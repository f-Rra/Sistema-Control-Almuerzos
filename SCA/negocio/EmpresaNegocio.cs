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
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_ListarEmpresas");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
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
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int idEmpresa)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("SP_DesactivarEmpresa");
                    datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                    datos.setearParametro("@IdEmpresa", idEmpresa);
                    datos.ejecutarAccion();
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "desactivar empresa");
        }

        public void agregar(Empresa empresa)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("SP_AgregarEmpresa");
                    datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                    datos.setearParametro("@IdCredencial", empresa.IdEmpresa);
                    datos.setearParametro("@Nombre", empresa.Nombre);
                    datos.setearParametro("@Estado", empresa.Estado);
                    datos.ejecutarAccion();
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "agregar empresa");
        }

        public void modificar(Empresa empresa)
        {
            ExceptionHelper.EjecutarConManejo(() =>
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("SP_ModificarEmpresa");
                    datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                    datos.setearParametro("@IdCredencial", empresa.IdEmpresa);
                    datos.setearParametro("@Nombre", empresa.Nombre);
                    datos.setearParametro("@Estado", empresa.Estado);
                    datos.ejecutarAccion();
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }, "modificar empresa");
        }
    }
}