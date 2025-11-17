using System;

namespace Dominio
{
    public class InfoBaseDatos
    {
        public string NombreBaseDatos { get; set; }
        public decimal TamañoMB { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }

    public class InfoRespaldo
    {
        public DateTime FechaRespaldo { get; set; }
        public string RutaArchivo { get; set; }
        public decimal TamañoMB { get; set; }
    }

    public class InfoAplicacion
    {
        public string Version { get; set; }
        public DateTime FechaCompilacion { get; set; }
        public string Framework { get; set; }
        public string UILibrary { get; set; }
    }
}
