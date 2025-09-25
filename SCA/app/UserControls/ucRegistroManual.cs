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

        private void CargarEmpresas()
        {
            cbLugar.DataSource = negEmp.listar();
            cbLugar.ValueMember = "IdEmpresa";
            cbLugar.DisplayMember = "Nombre";
        }

        public int CountRegistros()
        {
            return dgvFaltantes?.Rows?.Count ?? 0;
        }

        private void CargarRegistros()
        {
            dgvFaltantes.DataSource = null;

            if (servicioIdActual.HasValue)
            {
                dgvFaltantes.DataSource = negE.empleadosSinAlmorzar(servicioIdActual.Value);
            }
            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            var cols = dgvFaltantes?.Columns;
            if (cols == null) return;
            string[] aOcultar = { "IdEmpleado", "IdEmpresa", "Estado", "Nombre", "Apellido" };
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Verificar que hay una fila seleccionada
            if (dgvFaltantes.CurrentRow != null && 
                dgvFaltantes.CurrentRow.DataBoundItem != null)
            {
                Empleado seleccionado = (Empleado)dgvFaltantes.CurrentRow.DataBoundItem;
                
                try
                {
                    negR.registrarEmpleado(seleccionado.IdEmpleado, seleccionado.IdEmpresa, servicioIdActual.Value, idLugarActual);
                    
                    // Mensaje de confirmación
                    MessageBox.Show($"Empleado {seleccionado.NombreCompleto} registrado exitosamente.", 
                        "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refrescar la lista para eliminar al empleado registrado
                    CargarRegistros();
                    
                    // Refrescar los registros en la vista principal (esto también actualiza estadísticas)
                    formularioPrincipal?.RefrescarRegistros();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar empleado: {ex.Message}", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista.", 
                    "Empleado No Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
