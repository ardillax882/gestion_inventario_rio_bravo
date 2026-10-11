namespace gestion_inventario_rio_bravo.Models
{
    /// <summary>Roles del sistema. Los nombres coinciden con los valores de usuario.rol en la BD.</summary>
    public enum Rol
    {
        Gerente,
        Jefe_Compras,
        Bodeguero
    }

    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Rol Rol { get; set; }
        public bool Activo { get; set; } = true;

        public string RolTexto => TextoRol(Rol);

        public static string TextoRol(Rol rol) => rol == Rol.Jefe_Compras ? "Jefe de Compras" : rol.ToString();
    }
}
