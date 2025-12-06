using System.Windows.Forms;
using app.UserControls;

namespace app.Gestores
{
    public class GestorNavegacion
    {
        private readonly Panel _contenedorPrincipal;
        private readonly Panel _panelSuperior;
        private readonly GroupBox _gbxServicios;
        private readonly GroupBox _gbxUltimo;
        
        private ucServicio _vistaServicio;
        private ucRegistroManual _vistaRegistroManual;
        private ucReportes _vistaReportes;
        private ucAdmin _vistaAdmin;

        public GestorNavegacion(Panel contenedor, Panel panelSuperior, GroupBox gbxServicios, GroupBox gbxUltimo)
        {
            _contenedorPrincipal = contenedor;
            _panelSuperior = panelSuperior;
            _gbxServicios = gbxServicios;
            _gbxUltimo = gbxUltimo;
        }

        public void MostrarVista(UserControl vista)
        {
            if (vista == null) return;

            _contenedorPrincipal.SuspendLayout();

            foreach (Control c in _contenedorPrincipal.Controls)
                c.Visible = false;

            vista.Visible = true;
            vista.BringToFront();

            _contenedorPrincipal.ResumeLayout();
        }

        public void OcultarTodasLasVistas()
        {
            _contenedorPrincipal.SuspendLayout();

            foreach (Control c in _contenedorPrincipal.Controls)
                c.Visible = false;

            _gbxServicios.Visible = false;
            _gbxUltimo.Visible = false;

            _contenedorPrincipal.ResumeLayout();
        }

        public void MostrarPanelSuperior(bool mostrar)
        {
            _panelSuperior.Visible = mostrar;
        }

        public void MostrarGroupBoxes(bool mostrar)
        {
            _gbxServicios.Visible = mostrar;
            _gbxUltimo.Visible = mostrar;
            
            if (mostrar)
            {
                _gbxServicios.BringToFront();
                _gbxUltimo.BringToFront();
            }
        }
    }
}
