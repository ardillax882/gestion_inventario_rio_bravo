using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>
    /// Ventana principal = pantalla de Inicio: resumen de stock, obras y solicitudes abiertas, con accesos directos.
    /// El menú se arma según los permisos del usuario en sesión (RF-03).
    /// </summary>
    public partial class FormPrincipal : Ventana
    {
        /// <summary>True si el usuario eligió "Cerrar sesión" (volver al login) en vez de salir.</summary>
        public bool CerroSesion { get; private set; }

        public FormPrincipal()
        {
            InitializeComponent();
            var u = Sesion.Actual;
            lblSesion.Text = $"Usuario: {u.Nombre}  ·  Rol: {u.RolTexto}";
            lblBienvenida.Text = $"Bienvenido(a), {u.Nombre}";

            dgvStockBajo.AutoGenerateColumns = dgvObras.AutoGenerateColumns = dgvSolicitudes.AutoGenerateColumns = false;
            mnuAdministracion.Visible = Permisos.GestionarUsuarios;
            mnuAjuste.Visible = Permisos.AjustarInventario;
            mnuNuevaSolicitud.Visible = btnTarjetaNueva.Visible = Permisos.RegistrarSolicitud;
            MostrarLetra();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Actualizar();
        }

        /// <summary>Recarga el resumen. Se llama al abrir y al cerrar cualquier ventana que pueda cambiar datos.</summary>
        private void Actualizar()
        {
            try
            {
                var materiales = CatalogoService.Buscar("");
                var obras = ObraService.ListarActivas();
                var abiertas = SolicitudService.Listar(null, EstadoSolicitud.Pendiente, EstadoSolicitud.Aprobada, EstadoSolicitud.Despachada_parcial);

                dgvStockBajo.DataSource = materiales;
                dgvObras.DataSource = obras;
                dgvSolicitudes.DataSource = abiertas;

                int bajo = materiales.Count(m => m.BajoMinimo);
                Tarjeta(btnTarjetaStock, bajo, "Materiales bajo stock mínimo", bajo > 0);
                Tarjeta(btnTarjetaObras, obras.Count(o => o.Estado == EstadoObra.En_ejecucion), "Obras en ejecución", false);
                int pendientes = abiertas.Count(s => s.Estado == EstadoSolicitud.Pendiente);
                Tarjeta(btnTarjetaPendientes, pendientes, "Solicitudes por aprobar", pendientes > 0 && Permisos.AprobarSolicitud);
                Tarjeta(btnTarjetaDespachar, abiertas.Count(s => s.Despachable), "Solicitudes por despachar", false);
                lblActualizado.Text = "Actualizado " + DateTime.Now.ToString("HH:mm");
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo cargar el resumen de inicio.", ex);
            }
        }

        private static void Tarjeta(Button b, int valor, string texto, bool alerta)
        {
            b.Text = valor + "\n" + texto;
            b.BackColor = alerta ? Color.MistyRose : Color.White;
        }

        /// <summary>Abre una ventana modal y al cerrarla actualiza el inicio.</summary>
        private void Abrir(Form f)
        {
            using (f) f.ShowDialog(this);
            Actualizar();
        }

        // --- Menú y tarjetas ---

        private void mnuMateriales_Click(object sender, EventArgs e) => Abrir(new FormMateriales());
        private void btnTarjetaStock_Click(object sender, EventArgs e) => Abrir(new FormMateriales(soloBajoMinimo: true));
        private void mnuAjuste_Click(object sender, EventArgs e) => Abrir(new FormAjuste());
        private void mnuObras_Click(object sender, EventArgs e) => Abrir(new FormObras());
        private void mnuEquipos_Click(object sender, EventArgs e) => Abrir(new FormEquipos());
        private void mnuSolicitudes_Click(object sender, EventArgs e) => Abrir(new FormSolicitudes());
        private void btnTarjetaPendientes_Click(object sender, EventArgs e) => Abrir(new FormSolicitudes(estado: EstadoSolicitud.Pendiente));
        private void btnTarjetaDespachar_Click(object sender, EventArgs e) => Abrir(new FormSolicitudes(porDespachar: true));
        private void mnuNuevaSolicitud_Click(object sender, EventArgs e) => Abrir(new FormSolicitud());
        private void mnuUsuarios_Click(object sender, EventArgs e) => Abrir(new FormUsuarios());
        private void btnActualizar_Click(object sender, EventArgs e) => Actualizar();

        private void dgvStockBajo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStockBajo.Rows[e.RowIndex].DataBoundItem is Material m)
                Abrir(new FormKardex(m));
        }

        /// <summary>Bajo mínimo en rojo (RF-07), igual que en Materiales.</summary>
        private void dgvStockBajo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!(dgvStockBajo.Rows[e.RowIndex].DataBoundItem is Material m)) return;
            var estilo = dgvStockBajo.Rows[e.RowIndex].DefaultCellStyle;
            estilo.ForeColor = m.BajoMinimo ? Color.Firebrick : SystemColors.ControlText;
            estilo.BackColor = m.BajoMinimo ? Color.MistyRose : SystemColors.Window;
        }

        private void dgvObras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvObras.Rows[e.RowIndex].DataBoundItem is Obra o)
                Abrir(new FormSolicitudes(idObra: o.IdObra));
        }

        private void dgvSolicitudes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSolicitudes.Rows[e.RowIndex].DataBoundItem is Solicitud s)
                Abrir(new FormSolicitud(s.IdSolicitud));
        }

        private void mnuCambiarPassword_Click(object sender, EventArgs e)
        {
            using (var f = new FormPassword(Sesion.Actual))
                f.ShowDialog(this);
        }

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            CerroSesion = true;
            Close();
        }

        private void mnuSalir_Click(object sender, EventArgs e) => Close();

        // --- Tamaño de letra ---

        private void mnuLetraMas_Click(object sender, EventArgs e) => CambiarLetra(+1);
        private void mnuLetraMenos_Click(object sender, EventArgs e) => CambiarLetra(-1);

        private void CambiarLetra(int pasos)
        {
            Letra.Cambiar(pasos);
            MostrarLetra();
        }

        private void MostrarLetra()
        {
            lblLetraPorcentaje.Text = Letra.Porcentaje + " %";
            mnuLetraMenos.Enabled = Letra.Porcentaje > Letra.Niveles.First();
            mnuLetraMas.Enabled = Letra.Porcentaje < Letra.Niveles.Last();
        }

        /// <summary>Ctrl + y Ctrl − (también los del teclado numérico) cambian la letra, como en el navegador.</summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Oemplus) || keyData == (Keys.Control | Keys.Add)) { CambiarLetra(+1); return true; }
            if (keyData == (Keys.Control | Keys.OemMinus) || keyData == (Keys.Control | Keys.Subtract)) { CambiarLetra(-1); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
