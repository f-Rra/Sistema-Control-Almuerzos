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
            try
            {
                return ConfigurationManager.ConnectionStrings["BD_Control_Almuerzos"]?.ConnectionString;
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener cadena de conexión");
            }
        }

        public bool GuardarCadenaConexion(string nuevaCadena)
        {
            try
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "guardar cadena de conexión");
            }
        }

        public bool ProbarConexion(string cadenaConexion)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    return conexion.State == System.Data.ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "probar conexión");
            }
        }

        public InfoBaseDatos ObtenerInfoBaseDatos()
        {
            try
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener información de base de datos");
            }
        }

        public InfoRespaldo ObtenerUltimoRespaldo()
        {
            try
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener último respaldo");
            }
        }

        public bool CrearRespaldo(string rutaDestino)
        {
            try
            {
                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_CrearRespaldo");
                    datos.setearParametro("@RutaDestino", rutaDestino);
                    datos.ejecutarAccion();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "crear respaldo");
            }
        }

        public bool RestaurarRespaldo(string rutaArchivo)
        {
            try
            {
                using (var datos = new AccesoDatos())
                {
                    datos.setearProcedimiento("sp_RestaurarRespaldo");
                    datos.setearParametro("@RutaArchivo", rutaArchivo);
                    datos.ejecutarAccion();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "restaurar respaldo");
            }
        }

        public InfoAplicacion ObtenerInfoAplicacion()
        {
            try
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
            }
            catch (Exception ex)
            {
                throw NegocioException.FromDbException(ex, "obtener información de aplicación");
            }
        }
    }
}
