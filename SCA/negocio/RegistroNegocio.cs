using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class RegistroNegocio
    {
        public void RegistrarEmpleado(int idEmpleado, int idEmpresa, int idServicio, int idLugar)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_RegistrarEmpleado");
                    datos.setearParametro("@IdEmpleado", idEmpleado);
                    datos.setearParametro("@IdEmpresa", idEmpresa);
                    datos.setearParametro("@IdServicio", idServicio);
                    datos.setearParametro("@IdLugar", idLugar);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "registrar empleado");
            }
        }

        public List<Registro> ListarPorServicio(int idServicio)
        {
            try
            {
                List<Registro> lista = new List<Registro>();

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarRegistrosPorServicio");
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
                        lista.Add(registro);
                    }

                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "listar registros por servicio");
            }
        }

        public bool EmpleadoYaRegistrado(int idEmpleado, int idServicio)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_VerificarEmpleadoRegistrado");
                    datos.setearParametro("@IdEmpleado", idEmpleado);
                    datos.setearParametro("@IdServicio", idServicio);
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
                throw NegocioException.FromDbException(ex, "verificar empleado registrado");
            }
        }

        public int ContarRegistrosPorServicio(int idServicio)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ContarRegistrosPorServicio");
                    datos.setearParametro("@IdServicio", idServicio);
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return (int)datos.Lector["TotalRegistros"];
                    }

                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "contar registros por servicio");
            }
        }

        public List<Registro> ObtenerRegistrosPorEmpresaYFecha(int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                List<Registro> lista = new List<Registro>();

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ObtenerRegistrosPorEmpresaYFecha");
                    datos.setearParametro("@IdEmpresa", idEmpresa);
                    datos.setearParametro("@FechaInicio", fechaInicio);
                    datos.setearParametro("@FechaFin", fechaFin);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Registro registro = new Registro();
                        registro.IdRegistro = (int)datos.Lector["IdRegistro"];
                        registro.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                        registro.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                        registro.IdServicio = (int)datos.Lector["IdServicio"];
                        registro.IdLugar = (int)datos.Lector["IdLugar"];
                        registro.Fecha = (DateTime)datos.Lector["Fecha"];
                        registro.Hora = (TimeSpan)datos.Lector["Hora"];
                        registro.NombreEmpleado = (string)datos.Lector["NombreEmpleado"];
                        registro.NombreEmpresa = (string)datos.Lector["NombreEmpresa"];
                        lista.Add(registro);
                    }

                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener registros por empresa y fecha");
            }
        }
    }
}