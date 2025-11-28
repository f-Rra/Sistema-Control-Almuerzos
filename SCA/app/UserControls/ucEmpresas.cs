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
    public partial class ucEmpresas : UserControl
    {
        #region Variables y Constantes

        private EmpresaNegocio empresaNegocio;
        private Empresa seleccionada = null;
        private bool modoEdicion = false;

        #endregion

        #region Constructor e Inicialización

        public ucEmpresas()
        {
            InitializeComponent();
            empresaNegocio = new EmpresaNegocio();
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
                MensajesUI.MostrarError($"Error al cargar empresas: {ex.Message}");
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
                var empresas = empresaNegocio.ListarConEmpleados();
                if (empresas == null) return;

                empresas = AplicarFiltro(empresas, filtro);
                ActualizarDgvEmpresas(empresas);
                ActualizarContadorEmpresas(empresas.Count);
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private List<Empresa> AplicarFiltro(List<Empresa> empresas, string filtro)
        {
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                empresas = empresas.FindAll(e =>
                    e.Nombre.ToUpper().Contains(filtro.ToUpper())
                );
            }
            return empresas;
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
            string[] aOcultar = { "IdEmpresa", "Estado" };
            foreach (var nombre in aOcultar)
            {
                if (cols.Contains(nombre))
                {
                    cols[nombre].Visible = false;
                }
            }
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
            
            if (seleccionada.Estado)
                rbActivoEmpresa.Checked = true;
            else
                rbInactivoEmpresa.Checked = true;
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
                MensajesUI.MostrarAdvertencia("Ingrese el nombre de la empresa");
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarLongitudNombre()
        {
            if (txtNombre.Text.Trim().Length < 2)
            {
                MensajesUI.MostrarAdvertencia("El nombre debe tener al menos 2 caracteres");
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarFormatoNombre()
        {
            if (!ValidarNombre(txtNombre.Text))
            {
                MensajesUI.MostrarAdvertencia("El nombre de la empresa solo puede contener letras, números, espacios y guiones");
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
                        MensajesUI.MostrarAdvertencia("Ya existe una empresa con ese nombre");
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

                MensajesUI.MostrarExito("Empresa guardada correctamente");
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

            if (MensajesUI.MostrarConfirmacion($"¿Está seguro de desactivar la empresa '{seleccionada.Nombre}'?"))
            {
                try
                {
                    empresaNegocio.Eliminar(seleccionada.IdEmpresa);
                    MensajesUI.MostrarExito("Empresa desactivada correctamente");
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
                MensajesUI.MostrarAdvertencia(
                    $"No se puede desactivar la empresa '{seleccionada.Nombre}' " +
                    $"porque tiene {seleccionada.CantidadEmpleados} empleado(s) activo(s).\n\n" +
                    "Primero desactive o transfiera los empleados a otra empresa."
                );
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
            var empleadoNegocio = new EmpleadoNegocio();
            var todosEmpleados = empleadoNegocio.Listar();
            
            if (todosEmpleados != null)
            {
                return todosEmpleados.Count(emp => emp.IdEmpresa == idEmpresa && !emp.Estado);
            }
            return 0;
        }

        private int ObtenerAsistenciasMes(int idEmpresa)
        {
            var registroNegocio = new RegistroNegocio();
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
