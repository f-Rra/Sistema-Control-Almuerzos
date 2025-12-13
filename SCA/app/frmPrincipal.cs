using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.UserControls;
using Negocio;
using Dominio;
using app.Helpers;
using app.Gestores;
using static app.Helpers.MensajesConstantes;

namespace app
{
    public partial class frmPrincipal : Form
    {
        #region Variables, Enums y Constantes
        private enum TipoVista
        {
            Servicio,
            RegistroManual,
            Reportes,
            Admin
        }

        private readonly Color MenuHover = Color.FromArgb(243, 229, 201);
        private readonly LugarNegocio _lugarNegocio = new LugarNegocio();
        private readonly ServicioNegocio _servicioNegocio = new ServicioNegocio();
        private GestorCronometro _gestorCronometro;
        private GestorEstadisticas _gestorEstadisticas;
        private GestorNavegacion _gestorNavegacion;
        private Dictionary<TipoVista, UserControl> _vistas;
        private int? _idServicioActual = null;

        #endregion

        #region Constructor e Inicialización

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            _gestorCronometro = new GestorCronometro(lblCronometro);
            _gestorEstadisticas = new GestorEstadisticas(lblEstadisticas, lblProgreso, pbProgreso);
            _gestorNavegacion = new GestorNavegacion(pnlPrincipal, pnlSuperior, gbxServicios, gbxUltimo);
            InicializarVistas();
            _servicioNegocio.FinalizarServiciosPendientes();
            CargarLugares();
            CargarFecha();
            ActualizarEstadisticas();
            CargarVistaPrincipal();
            gbxServicios.Visible = true;
            gbxUltimo.Visible = true;
            gbxServicios.BringToFront();
            gbxUltimo.BringToFront();
        }

        #endregion

        #region Gestión de Servicios


        private void IniciarServicio()
        {
            try
            {
                if (!ValidarLugar() || !ValidarProyeccion(out int proyeccion) || !ValidarInvitados())
                    return;

                if (!(cbLugar.SelectedValue is int idLugar))
                    return;
                
                CrearServicioEnBD(idLugar, proyeccion);
                
                _gestorCronometro.Iniciar();
                ActualizarControles();

                var vistaServicio = ObtenerVista(TipoVista.Servicio) as ucServicio;
                vistaServicio?.SetServicio(_idServicioActual, idLugar);
                ActualizarEstadisticas();
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void FinalizarServicio()
        {
            if (!MensajesUI.MostrarConfirmacion(CONFIRMACION_FINALIZAR_SERVICIO))
            {
                return;
            }

            DetenerCronometro();

            try
            {
                GuardarEstadisticasEnBD();
                MensajesUI.MostrarExito("Servicio finalizado correctamente");
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
            finally
            {
                ResetearControles();
            }
        }

        private void ToggleServicio()
        {
            if (_gestorCronometro.EstaActivo)
                FinalizarServicio();
            else
                IniciarServicio();
        }

        private bool ValidarLugar()
        {
            if (cbLugar.SelectedValue == null)
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_SELECCIONE_LUGAR);
                return false;
            }
            return true;
        }

        private bool ValidarProyeccion(out int proyeccion)
        {
            proyeccion = 0;
            string proyText = mtxtProyeccion.Text.Trim();
            
            if (string.IsNullOrEmpty(proyText))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_INGRESE_PROYECCION);
                return false;
            }

