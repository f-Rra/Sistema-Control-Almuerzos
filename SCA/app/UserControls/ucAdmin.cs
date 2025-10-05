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
        // VARIABLES DE CLASE
        private ReaLTaiizor.Controls.Button botonActivo;
        
        // Instancias de los UserControls
        private ucEmpleados ucEmpleados;
        private ucEmpresas ucEmpresas;
        private ucEstadisticas ucEstadisticas;
        private ucConfiguracion ucConfiguracion;

        public ucAdmin()
        {
            InitializeComponent();
            InicializarUserControls();
            // Seleccionar Empleados por defecto
            SeleccionarBoton(btnEmpleados);
            MostrarUserControl(ucEmpleados);
        }

        private void InicializarUserControls()
        {
            // Crear instancias de los UserControls
            ucEmpleados = new ucEmpleados();
            ucEmpresas = new ucEmpresas();
            ucEstadisticas = new ucEstadisticas();
            ucConfiguracion = new ucConfiguracion();

            // Configurar propiedades comunes
            ucEmpleados.Dock = DockStyle.Fill;
            ucEmpresas.Dock = DockStyle.Fill;
            ucEstadisticas.Dock = DockStyle.Fill;
            ucConfiguracion.Dock = DockStyle.Fill;

            // Agregar al panel contenedor
            pnlContenido.Controls.Add(ucEmpleados);
            pnlContenido.Controls.Add(ucEmpresas);
            pnlContenido.Controls.Add(ucEstadisticas);
            pnlContenido.Controls.Add(ucConfiguracion);

            // Ocultar todos excepto el primero
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

        private void MostrarUserControl(UserControl controlAMostrar)
        {
            // Ocultar todos
            ucEmpleados.Visible = false;
            ucEmpresas.Visible = false;
            ucEstadisticas.Visible = false;
            ucConfiguracion.Visible = false;

            // Mostrar el seleccionado
            controlAMostrar.Visible = true;
            controlAMostrar.BringToFront();
        }
    }
}
