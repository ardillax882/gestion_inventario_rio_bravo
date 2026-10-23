namespace gestion_inventario_rio_bravo.Views
{
    partial class FormEquipos
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
            System.Windows.Forms.DataGridViewCellStyle estiloFecha = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFiltros = new System.Windows.Forms.FlowLayoutPanel();
            this.chkDevueltos = new System.Windows.Forms.CheckBox();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.colEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaPrestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecibidoPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPrestar = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.cmbEquipo = new System.Windows.Forms.ComboBox();
            this.lblObra = new System.Windows.Forms.Label();
            this.cmbObra = new System.Windows.Forms.ComboBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnPrestar = new System.Windows.Forms.Button();
            this.pnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.pnlPrestar.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // estilos
            //
            estiloFecha.Format = "dd-MM-yyyy HH:mm";
            //
            // pnlFiltros
            //
            this.pnlFiltros.Controls.Add(this.chkDevueltos);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(6);
            this.pnlFiltros.Size = new System.Drawing.Size(900, 34);
            this.pnlFiltros.TabIndex = 0;
            //
            // chkDevueltos
            //
            this.chkDevueltos.AutoSize = true;
            this.chkDevueltos.Name = "chkDevueltos";
            this.chkDevueltos.TabIndex = 0;
            this.chkDevueltos.Text = "Mostrar también los ya devueltos";
            this.chkDevueltos.UseVisualStyleBackColor = true;
            this.chkDevueltos.CheckedChanged += new System.EventHandler(this.chkDevueltos_CheckedChanged);
            //
            // dgvPrestamos
            //
            this.dgvPrestamos.AllowUserToAddRows = false;
            this.dgvPrestamos.AllowUserToDeleteRows = false;
            this.dgvPrestamos.AllowUserToResizeColumns = false;
            this.dgvPrestamos.AllowUserToResizeRows = false;
            this.dgvPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrestamos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEquipo,
            this.colObra,
            this.colFechaPrestamo,
            this.colUsuario,
            this.colFechaDevolucion,
            this.colRecibidoPor,
            this.colObservaciones});
            this.dgvPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrestamos.MultiSelect = false;
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.ReadOnly = true;
            this.dgvPrestamos.RowHeadersVisible = false;
            this.dgvPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrestamos.TabIndex = 1;
            this.dgvPrestamos.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPrestamos_RowPrePaint);
            //
            // colEquipo
            //
            this.colEquipo.DataPropertyName = "EquipoTexto";
            this.colEquipo.FillWeight = 80F;
            this.colEquipo.HeaderText = "Equipo";
            this.colEquipo.Name = "colEquipo";
            //
            // colObra
            //
            this.colObra.DataPropertyName = "ObraNombre";
            this.colObra.HeaderText = "Obra";
            this.colObra.Name = "colObra";
            //
            // colFechaPrestamo
            //
            this.colFechaPrestamo.DataPropertyName = "FechaPrestamo";
            this.colFechaPrestamo.DefaultCellStyle = estiloFecha;
            this.colFechaPrestamo.FillWeight = 70F;
            this.colFechaPrestamo.HeaderText = "Prestado el";
            this.colFechaPrestamo.Name = "colFechaPrestamo";
            //
            // colUsuario
            //
            this.colUsuario.DataPropertyName = "UsuarioNombre";
            this.colUsuario.FillWeight = 70F;
            this.colUsuario.HeaderText = "Entregó";
            this.colUsuario.Name = "colUsuario";
            //
            // colFechaDevolucion
            //
            this.colFechaDevolucion.DataPropertyName = "FechaDevolucion";
            this.colFechaDevolucion.DefaultCellStyle = estiloFecha;
            this.colFechaDevolucion.FillWeight = 70F;
            this.colFechaDevolucion.HeaderText = "Devuelto el";
            this.colFechaDevolucion.Name = "colFechaDevolucion";
            //
            // colRecibidoPor
            //
            this.colRecibidoPor.DataPropertyName = "RecibidoPor";
            this.colRecibidoPor.FillWeight = 70F;
            this.colRecibidoPor.HeaderText = "Recibió en bodega";
            this.colRecibidoPor.Name = "colRecibidoPor";
            //
            // colObservaciones
            //
            this.colObservaciones.DataPropertyName = "Observaciones";
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            //
            // pnlPrestar
            //
            this.pnlPrestar.Controls.Add(this.lblEquipo);
            this.pnlPrestar.Controls.Add(this.cmbEquipo);
            this.pnlPrestar.Controls.Add(this.lblObra);
            this.pnlPrestar.Controls.Add(this.cmbObra);
            this.pnlPrestar.Controls.Add(this.lblObservaciones);
            this.pnlPrestar.Controls.Add(this.txtObservaciones);
            this.pnlPrestar.Controls.Add(this.btnPrestar);
            this.pnlPrestar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPrestar.Name = "pnlPrestar";
            this.pnlPrestar.Padding = new System.Windows.Forms.Padding(6);
            this.pnlPrestar.Size = new System.Drawing.Size(900, 40);
            this.pnlPrestar.TabIndex = 2;
            //
            // lblEquipo
            //
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Margin = new System.Windows.Forms.Padding(3, 8, 0, 0);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Text = "Prestar:";
            //
            // cmbEquipo
            //
            this.cmbEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquipo.Name = "cmbEquipo";
            this.cmbEquipo.Size = new System.Drawing.Size(140, 21);
            this.cmbEquipo.TabIndex = 0;
            //
            // lblObra
            //
            this.lblObra.AutoSize = true;
            this.lblObra.Margin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.lblObra.Name = "lblObra";
            this.lblObra.Text = "a la obra:";
            //
            // cmbObra
            //
            this.cmbObra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObra.Name = "cmbObra";
            this.cmbObra.Size = new System.Drawing.Size(220, 21);
            this.cmbObra.TabIndex = 1;
            //
            // lblObservaciones
            //
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Margin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Text = "Obs.:";
            //
            // txtObservaciones
            //
            this.txtObservaciones.MaxLength = 200;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(220, 20);
            this.txtObservaciones.TabIndex = 2;
            //
            // btnPrestar
            //
            this.btnPrestar.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new System.Drawing.Size(90, 26);
            this.btnPrestar.TabIndex = 3;
            this.btnPrestar.Text = "Prestar";
            this.btnPrestar.UseVisualStyleBackColor = true;
            this.btnPrestar.Click += new System.EventHandler(this.btnPrestar_Click);
            //
            // pnlBotones
            //
            this.pnlBotones.Controls.Add(this.btnCerrar);
            this.pnlBotones.Controls.Add(this.btnDevolver);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(6);
            this.pnlBotones.Size = new System.Drawing.Size(900, 46);
            this.pnlBotones.TabIndex = 3;
            //
            // btnCerrar
            //
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 28);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            //
            // btnDevolver
            //
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(170, 28);
            this.btnDevolver.Text = "Registrar devolución a bodega";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            //
            // FormEquipos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.dgvPrestamos);
            this.Controls.Add(this.pnlPrestar);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlFiltros);
            this.MinimizeBox = false;
            this.Name = "FormEquipos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Equipos prestados a obras";
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.pnlPrestar.ResumeLayout(false);
            this.pnlPrestar.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlFiltros;
        private System.Windows.Forms.CheckBox chkDevueltos;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaPrestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecibidoPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.FlowLayoutPanel pnlPrestar;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.ComboBox cmbEquipo;
        private System.Windows.Forms.Label lblObra;
        private System.Windows.Forms.ComboBox cmbObra;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnPrestar;
        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnDevolver;
    }
}
