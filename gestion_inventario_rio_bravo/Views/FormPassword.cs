using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Nueva contraseña para un usuario: el propio (cambiar mi contraseña) o cualquiera si es el Gerente (restablecer).</summary>
    public partial class FormPassword : Ventana
    {
        private readonly Usuario usuario;

        public FormPassword(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            lblUsuario.Text = $"Usuario: {usuario.Nombre} ({usuario.Rut})";
            lblInfo.Text = $"Mínimo {UsuarioService.LargoMinimoPassword} caracteres.";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioService.CambiarPassword(usuario.IdUsuario, txtPassword.Text, txtConfirmar.Text);
                Mensajes.Info("Contraseña actualizada.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo cambiar la contraseña.", ex);
            }
        }
    }
}
