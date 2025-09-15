using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Registro
    {
        public int IdRegistro { get; set; }

        public int IdEmpleado { get; set; }

        [DisplayName("Empleado")]
        public string NombreEmpleado { get; set; }

        public int IdEmpresa { get; set; }

        [DisplayName("Empresa")]
        public string NombreEmpresa { get; set; }

        public int IdServicio { get; set; }

        public int IdLugar { get; set; }

        [DisplayName("Lugar")]
        public string NombreLugar { get; set; }

        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }

        [DisplayName("Hora")]
        public TimeSpan Hora { get; set; }

        [DisplayName("Hora Formateada")]
        public string HoraFormateada
        {
            get { return Hora.ToString(@"hh\:mm"); }
        }

        // Método de negocio en la entidad
        public bool EsDelDiaActual()
        {
            return Fecha.Date == DateTime.Now.Date;
        }
    }
}