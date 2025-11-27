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
    public partial class ucRegistroManual : UserControl
    {
        #region Variables y Constantes

        private readonly EmpleadoNegocio empleadoNegocio;
        private readonly EmpresaNegocio empresaNegocio;
        private readonly RegistroNegocio registroNegocio;
        private frmPrincipal formularioPrincipal;
        private int? servicioIdActual;
        private int idLugarActual;
        private Empleado ultimoEmpleadoRegistrado;

        #endregion

        #region Constructor e Inicialización

        public ucRegistroManual(frmPrincipal formPrincipal = null)
        {
            InitializeComponent();
            
            empleadoNegocio = new EmpleadoNegocio();
            empresaNegocio = new EmpresaNegocio();
            registroNegocio = new RegistroNegocio();
            
            this.formularioPrincipal = formPrincipal;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvFaltantes.MultiSelect = true;
            dgvFaltantes.SelectionChanged += dgvFaltantes_SelectionChanged;
        }
        
        private void ucRegistroManual_Load(object sender, EventArgs e)
        {
            CargarEmpresas();
        }

        public void SetServicio(int servicioId, int idLugar)
        {
            servicioIdActual = servicioId;
            idLugarActual = idLugar;
            CargarRegistros();
        }

        public void RefrescarDatos()
        {
            CargarEmpresas();
            if (servicioIdActual.HasValue)
            {
                CargarRegistros();
            }
        }

        #endregion

        #region Carga de Datos

        private void CargarEmpresas()
        {
            try
            {
                var empresas = empresaNegocio.Listar();
                var empresasFiltro = CrearListaEmpresasConOpcionTodas(empresas);
                ConfigurarEmpresas(empresasFiltro);
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private List<dynamic> CrearListaEmpresasConOpcionTodas(List<Empresa> empresas)
        {
            var empresasFiltro = new List<dynamic>();
            empresasFiltro.Add(new { IdEmpresa = 0, Nombre = "Todas" });
            
            foreach (var emp in empresas)
            {
                empresasFiltro.Add(new { IdEmpresa = emp.IdEmpresa, Nombre = emp.Nombre });
            }
            
            return empresasFiltro;
        }

        private void ConfigurarEmpresas(List<dynamic> empresasFiltro)
        {
            cbEmpresa.DataSource = null;
            cbEmpresa.DataSource = empresasFiltro;
            cbEmpresa.ValueMember = "IdEmpresa";
            cbEmpresa.DisplayMember = "Nombre";
            cbEmpresa.SelectedIndex = 0;
        }

        private void CargarRegistros()
        {
            try
            {
                dgvFaltantes.DataSource = null;

                if (servicioIdActual.HasValue)
                {
                    dgvFaltantes.DataSource = empleadoNegocio.EmpleadosSinAlmorzar(servicioIdActual.Value);
                }
                OcultarColumnas();
                LimpiarSeleccion();
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void LimpiarSeleccion()
        {
            dgvFaltantes.ClearSelection();
            btnAgregar.Enabled = dgvFaltantes.SelectedRows.Count > 0;
        }

        #endregion

        #region Configuración de Columnas

        private void OcultarColumnas()
        {
            var cols = dgvFaltantes?.Columns;
            if (cols == null) return;

            ConfigurarVisibilidadColumnas(cols);
            ConfigurarOrdenColumnas(cols);
        }

        private void ConfigurarVisibilidadColumnas(DataGridViewColumnCollection cols)
        {
            string[] aOcultar = { "IdEmpleado", "IdEmpresa", "Empresa", "Estado", "Nombre", "Apellido" };
            foreach (var nombre in aOcultar)
            {
                var col = cols[nombre];
                if (col != null) col.Visible = false;
            }

            string[] aMostrar = { "IdCredencial", "NombreCompleto", "NombreEmpresa" };
            foreach (var nombre in aMostrar)
            {
                var col = cols[nombre];
                if (col != null) col.Visible = true;
            }
        }

        private void ConfigurarOrdenColumnas(DataGridViewColumnCollection cols)
        {
            string[] orden = { "IdCredencial", "NombreCompleto", "NombreEmpresa" };
            int idx = 0;
            foreach (var nombre in orden)
            {
                var col = cols[nombre];
                if (col != null) col.DisplayIndex = idx++;
            }
        }

        #endregion

        #region Filtrado

        public void LimpiarFiltros()
        {
            txtNombre.Text = "";
            FiltrarEmpleados();
        }

        private void FiltrarEmpleados()
        {
            try
            {
                if (!servicioIdActual.HasValue)
                    return;

                string nombre = ObtenerNombreFiltro();
                int? empresaId = ObtenerEmpresaIdFiltro();
                
                var empleadosFiltrados = empleadoNegocio.FiltrarEmpleadosSinAlmorzar(servicioIdActual.Value, empresaId, nombre);
                
                ActualizarGridFiltrado(empleadosFiltrados);
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private string ObtenerNombreFiltro()
        {
            return string.IsNullOrWhiteSpace(txtNombre.Text) ? null : txtNombre.Text.Trim();
        }

        private int? ObtenerEmpresaIdFiltro()
        {
            if (cbEmpresa.SelectedValue != null && cbEmpresa.SelectedValue != DBNull.Value)
            {
                int selectedValue = (int)cbEmpresa.SelectedValue;
                if (selectedValue != 0)
                {
                    return selectedValue;
                }
            }
            return null;
        }

        private void ActualizarGridFiltrado(List<Empleado> empleadosFiltrados)
        {
            dgvFaltantes.DataSource = empleadosFiltrados;
            OcultarColumnas();
        }

        #endregion

        #region Registro de Empleados

        private void AgregarEmpleados()
        {
            if (!ValidarAgregarEmpleados())
                return;

            int cantidadAgregados = RegistrarEmpleadosSeleccionados();
            ActualizarDespuesDeAgregar(cantidadAgregados);
        }

        private bool ValidarAgregarEmpleados()
        {
            if (!servicioIdActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia("No hay un servicio activo");
                return false;
            }
            if (dgvFaltantes.SelectedRows == null || dgvFaltantes.SelectedRows.Count == 0)
            {
                MensajesUI.MostrarAdvertencia("Seleccione al menos un empleado de la lista");
                return false;
            }
            return true;
        }

        private int RegistrarEmpleadosSeleccionados()
        {
            Cursor anterior = Cursor.Current;
            int cantidadAgregados = 0;
            Empleado primerEmpleado = null;
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in dgvFaltantes.SelectedRows)
                {
                    if (row?.DataBoundItem is Empleado emp)
                    {
                        if (RegistrarEmpleado(emp))
                        {
                            if (cantidadAgregados == 0)
                            {
                                primerEmpleado = emp;
                            }
                            cantidadAgregados++;
                        }
                    }
                }
            }
            finally
            {
                Cursor.Current = anterior;
            }
            
            if (cantidadAgregados == 1 && primerEmpleado != null)
            {
                ultimoEmpleadoRegistrado = primerEmpleado;
            }
            
            return cantidadAgregados;
        }

        private bool RegistrarEmpleado(Empleado emp)
        {
            try
            {
                registroNegocio.RegistrarEmpleado(emp.IdEmpleado, emp.IdEmpresa, servicioIdActual.Value, idLugarActual);
                return true;
            }
            catch (NegocioException)
            {
                return false;
            }
        }

        private void ActualizarDespuesDeAgregar(int cantidadAgregados)
        {
            LimpiarFiltros();
            cbEmpresa.SelectedIndex = 0;
            CargarRegistros();
            NotificarFormularioPrincipal();
            
            if (cantidadAgregados > 0)
            {
                MostrarRegistrosAgregados(cantidadAgregados);
            }
        }

        private void NotificarFormularioPrincipal()
        {
            formularioPrincipal?.RefrescarRegistros();
            formularioPrincipal?.ActualizarEstadisticas();
        }

        #endregion

        #region Notificaciones Visuales

        private void MostrarRegistrosAgregados(int cantidad)
        {
            try
            {
                var notificacion = new ucNotificacion();
                string nombreEmpleado, empresa;
                string horaActual = DateTime.Now.ToString("HH:mm:ss");
                bool ocultarTitulo = false;
                if (cantidad == 1 && ultimoEmpleadoRegistrado != null)
                {
                    nombreEmpleado = ultimoEmpleadoRegistrado.NombreCompleto;
                    empresa = ultimoEmpleadoRegistrado.NombreEmpresa;
                    ocultarTitulo = false; 
                }
                else
                {
                    nombreEmpleado = $"{cantidad} Comensales Registrados";
                    empresa = "Registro Manual";
                    ocultarTitulo = true; 
                }
                
                notificacion.MostrarNotificacion(
                    nombreEmpleado,
                    empresa,
                    horaActual,
                    this, 
                    ocultarTitulo
                );
                
                ultimoEmpleadoRegistrado = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERROR] Error al mostrar notificación: {ex.Message}");
            }
        }

        #endregion

        #region Eventos

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            FiltrarEmpleados();
        }

        private void cbEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrarEmpleados();
        }

        private void dgvFaltantes_SelectionChanged(object sender, EventArgs e)
        {
            btnAgregar.Enabled = dgvFaltantes.SelectedRows.Count > 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEmpleados();
        }

        #endregion
    }
}
