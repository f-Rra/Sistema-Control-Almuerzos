using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class EstadisticasNegocio
    {
        public Estadisticas.Empleados ObtenerEstadisticasEmpleados()
        {
            try
            {
                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ObtenerEstadisticasEmpleados");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return new Estadisticas.Empleados
                        {
                            TotalRegistrados = (int)datos.Lector["TotalRegistrados"],
                            TotalActivos = (int)datos.Lector["TotalActivos"],
                            TotalInactivos = (int)datos.Lector["TotalInactivos"]
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener estadísticas de empleados");
            }
        }

        public Estadisticas.Empresas ObtenerEstadisticasEmpresas()
        {
            try
            {
                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ObtenerEstadisticasEmpresas");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return new Estadisticas.Empresas
                        {
                            TotalActivas = (int)datos.Lector["TotalActivas"],
                            TotalConEmpleados = (int)datos.Lector["TotalConEmpleados"],
                            PromedioEmpleados = (decimal)datos.Lector["PromedioEmpleados"]
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener estadísticas de empresas");
            }
        }

        public Estadisticas.Servicios ObtenerEstadisticasServicios()
        {
            try
            {
                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ObtenerEstadisticasServicios");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return new Estadisticas.Servicios
                        {
                            ServiciosEsteMes = (int)datos.Lector["ServiciosEsteMes"],
                            ServiciosEsteAnio = (int)datos.Lector["ServiciosEsteAnio"],
                            PromedioPorDia = (int)datos.Lector["PromedioPorDia"]
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener estadísticas de servicios");
            }
        }

        public Estadisticas.Asistencias ObtenerAsistenciasTendencias()
        {
            try
            {
                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ObtenerAsistenciasTendencias");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return new Estadisticas.Asistencias
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener asistencias y tendencias");
            }
        }

        public List<Estadisticas.TopEmpresa> ObtenerTop5Empresas(DateTime fecha)
        {
            try
            {
                var lista = new List<Estadisticas.TopEmpresa>();
                var primerDia = new DateTime(fecha.Year, fecha.Month, 1);
                var ultimoDia = primerDia.AddMonths(1).AddDays(-1);

                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ObtenerTop5EmpresasPorAsistencias");
                    datos.setearParametro("@FechaInicio", primerDia);
                    datos.setearParametro("@FechaFin", ultimoDia);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        var item = new Estadisticas.TopEmpresa
                        {
                            Ranking = Convert.ToInt64(datos.Lector["Ranking"]),
                            NombreEmpresa = datos.Lector["NombreEmpresa"].ToString(),
                            TotalAsistencias = Convert.ToInt32(datos.Lector["TotalAsistencias"]),
                            Porcentaje = Convert.ToDecimal(datos.Lector["Porcentaje"])
                        };
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener top 5 empresas por asistencias");
            }
        }
    }
}
