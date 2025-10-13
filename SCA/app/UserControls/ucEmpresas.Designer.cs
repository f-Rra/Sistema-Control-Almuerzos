namespace app.UserControls
{
    partial class ucEmpresas
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
            this.gbxEmpresaDetalles = new System.Windows.Forms.GroupBox();
            this.pnlA = new System.Windows.Forms.Panel();
            this.lblDetallesEmpresa = new ReaLTaiizor.Controls.BigLabel();
            this.pnlB = new System.Windows.Forms.Panel();
            this.btnEliminarEmpresa = new ReaLTaiizor.Controls.Button();
            this.btnCancelarEmpresa = new ReaLTaiizor.Controls.Button();
            this.btnGuardarEmpresa = new ReaLTaiizor.Controls.Button();
            this.rbInactivoEmpresa = new System.Windows.Forms.RadioButton();
            this.rbActivoEmpresa = new System.Windows.Forms.RadioButton();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbxEstadisticasEmpresa = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEstadisticasEmpresa = new ReaLTaiizor.Controls.BigLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalEmpleados = new ReaLTaiizor.Controls.BigLabel();
            this.lblEmpleadosInactivos = new ReaLTaiizor.Controls.BigLabel();
            this.lblAsistencias = new ReaLTaiizor.Controls.BigLabel();
            this.lblPromedio = new ReaLTaiizor.Controls.BigLabel();
            this.gbxListaEmpresas = new System.Windows.Forms.GroupBox();
            this.pnlC = new System.Windows.Forms.Panel();
            this.lblListaEmpresas = new ReaLTaiizor.Controls.BigLabel();
            this.pnlD = new System.Windows.Forms.Panel();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.lblTotalEmpresas = new System.Windows.Forms.Label();
            this.btnNuevaEmpresa = new ReaLTaiizor.Controls.Button();
            this.txtBuscarEmpresa = new System.Windows.Forms.TextBox();
            this.lblFiltroNombre = new System.Windows.Forms.Label();
            this.gbxEmpresaDetalles.SuspendLayout();
            this.pnlA.SuspendLayout();
            this.pnlB.SuspendLayout();
            this.gbxEstadisticasEmpresa.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbxListaEmpresas.SuspendLayout();
            this.pnlC.SuspendLayout();
            this.pnlD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxEmpresaDetalles
            // 
            this.gbxEmpresaDetalles.Controls.Add(this.pnlA);
            this.gbxEmpresaDetalles.Location = new System.Drawing.Point(742, 9);
            this.gbxEmpresaDetalles.Name = "gbxEmpresaDetalles";
            this.gbxEmpresaDetalles.Size = new System.Drawing.Size(395, 243);
            this.gbxEmpresaDetalles.TabIndex = 10;
            this.gbxEmpresaDetalles.TabStop = false;
            // 
            // pnlA
            // 
            this.pnlA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnlA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlA.Controls.Add(this.lblDetallesEmpresa);
            this.pnlA.Controls.Add(this.pnlB);
            this.pnlA.Location = new System.Drawing.Point(10, 19);
            this.pnlA.Name = "pnlA";
            this.pnlA.Size = new System.Drawing.Size(377, 208);
            this.pnlA.TabIndex = 8;
            // 
            // lblDetallesEmpresa
            // 
            this.lblDetallesEmpresa.AutoSize = true;
            this.lblDetallesEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblDetallesEmpresa.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetallesEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblDetallesEmpresa.Location = new System.Drawing.Point(105, 7);
            this.lblDetallesEmpresa.Name = "lblDetallesEmpresa";
            this.lblDetallesEmpresa.Size = new System.Drawing.Size(148, 17);
            this.lblDetallesEmpresa.TabIndex = 2;
            this.lblDetallesEmpresa.Text = "Detalles de la Empresa";
            this.lblDetallesEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlB
            // 
            this.pnlB.BackColor = System.Drawing.Color.Transparent;
            this.pnlB.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnlB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlB.Controls.Add(this.btnEliminarEmpresa);
            this.pnlB.Controls.Add(this.txtNombre);
            this.pnlB.Controls.Add(this.btnCancelarEmpresa);
            this.pnlB.Controls.Add(this.lblNombre);
            this.pnlB.Controls.Add(this.btnGuardarEmpresa);
            this.pnlB.Controls.Add(this.rbInactivoEmpresa);
            this.pnlB.Controls.Add(this.rbActivoEmpresa);
            this.pnlB.Controls.Add(this.lblEstado);
            this.pnlB.Location = new System.Drawing.Point(3, 27);
            this.pnlB.Name = "pnlB";
            this.pnlB.Size = new System.Drawing.Size(368, 175);
            this.pnlB.TabIndex = 6;
            // 
            // btnEliminarEmpresa
            // 
            this.btnEliminarEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarEmpresa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEliminarEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarEmpresa.Enabled = false;
            this.btnEliminarEmpresa.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEliminarEmpresa.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEliminarEmpresa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEliminarEmpresa.Image = null;
            this.btnEliminarEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarEmpresa.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEliminarEmpresa.Location = new System.Drawing.Point(239, 120);
            this.btnEliminarEmpresa.Name = "btnEliminarEmpresa";
            this.btnEliminarEmpresa.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEliminarEmpresa.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEliminarEmpresa.Size = new System.Drawing.Size(100, 35);
            this.btnEliminarEmpresa.TabIndex = 2;
            this.btnEliminarEmpresa.Text = "Eliminar";
            this.btnEliminarEmpresa.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnCancelarEmpresa
            // 
            this.btnCancelarEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelarEmpresa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnCancelarEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarEmpresa.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnCancelarEmpresa.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnCancelarEmpresa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelarEmpresa.Image = null;
            this.btnCancelarEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarEmpresa.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnCancelarEmpresa.Location = new System.Drawing.Point(132, 120);
            this.btnCancelarEmpresa.Name = "btnCancelarEmpresa";
            this.btnCancelarEmpresa.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnCancelarEmpresa.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnCancelarEmpresa.Size = new System.Drawing.Size(100, 35);
            this.btnCancelarEmpresa.TabIndex = 1;
            this.btnCancelarEmpresa.Text = "Cancelar";
            this.btnCancelarEmpresa.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnGuardarEmpresa
            // 
            this.btnGuardarEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarEmpresa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGuardarEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarEmpresa.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGuardarEmpresa.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGuardarEmpresa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGuardarEmpresa.Image = null;
            this.btnGuardarEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarEmpresa.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGuardarEmpresa.Location = new System.Drawing.Point(26, 120);
            this.btnGuardarEmpresa.Name = "btnGuardarEmpresa";
            this.btnGuardarEmpresa.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGuardarEmpresa.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGuardarEmpresa.Size = new System.Drawing.Size(100, 35);
            this.btnGuardarEmpresa.TabIndex = 0;
            this.btnGuardarEmpresa.Text = "Guardar";
            this.btnGuardarEmpresa.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // rbInactivoEmpresa
            // 
            this.rbInactivoEmpresa.AutoSize = true;
            this.rbInactivoEmpresa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInactivoEmpresa.ForeColor = System.Drawing.Color.White;
            this.rbInactivoEmpresa.Location = new System.Drawing.Point(147, 82);
            this.rbInactivoEmpresa.Name = "rbInactivoEmpresa";
            this.rbInactivoEmpresa.Size = new System.Drawing.Size(70, 21);
            this.rbInactivoEmpresa.TabIndex = 10;
            this.rbInactivoEmpresa.Text = "Inactivo";
            this.rbInactivoEmpresa.UseVisualStyleBackColor = true;
            // 
            // rbActivoEmpresa
            // 
            this.rbActivoEmpresa.AutoSize = true;
            this.rbActivoEmpresa.Checked = true;
            this.rbActivoEmpresa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActivoEmpresa.ForeColor = System.Drawing.Color.White;
            this.rbActivoEmpresa.Location = new System.Drawing.Point(86, 82);
            this.rbActivoEmpresa.Name = "rbActivoEmpresa";
            this.rbActivoEmpresa.Size = new System.Drawing.Size(61, 21);
            this.rbActivoEmpresa.TabIndex = 9;
            this.rbActivoEmpresa.TabStop = true;
            this.rbActivoEmpresa.Text = "Activo";
            this.rbActivoEmpresa.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(23, 83);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(53, 19);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtNombre.Location = new System.Drawing.Point(24, 34);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 33);
            this.txtNombre.TabIndex = 5;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(20, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 19);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre:";
            // 
            // gbxEstadisticasEmpresa
            // 
            this.gbxEstadisticasEmpresa.Controls.Add(this.panel1);
            this.gbxEstadisticasEmpresa.Location = new System.Drawing.Point(742, 253);
            this.gbxEstadisticasEmpresa.Name = "gbxEstadisticasEmpresa";
            this.gbxEstadisticasEmpresa.Size = new System.Drawing.Size(395, 243);
            this.gbxEstadisticasEmpresa.TabIndex = 11;
            this.gbxEstadisticasEmpresa.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblEstadisticasEmpresa);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(10, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 208);
            this.panel1.TabIndex = 8;
            // 
            // lblEstadisticasEmpresa
            // 
            this.lblEstadisticasEmpresa.AutoSize = true;
            this.lblEstadisticasEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadisticasEmpresa.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadisticasEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblEstadisticasEmpresa.Location = new System.Drawing.Point(105, 7);
            this.lblEstadisticasEmpresa.Name = "lblEstadisticasEmpresa";
            this.lblEstadisticasEmpresa.Size = new System.Drawing.Size(169, 17);
            this.lblEstadisticasEmpresa.TabIndex = 2;
            this.lblEstadisticasEmpresa.Text = "Estadisticas de la Empresa";
            this.lblEstadisticasEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::app.Properties.Resources.panel;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblPromedio);
            this.panel2.Controls.Add(this.lblAsistencias);
            this.panel2.Controls.Add(this.lblEmpleadosInactivos);
            this.panel2.Controls.Add(this.lblTotalEmpleados);
            this.panel2.Location = new System.Drawing.Point(3, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 175);
            this.panel2.TabIndex = 6;
            // 
            // lblTotalEmpleados
            // 
            this.lblTotalEmpleados.AutoSize = true;
            this.lblTotalEmpleados.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalEmpleados.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEmpleados.ForeColor = System.Drawing.Color.White;
            this.lblTotalEmpleados.Location = new System.Drawing.Point(13, 9);
            this.lblTotalEmpleados.Name = "lblTotalEmpleados";
            this.lblTotalEmpleados.Size = new System.Drawing.Size(215, 30);
            this.lblTotalEmpleados.TabIndex = 12;
            this.lblTotalEmpleados.Text = "Total de Empleados: ";
            this.lblTotalEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmpleadosInactivos
            // 
            this.lblEmpleadosInactivos.AutoSize = true;
            this.lblEmpleadosInactivos.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpleadosInactivos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleadosInactivos.ForeColor = System.Drawing.Color.White;
            this.lblEmpleadosInactivos.Location = new System.Drawing.Point(13, 49);
            this.lblEmpleadosInactivos.Name = "lblEmpleadosInactivos";
            this.lblEmpleadosInactivos.Size = new System.Drawing.Size(219, 30);
            this.lblEmpleadosInactivos.TabIndex = 12;
            this.lblEmpleadosInactivos.Text = "Empleados Inactivos:";
            this.lblEmpleadosInactivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAsistencias
            // 
            this.lblAsistencias.AutoSize = true;
            this.lblAsistencias.BackColor = System.Drawing.Color.Transparent;
            this.lblAsistencias.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsistencias.ForeColor = System.Drawing.Color.White;
            this.lblAsistencias.Location = new System.Drawing.Point(13, 89);
            this.lblAsistencias.Name = "lblAsistencias";
            this.lblAsistencias.Size = new System.Drawing.Size(257, 30);
            this.lblAsistencias.TabIndex = 12;
            this.lblAsistencias.Text = "Asistencias (Mes Actual):";
            this.lblAsistencias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPromedio
            // 
            this.lblPromedio.AutoSize = true;
            this.lblPromedio.BackColor = System.Drawing.Color.Transparent;
            this.lblPromedio.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedio.ForeColor = System.Drawing.Color.White;
            this.lblPromedio.Location = new System.Drawing.Point(13, 129);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(186, 30);
            this.lblPromedio.TabIndex = 12;
            this.lblPromedio.Text = "Promedio Diario: ";
            this.lblPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxListaEmpresas
            // 
            this.gbxListaEmpresas.Controls.Add(this.pnlC);
            this.gbxListaEmpresas.Location = new System.Drawing.Point(9, 1);
            this.gbxListaEmpresas.Name = "gbxListaEmpresas";
            this.gbxListaEmpresas.Size = new System.Drawing.Size(710, 499);
            this.gbxListaEmpresas.TabIndex = 12;
            this.gbxListaEmpresas.TabStop = false;
            // 
            // pnlC
            // 
            this.pnlC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnlC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlC.Controls.Add(this.lblListaEmpresas);
            this.pnlC.Controls.Add(this.pnlD);
            this.pnlC.Location = new System.Drawing.Point(10, 19);
            this.pnlC.Name = "pnlC";
            this.pnlC.Size = new System.Drawing.Size(687, 466);
            this.pnlC.TabIndex = 8;
            // 
            // lblListaEmpresas
            // 
            this.lblListaEmpresas.AutoSize = true;
            this.lblListaEmpresas.BackColor = System.Drawing.Color.Transparent;
            this.lblListaEmpresas.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaEmpresas.ForeColor = System.Drawing.Color.White;
            this.lblListaEmpresas.Location = new System.Drawing.Point(263, 7);
            this.lblListaEmpresas.Name = "lblListaEmpresas";
            this.lblListaEmpresas.Size = new System.Drawing.Size(118, 17);
            this.lblListaEmpresas.TabIndex = 2;
            this.lblListaEmpresas.Text = "Lista de Empresas";
            this.lblListaEmpresas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlD
            // 
            this.pnlD.BackColor = System.Drawing.Color.Transparent;
            this.pnlD.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnlD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlD.Controls.Add(this.dgvEmpleados);
            this.pnlD.Controls.Add(this.lblTotalEmpresas);
            this.pnlD.Controls.Add(this.btnNuevaEmpresa);
            this.pnlD.Controls.Add(this.txtBuscarEmpresa);
            this.pnlD.Controls.Add(this.lblFiltroNombre);
            this.pnlD.Location = new System.Drawing.Point(3, 27);
            this.pnlD.Name = "pnlD";
            this.pnlD.Size = new System.Drawing.Size(679, 434);
            this.pnlD.TabIndex = 6;
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
            // 
            // lblTotalEmpresas
            // 
            this.lblTotalEmpresas.AutoSize = true;
            this.lblTotalEmpresas.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEmpresas.ForeColor = System.Drawing.Color.White;
            this.lblTotalEmpresas.Location = new System.Drawing.Point(17, 392);
            this.lblTotalEmpresas.Name = "lblTotalEmpresas";
            this.lblTotalEmpresas.Size = new System.Drawing.Size(148, 25);
            this.lblTotalEmpresas.TabIndex = 0;
            this.lblTotalEmpresas.Text = "Total Empresas:";
            // 
            // btnNuevaEmpresa
            // 
            this.btnNuevaEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevaEmpresa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnNuevaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaEmpresa.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnNuevaEmpresa.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnNuevaEmpresa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNuevaEmpresa.Image = null;
            this.btnNuevaEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaEmpresa.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnNuevaEmpresa.Location = new System.Drawing.Point(513, 386);
            this.btnNuevaEmpresa.Name = "btnNuevaEmpresa";
            this.btnNuevaEmpresa.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnNuevaEmpresa.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnNuevaEmpresa.Size = new System.Drawing.Size(150, 35);
            this.btnNuevaEmpresa.TabIndex = 1;
            this.btnNuevaEmpresa.Text = "+ Nueva Empresa";
            this.btnNuevaEmpresa.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtBuscarEmpresa
            // 
            this.txtBuscarEmpresa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtBuscarEmpresa.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtBuscarEmpresa.Location = new System.Drawing.Point(20, 46);
            this.txtBuscarEmpresa.Name = "txtBuscarEmpresa";
            this.txtBuscarEmpresa.Size = new System.Drawing.Size(200, 33);
            this.txtBuscarEmpresa.TabIndex = 0;
            // 
            // lblFiltroNombre
            // 
            this.lblFiltroNombre.AutoSize = true;
            this.lblFiltroNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFiltroNombre.ForeColor = System.Drawing.Color.White;
            this.lblFiltroNombre.Location = new System.Drawing.Point(16, 21);
            this.lblFiltroNombre.Name = "lblFiltroNombre";
            this.lblFiltroNombre.Size = new System.Drawing.Size(124, 19);
            this.lblFiltroNombre.TabIndex = 8;
            this.lblFiltroNombre.Text = "Filtrar por nombre:";
            // 
            // ucEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.gbxListaEmpresas);
            this.Controls.Add(this.gbxEstadisticasEmpresa);
            this.Controls.Add(this.gbxEmpresaDetalles);
            this.Name = "ucEmpresas";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Size = new System.Drawing.Size(1155, 510);
            this.Load += new System.EventHandler(this.ucEmpresas_Load);
            this.gbxEmpresaDetalles.ResumeLayout(false);
            this.pnlA.ResumeLayout(false);
            this.pnlA.PerformLayout();
            this.pnlB.ResumeLayout(false);
            this.pnlB.PerformLayout();
            this.gbxEstadisticasEmpresa.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbxListaEmpresas.ResumeLayout(false);
            this.pnlC.ResumeLayout(false);
            this.pnlC.PerformLayout();
            this.pnlD.ResumeLayout(false);
            this.pnlD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxEmpresaDetalles;
        private System.Windows.Forms.Panel pnlA;
        private ReaLTaiizor.Controls.BigLabel lblDetallesEmpresa;
        private System.Windows.Forms.Panel pnlB;
        private ReaLTaiizor.Controls.Button btnEliminarEmpresa;
        private ReaLTaiizor.Controls.Button btnCancelarEmpresa;
        private ReaLTaiizor.Controls.Button btnGuardarEmpresa;
        private System.Windows.Forms.RadioButton rbInactivoEmpresa;
        private System.Windows.Forms.RadioButton rbActivoEmpresa;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox gbxEstadisticasEmpresa;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.BigLabel lblEstadisticasEmpresa;
        private System.Windows.Forms.Panel panel2;
        private ReaLTaiizor.Controls.BigLabel lblTotalEmpleados;
        private ReaLTaiizor.Controls.BigLabel lblPromedio;
        private ReaLTaiizor.Controls.BigLabel lblAsistencias;
        private ReaLTaiizor.Controls.BigLabel lblEmpleadosInactivos;
        private System.Windows.Forms.GroupBox gbxListaEmpresas;
        private System.Windows.Forms.Panel pnlC;
        private ReaLTaiizor.Controls.BigLabel lblListaEmpresas;
        private System.Windows.Forms.Panel pnlD;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Label lblTotalEmpresas;
        private ReaLTaiizor.Controls.Button btnNuevaEmpresa;
        private System.Windows.Forms.TextBox txtBuscarEmpresa;
        private System.Windows.Forms.Label lblFiltroNombre;
    }
}
