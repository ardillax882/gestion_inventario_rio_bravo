using gestion_inventario_rio_bravo.Data;
using gestion_inventario_rio_bravo.Models;

namespace gestion_inventario_rio_bravo.Services
{
    /// <summary>Usuario con sesión iniciada en esta instancia de la aplicación.</summary>
    public static class Sesion
    {
        public static Usuario Actual { get; private set; }

        /// <summary>Acepta RUT (con o sin puntos/guion) o email. Devuelve false si los datos no coinciden o el usuario está inactivo.</summary>
        public static bool IniciarSesion(string login, string password)
        {
            login = (login ?? "").Trim();
            if (login.Length == 0 || string.IsNullOrEmpty(password)) return false;

            var usuario = UsuarioRepository.BuscarPorLogin(Rut.Normalizar(login), login, out string hash);
            if (usuario == null || !usuario.Activo || !PasswordHasher.Verificar(password, hash))
                return false;

            Actual = usuario;
            return true;
        }

        public static void CerrarSesion() => Actual = null;

        public static bool Es(params Rol[] roles) => Actual != null && System.Array.IndexOf(roles, Actual.Rol) >= 0;
    }
}
