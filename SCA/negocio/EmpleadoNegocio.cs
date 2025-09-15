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
        // Listar todos los empleados activos
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

        // Buscar empleado por credencial RFID
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

        // Buscar empleados por nombre
        public List<Empleado> buscarPorNombre(string nombre)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_BuscarEmpleadosPorNombre");
                datos.setearParametro("@Nombre", nombre);
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

        // Empleados por empresa
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

        // Empleados que no han almorzado en un servicio
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
    }
}