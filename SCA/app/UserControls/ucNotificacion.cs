using System;
using System.Drawing;
using System.Windows.Forms;

namespace app.UserControls
{
    public partial class ucNotificacion : UserControl
    {
        private Timer timerOcultar;
        private Timer timerAnimacion;
        private int posicionFinalY;
        private int posicionInicialY;
        private const int DURACION_VISIBLE = 4000; // 4 segundos
        private const int VELOCIDAD_ANIMACION = 20; // ms entre frames

        public ucNotificacion()
        {
            InitializeComponent();
            ConfigurarEstilo();
        }

        private void ConfigurarEstilo()
        {
            this.Size = new Size(450, 120);
            this.BackColor = Color.FromArgb(35, 34, 33); // Borde oscuro
            this.Padding = new Padding(0);
        }

        public void MostrarNotificacion(string nombreEmpleado, string empresa, string hora, Control contenedorPadre, bool ocultarTitulo = false)
        {
            // Establecer textos
            lblNombreEmpleado.Text = nombreEmpleado;
            lblEmpresa.Text = empresa + " • " + hora;
            
            // Ocultar título si son múltiples registros
            lblTitulo.Visible = !ocultarTitulo;

            // Agregar al contenedor padre
            if (contenedorPadre != null)
            {
                contenedorPadre.Controls.Add(this);
                
                // Buscar los paneles para posicionamiento
                Control panelComensales = BuscarControl(contenedorPadre, "pnlComensales");
                Control panelRegistros = BuscarControl(contenedorPadre, "pnlRegistros");
                Control panelFaltantes = BuscarControl(contenedorPadre, "pnlFaltantes");
                
                // Calcular posición X centrada
                int x = (contenedorPadre.Width - this.Width) / 2;
                
                // Determinar posiciones Y según los paneles disponibles
                if (panelComensales != null && panelRegistros != null)
                {
                    // ucVistaPrincipal: entre pnlComensales y pnlRegistros
                    posicionInicialY = panelComensales.Bottom;
                    posicionFinalY = panelRegistros.Top + 10;
                }
                else if (panelRegistros != null && panelFaltantes != null)
                {
                    // ucRegistroManual: centrada verticalmente entre ambos paneles, 20px más arriba
                    int espacioEntre = panelFaltantes.Top - panelRegistros.Bottom;
                    int centroY = panelRegistros.Bottom + (espacioEntre / 2) - (this.Height / 2) - 20;
                    posicionInicialY = centroY - 50;
                    posicionFinalY = centroY;
                }
                else
                {
                    // Fallback: centro de la pantalla
                    posicionFinalY = (contenedorPadre.Height - this.Height) / 2;
                    posicionInicialY = posicionFinalY - 100;
                }

                this.Location = new Point(x, posicionInicialY);
                this.Visible = true;
                
                this.BringToFront();
            }

            // Iniciar animación de entrada
            AnimarEntrada();
        }
        
        private Control BuscarControl(Control contenedor, string nombre)
        {
            foreach (Control ctrl in contenedor.Controls)
            {
                if (ctrl.Name == nombre)
                    return ctrl;
                
                // Búsqueda recursiva
                Control encontrado = BuscarControl(ctrl, nombre);
                if (encontrado != null)
                    return encontrado;
            }
            return null;
        }

        private void AnimarEntrada()
        {
            timerAnimacion = new Timer();
            timerAnimacion.Interval = VELOCIDAD_ANIMACION;
            
            int pasoActual = 0;
            int totalPasos = 20; // 20 pasos para la animación (400ms total)
            
            timerAnimacion.Tick += (s, e) =>
            {
                pasoActual++;
                double progreso = (double)pasoActual / totalPasos;
                
                // Ease-out para movimiento más suave
                double ease = 1 - Math.Pow(1 - progreso, 3);
                
                // Actualizar posición Y (slide down)
                int nuevaY = (int)(posicionInicialY + (posicionFinalY - posicionInicialY) * ease);
                this.Location = new Point(this.Location.X, nuevaY);
                
                if (pasoActual >= totalPasos)
                {
                    timerAnimacion.Stop();
                    timerAnimacion.Dispose();
                    timerAnimacion = null;
                    
                    // Iniciar timer para ocultar después de X segundos
                    IniciarTimerOcultar();
                }
            };
            
            timerAnimacion.Start();
        }

        private void IniciarTimerOcultar()
        {
            timerOcultar = new Timer();
            timerOcultar.Interval = DURACION_VISIBLE;
            timerOcultar.Tick += (s, e) =>
            {
                timerOcultar.Stop();
                AnimarSalida();
            };
            timerOcultar.Start();
        }

        private void AnimarSalida()
        {
            timerAnimacion = new Timer();
            timerAnimacion.Interval = VELOCIDAD_ANIMACION;
            
            int pasoActual = 0;
            int totalPasos = 15; // Animación de salida más rápida (300ms)
            int posicionInicioSalida = this.Location.Y;
            int posicionFinalSalida = posicionInicioSalida - 50; // Sube 50px
            
            timerAnimacion.Tick += (s, e) =>
            {
                pasoActual++;
                double progreso = (double)pasoActual / totalPasos;
                
                // Ease-in para salida
                double ease = Math.Pow(progreso, 2);
                
                // Actualizar posición Y (slide up)
                int nuevaY = (int)(posicionInicioSalida + (posicionFinalSalida - posicionInicioSalida) * ease);
                this.Location = new Point(this.Location.X, nuevaY);
                
                if (pasoActual >= totalPasos)
                {
                    timerAnimacion.Stop();
                    timerAnimacion.Dispose();
                    timerAnimacion = null;
                    
                    // Remover del contenedor padre
                    this.Parent?.Controls.Remove(this);
                    this.Dispose();
                }
            };
            
            timerAnimacion.Start();
        }
    }
}
