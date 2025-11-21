namespace app.UserControls
{
    partial class ucConfiguracion
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
            this.pnl1 = new System.Windows.Forms.Panel();
            this.lblTitulo1 = new ReaLTaiizor.Controls.BigLabel();
            this.pnl1B = new System.Windows.Forms.Panel();
            this.lblEstadoConexion = new ReaLTaiizor.Controls.BigLabel();
            this.btnGuardarConexion = new ReaLTaiizor.Controls.Button();
            this.btnProbarConexion = new ReaLTaiizor.Controls.Button();
            this.txtCadenaConexion = new System.Windows.Forms.TextBox();
            this.lblCadenaConexion = new ReaLTaiizor.Controls.BigLabel();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.lblTitulo2 = new ReaLTaiizor.Controls.BigLabel();
            this.pnl2B = new System.Windows.Forms.Panel();
            this.btnRestaurarRespaldo = new ReaLTaiizor.Controls.Button();
            this.btnCrearRespaldo = new ReaLTaiizor.Controls.Button();
            this.lblTamañoRespaldo = new ReaLTaiizor.Controls.BigLabel();
            this.lblUltimoRespaldo = new ReaLTaiizor.Controls.BigLabel();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.lblFrecuencia = new ReaLTaiizor.Controls.BigLabel();
            this.btnExaminarRuta = new ReaLTaiizor.Controls.Button();
            this.txtRutaRespaldos = new System.Windows.Forms.TextBox();
            this.lblRutaRespaldos = new ReaLTaiizor.Controls.BigLabel();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.lblTitulo3 = new ReaLTaiizor.Controls.BigLabel();
            this.pnl3B = new System.Windows.Forms.Panel();
            this.btnProbarLector = new ReaLTaiizor.Controls.Button();
            this.btnConfigurarRFID = new ReaLTaiizor.Controls.Button();
            this.lblEstadoRFID = new ReaLTaiizor.Controls.BigLabel();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new ReaLTaiizor.Controls.BigLabel();
            this.btnDetectarPuertos = new ReaLTaiizor.Controls.Button();
            this.cboPuertoRFID = new System.Windows.Forms.ComboBox();
            this.lblPuertoCOM = new ReaLTaiizor.Controls.BigLabel();
            this.pnl4 = new System.Windows.Forms.Panel();
            this.lblTitulo4 = new ReaLTaiizor.Controls.BigLabel();
            this.pnl4B = new System.Windows.Forms.Panel();
            this.lblUILibrary = new ReaLTaiizor.Controls.BigLabel();
            this.lblFramework = new ReaLTaiizor.Controls.BigLabel();
            this.lblFechaCompilacion = new ReaLTaiizor.Controls.BigLabel();
            this.lblVersion = new ReaLTaiizor.Controls.BigLabel();
            this.pnl1.SuspendLayout();
            this.pnl1B.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl2B.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.pnl3B.SuspendLayout();
            this.pnl4.SuspendLayout();
            this.pnl4B.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl1.Controls.Add(this.lblTitulo1);
            this.pnl1.Controls.Add(this.pnl1B);
            this.pnl1.Location = new System.Drawing.Point(27, 14);
            this.pnl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(820, 353);
            this.pnl1.TabIndex = 0;
            // 
            // lblTitulo1
            // 
            this.lblTitulo1.AutoSize = true;
            this.lblTitulo1.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo1.ForeColor = System.Drawing.Color.White;
            this.lblTitulo1.Location = new System.Drawing.Point(312, 11);
            this.lblTitulo1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo1.Name = "lblTitulo1";
            this.lblTitulo1.Size = new System.Drawing.Size(166, 27);
            this.lblTitulo1.TabIndex = 2;
            this.lblTitulo1.Text = "BASE DE DATOS";
            this.lblTitulo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl1B
            // 
            this.pnl1B.BackColor = System.Drawing.Color.Transparent;
            this.pnl1B.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnl1B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl1B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl1B.Controls.Add(this.lblEstadoConexion);
            this.pnl1B.Controls.Add(this.btnGuardarConexion);
            this.pnl1B.Controls.Add(this.btnProbarConexion);
            this.pnl1B.Controls.Add(this.txtCadenaConexion);
            this.pnl1B.Controls.Add(this.lblCadenaConexion);
            this.pnl1B.Location = new System.Drawing.Point(4, 42);
            this.pnl1B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl1B.Name = "pnl1B";
            this.pnl1B.Size = new System.Drawing.Size(808, 304);
            this.pnl1B.TabIndex = 6;
            // 
            // lblEstadoConexion
            // 
            this.lblEstadoConexion.AutoSize = true;
            this.lblEstadoConexion.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoConexion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoConexion.ForeColor = System.Drawing.Color.White;
            this.lblEstadoConexion.Location = new System.Drawing.Point(437, 37);
            this.lblEstadoConexion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstadoConexion.Name = "lblEstadoConexion";
            this.lblEstadoConexion.Size = new System.Drawing.Size(235, 28);
            this.lblEstadoConexion.TabIndex = 14;
            this.lblEstadoConexion.Text = "Estado: No configurado";
            // 
            // btnGuardarConexion
            // 
            this.btnGuardarConexion.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarConexion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGuardarConexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarConexion.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGuardarConexion.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGuardarConexion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGuardarConexion.Image = null;
            this.btnGuardarConexion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarConexion.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGuardarConexion.Location = new System.Drawing.Point(411, 214);
            this.btnGuardarConexion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardarConexion.Name = "btnGuardarConexion";
            this.btnGuardarConexion.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGuardarConexion.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGuardarConexion.Size = new System.Drawing.Size(372, 51);
            this.btnGuardarConexion.TabIndex = 13;
            this.btnGuardarConexion.Text = "Guardar Cambios";
            this.btnGuardarConexion.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnGuardarConexion.Click += new System.EventHandler(this.btnGuardarConexion_Click);
            // 
            // btnProbarConexion
            // 
            this.btnProbarConexion.BackColor = System.Drawing.Color.Transparent;
            this.btnProbarConexion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnProbarConexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProbarConexion.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnProbarConexion.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnProbarConexion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProbarConexion.Image = null;
            this.btnProbarConexion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProbarConexion.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnProbarConexion.Location = new System.Drawing.Point(27, 214);
            this.btnProbarConexion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProbarConexion.Name = "btnProbarConexion";
            this.btnProbarConexion.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnProbarConexion.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnProbarConexion.Size = new System.Drawing.Size(372, 51);
            this.btnProbarConexion.TabIndex = 13;
            this.btnProbarConexion.Text = "Probar Conexión";
            this.btnProbarConexion.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnProbarConexion.Click += new System.EventHandler(this.btnProbarConexion_Click);
            // 
            // txtCadenaConexion
            // 
            this.txtCadenaConexion.BackColor = System.Drawing.Color.White;
            this.txtCadenaConexion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCadenaConexion.Location = new System.Drawing.Point(27, 68);
            this.txtCadenaConexion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCadenaConexion.Multiline = true;
            this.txtCadenaConexion.Name = "txtCadenaConexion";
            this.txtCadenaConexion.Size = new System.Drawing.Size(754, 102);
            this.txtCadenaConexion.TabIndex = 12;
            // 
            // lblCadenaConexion
            // 
            this.lblCadenaConexion.AutoSize = true;
            this.lblCadenaConexion.BackColor = System.Drawing.Color.Transparent;
            this.lblCadenaConexion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadenaConexion.ForeColor = System.Drawing.Color.White;
            this.lblCadenaConexion.Location = new System.Drawing.Point(22, 37);
            this.lblCadenaConexion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCadenaConexion.Name = "lblCadenaConexion";
            this.lblCadenaConexion.Size = new System.Drawing.Size(209, 28);
            this.lblCadenaConexion.TabIndex = 12;
            this.lblCadenaConexion.Text = "Cadena de Conexión:";
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl2.Controls.Add(this.lblTitulo2);
            this.pnl2.Controls.Add(this.pnl2B);
            this.pnl2.Location = new System.Drawing.Point(885, 14);
            this.pnl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(820, 353);
            this.pnl2.TabIndex = 1;
            // 
            // lblTitulo2
            // 
            this.lblTitulo2.AutoSize = true;
            this.lblTitulo2.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo2.ForeColor = System.Drawing.Color.White;
            this.lblTitulo2.Location = new System.Drawing.Point(267, 11);
            this.lblTitulo2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo2.Name = "lblTitulo2";
            this.lblTitulo2.Size = new System.Drawing.Size(299, 27);
            this.lblTitulo2.TabIndex = 2;
            this.lblTitulo2.Text = "RESPALDOS Y RESTAURACIÓN";
            this.lblTitulo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl2B
            // 
            this.pnl2B.BackColor = System.Drawing.Color.Transparent;
            this.pnl2B.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnl2B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl2B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl2B.Controls.Add(this.btnRestaurarRespaldo);
            this.pnl2B.Controls.Add(this.btnCrearRespaldo);
            this.pnl2B.Controls.Add(this.lblTamañoRespaldo);
            this.pnl2B.Controls.Add(this.lblUltimoRespaldo);
            this.pnl2B.Controls.Add(this.rbManual);
            this.pnl2B.Controls.Add(this.rbMensual);
            this.pnl2B.Controls.Add(this.lblFrecuencia);
            this.pnl2B.Controls.Add(this.btnExaminarRuta);
            this.pnl2B.Controls.Add(this.txtRutaRespaldos);
            this.pnl2B.Controls.Add(this.lblRutaRespaldos);
            this.pnl2B.Location = new System.Drawing.Point(4, 42);
            this.pnl2B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl2B.Name = "pnl2B";
            this.pnl2B.Size = new System.Drawing.Size(808, 304);
            this.pnl2B.TabIndex = 6;
            // 
            // btnRestaurarRespaldo
            // 
            this.btnRestaurarRespaldo.BackColor = System.Drawing.Color.Transparent;
            this.btnRestaurarRespaldo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnRestaurarRespaldo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurarRespaldo.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnRestaurarRespaldo.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnRestaurarRespaldo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurarRespaldo.Image = null;
            this.btnRestaurarRespaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestaurarRespaldo.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnRestaurarRespaldo.Location = new System.Drawing.Point(412, 214);
            this.btnRestaurarRespaldo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRestaurarRespaldo.Name = "btnRestaurarRespaldo";
            this.btnRestaurarRespaldo.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnRestaurarRespaldo.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnRestaurarRespaldo.Size = new System.Drawing.Size(370, 51);
            this.btnRestaurarRespaldo.TabIndex = 22;
            this.btnRestaurarRespaldo.Text = "Restaurar desde Respaldo";
            this.btnRestaurarRespaldo.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnRestaurarRespaldo.Click += new System.EventHandler(this.btnRestaurarRespaldo_Click);
            // 
            // btnCrearRespaldo
            // 
            this.btnCrearRespaldo.BackColor = System.Drawing.Color.Transparent;
            this.btnCrearRespaldo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnCrearRespaldo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearRespaldo.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnCrearRespaldo.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnCrearRespaldo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearRespaldo.Image = null;
            this.btnCrearRespaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearRespaldo.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnCrearRespaldo.Location = new System.Drawing.Point(27, 214);
            this.btnCrearRespaldo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCrearRespaldo.Name = "btnCrearRespaldo";
            this.btnCrearRespaldo.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnCrearRespaldo.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnCrearRespaldo.Size = new System.Drawing.Size(372, 51);
            this.btnCrearRespaldo.TabIndex = 21;
            this.btnCrearRespaldo.Text = "Crear Respaldo Ahora";
            this.btnCrearRespaldo.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnCrearRespaldo.Click += new System.EventHandler(this.btnCrearRespaldo_Click);
            // 
            // lblTamañoRespaldo
            // 
            this.lblTamañoRespaldo.AutoSize = true;
            this.lblTamañoRespaldo.BackColor = System.Drawing.Color.Transparent;
            this.lblTamañoRespaldo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamañoRespaldo.ForeColor = System.Drawing.Color.White;
            this.lblTamañoRespaldo.Location = new System.Drawing.Point(368, 158);
            this.lblTamañoRespaldo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTamañoRespaldo.Name = "lblTamañoRespaldo";
            this.lblTamañoRespaldo.Size = new System.Drawing.Size(97, 28);
            this.lblTamañoRespaldo.TabIndex = 20;
            this.lblTamañoRespaldo.Text = "Tamaño: -";
            // 
            // lblUltimoRespaldo
            // 
            this.lblUltimoRespaldo.AutoSize = true;
            this.lblUltimoRespaldo.BackColor = System.Drawing.Color.Transparent;
            this.lblUltimoRespaldo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimoRespaldo.ForeColor = System.Drawing.Color.White;
            this.lblUltimoRespaldo.Location = new System.Drawing.Point(22, 158);
            this.lblUltimoRespaldo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUltimoRespaldo.Name = "lblUltimoRespaldo";
            this.lblUltimoRespaldo.Size = new System.Drawing.Size(243, 28);
            this.lblUltimoRespaldo.TabIndex = 19;
            this.lblUltimoRespaldo.Text = "Último Respaldo: Ninguno";
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbManual.ForeColor = System.Drawing.Color.White;
            this.rbManual.Location = new System.Drawing.Point(500, 111);
            this.rbManual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(102, 32);
            this.rbManual.TabIndex = 17;
            this.rbManual.Text = "Manual";
            this.rbManual.UseVisualStyleBackColor = true;
            this.rbManual.CheckedChanged += new System.EventHandler(this.rbManual_CheckedChanged);
            // 
            // rbMensual
            // 
            this.rbMensual.AutoSize = true;
            this.rbMensual.Checked = true;
            this.rbMensual.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMensual.ForeColor = System.Drawing.Color.White;
            this.rbMensual.Location = new System.Drawing.Point(372, 111);
            this.rbMensual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbMensual.Name = "rbMensual";
            this.rbMensual.Size = new System.Drawing.Size(115, 32);
            this.rbMensual.TabIndex = 16;
            this.rbMensual.TabStop = true;
            this.rbMensual.Text = "Mensual ";
            this.rbMensual.UseVisualStyleBackColor = true;
            this.rbMensual.CheckedChanged += new System.EventHandler(this.rbMensual_CheckedChanged);
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.BackColor = System.Drawing.Color.Transparent;
            this.lblFrecuencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrecuencia.ForeColor = System.Drawing.Color.White;
            this.lblFrecuencia.Location = new System.Drawing.Point(22, 114);
            this.lblFrecuencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(348, 28);
            this.lblFrecuencia.TabIndex = 15;
            this.lblFrecuencia.Text = "Frecuencia de respaldo automático:";
            // 
            // btnExaminarRuta
            // 
            this.btnExaminarRuta.BackColor = System.Drawing.Color.Transparent;
            this.btnExaminarRuta.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnExaminarRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminarRuta.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnExaminarRuta.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnExaminarRuta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExaminarRuta.Image = null;
            this.btnExaminarRuta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExaminarRuta.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnExaminarRuta.Location = new System.Drawing.Point(615, 51);
            this.btnExaminarRuta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExaminarRuta.Name = "btnExaminarRuta";
            this.btnExaminarRuta.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnExaminarRuta.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnExaminarRuta.Size = new System.Drawing.Size(168, 51);
            this.btnExaminarRuta.TabIndex = 14;
            this.btnExaminarRuta.Text = "Examinar";
            this.btnExaminarRuta.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnExaminarRuta.Click += new System.EventHandler(this.btnExaminarRuta_Click);
            // 
            // txtRutaRespaldos
            // 
            this.txtRutaRespaldos.BackColor = System.Drawing.Color.White;
            this.txtRutaRespaldos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaRespaldos.Location = new System.Drawing.Point(27, 58);
            this.txtRutaRespaldos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRutaRespaldos.Name = "txtRutaRespaldos";
            this.txtRutaRespaldos.Size = new System.Drawing.Size(564, 33);
            this.txtRutaRespaldos.TabIndex = 13;
            // 
            // lblRutaRespaldos
            // 
            this.lblRutaRespaldos.AutoSize = true;
            this.lblRutaRespaldos.BackColor = System.Drawing.Color.Transparent;
            this.lblRutaRespaldos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRutaRespaldos.ForeColor = System.Drawing.Color.White;
            this.lblRutaRespaldos.Location = new System.Drawing.Point(21, 25);
            this.lblRutaRespaldos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRutaRespaldos.Name = "lblRutaRespaldos";
            this.lblRutaRespaldos.Size = new System.Drawing.Size(186, 28);
            this.lblRutaRespaldos.TabIndex = 12;
            this.lblRutaRespaldos.Text = "Ruta de respaldos:";
            // 
            // pnl3
            // 
            this.pnl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl3.Controls.Add(this.lblTitulo3);
            this.pnl3.Controls.Add(this.pnl3B);
            this.pnl3.Location = new System.Drawing.Point(27, 391);
            this.pnl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(820, 345);
            this.pnl3.TabIndex = 2;
            // 
            // lblTitulo3
            // 
            this.lblTitulo3.AutoSize = true;
            this.lblTitulo3.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo3.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo3.ForeColor = System.Drawing.Color.White;
            this.lblTitulo3.Location = new System.Drawing.Point(334, 11);
            this.lblTitulo3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo3.Name = "lblTitulo3";
            this.lblTitulo3.Size = new System.Drawing.Size(141, 27);
            this.lblTitulo3.TabIndex = 2;
            this.lblTitulo3.Text = "LECTOR RFID ";
            this.lblTitulo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl3B
            // 
            this.pnl3B.BackColor = System.Drawing.Color.Transparent;
            this.pnl3B.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnl3B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl3B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl3B.Controls.Add(this.btnProbarLector);
            this.pnl3B.Controls.Add(this.btnConfigurarRFID);
            this.pnl3B.Controls.Add(this.lblEstadoRFID);
            this.pnl3B.Controls.Add(this.cboBaudRate);
            this.pnl3B.Controls.Add(this.lblBaudRate);
            this.pnl3B.Controls.Add(this.btnDetectarPuertos);
            this.pnl3B.Controls.Add(this.cboPuertoRFID);
            this.pnl3B.Controls.Add(this.lblPuertoCOM);
            this.pnl3B.Location = new System.Drawing.Point(4, 42);
            this.pnl3B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl3B.Name = "pnl3B";
            this.pnl3B.Size = new System.Drawing.Size(808, 296);
            this.pnl3B.TabIndex = 6;
            // 
            // btnProbarLector
            // 
            this.btnProbarLector.BackColor = System.Drawing.Color.Transparent;
            this.btnProbarLector.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnProbarLector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProbarLector.Enabled = false;
            this.btnProbarLector.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnProbarLector.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnProbarLector.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProbarLector.Image = null;
            this.btnProbarLector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProbarLector.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnProbarLector.Location = new System.Drawing.Point(411, 217);
            this.btnProbarLector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProbarLector.Name = "btnProbarLector";
            this.btnProbarLector.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnProbarLector.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnProbarLector.Size = new System.Drawing.Size(372, 43);
            this.btnProbarLector.TabIndex = 21;
            this.btnProbarLector.Text = "Probar Lector";
            this.btnProbarLector.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnConfigurarRFID
            // 
            this.btnConfigurarRFID.BackColor = System.Drawing.Color.Transparent;
            this.btnConfigurarRFID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnConfigurarRFID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigurarRFID.Enabled = false;
            this.btnConfigurarRFID.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnConfigurarRFID.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnConfigurarRFID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnConfigurarRFID.Image = null;
            this.btnConfigurarRFID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigurarRFID.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnConfigurarRFID.Location = new System.Drawing.Point(27, 217);
            this.btnConfigurarRFID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConfigurarRFID.Name = "btnConfigurarRFID";
            this.btnConfigurarRFID.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnConfigurarRFID.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnConfigurarRFID.Size = new System.Drawing.Size(372, 43);
            this.btnConfigurarRFID.TabIndex = 20;
            this.btnConfigurarRFID.Text = "Configurar";
            this.btnConfigurarRFID.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblEstadoRFID
            // 
            this.lblEstadoRFID.AutoSize = true;
            this.lblEstadoRFID.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoRFID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoRFID.ForeColor = System.Drawing.Color.White;
            this.lblEstadoRFID.Location = new System.Drawing.Point(276, 152);
            this.lblEstadoRFID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstadoRFID.Name = "lblEstadoRFID";
            this.lblEstadoRFID.Size = new System.Drawing.Size(235, 28);
            this.lblEstadoRFID.TabIndex = 19;
            this.lblEstadoRFID.Text = "Estado: No configurado";
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.BackColor = System.Drawing.Color.White;
            this.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaudRate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboBaudRate.Location = new System.Drawing.Point(27, 148);
            this.cboBaudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(223, 36);
            this.cboBaudRate.TabIndex = 18;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.BackColor = System.Drawing.Color.Transparent;
            this.lblBaudRate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBaudRate.ForeColor = System.Drawing.Color.White;
            this.lblBaudRate.Location = new System.Drawing.Point(21, 115);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(226, 28);
            this.lblBaudRate.TabIndex = 17;
            this.lblBaudRate.Text = "Velocidad (Baud Rate):";
            // 
            // btnDetectarPuertos
            // 
            this.btnDetectarPuertos.BackColor = System.Drawing.Color.Transparent;
            this.btnDetectarPuertos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnDetectarPuertos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetectarPuertos.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnDetectarPuertos.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnDetectarPuertos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetectarPuertos.Image = null;
            this.btnDetectarPuertos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetectarPuertos.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnDetectarPuertos.Location = new System.Drawing.Point(282, 46);
            this.btnDetectarPuertos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDetectarPuertos.Name = "btnDetectarPuertos";
            this.btnDetectarPuertos.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnDetectarPuertos.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnDetectarPuertos.Size = new System.Drawing.Size(261, 51);
            this.btnDetectarPuertos.TabIndex = 16;
            this.btnDetectarPuertos.Text = "Detectar Automáticamente";
            this.btnDetectarPuertos.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cboPuertoRFID
            // 
            this.cboPuertoRFID.BackColor = System.Drawing.Color.White;
            this.cboPuertoRFID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuertoRFID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPuertoRFID.FormattingEnabled = true;
            this.cboPuertoRFID.Location = new System.Drawing.Point(27, 55);
            this.cboPuertoRFID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPuertoRFID.Name = "cboPuertoRFID";
            this.cboPuertoRFID.Size = new System.Drawing.Size(223, 36);
            this.cboPuertoRFID.TabIndex = 15;
            // 
            // lblPuertoCOM
            // 
            this.lblPuertoCOM.AutoSize = true;
            this.lblPuertoCOM.BackColor = System.Drawing.Color.Transparent;
            this.lblPuertoCOM.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPuertoCOM.ForeColor = System.Drawing.Color.White;
            this.lblPuertoCOM.Location = new System.Drawing.Point(21, 22);
            this.lblPuertoCOM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPuertoCOM.Name = "lblPuertoCOM";
            this.lblPuertoCOM.Size = new System.Drawing.Size(133, 28);
            this.lblPuertoCOM.TabIndex = 14;
            this.lblPuertoCOM.Text = "Puerto COM:";
            // 
            // pnl4
            // 
            this.pnl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl4.Controls.Add(this.lblTitulo4);
            this.pnl4.Controls.Add(this.pnl4B);
            this.pnl4.Location = new System.Drawing.Point(885, 391);
            this.pnl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(820, 345);
            this.pnl4.TabIndex = 3;
            // 
            // lblTitulo4
            // 
            this.lblTitulo4.AutoSize = true;
            this.lblTitulo4.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo4.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo4.ForeColor = System.Drawing.Color.White;
            this.lblTitulo4.Location = new System.Drawing.Point(225, 11);
            this.lblTitulo4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo4.Name = "lblTitulo4";
            this.lblTitulo4.Size = new System.Drawing.Size(339, 27);
            this.lblTitulo4.TabIndex = 2;
            this.lblTitulo4.Text = "INFORMACIÓN DE LA APLICACIÓN";
            this.lblTitulo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl4B
            // 
            this.pnl4B.BackColor = System.Drawing.Color.Transparent;
            this.pnl4B.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnl4B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl4B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl4B.Controls.Add(this.lblUILibrary);
            this.pnl4B.Controls.Add(this.lblFramework);
            this.pnl4B.Controls.Add(this.lblFechaCompilacion);
            this.pnl4B.Controls.Add(this.lblVersion);
            this.pnl4B.Location = new System.Drawing.Point(4, 42);
            this.pnl4B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl4B.Name = "pnl4B";
            this.pnl4B.Size = new System.Drawing.Size(808, 296);
            this.pnl4B.TabIndex = 6;
            // 
            // lblUILibrary
            // 
            this.lblUILibrary.AutoSize = true;
            this.lblUILibrary.BackColor = System.Drawing.Color.Transparent;
            this.lblUILibrary.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUILibrary.ForeColor = System.Drawing.Color.White;
            this.lblUILibrary.Location = new System.Drawing.Point(231, 200);
            this.lblUILibrary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUILibrary.Name = "lblUILibrary";
            this.lblUILibrary.Size = new System.Drawing.Size(297, 30);
            this.lblUILibrary.TabIndex = 16;
            this.lblUILibrary.Text = "UI Library:              RealTaiizor";
            // 
            // lblFramework
            // 
            this.lblFramework.AutoSize = true;
            this.lblFramework.BackColor = System.Drawing.Color.Transparent;
            this.lblFramework.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFramework.ForeColor = System.Drawing.Color.White;
            this.lblFramework.Location = new System.Drawing.Point(231, 149);
            this.lblFramework.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFramework.Name = "lblFramework";
            this.lblFramework.Size = new System.Drawing.Size(393, 30);
            this.lblFramework.TabIndex = 15;
            this.lblFramework.Text = "Framework:            .NET Framework 4.8";
            // 
            // lblFechaCompilacion
            // 
            this.lblFechaCompilacion.AutoSize = true;
            this.lblFechaCompilacion.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaCompilacion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFechaCompilacion.ForeColor = System.Drawing.Color.White;
            this.lblFechaCompilacion.Location = new System.Drawing.Point(231, 98);
            this.lblFechaCompilacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaCompilacion.Name = "lblFechaCompilacion";
            this.lblFechaCompilacion.Size = new System.Drawing.Size(353, 30);
            this.lblFechaCompilacion.TabIndex = 14;
            this.lblFechaCompilacion.Text = "Fecha de compilación:  16/11/2025";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(231, 52);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(279, 30);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "Versión:                      2.0.0";
            // 
            // ucConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.pnl4);
            this.Controls.Add(this.pnl3);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.pnl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucConfiguracion";
            this.Padding = new System.Windows.Forms.Padding(22, 23, 22, 23);
            this.Size = new System.Drawing.Size(1732, 762);
            this.Load += new System.EventHandler(this.ucConfiguracion_Load);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl1B.ResumeLayout(false);
            this.pnl1B.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.pnl2B.ResumeLayout(false);
            this.pnl2B.PerformLayout();
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.pnl3B.ResumeLayout(false);
            this.pnl3B.PerformLayout();
            this.pnl4.ResumeLayout(false);
            this.pnl4.PerformLayout();
            this.pnl4B.ResumeLayout(false);
            this.pnl4B.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private ReaLTaiizor.Controls.BigLabel lblTitulo1;
        private System.Windows.Forms.Panel pnl1B;
        private System.Windows.Forms.Panel pnl2;
        private ReaLTaiizor.Controls.BigLabel lblTitulo2;
        private System.Windows.Forms.Panel pnl2B;
        private System.Windows.Forms.Panel pnl3;
        private ReaLTaiizor.Controls.BigLabel lblTitulo3;
        private System.Windows.Forms.Panel pnl3B;
        private System.Windows.Forms.Panel pnl4;
        private ReaLTaiizor.Controls.BigLabel lblTitulo4;
        private System.Windows.Forms.Panel pnl4B;
        private ReaLTaiizor.Controls.BigLabel lblEstadoConexion;
        private ReaLTaiizor.Controls.Button btnGuardarConexion;
        private ReaLTaiizor.Controls.Button btnProbarConexion;
        private System.Windows.Forms.TextBox txtCadenaConexion;
        private ReaLTaiizor.Controls.BigLabel lblCadenaConexion;
        private ReaLTaiizor.Controls.Button btnRestaurarRespaldo;
        private ReaLTaiizor.Controls.Button btnCrearRespaldo;
        private ReaLTaiizor.Controls.BigLabel lblTamañoRespaldo;
        private ReaLTaiizor.Controls.BigLabel lblUltimoRespaldo;
        private System.Windows.Forms.RadioButton rbMensual;
        private System.Windows.Forms.RadioButton rbManual;
        private ReaLTaiizor.Controls.BigLabel lblFrecuencia;
        private ReaLTaiizor.Controls.Button btnExaminarRuta;
        private System.Windows.Forms.TextBox txtRutaRespaldos;
        private ReaLTaiizor.Controls.BigLabel lblRutaRespaldos;
        private ReaLTaiizor.Controls.Button btnProbarLector;
        private ReaLTaiizor.Controls.Button btnConfigurarRFID;
        private ReaLTaiizor.Controls.BigLabel lblEstadoRFID;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private ReaLTaiizor.Controls.BigLabel lblBaudRate;
        private ReaLTaiizor.Controls.Button btnDetectarPuertos;
        private System.Windows.Forms.ComboBox cboPuertoRFID;
        private ReaLTaiizor.Controls.BigLabel lblPuertoCOM;
        private ReaLTaiizor.Controls.BigLabel lblUILibrary;
        private ReaLTaiizor.Controls.BigLabel lblFramework;
        private ReaLTaiizor.Controls.BigLabel lblFechaCompilacion;
        private ReaLTaiizor.Controls.BigLabel lblVersion;
    }
}
