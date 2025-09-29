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
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReporte.DataSource == null || dgvReporte.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar. Genere un reporte primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                MessageBox.Show($"Reporte guardado como PDF:\n{rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ucReportes()
        {
            InitializeComponent();
        }

        private void ucReportes_Load(object sender, EventArgs e)
        {
            try
            {
                dtpHasta.Value = DateTime.Today;
                dtpDesde.Value = DateTime.Today.AddDays(-7);

                var negL = new LugarNegocio();
                var lugares = negL.listar() ?? new List<Lugar>();
                lugares.Insert(0, new Lugar { IdLugar = 0, Nombre = "Todos" });
                cbLugar.DataSource = lugares;
                cbLugar.DisplayMember = "Nombre";
                cbLugar.ValueMember = "IdLugar";
                cbLugar.SelectedIndex = 0;

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
                        break;
                }

                if (dgvReporte.DataSource != null)
                {
                    if (dgvReporte.Columns.Contains("Fecha"))
                        dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

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

                    if (dgvReporte.Columns.Contains("IdServicio")) dgvReporte.Columns["IdServicio"].Visible = false;
                    if (dgvReporte.Columns.Contains("IdLugar")) dgvReporte.Columns["IdLugar"].Visible = false;
                    if (dgvReporte.Columns.Contains("Estado")) dgvReporte.Columns["Estado"].Visible = false;
                    if (dgvReporte.Columns.Contains("Orden")) dgvReporte.Columns["Orden"].Visible = false;

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
