using System;
using System.Collections.Generic;
using gestion_inventario_rio_bravo.Models;
using Npgsql;

namespace gestion_inventario_rio_bravo.Data
{
    public static class MaterialRepository
    {
        private const string Select = @"SELECT m.id_material, m.codigo, m.nombre, m.descripcion, m.unidad_medida, m.id_categoria,
                                               c.nombre, m.stock_actual, m.stock_minimo, m.precio_unitario, m.activo
                                          FROM material m LEFT JOIN categoria c ON c.id_categoria = m.id_categoria ";

        public static List<Categoria> ListarCategorias()
        {
            var lista = new List<Categoria>();
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("SELECT id_categoria, nombre, prefijo, orden FROM categoria ORDER BY orden", conn))
            using (var r = cmd.ExecuteReader())
                while (r.Read())
                    lista.Add(new Categoria { IdCategoria = r.GetInt32(0), Nombre = r.GetString(1), Prefijo = r.GetString(2), Orden = r.GetInt32(3) });
            return lista;
        }

        /// <summary>Busca por código o nombre (RF-06). filtro vacío = todos.</summary>
        public static List<Material> Listar(string filtro, bool incluirInactivos, bool soloBajoMinimo)
        {
            var sql = Select + @"WHERE (@f = '' OR m.codigo ILIKE '%' || @f || '%' OR m.nombre ILIKE '%' || @f || '%')
                                   AND (@inactivos OR m.activo)
                                   AND (NOT @bajo OR (m.stock_minimo > 0 AND m.stock_actual <= m.stock_minimo))
                                 ORDER BY m.activo DESC, c.orden NULLS LAST, m.codigo";
            var lista = new List<Material>();
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("f", (filtro ?? "").Trim());
                cmd.Parameters.AddWithValue("inactivos", incluirInactivos);
                cmd.Parameters.AddWithValue("bajo", soloBajoMinimo);
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) lista.Add(Leer(r));
            }
            return lista;
        }

        /// <summary>Siguiente código libre para el prefijo de la categoría: RAD-001, RAD-002… (§8.4).</summary>
        public static string SiguienteCodigo(string prefijo)
        {
            const string sql = @"SELECT COALESCE(MAX(substring(codigo FROM 5)::int), 0) + 1
                                   FROM material WHERE codigo ~ ('^' || @p || '-[0-9]+$')";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("p", prefijo);
                return prefijo + "-" + Convert.ToInt32(cmd.ExecuteScalar()).ToString("D3");
            }
        }

        public static int Crear(Material m)
        {
            const string sql = @"INSERT INTO material (codigo, nombre, descripcion, unidad_medida, id_categoria, stock_minimo, precio_unitario, activo)
                                 VALUES (@codigo, @nombre, @descripcion, @unidad, @categoria, @minimo, @precio, @activo) RETURNING id_material";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                AgregarParametros(cmd, m);
                return (int)cmd.ExecuteScalar();
            }
        }

        public static void Actualizar(Material m)
        {
            const string sql = @"UPDATE material SET codigo = @codigo, nombre = @nombre, descripcion = @descripcion, unidad_medida = @unidad,
                                        id_categoria = @categoria, stock_minimo = @minimo, precio_unitario = @precio, activo = @activo
                                  WHERE id_material = @id";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                AgregarParametros(cmd, m);
                cmd.Parameters.AddWithValue("id", m.IdMaterial);
                cmd.ExecuteNonQuery();
            }
        }

        private static void AgregarParametros(NpgsqlCommand cmd, Material m)
        {
            cmd.Parameters.AddWithValue("codigo", m.Codigo);
            cmd.Parameters.AddWithValue("nombre", m.Nombre);
            cmd.Parameters.AddWithValue("descripcion", ConexionBD.Nulo(m.Descripcion));
            cmd.Parameters.AddWithValue("unidad", m.UnidadMedida);
            cmd.Parameters.AddWithValue("categoria", ConexionBD.Nulo(m.IdCategoria));
            cmd.Parameters.AddWithValue("minimo", m.StockMinimo);
            cmd.Parameters.AddWithValue("precio", m.PrecioUnitario);
            cmd.Parameters.AddWithValue("activo", m.Activo);
        }

        private static Material Leer(NpgsqlDataReader r) => new Material
        {
            IdMaterial = r.GetInt32(0),
            Codigo = r.GetString(1),
            Nombre = r.GetString(2),
            Descripcion = ConexionBD.Texto(r, 3),
            UnidadMedida = r.GetString(4),
            IdCategoria = r.IsDBNull(5) ? (int?)null : r.GetInt32(5),
            CategoriaNombre = ConexionBD.Texto(r, 6),
            StockActual = r.GetDecimal(7),
            StockMinimo = r.GetDecimal(8),
            PrecioUnitario = r.GetDecimal(9),
            Activo = r.GetBoolean(10)
        };
    }
}
