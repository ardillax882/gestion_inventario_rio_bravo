using System;
using Npgsql;

namespace gestion_inventario_rio_bravo.Data
{
    public static class ConexionBD
    {
        /// <summary>Devuelve una conexión ya abierta. Usar siempre dentro de un using.</summary>
        public static NpgsqlConnection ObtenerConexion()
        {
            var password = ConfiguracionConexion.ObtenerPassword();
            if (string.IsNullOrEmpty(password))
                throw new InvalidOperationException("La conexión a la base de datos no está configurada en este PC.");

            var conn = new NpgsqlConnection(ConfiguracionConexion.CadenaConexion(password));
            conn.Open();
            return conn;
        }

        /// <summary>True si el error es de usuario/contraseña rechazados por el servidor.</summary>
        public static bool EsErrorDeAutenticacion(Exception ex) =>
            ex is PostgresException pg && pg.SqlState.StartsWith("28"); // 28000, 28P01
    }
}
