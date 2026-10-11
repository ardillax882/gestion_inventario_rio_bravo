using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Data;
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

            if (!PrepararBaseDeDatos()) return;

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

        /// <summary>
        /// Comprueba la conexión configurada en el .env y, si la BD no tiene usuarios,
        /// crea el Gerente inicial. False = salir de la aplicación.
        /// </summary>
        private static bool PrepararBaseDeDatos()
        {
            try
            {
                if (!UsuarioService.ExisteAlguno())
                    using (var f = new FormUsuarioEditar(primerGerente: true))
                        return f.ShowDialog() == DialogResult.OK;
                return true;
            }
            catch (ConfiguracionException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex) when (ConexionBD.EsErrorDeAutenticacion(ex))
            {
                Mensajes.Advertencia($"La base de datos rechazó el usuario o la clave del archivo:\n{ConfiguracionEntorno.RutaArchivo}");
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo conectar con la base de datos. Revise la conexión a internet y el archivo .env.", ex);
            }
            return false;
        }
    }
}
