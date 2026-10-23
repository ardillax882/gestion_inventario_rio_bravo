namespace gestion_inventario_rio_bravo.Views
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            System.Windows.Forms.DataGridViewCellStyle estiloNumero = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloMoneda = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCambiarPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMateriales = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAjuste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuObrasMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuObras = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEquipos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSolicitudesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNuevaSolicitud = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSolicitudes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLetraMas = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLetraPorcentaje = new System.Windows.Forms.ToolStripLabel();
            this.mnuLetraMenos = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLetra = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSesion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpInicio = new System.Windows.Forms.TableLayoutPanel();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblActualizado = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlTarjetas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTarjetaStock = new System.Windows.Forms.Button();
            this.btnTarjetaObras = new System.Windows.Forms.Button();
            this.btnTarjetaPendientes = new System.Windows.Forms.Button();
            this.btnTarjetaDespachar = new System.Windows.Forms.Button();
            this.btnTarjetaNueva = new System.Windows.Forms.Button();
            this.tlpListas = new System.Windows.Forms.TableLayoutPanel();
            this.grpStock = new System.Windows.Forms.GroupBox();
            this.dgvStockBajo = new System.Windows.Forms.DataGridView();
            this.colStockCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpObras = new System.Windows.Forms.GroupBox();
            this.dgvObras = new System.Windows.Forms.DataGridView();
            this.colObraNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObraEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObraCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpSolicitudes = new System.Windows.Forms.GroupBox();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.colSolFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolObra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tlpInicio.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.pnlTarjetas.SuspendLayout();
            this.tlpListas.SuspendLayout();
            this.grpStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockBajo)).BeginInit();
            this.grpObras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObras)).BeginInit();
            this.grpSolicitudes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.SuspendLayout();
            //
            // estilos de celdas numéricas
            //
            estiloNumero.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloNumero.Format = "#,0.##";
            estiloMoneda.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloMoneda.Format = "$ #,0";
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSistema,
            this.mnuInventario,
            this.mnuObrasMenu,
            this.mnuSolicitudesMenu,
            this.mnuAdministracion,
            this.mnuLetraMas,
            this.lblLetraPorcentaje,
            this.mnuLetraMenos,
            this.lblLetra});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 0;
            //
            // mnuSistema
            //
            this.mnuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCambiarPassword,
            this.mnuSeparador,
            this.mnuCerrarSesion,
            this.mnuSalir});
            this.mnuSistema.Name = "mnuSistema";
            this.mnuSistema.Size = new System.Drawing.Size(60, 20);
            this.mnuSistema.Text = "&Sistema";
            //
            // mnuCambiarPassword
            //
            this.mnuCambiarPassword.Name = "mnuCambiarPassword";
            this.mnuCambiarPassword.Size = new System.Drawing.Size(200, 22);
            this.mnuCambiarPassword.Text = "Cambiar mi contraseña";
            this.mnuCambiarPassword.Click += new System.EventHandler(this.mnuCambiarPassword_Click);
            //
            // mnuSeparador
            //
            this.mnuSeparador.Name = "mnuSeparador";
            this.mnuSeparador.Size = new System.Drawing.Size(197, 6);
            //
            // mnuCerrarSesion
            //
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(200, 22);
            this.mnuCerrarSesion.Text = "Cerrar sesión";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            //
            // mnuSalir
            //
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(200, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            //
            // mnuInventario
            //
            this.mnuInventario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMateriales,
            this.mnuAjuste});
            this.mnuInventario.Name = "mnuInventario";
            this.mnuInventario.Size = new System.Drawing.Size(72, 20);
            this.mnuInventario.Text = "&Inventario";
            //
            // mnuMateriales
            //
            this.mnuMateriales.Name = "mnuMateriales";
            this.mnuMateriales.Size = new System.Drawing.Size(220, 22);
            this.mnuMateriales.Text = "Materiales y stock";
            this.mnuMateriales.Click += new System.EventHandler(this.mnuMateriales_Click);
            //
            // mnuAjuste
            //
            this.mnuAjuste.Name = "mnuAjuste";
            this.mnuAjuste.Size = new System.Drawing.Size(220, 22);
            this.mnuAjuste.Text = "Ajuste de inventario";
            this.mnuAjuste.Click += new System.EventHandler(this.mnuAjuste_Click);
            //
            // mnuObrasMenu
            //
            this.mnuObrasMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuObras,
            this.mnuEquipos});
            this.mnuObrasMenu.Name = "mnuObrasMenu";
            this.mnuObrasMenu.Size = new System.Drawing.Size(50, 20);
            this.mnuObrasMenu.Text = "&Obras";
            //
            // mnuObras
            //
            this.mnuObras.Name = "mnuObras";
            this.mnuObras.Size = new System.Drawing.Size(220, 22);
            this.mnuObras.Text = "Lista de obras";
            this.mnuObras.Click += new System.EventHandler(this.mnuObras_Click);
            //
            // mnuEquipos
            //
            this.mnuEquipos.Name = "mnuEquipos";
            this.mnuEquipos.Size = new System.Drawing.Size(220, 22);
            this.mnuEquipos.Text = "Equipos prestados";
            this.mnuEquipos.Click += new System.EventHandler(this.mnuEquipos_Click);
            //
            // mnuSolicitudesMenu
            //
            this.mnuSolicitudesMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNuevaSolicitud,
            this.mnuSolicitudes});
            this.mnuSolicitudesMenu.Name = "mnuSolicitudesMenu";
            this.mnuSolicitudesMenu.Size = new System.Drawing.Size(78, 20);
            this.mnuSolicitudesMenu.Text = "S&olicitudes";
            //
            // mnuNuevaSolicitud
            //
            this.mnuNuevaSolicitud.Name = "mnuNuevaSolicitud";
            this.mnuNuevaSolicitud.Size = new System.Drawing.Size(220, 22);
            this.mnuNuevaSolicitud.Text = "Nueva solicitud (planilla)";
            this.mnuNuevaSolicitud.Click += new System.EventHandler(this.mnuNuevaSolicitud_Click);
            //
            // mnuSolicitudes
            //
            this.mnuSolicitudes.Name = "mnuSolicitudes";
            this.mnuSolicitudes.Size = new System.Drawing.Size(220, 22);
            this.mnuSolicitudes.Text = "Ver solicitudes y despachos";
            this.mnuSolicitudes.Click += new System.EventHandler(this.mnuSolicitudes_Click);
            //
            // mnuAdministracion
            //
            this.mnuAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsuarios});
            this.mnuAdministracion.Name = "mnuAdministracion";
            this.mnuAdministracion.Size = new System.Drawing.Size(100, 20);
            this.mnuAdministracion.Text = "&Administración";
            //
            // mnuUsuarios
            //
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(180, 22);
            this.mnuUsuarios.Text = "Usuarios";
            this.mnuUsuarios.Click += new System.EventHandler(this.mnuUsuarios_Click);
            //
            // mnuLetraMas  (los cuatro van a la derecha; con Alignment Right el primero queda en el extremo)
            //
            this.mnuLetraMas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuLetraMas.Name = "mnuLetraMas";
            this.mnuLetraMas.Size = new System.Drawing.Size(34, 20);
            this.mnuLetraMas.Text = "A+";
            this.mnuLetraMas.ToolTipText = "Agrandar la letra (Ctrl +)";
            this.mnuLetraMas.Click += new System.EventHandler(this.mnuLetraMas_Click);
            //
            // lblLetraPorcentaje
            //
            this.lblLetraPorcentaje.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblLetraPorcentaje.Name = "lblLetraPorcentaje";
            this.lblLetraPorcentaje.Size = new System.Drawing.Size(35, 17);
            this.lblLetraPorcentaje.Text = "100 %";
            //
            // mnuLetraMenos
            //
            this.mnuLetraMenos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuLetraMenos.Name = "mnuLetraMenos";
            this.mnuLetraMenos.Size = new System.Drawing.Size(31, 20);
            this.mnuLetraMenos.Text = "A−";
            this.mnuLetraMenos.ToolTipText = "Achicar la letra (Ctrl −)";
            this.mnuLetraMenos.Click += new System.EventHandler(this.mnuLetraMenos_Click);
            //
            // lblLetra
            //
            this.lblLetra.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblLetra.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblLetra.Name = "lblLetra";
            this.lblLetra.Size = new System.Drawing.Size(92, 17);
            this.lblLetra.Text = "Tamaño de letra:";
            //
            // statusStrip1
            //
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSesion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 618);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1024, 22);
            this.statusStrip1.TabIndex = 2;
            //
            // lblSesion
            //
            this.lblSesion.Name = "lblSesion";
            this.lblSesion.Size = new System.Drawing.Size(0, 17);
            //
            // tlpInicio
            //
            this.tlpInicio.ColumnCount = 1;
            this.tlpInicio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInicio.Controls.Add(this.pnlEncabezado, 0, 0);
            this.tlpInicio.Controls.Add(this.pnlTarjetas, 0, 1);
            this.tlpInicio.Controls.Add(this.tlpListas, 0, 2);
            this.tlpInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInicio.Name = "tlpInicio";
            this.tlpInicio.Padding = new System.Windows.Forms.Padding(8);
            this.tlpInicio.RowCount = 3;
            this.tlpInicio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpInicio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpInicio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInicio.TabIndex = 1;
            //
            // pnlEncabezado
            //
            this.pnlEncabezado.Controls.Add(this.lblBienvenida);
            this.pnlEncabezado.Controls.Add(this.lblActualizado);
            this.pnlEncabezado.Controls.Add(this.btnActualizar);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.TabIndex = 0;
            //
            // lblBienvenida
            //
            this.lblBienvenida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblActualizado
            //
            this.lblActualizado.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblActualizado.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblActualizado.Name = "lblActualizado";
            this.lblActualizado.Size = new System.Drawing.Size(120, 44);
            this.lblActualizado.TabIndex = 1;
            this.lblActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnActualizar
            //
            this.btnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 44);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            //
            // pnlTarjetas
            //
            this.pnlTarjetas.Controls.Add(this.btnTarjetaStock);
            this.pnlTarjetas.Controls.Add(this.btnTarjetaObras);
            this.pnlTarjetas.Controls.Add(this.btnTarjetaPendientes);
            this.pnlTarjetas.Controls.Add(this.btnTarjetaDespachar);
            this.pnlTarjetas.Controls.Add(this.btnTarjetaNueva);
            this.pnlTarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTarjetas.Name = "pnlTarjetas";
            this.pnlTarjetas.TabIndex = 1;
            //
            // btnTarjetaStock
            //
            this.btnTarjetaStock.BackColor = System.Drawing.Color.White;
            this.btnTarjetaStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjetaStock.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTarjetaStock.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.btnTarjetaStock.Name = "btnTarjetaStock";
            this.btnTarjetaStock.Size = new System.Drawing.Size(220, 84);
            this.btnTarjetaStock.TabIndex = 0;
            this.btnTarjetaStock.UseVisualStyleBackColor = false;
            this.btnTarjetaStock.Click += new System.EventHandler(this.btnTarjetaStock_Click);
            //
            // btnTarjetaObras
            //
            this.btnTarjetaObras.BackColor = System.Drawing.Color.White;
            this.btnTarjetaObras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjetaObras.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTarjetaObras.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.btnTarjetaObras.Name = "btnTarjetaObras";
            this.btnTarjetaObras.Size = new System.Drawing.Size(220, 84);
            this.btnTarjetaObras.TabIndex = 1;
            this.btnTarjetaObras.UseVisualStyleBackColor = false;
            this.btnTarjetaObras.Click += new System.EventHandler(this.mnuObras_Click);
            //
            // btnTarjetaPendientes
            //
            this.btnTarjetaPendientes.BackColor = System.Drawing.Color.White;
            this.btnTarjetaPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjetaPendientes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTarjetaPendientes.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.btnTarjetaPendientes.Name = "btnTarjetaPendientes";
            this.btnTarjetaPendientes.Size = new System.Drawing.Size(220, 84);
            this.btnTarjetaPendientes.TabIndex = 2;
            this.btnTarjetaPendientes.UseVisualStyleBackColor = false;
            this.btnTarjetaPendientes.Click += new System.EventHandler(this.btnTarjetaPendientes_Click);
            //
            // btnTarjetaDespachar
            //
            this.btnTarjetaDespachar.BackColor = System.Drawing.Color.White;
            this.btnTarjetaDespachar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjetaDespachar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTarjetaDespachar.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.btnTarjetaDespachar.Name = "btnTarjetaDespachar";
            this.btnTarjetaDespachar.Size = new System.Drawing.Size(220, 84);
            this.btnTarjetaDespachar.TabIndex = 3;
            this.btnTarjetaDespachar.UseVisualStyleBackColor = false;
            this.btnTarjetaDespachar.Click += new System.EventHandler(this.btnTarjetaDespachar_Click);
            //
            // btnTarjetaNueva
            //
            this.btnTarjetaNueva.BackColor = System.Drawing.Color.Honeydew;
            this.btnTarjetaNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjetaNueva.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTarjetaNueva.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.btnTarjetaNueva.Name = "btnTarjetaNueva";
            this.btnTarjetaNueva.Size = new System.Drawing.Size(220, 84);
            this.btnTarjetaNueva.TabIndex = 4;
            this.btnTarjetaNueva.Text = "+ Nueva solicitud\n(planilla de materiales)";
            this.btnTarjetaNueva.UseVisualStyleBackColor = false;
            this.btnTarjetaNueva.Click += new System.EventHandler(this.mnuNuevaSolicitud_Click);
            //
            // tlpListas
            //
            this.tlpListas.ColumnCount = 3;
            this.tlpListas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpListas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpListas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpListas.Controls.Add(this.grpStock, 0, 0);
            this.tlpListas.Controls.Add(this.grpObras, 1, 0);
            this.tlpListas.Controls.Add(this.grpSolicitudes, 2, 0);
            this.tlpListas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpListas.Name = "tlpListas";
            this.tlpListas.RowCount = 1;
            this.tlpListas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpListas.TabIndex = 2;
            //
            // grpStock
            //
            this.grpStock.Controls.Add(this.dgvStockBajo);
            this.grpStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStock.Name = "grpStock";
            this.grpStock.Padding = new System.Windows.Forms.Padding(6);
            this.grpStock.TabIndex = 0;
            this.grpStock.TabStop = false;
            this.grpStock.Text = "Stock actual de materiales (doble clic: movimientos)";
            //
            // dgvStockBajo
            //
            this.dgvStockBajo.AllowUserToAddRows = false;
            this.dgvStockBajo.AllowUserToDeleteRows = false;
            this.dgvStockBajo.AllowUserToResizeColumns = false;
            this.dgvStockBajo.AllowUserToResizeRows = false;
            this.dgvStockBajo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockBajo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvStockBajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockBajo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStockCodigo,
            this.colStockNombre,
            this.colStockActual,
            this.colStockMinimo,
            this.colStockUnidad});
            this.dgvStockBajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockBajo.MultiSelect = false;
            this.dgvStockBajo.Name = "dgvStockBajo";
            this.dgvStockBajo.ReadOnly = true;
            this.dgvStockBajo.RowHeadersVisible = false;
            this.dgvStockBajo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockBajo.TabIndex = 0;
            this.dgvStockBajo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockBajo_CellDoubleClick);
            this.dgvStockBajo.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvStockBajo_RowPrePaint);
            //
            // colStockCodigo
            //
            this.colStockCodigo.DataPropertyName = "Codigo";
            this.colStockCodigo.FillWeight = 55F;
            this.colStockCodigo.HeaderText = "Código";
            this.colStockCodigo.Name = "colStockCodigo";
            this.colStockCodigo.ReadOnly = true;
            //
            // colStockNombre
            //
            this.colStockNombre.DataPropertyName = "Nombre";
            this.colStockNombre.HeaderText = "Material";
            this.colStockNombre.Name = "colStockNombre";
            this.colStockNombre.ReadOnly = true;
            //
            // colStockActual
            //
            this.colStockActual.DataPropertyName = "StockActual";
            this.colStockActual.DefaultCellStyle = estiloNumero;
            this.colStockActual.FillWeight = 45F;
            this.colStockActual.HeaderText = "Stock";
            this.colStockActual.Name = "colStockActual";
            this.colStockActual.ReadOnly = true;
            //
            // colStockMinimo
            //
            this.colStockMinimo.DataPropertyName = "StockMinimo";
            this.colStockMinimo.DefaultCellStyle = estiloNumero;
            this.colStockMinimo.FillWeight = 45F;
            this.colStockMinimo.HeaderText = "Mínimo";
            this.colStockMinimo.Name = "colStockMinimo";
            this.colStockMinimo.ReadOnly = true;
            //
            // colStockUnidad
            //
            this.colStockUnidad.DataPropertyName = "UnidadMedida";
            this.colStockUnidad.FillWeight = 35F;
            this.colStockUnidad.HeaderText = "Unid.";
            this.colStockUnidad.Name = "colStockUnidad";
            this.colStockUnidad.ReadOnly = true;
            //
            // grpObras
            //
            this.grpObras.Controls.Add(this.dgvObras);
            this.grpObras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpObras.Name = "grpObras";
            this.grpObras.Padding = new System.Windows.Forms.Padding(6);
            this.grpObras.TabIndex = 1;
            this.grpObras.TabStop = false;
            this.grpObras.Text = "Obras activas (doble clic: sus solicitudes)";
            //
            // dgvObras
            //
            this.dgvObras.AllowUserToAddRows = false;
            this.dgvObras.AllowUserToDeleteRows = false;
            this.dgvObras.AllowUserToResizeColumns = false;
            this.dgvObras.AllowUserToResizeRows = false;
            this.dgvObras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvObras.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvObras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colObraNombre,
            this.colObraEstado,
            this.colObraCosto});
            this.dgvObras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObras.MultiSelect = false;
            this.dgvObras.Name = "dgvObras";
            this.dgvObras.ReadOnly = true;
            this.dgvObras.RowHeadersVisible = false;
            this.dgvObras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObras.TabIndex = 0;
            this.dgvObras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObras_CellDoubleClick);
            //
            // colObraNombre
            //
            this.colObraNombre.DataPropertyName = "NombreObra";
            this.colObraNombre.HeaderText = "Obra";
            this.colObraNombre.Name = "colObraNombre";
            this.colObraNombre.ReadOnly = true;
            //
            // colObraEstado
            //
            this.colObraEstado.DataPropertyName = "EstadoTexto";
            this.colObraEstado.FillWeight = 60F;
            this.colObraEstado.HeaderText = "Estado";
            this.colObraEstado.Name = "colObraEstado";
            this.colObraEstado.ReadOnly = true;
            //
            // colObraCosto
            //
            this.colObraCosto.DataPropertyName = "CostoDespachado";
            this.colObraCosto.DefaultCellStyle = estiloMoneda;
            this.colObraCosto.FillWeight = 60F;
            this.colObraCosto.HeaderText = "Despachado";
            this.colObraCosto.Name = "colObraCosto";
            this.colObraCosto.ReadOnly = true;
            //
            // grpSolicitudes
            //
            this.grpSolicitudes.Controls.Add(this.dgvSolicitudes);
            this.grpSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSolicitudes.Name = "grpSolicitudes";
            this.grpSolicitudes.Padding = new System.Windows.Forms.Padding(6);
            this.grpSolicitudes.TabIndex = 2;
            this.grpSolicitudes.TabStop = false;
            this.grpSolicitudes.Text = "Solicitudes abiertas (doble clic: abrir planilla)";
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
            this.colSolFolio,
            this.colSolObra,
            this.colSolEstado,
            this.colSolSaldo});
            this.dgvSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSolicitudes.MultiSelect = false;
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.ReadOnly = true;
            this.dgvSolicitudes.RowHeadersVisible = false;
            this.dgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitudes.TabIndex = 0;
            this.dgvSolicitudes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolicitudes_CellDoubleClick);
            //
            // colSolFolio
            //
            this.colSolFolio.DataPropertyName = "Folio";
            this.colSolFolio.FillWeight = 55F;
            this.colSolFolio.HeaderText = "Folio";
            this.colSolFolio.Name = "colSolFolio";
            this.colSolFolio.ReadOnly = true;
            //
            // colSolObra
            //
            this.colSolObra.DataPropertyName = "ObraNombre";
            this.colSolObra.HeaderText = "Obra";
            this.colSolObra.Name = "colSolObra";
            this.colSolObra.ReadOnly = true;
            //
            // colSolEstado
            //
            this.colSolEstado.DataPropertyName = "EstadoTexto";
            this.colSolEstado.FillWeight = 65F;
            this.colSolEstado.HeaderText = "Estado";
            this.colSolEstado.Name = "colSolEstado";
            this.colSolEstado.ReadOnly = true;
            //
            // colSolSaldo
            //
            this.colSolSaldo.DataPropertyName = "SaldoTotal";
            this.colSolSaldo.DefaultCellStyle = estiloNumero;
            this.colSolSaldo.FillWeight = 45F;
            this.colSolSaldo.HeaderText = "Saldo";
            this.colSolSaldo.Name = "colSolSaldo";
            this.colSolSaldo.ReadOnly = true;
            //
            // FormPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.tlpInicio);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Inventario Río Bravo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tlpInicio.ResumeLayout(false);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlTarjetas.ResumeLayout(false);
            this.tlpListas.ResumeLayout(false);
            this.grpStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockBajo)).EndInit();
            this.grpObras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObras)).EndInit();
            this.grpSolicitudes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSistema;
        private System.Windows.Forms.ToolStripMenuItem mnuCambiarPassword;
        private System.Windows.Forms.ToolStripSeparator mnuSeparador;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuInventario;
        private System.Windows.Forms.ToolStripMenuItem mnuMateriales;
        private System.Windows.Forms.ToolStripMenuItem mnuAjuste;
        private System.Windows.Forms.ToolStripMenuItem mnuObrasMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuObras;
        private System.Windows.Forms.ToolStripMenuItem mnuEquipos;
        private System.Windows.Forms.ToolStripMenuItem mnuSolicitudesMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuNuevaSolicitud;
        private System.Windows.Forms.ToolStripMenuItem mnuSolicitudes;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministracion;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuLetraMas;
        private System.Windows.Forms.ToolStripLabel lblLetraPorcentaje;
        private System.Windows.Forms.ToolStripMenuItem mnuLetraMenos;
        private System.Windows.Forms.ToolStripLabel lblLetra;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblSesion;
        private System.Windows.Forms.TableLayoutPanel tlpInicio;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblActualizado;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.FlowLayoutPanel pnlTarjetas;
        private System.Windows.Forms.Button btnTarjetaStock;
        private System.Windows.Forms.Button btnTarjetaObras;
        private System.Windows.Forms.Button btnTarjetaPendientes;
        private System.Windows.Forms.Button btnTarjetaDespachar;
        private System.Windows.Forms.Button btnTarjetaNueva;
        private System.Windows.Forms.TableLayoutPanel tlpListas;
        private System.Windows.Forms.GroupBox grpStock;
        private System.Windows.Forms.DataGridView dgvStockBajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockUnidad;
        private System.Windows.Forms.GroupBox grpObras;
        private System.Windows.Forms.DataGridView dgvObras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObraNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObraEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObraCosto;
        private System.Windows.Forms.GroupBox grpSolicitudes;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolSaldo;
    }
}
