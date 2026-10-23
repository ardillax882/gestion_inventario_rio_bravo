using System;
using System.Linq;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Crear o editar una obra (RF-12, RF-13). Sus datos forman el encabezado de la planilla.</summary>
    public partial class FormObraEditar : Ventana
    {
        private readonly Obra obra;

        public FormObraEditar(Obra existente = null)
        {
            InitializeComponent();
            obra = existente ?? new Obra();
            Text = existente == null ? "Nueva obra" : "Editar obra";

            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoObra)).Cast<EstadoObra>()
                .Select(e => new { Valor = e, Texto = Obra.TextoEstado(e) }).ToList();

            txtNombre.Text = obra.NombreObra;
            numSuperficie.Value = obra.SuperficieM2 ?? 0;
            txtDireccion.Text = obra.Direccion;
            txtBeneficiario.Text = obra.Beneficiario;
            txtBeneficiarioRut.Text = obra.BeneficiarioRut;
            txtBeneficiarioTelefono.Text = obra.BeneficiarioTelefono;
            txtMaestro.Text = obra.Maestro;
            numPresupuesto.Value = obra.PresupuestoMateriales;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cmbEstado.SelectedValue = obra.Estado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var datos = new Obra
            {
                IdObra = obra.IdObra,
                NombreObra = txtNombre.Text,
                SuperficieM2 = numSuperficie.Value == 0 ? (decimal?)null : numSuperficie.Value,
                Direccion = txtDireccion.Text,
                Beneficiario = txtBeneficiario.Text,
                BeneficiarioRut = txtBeneficiarioRut.Text,
                BeneficiarioTelefono = txtBeneficiarioTelefono.Text,
                Maestro = txtMaestro.Text,
                PresupuestoMateriales = numPresupuesto.Value,
                Estado = (EstadoObra)cmbEstado.SelectedValue
            };
            try
            {
                ObraService.Guardar(datos);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo guardar la obra.", ex);
            }
        }
    }
}
