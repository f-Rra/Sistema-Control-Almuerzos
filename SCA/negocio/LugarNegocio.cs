using System;
using System.Collections.Generic;
using Dominio;
using negocio.Mappers;

namespace Negocio
{
    public class LugarNegocio
    {
        public List<Lugar> Listar()
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ListarLugares");
                    datos.ejecutarLectura();

                    return LugarMapper.MapList(datos.Lector);
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "listar lugares");
            }
        }
    }
}
