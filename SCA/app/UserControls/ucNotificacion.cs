using System;
using System.Drawing;
using System.Windows.Forms;

namespace app.UserControls
{
    public partial class ucNotificacion : UserControl
    {
        private Timer timer;
        private int yInicial, yFinal, paso;
        private bool animandoSalida;

        public ucNotificacion()
        {
            InitializeComponent();
        }

        public void MostrarNotificacion(string nombre, string empresa, string hora, Control padre, bool ocultarTitulo = false)
        {
            lblNombreEmpleado.Text = nombre;
            lblEmpresa.Text = $"{empresa} • {hora}";
            lblTitulo.Visible = !ocultarTitulo;
            pbxEstado.Visible = !ocultarTitulo;

            if (padre == null) return;

            padre.Controls.Add(this);
            CalcularPosicion(padre);
            Location = new Point((padre.Width - Width) / 2, yInicial);
            Visible = true;
            BringToFront();
            IniciarAnimacion(false);
        }

        private void CalcularPosicion(Control padre)
        {
            var pnlComensales = Buscar(padre, "pnlComensales");
            var pnlRegistros = Buscar(padre, "pnlRegistros");
            var pnlFaltantes = Buscar(padre, "pnlFaltantes");

            if (pnlComensales != null && pnlRegistros != null)
            {
                // ucVistaPrincipal
                yInicial = pnlComensales.Bottom;
                yFinal = pnlRegistros.Top + 10;
            }
            else if (pnlRegistros != null && pnlFaltantes != null)
            {
                // ucRegistroManual 
                yInicial = pnlRegistros.Bottom;
                yFinal = pnlFaltantes.Top + 10;
            }
            else
            {
                yFinal = (padre.Height - Height) / 2;
                yInicial = yFinal - 100;
            }
        }

        private Control Buscar(Control c, string nombre)
        {
            foreach (Control ctrl in c.Controls)
            {
                if (ctrl.Name == nombre) return ctrl;
                var found = Buscar(ctrl, nombre);
                if (found != null) return found;
            }
            return null;
        }

        private void IniciarAnimacion(bool salida)
        {
            animandoSalida = salida;
            paso = 0;
            timer?.Dispose();
            timer = new Timer { Interval = 20 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object s, EventArgs e)
        {
            paso++;
            int totalPasos = animandoSalida ? 15 : 20;
            double t = (double)paso / totalPasos;

            if (animandoSalida)
            {
                int y = (int)(yFinal - 50 * t * t);
                Location = new Point(Location.X, y);
            }
            else
            {
                double ease = 1 - Math.Pow(1 - t, 3);
                int y = (int)(yInicial + (yFinal - yInicial) * ease);
                Location = new Point(Location.X, y);
            }

            if (paso >= totalPasos)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;

                if (animandoSalida)
                {
                    Parent?.Controls.Remove(this);
                    Dispose();
                }
                else
                {
                    timer = new Timer { Interval = 4000 };
                    timer.Tick += (_, __) => { timer.Stop(); IniciarAnimacion(true); };
                    timer.Start();
                }
            }
        }
    }
}
