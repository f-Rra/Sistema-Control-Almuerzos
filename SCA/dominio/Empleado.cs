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
        public int id { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Apellido")]
        public string apellido { get; set; }

        [DisplayName("Credencial RFID")]
        public string idCredencial { get; set; }

        public int idEmpresa { get; set; }

        [DisplayName("Empresa")]
        public string nombreEmpresa { get; set; }

        [DisplayName("Estado")]
        public bool estado { get; set; }

        [DisplayName("Nombre Completo")]
        public string nombreCompleto
        {
            get { return $"{nombre} {apellido}"; }
        }

        // Método de negocio en la entidad
        public bool estaActivo()
        {
            return estado;
        }
    }
}