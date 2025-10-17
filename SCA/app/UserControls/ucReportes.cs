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
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            dtpHasta.Value = DateTime.Today;
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            CargarLugares();
            CargarReportes();
        }

        // Método público para refrescar los datos desde otros UserControls
        public void RefrescarDatos()
        {
            CargarLugares();
            // Limpiar reporte actual si existe
            dgvReporte.DataSource = null;
        }

        private void CargarLugares()
        {
            var negL = new LugarNegocio();
            var lugares = negL.listar() ?? new List<Lugar>();
            lugares.Insert(0, new Lugar { IdLugar = 0, Nombre = "Todos" });
            
            // Limpiar DataSource antes de asignar nuevos datos
            cbLugar.DataSource = null;
            
            cbLugar.DataSource = lugares;
            cbLugar.DisplayMember = "Nombre";
            cbLugar.ValueMember = "IdLugar";
            cbLugar.SelectedIndex = 0;
        }


        private void CargarReportes()
        {
            cbTipoReporte.Items.Clear();
            cbTipoReporte.Items.Add("Lista de servicios");
            cbTipoReporte.Items.Add("Asistencias por empresas");
            cbTipoReporte.Items.Add("Cobertura vs proyección");
            cbTipoReporte.Items.Add("Distribución por día de semana");
            cbTipoReporte.SelectedIndex = 0;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReporte.DataSource == null || dgvReporte.Rows.Count == 0)
                {
                    ExceptionHelper.MostrarAdvertencia("No hay datos para exportar. Genere un reporte primero.");
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Archivos PDF|*.pdf";
                    saveDialog.Title = "Guardar Reporte como PDF";
                    saveDialog.FileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportarPDF(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "exportar el reporte");
            }
        }

        private void ExportarPDF(string rutaArchivo)
        {
            try
            {
                var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 20, 20, 20, 20);
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Create));
                doc.Open();

                // Título
                var fontTitulo = iTextSharp.text.FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD);
                var fontNormal = iTextSharp.text.FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);
                doc.Add(new iTextSharp.text.Paragraph("SISTEMA DE CONTROL DE ALMUERZOS", fontTitulo));
                doc.Add(new iTextSharp.text.Paragraph("Reporte de servicios", fontNormal));
                doc.Add(new iTextSharp.text.Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal));

                // Información de filtros
                string infoFiltros = $"Fechas: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}    Lugar: {cbLugar.Text}    Tipo de reporte: {cbTipoReporte.Text}";
                doc.Add(new iTextSharp.text.Paragraph(infoFiltros, fontNormal));
                doc.Add(new iTextSharp.text.Paragraph(" "));

                // Tabla
                int colCount = dgvReporte.Columns.GetColumnCount(DataGridViewElementStates.Visible);
                var table = new iTextSharp.text.pdf.PdfPTable(colCount);
                table.WidthPercentage = 100;

                // Encabezados
                foreach (DataGridViewColumn col in dgvReporte.Columns)
                {
                    if (col.Visible)
                    {
                        var cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(col.HeaderText, fontNormal));
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }
                }

                // Filas
                foreach (DataGridViewRow row in dgvReporte.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewColumn col in dgvReporte.Columns)
                        {
                            if (col.Visible)
                            {
                                var value = row.Cells[col.Index].Value?.ToString() ?? "";
                                table.AddCell(new iTextSharp.text.Phrase(value, fontNormal));
                            }
                        }
                    }
                }

                doc.Add(table);
                doc.Close();
                writer.Close();

                ExceptionHelper.MostrarExito($"Reporte guardado como PDF:\n{rutaArchivo}");
                System.Diagnostics.Process.Start(rutaArchivo);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "generar el PDF");
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFechas(out DateTime desde, out DateTime hasta))
                    return;

                int? idLugar = ObtenerLugarSeleccionado();
                string tipo = cbTipoReporte.SelectedItem as string ?? string.Empty;

                CargarReporte(tipo, desde, hasta, idLugar);

                if (dgvReporte.DataSource != null)
                {
                    ConfigurarColumnasReporte(tipo);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "generar el reporte");
            }
        }

        private bool ValidarFechas(out DateTime desde, out DateTime hasta)
        {
            desde = dtpDesde.Value.Date;
            hasta = dtpHasta.Value.Date;

            if (desde > hasta)
            {
                ExceptionHelper.MostrarAdvertencia("El rango de fechas es inválido (Desde > Hasta)");
                return false;
            }
            return true;
        }

        private int? ObtenerLugarSeleccionado()
        {
            if (cbLugar.SelectedValue is int val && val > 0)
                return val;
            return null;
        }

        private void CargarReporte(string tipo, DateTime desde, DateTime hasta, int? idLugar)
        {
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
                case "Distribución por día":
                    dgvReporte.DataSource = rep.DistribucionPorDiaSemana(desde, hasta, idLugar);
                    break;
            }
        }

        private void ConfigurarColumnasReporte(string tipoReporte)
        {
            ConfigurarFormatos();
            ConfigurarEncabezados();
            OcultarColumnasInternas();
            ConfigurarColumnasEspecificas(tipoReporte);
        }

        private void ConfigurarFormatos()
        {
            ConfigurarColumna("Fecha", formato: "dd/MM/yyyy");
            ConfigurarColumna("CoberturaPorcentaje", formato: "N2");
        }

        private void ConfigurarEncabezados()
        {
            ConfigurarColumna("NombreLugar", headerText: "Lugar");
            ConfigurarColumna("Proyeccion", headerText: "Proyección");
            ConfigurarColumna("DuracionMinutos", headerText: "Duración (min)");
            ConfigurarColumna("TotalComensales", headerText: "Total Comensales");
            ConfigurarColumna("TotalInvitados", headerText: "Total Invitados");
            ConfigurarColumna("TotalGeneral", headerText: "Total General");
            ConfigurarColumna("CoberturaPorcentaje", headerText: "Cobertura %");
            ConfigurarColumna("TotalAsistencias", headerText: "Total Asistencias");
            ConfigurarColumna("Diferencia", headerText: "Diferencia");
            ConfigurarColumna("Atendidos", headerText: "Atendidos");
        }

        private void OcultarColumnasInternas()
        {
            ConfigurarColumna("IdServicio", visible: false);
            ConfigurarColumna("IdLugar", visible: false);
            ConfigurarColumna("Estado", visible: false);
            ConfigurarColumna("Orden", visible: false);
        }

        private void ConfigurarColumnasEspecificas(string tipoReporte)
        {
            if (tipoReporte == "Lista de servicios")
            {
                ConfigurarColumna("NombreLugar", visible: false);
                ConfigurarColumna("Fecha", displayIndex: 0);
                ConfigurarColumna("Proyeccion", displayIndex: 1);
                ConfigurarColumna("DuracionMinutos", displayIndex: 2);
                ConfigurarColumna("TotalComensales", displayIndex: 3);
                ConfigurarColumna("TotalInvitados", displayIndex: 4);
                ConfigurarColumna("TotalGeneral", displayIndex: 5);
            }
        }

        private void ConfigurarColumna(string nombreColumna, string headerText = null, string formato = null, bool? visible = null, int? displayIndex = null)
        {
            if (!dgvReporte.Columns.Contains(nombreColumna))
                return;

            var columna = dgvReporte.Columns[nombreColumna];

            if (headerText != null)
                columna.HeaderText = headerText;

            if (formato != null)
                columna.DefaultCellStyle.Format = formato;

            if (visible.HasValue)
                columna.Visible = visible.Value;

            if (displayIndex.HasValue)
                columna.DisplayIndex = displayIndex.Value;
        }
    }
}
