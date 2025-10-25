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
            try
            {
                CargarEstadisticasEmpleados();
                CargarEstadisticasEmpresas();
                CargarEstadisticasServicios();
                CargarAsistenciasTendencias();
                CargarTop5Empresas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error detallado:\n\nMensaje: {ex.Message}\n\nStackTrace: {ex.StackTrace}\n\nInnerException: {ex.InnerException?.Message}", 
                    "Error Debug", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void CargarEstadisticasEmpleados()
        {
            var empleados = negE.ObtenerEstadisticasEmpleados();  

            if (empleados != null)
            {
                lblTotalRegistrados.Text = "Total Registrados: " + empleados.TotalRegistrados;
                lblEmpleadosActivos.Text = "Activos: " + empleados.TotalActivos;
                lblEmpleadosInactivos.Text = "Inactivos: " + empleados.TotalInactivos;
            }
            else
            {
                lblTotalRegistrados.Text = "Total Registrados: N/A";
                lblEmpleadosActivos.Text = "Activos: N/A";
                lblEmpleadosInactivos.Text = "Inactivos: N/A";
            }
        }   

        private void CargarEstadisticasEmpresas()
        {
            var empresas = negE.ObtenerEstadisticasEmpresas();

            if (empresas != null)
            {
                lblEmpresasActivas.Text = "Total Activas: " + empresas.TotalActivas;
                lblEmpresasEmpleados.Text = "Con Empleados: " + empresas.TotalConEmpleados;
                lblPromedioEmpleados.Text = "Promedio (Empleados): " + empresas.PromedioEmpleados.ToString("F2");
            }
            else
            {
                lblEmpresasActivas.Text = "Total Activas: N/A";
                lblEmpresasEmpleados.Text = "Con Empleados: N/A";
                lblPromedioEmpleados.Text = "Promedio (Empleados): N/A";
            }
        }   

        private void CargarEstadisticasServicios()
        {
            var servicios = negE.ObtenerEstadisticasServicios();
            
            if (servicios != null)
            {
                lblServiciosMes.Text = "Este Mes: " + servicios.ServiciosEsteMes;
                lblServiciosTotal.Text = "Total del Año: " + servicios.ServiciosEsteAnio;
                lblPromedioDiario.Text = "Promedio/Dia: " + servicios.PromedioPorDia;
            }
            else
            {
                lblServiciosMes.Text = "Este Mes: N/A";
                lblServiciosTotal.Text = "Total del Año: N/A";
                lblPromedioDiario.Text = "Promedio/Dia: N/A";
            }
        }   

        private void CargarAsistenciasTendencias()
        {
            var tendencias = negE.ObtenerAsistenciasTendencias();
            if (tendencias != null)
            {
                lblAsistenciasTotales.Text = "Asistencias Totales (Mes Actual): " + tendencias.AsistenciasTotales;
                lblAsistenciasEmpleados.Text = "Asistencias de Empleados: " + tendencias.AsistenciasEmpleados;
                lblAsistenciasInvitados.Text = "Asistencias de Invitados: " + tendencias.AsistenciasInvitados;
                lblPromedioDiario.Text = "Promedio Diario de Asistencias: " + tendencias.PromedioDiario;
                lblCobertura.Text = "Cobertura Proyeccion vs Promedio: " + tendencias.CoberturaPromedio.ToString("N2") + "%";
                lblDuracionPromedio.Text = "Duracion Promedio de Servicio: " + CalcularHora(tendencias.DuracionPromedio);
            }
            else
            {
                lblAsistenciasTotales.Text = "Asistencias Totales (Mes Actual): N/A";
                lblAsistenciasEmpleados.Text = "Asistencias de Empleados: N/A";
                lblAsistenciasInvitados.Text = "Asistencias de Invitados: N/A";
                lblPromedioDiario.Text = "Promedio Diario de Asistencias: N/A";
                lblCobertura.Text = "Cobertura Proyeccion vs Promedio: N/A";
                lblDuracionPromedio.Text = "Duracion Promedio de Servicio: N/A";
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
