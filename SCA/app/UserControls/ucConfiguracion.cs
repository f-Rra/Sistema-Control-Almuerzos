using System;
using System.Drawing;
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
            CargarInformacionAplicacion();
        }

        public void RefrescarDatos()
        {
            CargarConfiguracionBaseDatos();
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
    }
}
