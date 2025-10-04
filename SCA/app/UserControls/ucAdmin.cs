using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.UserControls
{
    public partial class ucAdmin : UserControl
    {
        private ReaLTaiizor.Controls.Button botonActivo;

        public ucAdmin()
        {
            InitializeComponent();
            // Seleccionar Empleados por defecto
            SeleccionarBoton(btnEmpleados);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpleados);
            MostrarPanel(pnlEmpleados);
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpresas);
            MostrarPanel(pnlEmpresas);
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEstadisticas);
            MostrarPanel(pnlEstadisticas);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnConfiguracion);
            MostrarPanel(pnlConfiguracion);
        }

        private void SeleccionarBoton(ReaLTaiizor.Controls.Button boton)
        {
            // Colores
            Color colorDorado = Color.FromArgb(255, 208, 36);
            Color colorNegro = Color.FromArgb(35, 34, 33);

            // Restaurar botón anterior
            if (botonActivo != null)
            {
                botonActivo.InactiveColor = colorNegro;
                botonActivo.PressedColor = colorDorado;
            }

            // Activar nuevo botón
            botonActivo = boton;
            boton.InactiveColor = colorDorado;
            boton.PressedColor = colorDorado;
        }

        private void MostrarPanel(Panel panelAMostrar)
        {
            // Ocultar todos
            pnlEmpleados.Visible = false;
            pnlEmpresas.Visible = false;
            pnlEstadisticas.Visible = false;
            pnlConfiguracion.Visible = false;

            // Mostrar el seleccionado
            panelAMostrar.Visible = true;
            panelAMostrar.BringToFront();
        }
    }
}
