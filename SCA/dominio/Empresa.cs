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
        public int id { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Estado")]
        public bool estado { get; set; }

        // Método de negocio en la entidad
        public bool estaActiva()
        {
            return estado;
        }
    }
}