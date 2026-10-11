using System.Linq;

namespace gestion_inventario_rio_bravo.Services
{
    /// <summary>RUT chileno: normalización a "12345678-5" y validación del dígito verificador (módulo 11).</summary>
    public static class Rut
    {
        /// <summary>Quita puntos, guiones y espacios; devuelve "cuerpo-DV" en mayúscula, o null si no tiene forma de RUT.</summary>
        public static string Normalizar(string rut)
        {
            var limpio = new string((rut ?? "").Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();
            if (limpio.Length < 2) return null;

            var cuerpo = limpio.Substring(0, limpio.Length - 1).TrimStart('0');
            var dv = limpio[limpio.Length - 1];
            if (cuerpo.Length == 0 || cuerpo.Length > 8 || !cuerpo.All(char.IsDigit) || !(char.IsDigit(dv) || dv == 'K'))
                return null;
            return cuerpo + "-" + dv;
        }

        public static bool EsValido(string rut)
        {
            var normalizado = Normalizar(rut);
            if (normalizado == null) return false;

            var cuerpo = normalizado.Substring(0, normalizado.Length - 2);
            int suma = 0, factor = 2;
            for (int i = cuerpo.Length - 1; i >= 0; i--)
            {
                suma += (cuerpo[i] - '0') * factor;
                factor = factor == 7 ? 2 : factor + 1;
            }
            int resto = 11 - suma % 11;
            char esperado = resto == 11 ? '0' : resto == 10 ? 'K' : (char)('0' + resto);
            return normalizado[normalizado.Length - 1] == esperado;
        }
    }
}
