using System;
using System.Windows.Forms;

namespace app.UserControls
{
    public partial class ucPaneles : UserControl
    {
        public ucPaneles()
        {
            InitializeComponent();
        }

        // Métodos para mostrar/ocultar paneles según la sección activa
        public void MostrarPanelSuperior() {
            pnlSuperior.Visible = true;
            pnlBotonesAdmin.Visible = false;
            pnlControlesReportes.Visible = false;
        }
        public void MostrarPanelBotonesAdmin() {
            pnlSuperior.Visible = false;
            pnlBotonesAdmin.Visible = true;
            pnlControlesReportes.Visible = false;
        }
        public void MostrarPanelControlesReportes() {
            pnlSuperior.Visible = false;
            pnlBotonesAdmin.Visible = false;
            pnlControlesReportes.Visible = true;
        }
    }
}
