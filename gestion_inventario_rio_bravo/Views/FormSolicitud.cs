using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>
    /// Formulario estandarizado "Salida de materiales" (§8.2): reemplaza las planillas Excel.
    /// Crear/editar (Pendiente), aprobar o rechazar, despachar por partes e imprimir.
    /// Los botones se muestran según el rol y el estado de la solicitud.
    /// </summary>
    public partial class FormSolicitud : Form
    {
        private Solicitud solicitud;
        private List<Despacho> despachos = new List<Despacho>();
        private List<Obra> obras = new List<Obra>();
        private bool cambios;     // hay cambios sin guardar
        private bool cargando;    // evita marcar cambios mientras se llenan los controles
        private Font fuenteCategoria;

        public FormSolicitud(int? idSolicitud = null, int? idObra = null)
        {
            InitializeComponent();
            solicitud = idSolicitud.HasValue
                ? new Solicitud { IdSolicitud = idSolicitud.Value }
                : new Solicitud { IdObra = idObra ?? 0, UsuarioNombre = Sesion.Actual.Nombre };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                cmbCategoria.DataSource = CatalogoService.Categorias();
                cmbMaterial.DataSource = CatalogoService.Buscar("");
                cmbMaterial.SelectedIndex = -1;
                obras = ObraService.Listar();
                Recargar(solicitud.EsNueva ? (int?)null : solicitud.IdSolicitud);
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo abrir la solicitud.", ex);
                Close();
            }
        }

        /// <summary>Lee la solicitud desde la BD (id null = nueva) y repinta todo.</summary>
        private void Recargar(int? id)
        {
            if (id.HasValue)
            {
                solicitud = SolicitudService.Obtener(id.Value);
                despachos = SolicitudService.Despachos(id.Value);
            }
            cargando = true;
            // Para solicitudes editables solo se ofrecen obras no finalizadas (más la propia, si lo estuviera).
            cmbObra.DataSource = obras.Where(o => !solicitud.Editable || o.Estado != EstadoObra.Finalizada || o.IdObra == solicitud.IdObra).ToList();
            if (solicitud.IdObra != 0) cmbObra.SelectedValue = solicitud.IdObra;
            else cmbObra.SelectedIndex = -1;
            chkTrompo.Checked = solicitud.EquipoTrompo;
            chkPlaca.Checked = solicitud.EquipoPlaca;
            chkBano.Checked = solicitud.EquipoBano;
            txtObservaciones.Text = solicitud.Observaciones;
            cargando = false;
            cambios = false;

            MostrarEncabezado();
            MostrarLineas();
            MostrarDespachos();
            ActualizarBotones();
        }

        private void MostrarEncabezado()
        {
            var obra = cmbObra.SelectedItem as Obra;
            Text = "Salida de materiales " + solicitud.Folio + (obra != null ? " · " + obra.NombreObra : "");
            lblFolio.Text = "Folio: " + solicitud.Folio;
            lblEstado.Text = "Estado: " + solicitud.EstadoTexto;
            lblEstado.ForeColor = solicitud.Estado == EstadoSolicitud.Rechazada ? Color.Firebrick
                                : solicitud.Estado == EstadoSolicitud.Pendiente ? Color.DarkOrange : Color.DarkGreen;
            lblDatosObra.Text = obra == null ? "Seleccione la obra."
                : $"Superficie: {(obra.SuperficieM2.HasValue ? obra.SuperficieM2.Value.ToString("#,0.##") + " m²" : "—")}    "
                + $"Beneficiario: {obra.Beneficiario ?? "—"}    Ubicación: {obra.Direccion ?? "—"}    Maestro: {obra.Maestro ?? "—"}    "
                + $"Obra: {obra.EstadoTexto}";
            var registro = $"Fecha: {solicitud.FechaSolicitud:dd-MM-yyyy}    Registrada por: {solicitud.UsuarioNombre}";
            if (solicitud.AprobadorNombre != null)
                registro += $"    {(solicitud.Estado == EstadoSolicitud.Rechazada ? "Rechazada" : "Aprobada")} por: {solicitud.AprobadorNombre} ({solicitud.FechaAprobacion:dd-MM-yyyy})";
            lblRegistro.Text = registro;
            lblRechazo.Text = solicitud.Estado == EstadoSolicitud.Rechazada ? "Motivo del rechazo: " + solicitud.MotivoRechazo : "";
        }

        /// <summary>Líneas agrupadas por categoría en el orden fijo del formulario (§8.3).</summary>
        private void MostrarLineas()
        {
            dgvLineas.Rows.Clear();
            string categoria = null;
            foreach (var l in solicitud.Lineas.OrderBy(x => x.CategoriaOrden).ThenBy(x => x.Material))
            {
                if (l.Categoria != categoria)
                {
                    categoria = l.Categoria;
                    int h = dgvLineas.Rows.Add("", categoria.ToUpperInvariant());
                    var fila = dgvLineas.Rows[h];
                    fila.DefaultCellStyle.BackColor = Color.Gainsboro;
                    fila.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
                    fila.DefaultCellStyle.SelectionForeColor = Color.Black;
                    fila.DefaultCellStyle.Font = fuenteCategoria ?? (fuenteCategoria = new Font(dgvLineas.Font, FontStyle.Bold));
                }
                int i = dgvLineas.Rows.Add(l.Codigo, l.Material, l.Unidad, l.CantidadSolicitada, l.CantidadDespachada, l.Saldo, l.StockActual);
                dgvLineas.Rows[i].Tag = l;
                if (solicitud.Despachable && l.Saldo > 0 && l.StockActual < l.Saldo)
                    dgvLineas.Rows[i].Cells[colStock.Index].Style.ForeColor = Color.Firebrick; // no alcanza el stock
            }
            lblResumen.Text = $"{solicitud.Lineas.Count} materiales    Solicitado: {solicitud.Lineas.Sum(l => l.CantidadSolicitada):#,0.##}"
                            + $"    Entregado: {solicitud.Lineas.Sum(l => l.CantidadDespachada):#,0.##}    Saldo: {solicitud.Lineas.Sum(l => l.Saldo):#,0.##}";
        }

        private void MostrarDespachos()
        {
            lstDespachos.Items.Clear();
            for (int i = 0; i < despachos.Count; i++)
            {
                var d = despachos[i];
                lstDespachos.Items.Add($"Entrega {i + 1}: {d.Folio}  {d.FechaHora:dd-MM-yy HH:mm}  ({d.UsuarioNombre})");
            }
            if (despachos.Count == 0) lstDespachos.Items.Add("(sin entregas)");
        }

        private void ActualizarBotones()
        {
            bool editable = solicitud.Editable && Permisos.RegistrarSolicitud;
            cmbObra.Enabled = chkTrompo.Enabled = chkPlaca.Enabled = chkBano.Enabled = editable;
            txtObservaciones.ReadOnly = !editable;
            pnlAgregar.Visible = btnGuardar.Visible = editable;
            btnAprobar.Visible = btnRechazar.Visible = solicitud.Editable && !solicitud.EsNueva && Permisos.AprobarSolicitud;
            btnDespachar.Visible = solicitud.Despachable && Permisos.Despachar;
            btnImprimir.Enabled = !solicitud.EsNueva;
            btnComprobante.Enabled = despachos.Count > 0;
        }

        // --- Edición ---

        private void Encabezado_Changed(object sender, EventArgs e)
        {
            if (cargando) return;
            cambios = true;
            MostrarEncabezado();
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbMaterial.SelectedItem is Material m)) { lblUnidad.Text = ""; return; }
            lblUnidad.Text = m.UnidadMedida + $"  (stock {m.StockActual:#,0.##})";
            if (m.IdCategoria.HasValue) cmbCategoria.SelectedValue = m.IdCategoria.Value;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                SolicitudService.AgregarLinea(solicitud, cmbMaterial.SelectedItem as Material, cmbCategoria.SelectedItem as Categoria, numCantidad.Value);
                cambios = true;
                MostrarLineas();
                cmbMaterial.SelectedIndex = -1;
                cmbMaterial.Text = "";
                numCantidad.Value = 0;
                cmbMaterial.Focus();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo agregar el material.", ex);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (!(dgvLineas.CurrentRow?.Tag is DetalleSolicitud l)) return;
            solicitud.Lineas.Remove(l);
            cambios = true;
            MostrarLineas();
        }

        private void dgvLineas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && pnlAgregar.Visible) btnQuitar_Click(sender, e);
        }

        /// <summary>Doble clic en una línea: la carga arriba para cambiar su cantidad.</summary>
        private void dgvLineas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!pnlAgregar.Visible || e.RowIndex < 0 || !(dgvLineas.Rows[e.RowIndex].Tag is DetalleSolicitud l)) return;
            var m = ((List<Material>)cmbMaterial.DataSource).FirstOrDefault(x => x.IdMaterial == l.IdMaterial);
            if (m == null) return;
            cmbMaterial.SelectedItem = m;
            cmbCategoria.SelectedValue = l.IdCategoria;
            numCantidad.Value = l.CantidadSolicitada;
            numCantidad.Focus();
            numCantidad.Select(0, numCantidad.Text.Length);
        }

        private bool Guardar()
        {
            solicitud.IdObra = (cmbObra.SelectedItem as Obra)?.IdObra ?? 0;
            solicitud.EquipoTrompo = chkTrompo.Checked;
            solicitud.EquipoPlaca = chkPlaca.Checked;
            solicitud.EquipoBano = chkBano.Checked;
            solicitud.Observaciones = txtObservaciones.Text;
            try
            {
                SolicitudService.Guardar(solicitud);
                Recargar(solicitud.IdSolicitud);
                return true;
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo guardar la solicitud.", ex);
                return false;
            }
        }

        /// <summary>Las acciones sobre la solicitud exigen que esté guardada.</summary>
        private bool GuardadaAntesDe(string accion)
        {
            if (!cambios && !solicitud.EsNueva) return true;
            if (!Mensajes.Confirmar($"Hay cambios sin guardar. ¿Guardar la solicitud antes de {accion}?")) return false;
            return Guardar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Guardar()) Mensajes.Info($"Solicitud {solicitud.Folio} guardada.");
        }

        // --- Flujo ---

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (!GuardadaAntesDe("aprobarla")) return;
            if (!Mensajes.Confirmar($"¿Aprobar la solicitud {solicitud.Folio}? Ya no se podrán modificar sus materiales.")) return;
            Ejecutar(() => SolicitudService.Aprobar(solicitud), "No se pudo aprobar la solicitud.");
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (!GuardadaAntesDe("rechazarla")) return;
            var motivo = FormTexto.Pedir(this, "Rechazar " + solicitud.Folio, "Motivo del rechazo (obligatorio):", 200);
            if (motivo == null) return;
            Ejecutar(() => SolicitudService.Rechazar(solicitud, motivo), "No se pudo rechazar la solicitud.");
        }

        private void btnDespachar_Click(object sender, EventArgs e)
        {
            int idDespacho;
            using (var f = new FormDespacho(solicitud))
            {
                if (f.ShowDialog(this) != DialogResult.OK) return;
                idDespacho = f.IdDespacho;
            }
            try
            {
                Recargar(solicitud.IdSolicitud);
                var d = despachos.FirstOrDefault(x => x.IdDespacho == idDespacho);
                if (d != null && Mensajes.Confirmar($"Despacho {d.Folio} registrado. ¿Imprimir el comprobante?"))
                    using (var doc = new ImpresionDespacho(solicitud, d, despachos)) doc.Mostrar(this);
            }
            catch (Exception ex)
            {
                Mensajes.Error("El despacho se registró, pero no se pudo actualizar la vista.", ex);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!GuardadaAntesDe("imprimirla")) return;
            using (var doc = new ImpresionSolicitud(solicitud, despachos)) doc.Mostrar(this);
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            int i = lstDespachos.SelectedIndex;
            if (i < 0 || i >= despachos.Count) i = despachos.Count - 1;
            if (i < 0) return;
            using (var doc = new ImpresionDespacho(solicitud, despachos[i], despachos)) doc.Mostrar(this);
        }

        private void Ejecutar(Action accion, string error)
        {
            try
            {
                accion();
                Recargar(solicitud.IdSolicitud);
            }
            catch (Exception ex)
            {
                Mensajes.Error(error, ex);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (cambios && pnlAgregar.Visible && !Mensajes.Confirmar("Hay cambios sin guardar. ¿Cerrar de todas formas?"))
                e.Cancel = true;
            base.OnFormClosing(e);
        }
    }
}
