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
        public int IdServicio { get; set; }

        public int IdLugar { get; set; }

        [DisplayName("Lugar")]
        public string NombreLugar { get; set; }

        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }

    [DisplayName("Proyección")]
    public int? Proyeccion { get; set; }

    [DisplayName("Duración (min)")]
    public int? DuracionMinutos { get; set; }

        [DisplayName("Total Comensales")]
        public int TotalComensales { get; set; }

        [DisplayName("Total Invitados")]
        public int TotalInvitados { get; set; }

        [DisplayName("Total General")]
        public int TotalGeneral
        {
            get { return TotalComensales + TotalInvitados; }
        }

        [DisplayName("Estado")]
        public string Estado
        {
            get { return TotalComensales == 0 ? "Activo" : "Finalizado"; }
        }

        public bool EstaActivo()
        {
            return TotalComensales == 0;
        }

        public bool EstaFinalizado()
        {
            return TotalComensales > 0;
        }
    }
}