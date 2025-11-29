using System;
using System.Collections.Generic;
using Dominio;
using negocio.Mappers;

namespace Negocio
{
    public class ServicioNegocio
    {
        public Servicio ObtenerUltimoServicio()
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ObtenerUltimoServicio");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return ServicioMapper.MapFromReader(datos.Lector);
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener último servicio");
            }
        }

        public int CrearServicio(int idLugar, int? proyeccion = null)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_IniciarServicio");
                    datos.setearParametro("@IdLugar", idLugar);
                    datos.setearParametro("@Proyeccion", proyeccion.HasValue ? (object)proyeccion.Value : DBNull.Value);
                    return datos.ejecutarAccionReturn();
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "crear servicio");
            }
        }

        public void FinalizarServicio(int idServicio, int totalComensales, int totalInvitados, int? duracionMinutos = null)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_FinalizarServicio");
                    datos.setearParametro("@IdServicio", idServicio);
                    datos.setearParametro("@TotalComensales", totalComensales);
                    datos.setearParametro("@TotalInvitados", totalInvitados);
                    if (duracionMinutos.HasValue)
                        datos.setearParametro("@DuracionMinutos", duracionMinutos.Value);
                    else
                        datos.setearParametro("@DuracionMinutos", DBNull.Value);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "finalizar servicio");
            }
        }

        public List<Servicio> ListarPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarServiciosPorFecha");
                    datos.setearParametro("@FechaDesde", fechaDesde);
                    datos.setearParametro("@FechaHasta", fechaHasta);
                    datos.ejecutarLectura();

                    return ServicioMapper.MapList(datos.Lector);
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "listar servicios por fecha");
            }
        }

        public List<Servicio> ListarTodos()
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarServicios");
                    datos.ejecutarLectura();

                    return ServicioMapper.MapList(datos.Lector);
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "listar servicios");
            }
        }

        public int FinalizarServiciosPendientes()
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_FinalizarServiciosPendientes");
                    datos.ejecutarLectura();
                    if (datos.Lector.Read())
                        return (int)datos.Lector["ServiciosFinalizados"];
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "finalizar servicios pendientes");
            }
        }
    }
}
