using System.Data.SqlClient;
using Dominio;

namespace negocio.Mappers
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
                Framework = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
                UILibrary = "ReaLTaiizor 3.8.1.3"
            };
        }
    }
}
