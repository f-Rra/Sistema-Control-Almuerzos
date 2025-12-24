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
    public partial class ucEmpresas : UserControl
    {
        #region Variables y Constantes

        private EmpresaNegocio empresaNegocio;
        private EmpleadoNegocio empleadoNegocio;
        private RegistroNegocio registroNegocio;
        private Empresa seleccionada = null;
        private bool modoEdicion = false;

        #endregion

        #region Constructor e Inicialización

        public ucEmpresas()
        {
            InitializeComponent();
            empresaNegocio = new EmpresaNegocio();
            empleadoNegocio = new EmpleadoNegocio();
            registroNegocio = new RegistroNegocio();
        }

        private void ucEmpresas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosIniciales();
                ConfigurarEventos();
            }
            catch (Exception ex)
            {
                MensajesUI.MostrarError(string.Format(ERROR_CARGAR_EMPRESAS, ex.Message));
            }
        }

        private void CargarDatosIniciales()
        {
            CargarEmpresas();
            LimpiarFormulario();
            LimpiarEstadisticas();
        }

        private void ConfigurarEventos()
        {
            txtBuscarEmpresa.TextChanged += txtBuscarEmpresa_TextChanged;
        }

        public void RefrescarDatos()
        {
            CargarDatosIniciales();
        }

        #endregion

        #region Carga de Datos

        private void CargarEmpresas(string filtro = "")
        {
            try
            {
                // Filtrado optimizado en BD
                string filtroTexto = string.IsNullOrWhiteSpace(filtro) ? null : filtro;
                var empresas = empresaNegocio.FiltrarEmpresas(filtroTexto);
                if (empresas == null) return;

                ActualizarDgvEmpresas(empresas);
                ActualizarContadorEmpresas(empresas.Count);
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void ActualizarDgvEmpresas(List<Empresa> empresas)
        {
            dgvEmpresas.DataSource = null;
            dgvEmpresas.AutoGenerateColumns = true;
            dgvEmpresas.DataSource = empresas;
            OcultarColumnas();
        }

        private void ActualizarContadorEmpresas(int total)
        {
            lblTotalEmpresas.Text = $"Total Empresas: {total}";
        }

        private void OcultarColumnas()
        {
            var cols = dgvEmpresas?.Columns;
            if (cols == null) return;

            ConfigurarVisibilidadColumnas(cols);
        }

        private void ConfigurarVisibilidadColumnas(DataGridViewColumnCollection cols)
        {
            ListadoHelper.OcultarColumnas(dgvEmpresas, "IdEmpresa", "Estado");
        }

        #endregion

        #region Gestión de Formulario

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            rbActivoEmpresa.Checked = true;
            btnEliminarEmpresa.Enabled = false;
            seleccionada = null;
            modoEdicion = false;
        }

        private void CargarEmpresaEnFormulario(int idEmpresa)
        {
            try
            {
                seleccionada = empresaNegocio.BuscarPorId(idEmpresa);
                if (seleccionada == null) return;

                MostrarDatosEmpresa();
                ConfigurarModoEdicion();
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void MostrarDatosEmpresa()
        {
            txtNombre.Text = seleccionada.Nombre;
            
            rbActivoEmpresa.Checked = seleccionada.Estado;
            rbInactivoEmpresa.Checked = !seleccionada.Estado;
        }

        private void ConfigurarModoEdicion()
        {
            modoEdicion = true;
            btnEliminarEmpresa.Enabled = true;
        }

        #endregion

        #region Validación

        private bool ValidarFormulario()
        {
            if (!ValidarNombreEmpresa()) return false;
            if (!ValidarLongitudNombre()) return false;
            if (!ValidarFormatoNombre()) return false;
            if (!ValidarNombreDuplicado()) return false;

            return true;
        }

        private bool ValidarNombreEmpresa()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_INGRESE_NOMBRE_EMPRESA);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarLongitudNombre()
        {
            if (txtNombre.Text.Trim().Length < 2)
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_NOMBRE_MINIMO);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarFormatoNombre()
        {
            if (!ValidarNombre(txtNombre.Text))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_NOMBRE_EMPRESA_CARACTERES);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarNombreDuplicado()
        {
            try
            {
                var empresas = empresaNegocio.Listar();
                if (empresas != null)
                {
                    bool existe = empresas.Exists(e =>
                        e.Nombre.Trim().ToUpper() == txtNombre.Text.Trim().ToUpper() &&
                        (!modoEdicion || e.IdEmpresa != seleccionada.IdEmpresa)
                    );

                    if (existe)
                    {
                        MensajesUI.MostrarAdvertencia(VALIDACION_EMPRESA_DUPLICADA);
                        txtNombre.Focus();
                        return false;
                    }
                }
                return true;
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
                return false;
            }
        }

        private bool ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;
            
            System.Text.RegularExpressions.Regex regex = 
                new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s\-]+$");
            
            return regex.IsMatch(nombre);
        }

        #endregion

        #region Operaciones ABML

        private void NuevaEmpresa()
        {
            LimpiarFormulario();
            modoEdicion = false;
            seleccionada = null;
            txtNombre.Focus();
        }

        private void GuardarEmpresa()
        {
            if (!ValidarFormulario()) return;

            try
            {
                Empresa emp = new Empresa();
                CargarEmpresa(emp);

                if (modoEdicion)
                    empresaNegocio.Modificar(emp);
                else
                    empresaNegocio.Agregar(emp);

                MensajesUI.MostrarExito(EXITO_EMPRESA_GUARDADA);
                CargarEmpresas();
                LimpiarFormulario();
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void CargarEmpresa(Empresa emp)
        {
            if (modoEdicion && seleccionada != null)
            {
                emp.IdEmpresa = seleccionada.IdEmpresa;
            }
            emp.Nombre = txtNombre.Text.Trim();
            emp.Estado = rbActivoEmpresa.Checked;
        }

        private void EliminarEmpresa()
        {
            if (seleccionada == null) return;

            if (!ValidarEliminacionEmpresa()) return;

            if (MensajesUI.MostrarConfirmacion(string.Format(CONFIRMACION_DESACTIVAR_EMPRESA, seleccionada.Nombre)))
            {
                try
                {
                    empresaNegocio.Eliminar(seleccionada.IdEmpresa);
                    MensajesUI.MostrarExito(EXITO_EMPRESA_DESACTIVADA);
                    CargarEmpresas();
                    LimpiarFormulario();
                }
                catch (NegocioException ex)
                {
                    MensajesUI.ManejarExcepcion(ex);
                }
            }
        }

        private bool ValidarEliminacionEmpresa()
        {
            if (seleccionada.CantidadEmpleados > 0)
            {
                MensajesUI.MostrarAdvertencia(string.Format(
                    ADVERTENCIA_EMPRESA_CON_EMPLEADOS,
                    seleccionada.Nombre,
                    seleccionada.CantidadEmpleados
                ));
                return false;
            }
            return true;
        }

        #endregion

        #region Eventos

        private void dgvEmpresas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var cellValue = dgvEmpresas.CurrentRow?.Cells["IdEmpresa"]?.Value;
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    int idEmpresa = Convert.ToInt32(cellValue);
                    CargarEmpresaEnFormulario(idEmpresa);
                    CargarEstadisticasEmpresa(idEmpresa);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en SelectionChanged: {ex.Message}");
            }
        }

        private void txtBuscarEmpresa_TextChanged(object sender, EventArgs e)
        {
            CargarEmpresas(txtBuscarEmpresa.Text);
        }

        private void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            NuevaEmpresa();
        }

        private void btnGuardarEmpresa_Click(object sender, EventArgs e)
        {
            GuardarEmpresa();
        }

        private void btnEliminarEmpresa_Click(object sender, EventArgs e)
        {
            EliminarEmpresa();
        }

        private void btnCancelarEmpresa_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        #endregion

        #region Estadísticas

        private void CargarEstadisticasEmpresa(int idEmpresa)
        {
            try
            {
                var empresa = empresaNegocio.BuscarPorId(idEmpresa);
                if (empresa == null)
                {
                    LimpiarEstadisticas();
                    return;
                }

                int totalEmpleados = ObtenerTotalEmpleados(idEmpresa);
                int inactivos = ObtenerEmpleadosInactivos(idEmpresa);
                int asistenciasMes = ObtenerAsistenciasMes(idEmpresa);
                double promedioDiario = CalcularPromedioDiario(asistenciasMes);

                ActualizarEstadisticas(totalEmpleados, inactivos, asistenciasMes, promedioDiario);
            }
            catch (Exception ex)
            {
                LimpiarEstadisticas();
                System.Diagnostics.Debug.WriteLine($"Error al cargar estadísticas: {ex.Message}");
            }
        }

        private int ObtenerTotalEmpleados(int idEmpresa)
        {
            var empresas = empresaNegocio.ListarConEmpleados();
            var empresaConEmpleados = empresas?.Find(e => e.IdEmpresa == idEmpresa);
            return empresaConEmpleados?.CantidadEmpleados ?? 0;
        }

        private int ObtenerEmpleadosInactivos(int idEmpresa)
        {
            var todosEmpleados = empleadoNegocio.Listar();
            
            if (todosEmpleados != null)
            {
                return todosEmpleados.Count(emp => emp.IdEmpresa == idEmpresa && !emp.Estado);
            }
            return 0;
        }

        private int ObtenerAsistenciasMes(int idEmpresa)
        {
            DateTime inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);
            
            var registros = registroNegocio.ObtenerRegistrosPorEmpresaYFecha(idEmpresa, inicioMes, finMes);
            return registros?.Count ?? 0;
        }

        private double CalcularPromedioDiario(int asistenciasMes)
        {
            int diasTranscurridos = DateTime.Now.Day;
            return diasTranscurridos > 0 ? (double)asistenciasMes / diasTranscurridos : 0;
        }

        private void ActualizarEstadisticas(int totalEmpleados, int inactivos, int asistenciasMes, double promedioDiario)
        {
            lblTotalEmpleados.Text = $"Total de Empleados: {totalEmpleados}";
            lblEmpleadosInactivos.Text = $"Empleados Inactivos: {inactivos}";
            lblAsistencias.Text = $"Asistencias (Mes Actual): {asistenciasMes}";
            lblPromedio.Text = $"Promedio Diario: {promedioDiario:F1}";
        }

        private void LimpiarEstadisticas()
        {
            lblTotalEmpleados.Text = "Total de Empleados: -";
            lblEmpleadosInactivos.Text = "Empleados Inactivos: -";
            lblAsistencias.Text = "Asistencias (Mes Actual): -";
            lblPromedio.Text = "Promedio Diario: -";
        }

        #endregion
    }
}
