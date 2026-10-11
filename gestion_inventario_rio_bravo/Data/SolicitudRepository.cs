using System;
using System.Collections.Generic;
using System.Linq;
using gestion_inventario_rio_bravo.Models;
using Npgsql;

namespace gestion_inventario_rio_bravo.Data
{
    /// <summary>Solicitudes (planillas) y sus despachos (§8.2, RF-15..RF-19).</summary>
    public static class SolicitudRepository
    {
        private const string SelectEncabezado = @"
            SELECT s.id_solicitud, s.id_obra, o.nombre_obra, o.superficie_m2, o.direccion, o.beneficiario, o.maestro, o.estado,
                   s.id_usuario, u.nombre, s.fecha_solicitud, s.estado, ua.nombre, s.fecha_aprobacion, s.motivo_rechazo,
                   s.equipo_trompo, s.equipo_placa, s.equipo_bano, s.observaciones,
                   COALESCE((SELECT SUM(v.saldo) FROM v_saldo_solicitud v WHERE v.id_solicitud = s.id_solicitud), 0)
              FROM solicitud s
              JOIN obra o ON o.id_obra = s.id_obra
              JOIN usuario u ON u.id_usuario = s.id_usuario
              LEFT JOIN usuario ua ON ua.id_usuario = s.id_usuario_aprueba ";

