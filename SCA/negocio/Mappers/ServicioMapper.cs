using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace negocio.Mappers
{
    public static class ServicioMapper
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

        public static Servicio MapFromReader(SqlDataReader reader)
        {
            Servicio servicio = new Servicio
            {
                IdServicio = (int)reader["IdServicio"],
                Fecha = (DateTime)reader["Fecha"]
            };

            if (ColumnExists(reader, "IdLugar") && reader["IdLugar"] != DBNull.Value)
            {
                servicio.IdLugar = (int)reader["IdLugar"];
            }

            if (ColumnExists(reader, "NombreLugar") && reader["NombreLugar"] != DBNull.Value)
            {
                servicio.NombreLugar = (string)reader["NombreLugar"];
            }

            if (ColumnExists(reader, "Proyeccion") && reader["Proyeccion"] != DBNull.Value)
            {
                servicio.Proyeccion = (int)reader["Proyeccion"];
            }

            if (ColumnExists(reader, "DuracionMinutos") && reader["DuracionMinutos"] != DBNull.Value)
            {
                servicio.DuracionMinutos = (int)reader["DuracionMinutos"];
            }

            if (ColumnExists(reader, "TotalComensales") && reader["TotalComensales"] != DBNull.Value)
            {
                servicio.TotalComensales = (int)reader["TotalComensales"];
            }

            if (ColumnExists(reader, "TotalInvitados") && reader["TotalInvitados"] != DBNull.Value)
            {
                servicio.TotalInvitados = (int)reader["TotalInvitados"];
            }

            return servicio;
        }

        public static List<Servicio> MapList(SqlDataReader reader)
        {
            List<Servicio> lista = new List<Servicio>();
            while (reader.Read())
            {
                lista.Add(MapFromReader(reader));
            }
            return lista;
        }
    }
}
