using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class LugarNegocio
    {
        public List<Lugar> Listar()
        {
            try
            {
                List<Lugar> lista = new List<Lugar>();

                using (AccesoDatos datos = new AccesoDatos())
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "listar lugares");
            }
        }
    }
}
