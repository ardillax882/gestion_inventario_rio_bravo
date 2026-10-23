using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    public partial class FormLogin : Ventana
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            Cursor = Cursors.WaitCursor;
            try
            {
                if (Sesion.IniciarSesion(txtLogin.Text, txtPassword.Text))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
                lblError.Text = "RUT/email o contraseña incorrectos, o usuario inactivo.";
                txtPassword.Clear();
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo iniciar sesión.", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
