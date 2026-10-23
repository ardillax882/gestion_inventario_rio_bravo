using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>
    /// Ajuste de inventario con motivo obligatorio (RF-24): inventario inicial, conteo físico, merma, devolución de obra.
    /// Es la forma de cargar el stock mientras no exista el módulo de compras.
    /// </summary>
    public partial class FormAjuste : Form
    {
        private const string SinObra = "(ninguna: no es devolución de obra)";
        private readonly Material inicial;

        public FormAjuste(Material material = null)
        {
            InitializeComponent();
            inicial = material;
            rdbEntrada.Checked = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                cmbMaterial.DataSource = CatalogoService.Buscar("");
                cmbObra.Items.Add(SinObra);
                cmbObra.Items.AddRange(ObraService.Listar().ToArray());
                cmbObra.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo cargar el catálogo.", ex);
            }
            // requiere el enlace de datos ya creado
            cmbMaterial.SelectedIndex = inicial == null ? -1 : cmbMaterial.FindStringExact(inicial.CodigoNombre);
            cmbMaterial.Enabled = inicial == null;
            MostrarStock();
        }

        private Material Material => cmbMaterial.SelectedItem as Material;

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e) => MostrarStock();

        private void MostrarStock() =>
            lblStockValor.Text = Material == null ? "—" : Material.StockActual.ToString("#,0.##") + " " + Material.UnidadMedida;

        private void btnMotivo_Click(object sender, EventArgs e) => txtMotivo.Text = ((Button)sender).Text;

        /// <summary>Devolución de material sobrante: es una entrada y se indica de qué obra vuelve.</summary>
        private void btnMotivoDevolucion_Click(object sender, EventArgs e)
        {
            btnMotivo_Click(sender, e);
            rdbEntrada.Checked = true;
            cmbObra.Focus();
            cmbObra.DroppedDown = cmbObra.SelectedIndex <= 0;
        }

        /// <summary>Solo las entradas pueden venir de una obra (devolución).</summary>
        private void rdbSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSalida.Checked && cmbObra.Items.Count > 0) cmbObra.SelectedIndex = 0;
            cmbObra.Enabled = !rdbSalida.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var tipo = rdbEntrada.Checked ? TipoAjuste.AJUSTE_ENTRADA : TipoAjuste.AJUSTE_SALIDA;
                CatalogoService.RegistrarAjuste(Material, tipo, numCantidad.Value, txtMotivo.Text, cmbObra.SelectedItem as Obra);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo registrar el ajuste.", ex);
            }
        }
    }
}
