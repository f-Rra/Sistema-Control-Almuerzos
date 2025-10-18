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
    public partial class ucEmpresas : UserControl
    {
        private EmpresaNegocio negE = new EmpresaNegocio();
        private Empresa seleccionada = null;
        private bool modoEdicion = false;

        public ucEmpresas()
        {
            InitializeComponent();
        }

        private void ucEmpresas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarEmpresas();
                LimpiarFormulario();
                LimpiarEstadisticas();         
                txtBuscarEmpresa.TextChanged += txtBuscarEmpresa_TextChanged;
            }
            catch (Exception ex)
            {
                ExceptionHelper.MostrarError($"Error al cargar empresas: {ex.Message}");
            }
        }

        private void CargarEmpresas(string filtro = "")
        {
            try
            {
                var empresas = negE.listarConEmpleados();
                if (empresas == null) return;

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    empresas = empresas.FindAll(e =>
                        e.Nombre.ToUpper().Contains(filtro.ToUpper()) 
                    );
                }

                dgvEmpresas.DataSource = null;
                dgvEmpresas.AutoGenerateColumns = true;
                dgvEmpresas.DataSource = empresas;
                OcultarColumnas();
                lblTotalEmpresas.Text = $"Total Empresas: {empresas.Count}";
            }
            catch (Exception ex)
            {
                ExceptionHelper.MostrarError($"Error al cargar empresas: {ex.Message}\n\nDetalles: {ex.StackTrace}");
            }
        }

        private void OcultarColumnas()
        {
            var cols = dgvEmpresas?.Columns;
            if (cols == null) return;

            string[] aOcultar = { "IdEmpresa", "Estado" };
            foreach (var nombre in aOcultar)
            {
                if (cols.Contains(nombre))
                {
                    cols[nombre].Visible = false;
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            rbActivoEmpresa.Checked = true;
            btnEliminarEmpresa.Enabled = false;
            seleccionada = null;
            modoEdicion = false;
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                ExceptionHelper.MostrarAdvertencia("Ingrese el nombre de la empresa");
                txtNombre.Focus();
                return false;
            }

            if (txtNombre.Text.Trim().Length < 2)
            {
                ExceptionHelper.MostrarAdvertencia("El nombre debe tener al menos 2 caracteres");
                txtNombre.Focus();
                return false;
            }

            var empresas = negE.listar();
            if (empresas != null)
            {
                bool existe = empresas.Exists(e =>
                    e.Nombre.Trim().ToUpper() == txtNombre.Text.Trim().ToUpper() &&
                    (!modoEdicion || e.IdEmpresa != seleccionada.IdEmpresa)
                );

                if (existe)
                {
                    ExceptionHelper.MostrarAdvertencia("Ya existe una empresa con ese nombre");
                    txtNombre.Focus();
                    return false;
                }
            }

            return true;
        }

        private void CargarEmpresa(Empresa aux)
        {
            if (modoEdicion && seleccionada != null)
            {
                aux.IdEmpresa = seleccionada.IdEmpresa;
            }
            aux.Nombre = txtNombre.Text.Trim();
            aux.Estado = rbActivoEmpresa.Checked;
        }

        private void CargarEmpresaEnFormulario(int idEmpresa)
        {
            seleccionada = negE.buscarPorId(idEmpresa);
            if (seleccionada == null) return;
            txtNombre.Text = seleccionada.Nombre;
            if (seleccionada.Estado) rbActivoEmpresa.Checked = true;
            else rbInactivoEmpresa.Checked = true;
            modoEdicion = true;
            btnEliminarEmpresa.Enabled = true;
        }

        private void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            modoEdicion = false;
            seleccionada = null;
            txtNombre.Focus();
        }

        private void btnEliminarEmpresa_Click(object sender, EventArgs e)
        {
            if (seleccionada == null) return;

            if (seleccionada.CantidadEmpleados > 0)
            {
                ExceptionHelper.MostrarAdvertencia(
                    $"No se puede desactivar la empresa '{seleccionada.Nombre}' " +
                    $"porque tiene {seleccionada.CantidadEmpleados} empleado(s) activo(s).\n\n" +
                    "Primero desactive o transfiera los empleados a otra empresa."
                );
                return;
            }

            if (ExceptionHelper.MostrarConfirmacion($"¿Está seguro de desactivar la empresa '{seleccionada.Nombre}'?"))
            {
                negE.eliminar(seleccionada.IdEmpresa);
                ExceptionHelper.MostrarExito("Empresa desactivada correctamente");
                CargarEmpresas();
                LimpiarFormulario();
            }
        }

        private void btnCancelarEmpresa_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardarEmpresa_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;
            Empresa emp = new Empresa();
            CargarEmpresa(emp);
            if (modoEdicion) negE.modificar(emp);
            else negE.agregar(emp);
            ExceptionHelper.MostrarExito("Empresa guardada correctamente");
            CargarEmpresas();
            LimpiarFormulario();
        }

        private void dgvEmpresas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmpresas.CurrentRow != null && dgvEmpresas.CurrentRow.Cells["IdEmpresa"].Value != null)
                {
                    int idEmpresa = Convert.ToInt32(dgvEmpresas.CurrentRow.Cells["IdEmpresa"].Value);
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

        private void CargarEstadisticasEmpresa(int idEmpresa)
        {
            try
            {
                // Obtener la empresa seleccionada con su información completa
                var empresa = negE.buscarPorId(idEmpresa);
                if (empresa == null)
                {
                    LimpiarEstadisticas();
                    return;
                }

                // Total de empleados activos (desde la vista que ya tiene este dato)
                var empresas = negE.listarConEmpleados();
                var empresaConEmpleados = empresas?.Find(e => e.IdEmpresa == idEmpresa);
                int totalEmpleados = empresaConEmpleados?.CantidadEmpleados ?? 0;
                lblTotalEmpleados.Text = $"Total de Empleados: {totalEmpleados}";

                // Empleados inactivos de esta empresa
                var empleadoNegocio = new EmpleadoNegocio();
                var todosEmpleados = empleadoNegocio.listar();
                int inactivos = 0;
                if (todosEmpleados != null)
                {
                    inactivos = todosEmpleados.Count(emp => emp.IdEmpresa == idEmpresa && !emp.Estado);
                }
                lblEmpleadosInactivos.Text = $"Empleados Inactivos: {inactivos}";

                // Asistencias del mes actual
                var registroNegocio = new RegistroNegocio();
                DateTime inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);
                
                var registros = registroNegocio.obtenerRegistrosPorEmpresaYFecha(idEmpresa, inicioMes, finMes);
                int asistenciasMes = registros?.Count ?? 0;
                lblAsistencias.Text = $"Asistencias (Mes Actual): {asistenciasMes}";

                // Promedio diario (basado en los días transcurridos del mes)
                int diasTranscurridos = DateTime.Now.Day;
                double promedioDiario = diasTranscurridos > 0 ? (double)asistenciasMes / diasTranscurridos : 0;
                lblPromedio.Text = $"Promedio Diario: {promedioDiario:F1}";
            }
            catch (Exception ex)
            {
                LimpiarEstadisticas();
                System.Diagnostics.Debug.WriteLine($"Error al cargar estadísticas: {ex.Message}");
            }
        }

        private void LimpiarEstadisticas()
        {
            lblTotalEmpleados.Text = "Total de Empleados: -";
            lblEmpleadosInactivos.Text = "Empleados Inactivos: -";
            lblAsistencias.Text = "Asistencias (Mes Actual): -";
            lblPromedio.Text = "Promedio Diario: -";
        }

        public void RefrescarDatos()
        {
            CargarEmpresas();
            LimpiarFormulario();
            LimpiarEstadisticas();
        }
    }
}
