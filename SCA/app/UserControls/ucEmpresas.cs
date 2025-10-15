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
            CargarEmpresas();
            LimpiarFormulario();
        }

        private void CargarEmpresas(string filtro = "")
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

            lblTotalEmpresas.Text = $"Total Empleados: {empresas.Count}";
        }

        private void OcultarColumnas()
        {
            
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
            aux.IdEmpresa = seleccionada.IdEmpresa;
            aux.Nombre = txtNombre.Text.Trim();
            aux.Estado = rbActivoEmpresa.Checked;
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
            Empresa aux = new Empresa();
            if (modoEdicion && seleccionada != null) CargarEmpresa(aux);
            if (modoEdicion) negE.modificar(aux);
            else negE.agregar(aux);
            ExceptionHelper.MostrarExito("Empleado guardado correctamente");
            CargarEmpresas();
            LimpiarFormulario();
        }
    }
}
