namespace gestion_inventario_rio_bravo.Views
{
    partial class FormMateriales
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
            this.pnlFiltros = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.chkBajoMinimo = new System.Windows.Forms.CheckBox();
            this.chkInactivos = new System.Windows.Forms.CheckBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvMateriales = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnKardex = new System.Windows.Forms.Button();
            this.btnAjuste = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriales)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // estilos
            //
            estiloNumero.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloNumero.Format = "#,0.##";
            estiloMoneda.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloMoneda.Format = "$ #,0";
            //
            // pnlFiltros
            //
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Controls.Add(this.chkBajoMinimo);
            this.pnlFiltros.Controls.Add(this.chkInactivos);
            this.pnlFiltros.Controls.Add(this.lblTotal);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(6);
            this.pnlFiltros.Size = new System.Drawing.Size(900, 40);
            this.pnlFiltros.TabIndex = 0;
            //
            // lblBuscar
            //
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Buscar (código o nombre):";
            //
            // txtBuscar
            //
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(220, 20);
            this.txtBuscar.TabIndex = 0;
            //
            // btnBuscar
            //
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 26);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.Filtro_Changed);
            //
            // chkBajoMinimo
            //
            this.chkBajoMinimo.AutoSize = true;
            this.chkBajoMinimo.Margin = new System.Windows.Forms.Padding(12, 7, 3, 3);
            this.chkBajoMinimo.Name = "chkBajoMinimo";
            this.chkBajoMinimo.TabIndex = 2;
            this.chkBajoMinimo.Text = "Solo bajo stock mínimo";
            this.chkBajoMinimo.UseVisualStyleBackColor = true;
            this.chkBajoMinimo.CheckedChanged += new System.EventHandler(this.Filtro_Changed);
            //
            // chkInactivos
            //
            this.chkInactivos.AutoSize = true;
            this.chkInactivos.Margin = new System.Windows.Forms.Padding(12, 7, 3, 3);
            this.chkInactivos.Name = "chkInactivos";
            this.chkInactivos.TabIndex = 3;
            this.chkInactivos.Text = "Mostrar inactivos";
            this.chkInactivos.UseVisualStyleBackColor = true;
            this.chkInactivos.CheckedChanged += new System.EventHandler(this.Filtro_Changed);
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblTotal.Margin = new System.Windows.Forms.Padding(20, 8, 3, 0);
            this.lblTotal.Name = "lblTotal";
            //
            // dgvMateriales
            //
            this.dgvMateriales.AllowUserToAddRows = false;
            this.dgvMateriales.AllowUserToDeleteRows = false;
            this.dgvMateriales.AllowUserToResizeColumns = false;
            this.dgvMateriales.AllowUserToResizeRows = false;
            this.dgvMateriales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMateriales.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMateriales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombre,
            this.colCategoria,
            this.colUnidad,
            this.colStock,
            this.colMinimo,
            this.colPrecio,
            this.colActivo});
            this.dgvMateriales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMateriales.MultiSelect = false;
            this.dgvMateriales.Name = "dgvMateriales";
            this.dgvMateriales.ReadOnly = true;
            this.dgvMateriales.RowHeadersVisible = false;
            this.dgvMateriales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMateriales.TabIndex = 1;
            this.dgvMateriales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMateriales_CellDoubleClick);
            this.dgvMateriales.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvMateriales_RowPrePaint);
            //
            // colCodigo
            //
            this.colCodigo.DataPropertyName = "Codigo";
            this.colCodigo.FillWeight = 50F;
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            //
            // colNombre
            //
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.FillWeight = 160F;
            this.colNombre.HeaderText = "Material";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            //
            // colCategoria
            //
            this.colCategoria.DataPropertyName = "CategoriaNombre";
            this.colCategoria.FillWeight = 80F;
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            //
            // colUnidad
            //
            this.colUnidad.DataPropertyName = "UnidadMedida";
            this.colUnidad.FillWeight = 40F;
            this.colUnidad.HeaderText = "Unidad";
            this.colUnidad.Name = "colUnidad";
            this.colUnidad.ReadOnly = true;
            //
            // colStock
            //
            this.colStock.DataPropertyName = "StockActual";
            this.colStock.DefaultCellStyle = estiloNumero;
            this.colStock.FillWeight = 50F;
            this.colStock.HeaderText = "Stock actual";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            //
            // colMinimo
            //
            this.colMinimo.DataPropertyName = "StockMinimo";
            this.colMinimo.DefaultCellStyle = estiloNumero;
            this.colMinimo.FillWeight = 50F;
            this.colMinimo.HeaderText = "Stock mínimo";
            this.colMinimo.Name = "colMinimo";
            this.colMinimo.ReadOnly = true;
            //
            // colPrecio
            //
            this.colPrecio.DataPropertyName = "PrecioUnitario";
            this.colPrecio.DefaultCellStyle = estiloMoneda;
            this.colPrecio.FillWeight = 50F;
            this.colPrecio.HeaderText = "Precio unit.";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            //
            // colActivo
            //
            this.colActivo.DataPropertyName = "Activo";
            this.colActivo.FillWeight = 30F;
            this.colActivo.HeaderText = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.ReadOnly = true;
            //
            // pnlBotones
            //
            this.pnlBotones.Controls.Add(this.btnCerrar);
            this.pnlBotones.Controls.Add(this.btnKardex);
            this.pnlBotones.Controls.Add(this.btnAjuste);
            this.pnlBotones.Controls.Add(this.btnEditar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(6);
            this.pnlBotones.Size = new System.Drawing.Size(900, 46);
            this.pnlBotones.TabIndex = 2;
            //
            // btnCerrar
            //
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 28);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            //
            // btnKardex
            //
            this.btnKardex.Name = "btnKardex";
            this.btnKardex.Size = new System.Drawing.Size(120, 28);
            this.btnKardex.Text = "Ver movimientos";
            this.btnKardex.UseVisualStyleBackColor = true;
            this.btnKardex.Click += new System.EventHandler(this.btnKardex_Click);
            //
            // btnAjuste
            //
            this.btnAjuste.Name = "btnAjuste";
            this.btnAjuste.Size = new System.Drawing.Size(120, 28);
            this.btnAjuste.Text = "Ajustar stock";
            this.btnAjuste.UseVisualStyleBackColor = true;
            this.btnAjuste.Click += new System.EventHandler(this.btnAjuste_Click);
            //
            // btnEditar
            //
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 28);
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            //
            // btnNuevo
            //
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 28);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            //
            // FormMateriales
            //
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.dgvMateriales);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlFiltros);
            this.MinimizeBox = false;
            this.Name = "FormMateriales";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Materiales y stock";
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriales)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox chkBajoMinimo;
        private System.Windows.Forms.CheckBox chkInactivos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvMateriales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActivo;
        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnKardex;
        private System.Windows.Forms.Button btnAjuste;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
    }
}
