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
    private readonly RegistroNegocio negR = new RegistroNegocio();
    private int? servicioIdActual = null;

        public ucVistaPrincipal()
        {
            InitializeComponent();
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
