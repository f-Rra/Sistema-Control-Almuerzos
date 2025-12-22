using System.Data.SqlClient;
using Dominio;

namespace Negocio.Mappers
{
    public static class ConfiguracionMapper
    {
        public static InfoBaseDatos MapInfoBaseDatos(SqlDataReader reader)
        {
            if (reader.Read())
            {
                return new InfoBaseDatos
                {
                    NombreBaseDatos = reader["NombreBaseDatos"].ToString(),
                    TamañoMB = (decimal)reader["TamañoMB"],
                    FechaCreacion = (System.DateTime)reader["FechaCreacion"],
                    UltimaActualizacion = (System.DateTime)reader["UltimaActualizacion"]
                };
            }
            return null;
        }

        public static InfoRespaldo MapInfoRespaldo(SqlDataReader reader)
        {
            if (reader.Read())
            {
                return new InfoRespaldo
                {
                    FechaRespaldo = (System.DateTime)reader["FechaRespaldo"],
                    TamañoMB = (decimal)reader["TamañoMB"]
                };
            }
            return null;
        }

        public static InfoAplicacion MapInfoAplicacion()
        {
            return new InfoAplicacion
            {
                Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                FechaCompilacion = System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location),
                Framework = ".NET Framework 4.8.1",
                UILibrary = "ReaLTaiizor 3.8.1.3"
            };
        }
    }
}
