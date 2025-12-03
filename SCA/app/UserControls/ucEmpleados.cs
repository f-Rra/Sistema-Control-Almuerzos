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
                var empleados = empleadoNegocio.Listar();
                if (empleados == null) return;

                empleados = AplicarFiltros(empleados, filtro, idEmpresa);
                ActualizarDgvEmpleados(empleados);
                ActualizarContadorEmpleados(empleados.Count);
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private List<Empleado> AplicarFiltros(List<Empleado> empleados, string filtro, int idEmpresa)
        {
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                empleados = empleados.FindAll(e =>
                    e.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                    e.Apellido.ToUpper().Contains(filtro.ToUpper()) ||
                    e.IdCredencial.Contains(filtro)
                );
            }

            if (idEmpresa > 0)
            {
                empleados = empleados.FindAll(e => e.Empresa.IdEmpresa == idEmpresa);
            }

            return empleados;
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
            var cols = dgvEmpleados?.Columns;
            if (cols == null) return;

            ConfigurarVisibilidadColumnas(cols);
            ConfigurarOrdenColumnas(cols);
        }

        private void ConfigurarVisibilidadColumnas(DataGridViewColumnCollection cols)
        {
            string[] aMostrar = { "NombreCompleto", "Empresa" };
            
            foreach (DataGridViewColumn col in cols)
            {
                if (col.Name == "Empresa")
                {
                    col.Visible = false;
                    if (cols.Contains("NombreEmpresa"))
                    {
                        cols["NombreEmpresa"].Visible = true;
                        cols["NombreEmpresa"].HeaderText = "Empresa";
                    }
                }
                else if (!aMostrar.Contains(col.Name))
                {
                    col.Visible = false;
                }
                else
                {
                    col.Visible = true;
                }
            }
        }

        private void ConfigurarOrdenColumnas(DataGridViewColumnCollection cols)
        {
            string[] orden = { "NombreCompleto", "NombreEmpresa" };
            int idx = 0;
            
            foreach (var nombre in orden)
            {
                if (cols.Contains(nombre))
                    cols[nombre].DisplayIndex = idx++;
            }
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
            var empresasFiltro = (List<Empresa>)cbFiltroEmpresa.DataSource;
            
            if (selectedValueFiltro != null && empresasFiltro.Exists(e => e.IdEmpresa == (int)selectedValueFiltro))
            {
                cbFiltroEmpresa.SelectedValue = selectedValueFiltro;
            }
            
            if (selectedValueEmpleado != null && empresas.Exists(e => e.IdEmpresa == (int)selectedValueEmpleado))
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
            cbEmpresaEmpleado.SelectedValue = empleadoSeleccionado.Empresa.IdEmpresa;
            
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
            emp.Empresa = new Empresa { IdEmpresa = (int)cbEmpresaEmpleado.SelectedValue };
            emp.Estado = rbActivoEmpleado.Checked;
        }

        private void EliminarEmpleado()
        {
            if (empleadoSeleccionado == null) return;

            if (MensajesUI.MostrarConfirmacion("¿Está seguro de desactivar al empleado?"))
            {
                try
                {
                    empleadoNegocio.Eliminar(empleadoSeleccionado.IdEmpleado);
                    MensajesUI.MostrarExito("Empleado desactivado correctamente");
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
                MensajesUI.MostrarAdvertencia("Ingrese un número de credencial");
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
                    MensajesUI.MostrarAdvertencia("Esta credencial ya está en uso");
                }
                else
                {
                    MensajesUI.MostrarInformacion("Credencial actual del empleado");
                }
            }
            else
            {
                MensajesUI.MostrarInformacion("Credencial disponible");
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
                int idEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
                CargarEmpleadoEnFormulario(idEmpleado);
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
                MensajesUI.MostrarAdvertencia("Ingrese el número de credencial");
                txtCredencial.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarNombreEmpleado()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MensajesUI.MostrarAdvertencia("Ingrese el nombre");
                txtNombre.Focus();
                return false;
            }

            if (!ValidarNombre(txtNombre.Text))
            {
                MensajesUI.MostrarAdvertencia("El nombre solo puede contener letras, espacios, tildes y guiones");
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarApellidoEmpleado()
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MensajesUI.MostrarAdvertencia("Ingrese el apellido");
                txtApellido.Focus();
                return false;
            }

            if (!ValidarNombre(txtApellido.Text))
            {
                MensajesUI.MostrarAdvertencia("El apellido solo puede contener letras, espacios, tildes y guiones");
                txtApellido.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarEmpresaSeleccionada()
        {
            if (cbEmpresaEmpleado.SelectedIndex == -1)
            {
                MensajesUI.MostrarAdvertencia("Seleccione una empresa");
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
