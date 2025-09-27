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

       
        

        
    }
}