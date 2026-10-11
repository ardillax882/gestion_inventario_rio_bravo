using System;
using System.Drawing;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Catálogo de materiales con su stock actual (RF-04, RF-06, RF-07). El stock solo cambia con movimientos.</summary>
    public partial class FormMateriales : Form
    {
        public FormMateriales(bool soloBajoMinimo = false)
        {
            InitializeComponent();
            dgvMateriales.AutoGenerateColumns = false;
            chkBajoMinimo.Checked = soloBajoMinimo;
            btnNuevo.Visible = btnEditar.Visible = Permisos.EditarCatalogo;
            btnAjuste.Visible = Permisos.AjustarInventario;
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
                var lista = CatalogoService.Buscar(txtBuscar.Text, chkInactivos.Checked, chkBajoMinimo.Checked);
                dgvMateriales.DataSource = lista;
                lblTotal.Text = lista.Count + " materiales";
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo cargar el catálogo.", ex);
            }
        }

        private Material Seleccionado => dgvMateriales.CurrentRow?.DataBoundItem as Material;

        private void Filtro_Changed(object sender, EventArgs e) => Cargar();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var f = new FormMaterialEditar())
                if (f.ShowDialog(this) == DialogResult.OK) Cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Seleccionado == null) return;
            using (var f = new FormMaterialEditar(Seleccionado))
                if (f.ShowDialog(this) == DialogResult.OK) Cargar();
        }

        private void btnAjuste_Click(object sender, EventArgs e)
        {
            if (Seleccionado == null) return;
            using (var f = new FormAjuste(Seleccionado))
                if (f.ShowDialog(this) == DialogResult.OK) Cargar();
        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            if (Seleccionado == null) return;
            using (var f = new FormKardex(Seleccionado))
                f.ShowDialog(this);
        }

        private void dgvMateriales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (Permisos.EditarCatalogo) btnEditar_Click(sender, e);
            else btnKardex_Click(sender, e);
        }

        /// <summary>Bajo mínimo en rojo (RF-07), inactivos en gris.</summary>
        private void dgvMateriales_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!(dgvMateriales.Rows[e.RowIndex].DataBoundItem is Material m)) return;
            var estilo = dgvMateriales.Rows[e.RowIndex].DefaultCellStyle;
            estilo.ForeColor = !m.Activo ? SystemColors.GrayText : m.BajoMinimo ? Color.Firebrick : SystemColors.ControlText;
            estilo.BackColor = m.Activo && m.BajoMinimo ? Color.MistyRose : SystemColors.Window;
        }
    }
}
