using System;
using System.Windows.Forms;

namespace Negocio
{
    public static class ExceptionHelper
    {

        public static void MostrarError(string mensaje, Exception ex = null)
        {
            string mensajeCompleto = mensaje;
            
            if (ex != null)
            {
                mensajeCompleto += $"\n\nDetalle técnico: {ex.Message}";
                System.Diagnostics.Debug.WriteLine($"[ERROR] {mensaje}");
                System.Diagnostics.Debug.WriteLine($"[EXCEPTION] {ex.ToString()}");
            }
            
            MessageBox.Show(mensajeCompleto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void MostrarInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool MostrarConfirmacion(string mensaje)
        {
            DialogResult resultado = MessageBox.Show(
                mensaje, 
                "Confirmación", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );
            
            return resultado == DialogResult.Yes;
        }

        public static void ManejarExcepcionBD(Exception ex, string operacion)
        {
            string mensaje = $"Error al {operacion}.";
            
            if (ex.Message.Contains("timeout"))
            {
                mensaje += "\n\nLa operación tardó demasiado tiempo. Intente nuevamente.";
            }
            else if (ex.Message.Contains("connection"))
            {
                mensaje += "\n\nNo se pudo conectar a la base de datos. Verifique la conexión.";
            }
            else if (ex.Message.Contains("UNIQUE"))
            {
                mensaje += "\n\nYa existe un registro con esos datos.";
            }
            else if (ex.Message.Contains("FOREIGN KEY"))
            {
                mensaje += "\n\nNo se puede eliminar porque tiene registros relacionados.";
            }
            
            MostrarError(mensaje, ex);
        }

        public static T EjecutarConManejo<T>(Func<T> operacion, string mensajeError)
        {
            try
            {
                return operacion();
            }
            catch (Exception ex)
            {
                ManejarExcepcionBD(ex, mensajeError);
                return default(T);
            }
        }

        public static void EjecutarConManejo(Action operacion, string mensajeError)
        {
            try
            {
                operacion();
            }
            catch (Exception ex)
            {
                ManejarExcepcionBD(ex, mensajeError);
            }
        }
    }
}
