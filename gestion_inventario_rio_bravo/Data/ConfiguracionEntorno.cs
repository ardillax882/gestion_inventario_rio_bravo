using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;

namespace gestion_inventario_rio_bravo.Data
{
    /// <summary>
    /// Configuración crítica (RNF-02) leída desde un archivo .env que NO va a git.
    /// Se busca junto al .exe y, si no está, en las carpetas superiores (así en desarrollo
    /// basta con el .env en la carpeta del proyecto). Para cambiar de base (local o producción)
    /// solo se edita el .env. Plantillas: .env.example (producción) y .env.local.example (Supabase local).
    /// </summary>
    public static class ConfiguracionEntorno
    {
        public const string NombreArchivo = ".env";
        private const string Marcador = "PEGA_AQUI_LA_CLAVE";
        private const int NivelesSuperiores = 3;

        private static readonly string[] Obligatorias =
        {
            "RIOBRAVO_DB_HOST", "RIOBRAVO_DB_PORT", "RIOBRAVO_DB_NAME",
            "RIOBRAVO_DB_USER", "RIOBRAVO_DB_PASSWORD"
        };

        private static string _cadena;

        /// <summary>Ruta del .env encontrado (null si no existe).</summary>
        public static string RutaArchivo { get; private set; }

        /// <summary>Cadena de conexión completa. Lanza ConfiguracionException si el .env falta o está incompleto.</summary>
        public static string CadenaConexion => _cadena ?? (_cadena = Construir());

        private static string Construir()
        {
            RutaArchivo = Buscar();
            if (RutaArchivo == null)
                throw new ConfiguracionException(
                    $"No se encontró el archivo {NombreArchivo}.\n\n" +
                    $"Copie el {NombreArchivo} entregado por el administrador en la carpeta del programa:\n" +
                    AppDomain.CurrentDomain.BaseDirectory);

            var v = Leer(RutaArchivo);
            foreach (var clave in Obligatorias)
                if (!v.TryGetValue(clave, out var valor) || valor.Length == 0)
                    throw new ConfiguracionException($"Falta {clave} en {RutaArchivo}");
            if (v["RIOBRAVO_DB_PASSWORD"] == Marcador)
                throw new ConfiguracionException($"Reemplace {Marcador} por la clave real en {RutaArchivo}");
            if (!int.TryParse(v["RIOBRAVO_DB_PORT"], out var puerto))
                throw new ConfiguracionException($"RIOBRAVO_DB_PORT no es un número en {RutaArchivo}");

            var b = new NpgsqlConnectionStringBuilder
            {
                Host = v["RIOBRAVO_DB_HOST"],
                Port = puerto,
                Database = v["RIOBRAVO_DB_NAME"],
                Username = v["RIOBRAVO_DB_USER"],
                Password = v["RIOBRAVO_DB_PASSWORD"],
                SslMode = SslMode.Require,
                TrustServerCertificate = true,
            };
            try
            {
                if (v.TryGetValue("RIOBRAVO_DB_SSLMODE", out var ssl) && ssl.Length > 0)
                    b.SslMode = (SslMode)Enum.Parse(typeof(SslMode), ssl, ignoreCase: true);
                if (v.TryGetValue("RIOBRAVO_DB_TRUST_SERVER_CERTIFICATE", out var trust) && trust.Length > 0)
                    b.TrustServerCertificate = bool.Parse(trust);
                if (v.TryGetValue("RIOBRAVO_DB_TIMEOUT", out var timeout) && timeout.Length > 0)
                    b.Timeout = int.Parse(timeout);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException || ex is OverflowException)
            {
                throw new ConfiguracionException($"Valor no válido en {RutaArchivo}: {ex.Message}");
            }
            return b.ConnectionString;
        }

        private static string Buscar()
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            for (int i = 0; dir != null && i <= NivelesSuperiores; i++, dir = dir.Parent)
            {
                var ruta = Path.Combine(dir.FullName, NombreArchivo);
                if (File.Exists(ruta)) return ruta;
            }
            return null;
        }

        // Formato: CLAVE=valor por línea; '#' al inicio = comentario; comillas opcionales.
        // No hay comentarios al final de la línea, para que la clave pueda contener '#'.
        private static Dictionary<string, string> Leer(string ruta)
        {
            var valores = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var linea in File.ReadAllLines(ruta))
            {
                var l = linea.Trim();
                if (l.Length == 0 || l.StartsWith("#")) continue;
                int igual = l.IndexOf('=');
                if (igual <= 0) continue;
                var valor = l.Substring(igual + 1).Trim();
                if (valor.Length >= 2 && (valor[0] == '"' || valor[0] == '\'') && valor[valor.Length - 1] == valor[0])
                    valor = valor.Substring(1, valor.Length - 2);
                valores[l.Substring(0, igual).Trim()] = valor;
            }
            return valores;
        }
    }

    /// <summary>El .env falta o tiene datos incorrectos.</summary>
    public class ConfiguracionException : Exception
    {
        public ConfiguracionException(string mensaje) : base(mensaje) { }
    }
}
