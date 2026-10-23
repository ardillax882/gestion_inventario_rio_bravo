namespace gestion_inventario_rio_bravo.Views
{
    partial class FormAjuste
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
            this.lblMaterial = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblStockValor = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.rdbEntrada = new System.Windows.Forms.RadioButton();
            this.rdbSalida = new System.Windows.Forms.RadioButton();
            this.lblObra = new System.Windows.Forms.Label();
            this.cmbObra = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.pnlMotivos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMotivoInicial = new System.Windows.Forms.Button();
            this.btnMotivoConteo = new System.Windows.Forms.Button();
            this.btnMotivoMerma = new System.Windows.Forms.Button();
            this.btnMotivoDevolucion = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.pnlMotivos.SuspendLayout();
            this.SuspendLayout();
            //
            // lblMaterial
            //
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(20, 18);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Text = "Material:";
            //
            // cmbMaterial
            //
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.Location = new System.Drawing.Point(110, 15);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(380, 21);
            this.cmbMaterial.TabIndex = 0;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            //
            // lblStock
            //
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(20, 48);
            this.lblStock.Name = "lblStock";
            this.lblStock.Text = "Stock actual:";
            //
            // lblStockValor
            //
            this.lblStockValor.AutoSize = true;
            this.lblStockValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStockValor.Location = new System.Drawing.Point(110, 48);
            this.lblStockValor.Name = "lblStockValor";
            //
            // lblTipo
            //
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 76);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Text = "Tipo:";
            //
            // rdbEntrada
            //
            this.rdbEntrada.AutoSize = true;
            this.rdbEntrada.Location = new System.Drawing.Point(110, 74);
            this.rdbEntrada.Name = "rdbEntrada";
            this.rdbEntrada.TabIndex = 1;
            this.rdbEntrada.Text = "Entrada (suma stock)";
            this.rdbEntrada.UseVisualStyleBackColor = true;
            //
            // rdbSalida
            //
            this.rdbSalida.AutoSize = true;
            this.rdbSalida.Location = new System.Drawing.Point(260, 74);
            this.rdbSalida.Name = "rdbSalida";
            this.rdbSalida.TabIndex = 2;
            this.rdbSalida.Text = "Salida (resta stock)";
            this.rdbSalida.UseVisualStyleBackColor = true;
            this.rdbSalida.CheckedChanged += new System.EventHandler(this.rdbSalida_CheckedChanged);
            //
            // lblObra
            //
            this.lblObra.AutoSize = true;
            this.lblObra.Location = new System.Drawing.Point(20, 106);
            this.lblObra.Name = "lblObra";
            this.lblObra.Text = "Obra:";
            //
            // cmbObra
            //
            this.cmbObra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObra.Location = new System.Drawing.Point(110, 103);
            this.cmbObra.Name = "cmbObra";
            this.cmbObra.Size = new System.Drawing.Size(380, 21);
            this.cmbObra.TabIndex = 3;
            //
            // lblCantidad
            //
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(20, 136);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Text = "Cantidad:";
            //
            // numCantidad
            //
            this.numCantidad.DecimalPlaces = 2;
            this.numCantidad.Location = new System.Drawing.Point(110, 133);
            this.numCantidad.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(120, 20);
            this.numCantidad.TabIndex = 3;
            this.numCantidad.ThousandsSeparator = true;
            //
            // lblMotivo
            //
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(20, 166);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Text = "Motivo:";
            //
            // txtMotivo
            //
            this.txtMotivo.Location = new System.Drawing.Point(110, 163);
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(380, 20);
            this.txtMotivo.TabIndex = 4;
            //
            // pnlMotivos
            //
            this.pnlMotivos.Controls.Add(this.btnMotivoInicial);
            this.pnlMotivos.Controls.Add(this.btnMotivoConteo);
            this.pnlMotivos.Controls.Add(this.btnMotivoMerma);
            this.pnlMotivos.Controls.Add(this.btnMotivoDevolucion);
            this.pnlMotivos.Location = new System.Drawing.Point(106, 188);
            this.pnlMotivos.Name = "pnlMotivos";
            this.pnlMotivos.Size = new System.Drawing.Size(404, 30);
            this.pnlMotivos.TabIndex = 5;
            //
            // btnMotivoInicial
            //
            this.btnMotivoInicial.Name = "btnMotivoInicial";
            this.btnMotivoInicial.Size = new System.Drawing.Size(100, 24);
            this.btnMotivoInicial.Text = "Inventario inicial";
            this.btnMotivoInicial.UseVisualStyleBackColor = true;
            this.btnMotivoInicial.Click += new System.EventHandler(this.btnMotivo_Click);
            //
            // btnMotivoConteo
            //
            this.btnMotivoConteo.Name = "btnMotivoConteo";
            this.btnMotivoConteo.Size = new System.Drawing.Size(85, 24);
            this.btnMotivoConteo.Text = "Conteo físico";
            this.btnMotivoConteo.UseVisualStyleBackColor = true;
            this.btnMotivoConteo.Click += new System.EventHandler(this.btnMotivo_Click);
            //
            // btnMotivoMerma
            //
            this.btnMotivoMerma.Name = "btnMotivoMerma";
            this.btnMotivoMerma.Size = new System.Drawing.Size(55, 24);
            this.btnMotivoMerma.Text = "Merma";
            this.btnMotivoMerma.UseVisualStyleBackColor = true;
            this.btnMotivoMerma.Click += new System.EventHandler(this.btnMotivo_Click);
            //
            // btnMotivoDevolucion
            //
            this.btnMotivoDevolucion.Name = "btnMotivoDevolucion";
            this.btnMotivoDevolucion.Size = new System.Drawing.Size(120, 24);
            this.btnMotivoDevolucion.Text = "Devolución de obra";
            this.btnMotivoDevolucion.UseVisualStyleBackColor = true;
            this.btnMotivoDevolucion.Click += new System.EventHandler(this.btnMotivoDevolucion_Click);
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(304, 232);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 28);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Registrar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(400, 232);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 28);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            //
            // FormAjuste
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(514, 276);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblStockValor);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.rdbEntrada);
            this.Controls.Add(this.rdbSalida);
            this.Controls.Add(this.lblObra);
            this.Controls.Add(this.cmbObra);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.pnlMotivos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAjuste";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajuste de inventario";
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.pnlMotivos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblStockValor;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.RadioButton rdbEntrada;
        private System.Windows.Forms.RadioButton rdbSalida;
        private System.Windows.Forms.Label lblObra;
        private System.Windows.Forms.ComboBox cmbObra;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.FlowLayoutPanel pnlMotivos;
        private System.Windows.Forms.Button btnMotivoInicial;
        private System.Windows.Forms.Button btnMotivoConteo;
        private System.Windows.Forms.Button btnMotivoMerma;
        private System.Windows.Forms.Button btnMotivoDevolucion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
