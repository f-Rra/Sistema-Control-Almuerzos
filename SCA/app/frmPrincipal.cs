using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 


/*("#fdf39d"),Dorado claro
  ("#ffd024"),Dorado oscuro
  ("#FFF8E1"),Crema
  ("#232221"),Negro*/


namespace app
{
    public partial class frmPrincipal : Form
    {
        private LugarNegocio negL = new LugarNegocio();
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarLugares();
            CargarFecha();
        }

        private void CargarLugares()
        {
            cbLugar.DataSource = negL.listar();
            cbLugar.ValueMember = "IdLugar";
            cbLugar.DisplayMember = "Nombre";
        }

        private void CargarFecha()
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFecha.ReadOnly = true;    
            txtFecha.TabStop = false; 
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 205);
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 286);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 368);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 538);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
