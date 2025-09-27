using Negocio;
using Dominio;  
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.UserControls;
 


/*("#fdf39d"),Dorado claro
  ("#ffd024"),Dorado oscuro
  ("#FFF8E1"),Crema
  ("#232221"),Negro*/


namespace app
{
    public partial class frmPrincipal : Form
    {
        private readonly Color MenuBase = Color.FromArgb(35, 34, 33);
        private readonly Color MenuHover = Color.FromArgb(243, 229, 201);
        private readonly Stopwatch crono = new Stopwatch();
        private readonly Timer tmrCrono = new Timer { Interval = 1000 };
        private LugarNegocio negL = new LugarNegocio();
        private ServicioNegocio negS = new ServicioNegocio();
        private ucVistaPrincipal vistaPrincipal;
        private ucRegistroManual vistaRegManual;
        private ucReportes vistaReportes;
        private ucAdmin vistaAdmin;
        private int duracionMinutos = 0;
        private int? idServicioActual = null;

        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarLugares();
            CargarFecha();
            IniciarCronometro();
            ActualizarEstadisticas();
            CargarUltimoServicio();
        }

        private void CargarUltimoServicio()
        {
            try
            {
                Servicio ultimo = negS.obtenerUltimoServicio();
                if (ultimo != null)
                {
                    // Limpiar los textos previos y cargar nuevos datos
                    lblUlugar.Text = "Lugar: " + ultimo.NombreLugar;
                    lblUfecha.Text = "Fecha: " + ultimo.Fecha.ToString("dd/MM/yyyy");
                    lblUproyeccion.Text = "Proyección: " + (ultimo.Proyeccion?.ToString() ?? "N/A");
                    lblUcomensales.Text = "Comensales: " + ultimo.TotalComensales.ToString();
                    lblUinvitados.Text = "Invitados: " + ultimo.TotalInvitados.ToString();
                }
                
                // Ocultar todos los UserControls del panel principal
                OcultarTodasLasVistas();
                
                // Hacer visible y traer al frente el GroupBox del último servicio
                gbxUltimo.Visible = true;
                gbxUltimo.BringToFront();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("No se pudo cargar el último servicio: " + ex.Message);
            }
        }

        private void CargarVistaPrincipal()
        {
            if (vistaPrincipal == null)
                vistaPrincipal = new ucVistaPrincipal(this);
            if (vistaPrincipal.Parent != pnlPrincipal)
            {
                vistaPrincipal.Dock = DockStyle.Fill;
                vistaPrincipal.Visible = false;
                pnlPrincipal.Controls.Add(vistaPrincipal);
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

            pnlPrincipal.ResumeLayout();
        }

        private void MostrarVistaPrincipal()
        {
            CargarVistaPrincipal();
            MostrarVista(vistaPrincipal);
        }

        private void MostrarVistaRegistroManual()
        {
            if (!idServicioActual.HasValue)
            {
                MessageBox.Show("El servicio no está activo.");
                return;
            }

            CargarVistaRegistroManual();
            if (cbLugar.SelectedValue is int idLugar)
            {
                vistaRegManual.SetServicio(idServicioActual.Value, idLugar);
            }
            MostrarVista(vistaRegManual);
        }

        private void MostrarVistaReportes()
        {
            if (idServicioActual.HasValue)
            {
                MessageBox.Show("Reportes está disponible sólo con el servicio inactivo.");
                return;
            }

            CargarVistaReportes();
            MostrarVista(vistaReportes);
        }

        private void MostrarVistaAdmin()
        {
            if (idServicioActual.HasValue)
            {
                MessageBox.Show("Admin está disponible sólo con el servicio inactivo.");
                return;
            }

            CargarVistaAdmin();
            MostrarVista(vistaAdmin);
        }

        private void CargarLugares()
        {
            cbLugar.DataSource = negL.listar();
            cbLugar.ValueMember = "IdLugar";
            cbLugar.DisplayMember = "Nombre";
        }

        private void CargarFecha()
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFecha.ReadOnly = true;    
            txtFecha.TabStop = false; 
        }
        private void IniciarCronometro()
        {
            lblCronometro.Text = "00:00:00";
            tmrCrono.Tick += (s, ev) => { ActualizarCronometroUI(); };
        }