            if (!int.TryParse(proyText, out proyeccion))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_PROYECCION_VALIDA);
                return false;
            }
            
            if (proyeccion < 0 || proyeccion > 1000)
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_PROYECCION_RANGO);
                return false;
            }
            
            return true;
        }

        private bool ValidarInvitados()
        {
            if (string.IsNullOrWhiteSpace(mtxtInvitados.Text))
                return true; 
                
            if (!int.TryParse(mtxtInvitados.Text, out int invitados))
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_INVITADOS_VALIDO);
                return false;
            }
            
            if (invitados < 0 || invitados > 500)
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_INVITADOS_RANGO);
                return false;
            }
            
            return true;
        }

        private void CrearServicioEnBD(int idLugar, int proy)
        {
            int nuevoId = _servicioNegocio.CrearServicio(idLugar, proy);
            _idServicioActual = nuevoId;
        }

        private void ActualizarControles()
        {
            btnServicio.Text = "Finalizar Servicio";
            cbLugar.Enabled = false;
            mtxtProyeccion.ReadOnly = true;
            mtxtInvitados.ReadOnly = true;
            SetEstadoServicio(true);
            btnReportes.Enabled = false;
            btnAdmin.Enabled = false;
            btnRegistros.Enabled = true;
            btnHome.Enabled = true;
            _gestorNavegacion.MostrarGroupBoxes(false);
            CargarVistaPrincipal();
            MostrarVistaPrincipal();
        }

        private void DetenerCronometro()
        {
            _gestorCronometro.Detener();
            btnServicio.Text = "Iniciar Servicio";
        }

        private void GuardarEstadisticasEnBD()
        {
            if (_idServicioActual.HasValue)
            {
                int totalComensales = 0;
                if (_vistas.TryGetValue(TipoVista.Servicio, out var vistaServ))
                    totalComensales = (vistaServ as ucServicio)?.CountRegistros() ?? 0;

                int totalInvitados = 0;
                int.TryParse(mtxtInvitados.Text, out totalInvitados);

                _servicioNegocio.FinalizarServicio(_idServicioActual.Value, totalComensales, totalInvitados, _gestorCronometro.DuracionMinutos);
                ActualizarEstadisticas();
            }
        }

        private void ResetearControles()
        {
            cbLugar.Enabled = true;
            mtxtProyeccion.ReadOnly = false;
            mtxtInvitados.ReadOnly = false;
            _idServicioActual = null;
            mtxtProyeccion.Text = string.Empty;
            mtxtInvitados.Text = string.Empty;
            _gestorCronometro.Resetear();
            _gestorEstadisticas.Resetear();
            SetEstadoServicio(false);
            btnReportes.Enabled = true;
            btnAdmin.Enabled = true;
            btnRegistros.Enabled = true;
            btnHome.Enabled = true;
            _gestorNavegacion.OcultarTodasLasVistas();
            CargarServicios();
            CargarUltimoServicio();
            _gestorNavegacion.MostrarGroupBoxes(true);
        }

        private void SetEstadoServicio(bool activo)
        {
            if (activo)
            {
                lblEstado.Text = " ACTIVO";
                pbxEstado.Image = Properties.Resources.activo;
            }
            else
            {
                lblEstado.Text = "INACTIVO";
                pbxEstado.Image = Properties.Resources.inactivo;
            }
        }

        #endregion

        #region Carga de Datos 

        private void CargarServicios()
        {
            try
            {
                var lista = _servicioNegocio.ListarTodos();
                dgvServicios.DataSource = null;
                dgvServicios.DataSource = lista;

                if (dgvServicios.Columns.Count > 0)
                {
                    OcultarColumnasServicios();
                    RenombrarColumnasServicios();
                }
                dgvServicios.Refresh();
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void OcultarColumnasServicios()
        {
            ListadoHelper.OcultarColumnas(dgvServicios, 
                "IdServicio", "IdLugar", "Estado", "Proyeccion", "DuracionMinutos");
        }

        private void RenombrarColumnasServicios()
        {
            ListadoHelper.ConfigurarHeaders(dgvServicios,
                ("TotalComensales", "Comensales"),
                ("TotalInvitados", "Invitados"),
                ("TotalGeneral", "Total"));
        }

        private void CargarUltimoServicio()
        {
            try
            {
                Servicio ultimo = _servicioNegocio.ObtenerUltimoServicio();
                if (ultimo != null)
                {
                    lblUlugar.Text = "Lugar: " + ultimo.NombreLugar;
                    lblUfecha.Text = "Fecha: " + ultimo.Fecha.ToString("dd/MM/yyyy");
                    lblUproyeccion.Text = "Proyección: " + (ultimo.Proyeccion?.ToString() ?? "N/A");
                    lblUcomensales.Text = "Comensales: " + ultimo.TotalComensales.ToString();
                    lblUinvitados.Text = "Invitados: " + ultimo.TotalInvitados.ToString();
                    lblTotal.Text = "Total: " + ultimo.TotalGeneral.ToString();
                    lblDuracion.Text = "Duración: " + (ultimo.DuracionMinutos?.ToString() ?? "N/A") + " min";
                }
                else
                {
                    lblUlugar.Text = "Lugar: -";
                    lblUfecha.Text = "Fecha: -";
                    lblUproyeccion.Text = "Proyección: -";
                    lblUcomensales.Text = "Comensales: -";
                    lblUinvitados.Text = "Invitados: -";
                    lblTotal.Text = "Total: -";
                    lblDuracion.Text = "Duración: -";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("No se pudo cargar el último servicio: " + ex.Message);
            }
        }

        private void CargarLugares()
        {
            cbLugar.DataSource = null;
            cbLugar.DataSource = _lugarNegocio.Listar();
            cbLugar.ValueMember = "IdLugar";
            cbLugar.DisplayMember = "Nombre";
        }

        private void CargarFecha()
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFecha.ReadOnly = true;
            txtFecha.TabStop = false;
        }

        #endregion

        #region Gestión de UserControls

        private void InicializarVistas()
        {
            _vistas = new Dictionary<TipoVista, UserControl>();
        }

        private UserControl ObtenerVista(TipoVista tipo)
        {
            if (_vistas.TryGetValue(tipo, out UserControl vista)) return vista;
            
            UserControl nuevaVista = null;
            switch (tipo)
            {
                case TipoVista.Servicio:
                    nuevaVista = new ucServicio(this);
                    break;
                case TipoVista.RegistroManual:
                    nuevaVista = new ucRegistroManual(this);
                    break;
                case TipoVista.Reportes:
                    nuevaVista = new ucReportes();
                    break;
                case TipoVista.Admin:
                    nuevaVista = new ucAdmin();
                    break;
            }

            if (nuevaVista != null)
            {
                nuevaVista.Dock = DockStyle.Fill;
                nuevaVista.Visible = false;
                pnlPrincipal.Controls.Add(nuevaVista);
                _vistas[tipo] = nuevaVista;
            }

            return nuevaVista;
        }

        private void CargarVistaPrincipal()
        {
            if (_idServicioActual == null)
            {
                _gestorNavegacion.OcultarTodasLasVistas();
                CargarServicios();
                CargarUltimoServicio();
            }
            else
            {
                _gestorNavegacion.MostrarGroupBoxes(false);
                ObtenerVista(TipoVista.Servicio);
            }
        }

        private void MostrarVistaPrincipal()
        {
            CargarVistaPrincipal();
            _gestorNavegacion.MostrarPanelSuperior(true);

            if (_idServicioActual.HasValue)
            {
                var vistaServicio = ObtenerVista(TipoVista.Servicio);
                if (vistaServicio != null)
                    _gestorNavegacion.MostrarVista(vistaServicio);
            }
            else
            {
                _gestorNavegacion.OcultarTodasLasVistas();
                _gestorNavegacion.MostrarGroupBoxes(true);
            }
        }

        private bool MostrarVistaRegistroManual()
        {
            if (!_idServicioActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia(VALIDACION_SERVICIO_NO_ACTIVO);
                return false;
            }

            var vistaRegManual = ObtenerVista(TipoVista.RegistroManual) as ucRegistroManual;
            if (vistaRegManual == null) return false;

            vistaRegManual.RefrescarDatos();

            if (cbLugar.SelectedValue is int idLugar)
            {
                vistaRegManual.SetServicio(_idServicioActual.Value, idLugar);
            }

            _gestorNavegacion.MostrarPanelSuperior(true);
            _gestorNavegacion.MostrarVista(vistaRegManual);
            return true;
        }

        private bool MostrarVistaReportes()
        {
            if (_idServicioActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia(ADVERTENCIA_REPORTES_SERVICIO_ACTIVO);
                return false;
            }

            var vistaReportes = ObtenerVista(TipoVista.Reportes) as ucReportes;
            if (vistaReportes == null) return false;

            vistaReportes.RefrescarDatos();
            _gestorNavegacion.MostrarPanelSuperior(false);
            _gestorNavegacion.MostrarVista(vistaReportes);
            return true;
        }

        private bool MostrarVistaAdmin()
        {
            if (_idServicioActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia(ADVERTENCIA_ADMIN_SERVICIO_ACTIVO);
                return false;
            }

            var vistaAdmin = ObtenerVista(TipoVista.Admin) as ucAdmin;
            if (vistaAdmin == null) return false;

            _gestorNavegacion.MostrarPanelSuperior(false);
            _gestorNavegacion.MostrarVista(vistaAdmin);
            return true;
        }

        #endregion

        #region Actualizaciones

        public void RefrescarTodasLasVistas()
        {
            CargarLugares();

            if (_vistas.TryGetValue(TipoVista.RegistroManual, out var vistaReg))
                (vistaReg as ucRegistroManual)?.RefrescarDatos();

            if (_vistas.TryGetValue(TipoVista.Reportes, out var vistaRep))
                (vistaRep as ucReportes)?.RefrescarDatos();

            if (gbxServicios.Visible || gbxUltimo.Visible)
            {
                ActualizarEstadisticas();
                CargarServicios();
                CargarUltimoServicio();
            }
        }

        public void RefrescarRegistros()
        {
            if (_vistas.TryGetValue(TipoVista.Servicio, out var vistaServ))
                (vistaServ as ucServicio)?.RefrescarRegistros();

            ActualizarEstadisticas();
        }

        public void ActualizarEstadisticas()
        {
            int registrados = 0;
            if (_vistas.TryGetValue(TipoVista.Servicio, out var vistaServ))
                registrados = (vistaServ as ucServicio)?.CountRegistros() ?? 0;
            int.TryParse(mtxtProyeccion.Text, out int proyeccion);
            int.TryParse(mtxtInvitados.Text, out int invitados);

            _gestorEstadisticas.Actualizar(registrados, proyeccion, invitados);
        }

        #endregion



        #region Menú Lateral

        private void AplicarHover(Panel contenedor, Label etiqueta, bool hover)
        {
            if (contenedor == null || etiqueta == null) return;

            contenedor.BackColor = hover ? MenuHover : Color.Transparent;
            etiqueta.ForeColor = hover ? Color.Black : Color.Transparent;
            etiqueta.Cursor = Cursors.Hand;
        }

        private void Menu_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lblSender && lblSender.Parent is Panel p1)
                AplicarHover(p1, lblSender, true);
            else if (sender is Panel p2)
            {
                var lblChild = p2.Controls.OfType<Label>().FirstOrDefault();
                if (lblChild != null) AplicarHover(p2, lblChild, true);
            }
        }

        private void Menu_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lblSender && lblSender.Parent is Panel p1)
                AplicarHover(p1, lblSender, false);
            else if (sender is Panel p2)
            {
                var lblChild = p2.Controls.OfType<Label>().FirstOrDefault();
                if (lblChild != null) AplicarHover(p2, lblChild, false);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 210);
            MostrarVistaPrincipal();
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            if (MostrarVistaRegistroManual())
            {
                ssSidebar.Location = new System.Drawing.Point(9, 291);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (MostrarVistaReportes())
            {
                ssSidebar.Location = new System.Drawing.Point(9, 373);
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (MostrarVistaAdmin())
            {
                ssSidebar.Location = new System.Drawing.Point(9, 616);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (_idServicioActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia(ADVERTENCIA_FINALIZAR_ANTES_SALIR);
                return;
            }

            if (MensajesUI.MostrarConfirmacion(CONFIRMACION_SALIR_APLICACION))
            {
                Application.Exit();
            }
        }

        #endregion

        #region Eventos

        private void btnServicio_Click(object sender, EventArgs e)
        {
            ToggleServicio();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_idServicioActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia(ADVERTENCIA_FINALIZAR_ANTES_CERRAR);
                e.Cancel = true;
            }
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServicios.CurrentRow?.DataBoundItem is Servicio servicioSeleccionado)
            {
                try
                {
                    lblUlugar.Text = "Lugar: " + servicioSeleccionado.NombreLugar;
                    lblUfecha.Text = "Fecha: " + servicioSeleccionado.Fecha.ToString("dd/MM/yyyy");
                    lblUproyeccion.Text = "Proyección: " + (servicioSeleccionado.Proyeccion?.ToString() ?? "N/A");
                    lblUcomensales.Text = "Comensales: " + servicioSeleccionado.TotalComensales.ToString();
                    lblUinvitados.Text = "Invitados: " + servicioSeleccionado.TotalInvitados.ToString();
                    lblTotal.Text = "Total: " + servicioSeleccionado.TotalGeneral.ToString();
                    lblDuracion.Text = "Duración: " + (servicioSeleccionado.DuracionMinutos?.ToString() ?? "N/A") + " min";
                }
                catch (Exception ex)
                {
                    MensajesUI.MostrarError(string.Format(ERROR_CARGAR_SERVICIO, ex.Message));
                }
            }
        }

        #endregion
    }
}