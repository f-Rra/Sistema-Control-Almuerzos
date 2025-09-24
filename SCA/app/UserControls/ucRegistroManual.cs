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
    public partial class ucRegistroManual : UserControl
    {
        private readonly EmpleadoNegocio negE = new EmpleadoNegocio();
        private int? servicioIdActual;
        private int idLugarActual;

        public ucRegistroManual()
        {
            InitializeComponent();
        }

        public void SetServicio(int servicioId, int idLugar)
        {
            servicioIdActual = servicioId;
            idLugarActual = idLugar;
            CargarRegistros();
        }

        public int CountRegistros()
        {
            return dgvFaltantes?.Rows?.Count ?? 0;
        }

        private void CargarRegistros()
        {
            dgvFaltantes.DataSource = null;

            if (servicioIdActual.HasValue)
            {
                dgvFaltantes.DataSource = negE.empleadosSinAlmorzar(servicioIdActual.Value);
            }
            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            var cols = dgvFaltantes?.Columns;
            if (cols == null) return;

            // Ocultar columnas que no queremos mostrar en esta vista
            string[] aOcultar = { "IdEmpleado", "IdEmpresa", "Estado", "Nombre", "Apellido" };
            foreach (var nombre in aOcultar)
            {
                var col = cols[nombre];
                if (col != null) col.Visible = false;
            }
            // Asegurar visibles las que sí queremos mostrar (Credencial, Nombre+Apellido y Empresa)
            string[] aMostrar = { "IdCredencial", "NombreCompleto", "NombreEmpresa" };
            foreach (var nombre in aMostrar)
            {
                var col = cols[nombre];
                if (col != null) col.Visible = true;
            }

            // Ordenar: Credencial (izquierda), luego NombreCompleto, luego Empresa
            string[] orden = { "IdCredencial", "NombreCompleto", "NombreEmpresa" };
            int idx = 0;
            foreach (var nombre in orden)
            {
                var col = cols[nombre];
                if (col != null) col.DisplayIndex = idx++;
            }
        }
    }
}
