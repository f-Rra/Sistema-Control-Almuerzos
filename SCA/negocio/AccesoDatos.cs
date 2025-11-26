using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Negocio
{
    class AccesoDatos : IDisposable
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private string ruta;
        private bool disposed = false;

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
            comando.CommandTimeout = 120; 
        }

        public void setearConsulta(string consulta)
        {
            comando.Parameters.Clear();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearProcedimiento(string sp)
        {
            comando.Parameters.Clear();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void setearTipoComando(System.Data.CommandType tipo)
        {
            comando.CommandType = tipo;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
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
            finally
            {
                conexion.Close();
                comando.Parameters.Clear();
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (lector != null && !lector.IsClosed)
                    {
                        lector.Close();
                        lector.Dispose();
                    }
                    
                    if (comando != null)
                    {
                        comando.Dispose();
                    }
                    
                    if (conexion != null && conexion.State != System.Data.ConnectionState.Closed)
                    {
                        conexion.Close();
                        conexion.Dispose();
                    }
                }
                disposed = true;
            }
        }

        ~AccesoDatos()
        {
            Dispose(false);
        }

        #endregion
    }
}