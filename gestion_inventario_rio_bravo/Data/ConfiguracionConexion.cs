using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Npgsql;

namespace gestion_inventario_rio_bravo.Data
{
    /// <summary>
    /// Contraseña de la BD para este PC (RNF-02). Nunca va en el código ni en git.
    /// Orden de búsqueda:
    ///   1. Variable de entorno RIOBRAVO_DB_PASSWORD (pensada para el equipo de desarrollo).
    ///   2. Archivo %APPDATA%\RioBravo\conexion.dat, cifrado con DPAPI: solo lo puede leer
    ///      el mismo usuario de Windows en el mismo PC. Se crea con la pantalla "Configuración de conexión".
    /// </summary>
    public static class ConfiguracionConexion
    {
        public const string VariablePassword = "RIOBRAVO_DB_PASSWORD";

        public static readonly string RutaArchivo = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RioBravo", "conexion.dat");

        private static readonly byte[] Entropia = Encoding.UTF8.GetBytes("RioBravo.Inventario.Conexion");

        /// <summary>True si la contraseña viene de la variable de entorno (no se puede cambiar desde la app).</summary>
        public static bool DesdeVariableEntorno => !string.IsNullOrEmpty(LeerVariable());

        public static string ObtenerPassword() => LeerVariable() ?? LeerArchivo();

        /// <summary>Abre y cierra una conexión con la contraseña indicada; lanza excepción si falla.</summary>
        public static void Probar(string password)
        {
            using (var conn = new NpgsqlConnection(CadenaConexion(password)))
                conn.Open();
        }

        public static void Guardar(string password)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(RutaArchivo));
            var cifrado = ProtectedData.Protect(Encoding.UTF8.GetBytes(password), Entropia, DataProtectionScope.CurrentUser);
            File.WriteAllBytes(RutaArchivo, cifrado);
        }

        public static void Borrar()
        {
            if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);
        }

        internal static string CadenaConexion(string password)
        {
            var cs = ConfigurationManager.ConnectionStrings["RioBravo"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(cs))
                throw new InvalidOperationException("Falta la cadena de conexión \"RioBravo\" en App.config.");
            return new NpgsqlConnectionStringBuilder(cs) { Password = password }.ConnectionString;
        }

        // Primero la del proceso; si no, la de usuario guardada en Windows
        // (así funciona sin reiniciar Visual Studio después de crearla).
        private static string LeerVariable()
        {
            var valor = Environment.GetEnvironmentVariable(VariablePassword)
                     ?? Environment.GetEnvironmentVariable(VariablePassword, EnvironmentVariableTarget.User);
            return string.IsNullOrEmpty(valor) ? null : valor;
        }

        private static string LeerArchivo()
        {
            if (!File.Exists(RutaArchivo)) return null;
            try
            {
                var datos = ProtectedData.Unprotect(File.ReadAllBytes(RutaArchivo), Entropia, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(datos);
            }
            catch (CryptographicException)
            {
                return null; // archivo copiado de otro PC/usuario o dañado: se vuelve a configurar
            }
        }
    }
}
