using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace app.UserControls
{
    public partial class ucConfiguracion : UserControl
    {
        #region Variables y Constantes

        private ConfiguracionNegocio negocio;

        #endregion

        #region Constructor e Inicialización

        public ucConfiguracion()
        {
            InitializeComponent();
            negocio = new ConfiguracionNegocio();
        }

        private void ucConfiguracion_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            CargarConfiguracionBaseDatos();
            CargarInformacionRespaldos();
            CargarInformacionAplicacion();
        }

        public void RefrescarDatos()
        {
            CargarDatosIniciales();
        }

        #endregion

        #region Configuración Base de Datos

        private void CargarConfiguracionBaseDatos()
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                string cadenaConexion = negocio.ObtenerCadenaConexion();
                txtCadenaConexion.Text = cadenaConexion ?? string.Empty;

                InfoBaseDatos info = negocio.ObtenerInfoBaseDatos();
                ActualizarEstadoConexion(info != null);
            }, "cargar configuración de base de datos");
        }

        private void ActualizarEstadoConexion(bool conectado)
        {
            if (conectado)
            {
                lblEstadoConexion.Text = "Estado: Conectado correctamente";
                lblEstadoConexion.ForeColor = Color.LimeGreen;
            }
            else
            {
                lblEstadoConexion.Text = "Estado: No conectado";
                lblEstadoConexion.ForeColor = Color.Red;
            }
        }

        private void ProbarConexion()
        {
            string cadenaConexion = txtCadenaConexion.Text.Trim();

            if (!ValidarCadenaConexion(cadenaConexion))
                return;

            this.Cursor = Cursors.WaitCursor;

            bool exitoso = negocio.ProbarConexion(cadenaConexion);

            if (exitoso)
            {
                MessageBox.Show("Conexión exitosa a la base de datos", 
                    "Prueba de Conexión", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                
                ActualizarEstadoConexion(true);
            }
            else
            {
                ExceptionHelper.MostrarError("No se pudo conectar a la base de datos");
                lblEstadoConexion.Text = "Estado: Error de conexión";
                lblEstadoConexion.ForeColor = Color.Red;
            }

            this.Cursor = Cursors.Default;
        }

        private bool ValidarCadenaConexion(string cadenaConexion)
        {
            if (string.IsNullOrEmpty(cadenaConexion))
            {
                ExceptionHelper.MostrarAdvertencia("La cadena de conexión no puede estar vacía");
                return false;
            }
            return true;
        }

        private void GuardarConexion()
        {
            string nuevaCadena = txtCadenaConexion.Text.Trim();

            if (!ValidarCadenaConexion(nuevaCadena))
                return;

            if (!ConfirmarCambioConexion(nuevaCadena))
                return;

            if (!ConfirmarGuardado())
                return;

            EjecutarGuardadoConexion(nuevaCadena);
        }

        private bool ConfirmarCambioConexion(string nuevaCadena)
        {
            DialogResult resultado = MessageBox.Show(
                "ADVERTENCIA: Cambiar la cadena de conexión puede afectar el funcionamiento del sistema.\n\n" +
                "¿Desea probar la conexión antes de guardar?",
                "Confirmar Cambio de Conexión",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Cancel)
                return false;

            if (resultado == DialogResult.Yes)
            {
                if (!negocio.ProbarConexion(nuevaCadena))
                {
                    ExceptionHelper.MostrarError("No se pudo conectar con la nueva cadena de conexión");
                    return false;
                }
            }

            return true;
        }

        private bool ConfirmarGuardado()
        {
            return ExceptionHelper.MostrarConfirmacion(
                "¿Está seguro de guardar la nueva cadena de conexión?\n\nLa aplicación se reiniciará.");
        }

        private void EjecutarGuardadoConexion(string nuevaCadena)
        {
            this.Cursor = Cursors.WaitCursor;

            bool guardado = negocio.GuardarCadenaConexion(nuevaCadena);

            if (guardado)
            {
                MessageBox.Show(
                    "Cadena de conexión guardada correctamente.\n\nLa aplicación se reiniciará.",
                    "Configuración Guardada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Application.Restart();
            }
            else
            {
                ExceptionHelper.MostrarError("No se pudo guardar la cadena de conexión");
            }

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Información de Aplicación

        private void CargarInformacionAplicacion()
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                InfoAplicacion info = negocio.ObtenerInfoAplicacion();

                if (info != null)
                {
                    ActualizarInfoAplicacion(info);
                }
            }, "cargar información de aplicación");
        }

        private void ActualizarInfoAplicacion(InfoAplicacion info)
        {
            lblVersion.Text = $"Versión:                      {info.Version}";
            lblFechaCompilacion.Text = $"Fecha de compilación:  {info.FechaCompilacion:dd/MM/yyyy}";
            lblFramework.Text = $"Framework:            {info.Framework}";
            lblUILibrary.Text = $"UI Library:              {info.UILibrary}";
        }

        #endregion

        #region Respaldos y Restauración

        private void CargarInformacionRespaldos()
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                CargarRutaRespaldos();
                CargarFrecuenciaRespaldo();
                CargarUltimoRespaldo();
            }, "cargar información de respaldos");
        }

        private void CargarRutaRespaldos()
        {
            string rutaRespaldos = ConfigurationManager.AppSettings["RutaRespaldos"];
            if (!string.IsNullOrEmpty(rutaRespaldos))
            {
                txtRutaRespaldos.Text = rutaRespaldos;
            }
        }

        private void CargarFrecuenciaRespaldo()
        {
            string frecuencia = ConfigurationManager.AppSettings["FrecuenciaRespaldo"];
            if (frecuencia == "Manual")
            {
                rbManual.Checked = true;
            }
            else
            {
                rbMensual.Checked = true; // Por defecto
            }
        }

        private void CargarUltimoRespaldo()
        {
            InfoRespaldo ultimoRespaldo = negocio.ObtenerUltimoRespaldo();

            if (ultimoRespaldo != null)
            {
                lblUltimoRespaldo.Text = $"Último respaldo: {ultimoRespaldo.FechaRespaldo:dd/MM/yyyy HH:mm}";
                lblTamañoRespaldo.Text = $"Tamaño: {ultimoRespaldo.TamañoMB:N2} MB";
            }
            else
            {
                lblUltimoRespaldo.Text = "Último respaldo: Sin información";
                lblTamañoRespaldo.Text = "Tamaño: -";
            }
        }

        private void ExaminarRuta()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                ConfigurarDialogoRuta(dialog);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtRutaRespaldos.Text = dialog.SelectedPath;
                    GuardarConfiguracionRespaldos();
                }
            }
        }

        private void ConfigurarDialogoRuta(FolderBrowserDialog dialog)
        {
            dialog.Description = "Seleccione la carpeta donde se guardarán los respaldos";
            dialog.ShowNewFolderButton = true;

            if (!string.IsNullOrEmpty(txtRutaRespaldos.Text) && Directory.Exists(txtRutaRespaldos.Text))
            {
                dialog.SelectedPath = txtRutaRespaldos.Text;
            }
        }

        private void GuardarConfiguracionRespaldos()
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.AppSettings.Settings["RutaRespaldos"] == null)
                {
                    config.AppSettings.Settings.Add("RutaRespaldos", txtRutaRespaldos.Text);
                }
                else
                {
                    config.AppSettings.Settings["RutaRespaldos"].Value = txtRutaRespaldos.Text;
                }

                string frecuencia = rbMensual.Checked ? "Mensual" : "Manual";
                if (config.AppSettings.Settings["FrecuenciaRespaldo"] == null)
                {
                    config.AppSettings.Settings.Add("FrecuenciaRespaldo", frecuencia);
                }
                else
                {
                    config.AppSettings.Settings["FrecuenciaRespaldo"].Value = frecuencia;
                }

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }, "guardar configuración de respaldos");
        }

        private void CrearRespaldo()
        {
            if (!ValidarRutaRespaldo())
                return;

            if (!ConfirmarCreacionRespaldo())
                return;

            EjecutarCreacionRespaldo();
        }

        private bool ValidarRutaRespaldo()
        {
            if (string.IsNullOrWhiteSpace(txtRutaRespaldos.Text))
            {
                MessageBox.Show("Debe especificar una ruta para guardar el respaldo.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!Directory.Exists(txtRutaRespaldos.Text))
            {
                MessageBox.Show("La ruta especificada no existe.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ConfirmarCreacionRespaldo()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea crear un respaldo de la base de datos?\n\n" +
                "Esta operación puede tardar varios minutos dependiendo del tamaño de la base de datos.",
                "Confirmar respaldo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        private void EjecutarCreacionRespaldo()
        {
            string nombreArchivo = $"BD_Control_Almuerzos_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string rutaCompleta = Path.Combine(txtRutaRespaldos.Text, nombreArchivo);

            negocio.CrearRespaldo(rutaCompleta);

            MessageBox.Show(
                $"Respaldo creado exitosamente.\n\nArchivo: {nombreArchivo}",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            CargarInformacionRespaldos();
        }

        private void RestaurarRespaldo()
        {
            if (!MostrarAdvertenciaCritica())
                return;

            using (var dialog = new OpenFileDialog())
            {
                ConfigurarDialogoRespaldo(dialog);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (ConfirmarRestauracion(dialog.FileName))
                    {
                        EjecutarRestauracion(dialog.FileName);
                    }
                }
            }
        }

        private bool MostrarAdvertenciaCritica()
        {
            DialogResult advertencia = MessageBox.Show(
                "ADVERTENCIA CRÍTICA \n\n" +
                "Restaurar un respaldo ELIMINARÁ TODOS LOS DATOS ACTUALES de la base de datos " +
                "y los reemplazará con los datos del archivo de respaldo seleccionado.\n\n" +
                "Esta acción NO SE PUEDE DESHACER.\n\n" +
                "¿Está COMPLETAMENTE SEGURO de que desea continuar?",
                "Advertencia Crítica",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            return advertencia == DialogResult.Yes;
        }

        private void ConfigurarDialogoRespaldo(OpenFileDialog dialog)
        {
            dialog.Title = "Seleccionar archivo de respaldo";
            dialog.Filter = "Archivos de respaldo (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
            dialog.FilterIndex = 1;

            if (!string.IsNullOrEmpty(txtRutaRespaldos.Text) && Directory.Exists(txtRutaRespaldos.Text))
            {
                dialog.InitialDirectory = txtRutaRespaldos.Text;
            }
        }

        private bool ConfirmarRestauracion(string archivo)
        {
            DialogResult confirmacion = MessageBox.Show(
                $"Archivo seleccionado:\n{archivo}\n\n" +
                "Esta es su ÚLTIMA OPORTUNIDAD para cancelar.\n\n" +
                "¿Confirma que desea restaurar este respaldo?",
                "Confirmación Final",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            return confirmacion == DialogResult.Yes;
        }

        private void EjecutarRestauracion(string archivo)
        {
            negocio.RestaurarRespaldo(archivo);

            MessageBox.Show(
                "Respaldo restaurado exitosamente.\n\n" +
                "La aplicación se reiniciará para aplicar los cambios.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Application.Restart();
            Environment.Exit(0);
        }

        #endregion

        #region Eventos

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                ProbarConexion();
            }, "probar conexión");
        }

        private void btnGuardarConexion_Click(object sender, EventArgs e)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                GuardarConexion();
            }, "guardar cadena de conexión");
        }

        private void btnExaminarRuta_Click(object sender, EventArgs e)
        {
            ExaminarRuta();
        }

        private void rbMensual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMensual.Checked)
            {
                GuardarConfiguracionRespaldos();
            }
        }

        private void rbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbManual.Checked)
            {
                GuardarConfiguracionRespaldos();
            }
        }

        private void btnCrearRespaldo_Click(object sender, EventArgs e)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                CrearRespaldo();
            }, "crear respaldo");
        }

        private void btnRestaurarRespaldo_Click(object sender, EventArgs e)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                RestaurarRespaldo();
            }, "restaurar respaldo");
        }

        #endregion
    }
}
