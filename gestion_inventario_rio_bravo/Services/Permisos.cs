using gestion_inventario_rio_bravo.Models;

namespace gestion_inventario_rio_bravo.Services
{
    /// <summary>
    /// Matriz de permisos de Docs/REQUERIMIENTOS.md §3. Las vistas consultan aquí, nunca el rol directamente.
    /// Puntos pendientes con el cliente: AprobarSolicitud (P-01) y RegistrarVenta (P-06).
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
        public static bool AprobarSolicitud => Sesion.Es(Rol.Gerente);                    // P-01 provisorio
        public static bool Despachar => Sesion.Es(Rol.Gerente, Rol.Bodeguero);
        public static bool RegistrarVenta => Sesion.Es(Rol.Gerente, Rol.Jefe_Compras);     // P-06 provisorio
        public static bool AjustarInventario => Sesion.Es(Rol.Gerente, Rol.Bodeguero);
        public static bool VerReportes => Sesion.Actual != null;
    }
}
