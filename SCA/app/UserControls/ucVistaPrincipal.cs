using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace app.UserControls
{
    public partial class ucVistaPrincipal : UserControl
    {
    private readonly BindingSource registrosBinding = new BindingSource();
    private readonly RegistroNegocio negR = new RegistroNegocio();
    private int? servicioIdActual = null;

        public ucVistaPrincipal()
        {
            InitializeComponent();
            ConfigurarGrilla();
        }

        private void ConfigurarGrilla()
        {
            if (dgvRegistros == null) return;
            var colorCrema = Color.FromArgb(255, 248, 225);     // #FFF8E1
            var colorNegro = Color.FromArgb(35, 34, 33);         // #232221
            var colorDoradoOsc = Color.FromArgb(255, 208, 36);   // #ffd024
            var colorDoradoClaro = Color.FromArgb(253, 243, 157);// #fdf39d
            var colorHover = Color.FromArgb(243, 229, 201);      // similar a MenuHover

            this.BackColor = colorCrema;

            dgvRegistros.AutoGenerateColumns = true;
            dgvRegistros.ReadOnly = true;
            dgvRegistros.AllowUserToAddRows = false;
            dgvRegistros.AllowUserToDeleteRows = false;
            dgvRegistros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistros.MultiSelect = false;
            dgvRegistros.RowHeadersVisible = false;
            dgvRegistros.DataSource = registrosBinding;

            dgvRegistros.Dock = DockStyle.None;
            dgvRegistros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            dgvRegistros.BackgroundColor = colorCrema;
            dgvRegistros.BorderStyle = BorderStyle.None;
            dgvRegistros.GridColor = colorNegro;
            dgvRegistros.EnableHeadersVisualStyles = false;
            dgvRegistros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRegistros.ColumnHeadersDefaultCellStyle.BackColor = colorNegro;
            dgvRegistros.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRegistros.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorNegro;
            dgvRegistros.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvRegistros.ColumnHeadersHeight = 28;
            dgvRegistros.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            dgvRegistros.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRegistros.DefaultCellStyle.BackColor = colorCrema;
            dgvRegistros.DefaultCellStyle.ForeColor = Color.Black;
            dgvRegistros.DefaultCellStyle.SelectionBackColor = colorDoradoOsc;
            dgvRegistros.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvRegistros.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            dgvRegistros.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistros.AlternatingRowsDefaultCellStyle.BackColor = colorHover;
        }

        private void BindRegistros(IList<Registro> registros)
        {
            if (registros == null)
                registros = new List<Registro>();

            registrosBinding.DataSource = null; 
            registrosBinding.DataSource = registros;
            dgvRegistros?.Refresh();
        }

        public void SetServicio(int? servicioId)
        {
            servicioIdActual = servicioId;
            CargarRegistros();
        }

        public int CountRegistros()
        {
            return registrosBinding?.Count ?? 0;
        }

        private void CargarRegistros()
        {
            try
            {
                IList<Registro> regs = (servicioIdActual.HasValue)
                    ? negR.listarPorServicio(servicioIdActual.Value)
                    : new List<Registro>();

                BindRegistros(regs);
                OcultarColumnas();
            }
            catch
            {
                BindRegistros(new List<Registro>());
                OcultarColumnas();
            }
        }

        private void OcultarColumnas()
        {
           if (dgvRegistros?.Columns == null) return;

           var c = dgvRegistros.Columns["IdRegistro"]; if (c != null) c.Visible = false;
           c = dgvRegistros.Columns["IdEmpleado"]; if (c != null) c.Visible = false;
           c = dgvRegistros.Columns["IdEmpresa"]; if (c != null) c.Visible = false;
           c = dgvRegistros.Columns["IdServicio"]; if (c != null) c.Visible = false;
           c = dgvRegistros.Columns["IdLugar"]; if (c != null) c.Visible = false;
           c = dgvRegistros.Columns["Hora"]; if (c != null) c.Visible = false;
        }
    }
}