        /// <summary>Listado. idObra null = todas; estados vacío = todos.</summary>
        public static List<Solicitud> Listar(int? idObra, params EstadoSolicitud[] estados)
        {
            var sql = SelectEncabezado + @"WHERE (@obra::int IS NULL OR s.id_obra = @obra)
                                             AND (cardinality(@estados) = 0 OR s.estado = ANY(@estados))
                                           ORDER BY s.id_solicitud DESC";
            var lista = new List<Solicitud>();
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("obra", ConexionBD.Nulo(idObra));
                cmd.Parameters.AddWithValue("estados", Array.ConvertAll(estados, e => e.ToString()));
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) lista.Add(LeerEncabezado(r));
            }
            return lista;
        }

        /// <summary>Solicitud completa con sus líneas, ordenadas por categoría (orden del formulario) y material.</summary>
        public static Solicitud Obtener(int idSolicitud)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                Solicitud s;
                using (var cmd = new NpgsqlCommand(SelectEncabezado + "WHERE s.id_solicitud = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", idSolicitud);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return null;
                        s = LeerEncabezado(r);
                    }
                }

                const string sqlLineas = @"
                    SELECT v.id_detalle_solicitud, m.id_material, m.codigo, m.nombre, m.unidad_medida,
                           c.id_categoria, c.nombre, c.orden, v.cantidad_solicitada, v.cantidad_despachada, m.stock_actual
                      FROM v_saldo_solicitud v
                      JOIN material m ON m.id_material = v.id_material
                      JOIN categoria c ON c.id_categoria = v.id_categoria
                     WHERE v.id_solicitud = @id
                     ORDER BY c.orden, m.nombre";
                using (var cmd = new NpgsqlCommand(sqlLineas, conn))
                {
                    cmd.Parameters.AddWithValue("id", idSolicitud);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            s.Lineas.Add(new DetalleSolicitud
                            {
                                IdDetalleSolicitud = r.GetInt32(0),
                                IdMaterial = r.GetInt32(1),
                                Codigo = r.GetString(2),
                                Material = r.GetString(3),
                                Unidad = r.GetString(4),
                                IdCategoria = r.GetInt32(5),
                                Categoria = r.GetString(6),
                                CategoriaOrden = r.GetInt32(7),
                                CantidadSolicitada = r.GetDecimal(8),
                                CantidadDespachada = r.GetDecimal(9),
                                StockActual = r.GetDecimal(10)
                            });
                }
                return s;
            }
        }

        /// <summary>Despachos de la solicitud, del primero al último, con la cantidad entregada por línea.</summary>
        public static List<Despacho> Despachos(int idSolicitud)
        {
            const string sql = @"SELECT d.id_despacho, d.fecha_hora, u.nombre, d.recibido_por, d.observaciones,
                                        dd.id_detalle_solicitud, dd.cantidad
                                   FROM despacho d
                                   JOIN usuario u ON u.id_usuario = d.id_usuario
                                   JOIN detalle_despacho dd ON dd.id_despacho = d.id_despacho
                                  WHERE d.id_solicitud = @id
                                  ORDER BY d.id_despacho";
            var lista = new List<Despacho>();
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("id", idSolicitud);
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                    {
                        int id = r.GetInt32(0);
                        var d = lista.LastOrDefault();
                        if (d == null || d.IdDespacho != id)
                        {
                            d = new Despacho
                            {
                                IdDespacho = id,
                                IdSolicitud = idSolicitud,
                                FechaHora = r.GetDateTime(1),
                                UsuarioNombre = r.GetString(2),
                                RecibidoPor = ConexionBD.Texto(r, 3),
                                Observaciones = ConexionBD.Texto(r, 4)
                            };
                            lista.Add(d);
                        }
                        d.Cantidades[r.GetInt32(5)] = r.GetDecimal(6);
                    }
            }
            return lista;
        }

        /// <summary>
        /// Crea o actualiza una solicitud Pendiente con todas sus líneas (reemplaza las anteriores).
        /// Devuelve el id. Lanza ConflictoDatosException si ya no está Pendiente.
        /// </summary>
        public static int Guardar(Solicitud s)
        {
            return ConexionBD.EnTransaccion((conn, tx) =>
            {
                int id = s.IdSolicitud;
                if (s.EsNueva)
                {
                    const string sql = @"INSERT INTO solicitud (id_obra, id_usuario, fecha_solicitud, equipo_trompo, equipo_placa, equipo_bano, observaciones)
                                         VALUES (@obra, @usuario, @ahora, @trompo, @placa, @bano, @obs) RETURNING id_solicitud";
                    using (var cmd = new NpgsqlCommand(sql, conn, tx))
                    {
                        AgregarParametrosEncabezado(cmd, s);
                        cmd.Parameters.AddWithValue("usuario", s.IdUsuario);
                        ConexionBD.AgregarAhora(cmd, "ahora");
                        id = (int)cmd.ExecuteScalar();
                    }
                }
                else
                {
                    const string sql = @"UPDATE solicitud SET id_obra = @obra, equipo_trompo = @trompo, equipo_placa = @placa,
                                                equipo_bano = @bano, observaciones = @obs
                                          WHERE id_solicitud = @id AND estado = 'Pendiente'";
                    using (var cmd = new NpgsqlCommand(sql, conn, tx))
                    {
                        AgregarParametrosEncabezado(cmd, s);
                        cmd.Parameters.AddWithValue("id", id);
                        if (cmd.ExecuteNonQuery() == 0)
                            throw new ConflictoDatosException("La solicitud ya no está Pendiente; vuelva a abrirla.");
                    }
                    using (var cmd = new NpgsqlCommand("DELETE FROM detalle_solicitud WHERE id_solicitud = @id", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                const string sqlLinea = @"INSERT INTO detalle_solicitud (id_solicitud, id_material, id_categoria, cantidad_solicitada)
                                          VALUES (@id, @material, @categoria, @cantidad)";
                foreach (var l in s.Lineas)
                    using (var cmd = new NpgsqlCommand(sqlLinea, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.Parameters.AddWithValue("material", l.IdMaterial);
                        cmd.Parameters.AddWithValue("categoria", l.IdCategoria);
                        cmd.Parameters.AddWithValue("cantidad", l.CantidadSolicitada);
                        cmd.ExecuteNonQuery();
                    }
                return id;
            });
        }

        /// <summary>Aprueba (motivoRechazo null) o rechaza una solicitud Pendiente. False si ya no estaba Pendiente.</summary>
        public static bool Resolver(int idSolicitud, int idUsuario, string motivoRechazo)
        {
            const string sql = @"UPDATE solicitud SET estado = @estado, id_usuario_aprueba = @usuario, fecha_aprobacion = @ahora, motivo_rechazo = @motivo
                                  WHERE id_solicitud = @id AND estado = 'Pendiente'";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("estado", motivoRechazo == null ? "Aprobada" : "Rechazada");
                cmd.Parameters.AddWithValue("usuario", idUsuario);
                cmd.Parameters.AddWithValue("motivo", ConexionBD.Nulo(motivoRechazo));
                cmd.Parameters.AddWithValue("id", idSolicitud);
                ConexionBD.AgregarAhora(cmd, "ahora");
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        /// <summary>
        /// Registra un despacho en una sola transacción (RNF-03): encabezado, líneas, movimientos SALIDA_DESPACHO
        /// (el trigger descuenta stock y el CHECK impide stock negativo) y el nuevo estado de la solicitud (RN-07).
        /// La fila de la solicitud se bloquea para que dos despachos simultáneos no superen el saldo (RN-06).
        /// cantidades: id_detalle_solicitud → cantidad a entregar (> 0).
        /// </summary>
        public static int RegistrarDespacho(int idSolicitud, int idUsuario, string recibidoPor, string observaciones,
                                            IDictionary<int, decimal> cantidades)
        {
            return ConexionBD.EnTransaccion((conn, tx) =>
            {
                int idObra;
                using (var cmd = new NpgsqlCommand(@"SELECT s.estado, o.estado, s.id_obra FROM solicitud s JOIN obra o ON o.id_obra = s.id_obra
                                                      WHERE s.id_solicitud = @id FOR UPDATE OF s", conn, tx))
                {
                    cmd.Parameters.AddWithValue("id", idSolicitud);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) throw new ConflictoDatosException("La solicitud no existe.");
                        var estado = r.GetString(0);
                        if (estado != "Aprobada" && estado != "Despachada_parcial")
                            throw new ConflictoDatosException("La solicitud ya no se puede despachar (estado: " + estado.Replace('_', ' ') + ").");
                        if (r.GetString(1) != "En_ejecucion")
                            throw new ConflictoDatosException("Solo se despacha a obras En ejecución.");
                        idObra = r.GetInt32(2);
                    }
                }

                // Saldo y precio vigentes por línea, leídos con la solicitud bloqueada.
                var lineas = new Dictionary<int, Tuple<int, decimal, decimal>>(); // detalle → (material, saldo, precio)
                using (var cmd = new NpgsqlCommand(@"SELECT v.id_detalle_solicitud, v.id_material, v.saldo, m.precio_unitario
                                                       FROM v_saldo_solicitud v JOIN material m ON m.id_material = v.id_material
                                                      WHERE v.id_solicitud = @id", conn, tx))
                {
                    cmd.Parameters.AddWithValue("id", idSolicitud);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            lineas[r.GetInt32(0)] = Tuple.Create(r.GetInt32(1), r.GetDecimal(2), r.GetDecimal(3));
                }
                foreach (var c in cantidades)
                    if (!lineas.ContainsKey(c.Key) || c.Value <= 0 || c.Value > lineas[c.Key].Item2)
                        throw new ConflictoDatosException("Las cantidades superan el saldo pendiente; vuelva a abrir la solicitud.");

                int idDespacho;
                using (var cmd = new NpgsqlCommand(@"INSERT INTO despacho (id_solicitud, id_usuario, fecha_hora, recibido_por, observaciones)
                                                     VALUES (@id, @usuario, @ahora, @recibido, @obs) RETURNING id_despacho", conn, tx))
                {
                    cmd.Parameters.AddWithValue("id", idSolicitud);
                    cmd.Parameters.AddWithValue("usuario", idUsuario);
                    cmd.Parameters.AddWithValue("recibido", ConexionBD.Nulo(recibidoPor));
                    cmd.Parameters.AddWithValue("obs", ConexionBD.Nulo(observaciones));
                    ConexionBD.AgregarAhora(cmd, "ahora");
                    idDespacho = (int)cmd.ExecuteScalar();
                }

                foreach (var c in cantidades)
                {
                    var l = lineas[c.Key];
                    using (var cmd = new NpgsqlCommand(@"INSERT INTO detalle_despacho (id_despacho, id_detalle_solicitud, cantidad)
                                                         VALUES (@despacho, @detalle, @cantidad)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("despacho", idDespacho);
                        cmd.Parameters.AddWithValue("detalle", c.Key);
                        cmd.Parameters.AddWithValue("cantidad", c.Value);
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new NpgsqlCommand(@"INSERT INTO movimiento_inventario
                                                             (id_material, tipo, cantidad, precio_unitario, fecha_hora, id_usuario, id_obra, id_despacho)
                                                         VALUES (@material, 'SALIDA_DESPACHO', @cantidad, @precio, @ahora, @usuario, @obra, @despacho)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("material", l.Item1);
                        cmd.Parameters.AddWithValue("cantidad", c.Value);
                        cmd.Parameters.AddWithValue("precio", l.Item3);
                        cmd.Parameters.AddWithValue("usuario", idUsuario);
                        cmd.Parameters.AddWithValue("obra", idObra);
                        cmd.Parameters.AddWithValue("despacho", idDespacho);
                        ConexionBD.AgregarAhora(cmd, "ahora");
                        cmd.ExecuteNonQuery();
                    }
                }

                bool completa = lineas.All(l => l.Value.Item2 - (cantidades.TryGetValue(l.Key, out var c) ? c : 0) <= 0);
                using (var cmd = new NpgsqlCommand("UPDATE solicitud SET estado = @estado WHERE id_solicitud = @id", conn, tx))
                {
                    cmd.Parameters.AddWithValue("estado", completa ? "Despachada_total" : "Despachada_parcial");
                    cmd.Parameters.AddWithValue("id", idSolicitud);
                    cmd.ExecuteNonQuery();
                }
                return idDespacho;
            });
        }

        private static void AgregarParametrosEncabezado(NpgsqlCommand cmd, Solicitud s)
        {
            cmd.Parameters.AddWithValue("obra", s.IdObra);
            cmd.Parameters.AddWithValue("trompo", s.EquipoTrompo);
            cmd.Parameters.AddWithValue("placa", s.EquipoPlaca);
            cmd.Parameters.AddWithValue("bano", s.EquipoBano);
            cmd.Parameters.AddWithValue("obs", ConexionBD.Nulo(s.Observaciones));
        }

        private static Solicitud LeerEncabezado(NpgsqlDataReader r) => new Solicitud
        {
            IdSolicitud = r.GetInt32(0),
            IdObra = r.GetInt32(1),
            ObraNombre = r.GetString(2),
            ObraSuperficie = r.IsDBNull(3) ? (decimal?)null : r.GetDecimal(3),
            ObraDireccion = ConexionBD.Texto(r, 4),
            ObraBeneficiario = ConexionBD.Texto(r, 5),
            ObraMaestro = ConexionBD.Texto(r, 6),
            ObraEstado = (EstadoObra)Enum.Parse(typeof(EstadoObra), r.GetString(7)),
            IdUsuario = r.GetInt32(8),
            UsuarioNombre = r.GetString(9),
            FechaSolicitud = r.GetDateTime(10),
            Estado = (EstadoSolicitud)Enum.Parse(typeof(EstadoSolicitud), r.GetString(11)),
            AprobadorNombre = ConexionBD.Texto(r, 12),
            FechaAprobacion = r.IsDBNull(13) ? (DateTime?)null : r.GetDateTime(13),
            MotivoRechazo = ConexionBD.Texto(r, 14),
            EquipoTrompo = r.GetBoolean(15),
            EquipoPlaca = r.GetBoolean(16),
            EquipoBano = r.GetBoolean(17),
            Observaciones = ConexionBD.Texto(r, 18),
            SaldoTotal = r.GetDecimal(19)
        };
    }
}
