using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ReporteNegocio
    {
        public List<Servicio> ListarServiciosRango(DateTime fechaDesde, DateTime fechaHasta, int? idLugar = null)
        {
            try
            {
                var lista = new List<Servicio>();

                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarServiciosRango");
                    datos.setearParametro("@FechaDesde", fechaDesde);
                    datos.setearParametro("@FechaHasta", fechaHasta);
                    datos.setearParametro("@IdLugar", idLugar.HasValue ? (object)idLugar.Value : DBNull.Value);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        var s = new Servicio();
                        s.IdServicio = (int)datos.Lector["IdServicio"];
                        s.Fecha = (DateTime)datos.Lector["Fecha"];
                        if (!(datos.Lector["Proyeccion"] is DBNull)) s.Proyeccion = (int)datos.Lector["Proyeccion"];
                        if (!(datos.Lector["DuracionMinutos"] is DBNull)) s.DuracionMinutos = (int)datos.Lector["DuracionMinutos"];
                        s.TotalComensales = (int)datos.Lector["TotalComensales"];
                        s.TotalInvitados = (int)datos.Lector["TotalInvitados"];
                        s.NombreLugar = (string)datos.Lector["Lugar"];
                        lista.Add(s);
                    }
                    return lista;
                }
            }
            catch (SqlException ex)
            {
                throw NegocioException.FromDbException(ex, "listar servicios por rango");
            }
        }

        public List<AsistenciaPorEmpresa> AsistenciasPorEmpresas(DateTime fechaDesde, DateTime fechaHasta, int? idLugar = null)
        {
            try
            {
                var lista = new List<AsistenciaPorEmpresa>();

                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_AsistenciasPorEmpresas");
                    datos.setearParametro("@FechaDesde", fechaDesde);
                    datos.setearParametro("@FechaHasta", fechaHasta);
                    datos.setearParametro("@IdLugar", idLugar.HasValue ? (object)idLugar.Value : DBNull.Value);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        var item = new AsistenciaPorEmpresa
                        {
                            Empresa = (string)datos.Lector["Empresa"],
                            TotalAsistencias = (int)datos.Lector["TotalAsistencias"]
                        };
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (SqlException ex)
            {
                throw NegocioException.FromDbException(ex, "listar asistencias por empresas");
            }
        }

        public List<CoberturaVsProyeccion> ObtenerCoberturaVsProyeccion(DateTime fechaDesde, DateTime fechaHasta, int? idLugar = null)
        {
            try
            {
                var lista = new List<CoberturaVsProyeccion>();

                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ReporteCoberturaVsProyeccion");
                    datos.setearParametro("@FechaDesde", fechaDesde);
                    datos.setearParametro("@FechaHasta", fechaHasta);
                    datos.setearParametro("@IdLugar", idLugar.HasValue ? (object)idLugar.Value : DBNull.Value);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        var item = new CoberturaVsProyeccion
                        {
                            Fecha = (DateTime)datos.Lector["Fecha"],
                            Lugar = (string)datos.Lector["Lugar"],
                            Proyeccion = (int)datos.Lector["Proyeccion"],
                            Atendidos = (int)datos.Lector["Atendidos"],
                            CoberturaPorcentaje = datos.Lector["CoberturaPorcentaje"] is DBNull ? (decimal?)null : (decimal)datos.Lector["CoberturaPorcentaje"],
                            Diferencia = (int)datos.Lector["Diferencia"]
                        };
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (SqlException ex)
            {
                throw NegocioException.FromDbException(ex, "obtener cobertura vs proyección");
            }
        }

        public List<DistribucionDiaSemana> DistribucionPorDiaSemana(DateTime fechaDesde, DateTime fechaHasta, int? idLugar = null)
        {
            try
            {
                var lista = new List<DistribucionDiaSemana>();

                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_DistribucionPorDiaSemana");
                    datos.setearParametro("@FechaDesde", fechaDesde);
                    datos.setearParametro("@FechaHasta", fechaHasta);
                    datos.setearParametro("@IdLugar", idLugar.HasValue ? (object)idLugar.Value : DBNull.Value);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        var item = new DistribucionDiaSemana
                        {
                            Orden = (int)datos.Lector["Orden"],
                            Dia = (string)datos.Lector["Dia"],
                            Total = (int)datos.Lector["Total"]
                        };
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (SqlException ex)
            {
                throw NegocioException.FromDbException(ex, "obtener distribución por día de semana");
            }
        }
    }
}