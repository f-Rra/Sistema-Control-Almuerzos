using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace negocio.Mappers
{
    public static class EmpleadoMapper
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

        public static Empleado MapFromReader(SqlDataReader reader)
        {
            Empleado empleado = new Empleado
            {
                IdEmpleado = (int)reader["IdEmpleado"],
                Nombre = (string)reader["Nombre"],
                Apellido = (string)reader["Apellido"],
                IdCredencial = (string)reader["IdCredencial"],
                IdEmpresa = (int)reader["IdEmpresa"]
            };

            if (ColumnExists(reader, "Empresa") && reader["Empresa"] != System.DBNull.Value)
            {
                empleado.NombreEmpresa = (string)reader["Empresa"];
            }
            else if (ColumnExists(reader, "NombreEmpresa") && reader["NombreEmpresa"] != System.DBNull.Value)
            {
                empleado.NombreEmpresa = (string)reader["NombreEmpresa"];
            }

            if (ColumnExists(reader, "Estado") && reader["Estado"] != System.DBNull.Value)
            {
                empleado.Estado = (bool)reader["Estado"];
            }

            return empleado;
        }

        public static List<Empleado> MapList(SqlDataReader reader)
        {
            List<Empleado> lista = new List<Empleado>();
            while (reader.Read())
            {
                lista.Add(MapFromReader(reader));
            }
            return lista;
        }
    }
}
