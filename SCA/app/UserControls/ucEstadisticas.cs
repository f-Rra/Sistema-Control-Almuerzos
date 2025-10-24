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
    public partial class ucEstadisticas : UserControl
    {
        private EstadisticasNegocio negE = new EstadisticasNegocio();

        public ucEstadisticas()
        {
            InitializeComponent();
        }

        private void ucEstadisticas_Load(object sender, EventArgs e)
        {
            RefrescarDatos();   
        }

        public void RefrescarDatos()
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                CargarEstadisticasEmpleados();
                CargarEstadisticasEmpresas();
                CargarEstadisticasServicios();
                CargarAsistenciasTendencias();
                CargarTop5Empresas();
            }, "cargar las estadísticas");
        }

        private void CargarEstadisticasEmpleados()
        {
            var empleados = negE.ObtenerEstadisticasEmpleados();  

            if (empleados != null)
            {
                lblTotalRegistrados.Text += empleados.TotalRegistrados.ToString();
                lblEmpleadosActivos.Text += empleados.TotalActivos.ToString();
                lblEmpleadosInactivos.Text += empleados.TotalInactivos.ToString();
            }
            else
            {
                lblTotalRegistrados.Text += "N/A";
                lblEmpleadosActivos.Text += "N/A";
                lblEmpleadosInactivos.Text += "N/A";
            }
        }   

        private void CargarEstadisticasEmpresas()
        {
            var empresas = negE.ObtenerEstadisticasEmpresas();

            if (empresas != null)
            {
                lblEmpresasActivas.Text += empresas.TotalActivas.ToString();
                lblEmpresasEmpleados.Text += empresas.TotalConEmpleados.ToString();
                lblPromedioEmpleados.Text += empresas.PromedioEmpleados.ToString("F2");
            }
            else
            {
                lblEmpresasActivas.Text += "N/A";
                lblEmpresasEmpleados.Text += "N/A";
                lblPromedioEmpleados.Text += "N/A";
            }
        }   

        private void CargarEstadisticasServicios()
        {
            var servicios = negE.ObtenerEstadisticasServicios();
            
            if (servicios != null)
            {
                lblServiciosMes.Text += servicios.ServiciosEsteMes.ToString();
                lblServiciosTotal.Text += servicios.ServiciosEsteAnio.ToString();
                lblPromedioDiario.Text += servicios.PromedioPorDia.ToString();
            }
            else
            {
                lblServiciosMes.Text += "N/A";
                lblServiciosTotal.Text += "N/A";
                lblPromedioDiario.Text += "N/A";
            }
        }   

        private void CargarAsistenciasTendencias()
        {
            var tendencias = negE.ObtenerAsistenciasTendencias();
            if (tendencias != null)
            {
                lblAsistenciasTotales.Text += tendencias.AsistenciasTotales.ToString();
                lblAsistenciasEmpleados.Text += tendencias.AsistenciasEmpleados.ToString();
                lblAsistenciasInvitados.Text += tendencias.AsistenciasInvitados.ToString();
                lblPromedioDiario.Text += tendencias.PromedioDiario.ToString();
                lblCobertura.Text += tendencias.CoberturaPromedio.ToString("N2") + "%";
                lblDuracionPromedio.Text += CalcularHora(tendencias.DuracionPromedio);
            }
            else
            {
                lblAsistenciasTotales.Text += "N/A";
                lblAsistenciasEmpleados.Text += "N/A";
                lblAsistenciasInvitados.Text += "N/A";
                lblPromedioDiario.Text += "N/A";
                lblCobertura.Text += "N/A";
                lblDuracionPromedio.Text += "N/A";
            }   


        }

        private string CalcularHora(int totalMinutos)
        {
            int horas = totalMinutos / 60;
            int minutos = totalMinutos % 60;
            return $"{horas}h {minutos}m";
        }

        private void CargarTop5Empresas()
        {

        }   
    }
}
