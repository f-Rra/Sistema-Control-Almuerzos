using System.Windows.Forms;

namespace app.Helpers
{

    public static class ListadoHelper
    {

        public static void OcultarColumnas(DataGridView dgv, params string[] nombresColumnas)
        {
            if (dgv?.Columns == null) return;

            foreach (var nombreColumna in nombresColumnas)
            {
                if (dgv.Columns.Contains(nombreColumna))
                {
                    dgv.Columns[nombreColumna].Visible = false;
                }
            }
        }

        public static void ConfigurarHeaderText(DataGridView dgv, string nombreColumna, string headerText)
        {
            if (dgv?.Columns == null) return;

            if (dgv.Columns.Contains(nombreColumna))
            {
                dgv.Columns[nombreColumna].HeaderText = headerText;
            }
        }

        public static void ConfigurarHeaders(DataGridView dgv, params (string columna, string header)[] configuraciones)
        {
            foreach (var (columna, header) in configuraciones)
            {
                ConfigurarHeaderText(dgv, columna, header);
            }
        }

        public static T ObtenerValorCelda<T>(DataGridViewRow row, string nombreColumna, T valorPorDefecto = default)
        {
            if (row?.Cells[nombreColumna]?.Value == null)
                return valorPorDefecto;

            try
            {
                return (T)row.Cells[nombreColumna].Value;
            }
            catch
            {
                return valorPorDefecto;
            }
        }

        public static void ConfigurarFormato(DataGridView dgv, string nombreColumna, string formato)
        {
            if (dgv?.Columns == null) return;

            if (dgv.Columns.Contains(nombreColumna))
            {
                dgv.Columns[nombreColumna].DefaultCellStyle.Format = formato;
            }
        }

        public static void ConfigurarOrden(DataGridView dgv, string nombreColumna, int displayIndex)
        {
            if (dgv?.Columns == null) return;

            if (dgv.Columns.Contains(nombreColumna))
            {
                dgv.Columns[nombreColumna].DisplayIndex = displayIndex;
            }
        }
    }
}
