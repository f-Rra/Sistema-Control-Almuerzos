using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        public List<Empleado> listar()
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_ListarEmpleados");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                    empleado.Nombre = (string)datos.Lector["Nombre"];
                    empleado.Apellido = (string)datos.Lector["Apellido"];
                    empleado.IdCredencial = (string)datos.Lector["IdCredencial"];
                    empleado.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                    empleado.NombreEmpresa = (string)datos.Lector["Empresa"];

                    lista.Add(empleado);
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

        public Empleado buscarPorCredencial(string credencial)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_BuscarEmpleadoPorCredencial");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.setearParametro("@Credencial", credencial);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                    empleado.Nombre = (string)datos.Lector["Nombre"];
                    empleado.Apellido = (string)datos.Lector["Apellido"];
                    empleado.IdCredencial = (string)datos.Lector["IdCredencial"];
                    empleado.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                    empleado.NombreEmpresa = (string)datos.Lector["Empresa"];

                    return empleado;
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

        public List<Empleado> listarPorEmpresa(int idEmpresa)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarEmpleadosPorEmpresa");
                datos.setearParametro("@IdEmpresa", idEmpresa);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                    empleado.Nombre = (string)datos.Lector["Nombre"];
                    empleado.Apellido = (string)datos.Lector["Apellido"];
                    empleado.IdCredencial = (string)datos.Lector["IdCredencial"];

                    lista.Add(empleado);
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

        public List<Empleado> empleadosSinAlmorzar(int idServicio)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EmpleadosSinAlmorzar");
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                    empleado.Nombre = (string)datos.Lector["Nombre"];
                    empleado.Apellido = (string)datos.Lector["Apellido"];
                    empleado.IdCredencial = (string)datos.Lector["IdCredencial"];
                    empleado.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                    empleado.NombreEmpresa = (string)datos.Lector["Empresa"];

                    lista.Add(empleado);
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

        public List<Empleado> filtrarEmpleadosSinAlmorzar(int idServicio, int? idEmpresa = null, string nombre = null)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_FiltrarEmpleadosSinAlmorzar");
                datos.setearParametro("@IdServicio", idServicio);
                
                if (idEmpresa.HasValue)
                    datos.setearParametro("@IdEmpresa", idEmpresa.Value);
                else
                    datos.setearParametro("@IdEmpresa", DBNull.Value);
                    
                if (!string.IsNullOrWhiteSpace(nombre))
                    datos.setearParametro("@Nombre", nombre);
                else
                    datos.setearParametro("@Nombre", DBNull.Value);
                
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                    empleado.Nombre = (string)datos.Lector["Nombre"];
                    empleado.Apellido = (string)datos.Lector["Apellido"];
                    empleado.IdCredencial = (string)datos.Lector["IdCredencial"];
                    empleado.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                    empleado.NombreEmpresa = (string)datos.Lector["Empresa"];

                    lista.Add(empleado);
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