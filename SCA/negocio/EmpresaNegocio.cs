using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class EmpresaNegocio
    {
        public List<Empresa> Listar()
        {
            try
            {
                List<Empresa> lista = new List<Empresa>();

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarEmpresas");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Empresa empresa = new Empresa();
                        empresa.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                        empresa.Nombre = (string)datos.Lector["Nombre"];

                        lista.Add(empresa);
                    }

                    return lista;
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
                List<Empresa> lista = new List<Empresa>();

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearConsulta("SELECT IdEmpresa, Empresa as Nombre, Estado, CantidadEmpleados FROM vw_EmpresasConEmpleados");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Empresa empresa = new Empresa();
                        empresa.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                        empresa.Nombre = (string)datos.Lector["Nombre"];
                        empresa.Estado = (bool)datos.Lector["Estado"];
                        empresa.CantidadEmpleados = (int)datos.Lector["CantidadEmpleados"];

                        lista.Add(empresa);
                    }

                    return lista;
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
                Empresa empresa = null;

                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_BuscarEmpresaPorId");
                    datos.setearParametro("@IdEmpresa", idEmpresa);
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        empresa = new Empresa();
                        empresa.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                        empresa.Nombre = (string)datos.Lector["Nombre"];
                        empresa.Estado = (bool)datos.Lector["Estado"];
                    }

                    return empresa;
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