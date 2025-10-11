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
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                List<Empleado> lista = new List<Empleado>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("SP_ListarTodosLosEmpleados");
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
                        empleado.Estado = (bool)datos.Lector["Estado"];
                        empleado.Empresa = new Empresa();
                        empleado.Empresa.IdEmpresa = empleado.IdEmpresa;
                        empleado.Empresa.Nombre = empleado.NombreEmpresa;
                        lista.Add(empleado);
                    }

                    return lista;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "cargar empleados");
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
                throw;
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
                throw;
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
                throw;
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
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Empleado empleado)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("SP_AgregarEmpleado");
                    datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                    datos.setearParametro("@IdCredencial", empleado.IdCredencial);
                    datos.setearParametro("@Nombre", empleado.Nombre);
                    datos.setearParametro("@Apellido", empleado.Apellido);
                    datos.setearParametro("@IdEmpresa", empleado.Empresa.IdEmpresa);
                    datos.setearParametro("@Estado", empleado.Estado);
                    
                    datos.ejecutarAccion();
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "agregar empleado");
        }

        public void modificar(Empleado empleado)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("SP_ModificarEmpleado");
                    datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                    datos.setearParametro("@IdEmpleado", empleado.IdEmpleado);
                    datos.setearParametro("@IdCredencial", empleado.IdCredencial);
                    datos.setearParametro("@Nombre", empleado.Nombre);
                    datos.setearParametro("@Apellido", empleado.Apellido);
                    datos.setearParametro("@IdEmpresa", empleado.Empresa.IdEmpresa);
                    datos.setearParametro("@Estado", empleado.Estado);
                    
                    datos.ejecutarAccion();
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "modificar empleado");
        }

        public void eliminar(int idEmpleado)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("SP_DesactivarEmpleado");
                    datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                    datos.setearParametro("@IdEmpleado", idEmpleado);
                    datos.ejecutarAccion();
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "desactivar empleado");
        }

        public bool existeCredencial(string credencial)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("SP_VerificarCredencialExiste");
                    datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                    datos.setearParametro("@IdCredencial", credencial);
                    datos.ejecutarLectura();
                    
                    if (datos.Lector.Read())
                    {
                        return (int)datos.Lector["Existe"] > 0;
                    }
                    return false;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "verificar credencial");
        }

        public Empleado buscarPorId(int id)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();
                Empleado empleado = new Empleado();
                
                try
                {
                    datos.setearConsulta("SP_BuscarEmpleadoPorId");
                    datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                    datos.setearParametro("@IdEmpleado", id);
                    datos.ejecutarLectura();
                    
                    if (datos.Lector.Read())
                    {
                        empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                        empleado.IdCredencial = datos.Lector["IdCredencial"].ToString();
                        empleado.Nombre = datos.Lector["Nombre"].ToString();
                        empleado.Apellido = datos.Lector["Apellido"].ToString();
                        empleado.Estado = (bool)datos.Lector["Estado"];
                        
                        empleado.Empresa = new Empresa();
                        empleado.Empresa.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                        empleado.Empresa.Nombre = datos.Lector["NombreEmpresa"].ToString();
                    }
                    
                    return empleado;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "buscar empleado por ID");
        }

    }
}