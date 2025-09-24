using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.UserControls
{
    public partial class ucRegistroManual : UserControl
    {
        private int? servicioIdActual;
        private int idLugarActual;

        public ucRegistroManual()
        {
            InitializeComponent();
        }

        // Recibe el contexto del servicio activo y el lugar seleccionado
        public void SetServicio(int servicioId, int idLugar)
        {
            servicioIdActual = servicioId;
            idLugarActual = idLugar;

            // TODO: si este UC necesita cargar datos en base al servicio/lugar,
            // hacelo acá (e.g., CargarEmpleadosSinAlmorzar(servicioIdActual.Value, idLugarActual)).
        }
    }
}
