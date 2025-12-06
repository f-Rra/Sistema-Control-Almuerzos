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
using app.Helpers;
using static app.Helpers.MensajesConstantes;

namespace app.UserControls
{
    public partial class ucReportes : UserControl
    {
        #region Variables y Constantes

        private ReporteNegocio reporteNegocio;
        private LugarNegocio lugarNegocio;

        #endregion

        #region Constructor e Inicialización

        public ucReportes()
        {
            InitializeComponent();
            reporteNegocio = new ReporteNegocio();
            lugarNegocio = new LugarNegocio();
        }

        private void ucReportes_Load(object sender, EventArgs e)
        {
            ConfigurarFechasIniciales();
            CargarDatosIniciales();
        }

        private void ConfigurarFechasIniciales()
        {
            dtpHasta.Value = DateTime.Today;
            dtpDesde.Value = DateTime.Today.AddDays(-7);
        }

        private void CargarDatosIniciales()
        {
            CargarLugares();
            CargarReportes();
        }

        public void RefrescarDatos()
        {
            CargarLugares();
            LimpiarReporteActual();
        }

        private void LimpiarReporteActual()
        {
            dgvReporte.DataSource = null;
        }

        #endregion

        #region Carga de Datos

        private void CargarLugares()
        {
            try
            {
                var lugares = ObtenerLugaresConOpcionTodos();
                ConfigurarComboBoxLugares(lugares);
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private List<Lugar> ObtenerLugaresConOpcionTodos()
        {
            var lugares = lugarNegocio.Listar() ?? new List<Lugar>();
            lugares.Insert(0, new Lugar { IdLugar = 0, Nombre = "Todos" });
            return lugares;
        }

        private void ConfigurarComboBoxLugares(List<Lugar> lugares)
        {
            cbLugar.DataSource = null;
            cbLugar.DataSource = lugares;
            cbLugar.DisplayMember = "Nombre";
            cbLugar.ValueMember = "IdLugar";
            cbLugar.SelectedIndex = 0;
        }

        private void CargarReportes()
        {
            cbTipoReporte.Items.Clear();
            AgregarTiposDeReporte();
            cbTipoReporte.SelectedIndex = 0;
        }

        private void AgregarTiposDeReporte()
        {
            cbTipoReporte.Items.Add("Lista de servicios");
            cbTipoReporte.Items.Add("Asistencias por empresas");
            cbTipoReporte.Items.Add("Cobertura vs proyección");
            cbTipoReporte.Items.Add("Distribución por día de semana");
        }

        #endregion

        #region Exportación PDF

        private void ExportarReporte()
        {
            if (!ValidarDatosParaExportar())
                return;

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                ConfigurarDialogoGuardar(saveDialog);

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarPDF(saveDialog.FileName);
                }
            }
        }

