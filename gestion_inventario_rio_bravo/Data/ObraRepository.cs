using System;
using System.Collections.Generic;
using gestion_inventario_rio_bravo.Models;
using Npgsql;

namespace gestion_inventario_rio_bravo.Data
{
    public static class ObraRepository
    {
        /// <summary>Obras con el costo de lo despachado menos lo devuelto (RF-14). estados vacío = todas.</summary>
        public static List<Obra> Listar(params EstadoObra[] estados)
        {
            const string sql = @"SELECT o.id_obra, o.nombre_obra, o.superficie_m2, o.direccion, o.beneficiario, o.maestro,
                                        o.presupuesto_materiales, o.estado,
                                        COALESCE((SELECT SUM(CASE mv.tipo WHEN 'SALIDA_DESPACHO' THEN 1 ELSE -1 END * mv.cantidad * mv.precio_unitario)
                                                    FROM movimiento_inventario mv
                                                   WHERE mv.id_obra = o.id_obra AND mv.tipo IN ('SALIDA_DESPACHO', 'AJUSTE_ENTRADA')), 0),
                                        o.beneficiario_rut, o.beneficiario_telefono
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
                            CostoDespachado = r.GetDecimal(8),
                            BeneficiarioRut = ConexionBD.Texto(r, 9),
                            BeneficiarioTelefono = ConexionBD.Texto(r, 10)
                        });
            }
            return lista;
        }

        public static int Crear(Obra o)
        {
            const string sql = @"INSERT INTO obra (nombre_obra, superficie_m2, direccion, beneficiario, beneficiario_rut, beneficiario_telefono,
                                                   maestro, presupuesto_materiales, estado)
                                 VALUES (@nombre, @superficie, @direccion, @beneficiario, @beneficiarioRut, @beneficiarioTelefono,
                                         @maestro, @presupuesto, @estado) RETURNING id_obra";
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
                                        beneficiario = @beneficiario, beneficiario_rut = @beneficiarioRut, beneficiario_telefono = @beneficiarioTelefono,
                                        maestro = @maestro, presupuesto_materiales = @presupuesto, estado = @estado
                                  WHERE id_obra = @id";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                AgregarParametros(cmd, o);
                cmd.Parameters.AddWithValue("id", o.IdObra);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Préstamos de equipos: primero los que siguen en obra, luego los más recientes.</summary>
        public static List<PrestamoEquipo> Prestamos(bool soloPendientes)
        {
            const string sql = @"SELECT p.id_prestamo, p.equipo, p.id_obra, o.nombre_obra, p.fecha_prestamo, u.nombre,
                                        p.fecha_devolucion, ud.nombre, p.observaciones
                                   FROM prestamo_equipo p
                                   JOIN obra o ON o.id_obra = p.id_obra
                                   JOIN usuario u ON u.id_usuario = p.id_usuario
                                   LEFT JOIN usuario ud ON ud.id_usuario = p.id_usuario_devuelve
                                  WHERE NOT @pendientes OR p.fecha_devolucion IS NULL
                                  ORDER BY p.fecha_devolucion IS NOT NULL, p.fecha_prestamo DESC";
            var lista = new List<PrestamoEquipo>();
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("pendientes", soloPendientes);
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        lista.Add(new PrestamoEquipo
                        {
                            IdPrestamo = r.GetInt32(0),
                            Equipo = (Equipo)Enum.Parse(typeof(Equipo), r.GetString(1)),
                            IdObra = r.GetInt32(2),
                            ObraNombre = r.GetString(3),
                            FechaPrestamo = r.GetDateTime(4),
                            UsuarioNombre = r.GetString(5),
                            FechaDevolucion = r.IsDBNull(6) ? (DateTime?)null : r.GetDateTime(6),
                            RecibidoPor = ConexionBD.Texto(r, 7),
                            Observaciones = ConexionBD.Texto(r, 8)
                        });
            }
            return lista;
        }

        public static void Prestar(Equipo equipo, int idObra, int idUsuario, string observaciones)
        {
            const string sql = @"INSERT INTO prestamo_equipo (equipo, id_obra, id_usuario, fecha_prestamo, observaciones)
                                 VALUES (@equipo, @obra, @usuario, @ahora, @obs)";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("equipo", equipo.ToString());
                cmd.Parameters.AddWithValue("obra", idObra);
                cmd.Parameters.AddWithValue("usuario", idUsuario);
                cmd.Parameters.AddWithValue("obs", ConexionBD.Nulo(observaciones));
                ConexionBD.AgregarAhora(cmd, "ahora");
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Registra la vuelta del equipo a bodega. False si ya estaba devuelto.</summary>
        public static bool Devolver(int idPrestamo, int idUsuario)
        {
            const string sql = @"UPDATE prestamo_equipo SET fecha_devolucion = @ahora, id_usuario_devuelve = @usuario
                                  WHERE id_prestamo = @id AND fecha_devolucion IS NULL";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("id", idPrestamo);
                cmd.Parameters.AddWithValue("usuario", idUsuario);
                ConexionBD.AgregarAhora(cmd, "ahora");
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        private static void AgregarParametros(NpgsqlCommand cmd, Obra o)
        {
            cmd.Parameters.AddWithValue("nombre", o.NombreObra);
            cmd.Parameters.AddWithValue("superficie", ConexionBD.Nulo(o.SuperficieM2));
            cmd.Parameters.AddWithValue("direccion", ConexionBD.Nulo(o.Direccion));
            cmd.Parameters.AddWithValue("beneficiario", ConexionBD.Nulo(o.Beneficiario));
            cmd.Parameters.AddWithValue("beneficiarioRut", ConexionBD.Nulo(o.BeneficiarioRut));
            cmd.Parameters.AddWithValue("beneficiarioTelefono", ConexionBD.Nulo(o.BeneficiarioTelefono));
            cmd.Parameters.AddWithValue("maestro", ConexionBD.Nulo(o.Maestro));
            cmd.Parameters.AddWithValue("presupuesto", o.PresupuestoMateriales);
            cmd.Parameters.AddWithValue("estado", o.Estado.ToString());
        }
    }
}
