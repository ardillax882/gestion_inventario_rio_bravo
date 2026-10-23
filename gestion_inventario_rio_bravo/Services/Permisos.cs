using gestion_inventario_rio_bravo.Models;

namespace gestion_inventario_rio_bravo.Services
{
    /// <summary>
    /// Matriz de permisos de Docs/REQUERIMIENTOS.md §3. Las vistas consultan aquí, nunca el rol directamente.
    /// </summary>
    public static class Permisos
    {
        public static bool GestionarUsuarios => Sesion.Es(Rol.Gerente);
        public static bool GestionarObras => Sesion.Es(Rol.Gerente);
        public static bool EditarCatalogo => Sesion.Es(Rol.Gerente, Rol.Jefe_Compras);
        public static bool EditarProveedores => Sesion.Es(Rol.Gerente, Rol.Jefe_Compras);
        public static bool CrearOrdenCompra => Sesion.Es(Rol.Gerente, Rol.Jefe_Compras);
        public static bool RecepcionarOrdenCompra => Sesion.Es(Rol.Gerente, Rol.Bodeguero);
        public static bool RegistrarSolicitud => Sesion.Es(Rol.Gerente, Rol.Bodeguero);
        public static bool AprobarSolicitud => Sesion.Es(Rol.Gerente, Rol.Bodeguero);     // aprueba el encargado de bodega
        public static bool Despachar => Sesion.Es(Rol.Gerente, Rol.Bodeguero);
        public static bool AjustarInventario => Sesion.Es(Rol.Gerente, Rol.Bodeguero);
        public static bool PrestarEquipos => Sesion.Es(Rol.Gerente, Rol.Bodeguero);
        public static bool VerReportes => Sesion.Actual != null;
    }
}
