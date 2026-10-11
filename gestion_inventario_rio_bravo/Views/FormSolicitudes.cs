using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Listado de solicitudes (planillas) con filtros por obra y estado.</summary>
    public partial class FormSolicitudes : Form
    {
        private const string PorDespachar = "Por despachar (Aprobada o Despachada parcial)";
        private readonly int? idObraInicial;
        private readonly string estadoInicial;
        private bool cargando = true;

        public FormSolicitudes(int? idObra = null, EstadoSolicitud? estado = null, bool porDespachar = false)
        {
            InitializeComponent();
            dgvSolicitudes.AutoGenerateColumns = false;
            idObraInicial = idObra;
            btnNueva.Visible = Permisos.RegistrarSolicitud;

            var estados = new List<string> { "Todos", PorDespachar };
            estados.AddRange(Enum.GetValues(typeof(EstadoSolicitud)).Cast<EstadoSolicitud>().Select(Solicitud.TextoEstado));
            cmbEstado.DataSource = estados;
            estadoInicial = porDespachar ? PorDespachar : estado.HasValue ? Solicitud.TextoEstado(estado.Value) : "Todos";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cmbEstado.SelectedItem = estadoInicial; // requiere el enlace de datos ya creado
            try
            {
                var obras = new List<Obra> { new Obra { NombreObra = "Todas las obras" } };
                obras.AddRange(ObraService.Listar());
                cmbObra.DataSource = obras;
                if (idObraInicial.HasValue) cmbObra.SelectedValue = idObraInicial.Value;
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudieron cargar las obras.", ex);
            }
            cargando = false;
            Cargar();
        }

        private void Cargar()
        {
            if (cargando) return;
            try
            {
                var idObra = (cmbObra.SelectedItem as Obra)?.IdObra;
                var texto = cmbEstado.SelectedItem as string;
                EstadoSolicitud[] estados =
                    texto == PorDespachar ? new[] { EstadoSolicitud.Aprobada, EstadoSolicitud.Despachada_parcial }
                  : texto == "Todos" || texto == null ? new EstadoSolicitud[0]
                  : new[] { Enum.GetValues(typeof(EstadoSolicitud)).Cast<EstadoSolicitud>().First(e => Solicitud.TextoEstado(e) == texto) };
                var lista = SolicitudService.Listar(idObra == 0 ? null : idObra, estados);
                dgvSolicitudes.DataSource = lista;
                lblTotal.Text = lista.Count + " solicitudes";
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo cargar la lista de solicitudes.", ex);
            }
        }

        private void Filtro_Changed(object sender, EventArgs e) => Cargar();

        private Solicitud Seleccionada => dgvSolicitudes.CurrentRow?.DataBoundItem as Solicitud;

        private void btnNueva_Click(object sender, EventArgs e)
        {
            var idObra = (cmbObra.SelectedItem as Obra)?.IdObra;
            using (var f = new FormSolicitud(idObra: idObra == 0 ? null : idObra))
                f.ShowDialog(this);
            Cargar();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (Seleccionada == null) return;
            using (var f = new FormSolicitud(Seleccionada.IdSolicitud))
                f.ShowDialog(this);
            Cargar();
        }

        private void dgvSolicitudes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnAbrir_Click(sender, e);
        }
    }
}
