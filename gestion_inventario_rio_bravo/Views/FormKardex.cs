using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Kardex de un material (RF-25): todos sus movimientos con saldo. Solo lectura.</summary>
    public partial class FormKardex : Ventana
    {
        private readonly Material material;

        public FormKardex(Material m)
        {
            InitializeComponent();
            material = m;
            dgvMovimientos.AutoGenerateColumns = false;
            Text = "Movimientos de " + m.CodigoNombre;
            lblMaterial.Text = $"{m.CodigoNombre}   ·   Stock actual: {m.StockActual:#,0.##} {m.UnidadMedida}   ·   Mínimo: {m.StockMinimo:#,0.##}";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                dgvMovimientos.DataSource = CatalogoService.Kardex(material);
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudieron cargar los movimientos.", ex);
            }
        }
    }
}
