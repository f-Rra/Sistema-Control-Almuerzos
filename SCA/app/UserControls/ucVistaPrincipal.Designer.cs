namespace app.UserControls
{
    partial class ucVistaPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.btnRegistro = new ReaLTaiizor.Controls.Button();
            this.pnlRegistros = new System.Windows.Forms.Panel();
            this.pnlRegistrosB = new System.Windows.Forms.Panel();
            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.pnlComensales = new System.Windows.Forms.Panel();
            this.lblRegistros = new ReaLTaiizor.Controls.BigLabel();
            this.pnlComensalesB = new System.Windows.Forms.Panel();
            this.pnlRegistros.SuspendLayout();
            this.pnlRegistrosB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            this.pnlComensales.SuspendLayout();
            this.pnlComensalesB.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRegistro
            // 
            this.txtRegistro.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(110, 19);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(100, 33);
            this.txtRegistro.TabIndex = 1;
            // 
            // btnRegistro
            // 
            this.btnRegistro.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistro.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistro.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnRegistro.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnRegistro.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.Image = null;
            this.btnRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistro.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnRegistro.Location = new System.Drawing.Point(235, 17);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Padding = new System.Windows.Forms.Padding(14, 0, 12, 0);
            this.btnRegistro.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnRegistro.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnRegistro.Size = new System.Drawing.Size(179, 35);
            this.btnRegistro.TabIndex = 2;
            this.btnRegistro.Text = "Ingresar Registro";
            this.btnRegistro.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // pnlRegistros
            // 
            this.pnlRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnlRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRegistros.Controls.Add(this.pnlRegistrosB);
            this.pnlRegistros.Location = new System.Drawing.Point(13, 117);
            this.pnlRegistros.Name = "pnlRegistros";
            this.pnlRegistros.Size = new System.Drawing.Size(1122, 364);
            this.pnlRegistros.TabIndex = 23;
            // 
            // pnlRegistrosB
            // 
            this.pnlRegistrosB.BackColor = System.Drawing.Color.Transparent;
            this.pnlRegistrosB.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnlRegistrosB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlRegistrosB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRegistrosB.Controls.Add(this.dgvRegistros);
            this.pnlRegistrosB.Location = new System.Drawing.Point(3, 3);
            this.pnlRegistrosB.Name = "pnlRegistrosB";
            this.pnlRegistrosB.Size = new System.Drawing.Size(1114, 356);
            this.pnlRegistrosB.TabIndex = 6;
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.AllowUserToAddRows = false;
            this.dgvRegistros.AllowUserToDeleteRows = false;
            this.dgvRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.dgvRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRegistros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegistros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRegistros.ColumnHeadersHeight = 40;
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRegistros.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegistros.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRegistros.EnableHeadersVisualStyles = false;
            this.dgvRegistros.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.dgvRegistros.Location = new System.Drawing.Point(17, 14);
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.ReadOnly = true;
            this.dgvRegistros.RowHeadersVisible = false;
            this.dgvRegistros.RowTemplate.Height = 40;
            this.dgvRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistros.Size = new System.Drawing.Size(1080, 324);
            this.dgvRegistros.TabIndex = 0;
            // 
            // pnlComensales
            // 
            this.pnlComensales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.pnlComensales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComensales.Controls.Add(this.lblRegistros);
            this.pnlComensales.Controls.Add(this.pnlComensalesB);
            this.pnlComensales.Location = new System.Drawing.Point(314, 8);
            this.pnlComensales.Name = "pnlComensales";
            this.pnlComensales.Size = new System.Drawing.Size(501, 101);
            this.pnlComensales.TabIndex = 24;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(175, 7);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(178, 17);
            this.lblRegistros.TabIndex = 2;
            this.lblRegistros.Text = "REGISTRO DE COMENSALES";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlComensalesB
            // 
            this.pnlComensalesB.BackColor = System.Drawing.Color.Transparent;
            this.pnlComensalesB.BackgroundImage = global::app.Properties.Resources.panel;
            this.pnlComensalesB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlComensalesB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComensalesB.Controls.Add(this.btnRegistro);
            this.pnlComensalesB.Controls.Add(this.txtRegistro);
            this.pnlComensalesB.Location = new System.Drawing.Point(3, 27);
            this.pnlComensalesB.Name = "pnlComensalesB";
            this.pnlComensalesB.Size = new System.Drawing.Size(492, 69);
            this.pnlComensalesB.TabIndex = 6;
            // 
            // ucVistaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.pnlComensales);
            this.Controls.Add(this.pnlRegistros);
            this.Name = "ucVistaPrincipal";
            this.Size = new System.Drawing.Size(1155, 495);
            this.pnlRegistros.ResumeLayout(false);
            this.pnlRegistrosB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.pnlComensales.ResumeLayout(false);
            this.pnlComensales.PerformLayout();
            this.pnlComensalesB.ResumeLayout(false);
            this.pnlComensalesB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLugar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        
        private System.Windows.Forms.TextBox txtRegistro;
        private ReaLTaiizor.Controls.Button btnRegistro;
        private System.Windows.Forms.Panel pnlRegistros;
        private System.Windows.Forms.Panel pnlRegistrosB;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.Panel pnlComensales;
        private ReaLTaiizor.Controls.BigLabel lblRegistros;
        private System.Windows.Forms.Panel pnlComensalesB;
    }
}
