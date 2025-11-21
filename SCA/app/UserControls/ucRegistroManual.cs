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
    public partial class ucRegistroManual : UserControl
    {
        #region Variables y Constantes

        private readonly EmpleadoNegocio empleadoNegocio;
        private readonly EmpresaNegocio empresaNegocio;
        private readonly RegistroNegocio registroNegocio;
        private frmPrincipal formularioPrincipal;
        private int? servicioIdActual;
        private int idLugarActual;

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
            var empresas = empresaNegocio.listar();
            var empresasFiltro = CrearListaEmpresasConOpcionTodas(empresas);
            ConfigurarComboBoxEmpresas(empresasFiltro);
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

        private void ConfigurarComboBoxEmpresas(List<dynamic> empresasFiltro)
        {
            cbLugar.DataSource = null;
            cbLugar.DataSource = empresasFiltro;
            cbLugar.ValueMember = "IdEmpresa";
            cbLugar.DisplayMember = "Nombre";
            cbLugar.SelectedIndex = 0;
        }

        private void CargarRegistros()
        {
            dgvFaltantes.DataSource = null;

            if (servicioIdActual.HasValue)
            {
                dgvFaltantes.DataSource = empleadoNegocio.empleadosSinAlmorzar(servicioIdActual.Value);
            }
            OcultarColumnas();
            LimpiarSeleccion();
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
                
                var empleadosFiltrados = empleadoNegocio.filtrarEmpleadosSinAlmorzar(servicioIdActual.Value, empresaId, nombre);
                
                ActualizarGridFiltrado(empleadosFiltrados);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "filtrar empleados");
            }
        }

        private string ObtenerNombreFiltro()
        {
            return string.IsNullOrWhiteSpace(txtNombre.Text) ? null : txtNombre.Text.Trim();
        }

        private int? ObtenerEmpresaIdFiltro()
        {
            if (cbLugar.SelectedValue != null && cbLugar.SelectedValue != DBNull.Value)
            {
                int selectedValue = (int)cbLugar.SelectedValue;
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
                ExceptionHelper.MostrarAdvertencia("No hay un servicio activo");
                return false;
            }
            if (dgvFaltantes.SelectedRows == null || dgvFaltantes.SelectedRows.Count == 0)
            {
                ExceptionHelper.MostrarAdvertencia("Seleccione al menos un empleado de la lista");
                return false;
            }
            return true;
        }

        private int RegistrarEmpleadosSeleccionados()
        {
            Cursor anterior = Cursor.Current;
            int cantidadAgregados = 0;
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in dgvFaltantes.SelectedRows)
                {
                    if (row?.DataBoundItem is Empleado emp)
                    {
                        if (RegistrarEmpleado(emp))
                        {
                            cantidadAgregados++;
                        }
                    }
                }
            }
            finally
            {
                Cursor.Current = anterior;
            }
            
            return cantidadAgregados;
        }

        private bool RegistrarEmpleado(Empleado emp)
        {
            try
            {
                registroNegocio.registrarEmpleado(emp.IdEmpleado, emp.IdEmpresa, servicioIdActual.Value, idLugarActual);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ActualizarDespuesDeAgregar(int cantidadAgregados)
        {
            LimpiarFiltros();
            cbLugar.SelectedIndex = 0;
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
            Form formTemporal = null;
            Timer timer = null;

            try
            {
                formTemporal = CrearFormularioNotificacion();
                var (panelContenedor, panelTitulo, lblMensaje) = CrearControlesNotificacion(cantidad);
                
                EnsamblarNotificacion(formTemporal, panelContenedor, panelTitulo, lblMensaje);
                timer = ConfigurarTemporizador(formTemporal);
                
                ConfigurarEventosFormulario(formTemporal, timer);
                formTemporal.Show();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERROR] Error al mostrar ventana temporal: {ex.Message}");
                LimpiarRecursosNotificacion(formTemporal, timer);
            }
        }

        private Form CrearFormularioNotificacion()
        {
            return new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.None,
                Size = new Size(401, 170),
                BackColor = Color.FromArgb(35, 34, 33),
                TopMost = true,
                ShowInTaskbar = false,
                Padding = new Padding(1)
            };
        }

        private (Panel panelContenedor, Panel panelTitulo, Label lblMensaje) CrearControlesNotificacion(int cantidad)
        {
            var panelContenedor = new Panel
            {
                Size = new Size(399, 168),
                Location = new Point(1, 1),
                BackColor = Color.FromArgb(255, 248, 225)
            };

            var panelTitulo = new Panel
            {
                Size = new Size(399, 52),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(255, 208, 36)
            };

            var lblTitulo = new Label
            {
                Text = "Registro Manual",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(35, 34, 33),
                AutoSize = false,
                Size = new Size(399, 52),
                TextAlign = ContentAlignment.MiddleCenter
            };

            panelTitulo.Controls.Add(lblTitulo);

            string mensaje = cantidad == 1
                ? $"Comensal Agregado Correctamente"
                : $"Comensales Agregados Correctamente\n\nTotal registrados: {cantidad}";

            var lblMensaje = new Label
            {
                Text = mensaje,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(35, 34, 33),
                AutoSize = false,
                Size = new Size(385, 95),
                Location = new Point(7, 60),
                TextAlign = ContentAlignment.MiddleCenter
            };

            return (panelContenedor, panelTitulo, lblMensaje);
        }

        private void EnsamblarNotificacion(Form formTemporal, Panel panelContenedor, Panel panelTitulo, Label lblMensaje)
        {
            panelContenedor.Controls.Add(panelTitulo);
            panelContenedor.Controls.Add(lblMensaje);
            formTemporal.Controls.Add(panelContenedor);
        }

        private Timer ConfigurarTemporizador(Form formTemporal)
        {
            var timer = new Timer { Interval = 4000 };
            timer.Tick += (s, ev) =>
            {
                try
                {
                    timer.Stop();
                    timer.Dispose();
                    if (formTemporal != null && !formTemporal.IsDisposed)
                    {
                        formTemporal.Close();
                        formTemporal.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[ERROR] Error al cerrar ventana temporal en Tick: {ex.Message}");
                }
            };
            return timer;
        }

        private void ConfigurarEventosFormulario(Form formTemporal, Timer timer)
        {
            formTemporal.FormClosed += (s, ev) =>
            {
                if (timer != null)
                {
                    try { timer.Stop(); timer.Dispose(); }
                    catch { }
                }
            };

            formTemporal.Shown += (s, ev) => timer.Start();
        }

        private void LimpiarRecursosNotificacion(Form formTemporal, Timer timer)
        {
            try
            {
                timer?.Stop();
                timer?.Dispose();
            }
            catch { }

            try
            {
                if (formTemporal != null && !formTemporal.IsDisposed)
                    formTemporal.Dispose();
            }
            catch { }
        }

        #endregion

        #region Eventos

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            FiltrarEmpleados();
        }

        private void cbLugar_SelectionChangeCommitted(object sender, EventArgs e)
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
