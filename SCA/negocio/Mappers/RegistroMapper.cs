using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace negocio.Mappers
{
    public static class RegistroMapper
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

        public static Registro MapFromReader(SqlDataReader reader)
        {
            Registro registro = new Registro
            {
                IdRegistro = (int)reader["IdRegistro"],
                Fecha = (DateTime)reader["Fecha"],
                Hora = (TimeSpan)reader["Hora"]
            };

            if (ColumnExists(reader, "IdEmpleado") && reader["IdEmpleado"] != DBNull.Value)
            {
                registro.IdEmpleado = (int)reader["IdEmpleado"];
            }

            if (ColumnExists(reader, "IdServicio") && reader["IdServicio"] != DBNull.Value)
            {
                registro.IdServicio = (int)reader["IdServicio"];
            }

            if (ColumnExists(reader, "NombreEmpleado") && reader["NombreEmpleado"] != DBNull.Value)
            {
                registro.NombreEmpleado = (string)reader["NombreEmpleado"];
            }
            else if (ColumnExists(reader, "Empleado") && reader["Empleado"] != DBNull.Value)
            {
                registro.NombreEmpleado = (string)reader["Empleado"];
            }

            if (ColumnExists(reader, "IdEmpresa") && reader["IdEmpresa"] != DBNull.Value)
            {
                registro.IdEmpresa = (int)reader["IdEmpresa"];
            }

            if (ColumnExists(reader, "NombreEmpresa") && reader["NombreEmpresa"] != DBNull.Value)
            {
                registro.NombreEmpresa = (string)reader["NombreEmpresa"];
            }
            else if (ColumnExists(reader, "Empresa") && reader["Empresa"] != DBNull.Value)
            {
                registro.NombreEmpresa = (string)reader["Empresa"];
            }

            if (ColumnExists(reader, "IdLugar") && reader["IdLugar"] != DBNull.Value)
            {
                registro.IdLugar = (int)reader["IdLugar"];
            }

            if (ColumnExists(reader, "NombreLugar") && reader["NombreLugar"] != DBNull.Value)
            {
                registro.NombreLugar = (string)reader["NombreLugar"];
            }
            else if (ColumnExists(reader, "Lugar") && reader["Lugar"] != DBNull.Value)
            {
                registro.NombreLugar = (string)reader["Lugar"];
            }

            return registro;
        }

        public static List<Registro> MapList(SqlDataReader reader)
        {
            List<Registro> lista = new List<Registro>();
            while (reader.Read())
            {
                lista.Add(MapFromReader(reader));
            }
            return lista;
        }
    }
}
