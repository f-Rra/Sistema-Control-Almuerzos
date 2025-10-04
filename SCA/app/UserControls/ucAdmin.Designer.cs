namespace app.UserControls
{
    partial class ucAdmin
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnEmpleados = new ReaLTaiizor.Controls.Button();
            this.btnEmpresas = new ReaLTaiizor.Controls.Button();
            this.btnEstadisticas = new ReaLTaiizor.Controls.Button();
            this.btnConfiguracion = new ReaLTaiizor.Controls.Button();
            this.pnlEmpleados = new System.Windows.Forms.Panel();
            this.gbListaEmpleados = new System.Windows.Forms.GroupBox();
            this.lblTotalEmpleados = new System.Windows.Forms.Label();
            this.txtBuscarEmpleado = new System.Windows.Forms.TextBox();
            this.cbFiltroEmpresa = new System.Windows.Forms.ComboBox();
            this.btnNuevoEmpleado = new ReaLTaiizor.Controls.Button();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.gbEmpleadoDetalle = new System.Windows.Forms.GroupBox();
            this.btnEliminarEmpleado = new ReaLTaiizor.Controls.Button();
            this.btnGuardarEmpleado = new ReaLTaiizor.Controls.Button();
            this.lblCredencial = new System.Windows.Forms.Label();
            this.btnCancelarEmpleado = new ReaLTaiizor.Controls.Button();
            this.btnVerificarCredencial = new ReaLTaiizor.Controls.Button();
            this.txtCredencial = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.cbEmpresaEmpleado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.rbActivoEmpleado = new System.Windows.Forms.RadioButton();
            this.rbInactivoEmpleado = new System.Windows.Forms.RadioButton();
            this.pnlEmpresas = new System.Windows.Forms.Panel();
            this.pnlEstadisticas = new System.Windows.Forms.Panel();
            this.pnlConfiguracion = new System.Windows.Forms.Panel();
            this.pnlBotones.SuspendLayout();
            this.pnlEmpleados.SuspendLayout();
            this.gbListaEmpleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.gbEmpleadoDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.pnlBotones.Controls.Add(this.btnEmpleados);
            this.pnlBotones.Controls.Add(this.btnEmpresas);
            this.pnlBotones.Controls.Add(this.btnEstadisticas);
            this.pnlBotones.Controls.Add(this.btnConfiguracion);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(0, 0);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(1155, 70);
            this.pnlBotones.TabIndex = 0;
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEmpleados.BackColor = System.Drawing.Color.Transparent;
            this.btnEmpleados.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmpleados.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEmpleados.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEmpleados.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEmpleados.Image = null;
            this.btnEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEmpleados.Location = new System.Drawing.Point(277, 20);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEmpleados.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEmpleados.Size = new System.Drawing.Size(150, 40);
            this.btnEmpleados.TabIndex = 0;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnEmpresas
            // 
            this.btnEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEmpresas.BackColor = System.Drawing.Color.Transparent;
            this.btnEmpresas.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEmpresas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmpresas.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEmpresas.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEmpresas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEmpresas.Image = null;
            this.btnEmpresas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpresas.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEmpresas.Location = new System.Drawing.Point(442, 20);
            this.btnEmpresas.Name = "btnEmpresas";
            this.btnEmpresas.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEmpresas.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEmpresas.Size = new System.Drawing.Size(150, 40);
            this.btnEmpresas.TabIndex = 1;
            this.btnEmpresas.Text = "Empresas";
            this.btnEmpresas.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEmpresas.Click += new System.EventHandler(this.btnEmpresas_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEstadisticas.BackColor = System.Drawing.Color.Transparent;
            this.btnEstadisticas.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEstadisticas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadisticas.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEstadisticas.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEstadisticas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEstadisticas.Image = null;
            this.btnEstadisticas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadisticas.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEstadisticas.Location = new System.Drawing.Point(607, 20);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEstadisticas.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEstadisticas.Size = new System.Drawing.Size(150, 40);
            this.btnEstadisticas.TabIndex = 2;
            this.btnEstadisticas.Text = "Estadísticas";
            this.btnEstadisticas.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConfiguracion.BackColor = System.Drawing.Color.Transparent;
            this.btnConfiguracion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracion.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnConfiguracion.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnConfiguracion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfiguracion.Image = null;
            this.btnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnConfiguracion.Location = new System.Drawing.Point(772, 20);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnConfiguracion.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnConfiguracion.Size = new System.Drawing.Size(150, 40);
            this.btnConfiguracion.TabIndex = 3;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // pnlEmpleados
            // 
            this.pnlEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEmpleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.pnlEmpleados.Controls.Add(this.gbListaEmpleados);
            this.pnlEmpleados.Controls.Add(this.gbEmpleadoDetalle);
            this.pnlEmpleados.Location = new System.Drawing.Point(0, 70);
            this.pnlEmpleados.Name = "pnlEmpleados";
            this.pnlEmpleados.Padding = new System.Windows.Forms.Padding(15);
            this.pnlEmpleados.Size = new System.Drawing.Size(1155, 440);
            this.pnlEmpleados.TabIndex = 1;
            // 
            // gbListaEmpleados
            // 
            this.gbListaEmpleados.Controls.Add(this.lblTotalEmpleados);
            this.gbListaEmpleados.Controls.Add(this.txtBuscarEmpleado);
            this.gbListaEmpleados.Controls.Add(this.cbFiltroEmpresa);
            this.gbListaEmpleados.Controls.Add(this.btnNuevoEmpleado);
            this.gbListaEmpleados.Controls.Add(this.dgvEmpleados);
            this.gbListaEmpleados.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbListaEmpleados.Location = new System.Drawing.Point(15, 15);
            this.gbListaEmpleados.Name = "gbListaEmpleados";
            this.gbListaEmpleados.Padding = new System.Windows.Forms.Padding(20);
            this.gbListaEmpleados.Size = new System.Drawing.Size(560, 410);
            this.gbListaEmpleados.TabIndex = 0;
            this.gbListaEmpleados.TabStop = false;
            this.gbListaEmpleados.Text = "Lista de Empleados";
            // 
            // lblTotalEmpleados
            // 
            this.lblTotalEmpleados.AutoSize = true;
            this.lblTotalEmpleados.Location = new System.Drawing.Point(20, 345);
            this.lblTotalEmpleados.Name = "lblTotalEmpleados";
            this.lblTotalEmpleados.Size = new System.Drawing.Size(136, 19);
            this.lblTotalEmpleados.TabIndex = 0;
            this.lblTotalEmpleados.Text = "Total: 0 empleados";
            // 
            // txtBuscarEmpleado
            // 
            this.txtBuscarEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtBuscarEmpleado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtBuscarEmpleado.Location = new System.Drawing.Point(20, 35);
            this.txtBuscarEmpleado.Name = "txtBuscarEmpleado";
            this.txtBuscarEmpleado.Size = new System.Drawing.Size(200, 33);
            this.txtBuscarEmpleado.TabIndex = 0;
            this.txtBuscarEmpleado.Text = "Buscar empleado...";
            this.txtBuscarEmpleado.TextChanged += new System.EventHandler(this.txtBuscarEmpleado_TextChanged);
            // 
            // cbFiltroEmpresa
            // 
            this.cbFiltroEmpresa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.cbFiltroEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroEmpresa.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltroEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.cbFiltroEmpresa.FormattingEnabled = true;
            this.cbFiltroEmpresa.Location = new System.Drawing.Point(240, 35);
            this.cbFiltroEmpresa.Name = "cbFiltroEmpresa";
            this.cbFiltroEmpresa.Size = new System.Drawing.Size(150, 33);
            this.cbFiltroEmpresa.TabIndex = 1;
            // 
            // btnNuevoEmpleado
            // 
            this.btnNuevoEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevoEmpleado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnNuevoEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoEmpleado.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnNuevoEmpleado.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnNuevoEmpleado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNuevoEmpleado.Image = null;
            this.btnNuevoEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoEmpleado.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnNuevoEmpleado.Location = new System.Drawing.Point(376, 345);
            this.btnNuevoEmpleado.Name = "btnNuevoEmpleado";
            this.btnNuevoEmpleado.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnNuevoEmpleado.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnNuevoEmpleado.Size = new System.Drawing.Size(150, 35);
            this.btnNuevoEmpleado.TabIndex = 1;
            this.btnNuevoEmpleado.Text = "+ Nuevo Empleado";
            this.btnNuevoEmpleado.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnNuevoEmpleado.Click += new System.EventHandler(this.btnNuevoEmpleado_Click);
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpleados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.dgvEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmpleados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmpleados.ColumnHeadersHeight = 40;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmpleados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmpleados.EnableHeadersVisualStyles = false;
            this.dgvEmpleados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.dgvEmpleados.Location = new System.Drawing.Point(20, 80);
            this.dgvEmpleados.MultiSelect = false;
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.RowHeadersVisible = false;
            this.dgvEmpleados.RowTemplate.Height = 40;
            this.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleados.Size = new System.Drawing.Size(520, 250);
            this.dgvEmpleados.TabIndex = 1;
            this.dgvEmpleados.SelectionChanged += new System.EventHandler(this.dgvEmpleados_SelectionChanged);
            // 
            // gbEmpleadoDetalle
            // 
            this.gbEmpleadoDetalle.Controls.Add(this.btnEliminarEmpleado);
            this.gbEmpleadoDetalle.Controls.Add(this.btnGuardarEmpleado);
            this.gbEmpleadoDetalle.Controls.Add(this.lblCredencial);
            this.gbEmpleadoDetalle.Controls.Add(this.btnCancelarEmpleado);
            this.gbEmpleadoDetalle.Controls.Add(this.btnVerificarCredencial);
            this.gbEmpleadoDetalle.Controls.Add(this.txtCredencial);
            this.gbEmpleadoDetalle.Controls.Add(this.lblNombre);
            this.gbEmpleadoDetalle.Controls.Add(this.txtNombre);
            this.gbEmpleadoDetalle.Controls.Add(this.lblApellido);
            this.gbEmpleadoDetalle.Controls.Add(this.txtApellido);
            this.gbEmpleadoDetalle.Controls.Add(this.lblEmpresa);
            this.gbEmpleadoDetalle.Controls.Add(this.cbEmpresaEmpleado);
            this.gbEmpleadoDetalle.Controls.Add(this.lblEstado);
            this.gbEmpleadoDetalle.Controls.Add(this.rbActivoEmpleado);
            this.gbEmpleadoDetalle.Controls.Add(this.rbInactivoEmpleado);
            this.gbEmpleadoDetalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbEmpleadoDetalle.Location = new System.Drawing.Point(590, 15);
            this.gbEmpleadoDetalle.Name = "gbEmpleadoDetalle";
            this.gbEmpleadoDetalle.Padding = new System.Windows.Forms.Padding(20);
            this.gbEmpleadoDetalle.Size = new System.Drawing.Size(550, 410);
            this.gbEmpleadoDetalle.TabIndex = 0;
            this.gbEmpleadoDetalle.TabStop = false;
            this.gbEmpleadoDetalle.Text = "Detalles del Empleado";
            // 
            // btnEliminarEmpleado
            // 
            this.btnEliminarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarEmpleado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEliminarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarEmpleado.Enabled = false;
            this.btnEliminarEmpleado.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEliminarEmpleado.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEliminarEmpleado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEliminarEmpleado.Image = null;
            this.btnEliminarEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarEmpleado.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEliminarEmpleado.Location = new System.Drawing.Point(155, 320);
            this.btnEliminarEmpleado.Name = "btnEliminarEmpleado";
            this.btnEliminarEmpleado.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEliminarEmpleado.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEliminarEmpleado.Size = new System.Drawing.Size(100, 35);
            this.btnEliminarEmpleado.TabIndex = 2;
            this.btnEliminarEmpleado.Text = "Eliminar";
            this.btnEliminarEmpleado.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEliminarEmpleado.Click += new System.EventHandler(this.btnEliminarEmpleado_Click);
            // 
            // btnGuardarEmpleado
            // 
            this.btnGuardarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarEmpleado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGuardarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarEmpleado.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGuardarEmpleado.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGuardarEmpleado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGuardarEmpleado.Image = null;
            this.btnGuardarEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarEmpleado.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGuardarEmpleado.Location = new System.Drawing.Point(23, 320);
            this.btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            this.btnGuardarEmpleado.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGuardarEmpleado.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGuardarEmpleado.Size = new System.Drawing.Size(100, 35);
            this.btnGuardarEmpleado.TabIndex = 0;
            this.btnGuardarEmpleado.Text = "Guardar";
            this.btnGuardarEmpleado.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnGuardarEmpleado.Click += new System.EventHandler(this.btnGuardarEmpleado_Click);
            // 
            // lblCredencial
            // 
            this.lblCredencial.AutoSize = true;
            this.lblCredencial.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCredencial.Location = new System.Drawing.Point(16, 38);
            this.lblCredencial.Name = "lblCredencial";
            this.lblCredencial.Size = new System.Drawing.Size(148, 19);
            this.lblCredencial.TabIndex = 0;
            this.lblCredencial.Text = "Número de Credencial:";
            // 
            // btnCancelarEmpleado
            // 
            this.btnCancelarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelarEmpleado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnCancelarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarEmpleado.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnCancelarEmpleado.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnCancelarEmpleado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelarEmpleado.Image = null;
            this.btnCancelarEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarEmpleado.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnCancelarEmpleado.Location = new System.Drawing.Point(277, 320);
            this.btnCancelarEmpleado.Name = "btnCancelarEmpleado";
            this.btnCancelarEmpleado.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnCancelarEmpleado.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnCancelarEmpleado.Size = new System.Drawing.Size(100, 35);
            this.btnCancelarEmpleado.TabIndex = 1;
            this.btnCancelarEmpleado.Text = "Cancelar";
            this.btnCancelarEmpleado.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnCancelarEmpleado.Click += new System.EventHandler(this.btnCancelarEmpleado_Click);
            // 
            // btnVerificarCredencial
            // 
            this.btnVerificarCredencial.BackColor = System.Drawing.Color.Transparent;
            this.btnVerificarCredencial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnVerificarCredencial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificarCredencial.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnVerificarCredencial.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnVerificarCredencial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVerificarCredencial.Image = null;
            this.btnVerificarCredencial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerificarCredencial.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnVerificarCredencial.Location = new System.Drawing.Point(205, 55);
            this.btnVerificarCredencial.Name = "btnVerificarCredencial";
            this.btnVerificarCredencial.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnVerificarCredencial.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnVerificarCredencial.Size = new System.Drawing.Size(209, 38);
            this.btnVerificarCredencial.TabIndex = 1;
            this.btnVerificarCredencial.Text = "Verificar Disponibilidad";
            this.btnVerificarCredencial.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnVerificarCredencial.Click += new System.EventHandler(this.btnVerificarCredencial_Click);
            // 
            // txtCredencial
            // 
            this.txtCredencial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtCredencial.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredencial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtCredencial.Location = new System.Drawing.Point(20, 60);
            this.txtCredencial.MaxLength = 20;
            this.txtCredencial.Name = "txtCredencial";
            this.txtCredencial.Size = new System.Drawing.Size(150, 33);
            this.txtCredencial.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombre.Location = new System.Drawing.Point(16, 100);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 19);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtNombre.Location = new System.Drawing.Point(20, 122);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 33);
            this.txtNombre.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblApellido.Location = new System.Drawing.Point(287, 100);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(61, 19);
            this.lblApellido.TabIndex = 4;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtApellido.Location = new System.Drawing.Point(291, 122);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(250, 33);
            this.txtApellido.TabIndex = 5;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmpresa.Location = new System.Drawing.Point(16, 170);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(124, 19);
            this.lblEmpresa.TabIndex = 6;
            this.lblEmpresa.Text = "Empresa Asignada:";
            // 
            // cbEmpresaEmpleado
            // 
            this.cbEmpresaEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.cbEmpresaEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresaEmpleado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresaEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.cbEmpresaEmpleado.FormattingEnabled = true;
            this.cbEmpresaEmpleado.Location = new System.Drawing.Point(16, 195);
            this.cbEmpresaEmpleado.Name = "cbEmpresaEmpleado";
            this.cbEmpresaEmpleado.Size = new System.Drawing.Size(250, 33);
            this.cbEmpresaEmpleado.TabIndex = 7;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEstado.Location = new System.Drawing.Point(287, 170);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(53, 19);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado:";
            // 
            // rbActivoEmpleado
            // 
            this.rbActivoEmpleado.AutoSize = true;
            this.rbActivoEmpleado.Checked = true;
            this.rbActivoEmpleado.Location = new System.Drawing.Point(287, 195);
            this.rbActivoEmpleado.Name = "rbActivoEmpleado";
            this.rbActivoEmpleado.Size = new System.Drawing.Size(70, 23);
            this.rbActivoEmpleado.TabIndex = 9;
            this.rbActivoEmpleado.TabStop = true;
            this.rbActivoEmpleado.Text = "Activo";
            this.rbActivoEmpleado.UseVisualStyleBackColor = true;
            // 
            // rbInactivoEmpleado
            // 
            this.rbInactivoEmpleado.AutoSize = true;
            this.rbInactivoEmpleado.Location = new System.Drawing.Point(387, 195);
            this.rbInactivoEmpleado.Name = "rbInactivoEmpleado";
            this.rbInactivoEmpleado.Size = new System.Drawing.Size(80, 23);
            this.rbInactivoEmpleado.TabIndex = 10;
            this.rbInactivoEmpleado.Text = "Inactivo";
            this.rbInactivoEmpleado.UseVisualStyleBackColor = true;
            // 
            // pnlEmpresas
            // 
            this.pnlEmpresas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEmpresas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.pnlEmpresas.Location = new System.Drawing.Point(0, 70);
            this.pnlEmpresas.Name = "pnlEmpresas";
            this.pnlEmpresas.Padding = new System.Windows.Forms.Padding(15);
            this.pnlEmpresas.Size = new System.Drawing.Size(1014, 140);
            this.pnlEmpresas.TabIndex = 2;
            this.pnlEmpresas.Visible = false;
            // 
            // pnlEstadisticas
            // 
            this.pnlEstadisticas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEstadisticas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.pnlEstadisticas.Location = new System.Drawing.Point(0, 70);
            this.pnlEstadisticas.Name = "pnlEstadisticas";
            this.pnlEstadisticas.Padding = new System.Windows.Forms.Padding(15);
            this.pnlEstadisticas.Size = new System.Drawing.Size(1014, 140);
            this.pnlEstadisticas.TabIndex = 3;
            this.pnlEstadisticas.Visible = false;
            // 
            // pnlConfiguracion
            // 
            this.pnlConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.pnlConfiguracion.Location = new System.Drawing.Point(0, 70);
            this.pnlConfiguracion.Name = "pnlConfiguracion";
            this.pnlConfiguracion.Padding = new System.Windows.Forms.Padding(15);
            this.pnlConfiguracion.Size = new System.Drawing.Size(1155, 249);
            this.pnlConfiguracion.TabIndex = 4;
            this.pnlConfiguracion.Visible = false;
            // 
            // ucAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.pnlEmpleados);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlEmpresas);
            this.Controls.Add(this.pnlEstadisticas);
            this.Controls.Add(this.pnlConfiguracion);
            this.Name = "ucAdmin";
            this.Size = new System.Drawing.Size(1155, 510);
            this.Load += new System.EventHandler(this.ucAdmin_Load);
            this.pnlBotones.ResumeLayout(false);
            this.pnlEmpleados.ResumeLayout(false);
            this.gbListaEmpleados.ResumeLayout(false);
            this.gbListaEmpleados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.gbEmpleadoDetalle.ResumeLayout(false);
            this.gbEmpleadoDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBotones;
        private ReaLTaiizor.Controls.Button btnEmpleados;
        private ReaLTaiizor.Controls.Button btnEmpresas;
        private ReaLTaiizor.Controls.Button btnEstadisticas;
        private ReaLTaiizor.Controls.Button btnConfiguracion;
        private System.Windows.Forms.Panel pnlEmpleados;
        private System.Windows.Forms.GroupBox gbListaEmpleados;
        private System.Windows.Forms.TextBox txtBuscarEmpleado;
        private System.Windows.Forms.ComboBox cbFiltroEmpresa;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Label lblTotalEmpleados;
        private ReaLTaiizor.Controls.Button btnNuevoEmpleado;
        private System.Windows.Forms.GroupBox gbEmpleadoDetalle;
        private System.Windows.Forms.Label lblCredencial;
        private System.Windows.Forms.TextBox txtCredencial;
        private ReaLTaiizor.Controls.Button btnVerificarCredencial;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ComboBox cbEmpresaEmpleado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.RadioButton rbActivoEmpleado;
        private System.Windows.Forms.RadioButton rbInactivoEmpleado;
        private System.Windows.Forms.Panel pnlEmpresas;
        private System.Windows.Forms.Panel pnlEstadisticas;
        private System.Windows.Forms.Panel pnlConfiguracion;
        private ReaLTaiizor.Controls.Button btnEliminarEmpleado;
        private ReaLTaiizor.Controls.Button btnGuardarEmpleado;
        private ReaLTaiizor.Controls.Button btnCancelarEmpleado;
    }
}
