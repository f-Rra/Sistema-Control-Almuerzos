using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*("#fdf39d"),  // Dorado claro
  ("#ffd024"),  // Dorado oscuro
  ("#FFF8E1"),  // crema
  ("#232221"),  // Negro*/


namespace app
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 169);
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 251);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 332);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 537);
        }

   
        private readonly Color MenuBase = Color.FromArgb(35, 34, 33);
        private readonly Color MenuHover = Color.FromArgb(243, 229, 201);

        private void AplicarHover(Panel contenedor, Label etiqueta, bool hover)
        {
            if (contenedor == null || etiqueta == null) return;
            contenedor.BackColor = hover ? MenuHover : Color.Transparent;
            etiqueta.ForeColor = hover ? Color.Black : Color.Transparent;
            etiqueta.Cursor = Cursors.Hand;
        }

        private void Menu_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lblSender && lblSender.Parent is Panel p1)
                AplicarHover(p1, lblSender, true);
            else if (sender is Panel p2)
            {
                var lblChild = p2.Controls.OfType<Label>().FirstOrDefault();
                if (lblChild != null) AplicarHover(p2, lblChild, true);
            }
        }

        private void Menu_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lblSender && lblSender.Parent is Panel p1)
                AplicarHover(p1, lblSender, false);
            else if (sender is Panel p2)
            {
                var lblChild = p2.Controls.OfType<Label>().FirstOrDefault();
                if (lblChild != null) AplicarHover(p2, lblChild, false);
            }
        }
    }
}
