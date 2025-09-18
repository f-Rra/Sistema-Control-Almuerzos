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

        private void pbxHome_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(23, 169);
        }

        private void pbxRegistro_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(23, 237);
        }

        private void pbxReporte_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(23, 307);
        }

        private void pbxAdmin_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(23, 567);
        }
    }
}
