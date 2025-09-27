using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace app.UserControls
{
    public partial class ucReportes : UserControl
    {
        public ucReportes()
        {
            InitializeComponent();
        }

        private void ucReportes_Load(object sender, EventArgs e)
        {
            try
            {
                // Rango por defecto: últimos 7 días
                dtpHasta.Value = DateTime.Today;
                dtpDesde.Value = DateTime.Today.AddDays(-7);

                // Lugares con primera opción "Todos"
                var negL = new LugarNegocio();
                var lugares = negL.listar() ?? new List<Lugar>();
                lugares.Insert(0, new Lugar { IdLugar = 0, Nombre = "Todos" });
                cbLugar.DataSource = lugares;
                cbLugar.DisplayMember = "Nombre";
                cbLugar.ValueMember = "IdLugar";
                cbLugar.SelectedIndex = 0;

                // Tipos de reporte (4 opciones finales)
                cbTipoReporte.Items.Clear();
                cbTipoReporte.Items.Add("Lista de servicios");
                cbTipoReporte.Items.Add("Asistencias por empresas");
                cbTipoReporte.Items.Add("Cobertura vs proyección");
                cbTipoReporte.Items.Add("Distribución por día de semana");
                cbTipoReporte.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los filtros de reportes: " + ex.Message);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date;
                if (desde > hasta)
                {
                    MessageBox.Show("El rango de fechas es inválido (Desde > Hasta).");
                    return;
                }

                int? idLugar = null;
                if (cbLugar.SelectedValue is int val && val > 0)
                    idLugar = val;

                string tipo = cbTipoReporte.SelectedItem as string ?? string.Empty;
                var rep = new ReporteNegocio();

                dgvReporte.DataSource = null;

                switch (tipo)
                {
                    case "Lista de servicios":
                        dgvReporte.DataSource = rep.ListarServiciosRango(desde, hasta, idLugar);
                        break;
                    case "Asistencias por empresas":
                        dgvReporte.DataSource = rep.AsistenciasPorEmpresas(desde, hasta, idLugar);
                        break;
                    case "Cobertura vs proyección":
                        dgvReporte.DataSource = rep.CoberturaVsProyeccion(desde, hasta, idLugar);
                        break;
                    case "Distribución por día de semana":
                        dgvReporte.DataSource = rep.DistribucionPorDiaSemana(desde, hasta, idLugar);
                        break;
                    default:
                        // Nada seleccionado
                        break;
                }

                // Formato mínimo de columnas y ocultar/renombrar columnas según reporte
                if (dgvReporte.DataSource != null)
                {
                    // Formato general para todos los reportes
                    if (dgvReporte.Columns.Contains("Fecha"))
                        dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    // Encabezados para todos los reportes
                    if (dgvReporte.Columns.Contains("NombreLugar")) dgvReporte.Columns["NombreLugar"].HeaderText = "Lugar";
                    if (dgvReporte.Columns.Contains("Proyeccion")) dgvReporte.Columns["Proyeccion"].HeaderText = "Proyección";
                    if (dgvReporte.Columns.Contains("DuracionMinutos")) dgvReporte.Columns["DuracionMinutos"].HeaderText = "Duración (min)";
                    if (dgvReporte.Columns.Contains("TotalComensales")) dgvReporte.Columns["TotalComensales"].HeaderText = "Total Comensales";
                    if (dgvReporte.Columns.Contains("TotalInvitados")) dgvReporte.Columns["TotalInvitados"].HeaderText = "Total Invitados";
                    if (dgvReporte.Columns.Contains("TotalGeneral")) dgvReporte.Columns["TotalGeneral"].HeaderText = "Total General";
                    if (dgvReporte.Columns.Contains("CoberturaPorcentaje"))
                    {
                        dgvReporte.Columns["CoberturaPorcentaje"].HeaderText = "Cobertura %";
                        dgvReporte.Columns["CoberturaPorcentaje"].DefaultCellStyle.Format = "N2";
                    }
                    if (dgvReporte.Columns.Contains("TotalAsistencias")) dgvReporte.Columns["TotalAsistencias"].HeaderText = "Total Asistencias";
                    if (dgvReporte.Columns.Contains("Diferencia")) dgvReporte.Columns["Diferencia"].HeaderText = "Diferencia";
                    if (dgvReporte.Columns.Contains("Atendidos")) dgvReporte.Columns["Atendidos"].HeaderText = "Atendidos";

                    // Ocultar columnas innecesarias
                    if (dgvReporte.Columns.Contains("IdServicio")) dgvReporte.Columns["IdServicio"].Visible = false;
                    if (dgvReporte.Columns.Contains("IdLugar")) dgvReporte.Columns["IdLugar"].Visible = false;
                    if (dgvReporte.Columns.Contains("Estado")) dgvReporte.Columns["Estado"].Visible = false;
                    if (dgvReporte.Columns.Contains("Orden")) dgvReporte.Columns["Orden"].Visible = false;

                    // Orden sugerido de columnas para Lista de servicios
                    if (tipo == "Lista de servicios")
                    {
                        if (dgvReporte.Columns.Contains("NombreLugar")) dgvReporte.Columns["NombreLugar"].Visible = false;
                        if (dgvReporte.Columns.Contains("Fecha")) dgvReporte.Columns["Fecha"].DisplayIndex = 0;
                        if (dgvReporte.Columns.Contains("Proyeccion")) dgvReporte.Columns["Proyeccion"].DisplayIndex = 1;
                        if (dgvReporte.Columns.Contains("DuracionMinutos")) dgvReporte.Columns["DuracionMinutos"].DisplayIndex = 2;
                        if (dgvReporte.Columns.Contains("TotalComensales")) dgvReporte.Columns["TotalComensales"].DisplayIndex = 3;
                        if (dgvReporte.Columns.Contains("TotalInvitados")) dgvReporte.Columns["TotalInvitados"].DisplayIndex = 4;
                        if (dgvReporte.Columns.Contains("TotalGeneral")) dgvReporte.Columns["TotalGeneral"].DisplayIndex = 5;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el reporte: " + ex.Message);
            }
        }
    }
}
