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
    public partial class ucAdmin : UserControl
    {
        // VARIABLES DE CLASE
        private ReaLTaiizor.Controls.Button botonActivo;
        private EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
        private EmpresaNegocio empresaNegocio = new EmpresaNegocio();
        private Empleado empleadoSeleccionado = null;
        private bool modoEdicion = false;

        public ucAdmin()
        {
            InitializeComponent();
            // Seleccionar Empleados por defecto
            SeleccionarBoton(btnEmpleados);
        }

        private void ucAdmin_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarEmpresas();
            LimpiarFormularioEmpleado();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpleados);
            MostrarPanel(pnlEmpleados);
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpresas);
            MostrarPanel(pnlEmpresas);
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEstadisticas);
            MostrarPanel(pnlEstadisticas);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnConfiguracion);
            MostrarPanel(pnlConfiguracion);
        }

        private void SeleccionarBoton(ReaLTaiizor.Controls.Button boton)
        {
            // Colores
            Color colorDorado = Color.FromArgb(255, 208, 36);
            Color colorNegro = Color.FromArgb(35, 34, 33);

            // Restaurar botón anterior
            if (botonActivo != null)
            {
                botonActivo.InactiveColor = colorNegro;
                botonActivo.PressedColor = colorDorado;
            }

            // Activar nuevo botón
            botonActivo = boton;
            boton.InactiveColor = colorDorado;
            boton.PressedColor = colorDorado;
        }

        private void MostrarPanel(Panel panelAMostrar)
        {
            // Ocultar todos
            pnlEmpleados.Visible = false;
            pnlEmpresas.Visible = false;
            pnlEstadisticas.Visible = false;
            pnlConfiguracion.Visible = false;

            // Mostrar el seleccionado
            panelAMostrar.Visible = true;
            panelAMostrar.BringToFront();
        }

        // ══════════════════════════════════════════════════════════════
        // MÉTODOS DE CARGA DE DATOS
        // ══════════════════════════════════════════════════════════════

        private void CargarEmpleados(string filtro = "")
        {
            // Configurar columnas del DataGridView si no están configuradas
            if (dgvEmpleados.Columns.Count == 0)
            {
                dgvEmpleados.Columns.Add("IdEmpleado", "ID");
                dgvEmpleados.Columns["IdEmpleado"].Visible = false;
                dgvEmpleados.Columns.Add("Credencial", "Credencial");
                dgvEmpleados.Columns["Credencial"].FillWeight = 20;
                dgvEmpleados.Columns.Add("NombreCompleto", "Nombre Completo");
                dgvEmpleados.Columns["NombreCompleto"].FillWeight = 40;
                dgvEmpleados.Columns.Add("Empresa", "Empresa");
                dgvEmpleados.Columns["Empresa"].FillWeight = 30;
                dgvEmpleados.Columns.Add("Estado", "Estado");
                dgvEmpleados.Columns["Estado"].FillWeight = 10;
            }

            var empleados = empleadoNegocio.listar();
            if (empleados == null) return;
            
            // Aplicar filtros si existen
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                empleados = empleados.FindAll(e => 
                    e.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                    e.Apellido.ToUpper().Contains(filtro.ToUpper()) ||
                    e.IdCredencial.Contains(filtro)
                );
            }

                // Filtrar por empresa si está seleccionada
                if (cbFiltroEmpresa.SelectedIndex > 0)
                {
                    int idEmpresa = (int)cbFiltroEmpresa.SelectedValue;
                    empleados = empleados.FindAll(e => e.Empresa.IdEmpresa == idEmpresa);
                }

            dgvEmpleados.Rows.Clear();
            foreach (var emp in empleados)
            {
                dgvEmpleados.Rows.Add(
                    emp.IdEmpleado,
                    emp.IdCredencial,
                    $"{emp.Nombre} {emp.Apellido}",
                    emp.Empresa.Nombre,
                    emp.Estado ? "Activo" : "Inactivo"
                );
            }

            lblTotalEmpleados.Text = $"Total: {dgvEmpleados.RowCount} empleados";
        }

        private void CargarEmpresas()
        {
            var empresas = empresaNegocio.listar();
            if (empresas == null) return;
            
            // Para el filtro (con opción "Todas")
            var empresasFiltro = new List<Empresa>();
            empresasFiltro.Add(new Empresa { IdEmpresa = 0, Nombre = "Todas las empresas" });
            empresasFiltro.AddRange(empresas);
            
            cbFiltroEmpresa.DataSource = empresasFiltro;
            cbFiltroEmpresa.DisplayMember = "Nombre";
            cbFiltroEmpresa.ValueMember = "IdEmpresa";
            
            // Para el formulario de edición
            cbEmpresaEmpleado.DataSource = empresas;
            cbEmpresaEmpleado.DisplayMember = "Nombre";
            cbEmpresaEmpleado.ValueMember = "IdEmpresa";
        }

        // ══════════════════════════════════════════════════════════════
        // EVENTOS DE EMPLEADOS
        // ══════════════════════════════════════════════════════════════

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
            
            // Si existe y NO estamos en modo edición, es un problema
            // Si existe y SÍ estamos en modo edición, verificar que sea la misma credencial
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

        // ══════════════════════════════════════════════════════════════
        // MÉTODOS AUXILIARES
        // ══════════════════════════════════════════════════════════════

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
