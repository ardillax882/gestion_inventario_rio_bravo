namespace gestion_inventario_rio_bravo.Views
{
    partial class FormDespacho
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
            System.Windows.Forms.DataGridViewCellStyle estiloEntregar = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblInfo = new System.Windows.Forms.Label();
            this.dgvLineas = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.btnTodo = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblRecibidoPor = new System.Windows.Forms.Label();
            this.txtRecibidoPor = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineas)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // estilos
            //
            estiloNumero.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloNumero.Format = "#,0.##";
            estiloEntregar.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloEntregar.BackColor = System.Drawing.Color.LightYellow;
            estiloEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            estiloEntregar.Format = "#,0.##";
            //
            // lblInfo
            //
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblInfo.Size = new System.Drawing.Size(860, 30);
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dgvLineas
            //
            this.dgvLineas.AllowUserToAddRows = false;
            this.dgvLineas.AllowUserToDeleteRows = false;
            this.dgvLineas.AllowUserToResizeColumns = false;
            this.dgvLineas.AllowUserToResizeRows = false;
            this.dgvLineas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLineas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colMaterial,
            this.colCategoria,
            this.colUnidad,
            this.colSaldo,
            this.colStock,
            this.colEntregar});
            this.dgvLineas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLineas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.dgvLineas.MultiSelect = false;
            this.dgvLineas.Name = "dgvLineas";
            this.dgvLineas.RowHeadersVisible = false;
            this.dgvLineas.TabIndex = 0;
            this.dgvLineas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvLineas_CellValidating);
            //
            // colCodigo
            //
            this.colCodigo.FillWeight = 50F;
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            //
            // colMaterial
            //
            this.colMaterial.FillWeight = 150F;
            this.colMaterial.HeaderText = "Material";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.ReadOnly = true;
            //
            // colCategoria
            //
            this.colCategoria.FillWeight = 70F;
            this.colCategoria.HeaderText = "Sección";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            //
            // colUnidad
            //
            this.colUnidad.FillWeight = 40F;
            this.colUnidad.HeaderText = "Unidad";
            this.colUnidad.Name = "colUnidad";
            this.colUnidad.ReadOnly = true;
            //
            // colSaldo
            //
            this.colSaldo.DefaultCellStyle = estiloNumero;
            this.colSaldo.FillWeight = 50F;
            this.colSaldo.HeaderText = "Saldo pendiente";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.ReadOnly = true;
            //
            // colStock
            //
            this.colStock.DefaultCellStyle = estiloNumero;
            this.colStock.FillWeight = 50F;
            this.colStock.HeaderText = "Stock bodega";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            //
            // colEntregar
            //
            this.colEntregar.DefaultCellStyle = estiloEntregar;
            this.colEntregar.FillWeight = 55F;
            this.colEntregar.HeaderText = "Entregar hoy";
            this.colEntregar.Name = "colEntregar";
            //
            // pnlDatos
            //
            this.pnlDatos.Controls.Add(this.btnTodo);
            this.pnlDatos.Controls.Add(this.btnLimpiar);
            this.pnlDatos.Controls.Add(this.lblRecibidoPor);
            this.pnlDatos.Controls.Add(this.txtRecibidoPor);
            this.pnlDatos.Controls.Add(this.lblObservaciones);
            this.pnlDatos.Controls.Add(this.txtObservaciones);
            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(860, 100);
            this.pnlDatos.TabIndex = 1;
            //
            // btnTodo
            //
            this.btnTodo.Location = new System.Drawing.Point(8, 6);
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(230, 26);
            this.btnTodo.TabIndex = 0;
            this.btnTodo.Text = "Entregar todo el saldo (según stock)";
            this.btnTodo.UseVisualStyleBackColor = true;
            this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);
            //
            // btnLimpiar
            //
            this.btnLimpiar.Location = new System.Drawing.Point(244, 6);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 26);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            //
            // lblRecibidoPor
            //
            this.lblRecibidoPor.AutoSize = true;
            this.lblRecibidoPor.Location = new System.Drawing.Point(8, 44);
            this.lblRecibidoPor.Name = "lblRecibidoPor";
            this.lblRecibidoPor.Text = "Recibido por:";
            //
            // txtRecibidoPor
            //
            this.txtRecibidoPor.Location = new System.Drawing.Point(100, 41);
            this.txtRecibidoPor.MaxLength = 100;
            this.txtRecibidoPor.Name = "txtRecibidoPor";
            this.txtRecibidoPor.Size = new System.Drawing.Size(260, 20);
            this.txtRecibidoPor.TabIndex = 2;
            //
            // lblObservaciones
            //
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(8, 72);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Text = "Observaciones:";
            //
            // txtObservaciones
            //
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.Location = new System.Drawing.Point(100, 69);
            this.txtObservaciones.MaxLength = 300;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(750, 20);
            this.txtObservaciones.TabIndex = 3;
            //
            // pnlBotones
            //
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnConfirmar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(6);
            this.pnlBotones.Size = new System.Drawing.Size(860, 46);
            this.pnlBotones.TabIndex = 2;
            //
            // btnCancelar
            //
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 28);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            //
            // btnConfirmar
            //
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(150, 28);
            this.btnConfirmar.Text = "Confirmar despacho";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            //
            // FormDespacho
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(860, 520);
            this.Controls.Add(this.dgvLineas);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.lblInfo);
            this.MinimizeBox = false;
            this.Name = "FormDespacho";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo despacho";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineas)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView dgvLineas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregar;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Button btnTodo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblRecibidoPor;
        private System.Windows.Forms.TextBox txtRecibidoPor;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
    }
}
