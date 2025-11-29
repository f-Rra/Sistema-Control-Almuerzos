using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace negocio.Mappers
{
    public static class EmpresaMapper
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

        public static Empresa MapFromReader(SqlDataReader reader)
        {
            Empresa empresa = new Empresa
            {
                IdEmpresa = (int)reader["IdEmpresa"],
                Nombre = (string)reader["Nombre"]
            };

            if (ColumnExists(reader, "Estado") && reader["Estado"] != System.DBNull.Value)
            {
                empresa.Estado = (bool)reader["Estado"];
            }

            if (ColumnExists(reader, "CantidadEmpleados") && reader["CantidadEmpleados"] != System.DBNull.Value)
            {
                empresa.CantidadEmpleados = (int)reader["CantidadEmpleados"];
            }

            return empresa;
        }

        public static List<Empresa> MapList(SqlDataReader reader)
        {
            List<Empresa> lista = new List<Empresa>();
            while (reader.Read())
            {
                lista.Add(MapFromReader(reader));
            }
            return lista;
        }
    }
}
