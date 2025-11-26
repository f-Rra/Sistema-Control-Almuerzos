namespace app.UserControls
{
    partial class ucNotificacion
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
            if (disposing)
            {
                timer?.Stop();
                timer?.Dispose();
                
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ssSuperior = new ReaLTaiizor.Controls.SpaceSeparatorHorizontal();
            this.pbxEstado = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblNombreEmpleado = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.panelContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenedor.Controls.Add(this.label1);
            this.panelContenedor.Controls.Add(this.ssSuperior);
            this.panelContenedor.Controls.Add(this.pbxEstado);
            this.panelContenedor.Controls.Add(this.lblEmpresa);
            this.panelContenedor.Controls.Add(this.lblNombreEmpleado);
            this.panelContenedor.Controls.Add(this.lblTitulo);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Padding = new System.Windows.Forms.Padding(2);
            this.panelContenedor.Size = new System.Drawing.Size(454, 142);
            this.panelContenedor.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Image = global::app.Properties.Resources.notificacion;
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 78);
            this.label1.TabIndex = 6;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ssSuperior
            // 
            this.ssSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(157)))));
            this.ssSuperior.Customization = "ISIj/yEiI/8hIiP/ISIj/w==";
            this.ssSuperior.Font = new System.Drawing.Font("Verdana", 8F);
            this.ssSuperior.Image = null;
            this.ssSuperior.Location = new System.Drawing.Point(8, 35);
            this.ssSuperior.Name = "ssSuperior";
            this.ssSuperior.NoRounding = false;
            this.ssSuperior.Size = new System.Drawing.Size(438, 4);
            this.ssSuperior.TabIndex = 5;
            this.ssSuperior.Transparent = false;
            // 
            // pbxEstado
            // 
            this.pbxEstado.BackColor = System.Drawing.Color.Transparent;
            this.pbxEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxEstado.ForeColor = System.Drawing.Color.Transparent;
            this.pbxEstado.Image = global::app.Properties.Resources.activo;
            this.pbxEstado.Location = new System.Drawing.Point(106, 7);
            this.pbxEstado.Name = "pbxEstado";
            this.pbxEstado.Size = new System.Drawing.Size(29, 25);
            this.pbxEstado.TabIndex = 4;
            this.pbxEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblEmpresa.Location = new System.Drawing.Point(103, 88);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(205, 25);
            this.lblEmpresa.TabIndex = 3;
            this.lblEmpresa.Text = "Empresa S.A. • 12:45:32";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.AutoSize = true;
            this.lblNombreEmpleado.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.lblNombreEmpleado.Location = new System.Drawing.Point(103, 56);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(257, 32);
            this.lblNombreEmpleado.TabIndex = 2;
            this.lblNombreEmpleado.Text = "Juan Carlos González";
            this.lblNombreEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.lblTitulo.Location = new System.Drawing.Point(133, 2);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(219, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Comensal Registrado";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucNotificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.panelContenedor);
            this.Name = "ucNotificacion";
            this.Size = new System.Drawing.Size(454, 142);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombreEmpleado;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label pbxEstado;
        private ReaLTaiizor.Controls.SpaceSeparatorHorizontal ssSuperior;
        private System.Windows.Forms.Label label1;
    }
}
