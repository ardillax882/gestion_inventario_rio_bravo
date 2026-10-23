using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>
    /// Registra una entrega (una columna "Fecha" de la planilla, RF-17/RF-18): por cada línea con saldo
    /// se indica cuánto se entrega hoy (≤ saldo y ≤ stock). Al confirmar se descuenta el stock.
    /// </summary>
    public partial class FormDespacho : Ventana
    {
        private readonly Solicitud solicitud;

        /// <summary>Id del despacho registrado (válido si DialogResult = OK).</summary>
        public int IdDespacho { get; private set; }

        public FormDespacho(Solicitud s)
        {
            InitializeComponent();
            solicitud = s;
            Text = "Nuevo despacho · " + s.Folio;
            lblInfo.Text = $"{s.Folio} · {s.ObraNombre}    Ingrese la cantidad que se entrega hoy en cada material (deje vacío lo que no se entrega).";
            txtRecibidoPor.Text = s.ObraMaestro;

            foreach (var l in s.Lineas.Where(x => x.Saldo > 0).OrderBy(x => x.CategoriaOrden).ThenBy(x => x.Material))
            {
                int i = dgvLineas.Rows.Add(l.Codigo, l.Material, l.Categoria, l.Unidad, l.Saldo, l.StockActual, null);
                dgvLineas.Rows[i].Tag = l;
                if (l.StockActual <= 0)
                {
                    dgvLineas.Rows[i].Cells[colEntregar.Index].ReadOnly = true;
                    dgvLineas.Rows[i].DefaultCellStyle.ForeColor = SystemColors.GrayText;
                }
                else if (l.StockActual < l.Saldo)
                    dgvLineas.Rows[i].Cells[colStock.Index].Style.ForeColor = Color.Firebrick;
            }
        }

        /// <summary>Propone entregar todo el saldo que alcance con el stock disponible.</summary>
        private void btnTodo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvLineas.Rows)
                if (r.Tag is DetalleSolicitud l && l.StockActual > 0)
                    r.Cells[colEntregar.Index].Value = Math.Min(l.Saldo, l.StockActual);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvLineas.Rows)
                r.Cells[colEntregar.Index].Value = null;
        }

        private void dgvLineas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != colEntregar.Index) return;
            var texto = Convert.ToString(e.FormattedValue).Trim();
            if (texto.Length == 0) return;
            if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out var c) || c < 0)
            {
                Mensajes.Advertencia("Ingrese un número mayor o igual a cero.");
                e.Cancel = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!dgvLineas.EndEdit()) return;
            var cantidades = new Dictionary<int, decimal>();
            foreach (DataGridViewRow r in dgvLineas.Rows)
            {
                var v = r.Cells[colEntregar.Index].Value;
                if (r.Tag is DetalleSolicitud l && v != null && decimal.TryParse(Convert.ToString(v), NumberStyles.Number, CultureInfo.CurrentCulture, out var c) && c > 0)
                    cantidades[l.IdDetalleSolicitud] = c;
            }
            if (cantidades.Count > 0 && !Mensajes.Confirmar($"¿Registrar la entrega de {cantidades.Count} materiales a {solicitud.ObraNombre}? Se descontará el stock y no se puede deshacer (se corrige con un ajuste)."))
                return;
            try
            {
                IdDespacho = SolicitudService.Despachar(solicitud, cantidades, txtRecibidoPor.Text, txtObservaciones.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo registrar el despacho.", ex);
            }
        }
    }
}
