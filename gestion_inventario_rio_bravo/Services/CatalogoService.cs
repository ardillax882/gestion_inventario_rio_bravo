using System;
using System.Collections.Generic;
using System.Linq;
using gestion_inventario_rio_bravo.Data;
using gestion_inventario_rio_bravo.Models;
using Npgsql;

namespace gestion_inventario_rio_bravo.Services
{
    /// <summary>Catálogo de materiales, stock y ajustes de inventario (RF-04..RF-07, RF-24, RF-25).</summary>
    public static class CatalogoService
    {
        private static List<Categoria> _categorias;

        /// <summary>Las categorías son fijas (§8.3): se leen una vez por sesión.</summary>
        public static List<Categoria> Categorias() => _categorias ?? (_categorias = MaterialRepository.ListarCategorias());

        public static List<Material> Buscar(string filtro, bool incluirInactivos = false, bool soloBajoMinimo = false) =>
            MaterialRepository.Listar(filtro, incluirInactivos, soloBajoMinimo);

        public static string SiguienteCodigo(Categoria c) => MaterialRepository.SiguienteCodigo(c.Prefijo);

        public static void Guardar(Material m)
        {
            if (!Permisos.EditarCatalogo)
                throw new ValidacionException("No tiene permiso para editar el catálogo.");

            m.Codigo = (m.Codigo ?? "").Trim().ToUpperInvariant();
            m.Nombre = (m.Nombre ?? "").Trim();
            m.Descripcion = string.IsNullOrWhiteSpace(m.Descripcion) ? null : m.Descripcion.Trim();

            if (m.Codigo.Length == 0 || m.Codigo.Length > 20)
                throw new ValidacionException("Ingrese el código (máximo 20 caracteres).");
            if (m.Nombre.Length == 0 || m.Nombre.Length > 100)
                throw new ValidacionException("Ingrese el nombre (máximo 100 caracteres).");
            if (m.Descripcion != null && m.Descripcion.Length > 150)
                throw new ValidacionException("La descripción admite máximo 150 caracteres.");
            if (m.IdCategoria == null)
                throw new ValidacionException("Seleccione la categoría.");
            if (!Material.Unidades.Contains(m.UnidadMedida))
                throw new ValidacionException("Seleccione una unidad de medida de la lista.");
            if (m.StockMinimo < 0 || m.PrecioUnitario < 0)
                throw new ValidacionException("El stock mínimo y el precio no pueden ser negativos.");

            try
            {
                if (m.IdMaterial == 0) m.IdMaterial = MaterialRepository.Crear(m);
                else MaterialRepository.Actualizar(m);
            }
            catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
            {
                throw new ValidacionException("Ya existe un material con el código " + m.Codigo + ".");
            }
        }

        public static void RegistrarAjuste(Material m, TipoAjuste tipo, decimal cantidad, string motivo)
        {
            if (!Permisos.AjustarInventario)
                throw new ValidacionException("No tiene permiso para ajustar el inventario.");
            motivo = (motivo ?? "").Trim();
            if (m == null)
                throw new ValidacionException("Seleccione el material.");
            if (cantidad <= 0)
                throw new ValidacionException("La cantidad debe ser mayor que cero.");
            if (motivo.Length == 0 || motivo.Length > 200)
                throw new ValidacionException("Ingrese el motivo del ajuste (máximo 200 caracteres).");

            try
            {
                InventarioRepository.RegistrarAjuste(m.IdMaterial, tipo, cantidad, motivo, Sesion.Actual.IdUsuario);
            }
            catch (PostgresException ex) when (EsStockInsuficiente(ex))
            {
                throw new ValidacionException($"Stock insuficiente de {m.Nombre}: no puede quedar negativo (RN-04).");
            }
        }

        public static List<Movimiento> Kardex(Material m) => InventarioRepository.Kardex(m.IdMaterial);

        /// <summary>El CHECK stock_actual >= 0 de material rechazó el movimiento.</summary>
        public static bool EsStockInsuficiente(Exception ex) =>
            ex is PostgresException pg && pg.SqlState == PostgresErrorCodes.CheckViolation
            && pg.ConstraintName == "material_stock_actual_check";
    }
}
