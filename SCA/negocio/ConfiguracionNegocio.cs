using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using Dominio;

namespace Negocio
{
    public class ConfiguracionNegocio
    { 
        public string ObtenerCadenaConexion()
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                return ConfigurationManager.ConnectionStrings["BD_Control_Almuerzos"]?.ConnectionString;
            }, "obtener cadena de conexión");
        }

        public bool GuardarCadenaConexion(string nuevaCadena)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

                if (connectionStringsSection.ConnectionStrings["BD_Control_Almuerzos"] != null)
                {
                    connectionStringsSection.ConnectionStrings["BD_Control_Almuerzos"].ConnectionString = nuevaCadena;
                }
                else
                {
                    connectionStringsSection.ConnectionStrings.Add(new ConnectionStringSettings("BD_Control_Almuerzos", nuevaCadena));
                }

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                return true;
            }, "guardar cadena de conexión");
        }

        public bool ProbarConexion(string cadenaConexion)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    return conexion.State == System.Data.ConnectionState.Open;
                }
            }, "probar conexión");
        }

        public InfoBaseDatos ObtenerInfoBaseDatos()
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                InfoBaseDatos info = null;
                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ObtenerInfoBaseDatos");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        info = new InfoBaseDatos
                        {
                            NombreBaseDatos = (string)datos.Lector["NombreBaseDatos"],
                            TamañoMB = (decimal)datos.Lector["TamañoMB"],
                            FechaCreacion = (DateTime)datos.Lector["FechaCreacion"],
                            UltimaActualizacion = (DateTime)datos.Lector["UltimaActualizacion"]
                        };
                    }
                }
                return info;
            }, "obtener información de base de datos");
        }

        public InfoRespaldo ObtenerUltimoRespaldo()
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                InfoRespaldo info = null;
                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_ObtenerUltimoRespaldo");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        info = new InfoRespaldo
                        {
                            FechaRespaldo = (DateTime)datos.Lector["FechaRespaldo"],
                            RutaArchivo = (string)datos.Lector["RutaArchivo"],
                            TamañoMB = (decimal)datos.Lector["TamañoMB"]
                        };
                    }
                }
                return info;
            }, "obtener último respaldo");
        }

        public bool CrearRespaldo(string rutaDestino)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_CrearRespaldo");
                    datos.setearParametro("@RutaDestino", rutaDestino);
                    datos.ejecutarAccion();
                    return true;
                }
            }, "crear respaldo");
        }

        public bool RestaurarRespaldo(string rutaArchivo)
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_RestaurarRespaldo");
                    datos.setearParametro("@RutaArchivo", rutaArchivo);
                    datos.ejecutarAccion();
                    return true;
                }
            }, "restaurar respaldo");
        }

        public InfoAplicacion ObtenerInfoAplicacion()
        {
            return ExceptionHelper.EjecutarConManejo(() =>
            {
                var assembly = Assembly.GetExecutingAssembly();
                var version = assembly.GetName().Version;
                var fechaCompilacion = System.IO.File.GetLastWriteTime(assembly.Location);

                return new InfoAplicacion
                {
                    Version = version.ToString(),
                    FechaCompilacion = fechaCompilacion,
                    Framework = ".NET Framework 4.8",
                    UILibrary = "ReaLTaiizor & Winforms"
                };
            }, "obtener información de aplicación");
        }
    }
}
