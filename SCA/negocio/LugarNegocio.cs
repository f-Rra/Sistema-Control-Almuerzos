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
        public List<Lugar> listar()
        {
            List<Lugar> lista = new List<Lugar>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ListarLugares");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Lugar lugar = new Lugar();
                    lugar.IdLugar = (int)datos.Lector["IdLugar"];
                    lugar.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(lugar);
                }

                return lista;
            }
            catch
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
