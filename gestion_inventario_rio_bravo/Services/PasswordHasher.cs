using System;
using System.Security.Cryptography;

namespace gestion_inventario_rio_bravo.Services
{
    /// <summary>
    /// Hash de contraseñas con PBKDF2-SHA256 (RNF-02).
    /// Formato guardado: pbkdf2-sha256$iteraciones$sal_base64$hash_base64
    /// </summary>
    public static class PasswordHasher
    {
        private const string Esquema = "pbkdf2-sha256";
        private const int Iteraciones = 100000;
        private const int TamanoSal = 16;
        private const int TamanoHash = 32;

        public static string Hash(string password)
        {
            var sal = new byte[TamanoSal];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(sal);

            var hash = Derivar(password, sal, Iteraciones, TamanoHash);
            return $"{Esquema}${Iteraciones}${Convert.ToBase64String(sal)}${Convert.ToBase64String(hash)}";
        }

        public static bool Verificar(string password, string almacenado)
        {
            var partes = (almacenado ?? "").Split('$');
            if (partes.Length != 4 || partes[0] != Esquema || !int.TryParse(partes[1], out int iteraciones))
                return false;

            var sal = Convert.FromBase64String(partes[2]);
            var esperado = Convert.FromBase64String(partes[3]);
            var calculado = Derivar(password, sal, iteraciones, esperado.Length);

            // Comparación en tiempo constante.
            int diferencia = 0;
            for (int i = 0; i < esperado.Length; i++)
                diferencia |= esperado[i] ^ calculado[i];
            return diferencia == 0;
        }

        private static byte[] Derivar(string password, byte[] sal, int iteraciones, int tamano)
        {
            using (var kdf = new Rfc2898DeriveBytes(password, sal, iteraciones, HashAlgorithmName.SHA256))
                return kdf.GetBytes(tamano);
        }
    }
}
