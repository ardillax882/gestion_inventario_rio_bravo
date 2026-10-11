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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var tipo = rdbEntrada.Checked ? TipoAjuste.AJUSTE_ENTRADA : TipoAjuste.AJUSTE_SALIDA;
                CatalogoService.RegistrarAjuste(Material, tipo, numCantidad.Value, txtMotivo.Text);
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
