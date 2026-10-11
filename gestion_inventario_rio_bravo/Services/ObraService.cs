using System.Collections.Generic;
using gestion_inventario_rio_bravo.Data;
using gestion_inventario_rio_bravo.Models;

namespace gestion_inventario_rio_bravo.Services
{
    /// <summary>Obras (RF-12..RF-14). Solo el Gerente crea y edita.</summary>
    public static class ObraService
    {
        public static List<Obra> Listar(params EstadoObra[] estados) => ObraRepository.Listar(estados);

        /// <summary>Obras a las que se les puede registrar una solicitud (no finalizadas).</summary>
        public static List<Obra> ListarActivas() => ObraRepository.Listar(EstadoObra.En_ejecucion, EstadoObra.En_planificacion);

        public static void Guardar(Obra o)
        {
            if (!Permisos.GestionarObras)
                throw new ValidacionException("Solo el Gerente puede crear o editar obras.");

            o.NombreObra = (o.NombreObra ?? "").Trim();
            o.Direccion = Limpiar(o.Direccion);
            o.Beneficiario = Limpiar(o.Beneficiario);
            o.Maestro = Limpiar(o.Maestro);

            if (o.NombreObra.Length == 0 || o.NombreObra.Length > 100)
                throw new ValidacionException("Ingrese el nombre de la obra (máximo 100 caracteres).");
            if (o.SuperficieM2 != null && (o.SuperficieM2 <= 0 || o.SuperficieM2 >= 10000))
                throw new ValidacionException("La superficie debe ser mayor que 0 y menor que 10.000 m².");
            if ((o.Direccion?.Length ?? 0) > 150 || (o.Beneficiario?.Length ?? 0) > 100 || (o.Maestro?.Length ?? 0) > 100)
                throw new ValidacionException("Ubicación admite 150 caracteres; beneficiario y maestro, 100.");
            if (o.PresupuestoMateriales < 0)
                throw new ValidacionException("El presupuesto no puede ser negativo.");

            if (o.IdObra == 0) o.IdObra = ObraRepository.Crear(o);
            else ObraRepository.Actualizar(o);
        }

        private static string Limpiar(string s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
    }
}
