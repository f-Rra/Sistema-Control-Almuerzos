using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace negocio.Mappers
{
    public static class LugarMapper
    {
        private static bool ColumnExists(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, System.StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public static Lugar MapFromReader(SqlDataReader reader)
        {
            Lugar lugar = new Lugar
            {
                IdLugar = (int)reader["IdLugar"],
                Nombre = (string)reader["Nombre"]
            };

            if (ColumnExists(reader, "Descripcion") && reader["Descripcion"] != System.DBNull.Value)
            {
                lugar.Descripcion = (string)reader["Descripcion"];
            }

            if (ColumnExists(reader, "Estado") && reader["Estado"] != System.DBNull.Value)
            {
                lugar.Estado = (bool)reader["Estado"];
            }

            return lugar;
        }

        public static List<Lugar> MapList(SqlDataReader reader)
        {
            List<Lugar> lista = new List<Lugar>();
            while (reader.Read())
            {
                lista.Add(MapFromReader(reader));
            }
            return lista;
        }
    }
}
