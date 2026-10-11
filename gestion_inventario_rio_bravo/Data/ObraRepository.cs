using System;
using System.Collections.Generic;
using gestion_inventario_rio_bravo.Models;
using Npgsql;

namespace gestion_inventario_rio_bravo.Data
{
    public static class ObraRepository
    {
        /// <summary>Obras con el costo de lo despachado (RF-14). estados vacío = todas.</summary>
        public static List<Obra> Listar(params EstadoObra[] estados)
        {
            const string sql = @"SELECT o.id_obra, o.nombre_obra, o.superficie_m2, o.direccion, o.beneficiario, o.maestro,
                                        o.presupuesto_materiales, o.estado,
                                        COALESCE((SELECT SUM(mv.cantidad * mv.precio_unitario) FROM movimiento_inventario mv
                                                   WHERE mv.id_obra = o.id_obra AND mv.tipo = 'SALIDA_DESPACHO'), 0)
                                   FROM obra o
                                  WHERE cardinality(@estados) = 0 OR o.estado = ANY(@estados)
                                  ORDER BY CASE o.estado WHEN 'En_ejecucion' THEN 0 WHEN 'En_planificacion' THEN 1 ELSE 2 END, o.nombre_obra";
            var lista = new List<Obra>();
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("estados", Array.ConvertAll(estados, e => e.ToString()));
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        lista.Add(new Obra
                        {
                            IdObra = r.GetInt32(0),
                            NombreObra = r.GetString(1),
                            SuperficieM2 = r.IsDBNull(2) ? (decimal?)null : r.GetDecimal(2),
                            Direccion = ConexionBD.Texto(r, 3),
                            Beneficiario = ConexionBD.Texto(r, 4),
                            Maestro = ConexionBD.Texto(r, 5),
                            PresupuestoMateriales = r.GetDecimal(6),
                            Estado = (EstadoObra)Enum.Parse(typeof(EstadoObra), r.GetString(7)),
                            CostoDespachado = r.GetDecimal(8)
                        });
            }
            return lista;
        }

        public static int Crear(Obra o)
        {
            const string sql = @"INSERT INTO obra (nombre_obra, superficie_m2, direccion, beneficiario, maestro, presupuesto_materiales, estado)
                                 VALUES (@nombre, @superficie, @direccion, @beneficiario, @maestro, @presupuesto, @estado) RETURNING id_obra";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                AgregarParametros(cmd, o);
                return (int)cmd.ExecuteScalar();
            }
        }

        public static void Actualizar(Obra o)
        {
            const string sql = @"UPDATE obra SET nombre_obra = @nombre, superficie_m2 = @superficie, direccion = @direccion,
                                        beneficiario = @beneficiario, maestro = @maestro, presupuesto_materiales = @presupuesto, estado = @estado
                                  WHERE id_obra = @id";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                AgregarParametros(cmd, o);
                cmd.Parameters.AddWithValue("id", o.IdObra);
                cmd.ExecuteNonQuery();
            }
        }

        private static void AgregarParametros(NpgsqlCommand cmd, Obra o)
        {
            cmd.Parameters.AddWithValue("nombre", o.NombreObra);
            cmd.Parameters.AddWithValue("superficie", ConexionBD.Nulo(o.SuperficieM2));
            cmd.Parameters.AddWithValue("direccion", ConexionBD.Nulo(o.Direccion));
            cmd.Parameters.AddWithValue("beneficiario", ConexionBD.Nulo(o.Beneficiario));
            cmd.Parameters.AddWithValue("maestro", ConexionBD.Nulo(o.Maestro));
            cmd.Parameters.AddWithValue("presupuesto", o.PresupuestoMateriales);
            cmd.Parameters.AddWithValue("estado", o.Estado.ToString());
        }
    }
}
