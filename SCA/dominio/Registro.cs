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
        public int id { get; set; }

        public int idEmpleado { get; set; }

        [DisplayName("Empleado")]
        public string nombreEmpleado { get; set; }

        public int idEmpresa { get; set; }

        [DisplayName("Empresa")]
        public string nombreEmpresa { get; set; }

        public int idServicio { get; set; }

        public int idLugar { get; set; }

        [DisplayName("Lugar")]
        public string nombreLugar { get; set; }

        [DisplayName("Fecha")]
        public DateTime fecha { get; set; }

        [DisplayName("Hora")]
        public TimeSpan hora { get; set; }

        [DisplayName("Hora Formateada")]
        public string horaFormateada
        {
            get { return hora.ToString(@"hh\:mm"); }
        }

        // Método de negocio en la entidad
        public bool esDelDiaActual()
        {
            return fecha.Date == DateTime.Now.Date;
        }
    }
}