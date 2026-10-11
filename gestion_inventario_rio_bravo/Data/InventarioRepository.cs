using System.Collections.Generic;
using gestion_inventario_rio_bravo.Models;
using Npgsql;

namespace gestion_inventario_rio_bravo.Data
{
    /// <summary>Movimientos de inventario (kardex). El stock lo actualiza el trigger de la BD (RN-05).</summary>
    public static class InventarioRepository
    {
        /// <summary>Ajuste manual (RF-24). El precio se toma del material al momento del ajuste.</summary>
        public static void RegistrarAjuste(int idMaterial, TipoAjuste tipo, decimal cantidad, string motivo, int idUsuario)
        {
            const string sql = @"INSERT INTO movimiento_inventario (id_material, tipo, cantidad, precio_unitario, fecha_hora, id_usuario, motivo)
                                 SELECT id_material, @tipo, @cantidad, precio_unitario, @ahora, @usuario, @motivo
                                   FROM material WHERE id_material = @material";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("material", idMaterial);
                cmd.Parameters.AddWithValue("tipo", tipo.ToString());
                cmd.Parameters.AddWithValue("cantidad", cantidad);
                cmd.Parameters.AddWithValue("usuario", idUsuario);
                cmd.Parameters.AddWithValue("motivo", motivo);
                ConexionBD.AgregarAhora(cmd, "ahora");
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Kardex de un material (RF-25), del más antiguo al más reciente, con saldo acumulado.</summary>
        public static List<Movimiento> Kardex(int idMaterial)
        {
            const string sql = @"SELECT mv.fecha_hora, mv.tipo, mv.cantidad, mv.precio_unitario, u.nombre,
                                        mv.id_orden, mv.id_despacho, mv.id_venta, o.nombre_obra, mv.motivo
                                   FROM movimiento_inventario mv
                                   JOIN usuario u ON u.id_usuario = mv.id_usuario
                                   LEFT JOIN obra o ON o.id_obra = mv.id_obra
                                  WHERE mv.id_material = @material
                                  ORDER BY mv.id_movimiento";
            var lista = new List<Movimiento>();
            decimal saldo = 0;
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("material", idMaterial);
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                    {
                        var tipo = r.GetString(1);
                        var cantidad = r.GetDecimal(2);
                        bool entrada = tipo == "ENTRADA_COMPRA" || tipo == "AJUSTE_ENTRADA";
                        saldo += entrada ? cantidad : -cantidad;
                        lista.Add(new Movimiento
                        {
                            FechaHora = r.GetDateTime(0),
                            Tipo = tipo,
                            Entrada = entrada ? cantidad : 0,
                            Salida = entrada ? 0 : cantidad,
                            Saldo = saldo,
                            PrecioUnitario = r.GetDecimal(3),
                            Usuario = r.GetString(4),
                            Documento = !r.IsDBNull(6) ? Folio.Despacho(r.GetInt32(6))
                                      : !r.IsDBNull(5) ? "OC-" + r.GetInt32(5).ToString("D6")
                                      : !r.IsDBNull(7) ? "VEN-" + r.GetInt32(7).ToString("D6")
                                      : "",
                            Detalle = ConexionBD.Texto(r, 8) ?? ConexionBD.Texto(r, 9)
                        });
                    }
            }
            lista.Reverse(); // lo más reciente arriba
            return lista;
        }
    }
}
