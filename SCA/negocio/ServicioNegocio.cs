using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;

namespace Negocio
{
    public class ServicioNegocio
    {
        // Obtener servicio activo por lugar
        public Servicio obtenerServicioActivo(int idLugar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ObtenerServicioActivo");
                datos.setearParametro("@IdLugar", idLugar);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Servicio servicio = new Servicio();
                    servicio.IdServicio = (int)datos.Lector["IdServicio"];
                    servicio.IdLugar = (int)datos.Lector["IdLugar"];
                    servicio.Fecha = (DateTime)datos.Lector["Fecha"];
                    if (!(datos.Lector["Proyeccion"] is DBNull)) servicio.Proyeccion = (int)datos.Lector["Proyeccion"];
                    if (!(datos.Lector["DuracionMinutos"] is DBNull)) servicio.DuracionMinutos = (int)datos.Lector["DuracionMinutos"];
                    servicio.TotalComensales = (int)datos.Lector["TotalComensales"];
                    servicio.TotalInvitados = (int)datos.Lector["TotalInvitados"];

                    return servicio;
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

        // Crear nuevo servicio (opcionalmente con proyección)
        public int crearServicio(int idLugar, int? proyeccion = null)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AltaServicio");
                datos.setearParametro("@IdLugar", idLugar);
                if (proyeccion.HasValue)
                    datos.setearParametro("@Proyeccion", proyeccion.Value);
                else
                    datos.setearParametro("@Proyeccion", System.DBNull.Value);
                return datos.ejecutarAccionReturn();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Finalizar servicio
        public void finalizarServicio(int idServicio, int totalComensales, int totalInvitados, int? duracionMinutos = null)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_FinalizarServicio");
                datos.setearParametro("@IdServicio", idServicio);
                datos.setearParametro("@TotalComensales", totalComensales);
                datos.setearParametro("@TotalInvitados", totalInvitados);
                if (duracionMinutos.HasValue)
                    datos.setearParametro("@DuracionMinutos", duracionMinutos.Value);
                else
                    datos.setearParametro("@DuracionMinutos", System.DBNull.Value);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Listar servicios por fecha
        public List<Servicio> listarPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarServiciosPorFecha");
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
                    servicio.NombreLugar = (string)datos.Lector["Lugar"];

                    lista.Add(servicio);
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

        // Listar servicios por lugar
        public List<Servicio> listarPorLugar(int idLugar, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarServiciosPorLugar");
                datos.setearParametro("@IdLugar", idLugar);
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

                    lista.Add(servicio);
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