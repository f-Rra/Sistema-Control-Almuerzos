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
using app.Helpers;
using static app.Helpers.MensajesConstantes;

namespace app.UserControls
{
    public partial class ucServicio : UserControl
    {
        #region Propiedades y Variables

        private readonly RegistroNegocio _registroNegocio = new RegistroNegocio();
        private readonly EmpleadoNegocio _empleadoNegocio = new EmpleadoNegocio();  
        private frmPrincipal _formularioPrincipal;
        private int? _servicioIdActual = null;
        private int _idLugarActual = 1;

        #endregion

        #region Constructor

        public ucServicio(frmPrincipal formPrincipal = null)
        {
            InitializeComponent();
            _formularioPrincipal = formPrincipal;
        }

        #endregion

        #region Métodos Públicos

        public void SetServicio(int? servicioId, int idLugar)
        {
            _servicioIdActual = servicioId;
            _idLugarActual = idLugar;
            CargarRegistros();
        }

        public int CountRegistros()
        {
            try
            {
                if (_servicioIdActual.HasValue)
                {
                    return _registroNegocio.ContarRegistrosPorServicio(_servicioIdActual.Value);
                }
                return 0;
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
                return 0;
            }
        }

        public void RefrescarRegistros()
        {
            CargarRegistros();
        }

        #endregion

        #region Carga de Datos

        private void CargarRegistros()
        {
            try
            {
                dgvRegistros.DataSource = null;

                if (_servicioIdActual.HasValue)
                {
                    dgvRegistros.DataSource = _registroNegocio.ListarPorServicio(_servicioIdActual.Value);
                }
                
                ListadoHelper.OcultarColumnas(dgvRegistros,
                    "IdRegistro", "IdEmpleado", "IdEmpresa", "IdServicio", "IdLugar",
                    "Fecha", "Hora", "NombreLugar");
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        #endregion

        #region Eventos

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            ProcesarRegistro();
        }

        private void txtRegistro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ProcesarRegistro();
            }
        }

        private void ProcesarRegistro()
        {
            if (!ValidarServicioActivo()) return;
            if (!ValidarCredencial(out string credencial)) return;

            try
            {
                ProcesarRegistroEmpleado(credencial);
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        #endregion

        #region Validaciones

        private bool ValidarServicioActivo()
        {
            if (!_servicioIdActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_SERVICIO_INACTIVO);
                return false;
            }
            return true;
        }

        private bool ValidarCredencial(out string credencial)
        {
            credencial = txtRegistro.Text.Trim();
            if (string.IsNullOrEmpty(credencial))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_INGRESE_CREDENCIAL_VALIDA);
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
            Empleado empleado = _empleadoNegocio.BuscarPorCredencial(credencial);
            if (empleado == null)
            {
                MensajesUI.MostrarAdvertencia(string.Format(INFO_EMPLEADO_NO_ENCONTRADO, credencial));
                return null;
            }
            return empleado;
        }

        private bool VerificarEmpleadoYaRegistrado(Empleado empleado)
        {
            if (_registroNegocio.EmpleadoYaRegistrado(empleado.IdEmpleado, _servicioIdActual.Value))
            {
                MensajesUI.MostrarInformacion(string.Format(INFO_EMPLEADO_YA_REGISTRADO, empleado.NombreCompleto));
                return true;
            }
            return false;
        }

        private void RegistrarEmpleadoEnServicio(Empleado empleado)
        {
            _registroNegocio.RegistrarEmpleado(empleado.IdEmpleado, empleado.IdEmpresa, _servicioIdActual.Value, _idLugarActual);
            CargarRegistros();
            LimpiarInput();
            _formularioPrincipal?.ActualizarEstadisticas();
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
                var notificacion = new ucNotificacion();
                Control contenedorPadre = this;
                string horaActual = DateTime.Now.ToString("HH:mm:ss");
                
                notificacion.MostrarNotificacion(
                    empleado.NombreCompleto,
                    empleado.NombreEmpresa,
                    horaActual,
                    contenedorPadre,
                    false
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
