using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace app.UserControls
{
    public partial class ucVistaPrincipal : UserControl
    {
        private readonly RegistroNegocio negR = new RegistroNegocio();
        private readonly EmpleadoNegocio negE = new EmpleadoNegocio();  
        private frmPrincipal formularioPrincipal;
        private int? servicioIdActual = null;
        private int idLugarActual = 1;


        public ucVistaPrincipal(frmPrincipal formPrincipal = null)
        {
            InitializeComponent();
            this.formularioPrincipal = formPrincipal;
        }

        public void SetServicio(int? servicioId, int idLugar)
        {
            servicioIdActual = servicioId;
            idLugarActual = idLugar;
            CargarRegistros();
        }

        public int CountRegistros()
        {
            if (servicioIdActual.HasValue)
            {
                return negR.contarRegistrosPorServicio(servicioIdActual.Value);
            }
            return 0;
        }

        public void RefrescarRegistros()
        {
            CargarRegistros();
        }

        private void CargarRegistros()
        {
            dgvRegistros.DataSource = null;

            if (servicioIdActual.HasValue)
            {
                dgvRegistros.DataSource = negR.listarPorServicio(servicioIdActual.Value);
            }
            OcultarColumnas();

        }

        private void OcultarColumnas()
        {
            var cols = dgvRegistros?.Columns;
            if (cols == null) return;

            string[] aOcultar = { "IdRegistro", "IdEmpleado", "IdEmpresa", "IdServicio", "IdLugar", "Hora", "HoraF", "Empresa", "Lugar", "NombreLugar" };
            foreach (var nombre in aOcultar)
            {
                var col = cols[nombre];
                if (col != null) col.Visible = false;
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (!servicioIdActual.HasValue)
            {
                ExceptionHelper.MostrarAdvertencia("No hay un servicio activo");
                return;
            }
            
            string credencial = txtRegistro.Text.Trim();
            if (string.IsNullOrEmpty(credencial))
            {
                ExceptionHelper.MostrarAdvertencia("Ingrese una credencial válida");
                return;
            }
            
            try
            {
                Empleado empleado = negE.buscarPorCredencial(credencial);
                if (empleado == null)
                {
                    ExceptionHelper.MostrarAdvertencia($"No se encontró un empleado con la credencial {credencial}");
                    return;
                }
                
                if (negR.empleadoYaRegistrado(empleado.IdEmpleado, servicioIdActual.Value))
                {
                    ExceptionHelper.MostrarInformacion($"El empleado {empleado.NombreCompleto} ya está registrado en este servicio");
                    return;
                }
                negR.registrarEmpleado(empleado.IdEmpleado, empleado.IdEmpresa, servicioIdActual.Value, idLugarActual);
                CargarRegistros();
                txtRegistro.Clear();
                txtRegistro.Focus();
                formularioPrincipal?.ActualizarEstadisticas();
                
                // Mostrar mensaje de confirmación temporal
                MostrarMensajeRegistroExitoso(empleado);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "procesar el registro");
            }
        }

        /// <summary>
        /// Muestra un mensaje temporal con la información del empleado registrado
        /// </summary>
        /// <param name="empleado">Empleado que fue registrado</param>
        private void MostrarMensajeRegistroExitoso(Empleado empleado)
        {
            try
            {
                // Crear formulario temporal (50% más grande: 380->570, 160->240)
                var formTemporal = new Form
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.None,
                    Size = new Size(572, 242), // +2 para el borde
                    BackColor = Color.FromArgb(35, 34, 33), // Color negro del proyecto (borde)
                    TopMost = true,
                    ShowInTaskbar = false,
                    Padding = new Padding(1) // Padding para simular borde de 1px
                };

                // Panel contenedor interno (crea el efecto de borde)
                var panelContenedor = new Panel
                {
                    Size = new Size(570, 240),
                    Location = new Point(1, 1),
                    BackColor = Color.FromArgb(255, 248, 225) // Color de fondo del proyecto
                };

                // Panel superior con color principal del proyecto
                var panelTitulo = new Panel
                {
                    Size = new Size(570, 75),
                    Location = new Point(0, 0),
                    BackColor = Color.FromArgb(255, 208, 36) // Color amarillo del proyecto
                };

                // Título
                var lblTitulo = new Label
                {
                    Text = "✓ REGISTRO EXITOSO",
                    Font = new Font("Segoe UI", 18, FontStyle.Bold), // 14->18
                    ForeColor = Color.FromArgb(35, 34, 33), // Color texto oscuro del proyecto
                    AutoSize = false,
                    Size = new Size(570, 75),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panelTitulo.Controls.Add(lblTitulo);

                // Mensaje con datos del empleado
                string mensaje = $"{empleado.Nombre} {empleado.Apellido}\n" +
                                $"{empleado.NombreEmpresa}\n" +
                                $"Hora: {DateTime.Now:HH:mm:ss}";

                var lblMensaje = new Label
                {
                    Text = mensaje,
                    Font = new Font("Segoe UI", 18, FontStyle.Bold), // 14->18 y agregado Bold
                    ForeColor = Color.FromArgb(35, 34, 33),
                    AutoSize = false,
                    Size = new Size(550, 135),
                    Location = new Point(10, 85),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelContenedor.Controls.Add(panelTitulo);
                panelContenedor.Controls.Add(lblMensaje);
                formTemporal.Controls.Add(panelContenedor);

                // Timer para cerrar después de 3 segundos
                var timer = new Timer { Interval = 3000 };
                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    timer.Dispose();
                    formTemporal.Close();
                    formTemporal.Dispose();
                };

                formTemporal.Shown += (s, e) => timer.Start();
                formTemporal.Show();
            }
            catch
            {
                // Si falla el mensaje temporal, no afecta el registro
            }
        }
    }
}
