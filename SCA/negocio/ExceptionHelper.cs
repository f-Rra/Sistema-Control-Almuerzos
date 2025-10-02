using System;
using System.Windows.Forms;

namespace Negocio
{
    /// <summary>
    /// Clase helper para manejo consistente de excepciones en toda la aplicación
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Muestra un mensaje de error con formato consistente
        /// </summary>
        public static void MostrarError(string mensaje, Exception ex = null)
        {
            string mensajeCompleto = mensaje;
            
            if (ex != null)
            {
                mensajeCompleto += $"\n\nDetalle técnico: {ex.Message}";
                
                // Log del error (aquí se podría integrar con un sistema de logging)
                System.Diagnostics.Debug.WriteLine($"[ERROR] {mensaje}");
                System.Diagnostics.Debug.WriteLine($"[EXCEPTION] {ex.ToString()}");
            }
            
            MessageBox.Show(mensajeCompleto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Muestra un mensaje de advertencia
        /// </summary>
        public static void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Muestra un mensaje informativo
        /// </summary>
        public static void MostrarInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Muestra un mensaje de éxito
        /// </summary>
        public static void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Muestra un diálogo de confirmación
        /// </summary>
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

        /// <summary>
        /// Maneja excepciones de base de datos con mensajes user-friendly
        /// </summary>
        public static void ManejarExcepcionBD(Exception ex, string operacion)
        {
            string mensaje = $"Error al {operacion}.";
            
            // Detectar errores comunes de SQL Server
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

        /// <summary>
        /// Envuelve una operación con manejo de excepciones
        /// </summary>
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

        /// <summary>
        /// Envuelve una operación void con manejo de excepciones
        /// </summary>
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
