using System;

namespace Dominio
{
    public class AsistenciaPorEmpresa
    {
        public string Empresa { get; set; }
        public int TotalAsistencias { get; set; }
    }

    public class CoberturaVsProyeccion
    {
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int Proyeccion { get; set; }
        public int Atendidos { get; set; }
        public decimal? CoberturaPorcentaje { get; set; }
        public int Diferencia { get; set; }
    }

    public class DistribucionDiaSemana
    {
        public int Orden { get; set; }
        public string Dia { get; set; }
        public int Total { get; set; }
    }
}
