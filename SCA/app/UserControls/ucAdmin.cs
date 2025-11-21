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
        #region Variables y Constantes

        private readonly Color ColorDorado = Color.FromArgb(255, 208, 36);
        private readonly Color ColorNegro = Color.FromArgb(35, 34, 33);
        private ucEmpleados ucEmpleados;
        private ucEmpresas ucEmpresas;
        private ucEstadisticas ucEstadisticas;
        private ucConfiguracion ucConfiguracion;
        private ReaLTaiizor.Controls.Button botonActivo;

        #endregion

        #region Constructor e Inicialización

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

            ConfigurarDock();
            AgregarControles();
            ConfigurarVisibilidad();
        }

        private void ConfigurarDock()
        {
            ucEmpleados.Dock = DockStyle.Fill;
            ucEmpresas.Dock = DockStyle.Fill;
            ucEstadisticas.Dock = DockStyle.Fill;
            ucConfiguracion.Dock = DockStyle.Fill;
        }

        private void AgregarControles()
        {
            pnlContenido.Controls.Add(ucEmpleados);
            pnlContenido.Controls.Add(ucEmpresas);
            pnlContenido.Controls.Add(ucEstadisticas);
            pnlContenido.Controls.Add(ucConfiguracion);
        }

        private void ConfigurarVisibilidad()
        {
            ucEmpleados.Visible = true;
            ucEmpresas.Visible = false;
            ucEstadisticas.Visible = false;
            ucConfiguracion.Visible = false;
        }

        #endregion

        #region Gestión de UserControls

        private void MostrarUserControl(UserControl controlAMostrar)
        {
            pnlContenido.SuspendLayout();

            ucEmpleados.Visible = false;
            ucEmpresas.Visible = false;
            ucEstadisticas.Visible = false;
            ucConfiguracion.Visible = false;

            controlAMostrar.Visible = true;
            controlAMostrar.BringToFront();

            pnlContenido.ResumeLayout();
        }

        #endregion

        #region Gestión de Botones

        private void SeleccionarBoton(ReaLTaiizor.Controls.Button boton)
        {
            if (botonActivo != null)
            {
                botonActivo.InactiveColor = ColorNegro;
                botonActivo.PressedColor = ColorDorado;
            }

            botonActivo = boton;
            boton.InactiveColor = ColorDorado;
            boton.PressedColor = ColorDorado;
        }

        #endregion

        #region Actualizaciones

        private void NotificarCambiosAlFormularioPrincipal()
        {
            var formularioPrincipal = this.ParentForm as frmPrincipal;
            formularioPrincipal?.RefrescarTodasLasVistas();
        }

        #endregion

        #region Eventos de Botones

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpleados);
            ucEmpleados.RefrescarDatos();
            MostrarUserControl(ucEmpleados);
            NotificarCambiosAlFormularioPrincipal();
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpresas);
            ucEmpresas.RefrescarDatos();
            MostrarUserControl(ucEmpresas);
            NotificarCambiosAlFormularioPrincipal();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEstadisticas);
            ucEstadisticas.RefrescarDatos();
            MostrarUserControl(ucEstadisticas);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnConfiguracion);
            ucConfiguracion.RefrescarDatos();
            MostrarUserControl(ucConfiguracion);
        }

        #endregion
    }
}
