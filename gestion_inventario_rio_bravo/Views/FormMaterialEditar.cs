using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Crear o editar un material del catálogo (RF-04). El código se propone según la categoría (§8.4).</summary>
    public partial class FormMaterialEditar : Ventana
    {
        private readonly Material material;
        private bool codigoEditadoAMano;

        public FormMaterialEditar(Material existente = null)
        {
            InitializeComponent();
            material = existente ?? new Material();
            Text = existente == null ? "Nuevo material" : "Editar material " + existente.Codigo;

            cmbUnidad.Items.AddRange(Material.Unidades);
            cmbCategoria.DataSource = CatalogoService.Categorias();

            txtCodigo.Text = material.Codigo;
            txtNombre.Text = material.Nombre;
            txtDescripcion.Text = material.Descripcion;
            cmbUnidad.SelectedItem = material.UnidadMedida;
            numMinimo.Value = material.StockMinimo;
            numPrecio.Value = material.PrecioUnitario;
            chkActivo.Checked = material.Activo;
            lblStockValor.Text = material.StockActual.ToString("#,0.##") + " " + material.UnidadMedida
                               + "   (cambia solo con compras, despachos o ajustes)";
            codigoEditadoAMano = existente != null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (material.IdCategoria != null) cmbCategoria.SelectedValue = material.IdCategoria;
            else cmbCategoria.SelectedIndex = -1;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
        }

        /// <summary>Para materiales nuevos propone el siguiente código de la categoría (RAD-001…), salvo que el usuario lo haya escrito.</summary>
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (codigoEditadoAMano || !(cmbCategoria.SelectedItem is Categoria c)) return;
            try
            {
                txtCodigo.Text = CatalogoService.SiguienteCodigo(c);
                codigoEditadoAMano = false;
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo proponer el código.", ex);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e) => codigoEditadoAMano = true;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var datos = new Material
            {
                IdMaterial = material.IdMaterial,
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                UnidadMedida = cmbUnidad.SelectedItem as string,
                IdCategoria = (cmbCategoria.SelectedItem as Categoria)?.IdCategoria,
                StockMinimo = numMinimo.Value,
                PrecioUnitario = numPrecio.Value,
                Activo = chkActivo.Checked
            };
            try
            {
                CatalogoService.Guardar(datos);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo guardar el material.", ex);
            }
        }
    }
}
