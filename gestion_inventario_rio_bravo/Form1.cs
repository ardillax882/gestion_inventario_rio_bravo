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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarSolicitudes();
        }


        private void CargarSolicitudes()
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = @"SELECT 
                    id_solicitud AS ""ID Solicitud"",
                    articulo AS ""Artículo"",
                    cantidad AS ""Cantidad"",
                    estado AS ""Estado"",
                    obra_destino AS ""Obra Destino"",
                    stock_actual AS ""Stock Actual""
                    FROM Solicitud
                    ORDER BY id ASC;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            dt.Load(reader);

                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar solicitudes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsnuevasolicitud_Click(object sender, EventArgs e)
        {
            using (FormNuevaSolicitud ventanaNueva = new FormNuevaSolicitud())
            {
                if (ventanaNueva.ShowDialog() == DialogResult.OK)
                {
                    CargarSolicitudes(); 
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            // Colorear en verde claro si la solicitud está 'Pendiente'
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Estado")
            {
                string estado = e.Value.ToString();
                if (estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                    e.CellStyle.ForeColor = System.Drawing.Color.DarkGreen;
                }
                else if (estado.Equals("Aprobada", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = System.Drawing.Color.LightBlue;
                    e.CellStyle.ForeColor = System.Drawing.Color.DarkBlue;
                }
                else if (estado.Equals("Rechazada", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = System.Drawing.Color.LightCoral;
                    e.CellStyle.ForeColor = System.Drawing.Color.DarkRed;
                }
            }

            // Colorear en rojo si el stock actual no cubre la cantidad solicitada
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Stock Actual")
            {
                var fila = dataGridView1.Rows[e.RowIndex];
                if (fila.Cells["Cantidad"].Value != null && fila.Cells["Stock Actual"].Value != null)
                {
                    if (float.TryParse(fila.Cells["Stock Actual"].Value.ToString(), out float stock) &&
                        float.TryParse(fila.Cells["Cantidad"].Value.ToString(), out float cantidad))
                    {
                        if (stock < cantidad)
                        {
                            e.CellStyle.BackColor = System.Drawing.Color.Salmon;
                            e.CellStyle.ForeColor = System.Drawing.Color.DarkRed;
                        }
                    }
                }
            }
        }
    }
}
