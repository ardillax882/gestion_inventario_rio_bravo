using System;

namespace gestion_inventario_rio_bravo.Services
{
    /// <summary>Error de regla de negocio o de datos ingresados; su mensaje se muestra tal cual al usuario.</summary>
    public class ValidacionException : Exception
    {
        public ValidacionException(string mensaje) : base(mensaje) { }
    }
}
