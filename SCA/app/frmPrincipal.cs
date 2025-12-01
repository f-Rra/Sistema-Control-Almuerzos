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
using System;
using app.Helpers;

namespace app
{
    public partial class frmPrincipal : Form
    {
        #region Variables y Constantes

        private readonly Color MenuHover = Color.FromArgb(243, 229, 201);
        private readonly Timer tmrCrono = new Timer { Interval = 1000 };
        private readonly Stopwatch crono = new Stopwatch();
        private int duracionMinutos = 0;
        private LugarNegocio negL = new LugarNegocio();
        private ServicioNegocio negS = new ServicioNegocio();
        private ucVistaPrincipal vistaPrincipal;
        private ucRegistroManual vistaRegManual;
        private ucReportes vistaReportes;
        private ucAdmin vistaAdmin;
        private int? idServicioActual = null;

        #endregion

        #region Constructor e Inicialización

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            negS.FinalizarServiciosPendientes();
            CargarLugares();
            CargarFecha();
            IniciarCronometro();
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

                int idLugar = (int)cbLugar.SelectedValue;
                
                CrearServicioEnBD(idLugar, proyeccion);
                
                ActualizarCronometro();
                ActualizarControles();
                
                vistaPrincipal.SetServicio(idServicioActual, idLugar);
                ActualizarEstadisticas();
            }
            catch (NegocioException ex)
            {
                MensajesUI.ManejarExcepcion(ex);
            }
        }

        private void FinalizarServicio()
        {
            if (!MensajesUI.MostrarConfirmacion("¿Está seguro de finalizar el servicio? Esta acción guardará todas las estadísticas."))
            {
                return;
            }

            DetenerCronometro();

            try
            {
                GuardarEstadisticasEnBD();
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
            if (crono.IsRunning)
                FinalizarServicio();
            else
                IniciarServicio();
        }

        private bool ValidarLugar()
        {
            if (cbLugar.SelectedValue == null)
            {
                MensajesUI.MostrarAdvertencia("Seleccione un lugar");
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
                MensajesUI.MostrarAdvertencia("Ingrese una proyección de comensales");
                return false;
            }

            if (!int.TryParse(proyText, out proyeccion))
            {
                MensajesUI.MostrarAdvertencia("Ingrese una proyección válida (solo números)");
                return false;
            }
            
            if (proyeccion < 0 || proyeccion > 1000)
            {
                MensajesUI.MostrarAdvertencia("La proyección debe estar entre 0 y 1000 comensales");
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
                MensajesUI.MostrarAdvertencia("Ingrese un número válido de invitados");
                return false;
            }
            
            if (invitados < 0 || invitados > 500)
            {
                MensajesUI.MostrarAdvertencia("Los invitados deben estar entre 0 y 500");
                return false;
            }
            
            return true;
        }

        private void CrearServicioEnBD(int idLugar, int proy)
        {
            int nuevoId = negS.CrearServicio(idLugar, proy);
            idServicioActual = nuevoId;
        }

        private void ActualizarCronometro()
        {
            duracionMinutos = 0;
            crono.Reset();
            crono.Start();
            tmrCrono.Start();
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
            gbxServicios.Visible = false;
            gbxUltimo.Visible = false;
            CargarVistaPrincipal();
            MostrarVistaPrincipal();
        }

        private void DetenerCronometro()
        {
            tmrCrono.Stop();
            crono.Stop();
            ActualizarCronometroUI();
            duracionMinutos = (int)Math.Ceiling(crono.Elapsed.TotalMinutes);
            btnServicio.Text = "Iniciar Servicio";
        }

        private void GuardarEstadisticasEnBD()
        {
            if (idServicioActual.HasValue)
            {
                int totalComensales = vistaPrincipal?.CountRegistros() ?? 0;
                int totalInvitados = 0;
                int.TryParse(mtxtInvitados.Text, out totalInvitados);

                negS.FinalizarServicio(idServicioActual.Value, totalComensales, totalInvitados, duracionMinutos);
                ActualizarEstadisticas();
            }
        }

        private void ResetearControles()
        {
            cbLugar.Enabled = true;
            mtxtProyeccion.ReadOnly = false;
            mtxtInvitados.ReadOnly = false;
            idServicioActual = null;
            mtxtProyeccion.Text = string.Empty;
            mtxtInvitados.Text = string.Empty;
            crono.Reset();
            lblCronometro.Text = "00:00:00";
            lblEstadisticas.Text = "Registrados: 0 │ Faltan: 0";
            lblProgreso.Text = "0%";
            SetEstadoServicio(false);
            btnReportes.Enabled = true;
            btnAdmin.Enabled = true;
            btnRegistros.Enabled = true;
            btnHome.Enabled = true;
            OcultarTodasLasVistas();
            CargarServicios();
            CargarUltimoServicio();
            gbxServicios.Visible = true;
            gbxUltimo.Visible = true;
            gbxServicios.BringToFront();
            gbxUltimo.BringToFront();
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
                var lista = negS.ListarTodos();
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
            var cols = dgvServicios?.Columns;
            if (cols == null) return;

            string[] aOcultar = { "IdServicio", "IdLugar", "Estado", "Proyeccion", "DuracionMinutos" };
            foreach (var nombre in aOcultar)
            {
                var col = cols[nombre];
                if (col != null) col.Visible = false;
            }
        }

        private void RenombrarColumnasServicios()
        {
            var cols = dgvServicios?.Columns;
            if (cols == null) return;

            if (cols["TotalComensales"] != null)
                cols["TotalComensales"].HeaderText = "Comensales";
            if (cols["TotalInvitados"] != null)
                cols["TotalInvitados"].HeaderText = "Invitados";
            if (cols["TotalGeneral"] != null)
                cols["TotalGeneral"].HeaderText = "Total";
        }

        private void CargarUltimoServicio()
        {
            try
            {
                Servicio ultimo = negS.ObtenerUltimoServicio();
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
            cbLugar.DataSource = negL.Listar();
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

     
        private void CargarVistaPrincipal()
        {
            if (idServicioActual == null)
            {
                OcultarTodasLasVistas();
                CargarServicios();
                CargarUltimoServicio();
            }
            else
            {
                gbxServicios.Visible = false;
                gbxUltimo.Visible = false;

                if (vistaPrincipal == null)
                    vistaPrincipal = new ucVistaPrincipal(this);

                if (vistaPrincipal.Parent != pnlPrincipal)
                {
                    vistaPrincipal.Dock = DockStyle.Fill;
                    vistaPrincipal.Visible = false;
                    pnlPrincipal.Controls.Add(vistaPrincipal);
                }
            }
        }

        private void CargarVistaRegistroManual()
        {
            if (vistaRegManual == null)
                vistaRegManual = new ucRegistroManual(this);

            if (vistaRegManual.Parent != pnlPrincipal)
            {
                vistaRegManual.Dock = DockStyle.Fill;
                vistaRegManual.Visible = false;
                pnlPrincipal.Controls.Add(vistaRegManual);
            }
        }

        private void CargarVistaReportes()
        {
            if (vistaReportes == null)
                vistaReportes = new ucReportes();

            if (vistaReportes.Parent != pnlPrincipal)
            {
                vistaReportes.Dock = DockStyle.Fill;
                vistaReportes.Visible = false;
                pnlPrincipal.Controls.Add(vistaReportes);
            }
        }

        private void CargarVistaAdmin()
        {
            if (vistaAdmin == null)
                vistaAdmin = new ucAdmin();

            if (vistaAdmin.Parent != pnlPrincipal)
            {
                vistaAdmin.Dock = DockStyle.Fill;
                vistaAdmin.Visible = false;
                pnlPrincipal.Controls.Add(vistaAdmin);
            }
        }

        private void MostrarVista(UserControl vista)
        {
            if (vista == null) return;

            pnlPrincipal.SuspendLayout();

            foreach (Control c in pnlPrincipal.Controls)
                c.Visible = false;

            vista.Visible = true;
            vista.BringToFront();

            pnlPrincipal.ResumeLayout();
        }

        private void OcultarTodasLasVistas()
        {
            pnlPrincipal.SuspendLayout();

            foreach (Control c in pnlPrincipal.Controls)
                c.Visible = false;

            gbxServicios.Visible = false;
            gbxUltimo.Visible = false;

            pnlPrincipal.ResumeLayout();
        }

        private void MostrarVistaPrincipal()
        {
            CargarVistaPrincipal();
            pnlSuperior.Visible = true;

            if (idServicioActual.HasValue && vistaPrincipal != null)
            {
                MostrarVista(vistaPrincipal);
            }
            else
            {
                OcultarTodasLasVistas();
                gbxServicios.Visible = true;
                gbxUltimo.Visible = true;
                gbxServicios.BringToFront();
                gbxUltimo.BringToFront();
            }
        }

        private bool MostrarVistaRegistroManual()
        {
            if (!idServicioActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia("El servicio no está activo");
                return false;
            }

            CargarVistaRegistroManual();
            vistaRegManual.RefrescarDatos();

            if (cbLugar.SelectedValue is int idLugar)
            {
                vistaRegManual.SetServicio(idServicioActual.Value, idLugar);
            }

            pnlSuperior.Visible = true;
            MostrarVista(vistaRegManual);
            return true;
        }

        private bool MostrarVistaReportes()
        {
            if (idServicioActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia("Reportes está disponible sólo con el servicio inactivo");
                return false;
            }

            CargarVistaReportes();
            vistaReportes.RefrescarDatos();
            pnlSuperior.Visible = false;
            MostrarVista(vistaReportes);
            return true;
        }

        private bool MostrarVistaAdmin()
        {
            if (idServicioActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia("Admin está disponible sólo con el servicio inactivo");
                return false;
            }

            CargarVistaAdmin();
            pnlSuperior.Visible = false;
            MostrarVista(vistaAdmin);
            return true;
        }

        #endregion

        #region Actualizaciones

        public void RefrescarTodasLasVistas()
        {
            CargarLugares();
            vistaRegManual?.RefrescarDatos();
            vistaReportes?.RefrescarDatos();

            if (gbxServicios.Visible || gbxUltimo.Visible)
            {
                ActualizarEstadisticas();
                CargarServicios();
                CargarUltimoServicio();
            }
        }

        public void RefrescarRegistros()
        {
            vistaPrincipal?.RefrescarRegistros();
            ActualizarEstadisticas();
        }

        public void ActualizarEstadisticas()
        {
            int registrados = vistaPrincipal?.CountRegistros() ?? 0;

            int.TryParse(mtxtProyeccion.Text, out int proyeccion);
            int.TryParse(mtxtInvitados.Text, out int invitados);

            int objetivo = proyeccion + invitados;
            int faltan = Math.Max(0, objetivo - registrados);

            int porcentaje = objetivo > 0 ? Math.Min(100, (registrados * 100) / objetivo) :
                             registrados > 0 ? 100 : 0;

            pbProgreso.Value = porcentaje;
            lblProgreso.Text = $"{porcentaje}%";
            lblEstadisticas.Text = $"Registrados: {registrados} │ Faltan: {faltan}";
        }

        #endregion

        #region Cronómetro

        private void IniciarCronometro()
        {
            lblCronometro.Text = "00:00:00";
            tmrCrono.Tick += (s, ev) => { ActualizarCronometroUI(); };
        }

        private void ActualizarCronometroUI()
        {
            lblCronometro.Text = crono.Elapsed.ToString(@"hh\:mm\:ss");
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
            if (idServicioActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia("Debe finalizar el servicio activo antes de salir de la aplicación.");
                return;
            }

            if (MensajesUI.MostrarConfirmacion("¿Está seguro de salir de la aplicación?"))
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
            if (idServicioActual.HasValue)
            {
                MensajesUI.MostrarAdvertencia("Debe finalizar el servicio activo antes de cerrar la aplicación.");
                e.Cancel = true;
            }
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServicios.CurrentRow != null && dgvServicios.CurrentRow.DataBoundItem != null)
            {
                try
                {
                    Servicio servicioSeleccionado = (Servicio)dgvServicios.CurrentRow.DataBoundItem;
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
                    MensajesUI.MostrarError($"Error al cargar servicio seleccionado: {ex.Message}");
                }
            }
        }

        #endregion
    }
}