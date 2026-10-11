using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Services;
using gestion_inventario_rio_bravo.Views;

namespace gestion_inventario_rio_bravo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Primera ejecución: sin usuarios en la BD, se crea el Gerente inicial.
            try
            {
                if (!UsuarioService.ExisteAlguno())
                    using (var f = new FormUsuarioEditar(primerGerente: true))
                        if (f.ShowDialog() != DialogResult.OK) return;
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo conectar con la base de datos.", ex);
                return;
            }

            // Login → ventana principal; "Cerrar sesión" vuelve al login.
            while (true)
            {
                using (var login = new FormLogin())
                    if (login.ShowDialog() != DialogResult.OK) return;

                using (var principal = new FormPrincipal())
                {
                    Application.Run(principal);
                    Sesion.CerrarSesion();
                    if (!principal.CerroSesion) return;
                }
            }
        }
    }
}
