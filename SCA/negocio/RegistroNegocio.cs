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
            ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearProcedimiento("sp_RegistrarEmpleado");
                    datos.setearParametro("@IdEmpleado", idEmpleado);
                    datos.setearParametro("@IdEmpresa", idEmpresa);
                    datos.setearParametro("@IdServicio", idServicio);
                    datos.setearParametro("@IdLugar", idLugar);
                    datos.ejecutarAccion();
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "registrar empleado");
        }

        public List<Registro> listarPorServicio(int idServicio)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                List<Registro> lista = new List<Registro>();
                AccesoDatos datos = new AccesoDatos();

                try
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
                finally
                {
                    datos.cerrarConexion();
                }
            }, "listar registros por servicio");
        }

        public bool empleadoYaRegistrado(int idEmpleado, int idServicio)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();

                try
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
                finally
                {
                    datos.cerrarConexion();
                }
            }, "verificar empleado registrado");
        }

        public int contarRegistrosPorServicio(int idServicio)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();

                try
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
                finally
                {
                    datos.cerrarConexion();
                }
            }, "contar registros por servicio");
        }

        public List<Registro> obtenerRegistrosPorEmpresaYFecha(int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                List<Registro> lista = new List<Registro>();
                AccesoDatos datos = new AccesoDatos();

                try
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
                finally
                {
                    datos.cerrarConexion();
                }
            }, "obtener registros por empresa y fecha");
        }
    }
}