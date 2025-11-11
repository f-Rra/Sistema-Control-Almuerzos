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
        public Servicio obtenerUltimoServicio()
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

        public int crearServicio(int idLugar, int? proyeccion = null)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                datos.setearProcedimiento("sp_IniciarServicio");
                datos.setearParametro("@IdLugar", idLugar);
                if (proyeccion.HasValue)
                    datos.setearParametro("@Proyeccion", proyeccion.Value);
                else
                    datos.setearParametro("@Proyeccion", System.DBNull.Value);
                return datos.ejecutarAccionReturn();
            }
        }

        public void finalizarServicio(int idServicio, int totalComensales, int totalInvitados, int? duracionMinutos = null)
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
                    datos.setearParametro("@DuracionMinutos", System.DBNull.Value);
                datos.ejecutarAccion();
            }
        }

        public List<Servicio> listarPorFecha(DateTime fechaDesde, DateTime fechaHasta)
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

        public List<Servicio> listarTodos()
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
    }
}
