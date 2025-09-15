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
        // Listar todas las empresas
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
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Empleados por empresa
        public List<Empleado> empleadosPorEmpresa(int idEmpresa)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EmpleadosPorEmpresa");
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
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}