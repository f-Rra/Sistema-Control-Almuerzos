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
        #region Constructor e Inicialización

        public ucConfiguracion()
        {
            InitializeComponent();
        }

        private void ucConfiguracion_Load(object sender, EventArgs e)
        {
            CargarConfiguracionBaseDatos();
            CargarInformacionRespaldos();
            CargarInformacionAplicacion();
        }

        public void RefrescarDatos()
        {
            CargarConfiguracionBaseDatos();
            CargarInformacionRespaldos();
            CargarInformacionAplicacion();
        }

        #endregion

        #region Configuración Base de Datos

        private void CargarConfiguracionBaseDatos()
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                var negocio = new ConfiguracionNegocio();

                string cadenaConexion = negocio.ObtenerCadenaConexion();
                txtCadenaConexion.Text = cadenaConexion ?? string.Empty;

                InfoBaseDatos info = negocio.ObtenerInfoBaseDatos();
                if (info != null)
                {
                    lblEstadoConexion.Text = "Estado: Conectado correctamente";
                    lblEstadoConexion.ForeColor = Color.LimeGreen;
                }
                else
                {
                    lblEstadoConexion.Text = "Estado: No conectado";
                    lblEstadoConexion.ForeColor = Color.Red;
                }
            }, "cargar configuración de base de datos");
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                string cadenaConexion = txtCadenaConexion.Text.Trim();

                if (string.IsNullOrEmpty(cadenaConexion))
                {
                    ExceptionHelper.MostrarAdvertencia("La cadena de conexión no puede estar vacía");
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                var negocio = new ConfiguracionNegocio();
                bool exitoso = negocio.ProbarConexion(cadenaConexion);

                if (exitoso)
                {
                    MessageBox.Show("Conexión exitosa a la base de datos", 
                        "Prueba de Conexión", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    
                    lblEstadoConexion.Text = "Estado: Conectado correctamente";
                    lblEstadoConexion.ForeColor = Color.LimeGreen;
                }
                else
                {
                    ExceptionHelper.MostrarError("No se pudo conectar a la base de datos");
                    lblEstadoConexion.Text = "Estado: Error de conexión";
                    lblEstadoConexion.ForeColor = Color.Red;
                }
            }, "probar conexión");

            this.Cursor = Cursors.Default;
        }

        private void btnGuardarConexion_Click(object sender, EventArgs e)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                string nuevaCadena = txtCadenaConexion.Text.Trim();

                if (string.IsNullOrEmpty(nuevaCadena))
                {
                    ExceptionHelper.MostrarAdvertencia("La cadena de conexión no puede estar vacía");
                    return;
                }

                DialogResult resultado = MessageBox.Show(
                    "ADVERTENCIA: Cambiar la cadena de conexión puede afectar el funcionamiento del sistema.\n\n" +
                    "¿Desea probar la conexión antes de guardar?",
                    "Confirmar Cambio de Conexión",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Cancel)
                    return;

                if (resultado == DialogResult.Yes)
                {
                    var negocio = new ConfiguracionNegocio();
                    if (!negocio.ProbarConexion(nuevaCadena))
                    {
                        ExceptionHelper.MostrarError("No se pudo conectar con la nueva cadena de conexión");
                        return;
                    }
                }

                if (ExceptionHelper.MostrarConfirmacion(
                    "¿Está seguro de guardar la nueva cadena de conexión?\n\nLa aplicación se reiniciará."))
                {
                    this.Cursor = Cursors.WaitCursor;

                    var negocio = new ConfiguracionNegocio();
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
                }
            }, "guardar cadena de conexión");

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Información de Aplicación

        private void CargarInformacionAplicacion()
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                var negocio = new ConfiguracionNegocio();
                InfoAplicacion info = negocio.ObtenerInfoAplicacion();

                if (info != null)
                {
                    lblVersion.Text = $"Versión:                      {info.Version}";
                    lblFechaCompilacion.Text = $"Fecha de compilación:  {info.FechaCompilacion:dd/MM/yyyy}";
                    lblFramework.Text = $"Framework:            {info.Framework}";
                    lblUILibrary.Text = $"UI Library:              {info.UILibrary}";
                }
            }, "cargar información de aplicación");
        }

        #endregion

        #region Respaldos y Restauración

        private void CargarInformacionRespaldos()
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                string rutaRespaldos = ConfigurationManager.AppSettings["RutaRespaldos"];
                if (!string.IsNullOrEmpty(rutaRespaldos))
                {
                    txtRutaRespaldos.Text = rutaRespaldos;
                }

                string frecuencia = ConfigurationManager.AppSettings["FrecuenciaRespaldo"];
                if (frecuencia == "Manual")
                {
                    rbManual.Checked = true;
                }
                else
                {
                    rbMensual.Checked = true; // Por defecto
                }

                var negocio = new ConfiguracionNegocio();
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
            }, "cargar información de respaldos");
        }

        private void btnExaminarRuta_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Seleccione la carpeta donde se guardarán los respaldos";
                dialog.ShowNewFolderButton = true;

                if (!string.IsNullOrEmpty(txtRutaRespaldos.Text) && Directory.Exists(txtRutaRespaldos.Text))
                {
                    dialog.SelectedPath = txtRutaRespaldos.Text;
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtRutaRespaldos.Text = dialog.SelectedPath;
                    GuardarConfiguracionRespaldos();
                }
            }
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

        private void btnCrearRespaldo_Click(object sender, EventArgs e)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                if (string.IsNullOrWhiteSpace(txtRutaRespaldos.Text))
                {
                    MessageBox.Show("Debe especificar una ruta para guardar el respaldo.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!Directory.Exists(txtRutaRespaldos.Text))
                {
                    MessageBox.Show("La ruta especificada no existe.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Advertencia sobre permisos de SQL Server
                if (!txtRutaRespaldos.Text.StartsWith(@"C:\Program Files\Microsoft SQL Server\") &&
                    !txtRutaRespaldos.Text.StartsWith(@"C:\SQLBackups"))
                {
                    DialogResult advertencia = MessageBox.Show(
                        "ADVERTENCIA: La ruta seleccionada puede no tener permisos para SQL Server.\n\n" +
                        "Se recomienda usar rutas como:\n" +
                        "• C:\\SQLBackups\n" +
                        "• C:\\Program Files\\Microsoft SQL Server\\MSSQL[version]\\MSSQL\\Backup\\\n\n" +
                        "¿Desea continuar de todas formas?",
                        "Advertencia de Permisos",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (advertencia != DialogResult.Yes)
                        return;
                }

                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea crear un respaldo de la base de datos?\n\n" +
                    "Esta operación puede tardar varios minutos dependiendo del tamaño de la base de datos.",
                    "Confirmar respaldo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string nombreArchivo = $"BD_Control_Almuerzos_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                    string rutaCompleta = Path.Combine(txtRutaRespaldos.Text, nombreArchivo);

                    var negocio = new ConfiguracionNegocio();
                    negocio.CrearRespaldo(rutaCompleta);

                    MessageBox.Show(
                        $"Respaldo creado exitosamente.\n\nArchivo: {nombreArchivo}",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarInformacionRespaldos();
                }
            }, "crear respaldo");
        }

        private void btnRestaurarRespaldo_Click(object sender, EventArgs e)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                DialogResult advertencia = MessageBox.Show(
                    " ADVERTENCIA CRÍTICA \n\n" +
                    "Restaurar un respaldo ELIMINARÁ TODOS LOS DATOS ACTUALES de la base de datos " +
                    "y los reemplazará con los datos del archivo de respaldo seleccionado.\n\n" +
                    "Esta acción NO SE PUEDE DESHACER.\n\n" +
                    "¿Está COMPLETAMENTE SEGURO de que desea continuar?",
                    "Advertencia Crítica",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (advertencia != DialogResult.Yes)
                {
                    return;
                }

                using (var dialog = new OpenFileDialog())
                {
                    dialog.Title = "Seleccionar archivo de respaldo";
                    dialog.Filter = "Archivos de respaldo (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
                    dialog.FilterIndex = 1;

                    if (!string.IsNullOrEmpty(txtRutaRespaldos.Text) && Directory.Exists(txtRutaRespaldos.Text))
                    {
                        dialog.InitialDirectory = txtRutaRespaldos.Text;
                    }

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        DialogResult confirmacion = MessageBox.Show(
                            $"Archivo seleccionado:\n{dialog.FileName}\n\n" +
                            "Esta es su ÚLTIMA OPORTUNIDAD para cancelar.\n\n" +
                            "¿Confirma que desea restaurar este respaldo?",
                            "Confirmación Final",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (confirmacion == DialogResult.Yes)
                        {
                            var negocio = new ConfiguracionNegocio();
                            negocio.RestaurarRespaldo(dialog.FileName);

                            MessageBox.Show(
                                "Respaldo restaurado exitosamente.\n\n" +
                                "La aplicación se reiniciará para aplicar los cambios.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            Application.Restart();
                            Environment.Exit(0);
                        }
                    }
                }
            }, "restaurar respaldo");
        }

        #endregion
    }
}
