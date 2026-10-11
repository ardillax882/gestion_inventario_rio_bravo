using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Listado de obras con costo despachado vs. presupuesto (RF-12..RF-14). Solo el Gerente crea y edita.</summary>
    public partial class FormObras : Form
    {
        public FormObras()
        {
            InitializeComponent();
            dgvObras.AutoGenerateColumns = false;
            btnNueva.Visible = btnEditar.Visible = Permisos.GestionarObras;
            btnNuevaSolicitud.Visible = Permisos.RegistrarSolicitud;
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
                dgvObras.DataSource = chkFinalizadas.Checked ? ObraService.Listar() : ObraService.ListarActivas();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo cargar la lista de obras.", ex);
            }
        }

        private Obra Seleccionada => dgvObras.CurrentRow?.DataBoundItem as Obra;

        private void chkFinalizadas_CheckedChanged(object sender, EventArgs e) => Cargar();

        private void btnNueva_Click(object sender, EventArgs e)
        {
            using (var f = new FormObraEditar())
                if (f.ShowDialog(this) == DialogResult.OK) Cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Seleccionada == null) return;
            using (var f = new FormObraEditar(Seleccionada))
                if (f.ShowDialog(this) == DialogResult.OK) Cargar();
        }

        private void btnSolicitudes_Click(object sender, EventArgs e)
        {
            if (Seleccionada == null) return;
            using (var f = new FormSolicitudes(idObra: Seleccionada.IdObra))
                f.ShowDialog(this);
            Cargar();
        }

        private void btnNuevaSolicitud_Click(object sender, EventArgs e)
        {
            if (Seleccionada == null) return;
            using (var f = new FormSolicitud(idObra: Seleccionada.IdObra))
                f.ShowDialog(this);
            Cargar();
        }

        private void dgvObras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (Permisos.GestionarObras) btnEditar_Click(sender, e);
            else btnSolicitudes_Click(sender, e);
        }
    }
}
