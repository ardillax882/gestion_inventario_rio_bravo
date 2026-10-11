using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Listado y gestión de usuarios (solo Gerente, RF-02).</summary>
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Cargar();
        }

        private void Cargar()
        {
            try
            {
                dgvUsuarios.DataSource = UsuarioService.Listar();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo cargar la lista de usuarios.", ex);
            }
        }

        private Usuario Seleccionado => dgvUsuarios.CurrentRow?.DataBoundItem as Usuario;

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var f = new FormUsuarioEditar())
                if (f.ShowDialog(this) == DialogResult.OK) Cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Seleccionado == null) return;
            using (var f = new FormUsuarioEditar(Seleccionado))
                if (f.ShowDialog(this) == DialogResult.OK) Cargar();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            if (Seleccionado == null) return;
            using (var f = new FormPassword(Seleccionado))
                f.ShowDialog(this);
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEditar_Click(sender, e);
        }
    }
}
