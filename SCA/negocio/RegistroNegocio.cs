using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class RegistroNegocio
    {
        public void registrarEmpleado(int idEmpleado, int idEmpresa, int idServicio, int idLugar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_RegistrarEmpleado");
                datos.setearParametro("@IdEmpleado", idEmpleado);
                datos.setearParametro("@IdEmpresa", idEmpresa);
                datos.setearParametro("@IdServicio", idServicio);
                datos.setearParametro("@IdLugar", idLugar);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Registro> listarPorServicio(int idServicio)
        {
            List<Registro> lista = new List<Registro>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarRegistrosPorServicio");
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Registro registro = new Registro();
                    registro.IdRegistro = (int)datos.Lector["IdRegistro"];
                    registro.Hora = (TimeSpan)datos.Lector["Hora"];
                    registro.Fecha = (DateTime)datos.Lector["Fecha"];
                    registro.NombreEmpleado = (string)datos.Lector["Empleado"];
                    registro.NombreEmpresa = (string)datos.Lector["Empresa"];
                    // NO cargar NombreLugar - la columna se oculta en la vista

                    lista.Add(registro);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool empleadoYaRegistrado(int idEmpleado, int idServicio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_VerificarEmpleadoRegistrado");
                datos.setearParametro("@IdEmpleado", idEmpleado);
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["Existe"] > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int contarRegistrosPorServicio(int idServicio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ContarRegistrosPorServicio");
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["TotalRegistros"];
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}