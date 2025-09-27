using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class ReporteNegocio
    {
        // 1) Lista de servicios (rango + lugar opcional)
        public List<Servicio> ListarServiciosRango(DateTime fechaDesde, DateTime fechaHasta, int? idLugar = null)
        {
            var lista = new List<Servicio>();
            var datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ListarServiciosRango");
                datos.setearParametro("@FechaDesde", fechaDesde);
                datos.setearParametro("@FechaHasta", fechaHasta);
                datos.setearParametro("@IdLugar", idLugar.HasValue ? (object)idLugar.Value : System.DBNull.Value);
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // 2) Asistencias por empresas (rango + lugar opcional)
        public List<dynamic> AsistenciasPorEmpresas(DateTime fechaDesde, DateTime fechaHasta, int? idLugar = null)
        {
            var lista = new List<dynamic>();
            var datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AsistenciasPorEmpresas");
                datos.setearParametro("@FechaDesde", fechaDesde);
                datos.setearParametro("@FechaHasta", fechaHasta);
                datos.setearParametro("@IdLugar", idLugar.HasValue ? (object)idLugar.Value : System.DBNull.Value);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var row = new
                    {
                        Empresa = (string)datos.Lector["Empresa"],
                        TotalAsistencias = (int)datos.Lector["TotalAsistencias"]
                    };
                    lista.Add(row);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // 3) Cobertura vs proyección (rango + lugar opcional)
        public List<dynamic> CoberturaVsProyeccion(DateTime fechaDesde, DateTime fechaHasta, int? idLugar = null)
        {
            var lista = new List<dynamic>();
            var datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ReporteCoberturaVsProyeccion");
                datos.setearParametro("@FechaDesde", fechaDesde);
                datos.setearParametro("@FechaHasta", fechaHasta);
                datos.setearParametro("@IdLugar", idLugar.HasValue ? (object)idLugar.Value : System.DBNull.Value);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var row = new
                    {
                        Fecha = (DateTime)datos.Lector["Fecha"],
                        Lugar = (string)datos.Lector["Lugar"],
                        Proyeccion = (int)datos.Lector["Proyeccion"],
                        Atendidos = (int)datos.Lector["Atendidos"],
                        CoberturaPorcentaje = datos.Lector["CoberturaPorcentaje"] is DBNull ? (decimal?)null : (decimal)datos.Lector["CoberturaPorcentaje"],
                        Diferencia = (int)datos.Lector["Diferencia"]
                    };
                    lista.Add(row);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // 4) Distribución por día de semana (rango + lugar opcional)
        public List<dynamic> DistribucionPorDiaSemana(DateTime fechaDesde, DateTime fechaHasta, int? idLugar = null)
        {
            var lista = new List<dynamic>();
            var datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_DistribucionPorDiaSemana");
                datos.setearParametro("@FechaDesde", fechaDesde);
                datos.setearParametro("@FechaHasta", fechaHasta);
                datos.setearParametro("@IdLugar", idLugar.HasValue ? (object)idLugar.Value : System.DBNull.Value);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var row = new
                    {
                        Orden = (int)datos.Lector["Orden"],
                        Dia = (string)datos.Lector["Dia"],
                        Total = (int)datos.Lector["Total"]
                    };
                    lista.Add(row);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}