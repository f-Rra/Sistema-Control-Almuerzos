namespace app.UserControls
{
    partial class ucRegistroManual
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
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new ReaLTaiizor.Controls.SmallLabel();
            this.lblNombre = new ReaLTaiizor.Controls.SmallLabel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnAgregar = new ReaLTaiizor.Controls.Button();
            this.pnlRegistros = new System.Windows.Forms.Panel();
            this.lblRegistroManual = new ReaLTaiizor.Controls.BigLabel();
            this.pnlRegistrosB = new System.Windows.Forms.Panel();
            this.pnlFaltantes = new System.Windows.Forms.Panel();
            this.pnlFaltantesB = new System.Windows.Forms.Panel();
            this.dgvFaltantes = new System.Windows.Forms.DataGridView();
            this.pnlRegistros.SuspendLayout();
            this.pnlRegistrosB.SuspendLayout();
            this.pnlFaltantes.SuspendLayout();
            this.pnlFaltantesB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltantes)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.cbEmpresa.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(13, 22);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(155, 33);
            this.cbEmpresa.TabIndex = 16;
            this.cbEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cbEmpresa_SelectionChangeCommitted);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblEmpresa.Location = new System.Drawing.Point(10, 6);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(55, 15);
            this.lblEmpresa.TabIndex = 17;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(177, 6);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 15);
            this.lblNombre.TabIndex = 19;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.txtNombre.Location = new System.Drawing.Point(180, 22);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(155, 33);
            this.txtNombre.TabIndex = 18;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnAgregar.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = null;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnAgregar.Location = new System.Drawing.Point(347, 20);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new System.Windows.Forms.Padding(14, 0, 12, 0);
            this.btnAgregar.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnAgregar.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnAgregar.Size = new System.Drawing.Size(127, 35);
            this.btnAgregar.TabIndex = 20;
            this.btnAgregar.Text = "Agregar ";
            this.btnAgregar.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pnlRegistros
            // 
            this.pnlRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnlRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRegistros.Controls.Add(this.lblRegistroManual);
            this.pnlRegistros.Controls.Add(this.pnlRegistrosB);
            this.pnlRegistros.Location = new System.Drawing.Point(314, 8);
            this.pnlRegistros.Name = "pnlRegistros";
            this.pnlRegistros.Size = new System.Drawing.Size(501, 101);
            this.pnlRegistros.TabIndex = 21;
            // 
            // lblRegistroManual
            // 
            this.lblRegistroManual.AutoSize = true;
            this.lblRegistroManual.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistroManual.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistroManual.ForeColor = System.Drawing.Color.White;
            this.lblRegistroManual.Location = new System.Drawing.Point(180, 3);
            this.lblRegistroManual.Name = "lblRegistroManual";
            this.lblRegistroManual.Size = new System.Drawing.Size(135, 21);
            this.lblRegistroManual.TabIndex = 2;
            this.lblRegistroManual.Text = "Registro Manual";
            this.lblRegistroManual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRegistrosB
            // 
            this.pnlRegistrosB.BackColor = System.Drawing.Color.Transparent;
            this.pnlRegistrosB.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnlRegistrosB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlRegistrosB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRegistrosB.Controls.Add(this.btnAgregar);
            this.pnlRegistrosB.Controls.Add(this.lblNombre);
            this.pnlRegistrosB.Controls.Add(this.txtNombre);
            this.pnlRegistrosB.Controls.Add(this.lblEmpresa);
            this.pnlRegistrosB.Controls.Add(this.cbLugar);
            this.pnlRegistrosB.Location = new System.Drawing.Point(3, 27);
            this.pnlRegistrosB.Name = "pnlRegistrosB";
            this.pnlRegistrosB.Size = new System.Drawing.Size(492, 69);
            this.pnlRegistrosB.TabIndex = 6;
            // 
            // pnlFaltantes
            // 
            this.pnlFaltantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnlFaltantes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFaltantes.Controls.Add(this.pnlFaltantesB);
            this.pnlFaltantes.Location = new System.Drawing.Point(13, 117);
            this.pnlFaltantes.Name = "pnlFaltantes";
            this.pnlFaltantes.Size = new System.Drawing.Size(1122, 364);
            this.pnlFaltantes.TabIndex = 22;
            // 
            // pnlFaltantesB
            // 
            this.pnlFaltantesB.BackColor = System.Drawing.Color.Transparent;
            this.pnlFaltantesB.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnlFaltantesB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFaltantesB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFaltantesB.Controls.Add(this.dgvFaltantes);
            this.pnlFaltantesB.Location = new System.Drawing.Point(3, 3);
            this.pnlFaltantesB.Name = "pnlFaltantesB";
            this.pnlFaltantesB.Size = new System.Drawing.Size(1114, 356);
            this.pnlFaltantesB.TabIndex = 6;
            // 
            // dgvFaltantes
            // 
            this.dgvFaltantes.AllowUserToAddRows = false;
            this.dgvFaltantes.AllowUserToDeleteRows = false;
            this.dgvFaltantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFaltantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFaltantes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.dgvFaltantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFaltantes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFaltantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFaltantes.ColumnHeadersHeight = 40;
            this.dgvFaltantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFaltantes.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFaltantes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFaltantes.EnableHeadersVisualStyles = false;
            this.dgvFaltantes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.dgvFaltantes.Location = new System.Drawing.Point(17, 14);
            this.dgvFaltantes.Name = "dgvFaltantes";
            this.dgvFaltantes.ReadOnly = true;
            this.dgvFaltantes.RowHeadersVisible = false;
            this.dgvFaltantes.RowTemplate.Height = 40;
            this.dgvFaltantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaltantes.Size = new System.Drawing.Size(1080, 324);
            this.dgvFaltantes.TabIndex = 0;
            // 
            // ucRegistroManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.pnlFaltantes);
            this.Controls.Add(this.pnlRegistros);
            this.Name = "ucRegistroManual";
            this.Size = new System.Drawing.Size(1155, 495);
            this.Load += new System.EventHandler(this.ucRegistroManual_Load);
            this.pnlRegistros.ResumeLayout(false);
            this.pnlRegistros.PerformLayout();
            this.pnlRegistrosB.ResumeLayout(false);
            this.pnlRegistrosB.PerformLayout();
            this.pnlFaltantes.ResumeLayout(false);
            this.pnlFaltantesB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbEmpresa;
        private ReaLTaiizor.Controls.SmallLabel lblEmpresa;
        private ReaLTaiizor.Controls.SmallLabel lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private ReaLTaiizor.Controls.Button btnAgregar;
        private System.Windows.Forms.Panel pnlRegistros;
        private ReaLTaiizor.Controls.BigLabel lblRegistroManual;
        private System.Windows.Forms.Panel pnlRegistrosB;
        private System.Windows.Forms.Panel pnlFaltantes;
        private System.Windows.Forms.Panel pnlFaltantesB;
        private System.Windows.Forms.DataGridView dgvFaltantes;
    }
}
