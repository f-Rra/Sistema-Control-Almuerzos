using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Lugar
    {
        public int IdLugar { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Estado")]
        public bool Estado { get; set; }

        public bool EstaActivo()
        {
            return Estado;
        }
    }
}