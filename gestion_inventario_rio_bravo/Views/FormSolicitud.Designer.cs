namespace gestion_inventario_rio_bravo.Views
{
    partial class FormSolicitud
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && fuenteCategoria != null) fuenteCategoria.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle estiloNumero = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.lblObra = new System.Windows.Forms.Label();
            this.cmbObra = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblDatosObra = new System.Windows.Forms.Label();
            this.lblEquipos = new System.Windows.Forms.Label();
            this.chkTrompo = new System.Windows.Forms.CheckBox();
            this.chkPlaca = new System.Windows.Forms.CheckBox();
            this.chkBano = new System.Windows.Forms.CheckBox();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.lblRechazo = new System.Windows.Forms.Label();
            this.pnlAgregar = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.grpDespachos = new System.Windows.Forms.GroupBox();
            this.lstDespachos = new System.Windows.Forms.ListBox();
            this.btnComprobante = new System.Windows.Forms.Button();
            this.dgvLineas = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolicitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDespachado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnDespachar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            this.pnlAgregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.grpDespachos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineas)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // estiloNumero
            //
            estiloNumero.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloNumero.Format = "#,0.##";
            //
            // pnlEncabezado
            //
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblFolio);
            this.pnlEncabezado.Controls.Add(this.lblObra);
            this.pnlEncabezado.Controls.Add(this.cmbObra);
            this.pnlEncabezado.Controls.Add(this.lblEstado);
            this.pnlEncabezado.Controls.Add(this.lblDatosObra);
            this.pnlEncabezado.Controls.Add(this.lblEquipos);
            this.pnlEncabezado.Controls.Add(this.chkTrompo);
            this.pnlEncabezado.Controls.Add(this.chkPlaca);
            this.pnlEncabezado.Controls.Add(this.chkBano);
            this.pnlEncabezado.Controls.Add(this.lblRegistro);
            this.pnlEncabezado.Controls.Add(this.lblRechazo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1100, 140);
            this.pnlEncabezado.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(10, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "RÍO BRAVO · SALIDA DE MATERIALES";
            //
            // lblFolio
            //
            this.lblFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFolio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFolio.Location = new System.Drawing.Point(830, 8);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(260, 26);
            this.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblObra
            //
            this.lblObra.AutoSize = true;
            this.lblObra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblObra.Location = new System.Drawing.Point(12, 48);
            this.lblObra.Name = "lblObra";
            this.lblObra.Text = "Obra:";
            //
            // cmbObra
            //
            this.cmbObra.DisplayMember = "NombreObra";
            this.cmbObra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObra.Location = new System.Drawing.Point(60, 45);
            this.cmbObra.Name = "cmbObra";
            this.cmbObra.Size = new System.Drawing.Size(320, 21);
            this.cmbObra.TabIndex = 0;
            this.cmbObra.ValueMember = "IdObra";
            this.cmbObra.SelectedIndexChanged += new System.EventHandler(this.Encabezado_Changed);
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(400, 45);
            this.lblEstado.Name = "lblEstado";
            //
            // lblDatosObra
            //
            this.lblDatosObra.AutoSize = true;
            this.lblDatosObra.Location = new System.Drawing.Point(12, 76);
            this.lblDatosObra.Name = "lblDatosObra";
            //
            // lblEquipos
            //
            this.lblEquipos.AutoSize = true;
            this.lblEquipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEquipos.Location = new System.Drawing.Point(12, 101);
            this.lblEquipos.Name = "lblEquipos";
            this.lblEquipos.Text = "Equipos:";
            //
            // chkTrompo
            //
            this.chkTrompo.AutoSize = true;
            this.chkTrompo.Location = new System.Drawing.Point(72, 100);
            this.chkTrompo.Name = "chkTrompo";
            this.chkTrompo.TabIndex = 1;
            this.chkTrompo.Text = "Trompo";
            this.chkTrompo.UseVisualStyleBackColor = true;
            this.chkTrompo.CheckedChanged += new System.EventHandler(this.Encabezado_Changed);
            //
            // chkPlaca
            //
            this.chkPlaca.AutoSize = true;
            this.chkPlaca.Location = new System.Drawing.Point(142, 100);
            this.chkPlaca.Name = "chkPlaca";
            this.chkPlaca.TabIndex = 2;
            this.chkPlaca.Text = "Placa";
            this.chkPlaca.UseVisualStyleBackColor = true;
            this.chkPlaca.CheckedChanged += new System.EventHandler(this.Encabezado_Changed);
            //
            // chkBano
            //
            this.chkBano.AutoSize = true;
            this.chkBano.Location = new System.Drawing.Point(204, 100);
            this.chkBano.Name = "chkBano";
            this.chkBano.TabIndex = 3;
            this.chkBano.Text = "Baño";
            this.chkBano.UseVisualStyleBackColor = true;
            this.chkBano.CheckedChanged += new System.EventHandler(this.Encabezado_Changed);
            //
            // lblRegistro
            //
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Location = new System.Drawing.Point(290, 101);
            this.lblRegistro.Name = "lblRegistro";
            //
            // lblRechazo
            //
            this.lblRechazo.AutoSize = true;
            this.lblRechazo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRechazo.Location = new System.Drawing.Point(12, 122);
            this.lblRechazo.Name = "lblRechazo";
            //
            // pnlAgregar
            //
            this.pnlAgregar.BackColor = System.Drawing.Color.Honeydew;
            this.pnlAgregar.Controls.Add(this.lblMaterial);
            this.pnlAgregar.Controls.Add(this.cmbMaterial);
            this.pnlAgregar.Controls.Add(this.lblCategoria);
            this.pnlAgregar.Controls.Add(this.cmbCategoria);
            this.pnlAgregar.Controls.Add(this.lblCantidad);
            this.pnlAgregar.Controls.Add(this.numCantidad);
            this.pnlAgregar.Controls.Add(this.lblUnidad);
            this.pnlAgregar.Controls.Add(this.btnAgregar);
            this.pnlAgregar.Controls.Add(this.btnQuitar);
            this.pnlAgregar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAgregar.Name = "pnlAgregar";
            this.pnlAgregar.Padding = new System.Windows.Forms.Padding(6);
            this.pnlAgregar.Size = new System.Drawing.Size(1100, 40);
            this.pnlAgregar.TabIndex = 1;
            this.pnlAgregar.AutoSize = true;
            //
            // lblMaterial
            //
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Text = "Material (código o nombre):";
            //
            // cmbMaterial
            //
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(260, 21);
            this.cmbMaterial.TabIndex = 0;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            //
            // lblCategoria
            //
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(10, 8, 3, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Text = "Sección:";
            //
            // cmbCategoria
            //
            this.cmbCategoria.DisplayMember = "Nombre";
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(150, 21);
            this.cmbCategoria.TabIndex = 1;
            this.cmbCategoria.ValueMember = "IdCategoria";
            //
            // lblCantidad
            //
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(10, 8, 3, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Text = "Cantidad:";
            //
            // numCantidad
            //
            this.numCantidad.DecimalPlaces = 2;
            this.numCantidad.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.numCantidad.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(90, 20);
            this.numCantidad.TabIndex = 2;
            this.numCantidad.ThousandsSeparator = true;
            //
            // lblUnidad
            //
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblUnidad.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblUnidad.MinimumSize = new System.Drawing.Size(90, 0);
            this.lblUnidad.Name = "lblUnidad";
            //
            // btnAgregar
            //
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(80, 26);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            //
            // btnQuitar
            //
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(90, 26);
            this.btnQuitar.TabIndex = 4;
            this.btnQuitar.Text = "Quitar línea";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            //
            // grpDespachos
            //
            this.grpDespachos.Controls.Add(this.lstDespachos);
            this.grpDespachos.Controls.Add(this.btnComprobante);
            this.grpDespachos.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpDespachos.Name = "grpDespachos";
            this.grpDespachos.Padding = new System.Windows.Forms.Padding(6);
            this.grpDespachos.Size = new System.Drawing.Size(290, 300);
            this.grpDespachos.TabIndex = 3;
            this.grpDespachos.TabStop = false;
            this.grpDespachos.Text = "Entregas (despachos)";
            //
            // lstDespachos
            //
            this.lstDespachos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDespachos.IntegralHeight = false;
            this.lstDespachos.Name = "lstDespachos";
            this.lstDespachos.TabIndex = 0;
            //
            // btnComprobante
            //
            this.btnComprobante.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.Size = new System.Drawing.Size(278, 28);
            this.btnComprobante.TabIndex = 1;
            this.btnComprobante.Text = "Imprimir comprobante de la entrega";
            this.btnComprobante.UseVisualStyleBackColor = true;
            this.btnComprobante.Click += new System.EventHandler(this.btnComprobante_Click);
            //
            // dgvLineas
            //
            this.dgvLineas.AllowUserToAddRows = false;
            this.dgvLineas.AllowUserToDeleteRows = false;
            this.dgvLineas.AllowUserToResizeRows = false;
            this.dgvLineas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLineas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colMaterial,
            this.colUnidad,
            this.colSolicitado,
            this.colDespachado,
            this.colSaldo,
            this.colStock});
            this.dgvLineas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLineas.MultiSelect = false;
            this.dgvLineas.Name = "dgvLineas";
            this.dgvLineas.ReadOnly = true;
            this.dgvLineas.RowHeadersVisible = false;
            this.dgvLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLineas.TabIndex = 2;
            this.dgvLineas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineas_CellDoubleClick);
            this.dgvLineas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLineas_KeyDown);
            //
            // colCodigo
            //
            this.colCodigo.FillWeight = 50F;
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colMaterial
            //
            this.colMaterial.FillWeight = 180F;
            this.colMaterial.HeaderText = "Material";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colUnidad
            //
            this.colUnidad.FillWeight = 40F;
            this.colUnidad.HeaderText = "Unidad";
            this.colUnidad.Name = "colUnidad";
            this.colUnidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colSolicitado
            //
            this.colSolicitado.DefaultCellStyle = estiloNumero;
            this.colSolicitado.FillWeight = 50F;
            this.colSolicitado.HeaderText = "Solicitado";
            this.colSolicitado.Name = "colSolicitado";
            this.colSolicitado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colDespachado
            //
            this.colDespachado.DefaultCellStyle = estiloNumero;
            this.colDespachado.FillWeight = 50F;
            this.colDespachado.HeaderText = "Entregado";
            this.colDespachado.Name = "colDespachado";
            this.colDespachado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colSaldo
            //
            this.colSaldo.DefaultCellStyle = estiloNumero;
            this.colSaldo.FillWeight = 50F;
            this.colSaldo.HeaderText = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colStock
            //
            this.colStock.DefaultCellStyle = estiloNumero;
            this.colStock.FillWeight = 50F;
            this.colStock.HeaderText = "Stock bodega";
            this.colStock.Name = "colStock";
            this.colStock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // pnlPie
            //
            this.pnlPie.Controls.Add(this.lblResumen);
            this.pnlPie.Controls.Add(this.lblObservaciones);
            this.pnlPie.Controls.Add(this.txtObservaciones);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1100, 70);
            this.pnlPie.TabIndex = 4;
            //
            // lblResumen
            //
            this.lblResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResumen.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblResumen.Size = new System.Drawing.Size(1100, 20);
            this.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblObservaciones
            //
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(10, 26);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Text = "Observaciones:";
            //
            // txtObservaciones
            //
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.Location = new System.Drawing.Point(100, 23);
            this.txtObservaciones.MaxLength = 300;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(988, 40);
            this.txtObservaciones.TabIndex = 0;
            this.txtObservaciones.TextChanged += new System.EventHandler(this.Encabezado_Changed);
            //
            // pnlBotones
            //
            this.pnlBotones.Controls.Add(this.btnCerrar);
            this.pnlBotones.Controls.Add(this.btnImprimir);
            this.pnlBotones.Controls.Add(this.btnDespachar);
            this.pnlBotones.Controls.Add(this.btnRechazar);
            this.pnlBotones.Controls.Add(this.btnAprobar);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(6);
            this.pnlBotones.Size = new System.Drawing.Size(1100, 46);
            this.pnlBotones.TabIndex = 5;
            //
            // btnCerrar
            //
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 28);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            //
            // btnImprimir
            //
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 28);
            this.btnImprimir.Text = "Imprimir planilla";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            //
            // btnDespachar
            //
            this.btnDespachar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDespachar.Name = "btnDespachar";
            this.btnDespachar.Size = new System.Drawing.Size(130, 28);
            this.btnDespachar.Text = "Nuevo despacho";
            this.btnDespachar.UseVisualStyleBackColor = true;
            this.btnDespachar.Click += new System.EventHandler(this.btnDespachar_Click);
            //
            // btnRechazar
            //
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(90, 28);
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            //
            // btnAprobar
            //
            this.btnAprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(90, 28);
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            //
            // btnGuardar
            //
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 28);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // FormSolicitud
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.dgvLineas);
            this.Controls.Add(this.grpDespachos);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlAgregar);
            this.Controls.Add(this.pnlEncabezado);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "FormSolicitud";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Salida de materiales";
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlAgregar.ResumeLayout(false);
            this.pnlAgregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.grpDespachos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineas)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label lblObra;
        private System.Windows.Forms.ComboBox cmbObra;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblDatosObra;
        private System.Windows.Forms.Label lblEquipos;
        private System.Windows.Forms.CheckBox chkTrompo;
        private System.Windows.Forms.CheckBox chkPlaca;
        private System.Windows.Forms.CheckBox chkBano;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Label lblRechazo;
        private System.Windows.Forms.FlowLayoutPanel pnlAgregar;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.GroupBox grpDespachos;
        private System.Windows.Forms.ListBox lstDespachos;
        private System.Windows.Forms.Button btnComprobante;
        private System.Windows.Forms.DataGridView dgvLineas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolicitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDespachado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnDespachar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
