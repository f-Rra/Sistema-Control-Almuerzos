namespace app.UserControls
{
    partial class ucEmpleados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTotalEmpleados = new System.Windows.Forms.Label();
            this.lblTotalEmpresas = new System.Windows.Forms.Label();
            this.txtBuscarEmpleado = new System.Windows.Forms.TextBox();
            this.cbFiltroEmpresa = new System.Windows.Forms.ComboBox();
            this.btnNuevoEmpleado = new ReaLTaiizor.Controls.Button();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
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
            this.llblFiltroEmpresa = new System.Windows.Forms.Label();
            this.lblFiltroNombre = new System.Windows.Forms.Label();
            this.pnlA = new System.Windows.Forms.Panel();
            this.lblDetallesEmpleados = new ReaLTaiizor.Controls.BigLabel();
            this.pnlB = new System.Windows.Forms.Panel();
            this.gbEmpleadoDetalle = new System.Windows.Forms.GroupBox();
            this.gbListaEmpleados = new System.Windows.Forms.GroupBox();
            this.pnlC = new System.Windows.Forms.Panel();
            this.lblListaEmpleados = new ReaLTaiizor.Controls.BigLabel();
            this.pnlD = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.pnlA.SuspendLayout();
            this.pnlB.SuspendLayout();
            this.gbEmpleadoDetalle.SuspendLayout();
            this.gbListaEmpleados.SuspendLayout();
            this.pnlC.SuspendLayout();
            this.pnlD.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalEmpleados
            // 
            this.lblTotalEmpleados.AutoSize = true;
            this.lblTotalEmpleados.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.lblTotalEmpleados.Location = new System.Drawing.Point(17, 392);
            this.lblTotalEmpleados.Name = "lblTotalEmpleados";
            this.lblTotalEmpleados.Size = new System.Drawing.Size(177, 25);
            this.lblTotalEmpleados.TabIndex = 0;
            this.lblTotalEmpleados.Text = "Total Empleados: 0";
            // 
            // lblTotalEmpresas
            // 
            this.lblTotalEmpresas.AutoSize = true;
            this.lblTotalEmpresas.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEmpresas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.lblTotalEmpresas.Location = new System.Drawing.Point(240, 392);
            this.lblTotalEmpresas.Name = "lblTotalEmpresas";
            this.lblTotalEmpresas.Size = new System.Drawing.Size(164, 25);
            this.lblTotalEmpresas.TabIndex = 7;
            this.lblTotalEmpresas.Text = "Total Empresas: 0";
            // 
            // txtBuscarEmpleado
            // 
            this.txtBuscarEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtBuscarEmpleado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtBuscarEmpleado.Location = new System.Drawing.Point(20, 46);
            this.txtBuscarEmpleado.Name = "txtBuscarEmpleado";
            this.txtBuscarEmpleado.Size = new System.Drawing.Size(200, 33);
            this.txtBuscarEmpleado.TabIndex = 0;
            this.txtBuscarEmpleado.TextChanged += new System.EventHandler(this.txtBuscarEmpleado_TextChanged);
            // 
            // cbFiltroEmpresa
            // 
            this.cbFiltroEmpresa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.cbFiltroEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroEmpresa.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltroEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.cbFiltroEmpresa.FormattingEnabled = true;
            this.cbFiltroEmpresa.Location = new System.Drawing.Point(238, 45);
            this.cbFiltroEmpresa.Name = "cbFiltroEmpresa";
            this.cbFiltroEmpresa.Size = new System.Drawing.Size(205, 33);
            this.cbFiltroEmpresa.TabIndex = 1;
            this.cbFiltroEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbFiltroEmpresa_SelectedIndexChanged);
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
            this.btnNuevoEmpleado.Location = new System.Drawing.Point(513, 386);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmpleados.ColumnHeadersHeight = 40;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmpleados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmpleados.EnableHeadersVisualStyles = false;
            this.dgvEmpleados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.dgvEmpleados.Location = new System.Drawing.Point(20, 101);
            this.dgvEmpleados.MultiSelect = false;
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmpleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEmpleados.RowHeadersVisible = false;
            this.dgvEmpleados.RowTemplate.Height = 40;
            this.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleados.Size = new System.Drawing.Size(643, 270);
            this.dgvEmpleados.TabIndex = 1;
            this.dgvEmpleados.SelectionChanged += new System.EventHandler(this.dgvEmpleados_SelectionChanged);
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
            this.btnEliminarEmpleado.Location = new System.Drawing.Point(241, 343);
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
            this.btnGuardarEmpleado.Location = new System.Drawing.Point(28, 343);
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
            this.lblCredencial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.lblCredencial.Location = new System.Drawing.Point(23, 15);
            this.lblCredencial.Name = "lblCredencial";
            this.lblCredencial.Size = new System.Drawing.Size(75, 19);
            this.lblCredencial.TabIndex = 0;
            this.lblCredencial.Text = "Credencial:";
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
            this.btnCancelarEmpleado.Location = new System.Drawing.Point(134, 343);
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
            this.btnVerificarCredencial.Location = new System.Drawing.Point(202, 35);
            this.btnVerificarCredencial.Name = "btnVerificarCredencial";
            this.btnVerificarCredencial.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnVerificarCredencial.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnVerificarCredencial.Size = new System.Drawing.Size(139, 35);
            this.btnVerificarCredencial.TabIndex = 1;
            this.btnVerificarCredencial.Text = "Verificar";
            this.btnVerificarCredencial.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnVerificarCredencial.Click += new System.EventHandler(this.btnVerificarCredencial_Click);
            // 
            // txtCredencial
            // 
            this.txtCredencial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtCredencial.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredencial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtCredencial.Location = new System.Drawing.Point(27, 37);
            this.txtCredencial.MaxLength = 20;
            this.txtCredencial.Name = "txtCredencial";
            this.txtCredencial.Size = new System.Drawing.Size(150, 33);
            this.txtCredencial.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.lblNombre.Location = new System.Drawing.Point(23, 83);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 19);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtNombre.Location = new System.Drawing.Point(27, 105);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 33);
            this.txtNombre.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.lblApellido.Location = new System.Drawing.Point(23, 156);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(61, 19);
            this.lblApellido.TabIndex = 4;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtApellido.Location = new System.Drawing.Point(27, 178);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(250, 33);
            this.txtApellido.TabIndex = 5;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.lblEmpresa.Location = new System.Drawing.Point(22, 235);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(64, 19);
            this.lblEmpresa.TabIndex = 6;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // cbEmpresaEmpleado
            // 
            this.cbEmpresaEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.cbEmpresaEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresaEmpleado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresaEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.cbEmpresaEmpleado.FormattingEnabled = true;
            this.cbEmpresaEmpleado.Location = new System.Drawing.Point(27, 257);
            this.cbEmpresaEmpleado.Name = "cbEmpresaEmpleado";
            this.cbEmpresaEmpleado.Size = new System.Drawing.Size(250, 33);
            this.cbEmpresaEmpleado.TabIndex = 7;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.lblEstado.Location = new System.Drawing.Point(25, 306);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(53, 19);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado:";
            // 
            // rbActivoEmpleado
            // 
            this.rbActivoEmpleado.AutoSize = true;
            this.rbActivoEmpleado.Checked = true;
            this.rbActivoEmpleado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActivoEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.rbActivoEmpleado.Location = new System.Drawing.Point(88, 305);
            this.rbActivoEmpleado.Name = "rbActivoEmpleado";
            this.rbActivoEmpleado.Size = new System.Drawing.Size(61, 21);
            this.rbActivoEmpleado.TabIndex = 9;
            this.rbActivoEmpleado.TabStop = true;
            this.rbActivoEmpleado.Text = "Activo";
            this.rbActivoEmpleado.UseVisualStyleBackColor = true;
            // 
            // rbInactivoEmpleado
            // 
            this.rbInactivoEmpleado.AutoSize = true;
            this.rbInactivoEmpleado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInactivoEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.rbInactivoEmpleado.Location = new System.Drawing.Point(149, 305);
            this.rbInactivoEmpleado.Name = "rbInactivoEmpleado";
            this.rbInactivoEmpleado.Size = new System.Drawing.Size(70, 21);
            this.rbInactivoEmpleado.TabIndex = 10;
            this.rbInactivoEmpleado.Text = "Inactivo";
            this.rbInactivoEmpleado.UseVisualStyleBackColor = true;
            // 
            // llblFiltroEmpresa
            // 
            this.llblFiltroEmpresa.AutoSize = true;
            this.llblFiltroEmpresa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.llblFiltroEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.llblFiltroEmpresa.Location = new System.Drawing.Point(234, 20);
            this.llblFiltroEmpresa.Name = "llblFiltroEmpresa";
            this.llblFiltroEmpresa.Size = new System.Drawing.Size(128, 19);
            this.llblFiltroEmpresa.TabIndex = 8;
            this.llblFiltroEmpresa.Text = "Filtrar por empresa:";
            // 
            // lblFiltroNombre
            // 
            this.lblFiltroNombre.AutoSize = true;
            this.lblFiltroNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFiltroNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.lblFiltroNombre.Location = new System.Drawing.Point(16, 21);
            this.lblFiltroNombre.Name = "lblFiltroNombre";
            this.lblFiltroNombre.Size = new System.Drawing.Size(124, 19);
            this.lblFiltroNombre.TabIndex = 8;
            this.lblFiltroNombre.Text = "Filtrar por nombre:";
            // 
            // pnlA
            // 
            this.pnlA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnlA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlA.Controls.Add(this.lblDetallesEmpleados);
            this.pnlA.Controls.Add(this.pnlB);
            this.pnlA.Location = new System.Drawing.Point(10, 19);
            this.pnlA.Name = "pnlA";
            this.pnlA.Size = new System.Drawing.Size(377, 427);
            this.pnlA.TabIndex = 8;
            // 
            // lblDetallesEmpleados
            // 
            this.lblDetallesEmpleados.AutoSize = true;
            this.lblDetallesEmpleados.BackColor = System.Drawing.Color.Transparent;
            this.lblDetallesEmpleados.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetallesEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.lblDetallesEmpleados.Location = new System.Drawing.Point(126, 7);
            this.lblDetallesEmpleados.Name = "lblDetallesEmpleados";
            this.lblDetallesEmpleados.Size = new System.Drawing.Size(146, 17);
            this.lblDetallesEmpleados.TabIndex = 2;
            this.lblDetallesEmpleados.Text = "Detalles del Empleado";
            this.lblDetallesEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlB
            // 
            this.pnlB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.pnlB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlB.Controls.Add(this.btnEliminarEmpleado);
            this.pnlB.Controls.Add(this.lblCredencial);
            this.pnlB.Controls.Add(this.btnCancelarEmpleado);
            this.pnlB.Controls.Add(this.lblEmpresa);
            this.pnlB.Controls.Add(this.btnGuardarEmpleado);
            this.pnlB.Controls.Add(this.rbInactivoEmpleado);
            this.pnlB.Controls.Add(this.btnVerificarCredencial);
            this.pnlB.Controls.Add(this.rbActivoEmpleado);
            this.pnlB.Controls.Add(this.txtApellido);
            this.pnlB.Controls.Add(this.cbEmpresaEmpleado);
            this.pnlB.Controls.Add(this.lblApellido);
            this.pnlB.Controls.Add(this.txtNombre);
            this.pnlB.Controls.Add(this.lblEstado);
            this.pnlB.Controls.Add(this.txtCredencial);
            this.pnlB.Controls.Add(this.lblNombre);
            this.pnlB.Location = new System.Drawing.Point(3, 27);
            this.pnlB.Name = "pnlB";
            this.pnlB.Size = new System.Drawing.Size(368, 395);
            this.pnlB.TabIndex = 6;
            // 
            // gbEmpleadoDetalle
            // 
            this.gbEmpleadoDetalle.Controls.Add(this.pnlA);
            this.gbEmpleadoDetalle.Location = new System.Drawing.Point(742, 20);
            this.gbEmpleadoDetalle.Name = "gbEmpleadoDetalle";
            this.gbEmpleadoDetalle.Size = new System.Drawing.Size(395, 458);
            this.gbEmpleadoDetalle.TabIndex = 9;
            this.gbEmpleadoDetalle.TabStop = false;
            // 
            // gbListaEmpleados
            // 
            this.gbListaEmpleados.Controls.Add(this.pnlC);
            this.gbListaEmpleados.Location = new System.Drawing.Point(9, 1);
            this.gbListaEmpleados.Name = "gbListaEmpleados";
            this.gbListaEmpleados.Size = new System.Drawing.Size(710, 499);
            this.gbListaEmpleados.TabIndex = 10;
            this.gbListaEmpleados.TabStop = false;
            // 
            // pnlC
            // 
            this.pnlC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnlC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlC.Controls.Add(this.lblListaEmpleados);
            this.pnlC.Controls.Add(this.pnlD);
            this.pnlC.Location = new System.Drawing.Point(10, 19);
            this.pnlC.Name = "pnlC";
            this.pnlC.Size = new System.Drawing.Size(687, 466);
            this.pnlC.TabIndex = 8;
            // 
            // lblListaEmpleados
            // 
            this.lblListaEmpleados.AutoSize = true;
            this.lblListaEmpleados.BackColor = System.Drawing.Color.Transparent;
            this.lblListaEmpleados.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.lblListaEmpleados.Location = new System.Drawing.Point(263, 7);
            this.lblListaEmpleados.Name = "lblListaEmpleados";
            this.lblListaEmpleados.Size = new System.Drawing.Size(127, 17);
            this.lblListaEmpleados.TabIndex = 2;
            this.lblListaEmpleados.Text = "Lista de Empleados";
            this.lblListaEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlD
            // 
            this.pnlD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.pnlD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlD.Controls.Add(this.dgvEmpleados);
            this.pnlD.Controls.Add(this.lblTotalEmpleados);
            this.pnlD.Controls.Add(this.lblTotalEmpresas);
            this.pnlD.Controls.Add(this.btnNuevoEmpleado);
            this.pnlD.Controls.Add(this.cbFiltroEmpresa);
            this.pnlD.Controls.Add(this.txtBuscarEmpleado);
            this.pnlD.Controls.Add(this.lblFiltroNombre);
            this.pnlD.Controls.Add(this.llblFiltroEmpresa);
            this.pnlD.Location = new System.Drawing.Point(3, 27);
            this.pnlD.Name = "pnlD";
            this.pnlD.Size = new System.Drawing.Size(679, 434);
            this.pnlD.TabIndex = 6;
            // 
            // ucEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.gbListaEmpleados);
            this.Controls.Add(this.gbEmpleadoDetalle);
            this.Name = "ucEmpleados";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Size = new System.Drawing.Size(1155, 510);
            this.Load += new System.EventHandler(this.ucEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.pnlA.ResumeLayout(false);
            this.pnlA.PerformLayout();
            this.pnlB.ResumeLayout(false);
            this.pnlB.PerformLayout();
            this.gbEmpleadoDetalle.ResumeLayout(false);
            this.gbListaEmpleados.ResumeLayout(false);
            this.pnlC.ResumeLayout(false);
            this.pnlC.PerformLayout();
            this.pnlD.ResumeLayout(false);
            this.pnlD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtBuscarEmpleado;
        private System.Windows.Forms.ComboBox cbFiltroEmpresa;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Label lblTotalEmpleados;
        private System.Windows.Forms.Label lblTotalEmpresas;
        private ReaLTaiizor.Controls.Button btnNuevoEmpleado;
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
        private ReaLTaiizor.Controls.Button btnEliminarEmpleado;
        private ReaLTaiizor.Controls.Button btnGuardarEmpleado;
        private ReaLTaiizor.Controls.Button btnCancelarEmpleado;
        private System.Windows.Forms.Label llblFiltroEmpresa;
        private System.Windows.Forms.Label lblFiltroNombre;
        private System.Windows.Forms.Panel pnlA;
        private ReaLTaiizor.Controls.BigLabel lblDetallesEmpleados;
        private System.Windows.Forms.Panel pnlB;
        private System.Windows.Forms.GroupBox gbEmpleadoDetalle;
        private System.Windows.Forms.GroupBox gbListaEmpleados;
        private System.Windows.Forms.Panel pnlC;
        private ReaLTaiizor.Controls.BigLabel lblListaEmpleados;
        private System.Windows.Forms.Panel pnlD;
    }
}
