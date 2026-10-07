using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace gestion_inventario_rio_bravo
{
    public partial class FormNuevaSolicitud : Form
    {
        public FormNuevaSolicitud()
        {
            InitializeComponent();
        }

        private void FormNuevaSolicitud_Load(object sender, EventArgs e)
        {
            // Opciones predefinidas de materiales más comunes (intuitivo para los usuarios)
            cmbArticulo.Items.AddRange(new object[] {
                "Sacos de Cemento",
                "Madera de Pino 2x4",
                "Grava / Ripio",
                "Fierro de Construcción",
                "Arena Gruesa",
                "Grúa Horquilla (Días)"
            });
            if (cmbArticulo.Items.Count > 0) cmbArticulo.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas sencillas
            if (cmbArticulo.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un artículo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbObra.Text))
            {
                MessageBox.Show("Por favor, indique la obra de destino.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtCantidad.Text, out float cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Generar un código único simple (ej: SOL-342)
                string codigoSolicitud = "SOL-" + new Random().Next(100, 999).ToString();
                string articulo = cmbArticulo.SelectedItem.ToString();
                string obraDestino = cmbObra.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();

                using (var conn = ConexionBD.ObtenerConexion())
                {
                    // 3. Consultar el stock actual que hay en bodega de ese artículo (o poner 0 si no existe)
                    float stockActual = 0;
                    string queryStock = "SELECT stock_actual FROM Solicitud WHERE articulo = @art ORDER BY id DESC LIMIT 1;";
                    using (var cmdStock = new NpgsqlCommand(queryStock, conn))
                    {
                        cmdStock.Parameters.AddWithValue("@art", articulo);
                        var res = cmdStock.ExecuteScalar();
                        if (res != null && res != DBNull.Value)
                        {
                            stockActual = Convert.ToSingle(res);
                        }
                    }

                    // 4. Guardar la nueva solicitud en estado 'Pendiente'
                    string queryInsert = @"INSERT INTO Solicitud 
                                            (id_solicitud, articulo, cantidad, estado, obra_destino, stock_actual, fecha, descripcion) 
                                           VALUES 
                                            (@codigo, @art, @cant, 'Pendiente', @obra, @stock, CURRENT_DATE, @desc);";

                    using (var cmd = new NpgsqlCommand(queryInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigoSolicitud);
                        cmd.Parameters.AddWithValue("@art", articulo);
                        cmd.Parameters.AddWithValue("@cant", cantidad);
                        cmd.Parameters.AddWithValue("@obra", obraDestino);
                        cmd.Parameters.AddWithValue("@stock", stockActual);
                        cmd.Parameters.AddWithValue("@desc", descripcion);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"¡Solicitud {codigoSolicitud} creada exitosamente en estado Pendiente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la solicitud: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


