using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        public List<Empleado> Listar()
        {
            try
            {
                List<Empleado> lista = new List<Empleado>();

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarEmpleados");
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "cargar empleados");
            }
        }

        public Empleado BuscarPorCredencial(string credencial)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_BuscarEmpleadoPorCredencial");
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "buscar empleado por credencial");
            }
        }

        public List<Empleado> EmpleadosSinAlmorzar(int idServicio)
        {
            try
            {
                List<Empleado> lista = new List<Empleado>();

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_EmpleadosSinAlmorzar");
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener empleados sin almorzar");
            }
        }

        public List<Empleado> FiltrarEmpleadosSinAlmorzar(int idServicio, int? idEmpresa = null, string nombre = null)
        {
            try
            {
                List<Empleado> lista = new List<Empleado>();

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_FiltrarEmpleadosSinAlmorzar");
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "filtrar empleados sin almorzar");
            }
        }

        public void Agregar(Empleado empleado)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_AgregarEmpleado");
                    datos.setearParametro("@IdCredencial", empleado.IdCredencial);
                    datos.setearParametro("@Nombre", empleado.Nombre);
                    datos.setearParametro("@Apellido", empleado.Apellido);
                    datos.setearParametro("@IdEmpresa", empleado.Empresa.IdEmpresa);
                    datos.setearParametro("@Estado", empleado.Estado);

                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "agregar empleado");
            }
        }

        public void Modificar(Empleado empleado)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ModificarEmpleado");
                    datos.setearParametro("@IdEmpleado", empleado.IdEmpleado);
                    datos.setearParametro("@IdCredencial", empleado.IdCredencial);
                    datos.setearParametro("@Nombre", empleado.Nombre);
                    datos.setearParametro("@Apellido", empleado.Apellido);
                    datos.setearParametro("@IdEmpresa", empleado.Empresa.IdEmpresa);
                    datos.setearParametro("@Estado", empleado.Estado);

                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "modificar empleado");
            }
        }

        public void Eliminar(int idEmpleado)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_DesactivarEmpleado");
                    datos.setearParametro("@IdEmpleado", idEmpleado);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "desactivar empleado");
            }
        }

        public bool ExisteCredencial(string credencial)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_VerificarCredencial");
                    datos.setearParametro("@IdCredencial", credencial);
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return (int)datos.Lector["Registrado"] > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "verificar credencial");
            }
        }

        public Empleado BuscarPorId(int id)
        {
            try
            {
                Empleado empleado = new Empleado();

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_BuscarEmpleadoPorId");
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "buscar empleado por ID");
            }
        }
    }
}
