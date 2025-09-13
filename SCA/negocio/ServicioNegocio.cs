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
                    servicio.id = (int)datos.Lector["IdServicio"];
                    servicio.idLugar = (int)datos.Lector["IdLugar"];
                    servicio.fecha = (DateTime)datos.Lector["Fecha"];
                    servicio.totalComensales = (int)datos.Lector["TotalComensales"];
                    servicio.totalInvitados = (int)datos.Lector["TotalInvitados"];

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

        // Crear nuevo servicio
        public int crearServicio(int idLugar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AltaServicio");
                datos.setearParametro("@IdLugar", idLugar);
                return datos.ejecutarAccionReturn();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Finalizar servicio
        public void finalizarServicio(int idServicio, int totalComensales, int totalInvitados)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_FinalizarServicio");
                datos.setearParametro("@IdServicio", idServicio);
                datos.setearParametro("@TotalComensales", totalComensales);
                datos.setearParametro("@TotalInvitados", totalInvitados);
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
                    servicio.id = (int)datos.Lector["IdServicio"];
                    servicio.fecha = (DateTime)datos.Lector["Fecha"];
                    servicio.totalComensales = (int)datos.Lector["TotalComensales"];
                    servicio.totalInvitados = (int)datos.Lector["TotalInvitados"];
                    servicio.nombreLugar = (string)datos.Lector["Lugar"];

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
                    servicio.id = (int)datos.Lector["IdServicio"];
                    servicio.fecha = (DateTime)datos.Lector["Fecha"];
                    servicio.totalComensales = (int)datos.Lector["TotalComensales"];
                    servicio.totalInvitados = (int)datos.Lector["TotalInvitados"];

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