using System;
using System.Configuration;
using Npgsql;

namespace gestion_inventario_rio_bravo.Data
{
    public static class ConexionBD
    {
        // La cadena vive en connectionStrings.config (fuera de git).
        private static readonly Lazy<string> cadenaConexion = new Lazy<string>(() =>
        {
            ConnectionStringSettings cs;
            try { cs = ConfigurationManager.ConnectionStrings["RioBravo"]; }
            catch (ConfigurationErrorsException) { cs = null; } // connectionStrings.config no existe
            if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString) || cs.ConnectionString.Contains("TU_CONTRASEÑA"))
                throw new InvalidOperationException(
                    "Falta configurar la conexión. Copie connectionStrings.example.config como connectionStrings.config y complete la contraseña.");
            return cs.ConnectionString;
        });

        /// <summary>Devuelve una conexión ya abierta. Usar siempre dentro de un using.</summary>
        public static NpgsqlConnection ObtenerConexion()
        {
            var conn = new NpgsqlConnection(cadenaConexion.Value);
            conn.Open();
            return conn;
        }
    }
}
