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
        /// Asegura la clave de conexión de este PC (la pide si falta o fue rechazada) y,
        /// si la BD no tiene usuarios, crea el Gerente inicial. False = salir de la aplicación.
        /// </summary>
        private static bool PrepararBaseDeDatos()
        {
            string motivo = null;
            while (true)
            {
                if (ConfiguracionConexion.ObtenerPassword() == null)
                    using (var f = new FormConexion(motivo))
                        if (f.ShowDialog() != DialogResult.OK) return false;

                try
                {
                    if (!UsuarioService.ExisteAlguno())
                        using (var f = new FormUsuarioEditar(primerGerente: true))
                            return f.ShowDialog() == DialogResult.OK;
                    return true;
                }
                catch (Exception ex) when (ConexionBD.EsErrorDeAutenticacion(ex) && !ConfiguracionConexion.DesdeVariableEntorno)
                {
                    // La clave guardada ya no sirve (por ejemplo, se cambió): se borra y se vuelve a pedir.
                    ConfiguracionConexion.Borrar();
                    motivo = "La clave de conexión guardada en este PC ya no es válida.";
                }
                catch (Exception ex)
                {
                    Mensajes.Error(ConfiguracionConexion.DesdeVariableEntorno
                        ? $"No se pudo conectar con la base de datos (clave tomada de la variable {ConfiguracionConexion.VariablePassword})."
                        : "No se pudo conectar con la base de datos.", ex);
                    return false;
                }
            }
        }
    }
}
