# Clases Completas - Sistema de Control de Almuerzos

## 📁 Dominio (Capa de Entidades)

### **Clase Usuario eliminada** - Se maneja directamente en FormPrincipal (panel superior)

### **Empleado.cs**
```csharp
using System.ComponentModel;

namespace Dominio
{
    public class Empleado
    {
        public int id { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Apellido")]
        public string apellido { get; set; }

        [DisplayName("Credencial RFID")]
        public string idCredencial { get; set; }

        public int idEmpresa { get; set; }

        [DisplayName("Empresa")]
        public string nombreEmpresa { get; set; }

        [DisplayName("Estado")]
        public bool estado { get; set; }

        [DisplayName("Nombre Completo")]
        public string nombreCompleto
        {
            get { return $"{nombre} {apellido}"; }
        }

        // Método de negocio en la entidad
        public bool estaActivo()
        {
            return estado;
        }
    }
}
```

### **Empresa.cs**
```csharp
using System.ComponentModel;

namespace Dominio
{
    public class Empresa
    {
        public int id { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Estado")]
        public bool estado { get; set; }

        // Método de negocio en la entidad
        public bool estaActiva()
        {
            return estado;
        }
    }
}
```

### **Lugar.cs**
```csharp
using System.ComponentModel;

namespace Dominio
{
    public class Lugar
    {
        public int id { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [DisplayName("Estado")]
        public bool estado { get; set; }

        // Método de negocio en la entidad
        public bool estaActivo()
        {
            return estado;
        }
    }
}
```

### **Servicio.cs**
```csharp
using System;
using System.ComponentModel;

namespace Dominio
{
    public class Servicio
    {
        public int id { get; set; }

        public int idLugar { get; set; }

        [DisplayName("Lugar")]
        public string nombreLugar { get; set; }

        [DisplayName("Fecha")]
        public DateTime fecha { get; set; }

        [DisplayName("Total Comensales")]
        public int totalComensales { get; set; }

        [DisplayName("Total Invitados")]
        public int totalInvitados { get; set; }

        [DisplayName("Total General")]
        public int totalGeneral
        {
            get { return totalComensales + totalInvitados; }
        }

        [DisplayName("Estado")]
        public string estado
        {
            get { return totalComensales == 0 ? "Activo" : "Finalizado"; }
        }

        // Métodos de negocio en la entidad
        public bool estaActivo()
        {
            return totalComensales == 0;
        }

        public bool estaFinalizado()
        {
            return totalComensales > 0;
        }
    }
}
```

### **Registro.cs**
```csharp
using System;
using System.ComponentModel;

namespace Dominio
{
    public class Registro
    {
        public int id { get; set; }

        public int idEmpleado { get; set; }

        [DisplayName("Empleado")]
        public string nombreEmpleado { get; set; }

        public int idEmpresa { get; set; }

        [DisplayName("Empresa")]
        public string nombreEmpresa { get; set; }

        public int idServicio { get; set; }

        public int idLugar { get; set; }

        [DisplayName("Lugar")]
        public string nombreLugar { get; set; }

        [DisplayName("Fecha")]
        public DateTime fecha { get; set; }

        [DisplayName("Hora")]
        public TimeSpan hora { get; set; }

        [DisplayName("Hora Formateada")]
        public string horaFormateada
        {
            get { return hora.ToString(@"hh\:mm"); }
        }

        // Método de negocio en la entidad
        public bool esDelDiaActual()
        {
            return fecha.Date == DateTime.Now.Date;
        }
    }
}
```

## 📁 Negocio (Capa de Lógica)

### **AccesoDatos.cs** (Híbrido: Sistema-Gestion-Comercial + setearProcedimiento)
```csharp
using System;
using System.Data.SqlClient;

namespace Negocio
{
    class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private string ruta = "server=.\\SQLEXPRESS; database=SistemaControlAlmuerzos; integrated security=true";

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection(ruta);
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearProcedimiento(string sp)
        {
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

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
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
                return (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
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
    }
}
```

