using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EmpresaNegocio
    {
        public List<Empresa> listar()
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

        public List<Empresa> listarConEmpleados()
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

        public Empresa buscarPorId(int idEmpresa)
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

        public void eliminar(int idEmpresa)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_DesactivarEmpresa");
                    datos.setearParametro("@IdEmpresa", idEmpresa);
                    datos.ejecutarAccion();
                }
            }, "desactivar empresa");
        }

        public void agregar(Empresa empresa)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_AgregarEmpresa");
                    datos.setearParametro("@Nombre", empresa.Nombre);
                    datos.setearParametro("@Estado", empresa.Estado);
                    datos.ejecutarAccion();
                }
            }, "agregar empresa");
        }

        public void modificar(Empresa empresa)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ModificarEmpresa");
                    datos.setearParametro("@IdEmpresa", empresa.IdEmpresa);
                    datos.setearParametro("@Nombre", empresa.Nombre);
                    datos.setearParametro("@Estado", empresa.Estado);
                    datos.ejecutarAccion();
                }
            }, "modificar empresa");
        }
    }
}