namespace gestion_inventario_rio_bravo.Views
{
    partial class FormObraEditar
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblSuperficie = new System.Windows.Forms.Label();
            this.numSuperficie = new System.Windows.Forms.NumericUpDown();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblBeneficiario = new System.Windows.Forms.Label();
            this.txtBeneficiario = new System.Windows.Forms.TextBox();
            this.lblBeneficiarioRut = new System.Windows.Forms.Label();
            this.txtBeneficiarioRut = new System.Windows.Forms.TextBox();
            this.lblBeneficiarioTelefono = new System.Windows.Forms.Label();
            this.txtBeneficiarioTelefono = new System.Windows.Forms.TextBox();
            this.lblMaestro = new System.Windows.Forms.Label();
            this.txtMaestro = new System.Windows.Forms.TextBox();
            this.lblPresupuesto = new System.Windows.Forms.Label();
            this.numPresupuesto = new System.Windows.Forms.NumericUpDown();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSuperficie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPresupuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 18);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(97, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre de la obra:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(162, 12);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(330, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // lblSuperficie
            // 
            this.lblSuperficie.AutoSize = true;
            this.lblSuperficie.Location = new System.Drawing.Point(20, 48);
            this.lblSuperficie.Name = "lblSuperficie";
            this.lblSuperficie.Size = new System.Drawing.Size(77, 13);
            this.lblSuperficie.TabIndex = 1;
            this.lblSuperficie.Text = "Superficie (m²):";
            // 
            // numSuperficie
            // 
            this.numSuperficie.DecimalPlaces = 2;
            this.numSuperficie.Location = new System.Drawing.Point(162, 45);
            this.numSuperficie.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numSuperficie.Name = "numSuperficie";
            this.numSuperficie.Size = new System.Drawing.Size(100, 20);
            this.numSuperficie.TabIndex = 1;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(20, 78);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(58, 13);
            this.lblDireccion.TabIndex = 2;
            this.lblDireccion.Text = "Ubicación:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(162, 71);
            this.txtDireccion.MaxLength = 150;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(330, 20);
            this.txtDireccion.TabIndex = 2;
            // 
            // lblBeneficiario
            // 
            this.lblBeneficiario.AutoSize = true;
            this.lblBeneficiario.Location = new System.Drawing.Point(20, 108);
            this.lblBeneficiario.Name = "lblBeneficiario";
            this.lblBeneficiario.Size = new System.Drawing.Size(65, 13);
            this.lblBeneficiario.TabIndex = 3;
            this.lblBeneficiario.Text = "Beneficiario:";
            // 
            // txtBeneficiario
            // 
            this.txtBeneficiario.Location = new System.Drawing.Point(162, 101);
            this.txtBeneficiario.MaxLength = 100;
            this.txtBeneficiario.Name = "txtBeneficiario";
            this.txtBeneficiario.Size = new System.Drawing.Size(330, 20);
            this.txtBeneficiario.TabIndex = 3;
            // 
            // lblBeneficiarioRut
            //
            this.lblBeneficiarioRut.AutoSize = true;
            this.lblBeneficiarioRut.Location = new System.Drawing.Point(20, 138);
            this.lblBeneficiarioRut.Name = "lblBeneficiarioRut";
            this.lblBeneficiarioRut.Size = new System.Drawing.Size(88, 13);
            this.lblBeneficiarioRut.TabIndex = 3;
            this.lblBeneficiarioRut.Text = "RUT beneficiario:";
            //
            // txtBeneficiarioRut
            //
            this.txtBeneficiarioRut.Location = new System.Drawing.Point(162, 131);
            this.txtBeneficiarioRut.MaxLength = 12;
            this.txtBeneficiarioRut.Name = "txtBeneficiarioRut";
            this.txtBeneficiarioRut.Size = new System.Drawing.Size(100, 20);
            this.txtBeneficiarioRut.TabIndex = 4;
            //
            // lblBeneficiarioTelefono
            //
            this.lblBeneficiarioTelefono.AutoSize = true;
            this.lblBeneficiarioTelefono.Location = new System.Drawing.Point(280, 138);
            this.lblBeneficiarioTelefono.Name = "lblBeneficiarioTelefono";
            this.lblBeneficiarioTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblBeneficiarioTelefono.TabIndex = 4;
            this.lblBeneficiarioTelefono.Text = "Teléfono:";
            //
            // txtBeneficiarioTelefono
            //
            this.txtBeneficiarioTelefono.Location = new System.Drawing.Point(342, 131);
            this.txtBeneficiarioTelefono.MaxLength = 20;
            this.txtBeneficiarioTelefono.Name = "txtBeneficiarioTelefono";
            this.txtBeneficiarioTelefono.Size = new System.Drawing.Size(150, 20);
            this.txtBeneficiarioTelefono.TabIndex = 5;
            //
            // lblMaestro
            //
            this.lblMaestro.AutoSize = true;
            this.lblMaestro.Location = new System.Drawing.Point(20, 168);
            this.lblMaestro.Name = "lblMaestro";
            this.lblMaestro.Size = new System.Drawing.Size(132, 13);
            this.lblMaestro.TabIndex = 4;
            this.lblMaestro.Text = "Maestro jefe de cuadrilla:";
            //
            // txtMaestro
            //
            this.txtMaestro.Location = new System.Drawing.Point(162, 165);
            this.txtMaestro.MaxLength = 100;
            this.txtMaestro.Name = "txtMaestro";
            this.txtMaestro.Size = new System.Drawing.Size(330, 20);
            this.txtMaestro.TabIndex = 6;
            // 
            // lblPresupuesto
            // 
            this.lblPresupuesto.AutoSize = true;
            this.lblPresupuesto.Location = new System.Drawing.Point(20, 198);
            this.lblPresupuesto.Name = "lblPresupuesto";
            this.lblPresupuesto.Size = new System.Drawing.Size(134, 13);
            this.lblPresupuesto.TabIndex = 5;
            this.lblPresupuesto.Text = "Presupuesto mat. ($ c/IVA):";
            // 
            // numPresupuesto
            // 
            this.numPresupuesto.Location = new System.Drawing.Point(162, 196);
            this.numPresupuesto.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numPresupuesto.Name = "numPresupuesto";
            this.numPresupuesto.Size = new System.Drawing.Size(140, 20);
            this.numPresupuesto.TabIndex = 7;
            this.numPresupuesto.ThousandsSeparator = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(20, 228);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Location = new System.Drawing.Point(162, 225);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(140, 21);
            this.cmbEstado.TabIndex = 8;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(294, 264);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 28);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(390, 264);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 28);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormObraEditar
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(504, 308);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblSuperficie);
            this.Controls.Add(this.numSuperficie);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblBeneficiario);
            this.Controls.Add(this.txtBeneficiario);
            this.Controls.Add(this.lblBeneficiarioRut);
            this.Controls.Add(this.txtBeneficiarioRut);
            this.Controls.Add(this.lblBeneficiarioTelefono);
            this.Controls.Add(this.txtBeneficiarioTelefono);
            this.Controls.Add(this.lblMaestro);
            this.Controls.Add(this.txtMaestro);
            this.Controls.Add(this.lblPresupuesto);
            this.Controls.Add(this.numPresupuesto);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormObraEditar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Obra";
            ((System.ComponentModel.ISupportInitialize)(this.numSuperficie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPresupuesto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblSuperficie;
        private System.Windows.Forms.NumericUpDown numSuperficie;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblBeneficiario;
        private System.Windows.Forms.TextBox txtBeneficiario;
        private System.Windows.Forms.Label lblBeneficiarioRut;
        private System.Windows.Forms.TextBox txtBeneficiarioRut;
        private System.Windows.Forms.Label lblBeneficiarioTelefono;
        private System.Windows.Forms.TextBox txtBeneficiarioTelefono;
        private System.Windows.Forms.Label lblMaestro;
        private System.Windows.Forms.TextBox txtMaestro;
        private System.Windows.Forms.Label lblPresupuesto;
        private System.Windows.Forms.NumericUpDown numPresupuesto;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
