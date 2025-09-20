
namespace app
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Label();
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.ssVertical = new ReaLTaiizor.Controls.SpaceSeparatorVertical();
            this.btnInfo = new System.Windows.Forms.Label();
            this.ssLogo = new ReaLTaiizor.Controls.SpaceSeparatorHorizontal();
            this.ssSidebar = new ReaLTaiizor.Controls.SpaceSeparatorVertical();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pHome = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Label();
            this.pRegistros = new System.Windows.Forms.Panel();
            this.btnRegistros = new System.Windows.Forms.Label();
            this.pReportes = new System.Windows.Forms.Panel();
            this.btnReportes = new System.Windows.Forms.Label();
            this.pAdmin = new System.Windows.Forms.Panel();
            this.btnAdmin = new System.Windows.Forms.Label();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.txtProyeccion = new System.Windows.Forms.TextBox();
            this.ssTitulo = new ReaLTaiizor.Controls.SpaceSeparatorHorizontal();
            this.btnProyeccion = new ReaLTaiizor.Controls.Button();
            this.gbxDuracion = new ReaLTaiizor.Controls.ThunderGroupBox();
            this.pbxDuracion = new System.Windows.Forms.Label();
            this.pbxTitulo = new System.Windows.Forms.PictureBox();
            this.pbxEmpresas = new System.Windows.Forms.PictureBox();
            this.gbxEstado = new ReaLTaiizor.Controls.ThunderGroupBox();
            this.lblEstado = new ReaLTaiizor.Controls.BigLabel();
            this.pbxEstado = new System.Windows.Forms.Label();
            this.ssSuperior = new ReaLTaiizor.Controls.SpaceSeparatorHorizontal();
            this.cbLugar = new ReaLTaiizor.Controls.PoisonComboBox();
            this.btnServicio = new ReaLTaiizor.Controls.Button();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.cHome = new ReaLTaiizor.Controls.ParrotControlEllipse();
            this.cRegistros = new ReaLTaiizor.Controls.ParrotControlEllipse();
            this.cReportes = new ReaLTaiizor.Controls.ParrotControlEllipse();
            this.cAdmin = new ReaLTaiizor.Controls.ParrotControlEllipse();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.lblProyeccion = new ReaLTaiizor.Controls.SmallLabel();
            this.lblLugar = new ReaLTaiizor.Controls.SmallLabel();
            this.spaceSeparatorVertical1 = new ReaLTaiizor.Controls.SpaceSeparatorVertical();
            this.gbxProgreso = new ReaLTaiizor.Controls.ThunderGroupBox();
            this.bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlBarra.SuspendLayout();
            this.pnlLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pHome.SuspendLayout();
            this.pRegistros.SuspendLayout();
            this.pReportes.SuspendLayout();
            this.pAdmin.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.gbxDuracion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEmpresas)).BeginInit();
            this.gbxEstado.SuspendLayout();
            this.gbxProgreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.pnlBarra.Controls.Add(this.btnSalir);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(0, 0);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(1280, 25);
            this.pnlBarra.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.ForeColor = System.Drawing.Color.Transparent;
            this.btnSalir.Image = global::app.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(1251, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(29, 25);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlLateral
            // 
            this.pnlLateral.Controls.Add(this.ssVertical);
            this.pnlLateral.Controls.Add(this.btnInfo);
            this.pnlLateral.Controls.Add(this.ssLogo);
            this.pnlLateral.Controls.Add(this.ssSidebar);
            this.pnlLateral.Controls.Add(this.pbxLogo);
            this.pnlLateral.Controls.Add(this.pHome);
            this.pnlLateral.Controls.Add(this.pRegistros);
            this.pnlLateral.Controls.Add(this.pReportes);
            this.pnlLateral.Controls.Add(this.pAdmin);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 25);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(125, 695);
            this.pnlLateral.TabIndex = 2;
            // 
            // ssVertical
            // 
            this.ssVertical.Customization = "Kioq/yoqKv8jIyP/Kioq/w==";
            this.ssVertical.Font = new System.Drawing.Font("Verdana", 8F);
            this.ssVertical.Image = null;
            this.ssVertical.Location = new System.Drawing.Point(118, 6);
            this.ssVertical.Name = "ssVertical";
            this.ssVertical.NoRounding = false;
            this.ssVertical.Size = new System.Drawing.Size(4, 683);
            this.ssVertical.TabIndex = 3;
            this.ssVertical.Transparent = false;
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfo.ForeColor = System.Drawing.Color.Transparent;
            this.btnInfo.Image = global::app.Properties.Resources.info;
            this.btnInfo.Location = new System.Drawing.Point(19, 605);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 81);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ssLogo
            // 
            this.ssLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(157)))));
            this.ssLogo.Customization = "nfP9/53z/f+d8/3/nfP9/w==";
            this.ssLogo.Font = new System.Drawing.Font("Verdana", 8F);
            this.ssLogo.Image = null;
            this.ssLogo.Location = new System.Drawing.Point(12, 138);
            this.ssLogo.Name = "ssLogo";
            this.ssLogo.NoRounding = false;
            this.ssLogo.Size = new System.Drawing.Size(100, 4);
            this.ssLogo.TabIndex = 0;
            this.ssLogo.Text = "spaceSeparatorHorizontal1";
            this.ssLogo.Transparent = false;
            // 
            // ssSidebar
            // 
            this.ssSidebar.Customization = "Kioq/yoqKv8jIyP/Kioq/w==";
            this.ssSidebar.Font = new System.Drawing.Font("Verdana", 8F);
            this.ssSidebar.Image = null;
            this.ssSidebar.Location = new System.Drawing.Point(9, 170);
            this.ssSidebar.Name = "ssSidebar";
            this.ssSidebar.NoRounding = false;
            this.ssSidebar.Size = new System.Drawing.Size(4, 53);
            this.ssSidebar.TabIndex = 3;
            this.ssSidebar.Transparent = false;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::app.Properties.Resources.logo;
            this.pbxLogo.Location = new System.Drawing.Point(0, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(112, 120);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 2;
            this.pbxLogo.TabStop = false;
            // 
            // pHome
            // 
            this.pHome.BackColor = System.Drawing.Color.Transparent;
            this.pHome.Controls.Add(this.btnHome);
            this.pHome.Location = new System.Drawing.Point(19, 156);
            this.pHome.Name = "pHome";
            this.pHome.Size = new System.Drawing.Size(78, 81);
            this.pHome.TabIndex = 10;
            this.pHome.Click += new System.EventHandler(this.btnHome_Click);
            this.pHome.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.pHome.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHome.ForeColor = System.Drawing.Color.Transparent;
            this.btnHome.Image = global::app.Properties.Resources.home;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(78, 81);
            this.btnHome.TabIndex = 1;
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.btnHome.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // pRegistros
            // 
            this.pRegistros.BackColor = System.Drawing.Color.Transparent;
            this.pRegistros.Controls.Add(this.btnRegistros);
            this.pRegistros.Location = new System.Drawing.Point(22, 237);
            this.pRegistros.Name = "pRegistros";
            this.pRegistros.Size = new System.Drawing.Size(75, 81);
            this.pRegistros.TabIndex = 11;
            this.pRegistros.Click += new System.EventHandler(this.btnRegistros_Click);
            this.pRegistros.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.pRegistros.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // btnRegistros
            // 
            this.btnRegistros.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegistros.ForeColor = System.Drawing.Color.Transparent;
            this.btnRegistros.Image = global::app.Properties.Resources.registro;
            this.btnRegistros.Location = new System.Drawing.Point(0, 0);
            this.btnRegistros.Name = "btnRegistros";
            this.btnRegistros.Size = new System.Drawing.Size(75, 81);
            this.btnRegistros.TabIndex = 1;
            this.btnRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRegistros.Click += new System.EventHandler(this.btnRegistros_Click);
            this.btnRegistros.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.btnRegistros.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // pReportes
            // 
            this.pReportes.BackColor = System.Drawing.Color.Transparent;
            this.pReportes.Controls.Add(this.btnReportes);
            this.pReportes.Location = new System.Drawing.Point(22, 318);
            this.pReportes.Name = "pReportes";
            this.pReportes.Size = new System.Drawing.Size(75, 81);
            this.pReportes.TabIndex = 12;
            this.pReportes.Click += new System.EventHandler(this.btnReportes_Click);
            this.pReportes.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.pReportes.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.Transparent;
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReportes.ForeColor = System.Drawing.Color.Transparent;
            this.btnReportes.Image = global::app.Properties.Resources.Reporte;
            this.btnReportes.Location = new System.Drawing.Point(0, 0);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(75, 81);
            this.btnReportes.TabIndex = 1;
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            this.btnReportes.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.btnReportes.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // pAdmin
            // 
            this.pAdmin.BackColor = System.Drawing.Color.Transparent;
            this.pAdmin.Controls.Add(this.btnAdmin);
            this.pAdmin.Location = new System.Drawing.Point(19, 524);
            this.pAdmin.Name = "pAdmin";
            this.pAdmin.Size = new System.Drawing.Size(75, 81);
            this.pAdmin.TabIndex = 13;
            this.pAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            this.pAdmin.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.pAdmin.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.btnAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdmin.ForeColor = System.Drawing.Color.Transparent;
            this.btnAdmin.Image = global::app.Properties.Resources.admin;
            this.btnAdmin.Location = new System.Drawing.Point(0, 0);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(75, 81);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            this.btnAdmin.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.btnAdmin.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.gbxProgreso);
            this.pnlSuperior.Controls.Add(this.spaceSeparatorVertical1);
            this.pnlSuperior.Controls.Add(this.lblLugar);
            this.pnlSuperior.Controls.Add(this.lblProyeccion);
            this.pnlSuperior.Controls.Add(this.txtProyeccion);
            this.pnlSuperior.Controls.Add(this.ssTitulo);
            this.pnlSuperior.Controls.Add(this.btnProyeccion);
            this.pnlSuperior.Controls.Add(this.gbxDuracion);
            this.pnlSuperior.Controls.Add(this.pbxTitulo);
            this.pnlSuperior.Controls.Add(this.pbxEmpresas);
            this.pnlSuperior.Controls.Add(this.gbxEstado);
            this.pnlSuperior.Controls.Add(this.ssSuperior);
            this.pnlSuperior.Controls.Add(this.cbLugar);
            this.pnlSuperior.Controls.Add(this.btnServicio);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(125, 25);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1155, 142);
            this.pnlSuperior.TabIndex = 3;
            // 
            // txtProyeccion
            // 
            this.txtProyeccion.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtProyeccion.Location = new System.Drawing.Point(304, 28);
            this.txtProyeccion.Name = "txtProyeccion";
            this.txtProyeccion.Size = new System.Drawing.Size(121, 36);
            this.txtProyeccion.TabIndex = 0;
            // 
            // ssTitulo
            // 
            this.ssTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(157)))));
            this.ssTitulo.Customization = "JND//yTQ//8k0P//JND//w==";
            this.ssTitulo.Font = new System.Drawing.Font("Verdana", 8F);
            this.ssTitulo.Image = null;
            this.ssTitulo.Location = new System.Drawing.Point(27, 74);
            this.ssTitulo.Name = "ssTitulo";
            this.ssTitulo.NoRounding = false;
            this.ssTitulo.Size = new System.Drawing.Size(220, 4);
            this.ssTitulo.TabIndex = 14;
            this.ssTitulo.Text = "spaceSeparatorHorizontal1";
            this.ssTitulo.Transparent = false;
            // 
            // btnProyeccion
            // 
            this.btnProyeccion.BackColor = System.Drawing.Color.Transparent;
            this.btnProyeccion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnProyeccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProyeccion.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnProyeccion.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnProyeccion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProyeccion.Image = null;
            this.btnProyeccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProyeccion.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnProyeccion.Location = new System.Drawing.Point(441, 28);
            this.btnProyeccion.Name = "btnProyeccion";
            this.btnProyeccion.Padding = new System.Windows.Forms.Padding(14, 0, 12, 0);
            this.btnProyeccion.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnProyeccion.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnProyeccion.Size = new System.Drawing.Size(155, 35);
            this.btnProyeccion.TabIndex = 0;
            this.btnProyeccion.Text = "Cargar Proyeccion";
            this.btnProyeccion.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // gbxDuracion
            // 
            this.gbxDuracion.BackColor = System.Drawing.Color.Transparent;
            this.gbxDuracion.BodyColorA = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.gbxDuracion.BodyColorB = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.gbxDuracion.BodyColorC = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.gbxDuracion.BodyColorD = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.gbxDuracion.Controls.Add(this.bigLabel1);
            this.gbxDuracion.Controls.Add(this.pbxDuracion);
            this.gbxDuracion.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDuracion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gbxDuracion.Location = new System.Drawing.Point(800, 36);
            this.gbxDuracion.Name = "gbxDuracion";
            this.gbxDuracion.Size = new System.Drawing.Size(160, 77);
            this.gbxDuracion.TabIndex = 4;
            this.gbxDuracion.Text = "        Duracion del Servicio";
            // 
            // pbxDuracion
            // 
            this.pbxDuracion.BackColor = System.Drawing.Color.Transparent;
            this.pbxDuracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxDuracion.ForeColor = System.Drawing.Color.Transparent;
            this.pbxDuracion.Image = global::app.Properties.Resources.reloj;
            this.pbxDuracion.Location = new System.Drawing.Point(14, 37);
            this.pbxDuracion.Name = "pbxDuracion";
            this.pbxDuracion.Size = new System.Drawing.Size(29, 25);
            this.pbxDuracion.TabIndex = 1;
            this.pbxDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxTitulo
            // 
            this.pbxTitulo.BackColor = System.Drawing.Color.Transparent;
            this.pbxTitulo.BackgroundImage = global::app.Properties.Resources.cda;
            this.pbxTitulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxTitulo.Location = new System.Drawing.Point(6, 16);
            this.pbxTitulo.Name = "pbxTitulo";
            this.pbxTitulo.Size = new System.Drawing.Size(262, 60);
            this.pbxTitulo.TabIndex = 7;
            this.pbxTitulo.TabStop = false;
            // 
            // pbxEmpresas
            // 
            this.pbxEmpresas.BackColor = System.Drawing.Color.Transparent;
            this.pbxEmpresas.BackgroundImage = global::app.Properties.Resources.roemmers_southex;
            this.pbxEmpresas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxEmpresas.Location = new System.Drawing.Point(48, 74);
            this.pbxEmpresas.Name = "pbxEmpresas";
            this.pbxEmpresas.Size = new System.Drawing.Size(180, 46);
            this.pbxEmpresas.TabIndex = 6;
            this.pbxEmpresas.TabStop = false;
            // 
            // gbxEstado
            // 
            this.gbxEstado.BackColor = System.Drawing.Color.Transparent;
            this.gbxEstado.BodyColorA = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.gbxEstado.BodyColorB = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.gbxEstado.BodyColorC = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.gbxEstado.BodyColorD = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.gbxEstado.Controls.Add(this.lblEstado);
            this.gbxEstado.Controls.Add(this.pbxEstado);
            this.gbxEstado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxEstado.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gbxEstado.Location = new System.Drawing.Point(618, 36);
            this.gbxEstado.Name = "gbxEstado";
            this.gbxEstado.Size = new System.Drawing.Size(160, 77);
            this.gbxEstado.TabIndex = 3;
            this.gbxEstado.Text = "        Estado del Servicio";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(40, 35);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(102, 25);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "INACTIVO";
            // 
            // pbxEstado
            // 
            this.pbxEstado.BackColor = System.Drawing.Color.Transparent;
            this.pbxEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxEstado.ForeColor = System.Drawing.Color.Transparent;
            this.pbxEstado.Image = global::app.Properties.Resources.inactivo;
            this.pbxEstado.Location = new System.Drawing.Point(14, 37);
            this.pbxEstado.Name = "pbxEstado";
            this.pbxEstado.Size = new System.Drawing.Size(29, 25);
            this.pbxEstado.TabIndex = 1;
            this.pbxEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pbxEstado.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ssSuperior
            // 
            this.ssSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(157)))));
            this.ssSuperior.Customization = "nfP9/53z/f+d8/3/nfP9/w==";
            this.ssSuperior.Font = new System.Drawing.Font("Verdana", 8F);
            this.ssSuperior.Image = null;
            this.ssSuperior.Location = new System.Drawing.Point(6, 138);
            this.ssSuperior.Name = "ssSuperior";
            this.ssSuperior.NoRounding = false;
            this.ssSuperior.Size = new System.Drawing.Size(1137, 4);
            this.ssSuperior.TabIndex = 0;
            this.ssSuperior.Transparent = false;
            // 
            // cbLugar
            // 
            this.cbLugar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.cbLugar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cbLugar.FontSize = ReaLTaiizor.Extension.Poison.PoisonComboBoxSize.Tall;
            this.cbLugar.FormattingEnabled = true;
            this.cbLugar.ItemHeight = 29;
            this.cbLugar.Items.AddRange(new object[] {
            "Comedor",
            "Quincho"});
            this.cbLugar.Location = new System.Drawing.Point(304, 85);
            this.cbLugar.Name = "cbLugar";
            this.cbLugar.Size = new System.Drawing.Size(121, 35);
            this.cbLugar.TabIndex = 0;
            this.cbLugar.UseSelectable = true;
            // 
            // btnServicio
            // 
            this.btnServicio.BackColor = System.Drawing.Color.Transparent;
            this.btnServicio.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServicio.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnServicio.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnServicio.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicio.Image = null;
            this.btnServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicio.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnServicio.Location = new System.Drawing.Point(441, 85);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Padding = new System.Windows.Forms.Padding(14, 0, 12, 0);
            this.btnServicio.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnServicio.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnServicio.Size = new System.Drawing.Size(155, 35);
            this.btnServicio.TabIndex = 0;
            this.btnServicio.Text = " Iniciar Servicio";
            this.btnServicio.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(125, 167);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1155, 553);
            this.pnlPrincipal.TabIndex = 4;
            // 
            // cHome
            // 
            this.cHome.CornerRadius = 20;
            this.cHome.EffectedControl = this.pHome;
            // 
            // cRegistros
            // 
            this.cRegistros.CornerRadius = 20;
            this.cRegistros.EffectedControl = this.pRegistros;
            // 
            // cReportes
            // 
            this.cReportes.CornerRadius = 20;
            this.cReportes.EffectedControl = this.pReportes;
            // 
            // cAdmin
            // 
            this.cAdmin.CornerRadius = 20;
            this.cAdmin.EffectedControl = this.pAdmin;
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.Color.White;
            this.bigLabel1.Location = new System.Drawing.Point(40, 35);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(88, 25);
            this.bigLabel1.TabIndex = 2;
            this.bigLabel1.Text = "00:00:00";
            // 
            // lblProyeccion
            // 
            this.lblProyeccion.AutoSize = true;
            this.lblProyeccion.BackColor = System.Drawing.Color.Transparent;
            this.lblProyeccion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblProyeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(2)))), ((int)(((byte)(50)))), ((int)(((byte)(34)))));
            this.lblProyeccion.Location = new System.Drawing.Point(301, 12);
            this.lblProyeccion.Name = "lblProyeccion";
            this.lblProyeccion.Size = new System.Drawing.Size(65, 13);
            this.lblProyeccion.TabIndex = 15;
            this.lblProyeccion.Text = "Proyeccion:";
            // 
            // lblLugar
            // 
            this.lblLugar.AutoSize = true;
            this.lblLugar.BackColor = System.Drawing.Color.Transparent;
            this.lblLugar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLugar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(2)))), ((int)(((byte)(50)))), ((int)(((byte)(34)))));
            this.lblLugar.Location = new System.Drawing.Point(301, 69);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(39, 13);
            this.lblLugar.TabIndex = 15;
            this.lblLugar.Text = "Lugar:";
            // 
            // spaceSeparatorVertical1
            // 
            this.spaceSeparatorVertical1.Customization = "Kioq/yoqKv8jIyP/Kioq/w==";
            this.spaceSeparatorVertical1.Font = new System.Drawing.Font("Verdana", 8F);
            this.spaceSeparatorVertical1.Image = null;
            this.spaceSeparatorVertical1.Location = new System.Drawing.Point(274, 6);
            this.spaceSeparatorVertical1.Name = "spaceSeparatorVertical1";
            this.spaceSeparatorVertical1.NoRounding = false;
            this.spaceSeparatorVertical1.Size = new System.Drawing.Size(4, 130);
            this.spaceSeparatorVertical1.TabIndex = 14;
            this.spaceSeparatorVertical1.Transparent = false;
            // 
            // gbxProgreso
            // 
            this.gbxProgreso.BackColor = System.Drawing.Color.Transparent;
            this.gbxProgreso.BodyColorA = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.gbxProgreso.BodyColorB = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.gbxProgreso.BodyColorC = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.gbxProgreso.BodyColorD = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.gbxProgreso.Controls.Add(this.bigLabel2);
            this.gbxProgreso.Controls.Add(this.label3);
            this.gbxProgreso.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxProgreso.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gbxProgreso.Location = new System.Drawing.Point(983, 36);
            this.gbxProgreso.Name = "gbxProgreso";
            this.gbxProgreso.Size = new System.Drawing.Size(160, 77);
            this.gbxProgreso.TabIndex = 4;
            this.gbxProgreso.Text = "       Progreso del Servicio";
            // 
            // bigLabel2
            // 
            this.bigLabel2.AutoSize = true;
            this.bigLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel2.ForeColor = System.Drawing.Color.White;
            this.bigLabel2.Location = new System.Drawing.Point(40, 35);
            this.bigLabel2.Name = "bigLabel2";
            this.bigLabel2.Size = new System.Drawing.Size(102, 25);
            this.bigLabel2.TabIndex = 2;
            this.bigLabel2.Text = "INACTIVO";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Image = global::app.Properties.Resources.inactivo;
            this.label3.Location = new System.Drawing.Point(14, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 25);
            this.label3.TabIndex = 1;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlLateral);
            this.Controls.Add(this.pnlBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlBarra.ResumeLayout(false);
            this.pnlLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pHome.ResumeLayout(false);
            this.pRegistros.ResumeLayout(false);
            this.pReportes.ResumeLayout(false);
            this.pAdmin.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.gbxDuracion.ResumeLayout(false);
            this.gbxDuracion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEmpresas)).EndInit();
            this.gbxEstado.ResumeLayout(false);
            this.gbxEstado.PerformLayout();
            this.gbxProgreso.ResumeLayout(false);
            this.gbxProgreso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.Panel pnlLateral;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox pbxLogo;
        private ReaLTaiizor.Controls.Button btnServicio;
        private ReaLTaiizor.Controls.PoisonComboBox cbLugar;
        private System.Windows.Forms.Panel pnlPrincipal;
        private ReaLTaiizor.Controls.SpaceSeparatorVertical ssSidebar;
        private ReaLTaiizor.Controls.SpaceSeparatorHorizontal ssSuperior;
        private ReaLTaiizor.Controls.SpaceSeparatorVertical ssVertical;
        private ReaLTaiizor.Controls.ParrotControlEllipse cHome;
        private System.Windows.Forms.Label btnHome;
        private System.Windows.Forms.Label btnReportes;
        private System.Windows.Forms.Label btnRegistros;
        private System.Windows.Forms.Label btnInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnAdmin;
        private System.Windows.Forms.Panel pHome;
        private System.Windows.Forms.Panel pRegistros;
        private System.Windows.Forms.Panel pReportes;
        private System.Windows.Forms.Panel pAdmin;
        private ReaLTaiizor.Controls.ParrotControlEllipse cRegistros;
        private ReaLTaiizor.Controls.ParrotControlEllipse cReportes;
        private ReaLTaiizor.Controls.ParrotControlEllipse cAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnSalir;
        private ReaLTaiizor.Controls.ThunderGroupBox gbxEstado;
        private System.Windows.Forms.Label pbxEstado;
        private ReaLTaiizor.Controls.BigLabel lblEstado;
        private ReaLTaiizor.Controls.ThunderGroupBox gbxDuracion;
        private System.Windows.Forms.Label pbxDuracion;
        private System.Windows.Forms.PictureBox pbxEmpresas;
        private System.Windows.Forms.PictureBox pbxTitulo;
        private ReaLTaiizor.Controls.SpaceSeparatorHorizontal ssTitulo;
        private ReaLTaiizor.Controls.SpaceSeparatorHorizontal ssLogo;
        private ReaLTaiizor.Controls.Button btnProyeccion;
        private System.Windows.Forms.TextBox txtProyeccion;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.SmallLabel lblProyeccion;
        private ReaLTaiizor.Controls.SmallLabel lblLugar;
        private ReaLTaiizor.Controls.SpaceSeparatorVertical spaceSeparatorVertical1;
        private ReaLTaiizor.Controls.ThunderGroupBox gbxProgreso;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private System.Windows.Forms.Label label3;
    }
}