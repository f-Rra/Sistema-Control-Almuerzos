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
    public partial class ucEstadisticas : UserControl
    {
        public ucEstadisticas()
        {
            InitializeComponent();
        }

        private void ucEstadisticas_Load(object sender, EventArgs e)
        {
            // TODO: Implementar lógica de estadísticas
        }

        // Método público para refrescar los datos desde otros UserControls
        public void RefrescarDatos()
        {
            // TODO: Implementar cuando se agregue lógica de estadísticas
        }
    }
}
