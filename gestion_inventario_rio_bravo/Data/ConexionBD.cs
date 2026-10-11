using System;
using Npgsql;
using NpgsqlTypes;

namespace gestion_inventario_rio_bravo.Data
{
    public static class ConexionBD
    {
        /// <summary>Devuelve una conexión ya abierta. Usar siempre dentro de un using.</summary>
        public static NpgsqlConnection ObtenerConexion()
        {
            var conn = new NpgsqlConnection(ConfiguracionEntorno.CadenaConexion);
            conn.Open();
            return conn;
        }

        /// <summary>Ejecuta todo dentro de una transacción (RNF-03): se confirma al terminar o se revierte si hay excepción.</summary>
        public static T EnTransaccion<T>(Func<NpgsqlConnection, NpgsqlTransaction, T> accion)
        {
            using (var conn = ObtenerConexion())
            using (var tx = conn.BeginTransaction())
            {
                var resultado = accion(conn, tx);
                tx.Commit();
                return resultado;
            }
        }

        /// <summary>
        /// Hora local del PC para columnas TIMESTAMP. El servidor de Supabase está en UTC,
        /// por eso las fechas de los documentos las envía la app y no se usa now().
        /// </summary>
        public static void AgregarAhora(NpgsqlCommand cmd, string nombre) =>
            cmd.Parameters.Add(nombre, NpgsqlDbType.Timestamp).Value =
                DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);

        public static object Nulo(object valor) => valor ?? DBNull.Value;

        public static string Texto(NpgsqlDataReader r, int i) => r.IsDBNull(i) ? null : r.GetString(i);

        /// <summary>True si el error es de usuario/contraseña rechazados por el servidor.</summary>
        public static bool EsErrorDeAutenticacion(Exception ex) =>
            ex is PostgresException pg && pg.SqlState.StartsWith("28"); // 28000, 28P01
    }

    /// <summary>Los datos cambiaron entre que se leyeron y se guardaron (otro usuario, otro PC). El mensaje es para el usuario.</summary>
    public class ConflictoDatosException : Exception
    {
        public ConflictoDatosException(string mensaje) : base(mensaje) { }
    }
}
