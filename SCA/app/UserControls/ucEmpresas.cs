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
                ExceptionHelper.MostrarAdvertencia("Ingrese el nombre");
                txtNombre.Focus();
                return false;
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

            if (ExceptionHelper.MostrarConfirmacion($"¿Está seguro de desactivar la empresa?"))
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
                }
            }
            catch (Exception ex)
            {
                // No mostrar error aquí porque puede ser normal durante la carga
                System.Diagnostics.Debug.WriteLine($"Error en SelectionChanged: {ex.Message}");
            }
        }
    }
}
