using System.Windows.Forms;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Pide un texto obligatorio (ej. motivo de rechazo). Devuelve null si se cancela.</summary>
    public partial class FormTexto : Form
    {
        public FormTexto(string titulo, string etiqueta, int largoMaximo)
        {
            InitializeComponent();
            Text = titulo;
            lblEtiqueta.Text = etiqueta;
            txtTexto.MaxLength = largoMaximo;
        }

        public static string Pedir(IWin32Window owner, string titulo, string etiqueta, int largoMaximo)
        {
            using (var f = new FormTexto(titulo, etiqueta, largoMaximo))
                return f.ShowDialog(owner) == DialogResult.OK ? f.txtTexto.Text : null;
        }
    }
}
