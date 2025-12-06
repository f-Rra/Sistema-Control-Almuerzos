using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace app.Gestores
{
    /// <summary>
    /// Gestiona el cronómetro del servicio de almuerzos.
    /// </summary>
    public class GestorCronometro
    {
        private readonly Timer _timer;
        private readonly Stopwatch _stopwatch;
        private readonly Label _labelDisplay;
        
        public int DuracionMinutos { get; private set; }
        public bool EstaActivo => _stopwatch.IsRunning;

        public GestorCronometro(Label labelDisplay)
        {
            _labelDisplay = labelDisplay;
            _timer = new Timer { Interval = 1000 };
            _stopwatch = new Stopwatch();
            _timer.Tick += OnTimerTick;
            _labelDisplay.Text = "00:00:00";
        }

        public void Iniciar()
        {
            DuracionMinutos = 0;
            _stopwatch.Reset();
            _stopwatch.Start();
            _timer.Start();
        }

        public void Detener()
        {
            _timer.Stop();
            _stopwatch.Stop();
            ActualizarDisplay();
            DuracionMinutos = (int)Math.Ceiling(_stopwatch.Elapsed.TotalMinutes);
        }

        public void Resetear()
        {
            _stopwatch.Reset();
            _labelDisplay.Text = "00:00:00";
            DuracionMinutos = 0;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            ActualizarDisplay();
        }

        private void ActualizarDisplay()
        {
            _labelDisplay.Text = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
        }

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
            if (_stopwatch != null)
            {
                _stopwatch.Stop();
            }
        }
    }
}