### **EmpleadoNegocio.cs**
```csharp
using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        // Listar todos los empleados activos
        public List<Empleado> listar()
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_ListarEmpleados");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.id = (int)datos.Lector["IdEmpleado"];
                    empleado.nombre = (string)datos.Lector["Nombre"];
                    empleado.apellido = (string)datos.Lector["Apellido"];
                    empleado.idCredencial = (string)datos.Lector["IdCredencial"];
                    empleado.idEmpresa = (int)datos.Lector["IdEmpresa"];
                    empleado.nombreEmpresa = (string)datos.Lector["Empresa"];
                    
                    lista.Add(empleado);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Buscar empleado por credencial RFID
        public Empleado buscarPorCredencial(string credencial)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_BuscarEmpleadoPorCredencial");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.setearParametro("@Credencial", credencial);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.id = (int)datos.Lector["IdEmpleado"];
                    empleado.nombre = (string)datos.Lector["Nombre"];
                    empleado.apellido = (string)datos.Lector["Apellido"];
                    empleado.idCredencial = (string)datos.Lector["IdCredencial"];
                    empleado.idEmpresa = (int)datos.Lector["IdEmpresa"];
                    empleado.nombreEmpresa = (string)datos.Lector["Empresa"];
                    
                    return empleado;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Buscar empleados por nombre
        public List<Empleado> buscarPorNombre(string nombre)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_BuscarEmpleadosPorNombre");
                datos.setearParametro("@Nombre", nombre);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                    empleado.Nombre = (string)datos.Lector["Nombre"];
                    empleado.Apellido = (string)datos.Lector["Apellido"];
                    empleado.IdCredencial = (string)datos.Lector["IdCredencial"];
                    empleado.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                    empleado.NombreEmpresa = (string)datos.Lector["Empresa"];
                    
                    lista.Add(empleado);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Empleados por empresa
        public List<Empleado> listarPorEmpresa(int idEmpresa)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarEmpleadosPorEmpresa");
                datos.setearParametro("@IdEmpresa", idEmpresa);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                    empleado.Nombre = (string)datos.Lector["Nombre"];
                    empleado.Apellido = (string)datos.Lector["Apellido"];
                    empleado.IdCredencial = (string)datos.Lector["IdCredencial"];
                    
                    lista.Add(empleado);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Empleados que no han almorzado en un servicio
        public List<Empleado> empleadosSinAlmorzar(int idServicio)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EmpleadosSinAlmorzar");
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                    empleado.Nombre = (string)datos.Lector["Nombre"];
                    empleado.Apellido = (string)datos.Lector["Apellido"];
                    empleado.IdCredencial = (string)datos.Lector["IdCredencial"];
                    empleado.IdEmpresa = (int)datos.Lector["IdEmpresa"];
                    empleado.NombreEmpresa = (string)datos.Lector["Empresa"];
                    
                    lista.Add(empleado);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
```

### **ServicioNegocio.cs**
```csharp
using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class ServicioNegocio
    {
        // Obtener servicio activo por lugar
        public Servicio obtenerServicioActivo(int idLugar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ObtenerServicioActivo");
                datos.setearParametro("@IdLugar", idLugar);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Servicio servicio = new Servicio();
servicio.id = (int)datos.Lector["IdServicio"];
                    servicio.idLugar = (int)datos.Lector["IdLugar"];
                    servicio.fecha = (DateTime)datos.Lector["Fecha"];
                    servicio.totalComensales = (int)datos.Lector["TotalComensales"];
                    servicio.totalInvitados = (int)datos.Lector["TotalInvitados"];
                    
                    return servicio;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Crear nuevo servicio
        public int crearServicio(int idLugar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AltaServicio");
                datos.setearParametro("@IdLugar", idLugar);
                return datos.ejecutarAccionReturn();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Finalizar servicio
        public void finalizarServicio(int idServicio, int totalComensales, int totalInvitados)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_FinalizarServicio");
                datos.setearParametro("@IdServicio", idServicio);
                datos.setearParametro("@TotalComensales", totalComensales);
                datos.setearParametro("@TotalInvitados", totalInvitados);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Listar servicios por fecha
        public List<Servicio> listarPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarServiciosPorFecha");
                datos.setearParametro("@FechaDesde", fechaDesde);
                datos.setearParametro("@FechaHasta", fechaHasta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Servicio servicio = new Servicio();
servicio.id = (int)datos.Lector["IdServicio"];
                    servicio.fecha = (DateTime)datos.Lector["Fecha"];
                    servicio.totalComensales = (int)datos.Lector["TotalComensales"];
                    servicio.totalInvitados = (int)datos.Lector["TotalInvitados"];
                    servicio.nombreLugar = (string)datos.Lector["Lugar"];
                    
                    lista.Add(servicio);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Listar servicios por lugar
        public List<Servicio> listarPorLugar(int idLugar, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarServiciosPorLugar");
                datos.setearParametro("@IdLugar", idLugar);
                datos.setearParametro("@FechaDesde", fechaDesde);
                datos.setearParametro("@FechaHasta", fechaHasta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Servicio servicio = new Servicio();
                    servicio.IdServicio = (int)datos.Lector["IdServicio"];
                    servicio.Fecha = (DateTime)datos.Lector["Fecha"];
                    servicio.TotalComensales = (int)datos.Lector["TotalComensales"];
                    servicio.TotalInvitados = (int)datos.Lector["TotalInvitados"];
                    
                    lista.Add(servicio);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
```

