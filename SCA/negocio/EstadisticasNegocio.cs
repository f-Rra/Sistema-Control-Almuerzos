using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class EstadisticasNegocio
    {
        public dynamic ObtenerEstadisticasEmpleados()
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                var datos = new AccesoDatos();
                try
                {
                    datos.setearProcedimiento("sp_ObtenerEstadisticasEmpleados");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return new
                        {
                            TotalRegistrados = (int)datos.Lector["TotalRegistrados"],
                            TotalActivos = (int)datos.Lector["TotalActivos"],
                            TotalInactivos = (int)datos.Lector["TotalInactivos"]
                        };
                    }
                    return null;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "obtener estadísticas de empleados");
        }

        public dynamic ObtenerEstadisticasEmpresas()
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                var datos = new AccesoDatos();
                try
                {
                    datos.setearProcedimiento("sp_ObtenerEstadisticasEmpresas");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return new
                        {
                            TotalActivas = (int)datos.Lector["TotalActivas"],
                            TotalConEmpleados = (int)datos.Lector["TotalConEmpleados"],
                            PromedioEmpleados = (decimal)datos.Lector["PromedioEmpleados"]
                        };
                    }
                    return null;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "obtener estadísticas de empresas");
        }

        public dynamic ObtenerEstadisticasServicios()
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                var datos = new AccesoDatos();
                try
                {
                    datos.setearProcedimiento("sp_ObtenerEstadisticasServicios");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return new
                        {
                            ServiciosEsteMes = (int)datos.Lector["ServiciosEsteMes"],
                            ServiciosEsteAnio = (int)datos.Lector["ServiciosEsteAnio"],
                            PromedioPorDia = (int)datos.Lector["PromedioPorDia"]
                        };
                    }
                    return null;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "obtener estadísticas de servicios");
        }

        public dynamic ObtenerAsistenciasTendencias()
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                var datos = new AccesoDatos();
                try
                {
                    datos.setearProcedimiento("sp_ObtenerAsistenciasTendencias");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return new
                        {
                            AsistenciasTotales = (int)datos.Lector["AsistenciasTotales"],
                            AsistenciasEmpleados = (int)datos.Lector["AsistenciasEmpleados"],
                            AsistenciasInvitados = (int)datos.Lector["AsistenciasInvitados"],
                            PromedioDiario = (int)datos.Lector["PromedioDiario"],
                            CoberturaPromedio = datos.Lector["CoberturaPromedio"] is DBNull ? 0m : (decimal)datos.Lector["CoberturaPromedio"],
                            DuracionPromedio = datos.Lector["DuracionPromedio"] is DBNull ? 0 : (int)datos.Lector["DuracionPromedio"]
                        };
                    }
                    return null;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "obtener asistencias y tendencias");
        }

        public List<dynamic> ObtenerTop5Empresas(DateTime fecha)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                var lista = new List<dynamic>();
                var datos = new AccesoDatos();
                
                // Calcular primer y último día del mes
                var primerDia = new DateTime(fecha.Year, fecha.Month, 1);
                var ultimoDia = primerDia.AddMonths(1).AddDays(-1);
                
                try
                {
                    datos.setearProcedimiento("sp_ObtenerTop5EmpresasPorAsistencias");
                    datos.setearParametro("@FechaInicio", primerDia);
                    datos.setearParametro("@FechaFin", ultimoDia);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        var item = new
                        {
                            Ranking = (long)datos.Lector["Ranking"],
                            NombreEmpresa = (string)datos.Lector["NombreEmpresa"],
                            TotalAsistencias = (int)datos.Lector["TotalAsistencias"],
                            Porcentaje = (decimal)datos.Lector["Porcentaje"]
                        };
                        lista.Add(item);
                    }
                    return lista;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "obtener top 5 empresas por asistencias");
        }
    }
}
