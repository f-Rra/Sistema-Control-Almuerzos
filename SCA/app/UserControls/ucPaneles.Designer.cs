namespace app.UserControls
{
    partial class ucPaneles
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlBotonesAdmin = new System.Windows.Forms.Panel();
            this.pnlControlesReportes = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(255, 248, 225);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1155, 185);
            this.pnlSuperior.TabIndex = 0;
            // 
            // pnlBotonesAdmin
            // 
            this.pnlBotonesAdmin.BackColor = System.Drawing.Color.FromArgb(255, 248, 225);
            this.pnlBotonesAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotonesAdmin.Location = new System.Drawing.Point(0, 185);
            this.pnlBotonesAdmin.Name = "pnlBotonesAdmin";
            this.pnlBotonesAdmin.Size = new System.Drawing.Size(1155, 113);
            this.pnlBotonesAdmin.TabIndex = 1;
            this.pnlBotonesAdmin.Visible = false;
            // 
            // pnlControlesReportes
            // 
            this.pnlControlesReportes.BackColor = System.Drawing.Color.FromArgb(255, 248, 225);
            this.pnlControlesReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControlesReportes.Location = new System.Drawing.Point(0, 298);
            this.pnlControlesReportes.Name = "pnlControlesReportes";
            this.pnlControlesReportes.Size = new System.Drawing.Size(1155, 113);
            this.pnlControlesReportes.TabIndex = 2;
            this.pnlControlesReportes.Visible = false;
            // 
            // ucPaneles
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlControlesReportes);
            this.Controls.Add(this.pnlBotonesAdmin);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "ucPaneles";
            this.Size = new System.Drawing.Size(1155, 411);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlBotonesAdmin;
        private System.Windows.Forms.Panel pnlControlesReportes;
    }
}
