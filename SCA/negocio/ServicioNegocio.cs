using System;
using System.Collections.Generic;
using Dominio;

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
                        Servicio servicio = new Servicio();
                        servicio.IdServicio = (int)datos.Lector["IdServicio"];
                        servicio.IdLugar = (int)datos.Lector["IdLugar"];
                        servicio.NombreLugar = (string)datos.Lector["NombreLugar"];
                        servicio.Fecha = (DateTime)datos.Lector["Fecha"];
                        if (!(datos.Lector["Proyeccion"] is DBNull)) servicio.Proyeccion = (int)datos.Lector["Proyeccion"];
                        if (!(datos.Lector["DuracionMinutos"] is DBNull)) servicio.DuracionMinutos = (int)datos.Lector["DuracionMinutos"];
                        servicio.TotalComensales = (int)datos.Lector["TotalComensales"];
                        servicio.TotalInvitados = (int)datos.Lector["TotalInvitados"];

                        return servicio;
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
                    // Validación adicional para prevenir race condition
                    datos.setearProcedimiento("sp_VerificarServicioActivo");
                    datos.setearParametro("@IdLugar", idLugar);
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        int existe = (int)datos.Lector["Existe"];
                        if (existe > 0)
                        {
                            datos.cerrarConexion();
                            throw new NegocioException("Ya existe un servicio activo para este lugar. Finalice el servicio actual antes de iniciar uno nuevo.", "crear servicio");
                        }
                    }
                    datos.cerrarConexion();

                    // Proceder con la inserción
                    datos.setearProcedimiento("sp_IniciarServicio");
                    datos.setearParametro("@IdLugar", idLugar);
                    if (proyeccion.HasValue)
                        datos.setearParametro("@Proyeccion", proyeccion.Value);
                    else
                        datos.setearParametro("@Proyeccion", DBNull.Value);
                    return datos.ejecutarAccionReturn();
                }
            }
            catch (NegocioException)
            {
                throw; // Re-lanzar NegocioException sin envolver
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
                List<Servicio> lista = new List<Servicio>();

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarServiciosPorFecha");
                    datos.setearParametro("@FechaDesde", fechaDesde);
                    datos.setearParametro("@FechaHasta", fechaHasta);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Servicio servicio = new Servicio();
                        servicio.IdServicio = (int)datos.Lector["IdServicio"];
                        servicio.Fecha = (DateTime)datos.Lector["Fecha"];
                        if (!(datos.Lector["Proyeccion"] is DBNull)) servicio.Proyeccion = (int)datos.Lector["Proyeccion"];
                        if (!(datos.Lector["DuracionMinutos"] is DBNull)) servicio.DuracionMinutos = (int)datos.Lector["DuracionMinutos"];
                        servicio.TotalComensales = (int)datos.Lector["TotalComensales"];
                        servicio.TotalInvitados = (int)datos.Lector["TotalInvitados"];
                        servicio.NombreLugar = (string)datos.Lector["NombreLugar"];
                        lista.Add(servicio);
                    }

                    return lista;
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
                List<Servicio> lista = new List<Servicio>();

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarServicios");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Servicio servicio = new Servicio();
                        servicio.IdServicio = (int)datos.Lector["IdServicio"];
                        servicio.Fecha = (DateTime)datos.Lector["Fecha"];
                        if (!(datos.Lector["Proyeccion"] is DBNull)) servicio.Proyeccion = (int)datos.Lector["Proyeccion"];
                        if (!(datos.Lector["DuracionMinutos"] is DBNull)) servicio.DuracionMinutos = (int)datos.Lector["DuracionMinutos"];
                        servicio.TotalComensales = (int)datos.Lector["TotalComensales"];
                        servicio.TotalInvitados = (int)datos.Lector["TotalInvitados"];
                        servicio.NombreLugar = (string)datos.Lector["NombreLugar"];
                        lista.Add(servicio);
                    }

                    return lista;
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
