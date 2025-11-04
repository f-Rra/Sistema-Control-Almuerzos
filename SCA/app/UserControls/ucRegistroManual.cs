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
        private readonly EmpleadoNegocio negE = new EmpleadoNegocio();
        private readonly EmpresaNegocio negEmp = new EmpresaNegocio();
        private readonly RegistroNegocio negR = new RegistroNegocio();  
        private frmPrincipal formularioPrincipal;
        private int? servicioIdActual;
        private int idLugarActual;

        public ucRegistroManual(frmPrincipal formPrincipal = null)
        {
            InitializeComponent();
            this.formularioPrincipal = formPrincipal;
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

        private void CargarEmpresas()
        {
            var empresas = negEmp.listar();
            var empresasFiltro = new List<dynamic>();
            empresasFiltro.Add(new { IdEmpresa = 0, Nombre = "Todas" });
            
            foreach (var emp in empresas)
            {
                empresasFiltro.Add(new { IdEmpresa = emp.IdEmpresa, Nombre = emp.Nombre });
            }
            
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
                dgvFaltantes.DataSource = negE.empleadosSinAlmorzar(servicioIdActual.Value);
            }
            OcultarColumnas();
            dgvFaltantes.ClearSelection();
            btnAgregar.Enabled = dgvFaltantes.SelectedRows.Count > 0;
        }

        private void OcultarColumnas()
        {
            var cols = dgvFaltantes?.Columns;
            if (cols == null) return;
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
            string[] orden = { "IdCredencial", "NombreCompleto", "NombreEmpresa" };
            int idx = 0;
            foreach (var nombre in orden)
            {
                var col = cols[nombre];
                if (col != null) col.DisplayIndex = idx++;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            FiltrarEmpleados();
        }

        public void LimpiarFiltros()
        {
            txtNombre.Text = "";
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

        private void FiltrarEmpleados()
        {
            try
            {
                if (servicioIdActual.HasValue)
                {
                    string nombre = string.IsNullOrWhiteSpace(txtNombre.Text) ? null : txtNombre.Text.Trim();
                    int? empresaId = null;
                    
                    if (cbLugar.SelectedValue != null && cbLugar.SelectedValue != DBNull.Value)
                    {
                        int selectedValue = (int)cbLugar.SelectedValue;
                        if (selectedValue != 0) 
                        {
                            empresaId = selectedValue;
                        }
                    }
                    
                    var empleadosFiltrados = negE.filtrarEmpleadosSinAlmorzar(servicioIdActual.Value, empresaId, nombre);
                    
                    dgvFaltantes.DataSource = empleadosFiltrados;
                    OcultarColumnas();
                    
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "filtrar empleados");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!servicioIdActual.HasValue)
            {
                ExceptionHelper.MostrarAdvertencia("No hay un servicio activo");
                return;
            }
            if (dgvFaltantes.SelectedRows == null || dgvFaltantes.SelectedRows.Count == 0)
            {
                ExceptionHelper.MostrarAdvertencia("Seleccione al menos un empleado de la lista");
                return;
            }

            Cursor anterior = Cursor.Current;
            int cantidadAgregados = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in dgvFaltantes.SelectedRows)
                {
                    if (row?.DataBoundItem is Empleado emp)
                    {
                        try
                        {
                            negR.registrarEmpleado(emp.IdEmpleado, emp.IdEmpresa, servicioIdActual.Value, idLugarActual);
                            cantidadAgregados++;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            finally
            {
                Cursor.Current = anterior;
            }
            
            LimpiarFiltros();
            cbLugar.SelectedIndex = 0;
            CargarRegistros();
            formularioPrincipal?.RefrescarRegistros();
            formularioPrincipal?.ActualizarEstadisticas();
            
            if (cantidadAgregados > 0)
            {
                MostrarRegistrosAgregados(cantidadAgregados);
            }
        }

        private void MostrarRegistrosAgregados(int cantidad)
        {
            try
            {
                var formTemporal = new Form
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.None,
                    Size = new Size(401, 170), 
                    BackColor = Color.FromArgb(35, 34, 33), 
                    TopMost = true,
                    ShowInTaskbar = false,
                    Padding = new Padding(1) 
                };

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

                panelContenedor.Controls.Add(panelTitulo);
                panelContenedor.Controls.Add(lblMensaje);
                formTemporal.Controls.Add(panelContenedor);

                var timer = new Timer { Interval = 4000 };
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();
                    timer.Dispose();
                    formTemporal.Close();
                    formTemporal.Dispose();
                };

                formTemporal.Shown += (s, ev) => timer.Start();
                formTemporal.Show();
            }
            catch {}
        }
    }
}
