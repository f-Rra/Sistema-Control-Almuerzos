using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ReporteNegocio
    {
        // Estadísticas del servicio activo
        public dynamic estadisticasServicioActivo(int idServicio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_EstadisticasServicioActivo");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new
                    {
                        TotalEmpleados = (int)datos.Lector["TotalEmpleados"],
                        TotalInvitados = (int)datos.Lector["TotalInvitados"],
                        TotalGeneral = (int)datos.Lector["TotalGeneral"]
                    };
                }

                return null;
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

        // Registros por empresa en un servicio
        public List<dynamic> registrosPorEmpresa(int idServicio)
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_RegistrosPorEmpresa");
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Empresa = (string)datos.Lector["Empresa"],
                        Cantidad = (int)datos.Lector["Cantidad"]
                    };

                    lista.Add(item);
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

        // Picos de concurrencia por hora
        public List<dynamic> picosConcurrencia(int idServicio)
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_PicosConcurrencia");
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Hora = (int)datos.Lector["Hora"],
                        Cantidad = (int)datos.Lector["Cantidad"]
                    };

                    lista.Add(item);
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

        // Resumen diario por lugar
        public List<dynamic> resumenDiarioPorLugar(DateTime fecha)
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ResumenDiarioPorLugar");
                datos.setearParametro("@Fecha", fecha);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Fecha = (DateTime)datos.Lector["Fecha"],
                        Lugar = (string)datos.Lector["Lugar"],
                        TotalComensales = (int)datos.Lector["TotalComensales"],
                        TotalInvitados = (int)datos.Lector["TotalInvitados"],
                        Total = (int)datos.Lector["Total"]
                    };

                    lista.Add(item);
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

        // Top 5 empresas con más asistencia
        public List<dynamic> topEmpresasAsistencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_TopEmpresasAsistencia");
                datos.setearParametro("@FechaDesde", fechaDesde);
                datos.setearParametro("@FechaHasta", fechaHasta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Empresa = (string)datos.Lector["Empresa"],
                        TotalAsistencias = (int)datos.Lector["TotalAsistencias"]
                    };

                    lista.Add(item);
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

        // Promedio diario de asistencia
        public double promedioDiarioAsistencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_PromedioDiarioAsistencia");
                datos.setearParametro("@FechaDesde", fechaDesde);
                datos.setearParametro("@FechaHasta", fechaHasta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return Convert.ToDouble(datos.Lector["PromedioDiario"]);
                }

                return 0;
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

        // Estadísticas del día actual
        public List<dynamic> estadisticasDiaActual()
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EstadisticasDiaActual");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Lugar = (string)datos.Lector["Lugar"],
                        ServiciosHoy = (int)datos.Lector["ServiciosHoy"],
                        TotalEmpleados = (int)datos.Lector["TotalEmpleados"],
                        TotalInvitados = (int)datos.Lector["TotalInvitados"],
                        TotalGeneral = (int)datos.Lector["TotalGeneral"]
                    };

                    lista.Add(item);
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

        // Tendencia últimos 7 días
        public List<dynamic> tendenciaUltimos7Dias()
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_TendenciaUltimos7Dias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Fecha = (DateTime)datos.Lector["Fecha"],
                        TotalDiario = (int)datos.Lector["TotalDiario"]
                    };

                    lista.Add(item);
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

        // Empleados más frecuentes
        public List<dynamic> empleadosMasFrecuentes(int meses = 1)
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EmpleadosMasFrecuentes");
                datos.setearParametro("@Meses", meses);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Empleado = (string)datos.Lector["Empleado"],
                        Empresa = (string)datos.Lector["Empresa"],
                        Asistencias = (int)datos.Lector["Asistencias"]
                    };

                    lista.Add(item);
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