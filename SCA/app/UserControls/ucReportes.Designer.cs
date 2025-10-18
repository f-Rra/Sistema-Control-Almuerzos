namespace app.UserControls
{
    partial class ucReportes
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.gbxPanelReportes = new System.Windows.Forms.GroupBox();
            this.pnlReportesA = new System.Windows.Forms.Panel();
            this.lblReportes = new ReaLTaiizor.Controls.BigLabel();
            this.pnlReportesB = new System.Windows.Forms.Panel();
            this.cbTipoReporte = new System.Windows.Forms.ComboBox();
            this.lblTipoReporte = new ReaLTaiizor.Controls.SmallLabel();
            this.btnGenerar = new ReaLTaiizor.Controls.Button();
            this.cbLugar = new System.Windows.Forms.ComboBox();
            this.lblLugar = new ReaLTaiizor.Controls.SmallLabel();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new ReaLTaiizor.Controls.SmallLabel();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new ReaLTaiizor.Controls.SmallLabel();
            this.btnExportar = new ReaLTaiizor.Controls.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.ssPanel = new ReaLTaiizor.Controls.SpaceSeparatorVertical();
            this.pbxTitulo = new System.Windows.Forms.PictureBox();
            this.gbxReportes = new System.Windows.Forms.GroupBox();
            this.pnlReportesC = new System.Windows.Forms.Panel();
            this.pnlReportesD = new System.Windows.Forms.Panel();
            this.pnlSuperior.SuspendLayout();
            this.gbxPanelReportes.SuspendLayout();
            this.pnlReportesA.SuspendLayout();
            this.pnlReportesB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitulo)).BeginInit();
            this.gbxReportes.SuspendLayout();
            this.pnlReportesC.SuspendLayout();
            this.pnlReportesD.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.pnlSuperior.Controls.Add(this.gbxPanelReportes);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1155, 179);
            this.pnlSuperior.TabIndex = 0;
            // 
            // gbxPanelReportes
            // 
            this.gbxPanelReportes.Controls.Add(this.pnlReportesA);
            this.gbxPanelReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxPanelReportes.Location = new System.Drawing.Point(299, 7);
            this.gbxPanelReportes.Name = "gbxPanelReportes";
            this.gbxPanelReportes.Size = new System.Drawing.Size(839, 151);
            this.gbxPanelReportes.TabIndex = 9;
            this.gbxPanelReportes.TabStop = false;
            // 
            // pnlReportesA
            // 
            this.pnlReportesA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnlReportesA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReportesA.Controls.Add(this.lblReportes);
            this.pnlReportesA.Controls.Add(this.pnlReportesB);
            this.pnlReportesA.Location = new System.Drawing.Point(6, 14);
            this.pnlReportesA.Name = "pnlReportesA";
            this.pnlReportesA.Size = new System.Drawing.Size(827, 130);
            this.pnlReportesA.TabIndex = 7;
            // 
            // lblReportes
            // 
            this.lblReportes.AutoSize = true;
            this.lblReportes.BackColor = System.Drawing.Color.Transparent;
            this.lblReportes.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportes.ForeColor = System.Drawing.Color.White;
            this.lblReportes.Location = new System.Drawing.Point(361, 4);
            this.lblReportes.Name = "lblReportes";
            this.lblReportes.Size = new System.Drawing.Size(72, 20);
            this.lblReportes.TabIndex = 9;
            this.lblReportes.Text = "Reportes";
            this.lblReportes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlReportesB
            // 
            this.pnlReportesB.BackColor = System.Drawing.Color.Transparent;
            this.pnlReportesB.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnlReportesB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlReportesB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReportesB.Controls.Add(this.cbTipoReporte);
            this.pnlReportesB.Controls.Add(this.lblTipoReporte);
            this.pnlReportesB.Controls.Add(this.btnGenerar);
            this.pnlReportesB.Controls.Add(this.cbLugar);
            this.pnlReportesB.Controls.Add(this.lblLugar);
            this.pnlReportesB.Controls.Add(this.dtpDesde);
            this.pnlReportesB.Controls.Add(this.lblDesde);
            this.pnlReportesB.Controls.Add(this.dtpHasta);
            this.pnlReportesB.Controls.Add(this.lblHasta);
            this.pnlReportesB.Location = new System.Drawing.Point(3, 27);
            this.pnlReportesB.Name = "pnlReportesB";
            this.pnlReportesB.Size = new System.Drawing.Size(817, 97);
            this.pnlReportesB.TabIndex = 6;
            // 
            // cbTipoReporte
            // 
            this.cbTipoReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.cbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoReporte.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbTipoReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.cbTipoReporte.FormattingEnabled = true;
            this.cbTipoReporte.Location = new System.Drawing.Point(396, 40);
            this.cbTipoReporte.Name = "cbTipoReporte";
            this.cbTipoReporte.Size = new System.Drawing.Size(230, 29);
            this.cbTipoReporte.TabIndex = 7;
            // 
            // lblTipoReporte
            // 
            this.lblTipoReporte.AutoSize = true;
            this.lblTipoReporte.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoReporte.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTipoReporte.ForeColor = System.Drawing.Color.White;
            this.lblTipoReporte.Location = new System.Drawing.Point(393, 24);
            this.lblTipoReporte.Name = "lblTipoReporte";
            this.lblTipoReporte.Size = new System.Drawing.Size(90, 13);
            this.lblTipoReporte.TabIndex = 6;
            this.lblTipoReporte.Text = "Tipo de reporte:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerar.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGenerar.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Image = null;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnGenerar.Location = new System.Drawing.Point(642, 37);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnGenerar.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnGenerar.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnGenerar.Size = new System.Drawing.Size(159, 32);
            this.btnGenerar.TabIndex = 8;
            this.btnGenerar.Text = " Generar Reporte";
            this.btnGenerar.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cbLugar
            // 
            this.cbLugar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.cbLugar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLugar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbLugar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.cbLugar.FormattingEnabled = true;
            this.cbLugar.Location = new System.Drawing.Point(270, 40);
            this.cbLugar.Name = "cbLugar";
            this.cbLugar.Size = new System.Drawing.Size(108, 29);
            this.cbLugar.TabIndex = 5;
            // 
            // lblLugar
            // 
            this.lblLugar.AutoSize = true;
            this.lblLugar.BackColor = System.Drawing.Color.Transparent;
            this.lblLugar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLugar.ForeColor = System.Drawing.Color.White;
            this.lblLugar.Location = new System.Drawing.Point(267, 24);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(39, 13);
            this.lblLugar.TabIndex = 4;
            this.lblLugar.Text = "Lugar:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpDesde.CustomFormat = "d/M/yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(18, 40);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(108, 29);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDesde.ForeColor = System.Drawing.Color.White;
            this.lblDesde.Location = new System.Drawing.Point(15, 24);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpHasta.CustomFormat = "d/M/yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(144, 40);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(108, 29);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHasta.ForeColor = System.Drawing.Color.White;
            this.lblHasta.Location = new System.Drawing.Point(141, 24);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(39, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.Transparent;
            this.btnExportar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnExportar.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Image = null;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnExportar.Location = new System.Drawing.Point(953, 410);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnExportar.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnExportar.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnExportar.Size = new System.Drawing.Size(159, 32);
            this.btnExportar.TabIndex = 9;
            this.btnExportar.Text = "Exportar PDF";
            this.btnExportar.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.dgvReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReporte.ColumnHeadersHeight = 40;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReporte.EnableHeadersVisualStyles = false;
            this.dgvReporte.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.dgvReporte.Location = new System.Drawing.Point(30, 243);
            this.dgvReporte.MultiSelect = false;
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.RowHeadersWidth = 62;
            this.dgvReporte.RowTemplate.Height = 40;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(1097, 383);
            this.dgvReporte.TabIndex = 1;
            // 
            // ssPanel
            // 
            this.ssPanel.Customization = "Kioq/yoqKv8jIyP/Kioq/w==";
            this.ssPanel.Font = new System.Drawing.Font("Verdana", 8F);
            this.ssPanel.Image = null;
            this.ssPanel.Location = new System.Drawing.Point(287, 3);
            this.ssPanel.Name = "ssPanel";
            this.ssPanel.NoRounding = false;
            this.ssPanel.Size = new System.Drawing.Size(4, 165);
            this.ssPanel.TabIndex = 6;
            this.ssPanel.Transparent = false;
            // 
            // pbxTitulo
            // 
            this.pbxTitulo.BackColor = System.Drawing.Color.Transparent;
            this.pbxTitulo.BackgroundImage = global::app.Properties.Resources.cda;
            this.pbxTitulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxTitulo.Location = new System.Drawing.Point(0, 46);
            this.pbxTitulo.Name = "pbxTitulo";
            this.pbxTitulo.Size = new System.Drawing.Size(281, 96);
            this.pbxTitulo.TabIndex = 8;
            this.pbxTitulo.TabStop = false;
            // 
            // gbxReportes
            // 
            this.gbxReportes.Controls.Add(this.pnlReportesC);
            this.gbxReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxReportes.Location = new System.Drawing.Point(4, 185);
            this.gbxReportes.Name = "gbxReportes";
            this.gbxReportes.Size = new System.Drawing.Size(1148, 507);
            this.gbxReportes.TabIndex = 10;
            this.gbxReportes.TabStop = false;
            // 
            // pnlReportesC
            // 
            this.pnlReportesC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnlReportesC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReportesC.Controls.Add(this.pnlReportesD);
            this.pnlReportesC.Location = new System.Drawing.Point(6, 14);
            this.pnlReportesC.Name = "pnlReportesC";
            this.pnlReportesC.Size = new System.Drawing.Size(1136, 487);
            this.pnlReportesC.TabIndex = 7;
            // 
            // pnlReportesD
            // 
            this.pnlReportesD.BackColor = System.Drawing.Color.Transparent;
            this.pnlReportesD.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnlReportesD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlReportesD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReportesD.Controls.Add(this.btnExportar);
            this.pnlReportesD.Location = new System.Drawing.Point(3, 27);
            this.pnlReportesD.Name = "pnlReportesD";
            this.pnlReportesD.Size = new System.Drawing.Size(1128, 455);
            this.pnlReportesD.TabIndex = 6;
            // 
            // ucReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.gbxReportes);
            this.Controls.Add(this.pbxTitulo);
            this.Controls.Add(this.ssPanel);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "ucReportes";
            this.Size = new System.Drawing.Size(1155, 695);
            this.Load += new System.EventHandler(this.ucReportes_Load);
            this.pnlSuperior.ResumeLayout(false);
            this.gbxPanelReportes.ResumeLayout(false);
            this.pnlReportesA.ResumeLayout(false);
            this.pnlReportesA.PerformLayout();
            this.pnlReportesB.ResumeLayout(false);
            this.pnlReportesB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitulo)).EndInit();
            this.gbxReportes.ResumeLayout(false);
            this.pnlReportesC.ResumeLayout(false);
            this.pnlReportesD.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlSuperior;
        private ReaLTaiizor.Controls.Button btnGenerar;
        private ReaLTaiizor.Controls.Button btnExportar;
        private System.Windows.Forms.ComboBox cbTipoReporte;
        private ReaLTaiizor.Controls.SmallLabel lblTipoReporte;
        private System.Windows.Forms.ComboBox cbLugar;
        private ReaLTaiizor.Controls.SmallLabel lblLugar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private ReaLTaiizor.Controls.SmallLabel lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private ReaLTaiizor.Controls.SmallLabel lblDesde;
        private System.Windows.Forms.DataGridView dgvReporte;
        private ReaLTaiizor.Controls.SpaceSeparatorVertical ssPanel;
        private System.Windows.Forms.PictureBox pbxTitulo;
        private System.Windows.Forms.GroupBox gbxPanelReportes;
        private System.Windows.Forms.Panel pnlReportesA;
        private System.Windows.Forms.Panel pnlReportesB;
        private ReaLTaiizor.Controls.BigLabel lblReportes;
        private System.Windows.Forms.GroupBox gbxReportes;
        private System.Windows.Forms.Panel pnlReportesC;
        private System.Windows.Forms.Panel pnlReportesD;
    }
}
