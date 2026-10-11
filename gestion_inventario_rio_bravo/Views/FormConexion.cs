using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Data;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Se muestra la primera vez en cada PC (o si la clave cambió): prueba la clave y la guarda cifrada.</summary>
    public partial class FormConexion : Form
    {
        public FormConexion(string motivo = null)
        {
            InitializeComponent();
            lblInfo.Text = (motivo ?? "La conexión a la base de datos no está configurada en este PC.")
                         + "\n\nIngrese la clave de conexión entregada por el administrador del sistema. "
                         + "Se guardará cifrada y solo para su usuario de Windows en este equipo.";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
                txtPassword.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                ConfiguracionConexion.Probar(txtPassword.Text);
                ConfiguracionConexion.Guardar(txtPassword.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) when (ConexionBD.EsErrorDeAutenticacion(ex))
            {
                Mensajes.Advertencia("La clave de conexión no es correcta.");
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo conectar con la base de datos. Revise la conexión a internet.", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
