using System;
using System.Collections.Generic;
using Dominio;
using Negocio.Mappers;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        public List<Empleado> Listar()
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarEmpleados");
                    datos.ejecutarLectura();

                    return EmpleadoMapper.MapList(datos.Lector);
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
                        return EmpleadoMapper.MapFromReader(datos.Lector);
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
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_EmpleadosSinAlmorzar");
                    datos.setearParametro("@IdServicio", idServicio);
                    datos.ejecutarLectura();

                    return EmpleadoMapper.MapList(datos.Lector);
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
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_FiltrarEmpleadosSinAlmorzar");
                    datos.setearParametro("@IdServicio", idServicio);
                    datos.setearParametro("@IdEmpresa", idEmpresa.HasValue ? (object)idEmpresa.Value : DBNull.Value);
                    datos.setearParametro("@Nombre", !string.IsNullOrWhiteSpace(nombre) ? (object)nombre : DBNull.Value);

                    datos.ejecutarLectura();

                    return EmpleadoMapper.MapList(datos.Lector);
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
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_BuscarEmpleadoPorId");
                    datos.setearParametro("@IdEmpleado", id);
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return EmpleadoMapper.MapFromReader(datos.Lector);
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "buscar empleado por ID");
            }
        }

        /// <summary>
        /// Filtra empleados por nombre/apellido/credencial y empresa (optimizado en BD).
        /// </summary>
        /// <param name="filtro">Texto a buscar en nombre, apellido o credencial.</param>
        /// <param name="idEmpresa">ID de empresa para filtrar (opcional).</param>
        /// <returns>Lista de empleados que coinciden con los filtros.</returns>
        public List<Empleado> FiltrarEmpleados(string filtro = null, int? idEmpresa = null)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_FiltrarEmpleados");
                    datos.setearParametro("@Filtro", string.IsNullOrWhiteSpace(filtro) ? (object)DBNull.Value : filtro);
                    datos.setearParametro("@IdEmpresa", idEmpresa.HasValue ? (object)idEmpresa.Value : DBNull.Value);
                    datos.ejecutarLectura();

                    return EmpleadoMapper.MapList(datos.Lector);
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "filtrar empleados");
            }
        }
    }
}
