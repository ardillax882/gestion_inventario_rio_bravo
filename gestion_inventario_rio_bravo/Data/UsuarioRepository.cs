using System;
using System.Collections.Generic;
using gestion_inventario_rio_bravo.Models;
using Npgsql;

namespace gestion_inventario_rio_bravo.Data
{
    public static class UsuarioRepository
    {
        private const string Columnas = "id_usuario, rut, nombre, email, rol, activo";

        public static bool ExisteAlguno()
        {
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("SELECT EXISTS (SELECT 1 FROM usuario)", conn))
                return (bool)cmd.ExecuteScalar();
        }

        /// <summary>Busca por RUT normalizado o por email (sin distinguir mayúsculas). Devuelve null si no existe.</summary>
        public static Usuario BuscarPorLogin(string rut, string email, out string passwordHash)
        {
            passwordHash = null;
            const string sql = "SELECT " + Columnas + ", password_hash FROM usuario WHERE rut = @rut OR lower(email) = lower(@email)";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("rut", (object)rut ?? DBNull.Value);
                cmd.Parameters.AddWithValue("email", (object)email ?? DBNull.Value);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;
                    passwordHash = r.GetString(6);
                    return Leer(r);
                }
            }
        }

        public static List<Usuario> Listar()
        {
            var lista = new List<Usuario>();
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("SELECT " + Columnas + " FROM usuario ORDER BY activo DESC, nombre", conn))
            using (var r = cmd.ExecuteReader())
                while (r.Read()) lista.Add(Leer(r));
            return lista;
        }

        public static int Crear(Usuario u, string passwordHash)
        {
            const string sql = @"INSERT INTO usuario (rut, nombre, email, password_hash, rol, activo)
                                 VALUES (@rut, @nombre, @email, @hash, @rol, @activo) RETURNING id_usuario";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                AgregarParametros(cmd, u);
                cmd.Parameters.AddWithValue("hash", passwordHash);
                return (int)cmd.ExecuteScalar();
            }
        }

        public static void Actualizar(Usuario u)
        {
            const string sql = @"UPDATE usuario SET rut = @rut, nombre = @nombre, email = @email, rol = @rol, activo = @activo
                                 WHERE id_usuario = @id";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                AgregarParametros(cmd, u);
                cmd.Parameters.AddWithValue("id", u.IdUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public static void CambiarPassword(int idUsuario, string passwordHash)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("UPDATE usuario SET password_hash = @hash WHERE id_usuario = @id", conn))
            {
                cmd.Parameters.AddWithValue("hash", passwordHash);
                cmd.Parameters.AddWithValue("id", idUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Gerentes activos distintos del usuario indicado.</summary>
        public static int ContarOtrosGerentesActivos(int idUsuario)
        {
            const string sql = "SELECT count(*) FROM usuario WHERE rol = 'Gerente' AND activo AND id_usuario <> @id";
            using (var conn = ConexionBD.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("id", idUsuario);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private static void AgregarParametros(NpgsqlCommand cmd, Usuario u)
        {
            cmd.Parameters.AddWithValue("rut", u.Rut);
            cmd.Parameters.AddWithValue("nombre", u.Nombre);
            cmd.Parameters.AddWithValue("email", u.Email);
            cmd.Parameters.AddWithValue("rol", u.Rol.ToString());
            cmd.Parameters.AddWithValue("activo", u.Activo);
        }

        private static Usuario Leer(NpgsqlDataReader r) => new Usuario
        {
            IdUsuario = r.GetInt32(0),
            Rut = r.GetString(1),
            Nombre = r.GetString(2),
            Email = r.GetString(3),
            Rol = (Rol)Enum.Parse(typeof(Rol), r.GetString(4)),
            Activo = r.GetBoolean(5)
        };
    }
}
