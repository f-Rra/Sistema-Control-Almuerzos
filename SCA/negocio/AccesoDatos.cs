using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Negocio
{
    class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private string ruta;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            ruta = ConfigurationManager.ConnectionStrings["BD_Control_Almuerzos"]?.ConnectionString;
            
            if (string.IsNullOrEmpty(ruta))
            {
                throw new Exception("No se encontró la cadena de conexión 'BD_Control_Almuerzos' en App.config");
            }
            
            conexion = new SqlConnection(ruta);
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "configurar consulta SQL");
                throw;
            }
        }

        public void setearProcedimiento(string sp)
        {
            try
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = sp;
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "configurar procedimiento almacenado");
                throw;
            }
        }
        public void setearTipoComando(System.Data.CommandType tipo)
        {
            try
            {
                comando.CommandType = tipo;
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "configurar tipo de comando");
                throw;
            }
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "ejecutar lectura en base de datos");
                throw;
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "ejecutar acción en base de datos");
                throw;
            }
            finally
            {
                conexion.Close();
                comando.Parameters.Clear();
            }
        }

        public int ejecutarAccionReturn()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                var result = comando.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return 0;
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "ejecutar acción con retorno en base de datos");
                throw;
            }
            finally
            {
                conexion.Close();
                comando.Parameters.Clear();
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            try
            {
                comando.Parameters.AddWithValue(nombre, valor);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "configurar parámetro");
                throw;
            }
        }

        public void cerrarConexion()
        {
            try
            {
                if (lector != null)
                    lector.Close();
                conexion.Close();
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManejarExcepcionBD(ex, "cerrar conexión");
                throw;
            }
        }
    }
}