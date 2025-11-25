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
        #region Propiedades y Variables

        private readonly RegistroNegocio negR = new RegistroNegocio();
        private readonly EmpleadoNegocio negE = new EmpleadoNegocio();  
        private frmPrincipal formularioPrincipal;
        private int? servicioIdActual = null;
        private int idLugarActual = 1;

        #endregion

        #region Constructor

        public ucVistaPrincipal(frmPrincipal formPrincipal = null)
        {
            InitializeComponent();
            this.formularioPrincipal = formPrincipal;
        }

        #endregion

        #region Métodos Públicos

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

        #endregion

        #region Carga de Datos

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

        #endregion

        #region Eventos

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (!ValidarServicioActivo()) return;
            if (!ValidarCredencial(out string credencial)) return;

            try
            {
                ProcesarRegistroEmpleado(credencial);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "procesar el registro");
            }
        }

        #endregion

        #region Validaciones

        private bool ValidarServicioActivo()
        {
            if (!servicioIdActual.HasValue)
            {
                ExceptionHelper.MostrarAdvertencia("No hay un servicio activo");
                return false;
            }
            return true;
        }

        private bool ValidarCredencial(out string credencial)
        {
            credencial = txtRegistro.Text.Trim();
            if (string.IsNullOrEmpty(credencial))
            {
                ExceptionHelper.MostrarAdvertencia("Ingrese una credencial válida");
                return false;
            }
            return true;
        }

        #endregion

        #region Procesamiento de Registro

        private void ProcesarRegistroEmpleado(string credencial)
        {
            Empleado empleado = BuscarEmpleadoPorCredencial(credencial);
            if (empleado == null) return;

            if (VerificarEmpleadoYaRegistrado(empleado)) return;

            RegistrarEmpleadoEnServicio(empleado);
        }

        private Empleado BuscarEmpleadoPorCredencial(string credencial)
        {
            Empleado empleado = negE.buscarPorCredencial(credencial);
            if (empleado == null)
            {
                ExceptionHelper.MostrarAdvertencia($"No se encontró un empleado con la credencial {credencial}");
                return null;
            }
            return empleado;
        }

        private bool VerificarEmpleadoYaRegistrado(Empleado empleado)
        {
            if (negR.empleadoYaRegistrado(empleado.IdEmpleado, servicioIdActual.Value))
            {
                ExceptionHelper.MostrarInformacion($"El empleado {empleado.NombreCompleto} ya está registrado en este servicio");
                return true;
            }
            return false;
        }

        private void RegistrarEmpleadoEnServicio(Empleado empleado)
        {
            negR.registrarEmpleado(empleado.IdEmpleado, empleado.IdEmpresa, servicioIdActual.Value, idLugarActual);
            CargarRegistros();
            LimpiarInput();
            formularioPrincipal?.ActualizarEstadisticas();
            MostrarComensalRegistrado(empleado);
        }

        private void LimpiarInput()
        {
            txtRegistro.Clear();
            txtRegistro.Focus();
        }

        #endregion

        #region Notificación Visual

        private void MostrarComensalRegistrado(Empleado empleado)
        {
            try
            {
                // Crear instancia del UserControl de notificación
                var notificacion = new ucNotificacion();
                
                // Obtener este UserControl como contenedor
                Control contenedorPadre = this;
                
                // Formatear hora
                string horaActual = DateTime.Now.ToString("HH:mm:ss");
                
                // Mostrar notificación con animación (mostrar título)
                notificacion.MostrarNotificacion(
                    empleado.NombreCompleto,
                    empleado.NombreEmpresa,
                    horaActual,
                    contenedorPadre,
                    false // Mostrar título
                );
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERROR] Error al mostrar notificación: {ex.Message}");
            }
        }

        #endregion
    }
}
