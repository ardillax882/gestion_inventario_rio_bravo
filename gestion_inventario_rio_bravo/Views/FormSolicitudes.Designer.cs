namespace gestion_inventario_rio_bravo.Views
{
    partial class FormSolicitudes
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
            System.Windows.Forms.DataGridViewCellStyle estiloFecha = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFiltros = new System.Windows.Forms.FlowLayoutPanel();
            this.lblObra = new System.Windows.Forms.Label();
            this.cmbObra = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.colFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAprobador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // estilos
            //
            estiloNumero.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloNumero.Format = "#,0.##";
            estiloFecha.Format = "dd-MM-yyyy";
            //
            // pnlFiltros
            //
            this.pnlFiltros.Controls.Add(this.lblObra);
            this.pnlFiltros.Controls.Add(this.cmbObra);
            this.pnlFiltros.Controls.Add(this.lblEstado);
            this.pnlFiltros.Controls.Add(this.cmbEstado);
            this.pnlFiltros.Controls.Add(this.lblTotal);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(6);
            this.pnlFiltros.Size = new System.Drawing.Size(900, 38);
            this.pnlFiltros.TabIndex = 0;
            //
            // lblObra
            //
            this.lblObra.AutoSize = true;
            this.lblObra.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblObra.Name = "lblObra";
            this.lblObra.Text = "Obra:";
            //
            // cmbObra
            //
            this.cmbObra.DisplayMember = "NombreObra";
            this.cmbObra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObra.Name = "cmbObra";
            this.cmbObra.Size = new System.Drawing.Size(240, 21);
            this.cmbObra.TabIndex = 0;
            this.cmbObra.ValueMember = "IdObra";
            this.cmbObra.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Margin = new System.Windows.Forms.Padding(15, 7, 3, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Estado:";
            //
            // cmbEstado
            //
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(270, 21);
            this.cmbEstado.TabIndex = 1;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblTotal.Margin = new System.Windows.Forms.Padding(20, 7, 3, 0);
            this.lblTotal.Name = "lblTotal";
            //
            // dgvSolicitudes
            //
            this.dgvSolicitudes.AllowUserToAddRows = false;
            this.dgvSolicitudes.AllowUserToDeleteRows = false;
            this.dgvSolicitudes.AllowUserToResizeColumns = false;
            this.dgvSolicitudes.AllowUserToResizeRows = false;
            this.dgvSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitudes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFolio,
            this.colFecha,
            this.colObra,
            this.colEstado,
            this.colSaldo,
            this.colRegistro,
            this.colAprobador});
            this.dgvSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSolicitudes.MultiSelect = false;
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.ReadOnly = true;
            this.dgvSolicitudes.RowHeadersVisible = false;
            this.dgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitudes.TabIndex = 1;
            this.dgvSolicitudes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolicitudes_CellDoubleClick);
            //
            // colFolio
            //
            this.colFolio.DataPropertyName = "Folio";
            this.colFolio.FillWeight = 50F;
            this.colFolio.HeaderText = "Folio";
            this.colFolio.Name = "colFolio";
            //
            // colFecha
            //
            this.colFecha.DataPropertyName = "FechaSolicitud";
            this.colFecha.DefaultCellStyle = estiloFecha;
            this.colFecha.FillWeight = 50F;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            //
            // colObra
            //
            this.colObra.DataPropertyName = "ObraNombre";
            this.colObra.FillWeight = 130F;
            this.colObra.HeaderText = "Obra";
            this.colObra.Name = "colObra";
            //
            // colEstado
            //
            this.colEstado.DataPropertyName = "EstadoTexto";
            this.colEstado.FillWeight = 70F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            //
            // colSaldo
            //
            this.colSaldo.DataPropertyName = "SaldoTotal";
            this.colSaldo.DefaultCellStyle = estiloNumero;
            this.colSaldo.FillWeight = 50F;
            this.colSaldo.HeaderText = "Saldo por entregar";
            this.colSaldo.Name = "colSaldo";
            //
            // colRegistro
            //
            this.colRegistro.DataPropertyName = "UsuarioNombre";
            this.colRegistro.FillWeight = 70F;
            this.colRegistro.HeaderText = "Registrada por";
            this.colRegistro.Name = "colRegistro";
            //
            // colAprobador
            //
            this.colAprobador.DataPropertyName = "AprobadorNombre";
            this.colAprobador.FillWeight = 70F;
            this.colAprobador.HeaderText = "Aprobada/rechazada por";
            this.colAprobador.Name = "colAprobador";
            //
            // pnlBotones
            //
            this.pnlBotones.Controls.Add(this.btnCerrar);
            this.pnlBotones.Controls.Add(this.btnAbrir);
            this.pnlBotones.Controls.Add(this.btnNueva);
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
            // btnAbrir
            //
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(110, 28);
            this.btnAbrir.Text = "Abrir planilla";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            //
            // btnNueva
            //
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(110, 28);
            this.btnNueva.Text = "Nueva solicitud";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            //
            // FormSolicitudes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.dgvSolicitudes);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlFiltros);
            this.MinimizeBox = false;
            this.Name = "FormSolicitudes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solicitudes de materiales";
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlFiltros;
        private System.Windows.Forms.Label lblObra;
        private System.Windows.Forms.ComboBox cmbObra;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAprobador;
        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnNueva;
    }
}
