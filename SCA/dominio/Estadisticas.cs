using System;

namespace Dominio
{
    public class Estadisticas
    {
        public class Empleados
        {
            public int TotalRegistrados { get; set; }
            public int TotalActivos { get; set; }
            public int TotalInactivos { get; set; }
        }

        public class Empresas
        {
            public int TotalActivas { get; set; }
            public int TotalConEmpleados { get; set; }
            public decimal PromedioEmpleados { get; set; }
        }

        public class Servicios
        {
            public int ServiciosEsteMes { get; set; }
            public int ServiciosEsteAnio { get; set; }
            public int PromedioPorDia { get; set; }
        }

        public class Asistencias
        {
            public int AsistenciasTotales { get; set; }
            public int AsistenciasEmpleados { get; set; }
            public int AsistenciasInvitados { get; set; }
            public int PromedioDiario { get; set; }
            public decimal CoberturaPromedio { get; set; }
            public int DuracionPromedio { get; set; }
        }

        public class TopEmpresa
        {
            public long Ranking { get; set; }
            public string NombreEmpresa { get; set; }
            public int TotalAsistencias { get; set; }
            public decimal Porcentaje { get; set; }
        }
    }
}
