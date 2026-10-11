namespace gestion_inventario_rio_bravo.Views
{
    partial class FormKardex
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle estiloNumero = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloMoneda = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloFecha = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            //
            // estilos
            //
            estiloNumero.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloNumero.Format = "#,0.##;-#,0.##;\"\"";
            estiloMoneda.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloMoneda.Format = "$ #,0";
            estiloFecha.Format = "dd-MM-yyyy HH:mm";
            //
            // lblMaterial
            //
            this.lblMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMaterial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblMaterial.Size = new System.Drawing.Size(900, 34);
            this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dgvMovimientos
            //
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AllowUserToResizeColumns = false;
            this.dgvMovimientos.AllowUserToResizeRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colTipo,
            this.colEntrada,
            this.colSalida,
            this.colSaldo,
            this.colPrecio,
            this.colDocumento,
            this.colDetalle,
            this.colUsuario});
            this.dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.TabIndex = 0;
            //
            // colFecha
            //
            this.colFecha.DataPropertyName = "FechaHora";
            this.colFecha.DefaultCellStyle = estiloFecha;
            this.colFecha.FillWeight = 70F;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            //
            // colTipo
            //
            this.colTipo.DataPropertyName = "TipoTexto";
            this.colTipo.FillWeight = 70F;
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            //
            // colEntrada
            //
            this.colEntrada.DataPropertyName = "Entrada";
            this.colEntrada.DefaultCellStyle = estiloNumero;
            this.colEntrada.FillWeight = 45F;
            this.colEntrada.HeaderText = "Entrada";
            this.colEntrada.Name = "colEntrada";
            //
            // colSalida
            //
            this.colSalida.DataPropertyName = "Salida";
            this.colSalida.DefaultCellStyle = estiloNumero;
            this.colSalida.FillWeight = 45F;
            this.colSalida.HeaderText = "Salida";
            this.colSalida.Name = "colSalida";
            //
            // colSaldo
            //
            this.colSaldo.DataPropertyName = "Saldo";
            this.colSaldo.DefaultCellStyle = estiloNumero;
            this.colSaldo.FillWeight = 45F;
            this.colSaldo.HeaderText = "Saldo";
            this.colSaldo.Name = "colSaldo";
            //
            // colPrecio
            //
            this.colPrecio.DataPropertyName = "PrecioUnitario";
            this.colPrecio.DefaultCellStyle = estiloMoneda;
            this.colPrecio.FillWeight = 45F;
            this.colPrecio.HeaderText = "Precio unit.";
            this.colPrecio.Name = "colPrecio";
            //
            // colDocumento
            //
            this.colDocumento.DataPropertyName = "Documento";
            this.colDocumento.FillWeight = 50F;
            this.colDocumento.HeaderText = "Documento";
            this.colDocumento.Name = "colDocumento";
            //
            // colDetalle
            //
            this.colDetalle.DataPropertyName = "Detalle";
            this.colDetalle.HeaderText = "Obra / motivo";
            this.colDetalle.Name = "colDetalle";
            //
            // colUsuario
            //
            this.colUsuario.DataPropertyName = "Usuario";
            this.colUsuario.FillWeight = 60F;
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            //
            // FormKardex
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.lblMaterial);
            this.MinimizeBox = false;
            this.Name = "FormKardex";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movimientos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
    }
}
