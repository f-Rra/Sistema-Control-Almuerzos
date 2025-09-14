namespace app
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlLateral = new ReaLTaiizor.Controls.MaterialCard();
            this.pnlSuperior = new ReaLTaiizor.Controls.MaterialCard();
            this.pnlPrincipal = new ReaLTaiizor.Controls.MaterialCard();
            this.SuspendLayout();
            // 
            // pnlLateral
            // 
            this.pnlLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlLateral.Depth = 0;
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlLateral.Location = new System.Drawing.Point(3, 64);
            this.pnlLateral.Margin = new System.Windows.Forms.Padding(14);
            this.pnlLateral.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Padding = new System.Windows.Forms.Padding(14);
            this.pnlLateral.Size = new System.Drawing.Size(200, 733);
            this.pnlLateral.TabIndex = 0;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlSuperior.Depth = 0;
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlSuperior.Location = new System.Drawing.Point(203, 64);
            this.pnlSuperior.Margin = new System.Windows.Forms.Padding(14);
            this.pnlSuperior.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Padding = new System.Windows.Forms.Padding(14);
            this.pnlSuperior.Size = new System.Drawing.Size(994, 100);
            this.pnlSuperior.TabIndex = 1;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlPrincipal.Depth = 0;
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlPrincipal.Location = new System.Drawing.Point(203, 164);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(14);
            this.pnlPrincipal.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Padding = new System.Windows.Forms.Padding(14);
            this.pnlPrincipal.Size = new System.Drawing.Size(994, 633);
            this.pnlPrincipal.TabIndex = 2;
            // 
            // frmPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlLateral);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard pnlLateral;
        private ReaLTaiizor.Controls.MaterialCard pnlSuperior;
        private ReaLTaiizor.Controls.MaterialCard pnlPrincipal;
    }
}
