using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Ventana principal. El menú se arma según los permisos del usuario en sesión (RF-03).</summary>
    public partial class FormPrincipal : Form
    {
        /// <summary>True si el usuario eligió "Cerrar sesión" (volver al login) en vez de salir.</summary>
        public bool CerroSesion { get; private set; }

        public FormPrincipal()
        {
            InitializeComponent();
            var u = Sesion.Actual;
            lblSesion.Text = $"Usuario: {u.Nombre}  ·  Rol: {u.RolTexto}";
            lblBienvenida.Text = $"Bienvenido(a), {u.Nombre}";

            mnuAdministracion.Visible = Permisos.GestionarUsuarios;
        }

        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            using (var f = new FormUsuarios())
                f.ShowDialog(this);
        }

        private void mnuCambiarPassword_Click(object sender, EventArgs e)
        {
            using (var f = new FormPassword(Sesion.Actual))
                f.ShowDialog(this);
        }

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            CerroSesion = true;
            Close();
        }

        private void mnuSalir_Click(object sender, EventArgs e) => Close();
    }
}
