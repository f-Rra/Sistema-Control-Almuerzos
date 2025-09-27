using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [DisplayName("Credencial RFID")]
        public string IdCredencial { get; set; }

        public int IdEmpresa { get; set; }

        [DisplayName("Empresa")]
        public string NombreEmpresa { get; set; }

        [DisplayName("Estado")]
        public bool Estado { get; set; }

        [DisplayName("Nombre Completo")]
        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
        }
        public bool EstaActivo()
        {
            return Estado;
        }
    }
}