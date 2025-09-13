using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class LugarNegocio
    {
        // Obtener todos los lugares para el ComboBox
        public List<Lugar> listar()
        {
            List<Lugar> lista = new List<Lugar>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_ListarLugares");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Lugar lugar = new Lugar();
                    lugar.id = (int)datos.Lector["IdLugar"];
                    lugar.nombre = (string)datos.Lector["Nombre"];

                    lista.Add(lugar);
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

        // Obtener ID de lugar por nombre
        public int obtenerIdPorNombre(string nombreLugar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_ObtenerLugarPorNombre");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.setearParametro("@Nombre", nombreLugar);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["IdLugar"];
                }

                return 0; // Si no encuentra el lugar
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

        // Validar contraseña de administrador (hardcodeada)
        public static bool validarPasswordAdmin(string password)
        {
            return password == "admin123"; // Contraseña hardcodeada
        }
    }
}