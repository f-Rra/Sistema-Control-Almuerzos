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
        private readonly EmpleadoNegocio negE = new EmpleadoNegocio();  
        private int? servicioIdActual = null;
        private int idLugarActual = 1;

        public event EventHandler RegistroRealizado;

        public ucVistaPrincipal()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }
        
        private void ConfigurarDataGridView()
        {
            // Permitir que las columnas se generen automáticamente
            dgvRegistros.AutoGenerateColumns = true;
            dgvRegistros.DataSource = registrosBinding;
        }

        private void BindRegistros(IList<Registro> registros)
        {
            if (registros == null)
                registros = new List<Registro>();

            registrosBinding.DataSource = null; 
            registrosBinding.DataSource = registros;
            dgvRegistros?.Refresh();
        }

        public void SetServicio(int? servicioId, int idLugar)
        {
            servicioIdActual = servicioId;
            idLugarActual = idLugar;
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
                
                // Asegurar que el DataGridView sea visible
                dgvRegistros.Visible = true;
                dgvRegistros.Refresh();
            }
            catch (Exception ex)
            {
                BindRegistros(new List<Registro>());
                OcultarColumnas();
                dgvRegistros.Visible = true;
                dgvRegistros.Refresh();
                
                // Solo mostrar el error si es crítico
                Console.WriteLine($"Error al cargar registros: {ex.Message}");
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

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (!servicioIdActual.HasValue)
            {
                MessageBox.Show("No hay un servicio activo", "Servicio Inactivo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string credencial = txtRegistro.Text.Trim();
            if (string.IsNullOrEmpty(credencial))
            {
                MessageBox.Show("Ingrese una credencial válida", "Credencial Requerida", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                Empleado empleado = negE.buscarPorCredencial(credencial);
                if (empleado == null)
                {
                    MessageBox.Show($"No se encontró un empleado con la credencial {credencial}", 
                        "Empleado No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Usar el IdEmpleado en lugar de convertir IdCredencial
                if (negR.empleadoYaRegistrado(empleado.IdEmpleado, servicioIdActual.Value))
                {
                    MessageBox.Show($"El empleado {empleado.NombreCompleto} ya está registrado en este servicio", 
                        "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                // Registrar usando IdEmpleado
                negR.registrarEmpleado(empleado.IdEmpleado, empleado.IdEmpresa, servicioIdActual.Value, idLugarActual);
                
                // Actualizar la vista
                CargarRegistros();
                txtRegistro.Clear();
                txtRegistro.Focus();
                
                // Disparar evento para actualizar estadísticas
                RegistroRealizado?.Invoke(this, EventArgs.Empty);
                
                MessageBox.Show($"Empleado {empleado.NombreCompleto} registrado correctamente", 
                    "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el registro: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