        private void ActualizarCronometroUI()
        {
            lblCronometro.Text = crono.Elapsed.ToString(@"hh\:mm\:ss");
        }

        private void ActulizarEstadoServicio()
        {
            if (lblEstado.Text == "INACTIVO")
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

        private void IniciarServicio()
        {
            try
            {
                if (cbLugar.SelectedValue == null)
                {
                    MessageBox.Show("Seleccioná un lugar");
                    return;
                }

                string proyText = mtxtProyeccion.Text.Trim();
                if (string.IsNullOrEmpty(proyText))
                {
                    MessageBox.Show("Ingresá una proyección de comensales");
                    return;
                }

                if (!int.TryParse(proyText, out int proy))
                {
                    MessageBox.Show("Ingresá una proyección válida (solo números)");
                    return;
                }

                int idLugar = (int)cbLugar.SelectedValue;

                int nuevoId = negS.crearServicio(idLugar, proy);
                idServicioActual = nuevoId;
                duracionMinutos = 0;
                crono.Reset();
                crono.Start();
                tmrCrono.Start();
                btnServicio.Text = "Finalizar Servicio";

                cbLugar.Enabled = false;
                mtxtProyeccion.ReadOnly = true;
                mtxtInvitados.ReadOnly = true; 

                CargarVistaPrincipal();
                MostrarVistaPrincipal();
                vistaPrincipal.SetServicio(idServicioActual, idLugar);
                ActualizarEstadisticas();

                SetEstadoServicio(true);

                btnReportes.Enabled = false;
                btnAdmin.Enabled = false;
                btnRegistros.Enabled = true;
                btnHome.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo iniciar el servicio: " + ex.Message);
            }
        }

        private void FinalizarServicio()
        {
            tmrCrono.Stop();
            crono.Stop();
            ActualizarCronometroUI();
            duracionMinutos = (int)Math.Ceiling(crono.Elapsed.TotalMinutes);
            btnServicio.Text = "Iniciar Servicio";
            try
            {
                if (idServicioActual.HasValue)
                {
                    int totalComensales = vistaPrincipal?.CountRegistros() ?? 0;
                    int totalInvitados = 0;
                    int.TryParse(mtxtInvitados.Text, out totalInvitados);

                    negS.finalizarServicio(idServicioActual.Value, totalComensales, totalInvitados, duracionMinutos);
                    ActualizarEstadisticas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo finalizar el servicio: " + ex.Message);
            }
            finally
            {
                cbLugar.Enabled = true;
                mtxtProyeccion.ReadOnly = false;
                mtxtInvitados.ReadOnly = false;
                idServicioActual = null;
                mtxtProyeccion.Text = string.Empty;
                mtxtInvitados.Text = string.Empty;
                crono.Reset();
                lblCronometro.Text = "00:00:00";
                ActualizarEstadisticas();
                SetEstadoServicio(false);
                btnReportes.Enabled = true;
                btnAdmin.Enabled = true;
                btnRegistros.Enabled = true;
                btnHome.Enabled = true;
                CargarUltimoServicio(); 
            }
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

        public void RefrescarRegistros()
        {
            vistaPrincipal?.RefrescarRegistros();
            // Actualizar estadísticas después de refrescar los registros
            ActualizarEstadisticas();
        }

        private void ToggleServicio()
        {
            if (crono.IsRunning)
                FinalizarServicio();
            else
                IniciarServicio();
        }

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
            ssSidebar.Location = new System.Drawing.Point(9, 205);
            MostrarVistaPrincipal();
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 286);
            MostrarVistaRegistroManual();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 368);
            MostrarVistaReportes();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 538);
            MostrarVistaAdmin();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            ToggleServicio();
        }
    }
}
