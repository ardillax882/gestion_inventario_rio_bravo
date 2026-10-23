using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>
    /// Base de los documentos impresos (§8.2): tamaño carta, encabezado Río Bravo, tabla agrupada por categoría
    /// con salto de página, y firmas al final. Unidades: centésimas de pulgada.
    /// </summary>
    public abstract class ImpresionBase : PrintDocument
    {
        protected class Columna
        {
            public string Titulo;
            public float Ancho;           // 0 = ocupa el espacio que sobra
            public bool Numero;
            public Columna(string titulo, float ancho, bool numero = false) { Titulo = titulo; Ancho = ancho; Numero = numero; }
        }

        /// <summary>Fila de la tabla: categoría (encabezado de sección) o valores.</summary>
        protected class Fila
        {
            public string Categoria;
            public string[] Valores;
        }

        protected readonly Font Titulo = new Font("Segoe UI", 13, FontStyle.Bold);
        protected readonly Font Normal = new Font("Segoe UI", 8.5f);
        protected readonly Font Negrita = new Font("Segoe UI", 8.5f, FontStyle.Bold);
        protected readonly Font Chica = new Font("Segoe UI", 7.5f);
        protected const float AltoFila = 17;
        private const float AltoFirmas = 80;

        private int _fila, _pagina;

        protected ImpresionBase(string nombre, bool horizontal)
        {
            DocumentName = nombre;
            DefaultPageSettings.Landscape = horizontal;
            DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            foreach (PaperSize p in PrinterSettings.PaperSizes)
                if (p.Kind == PaperKind.Letter) { DefaultPageSettings.PaperSize = p; break; }
        }

        protected abstract string Folio { get; }
        protected abstract string Subtitulo { get; }
        protected abstract Columna[] Columnas { get; }
        protected abstract List<Fila> Filas { get; }
        protected abstract string[] Firmas { get; }

        /// <summary>Datos del encabezado bajo el título; devuelve la Y donde sigue la tabla.</summary>
        protected abstract float DibujarDatos(Graphics g, RectangleF area, float y);

        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);
            _fila = 0;
            _pagina = 0;
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);
            var g = e.Graphics;
            var area = (RectangleF)e.MarginBounds;
            _pagina++;

            // Encabezado (en todas las páginas).
            g.DrawString("RÍO BRAVO · " + Subtitulo, Titulo, Brushes.Black, area.Left, area.Top);
            Texto(g, Folio, Titulo, new RectangleF(area.Left, area.Top, area.Width, 24), StringAlignment.Far);
            Texto(g, "Página " + _pagina + " · Impreso " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), Chica,
                  new RectangleF(area.Left, area.Top + 24, area.Width, 14), StringAlignment.Far);
            float y = DibujarDatos(g, area, area.Top + 28) + 6;

            // Tabla.
            var anchos = CalcularAnchos(area.Width);
            y = DibujarCabeceraTabla(g, area.Left, y, anchos);
            var filas = Filas;
            while (_fila < filas.Count)
            {
                if (y + AltoFila > area.Bottom) { e.HasMorePages = true; return; }
                DibujarFila(g, area.Left, y, anchos, filas[_fila]);
                y += AltoFila;
                _fila++;
            }

            // Firmas al final; si no caben, van en una página nueva.
            if (y + AltoFirmas > area.Bottom && filas.Count > 0) { e.HasMorePages = true; _fila = filas.Count; return; }
            DibujarFirmas(g, area, area.Bottom - AltoFirmas + 30);
            e.HasMorePages = false;
        }

        /// <summary>Vuelve a imprimir la tabla desde la primera fila (siguiente grupo de entregas).</summary>
        protected void ReiniciarFilas() => _fila = 0;

        private float[] CalcularAnchos(float total)
        {
            var cols = Columnas;
            float fijo = cols.Sum(c => c.Ancho);
            int flexibles = Math.Max(1, cols.Count(c => c.Ancho == 0));
            return cols.Select(c => c.Ancho > 0 ? c.Ancho : (total - fijo) / flexibles).ToArray();
        }

        private float DibujarCabeceraTabla(Graphics g, float x, float y, float[] anchos)
        {
            const float alto = 30;
            var cols = Columnas;
            for (int i = 0; i < cols.Length; i++)
            {
                var r = new RectangleF(x, y, anchos[i], alto);
                g.FillRectangle(Brushes.Gainsboro, r);
                g.DrawRectangle(Pens.Black, r.X, r.Y, r.Width, r.Height);
                Texto(g, cols[i].Titulo, Negrita, Rect(r, 2), cols[i].Numero ? StringAlignment.Far : StringAlignment.Near, centrado: true);
                x += anchos[i];
            }
            return y + alto;
        }

        private void DibujarFila(Graphics g, float x, float y, float[] anchos, Fila f)
        {
            float ancho = anchos.Sum();
            if (f.Categoria != null)
            {
                var r = new RectangleF(x, y, ancho, AltoFila);
                g.FillRectangle(Brushes.WhiteSmoke, r);
                g.DrawRectangle(Pens.Black, r.X, r.Y, r.Width, r.Height);
                Texto(g, f.Categoria.ToUpperInvariant(), Negrita, Rect(r, 3), StringAlignment.Near, centrado: true);
                return;
            }
            var cols = Columnas;
            for (int i = 0; i < cols.Length; i++)
            {
                var r = new RectangleF(x, y, anchos[i], AltoFila);
                g.DrawRectangle(Pens.Gray, r.X, r.Y, r.Width, r.Height);
                Texto(g, f.Valores[i], Normal, Rect(r, 3), cols[i].Numero ? StringAlignment.Far : StringAlignment.Near, centrado: true);
                x += anchos[i];
            }
        }

        private void DibujarFirmas(Graphics g, RectangleF area, float y)
        {
            var firmas = Firmas;
            float ancho = area.Width / firmas.Length;
            for (int i = 0; i < firmas.Length; i++)
            {
                float x = area.Left + i * ancho + 20;
                g.DrawLine(Pens.Black, x, y, x + ancho - 40, y);
                Texto(g, firmas[i], Normal, new RectangleF(x, y + 3, ancho - 40, 30), StringAlignment.Center);
            }
        }

        /// <summary>Línea "Etiqueta: valor" en negrita/normal. Devuelve la X donde termina.</summary>
        protected float Dato(Graphics g, string etiqueta, string valor, float x, float y)
        {
            g.DrawString(etiqueta + ":", Negrita, Brushes.Black, x, y);
            x += g.MeasureString(etiqueta + ":", Negrita).Width;
            var v = string.IsNullOrEmpty(valor) ? "________________" : valor;
            g.DrawString(v, Normal, Brushes.Black, x, y);
            return x + g.MeasureString(v, Normal).Width + 14;
        }

        protected static void Texto(Graphics g, string texto, Font f, RectangleF r, StringAlignment alineacion, bool centrado = false)
        {
            using (var sf = new StringFormat { Alignment = alineacion, LineAlignment = centrado ? StringAlignment.Center : StringAlignment.Near, Trimming = StringTrimming.EllipsisCharacter })
                g.DrawString(texto ?? "", f, Brushes.Black, r, sf);
        }

        private static RectangleF Rect(RectangleF r, float margen) => new RectangleF(r.X + margen, r.Y, r.Width - 2 * margen, r.Height);

        protected static string Num(decimal d) => d.ToString("#,0.##");

        /// <summary>Filas agrupadas por categoría en el orden del formulario (§8.3).</summary>
        protected static List<Fila> Agrupar(IEnumerable<DetalleSolicitud> lineas, Func<DetalleSolicitud, string[]> valores)
        {
            var filas = new List<Fila>();
            string actual = null;
            foreach (var l in lineas.OrderBy(l => l.CategoriaOrden).ThenBy(l => l.Material))
            {
                if (l.Categoria != actual) filas.Add(new Fila { Categoria = actual = l.Categoria });
                filas.Add(new Fila { Valores = valores(l) });
            }
            return filas;
        }

        /// <summary>Muestra la vista previa; desde ahí se imprime o se elige la impresora.</summary>
        public void Mostrar(IWin32Window owner)
        {
            using (var vista = new PrintPreviewDialog { Document = this, WindowState = FormWindowState.Maximized, UseAntiAlias = true })
            {
                vista.PrintPreviewControl.Zoom = 1.0;
                vista.ShowDialog(owner);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) { Titulo.Dispose(); Normal.Dispose(); Negrita.Dispose(); Chica.Dispose(); }
            base.Dispose(disposing);
        }

        protected void DibujarEncabezadoObra(Graphics g, Solicitud s, float x, float y)
        {
            var obra = s.ObraNombre + (s.ObraSuperficie.HasValue ? $" ({Num(s.ObraSuperficie.Value)} m²)" : "");
            Dato(g, "Obra", obra, x, y);
        }
    }

    /// <summary>Impresión 1 — el formulario estandarizado de la solicitud con todas las entregas (reemplaza la planilla Excel).</summary>
    public class ImpresionSolicitud : ImpresionBase
    {
        private const int EntregasPorHoja = 4;
        private readonly Solicitud _s;
        private readonly List<Despacho> _despachos;
        private int _bloque;            // grupo de 4 entregas que se está imprimiendo
        private List<Fila> _filas;

        public ImpresionSolicitud(Solicitud s, List<Despacho> despachos) : base(s.Folio, horizontal: true)
        {
            _s = s;
            _despachos = despachos;
        }

        private int Bloques => Math.Max(1, (_despachos.Count + EntregasPorHoja - 1) / EntregasPorHoja);
        private IEnumerable<Despacho> DespachosDelBloque => _despachos.Skip(_bloque * EntregasPorHoja).Take(EntregasPorHoja);

        protected override string Folio => _s.Folio;
        protected override string Subtitulo => "SALIDA DE MATERIALES";
        protected override string[] Firmas => new[] { "Entregado por (Bodeguero)", "Recibido por (Maestro jefe de cuadrilla)", "Autorizado por (Encargado de bodega)" };

        protected override Columna[] Columnas
        {
            get
            {
                var cols = new List<Columna> { new Columna("Código", 68), new Columna("Material", 0), new Columna("Unid.", 48), new Columna("Cant. solicitada", 66, true) };
                var bloque = DespachosDelBloque.ToList();
                for (int i = 0; i < EntregasPorHoja; i++)
                {
                    int n = _bloque * EntregasPorHoja + i + 1;
                    cols.Add(new Columna(i < bloque.Count ? $"Entrega {n}\n{bloque[i].FechaHora:dd-MM-yy}" : $"Entrega {n}\n__-__-__", 72, true));
                }
                cols.Add(new Columna("Total entregado", 70, true));
                cols.Add(new Columna("Saldo", 62, true));
                return cols.ToArray();
            }
        }

        protected override List<Fila> Filas => _filas ?? (_filas = Agrupar(_s.Lineas, l =>
        {
            var v = new List<string> { l.Codigo, l.Material, l.Unidad, Num(l.CantidadSolicitada) };
            foreach (var d in DespachosDelBloque)
                v.Add(d.Cantidades.TryGetValue(l.IdDetalleSolicitud, out var c) ? Num(c) : "");
            while (v.Count < 4 + EntregasPorHoja) v.Add("");
            v.Add(Num(l.CantidadDespachada));
            v.Add(Num(l.Saldo));
            return v.ToArray();
        }));

        protected override float DibujarDatos(Graphics g, RectangleF area, float y)
        {
            float x = area.Left;
            DibujarEncabezadoObra(g, _s, x, y);
            Dato(g, "Estado", _s.EstadoTexto, area.Left + area.Width * 0.62f, y);
            y += 16;
            x = Dato(g, "Beneficiario", _s.ObraBeneficiario, area.Left, y);
            x = Dato(g, "Ubicación", _s.ObraDireccion, x, y);
            Dato(g, "Maestro", _s.ObraMaestro, x, y);
            y += 16;
            x = Dato(g, "Equipos", $"[{(_s.EquipoTrompo ? "X" : " ")}] Trompo   [{(_s.EquipoPlaca ? "X" : " ")}] Placa   [{(_s.EquipoBano ? "X" : " ")}] Baño", area.Left, y);
            x = Dato(g, "Fecha solicitud", _s.FechaSolicitud.ToString("dd-MM-yyyy"), x, y);
            x = Dato(g, "Registrada por", _s.UsuarioNombre, x, y);
            if (_s.AprobadorNombre != null)
                Dato(g, _s.Estado == EstadoSolicitud.Rechazada ? "Rechazada por" : "Aprobada por", _s.AprobadorNombre, x, y);
            y += 16;
            if (Bloques > 1)
            {
                g.DrawString($"Entregas {_bloque * EntregasPorHoja + 1} a {(_bloque + 1) * EntregasPorHoja} (de {_despachos.Count})", Negrita, Brushes.Black, area.Left, y);
                y += 16;
            }
            if (!string.IsNullOrEmpty(_s.Observaciones))
            {
                Dato(g, "Observaciones", _s.Observaciones, area.Left, y);
                y += 16;
            }
            return y;
        }

        protected override void OnBeginPrint(PrintEventArgs e)
        {
            _bloque = 0;
            _filas = null;
            base.OnBeginPrint(e);
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);
            // Terminado un grupo de 4 entregas, se repite la planilla con las siguientes (§8.2).
            if (!e.HasMorePages && _bloque + 1 < Bloques)
            {
                _bloque++;
                _filas = null;
                ReiniciarFilas();
                e.HasMorePages = true;
            }
        }
    }

    /// <summary>Impresión 2 — comprobante de una entrega.</summary>
    public class ImpresionDespacho : ImpresionBase
    {
        private readonly Solicitud _s;
        private readonly Despacho _d;
        private readonly Dictionary<int, decimal> _saldoDespues = new Dictionary<int, decimal>();
        private List<Fila> _filas;

        /// <param name="todos">Todos los despachos de la solicitud, para calcular el saldo que quedó después de esta entrega.</param>
        public ImpresionDespacho(Solicitud s, Despacho d, List<Despacho> todos) : base(d.Folio, horizontal: false)
        {
            _s = s;
            _d = d;
            foreach (var l in s.Lineas)
                _saldoDespues[l.IdDetalleSolicitud] = l.CantidadSolicitada - todos.Where(x => x.IdDespacho <= d.IdDespacho)
                    .Sum(x => x.Cantidades.TryGetValue(l.IdDetalleSolicitud, out var c) ? c : 0);
        }

        protected override string Folio => _d.Folio;
        protected override string Subtitulo => "COMPROBANTE DE DESPACHO";
        protected override string[] Firmas => new[] { "Entregado por: " + _d.UsuarioNombre, "Recibido por: " + (_d.RecibidoPor ?? "") };

        protected override Columna[] Columnas => new[]
        {
            new Columna("Código", 70), new Columna("Material", 0), new Columna("Unidad", 50),
            new Columna("Cantidad entregada", 80, true), new Columna("Saldo pendiente", 75, true)
        };

        protected override List<Fila> Filas => _filas ?? (_filas = Agrupar(
            _s.Lineas.Where(l => _d.Cantidades.ContainsKey(l.IdDetalleSolicitud)),
            l => new[] { l.Codigo, l.Material, l.Unidad, Num(_d.Cantidades[l.IdDetalleSolicitud]), Num(_saldoDespues[l.IdDetalleSolicitud]) }));

        protected override float DibujarDatos(Graphics g, RectangleF area, float y)
        {
            float x = Dato(g, "Solicitud", _s.Folio, area.Left, y);
            Dato(g, "Fecha", _d.FechaHora.ToString("dd-MM-yyyy HH:mm"), x, y);
            y += 16;
            DibujarEncabezadoObra(g, _s, area.Left, y);
            y += 16;
            x = Dato(g, "Ubicación", _s.ObraDireccion, area.Left, y);
            Dato(g, "Maestro", _s.ObraMaestro, x, y);
            y += 16;
            if (!string.IsNullOrEmpty(_d.Observaciones))
            {
                Dato(g, "Observaciones", _d.Observaciones, area.Left, y);
                y += 16;
            }
            return y;
        }
    }
}
