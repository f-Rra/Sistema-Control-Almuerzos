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
    public partial class ucVistaPrincipal : UserControl
    {
        private readonly RegistroNegocio negR = new RegistroNegocio();
        private readonly EmpleadoNegocio negE = new EmpleadoNegocio();  
        private frmPrincipal formularioPrincipal;
        private int? servicioIdActual = null;
        private int idLugarActual = 1;


        public ucVistaPrincipal(frmPrincipal formPrincipal = null)
        {
            InitializeComponent();
            this.formularioPrincipal = formPrincipal;
        }

        public void SetServicio(int? servicioId, int idLugar)
        {
            servicioIdActual = servicioId;
            idLugarActual = idLugar;
            CargarRegistros();
        }

        public int CountRegistros()
        {
            if (servicioIdActual.HasValue)
            {
                return negR.contarRegistrosPorServicio(servicioIdActual.Value);
            }
            return 0;
        }

        public void RefrescarRegistros()
        {
            CargarRegistros();
        }

        private void CargarRegistros()
        {
            dgvRegistros.DataSource = null;

            if (servicioIdActual.HasValue)
            {
                dgvRegistros.DataSource = negR.listarPorServicio(servicioIdActual.Value);
            }
            OcultarColumnas();

        }

        private void OcultarColumnas()
        {
            var cols = dgvRegistros?.Columns;
            if (cols == null) return;

            string[] aOcultar = { "IdRegistro", "IdEmpleado", "IdEmpresa", "IdServicio", "IdLugar", "Hora" };
            foreach (var nombre in aOcultar)
            {
                var col = cols[nombre];
                if (col != null) col.Visible = false;
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (!servicioIdActual.HasValue)
            {
                ExceptionHelper.MostrarAdvertencia("No hay un servicio activo");
                return;
            }
            
            string credencial = txtRegistro.Text.Trim();
            if (string.IsNullOrEmpty(credencial))
            {
                ExceptionHelper.MostrarAdvertencia("Ingrese una credencial válida");
                return;
            }
            
            try
            {
                Empleado empleado = negE.buscarPorCredencial(credencial);
                if (empleado == null)
                {
                    ExceptionHelper.MostrarAdvertencia($"No se encontró un empleado con la credencial {credencial}");
                    return;
                }
                
                if (negR.empleadoYaRegistrado(empleado.IdEmpleado, servicioIdActual.Value))
                {
                    ExceptionHelper.MostrarInformacion($"El empleado {empleado.NombreCompleto} ya está registrado en este servicio");
                    return;
                }
                negR.registrarEmpleado(empleado.IdEmpleado, empleado.IdEmpresa, servicioIdActual.Value, idLugarActual);
                CargarRegistros();
                txtRegistro.Clear();
                txtRegistro.Focus();
                formularioPrincipal?.ActualizarEstadisticas();
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "procesar el registro");
            }
        }
    }
}
