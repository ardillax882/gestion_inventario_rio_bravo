namespace gestion_inventario_rio_bravo.Views
{
    partial class FormObras
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
            this.chkFinalizadas = new System.Windows.Forms.CheckBox();
            this.dgvObras = new System.Windows.Forms.DataGridView();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuperficie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaestro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresupuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnNuevaSolicitud = new System.Windows.Forms.Button();
            this.btnSolicitudes = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObras)).BeginInit();
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
            this.pnlFiltros.Controls.Add(this.chkFinalizadas);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(6);
            this.pnlFiltros.Size = new System.Drawing.Size(900, 34);
            this.pnlFiltros.TabIndex = 0;
            //
            // chkFinalizadas
            //
            this.chkFinalizadas.AutoSize = true;
            this.chkFinalizadas.Name = "chkFinalizadas";
            this.chkFinalizadas.TabIndex = 0;
            this.chkFinalizadas.Text = "Mostrar también obras finalizadas";
            this.chkFinalizadas.UseVisualStyleBackColor = true;
            this.chkFinalizadas.CheckedChanged += new System.EventHandler(this.chkFinalizadas_CheckedChanged);
            //
            // dgvObras
            //
            this.dgvObras.AllowUserToAddRows = false;
            this.dgvObras.AllowUserToDeleteRows = false;
            this.dgvObras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvObras.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvObras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colSuperficie,
            this.colDireccion,
            this.colMaestro,
            this.colEstado,
            this.colPresupuesto,
            this.colCosto});
            this.dgvObras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObras.MultiSelect = false;
            this.dgvObras.Name = "dgvObras";
            this.dgvObras.ReadOnly = true;
            this.dgvObras.RowHeadersVisible = false;
            this.dgvObras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObras.TabIndex = 1;
            this.dgvObras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObras_CellDoubleClick);
            //
            // colNombre
            //
            this.colNombre.DataPropertyName = "NombreObra";
            this.colNombre.FillWeight = 130F;
            this.colNombre.HeaderText = "Obra";
            this.colNombre.Name = "colNombre";
            //
            // colSuperficie
            //
            this.colSuperficie.DataPropertyName = "SuperficieM2";
            this.colSuperficie.DefaultCellStyle = estiloNumero;
            this.colSuperficie.FillWeight = 40F;
            this.colSuperficie.HeaderText = "m²";
            this.colSuperficie.Name = "colSuperficie";
            //
            // colDireccion
            //
            this.colDireccion.DataPropertyName = "Direccion";
            this.colDireccion.HeaderText = "Ubicación";
            this.colDireccion.Name = "colDireccion";
            //
            // colMaestro
            //
            this.colMaestro.DataPropertyName = "Maestro";
            this.colMaestro.FillWeight = 80F;
            this.colMaestro.HeaderText = "Maestro";
            this.colMaestro.Name = "colMaestro";
            //
            // colEstado
            //
            this.colEstado.DataPropertyName = "EstadoTexto";
            this.colEstado.FillWeight = 60F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            //
            // colPresupuesto
            //
            this.colPresupuesto.DataPropertyName = "PresupuestoMateriales";
            this.colPresupuesto.DefaultCellStyle = estiloMoneda;
            this.colPresupuesto.FillWeight = 60F;
            this.colPresupuesto.HeaderText = "Presupuesto";
            this.colPresupuesto.Name = "colPresupuesto";
            //
            // colCosto
            //
            this.colCosto.DataPropertyName = "CostoDespachado";
            this.colCosto.DefaultCellStyle = estiloMoneda;
            this.colCosto.FillWeight = 60F;
            this.colCosto.HeaderText = "Despachado";
            this.colCosto.Name = "colCosto";
            //
            // pnlBotones
            //
            this.pnlBotones.Controls.Add(this.btnCerrar);
            this.pnlBotones.Controls.Add(this.btnNuevaSolicitud);
            this.pnlBotones.Controls.Add(this.btnSolicitudes);
            this.pnlBotones.Controls.Add(this.btnEditar);
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
            // btnNuevaSolicitud
            //
            this.btnNuevaSolicitud.Name = "btnNuevaSolicitud";
            this.btnNuevaSolicitud.Size = new System.Drawing.Size(150, 28);
            this.btnNuevaSolicitud.Text = "Nueva solicitud para la obra";
            this.btnNuevaSolicitud.UseVisualStyleBackColor = true;
            this.btnNuevaSolicitud.Click += new System.EventHandler(this.btnNuevaSolicitud_Click);
            //
            // btnSolicitudes
            //
            this.btnSolicitudes.Name = "btnSolicitudes";
            this.btnSolicitudes.Size = new System.Drawing.Size(110, 28);
            this.btnSolicitudes.Text = "Ver solicitudes";
            this.btnSolicitudes.UseVisualStyleBackColor = true;
            this.btnSolicitudes.Click += new System.EventHandler(this.btnSolicitudes_Click);
            //
            // btnEditar
            //
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 28);
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            //
            // btnNueva
            //
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(90, 28);
            this.btnNueva.Text = "Nueva obra";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            //
            // FormObras
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.dgvObras);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlFiltros);
            this.MinimizeBox = false;
            this.Name = "FormObras";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Obras";
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObras)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlFiltros;
        private System.Windows.Forms.CheckBox chkFinalizadas;
        private System.Windows.Forms.DataGridView dgvObras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuperficie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaestro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresupuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCosto;
        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnNuevaSolicitud;
        private System.Windows.Forms.Button btnSolicitudes;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNueva;
    }
}
