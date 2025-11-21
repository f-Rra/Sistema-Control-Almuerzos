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
        #region Variables y Constantes

        private EstadisticasNegocio estadisticasNegocio;

        #endregion

        #region Constructor e Inicialización

        public ucEstadisticas()
        {
            InitializeComponent();
            estadisticasNegocio = new EstadisticasNegocio();
        }

        private void ucEstadisticas_Load(object sender, EventArgs e)
        {
            RefrescarDatos();   
        }

        public void RefrescarDatos()
        {
            try
            {
                CargarTodasLasEstadisticas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error detallado:\n\nMensaje: {ex.Message}\n\nStackTrace: {ex.StackTrace}\n\nInnerException: {ex.InnerException?.Message}", 
                    "Error Debug", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void CargarTodasLasEstadisticas()
        {
            CargarEstadisticasEmpleados();
            CargarEstadisticasEmpresas();
            CargarEstadisticasServicios();
            CargarAsistenciasTendencias();
            CargarTop5Empresas();
        }

        #endregion

        #region Estadísticas de Empleados

        private void CargarEstadisticasEmpleados()
        {
            var empleados = estadisticasNegocio.ObtenerEstadisticasEmpleados();
            ActualizarEstadisticasEmpleados(empleados);
        }

        private void ActualizarEstadisticasEmpleados(Estadisticas.Empleados empleados)
        {
            if (empleados != null)
            {
                lblTotalRegistrados.Text = "Total Registrados: " + empleados.TotalRegistrados;
                lblEmpleadosActivos.Text = "Activos: " + empleados.TotalActivos;
                lblEmpleadosInactivos.Text = "Inactivos: " + empleados.TotalInactivos;
            }
            else
            {
                MostrarEstadisticasEmpleadosNoDisponibles();
            }
        }

        private void MostrarEstadisticasEmpleadosNoDisponibles()
        {
            lblTotalRegistrados.Text = "Total Registrados: N/A";
            lblEmpleadosActivos.Text = "Activos: N/A";
            lblEmpleadosInactivos.Text = "Inactivos: N/A";
        }

        #endregion   

        #region Estadísticas de Empresas

        private void CargarEstadisticasEmpresas()
        {
            var empresas = estadisticasNegocio.ObtenerEstadisticasEmpresas();
            ActualizarEstadisticasEmpresas(empresas);
        }

        private void ActualizarEstadisticasEmpresas(Estadisticas.Empresas empresas)
        {
            if (empresas != null)
            {
                lblEmpresasActivas.Text = "Total Activas: " + empresas.TotalActivas;
                lblEmpresasEmpleados.Text = "Con Empleados: " + empresas.TotalConEmpleados;
                lblPromedioEmpleados.Text = "Promedio (Empleados): " + ((int)empresas.PromedioEmpleados).ToString();
            }
            else
            {
                MostrarEstadisticasEmpresasNoDisponibles();
            }
        }

        private void MostrarEstadisticasEmpresasNoDisponibles()
        {
            lblEmpresasActivas.Text = "Total Activas: N/A";
            lblEmpresasEmpleados.Text = "Con Empleados: N/A";
            lblPromedioEmpleados.Text = "Promedio (Empleados): N/A";
        }

        #endregion   

        #region Estadísticas de Servicios

        private void CargarEstadisticasServicios()
        {
            var servicios = estadisticasNegocio.ObtenerEstadisticasServicios();
            ActualizarEstadisticasServicios(servicios);
        }

        private void ActualizarEstadisticasServicios(Estadisticas.Servicios servicios)
        {
            if (servicios != null)
            {
                lblServiciosMes.Text = "Este Mes: " + servicios.ServiciosEsteMes;
                lblServiciosTotal.Text = "Total del Año: " + servicios.ServiciosEsteAnio;
                lblServiciosPromedio.Text = "Promedio/Dia: " + servicios.PromedioPorDia;
            }
            else
            {
                MostrarEstadisticasServiciosNoDisponibles();
            }
        }

        private void MostrarEstadisticasServiciosNoDisponibles()
        {
            lblServiciosMes.Text = "Este Mes: N/A";
            lblServiciosTotal.Text = "Total del Año: N/A";
            lblServiciosPromedio.Text = "Promedio/Dia: N/A";
        }

        #endregion   

        #region Asistencias y Tendencias

        private void CargarAsistenciasTendencias()
        {
            var tendencias = estadisticasNegocio.ObtenerAsistenciasTendencias();
            ActualizarAsistenciasTendencias(tendencias);
        }

        private void ActualizarAsistenciasTendencias(Estadisticas.Asistencias tendencias)
        {
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
                MostrarAsistenciasTendenciasNoDisponibles();
            }
        }

        private void MostrarAsistenciasTendenciasNoDisponibles()
        {
            lblAsistenciasTotales.Text = "Asistencias Totales (Mes Actual): N/A";
            lblAsistenciasEmpleados.Text = "Asistencias de Empleados: N/A";
            lblAsistenciasInvitados.Text = "Asistencias de Invitados: N/A";
            lblPromedioDiario.Text = "Promedio Diario de Asistencias: N/A";
            lblCobertura.Text = "Cobertura Proyeccion vs Promedio: N/A";
            lblDuracionPromedio.Text = "Duracion Promedio de Servicio: N/A";
        }

        private string CalcularHora(int totalMinutos)
        {
            int horas = totalMinutos / 60;
            int minutos = totalMinutos % 60;
            return $"{horas}h {minutos}m";
        }

        #endregion

        #region Top 5 Empresas

        private void CargarTop5Empresas()
        {
            var lista = estadisticasNegocio.ObtenerTop5Empresas(DateTime.Now);
            var controles = ObtenerControlesTop5();

            if (lista != null && lista.Count > 0)
            {
                MostrarTop5ConDatos(lista, controles);
            }
            else
            {
                MostrarTop5SinDatos(controles);
            }
        }

        private (Label[] lblTops, Label[] lblPorcentajes, ReaLTaiizor.Controls.AloneProgressBar[] pbProgresos) ObtenerControlesTop5()
        {
            var lblTops = new[] { lblTop1, lblTop2, lblTop3, lblTop4, lblTop5 };
            var lblPorcentajes = new[] { lblPorcentaje1, lblPorcentaje2, lblPorcentaje3, lblPorcentaje4, lblPorcentaje5 };
            var pbProgresos = new[] { pbProgreso1, pbProgreso2, pbProgreso3, pbProgreso4, pbProgreso5 };

            return (lblTops, lblPorcentajes, pbProgresos);
        }

        private void MostrarTop5ConDatos(List<Estadisticas.TopEmpresa> lista, (Label[] lblTops, Label[] lblPorcentajes, ReaLTaiizor.Controls.AloneProgressBar[] pbProgresos) controles)
        {
            int valorMaximo = lista[0].TotalAsistencias;

            for (int i = 0; i < 5; i++)
            {
                if (i < lista.Count)
                {
                    ActualizarItemTop5(i, lista[i], valorMaximo, controles);
                }
                else
                {
                    LimpiarItemTop5(i, controles);
                }
            }
        }

        private void ActualizarItemTop5(int indice, Estadisticas.TopEmpresa empresa, int valorMaximo, (Label[] lblTops, Label[] lblPorcentajes, ReaLTaiizor.Controls.AloneProgressBar[] pbProgresos) controles)
        {
            controles.lblTops[indice].Text = (indice + 1) + ". " + empresa.NombreEmpresa;
            controles.lblPorcentajes[indice].Text = empresa.Porcentaje.ToString("F1") + "%";

            int valorBarra = CalcularValorBarra(empresa.TotalAsistencias, valorMaximo);
            controles.pbProgresos[indice].Value = valorBarra;
            controles.pbProgresos[indice].Visible = true;
        }

        private int CalcularValorBarra(int totalAsistencias, int valorMaximo)
        {
            return valorMaximo > 0 ? (int)((double)totalAsistencias / valorMaximo * 100) : 0;
        }

        private void LimpiarItemTop5(int indice, (Label[] lblTops, Label[] lblPorcentajes, ReaLTaiizor.Controls.AloneProgressBar[] pbProgresos) controles)
        {
            controles.lblTops[indice].Text = (indice + 1) + ".";
            controles.lblPorcentajes[indice].Text = "";
            controles.pbProgresos[indice].Value = 0;
            controles.pbProgresos[indice].Visible = false;
        }

        private void MostrarTop5SinDatos((Label[] lblTops, Label[] lblPorcentajes, ReaLTaiizor.Controls.AloneProgressBar[] pbProgresos) controles)
        {
            for (int i = 0; i < 5; i++)
            {
                controles.lblTops[i].Text = (i + 1) + ".";
                controles.lblPorcentajes[i].Text = "Sin datos";
                controles.pbProgresos[i].Value = 0;
                controles.pbProgresos[i].Visible = false;
            }
        }

        #endregion
    }
}
