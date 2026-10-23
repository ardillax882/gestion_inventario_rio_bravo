using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>
    /// Tamaño de letra de todo el sistema (A− / A+ en la ventana principal). Cada usuario guarda el suyo
    /// en este PC, en %APPDATA%\InventarioRioBravo\letra.txt; antes del login se usa el último elegido.
    /// </summary>
    public static class Letra
    {
        public static readonly int[] Niveles = { 100, 115, 130, 150, 175 };

        public static int Porcentaje { get; private set; } = 100;

        private const string ClaveUltimo = "ultimo";
        private static readonly string Archivo = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "InventarioRioBravo", "letra.txt");
        private static string usuario;
        // Porcentaje ya aplicado a cada ventana, para escalar solo la diferencia cuando cambia.
        private static readonly ConditionalWeakTable<Form, object> aplicado = new ConditionalWeakTable<Form, object>();

        static Letra()
        {
            if (Leer().TryGetValue(ClaveUltimo, out int p)) Porcentaje = p;
        }

        /// <summary>Al iniciar sesión: usa el tamaño que ese usuario eligió la última vez (si no tiene, se mantiene el actual).</summary>
        public static void CargarUsuario(int idUsuario)
        {
            usuario = idUsuario.ToString();
            if (Leer().TryGetValue(usuario, out int p)) Porcentaje = p;
        }

        /// <summary>Sube o baja un nivel (pasos = +1 / −1) y repinta las ventanas abiertas.</summary>
        public static void Cambiar(int pasos)
        {
            int i = Math.Max(0, Array.IndexOf(Niveles, Porcentaje));
            int nuevo = Niveles[Math.Max(0, Math.Min(Niveles.Length - 1, i + pasos))];
            if (nuevo == Porcentaje) return;
            Porcentaje = nuevo;
            Guardar();
            foreach (var f in Application.OpenForms.Cast<Form>().ToList()) Aplicar(f);
        }

        /// <summary>
        /// Escala la letra de la ventana. Con AutoScaleMode.Font (todas las ventanas), cambiar Form.Font
        /// agranda también los controles; las letras propias (títulos, negritas) se escalan aparte.
        /// </summary>
        public static void Aplicar(Form f)
        {
            int antes = aplicado.TryGetValue(f, out object a) ? (int)a : 100;
            if (antes == Porcentaje) return;
            float r = Porcentaje / (float)antes;
            aplicado.Remove(f);
            aplicado.Add(f, Porcentaje);

            // Se buscan antes de cambiar Form.Font: después todas las heredadas también serían "distintas".
            var propias = new List<Control>();
            BuscarLetrasPropias(f, propias);
            var tablas = new List<DataGridView>();
            BuscarTablas(f, tablas);

            f.SuspendLayout();
            foreach (var c in propias) c.Font = Escalar(c.Font, r);
            f.Font = Escalar(f.Font, r);
            foreach (var strip in propias.OfType<ToolStrip>()) MenusDesplegables(strip.Items);
            foreach (var t in tablas)
            {
                foreach (DataGridViewColumn col in t.Columns)
                    if (col.DefaultCellStyle.Font != null) col.DefaultCellStyle.Font = Escalar(col.DefaultCellStyle.Font, r);
                t.RowTemplate.Height = (int)Math.Round(t.RowTemplate.Height * r);
                foreach (DataGridViewRow fila in t.Rows)
                {
                    if (fila.DefaultCellStyle.Font != null) fila.DefaultCellStyle.Font = Escalar(fila.DefaultCellStyle.Font, r);
                    fila.Height = (int)Math.Round(fila.Height * r);
                }
            }
            f.ResumeLayout(true);

            // Con letra grande, una ventana no puede quedar más grande que la pantalla.
            var area = Screen.FromControl(f).WorkingArea;
            var maximo = new Size(Math.Min(f.Width, area.Width), Math.Min(f.Height, area.Height));
            if (maximo != f.Size)
            {
                f.MinimumSize = new Size(Math.Min(f.MinimumSize.Width, maximo.Width), Math.Min(f.MinimumSize.Height, maximo.Height));
                f.Size = maximo;
            }
        }

        private static Font Escalar(Font fuente, float r) =>
            new Font(fuente.FontFamily, fuente.Size * r, fuente.Style, fuente.Unit, fuente.GdiCharSet);

        /// <summary>Controles con letra propia: su Font no es el mismo objeto que hereda del padre.</summary>
        private static void BuscarLetrasPropias(Control padre, List<Control> propias)
        {
            foreach (Control c in padre.Controls)
            {
                if (!ReferenceEquals(c.Font, padre.Font)) propias.Add(c);
                BuscarLetrasPropias(c, propias);
            }
        }

        private static void BuscarTablas(Control padre, List<DataGridView> tablas)
        {
            foreach (Control c in padre.Controls)
            {
                if (c is DataGridView t) tablas.Add(t);
                BuscarTablas(c, tablas);
            }
        }

        /// <summary>Los submenús son ventanas aparte: toman la letra del menú que los abre.</summary>
        private static void MenusDesplegables(ToolStripItemCollection items)
        {
            foreach (var item in items.OfType<ToolStripDropDownItem>())
            {
                item.DropDown.Font = item.Font;
                MenusDesplegables(item.DropDownItems);
            }
        }

        private static Dictionary<string, int> Leer()
        {
            var valores = new Dictionary<string, int>();
            try
            {
                if (File.Exists(Archivo))
                    foreach (var linea in File.ReadAllLines(Archivo))
                    {
                        var partes = linea.Split('=');
                        if (partes.Length == 2 && int.TryParse(partes[1], out int p) && Niveles.Contains(p))
                            valores[partes[0].Trim()] = p;
                    }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                // Sin preferencias guardadas se usa 100 %: no vale la pena interrumpir al usuario.
            }
            return valores;
        }

        private static void Guardar()
        {
            try
            {
                var valores = Leer();
                valores[ClaveUltimo] = Porcentaje;
                if (usuario != null) valores[usuario] = Porcentaje;
                Directory.CreateDirectory(Path.GetDirectoryName(Archivo));
                File.WriteAllLines(Archivo, valores.Select(v => v.Key + "=" + v.Value));
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                // Si no se puede guardar, el tamaño igual se aplica en esta sesión.
            }
        }
    }
}
