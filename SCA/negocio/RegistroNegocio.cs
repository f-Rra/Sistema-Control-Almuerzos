using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;
using Negocio.Mappers;

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
            catch (SqlException ex)
            {
                throw NegocioException.FromDbException(ex, "registrar empleado");
            }
        }

        public List<Registro> ListarPorServicio(int idServicio)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarRegistrosPorServicio");
                    datos.setearParametro("@IdServicio", idServicio);
                    datos.ejecutarLectura();

                    return RegistroMapper.MapList(datos.Lector);
                }
            }
            catch (SqlException ex)
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
            catch (SqlException ex)
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
            catch (SqlException ex)
            {
                throw NegocioException.FromDbException(ex, "contar registros por servicio");
            }
        }

        public List<Registro> ObtenerRegistrosPorEmpresaYFecha(int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ObtenerRegistrosPorEmpresaYFecha");
                    datos.setearParametro("@IdEmpresa", idEmpresa);
                    datos.setearParametro("@FechaInicio", fechaInicio);
                    datos.setearParametro("@FechaFin", fechaFin);
                    datos.ejecutarLectura();

                    return RegistroMapper.MapList(datos.Lector);
                }
            }
            catch (SqlException ex)
            {
                throw NegocioException.FromDbException(ex, "obtener registros por empresa y fecha");
            }
        }
    }
}