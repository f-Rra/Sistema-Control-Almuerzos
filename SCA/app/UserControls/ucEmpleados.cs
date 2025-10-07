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
    public partial class ucEmpleados : UserControl
    {
        private EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
        private EmpresaNegocio empresaNegocio = new EmpresaNegocio();
        private Empleado empleadoSeleccionado = null;
        private bool modoEdicion = false;

        public ucEmpleados()
        {
            InitializeComponent();
        }

        private void ucEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarEmpresas();
            LimpiarFormularioEmpleado();
        }

        private void CargarEmpleados(string filtro = "")
        {
            var empleados = empleadoNegocio.listar();
            if (empleados == null) return;

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                empleados = empleados.FindAll(e =>
                    e.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                    e.Apellido.ToUpper().Contains(filtro.ToUpper()) ||
                    e.IdCredencial.Contains(filtro)
                );
            }

            dgvEmpleados.DataSource = null;
            dgvEmpleados.AutoGenerateColumns = true;
            dgvEmpleados.DataSource = empleados;
            OcultarColumnas();

            lblTotalEmpleados.Text = $"Total: {empleados.Count} empleados";
        }

        private void OcultarColumnas()
        {
            var cols = dgvEmpleados?.Columns;
            if (cols == null) return;

            string[] aMostrar = { "IdCredencial", "NombreCompleto", "Empresa", "Estado" };
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

            string[] orden = { "IdCredencial", "NombreCompleto", "NombreEmpresa", "Estado" };
            int idx = 0;
            foreach (var nombre in orden)
            {
                if (cols.Contains(nombre))
                    cols[nombre].DisplayIndex = idx++;
            }
        }

        private void CargarEmpresas()
        {
            var empresas = empresaNegocio.listar();
            if (empresas == null) return;
            
            var empresasFiltro = new List<Empresa>();
            empresasFiltro.Add(new Empresa { IdEmpresa = 0, Nombre = "Todas las empresas" });
            empresasFiltro.AddRange(empresas);
            
            cbFiltroEmpresa.DataSource = empresasFiltro;
            cbFiltroEmpresa.DisplayMember = "Nombre";
            cbFiltroEmpresa.ValueMember = "IdEmpresa";
            cbEmpresaEmpleado.DataSource = empresas;
            cbEmpresaEmpleado.DisplayMember = "Nombre";
            cbEmpresaEmpleado.ValueMember = "IdEmpresa";
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                int idEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
                CargarEmpleadoEnFormulario(idEmpleado);
            }
        }

        private void CargarEmpleadoEnFormulario(int idEmpleado)
        {
            empleadoSeleccionado = empleadoNegocio.buscarPorId(idEmpleado);
            if (empleadoSeleccionado == null) return;
            
            txtCredencial.Text = empleadoSeleccionado.IdCredencial;
            txtNombre.Text = empleadoSeleccionado.Nombre;
            txtApellido.Text = empleadoSeleccionado.Apellido;
            cbEmpresaEmpleado.SelectedValue = empleadoSeleccionado.Empresa.IdEmpresa;
            
            if (empleadoSeleccionado.Estado)
                rbActivoEmpleado.Checked = true;
            else
                rbInactivoEmpleado.Checked = true;
            
            modoEdicion = true;
            btnEliminarEmpleado.Enabled = true;
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            LimpiarFormularioEmpleado();
            modoEdicion = false;
            empleadoSeleccionado = null;
            txtCredencial.Focus();
        }

        private void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioEmpleado())
                return;

            Empleado emp = new Empleado();
            
            if (modoEdicion && empleadoSeleccionado != null)
                emp.IdEmpleado = empleadoSeleccionado.IdEmpleado;
            
            emp.IdCredencial = txtCredencial.Text.Trim();
            emp.Nombre = txtNombre.Text.Trim();
            emp.Apellido = txtApellido.Text.Trim();
            emp.Empresa = new Empresa();
            emp.Empresa.IdEmpresa = (int)cbEmpresaEmpleado.SelectedValue;
            emp.Estado = rbActivoEmpleado.Checked;

            if (modoEdicion)
                empleadoNegocio.modificar(emp);
            else
                empleadoNegocio.agregar(emp);

            ExceptionHelper.MostrarExito("Empleado guardado correctamente");
            
            CargarEmpleados();
            LimpiarFormularioEmpleado();
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (empleadoSeleccionado == null)
                return;

            if (ExceptionHelper.MostrarConfirmacion(
                $"¿Está seguro de desactivar al empleado {empleadoSeleccionado.Nombre} {empleadoSeleccionado.Apellido}?"))
            {
                empleadoNegocio.eliminar(empleadoSeleccionado.IdEmpleado);
                ExceptionHelper.MostrarExito("Empleado desactivado correctamente");
                CargarEmpleados();
                LimpiarFormularioEmpleado();
            }
        }

        private void btnCancelarEmpleado_Click(object sender, EventArgs e)
        {
            LimpiarFormularioEmpleado();
        }

        private void btnVerificarCredencial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCredencial.Text))
            {
                ExceptionHelper.MostrarAdvertencia("Ingrese un número de credencial");
                return;
            }

            bool existe = empleadoNegocio.existeCredencial(txtCredencial.Text.Trim());
           
            if (existe)
            {
                if (!modoEdicion || 
                    (modoEdicion && empleadoSeleccionado.IdCredencial != txtCredencial.Text.Trim()))
                {
                    ExceptionHelper.MostrarAdvertencia("Esta credencial ya está en uso");
                }
                else
                {
                    ExceptionHelper.MostrarInformacion("Credencial actual del empleado");
                }
            }
            else
            {
                ExceptionHelper.MostrarInformacion("Credencial disponible");
            }
        }

        private void txtBuscarEmpleado_TextChanged(object sender, EventArgs e)
        {
            CargarEmpleados(txtBuscarEmpleado.Text);
        }

        private bool ValidarFormularioEmpleado()
        {
            if (string.IsNullOrWhiteSpace(txtCredencial.Text))
            {
                ExceptionHelper.MostrarAdvertencia("Ingrese el número de credencial");
                txtCredencial.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                ExceptionHelper.MostrarAdvertencia("Ingrese el nombre");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                ExceptionHelper.MostrarAdvertencia("Ingrese el apellido");
                txtApellido.Focus();
                return false;
            }

            if (cbEmpresaEmpleado.SelectedIndex == -1)
            {
                ExceptionHelper.MostrarAdvertencia("Seleccione una empresa");
                return false;
            }

            return true;
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
    }
}
