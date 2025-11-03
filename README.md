# 🍽️ Sistema de Control de Almuerzos

Sistema completo de gestión de comedores corporativos desarrollado en C# con Windows Forms, diseñado para el registro eficiente de comensales mediante credenciales RFID y generación de reportes automáticos.

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue)
![C#](https://img.shields.io/badge/C%23-10.0-green)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-red)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-lightblue)

---

##  Características Principales

-  **Arquitectura de 3 capas** (Dominio, Negocio, Presentación)
-  **Registro rápido de comensales** por ID de credencial (preparado para RFID)
-  **Gestión completa de empleados** con asignación de credenciales
-  **Sistema de servicios por jornada** (comedor y quincho)
-  **Visualización en tiempo real** para personal de cocina
-  **Reportes automáticos** con exportación a PDF
-  **Estadísticas avanzadas** por empresa, período y lugar
-  **Procedimientos almacenados** para todas las operaciones críticas
-  **Validaciones robustas** (duplicados, servicio activo, estado de empleado)
-  **Interfaz moderna** con diseño profesional
-  **Manejo de invitados** sin datos personales
-  **Registro manual alternativo** para casos sin credencial
-  **Optimizado para alta concurrencia** en horarios pico

##  Funcionalidades del Sistema

###  Registro de Comensales

**Método Actual: Ingreso por Teclado**
- Registro mediante ID de credencial
- Validación automática de duplicados
- Confirmación visual inmediata

**Método Futuro: RFID Automático**
- Lectura automática de credencial
- Registro instantáneo (<1 segundo)
- Cero intervención del operador
- Guía completa de implementación incluida

**Características:**
-  Validación de empleado activo
-  Detección de registros duplicados en servicio actual
-  Vinculación automática al servicio activo
-  Registro alternativo manual (sin credencial)
-  Gestión de invitados (solo cantidad, sin datos personales)

###  Gestión de Empleados

**Operaciones ABML Completas:**
- **Alta**: Crear nuevos empleados con datos completos
- **Modificación**: Actualizar información de empleados
- **Baja lógica**: Desactivar empleados manteniendo historial
- **Listado y Búsqueda**: Filtros por nombre, apellido, empresa

**Gestión de Credenciales:**
- Asignación de ID de credencial a empleados
- Reasignación de credenciales (pérdida/daño)
- Validación de unicidad de credenciales

**Organización por Empresa:**
- Agrupación de empleados por compañía
- Estadísticas por empresa
- Reportes segmentados

###  Gestión de Servicios

**Control de Jornadas:**
- Inicio de servicio por lugar (Comedor/Quincho)
- Registro de proyección de comensales
- Total de invitados esperados
- Cierre de servicio con estadísticas finales

**Información Automática:**
-  Duración del servicio
-  Total de comensales reales vs proyectados
-  Comparativa de eficiencia

###  Panel Principal

**Visualización Instantánea:**
- Listado de todos los registros del servicio actual
- Contador principal de comensales
- Total de invitados
- Comparativa proyección vs real
- Actualización automática sin recargas

###  Reportes y Estadísticas

**Tipos de Reportes Disponibles:**

**1. Reporte Diario**
- Total de comensales por día
- Desglose por empresa
- Total de invitados
- Comparativa con proyección

**2. Reporte por Período**
- Rango de fechas personalizable
- Totales acumulados y promedios
- Tendencias semanales/mensuales
- Identificación de picos de asistencia

**3. Reporte por Empresa**
- Estadísticas específicas por compañía
- Evolución temporal
- Porcentaje de participación
- Análisis de regularidad

**4. Estadísticas Generales**
- Distribución por día de la semana
- Comparativa comedor vs quincho
- Análisis de proyecciones vs realidad
- Cobertura histórica

**Exportación:**
-  Formato PDF 
-  Gráficos y visualizaciones
-  Encabezados corporativos

---

##  Arquitectura del Sistema

```
Sistema-Control-Almuerzos/
├── SCA/
│   ├── dominio/                   # Capa de Entidades
│   │   ├── Empleado.cs            # Modelo de empleados
│   │   ├── Empresa.cs             # Modelo de empresas
│   │   ├── Lugar.cs               # Modelo de lugares (comedor/quincho)
│   │   ├── Servicio.cs            # Modelo de servicios por jornada
│   │   ├── Registro.cs            # Modelo de registros de almuerzos
│   │   └── Estadisticas.cs        # Modelo de datos estadísticos
│   │
│   ├── negocio/                   # Capa de Lógica de Negocio
│   │   ├── AccesoDatos.cs         # Clase centralizada para BD
│   │   ├── EmpleadoNegocio.cs     # Lógica de empleados
│   │   ├── EmpresaNegocio.cs      # Lógica de empresas
│   │   ├── LugarNegocio.cs        # Lógica de lugares
│   │   ├── ServicioNegocio.cs     # Lógica de servicios
│   │   ├── RegistroNegocio.cs     # Lógica de registros
│   │   ├── EstadisticasNegocio.cs # Lógica de estadísticas
│   │   ├── ReporteNegocio.cs      # Generación de reportes PDF
│   │   └── ExceptionHelper.cs     # Manejo centralizado de errores
│   │
│   └── app/                       # Capa de Presentación
│       ├── Program.cs             # Punto de entrada
│       ├── frmPrincipal.cs        # Ventana principal
│       ├── UserControls/          # Controles de usuario modulares
│       │   ├── ucVistaPrincipal.cs       # Pantalla de bienvenida
│       │   ├── ucRegistroManual.cs       # Registro de comensales
│       │   ├── ucEmpleados.cs            # Gestión de empleados
│       │   ├── ucEmpresas.cs             # Gestión de empresas
│       │   ├── ucConfiguracion.cs        # Configuración de servicios
│       │   ├── ucReportes.cs             # Sistema de reportes
│       │   ├── ucEstadisticas.cs         # Análisis estadístico
│       │   └── ucAdmin.cs                # Panel administrativo
│       └── Iconos/                # Recursos gráficos
│
├── Script_Sistema_Control_Almuerzos.sql  # Script completo de BD
├── Procedimientos_Vistas_Triggers.sql    # Objetos de BD
├── Datos_Iniciales.sql                   # Datos de prueba
├── DER_SdCdA.drawio                      # Diagrama ER
├── MANUAL_USUARIO.md                     # Manual para el usuario
└── README.md                             # Este archivo
```

##  Base de Datos

### Modelo de Datos

**EMPLEADOS**
```sql
- IdEmpleado (INT, PK, Identity)
- Nombre (VARCHAR(50), NOT NULL)
- Apellido (VARCHAR(50), NOT NULL)
- IdEmpresa (INT, FK, NOT NULL)
- IdCredencial (VARCHAR(20), UNIQUE)
- Estado (BIT, DEFAULT 1)
```

**EMPRESAS**
```sql
- IdEmpresa (INT, PK, Identity)
- Nombre (VARCHAR(100), NOT NULL)
- Estado (BIT, DEFAULT 1)
```

**LUGARES**
```sql
- IdLugar (INT, PK, Identity)
- Nombre (VARCHAR(50), NOT NULL)
- Descripcion (VARCHAR(200))
- Estado (BIT, DEFAULT 1)
```

**SERVICIOS**
```sql
- IdServicio (INT, PK, Identity)
- IdLugar (INT, FK, NOT NULL)
- Fecha (DATE, NOT NULL)
- Proyeccion (INT)
- DuracionMinutos (INT)
- TotalComensales (INT, DEFAULT 0)
- TotalInvitados (INT, DEFAULT 0)
- Estado (VARCHAR(20), DEFAULT 'Activo')
```

**REGISTROS**
```sql
- IdRegistro (INT, PK, Identity)
- IdEmpleado (INT, FK, NOT NULL)
- IdEmpresa (INT, FK, NOT NULL)
- IdServicio (INT, FK, NOT NULL)
- Fecha (DATE, NOT NULL)
- Hora (TIME, NOT NULL)
- IdLugar (INT, FK, NOT NULL)
```

### Procedimientos Almacenados

#### Gestión de Empleados
- `sp_ListarEmpleados`: Listado completo con empresa y credencial
- `sp_BuscarEmpleadoPorId`: Búsqueda específica por ID
- `sp_BuscarEmpleadoPorCredencial`: Búsqueda por ID de credencial
- `sp_AltaEmpleado`: Inserción con validaciones
- `sp_ModificarEmpleado`: Actualización completa
- `sp_BajaEmpleado`: Baja lógica
- `sp_AsignarCredencial`: Asignar ID de credencial único

#### Gestión de Servicios
- `sp_IniciarServicio`: Crear nuevo servicio activo
- `sp_FinalizarServicio`: Cerrar servicio con cálculos
- `sp_ObtenerServicioActivo`: Obtener servicio en curso
- `sp_ListarServicios`: Historial de servicios

#### Gestión de Registros
- `sp_RegistrarAlmuerzo`: Registro principal con validaciones
- `sp_RegistrarInvitados`: Registro de invitados sin datos
- `sp_VerificarRegistroDuplicado`: Validar si ya se registró
- `sp_ListarRegistrosPorServicio`: Registros del servicio actual
- `sp_ContarRegistrosPorServicio`: Total de comensales

#### Reportes y Estadísticas
- `sp_ReporteDiario`: Estadísticas de un día específico
- `sp_ReportePorPeriodo`: Análisis de rango de fechas
- `sp_ReportePorEmpresa`: Datos específicos de empresa
- `sp_EstadisticasGenerales`: Resumen general del sistema

### Vistas

- `vw_EmpleadosCompletos`: Vista completa de empleados con empresa
- `vw_RegistrosCompletos`: Registros con datos de empleado y empresa
- `vw_ServiciosCompletos`: Servicios con estadísticas calculadas
- `vw_EstadisticasPorEmpresa`: Agrupación de datos por compañía

### Triggers

- `tr_ActualizarTotalComensales`: Actualiza contador en SERVICIOS automáticamente
- `tr_ValidarCredencialUnica`: Valida unicidad de credenciales
- `tr_ValidarServicioActivo`: Previene múltiples servicios activos simultáneos

---

##  Instalación y Configuración

### Requisitos del Sistema

**Software Requerido:**
- **Visual Studio 2019 o superior**
- **.NET Framework 4.8**
- **SQL Server 2019 o superior** 
- **Windows 10 o superior**

**Hardware Mínimo:**
- Procesador: Intel Core i3 o equivalente
- RAM: 4 GB (recomendado 8 GB)
- Espacio en disco: 500 MB

**Hardware Futuro (RFID):**
- Lector RFID 
- Conexión USB
- Credenciales RFID compatibles

### Módulos del Sistema

| Módulo | Descripción |
|--------|-------------|
| **ucVistaPrincipal** | Pantalla de bienvenida y navegación | 
| **ucRegistroManual** | Registro de comensales | 
| **ucEmpleados** | Gestión de empleados y credenciales | 
| **ucEmpresas** | Gestión de empresas | 
| **ucConfiguracion** | Configuración del sistema | 
| **ucReportes** | Generación de reportes | 
| **ucEstadisticas** | Análisis estadístico |
| **ucAdmin** | Panel administrativo general | 

---

##  Características Técnicas

### Seguridad

- **Validación de entrada**: Todos los inputs son validados
- **Prevención de SQL Injection**: Uso exclusivo de parámetros y SPs
- **Transacciones seguras**: Rollback automático en errores
- **Baja lógica**: No se eliminan datos, solo se desactivan
- **Integridad referencial**: Llaves foráneas con restricciones

### Rendimiento

- **Índices optimizados**: En campos de búsqueda frecuente
- **Consultas parametrizadas**: Para mejor plan de ejecución
- **Stored Procedures**: Lógica pre-compilada en servidor
- **Actualización eficiente**: Solo datos necesarios en tiempo real

### Validaciones Implementadas

**A Nivel de Base de Datos:**
-  Unicidad de credenciales (Triggers)
-  Integridad referencial (FK Constraints)
-  Validación de servicio único activo (Triggers)
-  Actualización automática de contadores (Triggers)

**A Nivel de Negocio:**
-  Empleado debe estar activo
-  No puede registrarse dos veces en el mismo servicio
-  Debe existir un servicio activo para registrar
-  Credencial debe ser única al asignar
-  No se puede cerrar un servicio sin inicio

**A Nivel de Presentación:**
-  Campos obligatorios marcados
-  Formato de datos validado
- Confirmaciones antes de operaciones críticas
-  Feedback visual inmediato

##  Roadmap

###  Fase 1: Sistema Base (COMPLETADA)

**Estado**: Funcional y listo para producción

-  Diseño e implementación de base de datos
-  Arquitectura en 3 capas completa
-  Módulo de gestión de empleados
-  Módulo de gestión de empresas y lugares
-  Sistema de servicios por jornada
-  Registro por ingreso de ID (teclado)
-  Panel de visualización para cocina
-  Sistema de reportes y estadísticas
-  Exportación a PDF
-  Interfaz completa y funcional
-  Validaciones robustas
-  Documentación técnica

###  Fase 2: Integración RFID (PLANIFICADA)

**Estado**: Documentado para implementación futura

**Objetivos:**
-  Guía de selección de hardware RFID
-  Configuración de lectores (USB/Serial)
-  Modificación de capa de presentación
-  Testing con credenciales reales
-  Manual de implementación
-  Procedimiento de migración sin downtime

**Prerequisitos:**
- Adquisición de lectores RFID compatibles
- Credenciale con chip RFID
- Configuración de puerto de comunicación

##  Documentación

### Documentos Disponibles

| Documento | Descripción | Ubicación |
|-----------|-------------|-----------|
| **README.md** | Documentación técnica completa (este archivo) | Raíz del proyecto |
| **MANUAL_USUARIO.md** | Guía para usuarios finales | Raíz del proyecto |
| **DER_SdCdA.drawio** | Diagrama Entidad-Relación | Raíz del proyecto |
| **Script_Sistema_Control_Almuerzos.sql** | Script completo de creación de BD | Raíz del proyecto |
| **Procedimientos_Vistas_Triggers.sql** | Objetos de BD detallados | Raíz del proyecto |
| **Datos_Iniciales.sql** | Datos de prueba para testing | Raíz del proyecto |

### Guías Específicas

**Para Desarrolladores:**
- Leer este README completo
- Revisar arquitectura en sección correspondiente
- Consultar `ExceptionHelper.cs` para manejo de errores

**Para Usuarios:**
- Leer `MANUAL_USUARIO.md`
- Revisar flujos de trabajo comunes
- Consultar sección de Preguntas Frecuentes

---

##  Estadísticas del Proyecto

- **Líneas de código**: ~8,000+ (C# + SQL)
- **Clases**: 25+
- **Procedimientos almacenados**: 20+
- **Tiempo de desarrollo**: 3 meses
- **Tecnologías**: 5 (C#, SQL Server, Windows Forms, ReaLTaiizor, iTextSharp)

---

##  Enlaces Útiles

- [Repositorio en GitHub](https://github.com/f-Rra/Sistema-Control-Almuerzos)
- [Documentación de .NET Framework](https://docs.microsoft.com/en-us/dotnet/framework/)
- [SQL Server Documentation](https://docs.microsoft.com/en-us/sql/sql-server/)
- [ReaLTaiizor UI Components](https://github.com/Taiizor/ReaLTaiizor)
- [iTextSharp Documentation](https://github.com/itext/itextsharp)

---

**Facundo Herrera**
- 🎓 Estudiante de Tecnicatura Universitaria en Programación - UTN
- 🐙 GitHub: [@f-Rra](https://github.com/f-Rra)
- 📧 Email: [Facundo.Herrera@alumnos.frgp.utn.edu.ar]

---