        private bool ValidarDatosParaExportar()
        {
            if (dgvReporte.DataSource == null || dgvReporte.Rows.Count == 0)
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_NO_HAY_DATOS_EXPORTAR);
                return false;
            }
            return true;
        }

        private void ConfigurarDialogoGuardar(SaveFileDialog saveDialog)
        {
            saveDialog.Filter = "Archivos PDF|*.pdf";
            saveDialog.Title = "Guardar Reporte como PDF";
            saveDialog.FileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        }

        private void ExportarPDF(string rutaArchivo)
        {
            try
            {
                using (var fileStream = new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Create))
                {
                    using (var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 20, 20, 20, 20))
                    {
                        using (var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fileStream))
                        {
                            doc.Open();

                            var fontTitulo = iTextSharp.text.FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD);
                            var fontNormal = iTextSharp.text.FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);

                            AgregarEncabezadoPDF(doc, fontTitulo, fontNormal);
                            AgregarInformacionFiltrosPDF(doc, fontNormal);
                            AgregarTablaDatosPDF(doc, fontNormal);

                            doc.Close();
                        }
                    }
                }

                MostrarMensajeExitoYAbrirPDF(rutaArchivo);
            }
            catch (System.IO.IOException ioEx)
            {
                MensajesUI.MostrarError(string.Format(ERROR_ARCHIVO_ABIERTO, ioEx.Message));
            }
            catch (Exception ex)
            {
                MensajesUI.MostrarError($"Error al generar el PDF: {ex.Message}");
            }
        }

        private void AgregarEncabezadoPDF(iTextSharp.text.Document doc, iTextSharp.text.Font fontTitulo, iTextSharp.text.Font fontNormal)
        {
            doc.Add(new iTextSharp.text.Paragraph("SISTEMA DE CONTROL DE ALMUERZOS", fontTitulo));
            doc.Add(new iTextSharp.text.Paragraph("Reporte de servicios", fontNormal));
            doc.Add(new iTextSharp.text.Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal));
        }

        private void AgregarInformacionFiltrosPDF(iTextSharp.text.Document doc, iTextSharp.text.Font fontNormal)
        {
            string infoFiltros = $"Fechas: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}    Lugar: {cbLugar.Text}    Tipo de reporte: {cbTipoReporte.Text}";
            doc.Add(new iTextSharp.text.Paragraph(infoFiltros, fontNormal));
            doc.Add(new iTextSharp.text.Paragraph(" "));
        }

        private void AgregarTablaDatosPDF(iTextSharp.text.Document doc, iTextSharp.text.Font fontNormal)
        {
            int colCount = dgvReporte.Columns.GetColumnCount(DataGridViewElementStates.Visible);
            var table = new iTextSharp.text.pdf.PdfPTable(colCount);
            table.WidthPercentage = 100;

            AgregarEncabezadosTabla(table, fontNormal);
            AgregarFilasTabla(table, fontNormal);

            doc.Add(table);
        }

        private void AgregarEncabezadosTabla(iTextSharp.text.pdf.PdfPTable table, iTextSharp.text.Font fontNormal)
        {
            foreach (DataGridViewColumn col in dgvReporte.Columns)
            {
                if (col.Visible)
                {
                    var cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(col.HeaderText, fontNormal));
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                }
            }
        }

        private void AgregarFilasTabla(iTextSharp.text.pdf.PdfPTable table, iTextSharp.text.Font fontNormal)
        {
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
        }

        private void MostrarMensajeExitoYAbrirPDF(string rutaArchivo)
        {
            MensajesUI.MostrarExito(string.Format(INFO_REPORTE_GUARDADO, rutaArchivo));
            System.Diagnostics.Process.Start(rutaArchivo);
        }

        #endregion

        #region Eventos

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarReporte();
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarReporte();
            }
            catch (Exception ex)
            {
                MensajesUI.MostrarError(string.Format(ERROR_EXPORTAR_REPORTE, ex.Message));
            }
        }

        #endregion

        #region Generación de Reportes

        private void GenerarReporte()
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

        private bool ValidarFechas(out DateTime desde, out DateTime hasta)
        {
            desde = dtpDesde.Value.Date;
            hasta = dtpHasta.Value.Date;

            if (desde > hasta)
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_RANGO_FECHAS_INVALIDO);
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
            dgvReporte.DataSource = null;

            switch (tipo)
            {
                case "Lista de servicios":
                    dgvReporte.DataSource = reporteNegocio.ListarServiciosRango(desde, hasta, idLugar);
                    break;
                case "Asistencias por empresas":
                    dgvReporte.DataSource = reporteNegocio.AsistenciasPorEmpresas(desde, hasta, idLugar);
                    break;
                case "Cobertura vs proyección":
                    dgvReporte.DataSource = reporteNegocio.ObtenerCoberturaVsProyeccion(desde, hasta, idLugar);
                    break;
                case "Distribución por día de semana":
                    dgvReporte.DataSource = reporteNegocio.DistribucionPorDiaSemana(desde, hasta, idLugar);
                    break;
            }
        }

        #endregion

        #region Configuración de Columnas

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
                ConfigurarColumnasListaServicios();
            }
        }

        private void ConfigurarColumnasListaServicios()
        {
            ConfigurarColumna("NombreLugar", visible: false);
            ConfigurarColumna("Fecha", displayIndex: 0);
            ConfigurarColumna("Proyeccion", displayIndex: 1);
            ConfigurarColumna("DuracionMinutos", displayIndex: 2);
            ConfigurarColumna("TotalComensales", displayIndex: 3);
            ConfigurarColumna("TotalInvitados", displayIndex: 4);
            ConfigurarColumna("TotalGeneral", displayIndex: 5);
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

        #endregion
    }
}
