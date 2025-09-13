using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Servicio
    {
        public int id { get; set; }

        public int idLugar { get; set; }

        [DisplayName("Lugar")]
        public string nombreLugar { get; set; }

        [DisplayName("Fecha")]
        public DateTime fecha { get; set; }

        [DisplayName("Total Comensales")]
        public int totalComensales { get; set; }

        [DisplayName("Total Invitados")]
        public int totalInvitados { get; set; }

        [DisplayName("Total General")]
        public int totalGeneral
        {
            get { return totalComensales + totalInvitados; }
        }

        [DisplayName("Estado")]
        public string estado
        {
            get { return totalComensales == 0 ? "Activo" : "Finalizado"; }
        }

        // Métodos de negocio en la entidad
        public bool estaActivo()
        {
            return totalComensales == 0;
        }

        public bool estaFinalizado()
        {
            return totalComensales > 0;
        }
    }
}