using System;
using System.Collections.Generic;
using System.Linq;
using gestion_inventario_rio_bravo.Data;
using gestion_inventario_rio_bravo.Models;
using Npgsql;

namespace gestion_inventario_rio_bravo.Services
{
    /// <summary>Flujo de la solicitud (RF-15..RF-19): Pendiente → Aprobada | Rechazada → Despachada parcial → Despachada total.</summary>
    public static class SolicitudService
    {
        public static List<Solicitud> Listar(int? idObra, params EstadoSolicitud[] estados) => SolicitudRepository.Listar(idObra, estados);

        /// <summary>Aprobadas o con entregas parciales: lo que la bodega tiene por despachar.</summary>
        public static List<Solicitud> PorDespachar() =>
            SolicitudRepository.Listar(null, EstadoSolicitud.Aprobada, EstadoSolicitud.Despachada_parcial);

        public static Solicitud Obtener(int id) => SolicitudRepository.Obtener(id)
            ?? throw new ValidacionException("La solicitud no existe.");

        public static List<Despacho> Despachos(int idSolicitud) => SolicitudRepository.Despachos(idSolicitud);

        /// <summary>Agrega una línea o, si el material ya está en esa categoría, reemplaza la cantidad.</summary>
        public static void AgregarLinea(Solicitud s, Material m, Categoria c, decimal cantidad)
        {
            if (!s.Editable)
                throw new ValidacionException("Solo se modifican las solicitudes Pendientes.");
            if (m == null)
                throw new ValidacionException("Seleccione un material de la lista.");
            if (c == null)
                throw new ValidacionException("Seleccione la categoría (sección del formulario).");
            if (cantidad <= 0)
                throw new ValidacionException("La cantidad debe ser mayor que cero.");

            var linea = s.Lineas.FirstOrDefault(l => l.IdMaterial == m.IdMaterial && l.IdCategoria == c.IdCategoria);
            if (linea == null)
            {
                linea = new DetalleSolicitud
                {
                    IdMaterial = m.IdMaterial,
                    Codigo = m.Codigo,
                    Material = m.Nombre,
                    Unidad = m.UnidadMedida,
                    IdCategoria = c.IdCategoria,
                    Categoria = c.Nombre,
                    CategoriaOrden = c.Orden,
                    StockActual = m.StockActual
                };
                s.Lineas.Add(linea);
            }
            linea.CantidadSolicitada = cantidad;
            s.Lineas.Sort((a, b) => a.CategoriaOrden != b.CategoriaOrden
                ? a.CategoriaOrden.CompareTo(b.CategoriaOrden)
                : string.Compare(a.Material, b.Material, StringComparison.CurrentCultureIgnoreCase));
        }

        public static void Guardar(Solicitud s)
        {
            if (!Permisos.RegistrarSolicitud)
                throw new ValidacionException("No tiene permiso para registrar solicitudes.");
            if (!s.Editable)
                throw new ValidacionException("Solo se modifican las solicitudes Pendientes.");
            if (s.IdObra == 0)
                throw new ValidacionException("Seleccione la obra.");
            if (s.Lineas.Count == 0)
                throw new ValidacionException("Agregue al menos un material.");
            s.Observaciones = string.IsNullOrWhiteSpace(s.Observaciones) ? null : s.Observaciones.Trim();
            if ((s.Observaciones?.Length ?? 0) > 300)
                throw new ValidacionException("Las observaciones admiten máximo 300 caracteres.");
            if (s.EsNueva) s.IdUsuario = Sesion.Actual.IdUsuario;

            s.IdSolicitud = Ejecutar(() => SolicitudRepository.Guardar(s));
        }

        public static void Aprobar(Solicitud s) => Resolver(s, null);

        public static void Rechazar(Solicitud s, string motivo)
        {
            motivo = (motivo ?? "").Trim();
            if (motivo.Length == 0 || motivo.Length > 200)
                throw new ValidacionException("Ingrese el motivo del rechazo (máximo 200 caracteres).");
            Resolver(s, motivo);
        }

        private static void Resolver(Solicitud s, string motivoRechazo)
        {
            if (!Permisos.AprobarSolicitud)
                throw new ValidacionException("No tiene permiso para aprobar o rechazar solicitudes.");
            if (!SolicitudRepository.Resolver(s.IdSolicitud, Sesion.Actual.IdUsuario, motivoRechazo))
                throw new ValidacionException("La solicitud ya no está Pendiente; vuelva a abrirla.");
        }

        /// <summary>Registra una entrega parcial o total (RF-17, RF-18). Devuelve el id del despacho.</summary>
        public static int Despachar(Solicitud s, IDictionary<int, decimal> cantidades, string recibidoPor, string observaciones)
        {
            if (!Permisos.Despachar)
                throw new ValidacionException("No tiene permiso para despachar.");
            if (!s.Despachable)
                throw new ValidacionException("Solo se despachan solicitudes Aprobadas o Despachadas parcialmente.");
            if (s.ObraEstado != EstadoObra.En_ejecucion)
                throw new ValidacionException($"La obra está \"{Obra.TextoEstado(s.ObraEstado)}\". Solo se despacha a obras En ejecución (RN-03).");

            var aEntregar = cantidades.Where(c => c.Value > 0).ToDictionary(c => c.Key, c => c.Value);
            if (aEntregar.Count == 0)
                throw new ValidacionException("Ingrese la cantidad a entregar en al menos una línea.");
            foreach (var l in s.Lineas.Where(l => aEntregar.ContainsKey(l.IdDetalleSolicitud)))
            {
                var c = aEntregar[l.IdDetalleSolicitud];
                if (c > l.Saldo)
                    throw new ValidacionException($"{l.Material}: la cantidad ({c:0.##}) supera el saldo pendiente ({l.Saldo:0.##}) (RN-06).");
                if (c > l.StockActual)
                    throw new ValidacionException($"{l.Material}: stock insuficiente (hay {l.StockActual:0.##} {l.Unidad}) (RN-04).");
            }

            recibidoPor = string.IsNullOrWhiteSpace(recibidoPor) ? null : recibidoPor.Trim();
            observaciones = string.IsNullOrWhiteSpace(observaciones) ? null : observaciones.Trim();
            if ((recibidoPor?.Length ?? 0) > 100 || (observaciones?.Length ?? 0) > 300)
                throw new ValidacionException("\"Recibido por\" admite 100 caracteres y observaciones 300.");

            return Ejecutar(() => SolicitudRepository.RegistrarDespacho(
                s.IdSolicitud, Sesion.Actual.IdUsuario, recibidoPor, observaciones, aEntregar));
        }

        /// <summary>Traduce las negativas de la BD (cambios concurrentes, stock) a mensajes para el usuario.</summary>
        private static int Ejecutar(Func<int> accion)
        {
            try { return accion(); }
            catch (ConflictoDatosException ex) { throw new ValidacionException(ex.Message); }
            catch (PostgresException ex) when (CatalogoService.EsStockInsuficiente(ex))
            {
                throw new ValidacionException("Stock insuficiente: otro usuario despachó o ajustó este material. Vuelva a abrir la solicitud.");
            }
        }
    }
}