### **RegistroNegocio.cs**
```csharp
using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class RegistroNegocio
    {
        // Registrar empleado en servicio
        public void registrarEmpleado(int idEmpleado, int idEmpresa, int idServicio, int idLugar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_RegistrarEmpleado");
                datos.setearParametro("@IdEmpleado", idEmpleado);
                datos.setearParametro("@IdEmpresa", idEmpresa);
                datos.setearParametro("@IdServicio", idServicio);
                datos.setearParametro("@IdLugar", idLugar);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Listar registros de un servicio
        public List<Registro> listarPorServicio(int idServicio)
        {
            List<Registro> lista = new List<Registro>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarRegistrosPorServicio");
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Registro registro = new Registro();
                    registro.id = (int)datos.Lector["IdRegistro"];
                    registro.hora = (TimeSpan)datos.Lector["Hora"];
                    registro.fecha = (DateTime)datos.Lector["Fecha"];
                    registro.nombreEmpleado = (string)datos.Lector["Empleado"];
                    registro.nombreEmpresa = (string)datos.Lector["Empresa"];
                    
                    lista.Add(registro);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Verificar si empleado ya está registrado
        public bool empleadoYaRegistrado(int idEmpleado, int idServicio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_VerificarEmpleadoRegistrado");
                datos.setearParametro("@IdEmpleado", idEmpleado);
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["Existe"] > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Contar registros por servicio
        public int contarRegistrosPorServicio(int idServicio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ContarRegistrosPorServicio");
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["TotalRegistros"];
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
```

### **LugarNegocio.cs** (Reemplaza UsuarioNegocio.cs)
```csharp
using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class LugarNegocio
    {
        // Obtener todos los lugares para el ComboBox
        public List<Lugar> listar()
        {
            List<Lugar> lista = new List<Lugar>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_ListarLugares");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Lugar lugar = new Lugar();
                    lugar.id = (int)datos.Lector["IdLugar"];
                    lugar.nombre = (string)datos.Lector["Nombre"];
                    
                    lista.Add(lugar);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Obtener ID de lugar por nombre
        public int obtenerIdPorNombre(string nombreLugar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_ObtenerLugarPorNombre");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.setearParametro("@Nombre", nombreLugar);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["IdLugar"];
                }

                return 0; // Si no encuentra el lugar
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Validar contraseña de administrador (hardcodeada)
        public static bool validarPasswordAdmin(string password)
        {
            return password == "admin123"; // Contraseña hardcodeada
        }
    }
}
```

### **EmpresaNegocio.cs**
```csharp
using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class EmpresaNegocio
    {
        // Listar todas las empresas
        public List<Empresa> listar()
        {
            List<Empresa> lista = new List<Empresa>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_ListarEmpresas");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empresa empresa = new Empresa();
                    empresa.id = (int)datos.Lector["IdEmpresa"];
                    empresa.nombre = (string)datos.Lector["Nombre"];
                    
                    lista.Add(empresa);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Empleados por empresa
        public List<Empleado> empleadosPorEmpresa(int idEmpresa)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EmpleadosPorEmpresa");
                datos.setearParametro("@IdEmpresa", idEmpresa);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
                    empleado.Nombre = (string)datos.Lector["Nombre"];
                    empleado.Apellido = (string)datos.Lector["Apellido"];
                    empleado.IdCredencial = (string)datos.Lector["IdCredencial"];
                    
                    lista.Add(empleado);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
```

