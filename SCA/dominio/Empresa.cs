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

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Estado")]
        public bool Estado { get; set; }

        public bool EstaActiva()
        {
            return Estado;
        }
    }
}