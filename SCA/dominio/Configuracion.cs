using System;

namespace Dominio
{
    // Información de Base de Datos
    public class InfoBaseDatos
    {
        public string NombreBaseDatos { get; set; }
        public decimal TamañoMB { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }

    // Información de Respaldo
    public class InfoRespaldo
    {
        public DateTime FechaRespaldo { get; set; }
        public string RutaArchivo { get; set; }
        public decimal TamañoMB { get; set; }
    }

    // Información de la Aplicación
    public class InfoAplicacion
    {
        public string Version { get; set; }
        public DateTime FechaCompilacion { get; set; }
        public string Framework { get; set; }
        public string UILibrary { get; set; }
    }
}
