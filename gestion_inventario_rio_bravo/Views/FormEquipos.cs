using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>
    /// Equipos prestados a las obras (trompo, placa compactadora, baño químico): deben volver a bodega.
    /// Prestar y registrar la devolución: Gerente y Bodeguero. Los demás solo consultan.
    /// </summary>
    public partial class FormEquipos : Form
    {
        public FormEquipos()
        {
            InitializeComponent();
            dgvPrestamos.AutoGenerateColumns = false;
            cmbEquipo.DisplayMember = "Texto";
            cmbEquipo.ValueMember = "Valor";
            cmbEquipo.DataSource = Enum.GetValues(typeof(Equipo)).Cast<Equipo>()
                .Select(e => new { Valor = e, Texto = PrestamoEquipo.TextoEquipo(e) }).ToList();
            pnlPrestar.Visible = btnDevolver.Visible = Permisos.PrestarEquipos;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                cmbObra.DataSource = ObraService.ListarActivas();
                cmbObra.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo cargar la lista de obras.", ex);
            }
            Cargar();
        }

        private void Cargar()
        {
            try
            {
                dgvPrestamos.DataSource = ObraService.Prestamos(soloPendientes: !chkDevueltos.Checked);
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo cargar la lista de equipos prestados.", ex);
            }
        }

        private PrestamoEquipo Seleccionado => dgvPrestamos.CurrentRow?.DataBoundItem as PrestamoEquipo;

        private void chkDevueltos_CheckedChanged(object sender, EventArgs e) => Cargar();

        private void btnPrestar_Click(object sender, EventArgs e)
        {
            try
            {
                ObraService.PrestarEquipo((Equipo)cmbEquipo.SelectedValue, cmbObra.SelectedItem as Obra, txtObservaciones.Text);
                txtObservaciones.Text = "";
                Cargar();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo registrar el préstamo.", ex);
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            var p = Seleccionado;
            if (p == null || p.Devuelto) return;
            if (!Mensajes.Confirmar($"¿Registrar que {p.EquipoTexto} volvió a bodega desde {p.ObraNombre}?")) return;
            try
            {
                ObraService.DevolverEquipo(p);
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo registrar la devolución.", ex);
            }
            Cargar();
        }

        /// <summary>Los que siguen en obra se destacan; los devueltos van en gris.</summary>
        private void dgvPrestamos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!(dgvPrestamos.Rows[e.RowIndex].DataBoundItem is PrestamoEquipo p)) return;
            dgvPrestamos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = p.Devuelto ? SystemColors.GrayText : SystemColors.ControlText;
        }
    }
}
