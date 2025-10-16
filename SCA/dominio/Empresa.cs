using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }

        [DisplayName("Empresa")]
        public string Nombre { get; set; }

        [DisplayName("Estado")]
        public bool Estado { get; set; }

        [DisplayName("Empleados")]
        public int CantidadEmpleados { get; set; }

        public bool EstaActiva()
        {
            return Estado;
        }
    }
}