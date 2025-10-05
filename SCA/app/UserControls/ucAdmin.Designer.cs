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
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new ReaLTaiizor.Controls.Button();
            this.btnEstadisticas = new ReaLTaiizor.Controls.Button();
            this.btnEmpresas = new ReaLTaiizor.Controls.Button();
            this.btnEmpleados = new ReaLTaiizor.Controls.Button();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.pnlBotones.Controls.Add(this.btnConfiguracion);
            this.pnlBotones.Controls.Add(this.btnEstadisticas);
            this.pnlBotones.Controls.Add(this.btnEmpresas);
            this.pnlBotones.Controls.Add(this.btnEmpleados);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(0, 0);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(1155, 113);
            this.pnlBotones.TabIndex = 0;
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
            this.btnConfiguracion.Location = new System.Drawing.Point(732, 34);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnConfiguracion.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnConfiguracion.Size = new System.Drawing.Size(150, 40);
            this.btnConfiguracion.TabIndex = 3;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
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
            this.btnEstadisticas.Location = new System.Drawing.Point(567, 34);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEstadisticas.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEstadisticas.Size = new System.Drawing.Size(150, 40);
            this.btnEstadisticas.TabIndex = 2;
            this.btnEstadisticas.Text = "Estadísticas";
            this.btnEstadisticas.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
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
            this.btnEmpresas.Location = new System.Drawing.Point(402, 34);
            this.btnEmpresas.Name = "btnEmpresas";
            this.btnEmpresas.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEmpresas.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEmpresas.Size = new System.Drawing.Size(150, 40);
            this.btnEmpresas.TabIndex = 1;
            this.btnEmpresas.Text = "Empresas";
            this.btnEmpresas.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEmpresas.Click += new System.EventHandler(this.btnEmpresas_Click);
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
            this.btnEmpleados.Location = new System.Drawing.Point(237, 34);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(34)))), ((int)(((byte)(33)))));
            this.btnEmpleados.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(36)))));
            this.btnEmpleados.Size = new System.Drawing.Size(150, 40);
            this.btnEmpleados.TabIndex = 0;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 113);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1155, 582);
            this.pnlContenido.TabIndex = 1;
            // 
            // ucAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlBotones);
            this.Name = "ucAdmin";
            this.Size = new System.Drawing.Size(1155, 695);
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBotones;
        private ReaLTaiizor.Controls.Button btnEmpleados;
        private ReaLTaiizor.Controls.Button btnEmpresas;
        private ReaLTaiizor.Controls.Button btnEstadisticas;
        private ReaLTaiizor.Controls.Button btnConfiguracion;
        private System.Windows.Forms.Panel pnlContenido;
    }
}
