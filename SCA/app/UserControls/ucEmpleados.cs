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
    public partial class ucEmpleados : UserControl
    {
        #region Variables y Constantes

        private EmpleadoNegocio empleadoNegocio;
        private EmpresaNegocio empresaNegocio;

        private Empleado empleadoSeleccionado = null;
        private bool modoEdicion = false;

        #endregion

        #region Constructor e Inicialización

        public ucEmpleados()
        {
            InitializeComponent();
            empleadoNegocio = new EmpleadoNegocio();
            empresaNegocio = new EmpresaNegocio();
        }

        private void ucEmpleados_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            CargarEmpleados();
            CargarEmpresas();
            LimpiarFormularioEmpleado();
        }

        public void RefrescarDatos()
        {
            CargarDatosIniciales();
        }

        #endregion

        #region Carga de Datos

        private void CargarEmpleados(string filtro = "", int idEmpresa = 0)
        {
            try
            {
                // Filtrado optimizado en BD
                int? idEmpresaFiltro = idEmpresa > 0 ? (int?)idEmpresa : null;
                string filtroTexto = string.IsNullOrWhiteSpace(filtro) ? null : filtro;

                var empleados = empleadoNegocio.FiltrarEmpleados(filtroTexto, idEmpresaFiltro);
                if (empleados == null) return;

                ActualizarDgvEmpleados(empleados);
                ActualizarContadorEmpleados(empleados.Count);
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void ActualizarDgvEmpleados(List<Empleado> empleados)
        {
            dgvEmpleados.DataSource = null;
            dgvEmpleados.AutoGenerateColumns = true;
            dgvEmpleados.DataSource = empleados;
            OcultarColumnas();
        }

        private void ActualizarContadorEmpleados(int total)
        {
            lblTotalEmpleados.Text = $"Total Empleados: {total}";
        }

        private void OcultarColumnas()
        {
            // Ocultar columnas internas
            ListadoHelper.OcultarColumnas(dgvEmpleados, 
                "IdEmpleado", "IdCredencial", "IdEmpresa", "Estado", "Empresa", "NombreCompleto");
            
            // Configurar encabezados
            ListadoHelper.ConfigurarHeaders(dgvEmpleados,
                ("NombreEmpresa", "Empresa"));
            
            // Configurar orden
            ListadoHelper.ConfigurarOrden(dgvEmpleados, "NombreEmpresa", 0);
        }

        private void CargarEmpresas()
        {
            try
            {
                var empresas = empresaNegocio.Listar();
                if (empresas == null) return;
            
            object selectedValueFiltro = cbFiltroEmpresa.SelectedValue;
            object selectedValueEmpleado = cbEmpresaEmpleado.SelectedValue;
            
            ConfigurarCbEmpresas(empresas);
                RestaurarSelecciones(empresas, selectedValueFiltro, selectedValueEmpleado);
                ActualizarContadorEmpresas(empresas.Count);
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void ConfigurarCbEmpresas(List<Empresa> empresas)
        {
            cbFiltroEmpresa.DataSource = null;
            cbEmpresaEmpleado.DataSource = null;
            
            var empresasFiltro = new List<Empresa>();
            empresasFiltro.Add(new Empresa { IdEmpresa = 0, Nombre = "Todas" });
            empresasFiltro.AddRange(empresas);
            
            cbFiltroEmpresa.DataSource = empresasFiltro;
            cbFiltroEmpresa.DisplayMember = "Nombre";
            cbFiltroEmpresa.ValueMember = "IdEmpresa";
            
            cbEmpresaEmpleado.DataSource = new List<Empresa>(empresas);
            cbEmpresaEmpleado.DisplayMember = "Nombre";
            cbEmpresaEmpleado.ValueMember = "IdEmpresa";
        }

        private void RestaurarSelecciones(List<Empresa> empresas, object selectedValueFiltro, object selectedValueEmpleado)
        {
            var empresasFiltro = cbFiltroEmpresa.DataSource as List<Empresa>;
            
            if (selectedValueFiltro is int idFiltro && empresasFiltro != null && empresasFiltro.Exists(e => e.IdEmpresa == idFiltro))
            {
                cbFiltroEmpresa.SelectedValue = selectedValueFiltro;
            }
            
            if (selectedValueEmpleado is int idEmpleado && empresas.Exists(e => e.IdEmpresa == idEmpleado))
            {
                cbEmpresaEmpleado.SelectedValue = selectedValueEmpleado;
            }
        }

        private void ActualizarContadorEmpresas(int total)
        {
            lblTotalEmpresas.Text = $"Total Empresas: {total}";
        }

        #endregion

        #region Gestión de Formulario

        private void CargarEmpleadoEnFormulario(int idEmpleado)
        {
            try
            {
                empleadoSeleccionado = empleadoNegocio.BuscarPorId(idEmpleado);
                if (empleadoSeleccionado == null) return;

                MostrarDatosEmpleado();
                ConfigurarModoEdicion();
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void MostrarDatosEmpleado()
        {
            txtCredencial.Text = empleadoSeleccionado.IdCredencial;
            txtNombre.Text = empleadoSeleccionado.Nombre;
            txtApellido.Text = empleadoSeleccionado.Apellido;
            cbEmpresaEmpleado.SelectedValue = empleadoSeleccionado.IdEmpresa;
            
            rbActivoEmpleado.Checked = empleadoSeleccionado.Estado;
            rbInactivoEmpleado.Checked = !empleadoSeleccionado.Estado;
        }

        private void ConfigurarModoEdicion()
        {
            modoEdicion = true;
            btnEliminarEmpleado.Enabled = true;
        }

        private void LimpiarFormularioEmpleado()
        {
            txtCredencial.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            cbEmpresaEmpleado.SelectedIndex = -1;
            rbActivoEmpleado.Checked = true;
            btnEliminarEmpleado.Enabled = false;
            empleadoSeleccionado = null;
            modoEdicion = false;
        }

        #region Operaciones ABML

        private void NuevoEmpleado()
        {
            LimpiarFormularioEmpleado();
            modoEdicion = false;
            empleadoSeleccionado = null;
            txtCredencial.Focus();
        }

        private void GuardarEmpleado()
        {
            if (!ValidarFormularioEmpleado()) return;

            try
            {
                Empleado emp = new Empleado();
                CargarEmpleado(emp);

                if (modoEdicion)
                    empleadoNegocio.Modificar(emp);
                else
                    empleadoNegocio.Agregar(emp);

                MensajesUI.MostrarExito("Empleado guardado correctamente");
                CargarEmpleados();
                LimpiarFormularioEmpleado();
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void CargarEmpleado(Empleado emp)
        {
            if (modoEdicion && empleadoSeleccionado != null)
            {
                emp.IdEmpleado = empleadoSeleccionado.IdEmpleado;
            }

            emp.IdCredencial = txtCredencial.Text.Trim();
            emp.Nombre = txtNombre.Text.Trim();
            emp.Apellido = txtApellido.Text.Trim();
            
            if (cbEmpresaEmpleado.SelectedValue is int idEmpresa)
            {
                emp.Empresa = new Empresa { IdEmpresa = idEmpresa };
            }
            
            emp.Estado = rbActivoEmpleado.Checked;
        }

        private void EliminarEmpleado()
        {
            if (empleadoSeleccionado == null) return;

            if (MensajesUI.MostrarConfirmacion(CONFIRMACION_DESACTIVAR_EMPLEADO))
            {
                try
                {
                    empleadoNegocio.Eliminar(empleadoSeleccionado.IdEmpleado);
                    MensajesUI.MostrarExito(EXITO_EMPLEADO_DESACTIVADO);
                    CargarEmpleados();
                    LimpiarFormularioEmpleado();
                }
                catch (NegocioException ex)
                {
                    MensajesUI.ManejarExcepcion(ex);
                }
            }
        }

        #endregion

        #region Verificación de Credencial

        private void VerificarCredencial()
        {
            if (string.IsNullOrWhiteSpace(txtCredencial.Text))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_INGRESE_CREDENCIAL);
                return;
            }

            try
            {
                bool existe = empleadoNegocio.ExisteCredencial(txtCredencial.Text.Trim());
                MostrarResultadoVerificacion(existe);
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void MostrarResultadoVerificacion(bool existe)
        {
            if (existe)
            {
                if (!modoEdicion || (modoEdicion && empleadoSeleccionado.IdCredencial != txtCredencial.Text.Trim()))
                {
                    MensajesUI.MostrarAdvertencia(VALIDACION_CREDENCIAL_EN_USO);
                }
                else
                {
                    MensajesUI.MostrarInformacion(EXITO_CREDENCIAL_ACTUAL);
                }
            }
            else
            {
                MensajesUI.MostrarInformacion(EXITO_CREDENCIAL_DISPONIBLE);
            }
        }

        #endregion

        #region Filtrado

        private int ObtenerIdEmpresaFiltro()
        {
            int idEmpresa = 0;
            if (cbFiltroEmpresa.SelectedValue != null && int.TryParse(cbFiltroEmpresa.SelectedValue.ToString(), out int temp))
            {
                idEmpresa = temp;
            }
            return idEmpresa;
        }

        #endregion

        #region Eventos

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                var cellValue = dgvEmpleados.CurrentRow.Cells["IdEmpleado"]?.Value;
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    int idEmpleado = Convert.ToInt32(cellValue);
                    CargarEmpleadoEnFormulario(idEmpleado);
                }
            }
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            NuevoEmpleado();
        }

        private void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            GuardarEmpleado();
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            EliminarEmpleado();
        }

        private void btnCancelarEmpleado_Click(object sender, EventArgs e)
        {
            LimpiarFormularioEmpleado();
        }

        private void btnVerificarCredencial_Click(object sender, EventArgs e)
        {
            VerificarCredencial();
        }

        private void txtBuscarEmpleado_TextChanged(object sender, EventArgs e)
        {
            int idEmpresa = ObtenerIdEmpresaFiltro();
            CargarEmpleados(txtBuscarEmpleado.Text, idEmpresa);
        }

        private void cbFiltroEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltroEmpresa.SelectedValue == null) return;
            int idEmpresa = ObtenerIdEmpresaFiltro();
            CargarEmpleados(txtBuscarEmpleado.Text, idEmpresa);
        }

        #endregion

        #endregion

        #region Validación

        private bool ValidarFormularioEmpleado()
        {
            if (!ValidarCredencial()) return false;
            if (!ValidarNombreEmpleado()) return false;
            if (!ValidarApellidoEmpleado()) return false;
            if (!ValidarEmpresaSeleccionada()) return false;

            return true;
        }

        private bool ValidarCredencial()
        {
            if (string.IsNullOrWhiteSpace(txtCredencial.Text))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_INGRESE_CREDENCIAL_EMPLEADO);
                txtCredencial.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarNombreEmpleado()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_INGRESE_NOMBRE);
                txtNombre.Focus();
                return false;
            }

            if (!ValidarNombre(txtNombre.Text))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_NOMBRE_SOLO_LETRAS);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarApellidoEmpleado()
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_INGRESE_APELLIDO);
                txtApellido.Focus();
                return false;
            }

            if (!ValidarNombre(txtApellido.Text))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_APELLIDO_SOLO_LETRAS);
                txtApellido.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarEmpresaSeleccionada()
        {
            if (cbEmpresaEmpleado.SelectedIndex == -1)
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_SELECCIONE_EMPRESA);
                return false;
            }
            return true;
        }

        private bool ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;
            
            System.Text.RegularExpressions.Regex regex = 
                new System.Text.RegularExpressions.Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-]+$");
            
            return regex.IsMatch(nombre);
        }

        #endregion
    }
}
