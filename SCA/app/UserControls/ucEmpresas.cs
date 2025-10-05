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
    public partial class ucEmpresas : UserControl
    {
        private EmpresaNegocio empresaNegocio = new EmpresaNegocio();

        public ucEmpresas()
        {
            InitializeComponent();
        }

        private void ucEmpresas_Load(object sender, EventArgs e)
        {
            // TODO: Implementar lógica de carga de empresas
            CargarEmpresas();
        }

        private void CargarEmpresas()
        {
            // TODO: Implementar carga de empresas en DataGridView
            var empresas = empresaNegocio.listar();
            if (empresas == null) return;

            // Aquí iría la lógica para mostrar las empresas
        }
    }
}
