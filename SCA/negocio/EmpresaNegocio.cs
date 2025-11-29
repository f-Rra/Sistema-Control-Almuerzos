using System;
using System.Collections.Generic;
using Dominio;
using negocio.Mappers;

namespace Negocio
{
    public class EmpresaNegocio
    {
        public List<Empresa> Listar()
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarEmpresas");
                    datos.ejecutarLectura();

                    return EmpresaMapper.MapList(datos.Lector);
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "listar empresas");
            }
        }

        public List<Empresa> ListarConEmpleados()
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearConsulta("SELECT IdEmpresa, Empresa as Nombre, Estado, CantidadEmpleados FROM vw_EmpresasConEmpleados");
                    datos.ejecutarLectura();

                    return EmpresaMapper.MapList(datos.Lector);
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "listar empresas con empleados");
            }
        }

        public Empresa BuscarPorId(int idEmpresa)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_BuscarEmpresaPorId");
                    datos.setearParametro("@IdEmpresa", idEmpresa);
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        return EmpresaMapper.MapFromReader(datos.Lector);
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "buscar empresa por ID");
            }
        }

        public void Eliminar(int idEmpresa)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_DesactivarEmpresa");
                    datos.setearParametro("@IdEmpresa", idEmpresa);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "desactivar empresa");
            }
        }

        public void Agregar(Empresa empresa)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_AgregarEmpresa");
                    datos.setearParametro("@Nombre", empresa.Nombre);
                    datos.setearParametro("@Estado", empresa.Estado);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "agregar empresa");
            }
        }

        public void Modificar(Empresa empresa)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ModificarEmpresa");
                    datos.setearParametro("@IdEmpresa", empresa.IdEmpresa);
                    datos.setearParametro("@Nombre", empresa.Nombre);
                    datos.setearParametro("@Estado", empresa.Estado);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "modificar empresa");
            }
        }
    }
}