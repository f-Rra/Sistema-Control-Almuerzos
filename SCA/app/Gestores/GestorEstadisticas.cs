using System;
using System.Windows.Forms;

namespace app.Gestores
{
    /// <summary>
    /// Gestiona el cálculo y visualización de estadísticas del servicio.
    /// </summary>
    public class GestorEstadisticas
    {
        private readonly Label _labelEstadisticas;
        private readonly Label _labelProgreso;
        private readonly ProgressBar _progressBar;

        public GestorEstadisticas(Label labelEstadisticas, Label labelProgreso, ProgressBar progressBar)
        {
            _labelEstadisticas = labelEstadisticas;
            _labelProgreso = labelProgreso;
            _progressBar = progressBar;
        }

        public void Actualizar(int registrados, int proyeccion, int invitados)
        {
            int objetivo = proyeccion + invitados;
            int faltan = Math.Max(0, objetivo - registrados);
            int porcentaje = CalcularPorcentaje(registrados, objetivo);

            ActualizarUI(registrados, faltan, porcentaje);
        }

        public void Resetear()
        {
            _labelEstadisticas.Text = "Registrados: 0 │ Faltan: 0";
            _labelProgreso.Text = "0%";
            _progressBar.Value = 0;
        }

        private int CalcularPorcentaje(int registrados, int objetivo)
        {
            if (objetivo > 0)
                return Math.Min(100, (registrados * 100) / objetivo);
            
            return registrados > 0 ? 100 : 0;
        }

        private void ActualizarUI(int registrados, int faltan, int porcentaje)
        {
            _progressBar.Value = porcentaje;
            _labelProgreso.Text = $"{porcentaje}%";
            _labelEstadisticas.Text = $"Registrados: {registrados} │ Faltan: {faltan}";
        }
    }
}