### **ReporteNegocio.cs**
```csharp
using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class ReporteNegocio
    {
        // Estadísticas del servicio activo
        public dynamic estadisticasServicioActivo(int idServicio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SP_EstadisticasServicioActivo");
                datos.setearTipoComando(System.Data.CommandType.StoredProcedure);
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new
                    {
                        TotalEmpleados = (int)datos.Lector["TotalEmpleados"],
                        TotalInvitados = (int)datos.Lector["TotalInvitados"],
                        TotalGeneral = (int)datos.Lector["TotalGeneral"]
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Registros por empresa en un servicio
        public List<dynamic> registrosPorEmpresa(int idServicio)
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_RegistrosPorEmpresa");
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Empresa = (string)datos.Lector["Empresa"],
                        Cantidad = (int)datos.Lector["Cantidad"]
                    };
                    
                    lista.Add(item);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Picos de concurrencia por hora
        public List<dynamic> picosConcurrencia(int idServicio)
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_PicosConcurrencia");
                datos.setearParametro("@IdServicio", idServicio);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Hora = (int)datos.Lector["Hora"],
                        Cantidad = (int)datos.Lector["Cantidad"]
                    };
                    
                    lista.Add(item);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Resumen diario por lugar
        public List<dynamic> resumenDiarioPorLugar(DateTime fecha)
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ResumenDiarioPorLugar");
                datos.setearParametro("@Fecha", fecha);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Fecha = (DateTime)datos.Lector["Fecha"],
                        Lugar = (string)datos.Lector["Lugar"],
                        TotalComensales = (int)datos.Lector["TotalComensales"],
                        TotalInvitados = (int)datos.Lector["TotalInvitados"],
                        Total = (int)datos.Lector["Total"]
                    };
                    
                    lista.Add(item);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Top 5 empresas con más asistencia
        public List<dynamic> topEmpresasAsistencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_TopEmpresasAsistencia");
                datos.setearParametro("@FechaDesde", fechaDesde);
                datos.setearParametro("@FechaHasta", fechaHasta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Empresa = (string)datos.Lector["Empresa"],
                        TotalAsistencias = (int)datos.Lector["TotalAsistencias"]
                    };
                    
                    lista.Add(item);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Promedio diario de asistencia
        public double promedioDiarioAsistencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_PromedioDiarioAsistencia");
                datos.setearParametro("@FechaDesde", fechaDesde);
                datos.setearParametro("@FechaHasta", fechaHasta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return Convert.ToDouble(datos.Lector["PromedioDiario"]);
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Estadísticas del día actual
        public List<dynamic> estadisticasDiaActual()
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EstadisticasDiaActual");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Lugar = (string)datos.Lector["Lugar"],
                        ServiciosHoy = (int)datos.Lector["ServiciosHoy"],
                        TotalEmpleados = (int)datos.Lector["TotalEmpleados"],
                        TotalInvitados = (int)datos.Lector["TotalInvitados"],
                        TotalGeneral = (int)datos.Lector["TotalGeneral"]
                    };
                    
                    lista.Add(item);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Tendencia últimos 7 días
        public List<dynamic> tendenciaUltimos7Dias()
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_TendenciaUltimos7Dias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Fecha = (DateTime)datos.Lector["Fecha"],
                        TotalDiario = (int)datos.Lector["TotalDiario"]
                    };
                    
                    lista.Add(item);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        // Empleados más frecuentes
        public List<dynamic> empleadosMasFrecuentes(int meses = 1)
        {
            List<dynamic> lista = new List<dynamic>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EmpleadosMasFrecuentes");
                datos.setearParametro("@Meses", meses);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var item = new
                    {
                        Empleado = (string)datos.Lector["Empleado"],
                        Empresa = (string)datos.Lector["Empresa"],
                        Asistencias = (int)datos.Lector["Asistencias"]
                    };
                    
                    lista.Add(item);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
```

---

**Versión**: 1.0  
**Fecha**: Enero 2024  
**Autor**: Equipo de Desarrollo  
**Basado en**: Patrones del proyecto "Tienda de Videojuegos"
