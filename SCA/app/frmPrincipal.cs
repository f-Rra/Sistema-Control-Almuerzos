using Negocio;
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
        private LugarNegocio negL = new LugarNegocio();
        private ServicioNegocio negS = new ServicioNegocio();
        private ucVistaPrincipal vistaPrincipal;
        private readonly Stopwatch crono = new Stopwatch();
        private readonly Timer tmrCrono = new Timer { Interval = 1000 };
        private int duracionMinutos = 0;
        private int? idServicioActual = null;

        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarVistaPrincipal();
            vistaPrincipal?.SetServicio(idServicioActual);
            CargarLugares();
            CargarFecha();
            IniciarCronometro();
            ActualizarEstadisticas();
        }

        private void CargarVistaPrincipal()
        {
            var contenedor = this.Controls.Find("pnlPrincipal", true).FirstOrDefault() as Control ?? this;
            if (vistaPrincipal != null && contenedor.Controls.Contains(vistaPrincipal))
                contenedor.Controls.Remove(vistaPrincipal);
        vistaPrincipal = new ucVistaPrincipal();
                vistaPrincipal.Dock = DockStyle.Fill;
                vistaPrincipal.Visible = true;
                contenedor.Controls.Add(vistaPrincipal);
                vistaPrincipal.BringToFront();
        }


        private void MostrarVistaPrincipal()
        {
            var contenedor = this.Controls.Find("pnlPrincipal", true).FirstOrDefault() as Control ?? this;
            if (vistaPrincipal == null || !contenedor.Controls.Contains(vistaPrincipal))
            {
                CargarVistaPrincipal();
            }
            else
            {
                vistaPrincipal.BringToFront();
            }
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

        private void IniciarServicio()
        {
            duracionMinutos = 0;
            crono.Reset();
            crono.Start();
            tmrCrono.Start();
            btnServicio.Text = "Finalizar Servicio";
            try
            {
                if (cbLugar.SelectedValue == null)
                {
                    MessageBox.Show("Seleccioná un lugar.");
                    return;
                }
                int idLugar = (int)cbLugar.SelectedValue;
                int proy = 0;
                int? proyeccion = int.TryParse(mtxtProyeccion.Text, out proy) ? (int?)proy : null;
                int nuevoId = negS.crearServicio(idLugar, proyeccion);
                idServicioActual = nuevoId;
                cbLugar.Enabled = false;
                mtxtProyeccion.ReadOnly = true;
                mtxtInvitados.ReadOnly = true;
                vistaPrincipal?.SetServicio(idServicioActual);
                ActualizarEstadisticas();
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
                vistaPrincipal?.SetServicio(idServicioActual);
                mtxtProyeccion.Text = string.Empty;
                mtxtInvitados.Text = string.Empty;
                crono.Reset();
                lblCronometro.Text = "00:00:00";
                ActualizarEstadisticas();
            }
        }
        private void ActualizarEstadisticas()
        {
            try
            {
                int registrados = vistaPrincipal?.CountRegistros() ?? 0;
                int proyeccion = 0; int invitados = 0;
                int.TryParse(mtxtProyeccion.Text, out proyeccion);
                int.TryParse(mtxtInvitados.Text, out invitados);

                int objetivo = Math.Max(0, proyeccion + invitados);
                int faltan = Math.Max(0, objetivo - registrados);
                int porcentaje = 0;
                if (objetivo > 0)
                {
                    porcentaje = (int)Math.Round((registrados * 100.0) / objetivo);
                    if (porcentaje > 100) porcentaje = 100;
                    if (porcentaje < 0) porcentaje = 0;
                }
                else if (registrados > 0)
                {
                    porcentaje = 100;
                }
                try
                {
                    if (pbProgreso.Maximum != 100) pbProgreso.Maximum = 100;
                    if (pbProgreso.Minimum != 0) pbProgreso.Minimum = 0;
                    pbProgreso.Value = Math.Max(pbProgreso.Minimum, Math.Min(pbProgreso.Maximum, porcentaje));
                }
                catch {}
                lblProgreso.Text = porcentaje.ToString() + "%";
                lblEstadisticas.Text = $"Registrados: {registrados} │ Faltan: {faltan}";
            }
            catch {}
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
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 368);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ssSidebar.Location = new System.Drawing.Point(9, 538);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            ToggleServicio();
            ActulizarEstadoServicio();
        }

        

    }
}
