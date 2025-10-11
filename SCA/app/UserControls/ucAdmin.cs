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
        private ucEmpleados ucEmpleados;
        private ucEmpresas ucEmpresas;
        private ucEstadisticas ucEstadisticas;
        private ucConfiguracion ucConfiguracion;

        public ucAdmin()
        {
            InitializeComponent();
            InicializarUserControls();
            SeleccionarBoton(btnEmpleados);
            MostrarUserControl(ucEmpleados);
        }

        private void InicializarUserControls()
        {
            ucEmpleados = new ucEmpleados();
            ucEmpresas = new ucEmpresas();
            ucEstadisticas = new ucEstadisticas();
            ucConfiguracion = new ucConfiguracion();
            ucEmpleados.Dock = DockStyle.Fill;
            ucEmpresas.Dock = DockStyle.Fill;
            ucEstadisticas.Dock = DockStyle.Fill;
            ucConfiguracion.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(ucEmpleados);
            pnlContenido.Controls.Add(ucEmpresas);
            pnlContenido.Controls.Add(ucEstadisticas);
            pnlContenido.Controls.Add(ucConfiguracion);
            ucEmpleados.Visible = true;
            ucEmpresas.Visible = false;
            ucEstadisticas.Visible = false;
            ucConfiguracion.Visible = false;
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpleados);
            MostrarUserControl(ucEmpleados);
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpresas);
            MostrarUserControl(ucEmpresas);
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEstadisticas);
            MostrarUserControl(ucEstadisticas);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnConfiguracion);
            MostrarUserControl(ucConfiguracion);
        }

        private void SeleccionarBoton(ReaLTaiizor.Controls.Button boton)
        {
            Color colorDorado = Color.FromArgb(255, 208, 36);
            Color colorNegro = Color.FromArgb(35, 34, 33);
            if (botonActivo != null)
            {
                botonActivo.InactiveColor = colorNegro;
                botonActivo.PressedColor = colorDorado;
            }
            botonActivo = boton;
            boton.InactiveColor = colorDorado;
            boton.PressedColor = colorDorado;
        }

        private void MostrarUserControl(UserControl controlAMostrar)
        {
            ucEmpleados.Visible = false;
            ucEmpresas.Visible = false;
            ucEstadisticas.Visible = false;
            ucConfiguracion.Visible = false;
            controlAMostrar.Visible = true;
            controlAMostrar.BringToFront();
        }
    }
}
