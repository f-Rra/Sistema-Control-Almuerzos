# Sistema Control de Almuerzos

Sistema completo de gestión de comedores corporativos desarrollado en C# con Windows Forms, diseñado para el registro eficiente de comensales mediante credenciales RFID y generación de reportes automáticos.

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue)
![C#](https://img.shields.io/badge/C%23-10.0-green)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-red)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-lightblue)
![Status](https://img.shields.io/badge/Status-Production%20Ready-brightgreen)
![Maintained](https://img.shields.io/badge/Maintained-Yes-green)

---

##  Características Principales

-  **Arquitectura de 3 capas** (Dominio, Negocio, Presentación)
-  **Registro rápido de comensales** por ID de credencial (preparado para RFID)
-  **Gestión completa de empleados y empresas** con asignación de credenciales
-  **Sistema de servicios por jornada** (comedor y quincho)
-  **Visualización en tiempo real** para personal de cocina
-  **Reportes automáticos** con exportación a PDF
-  **Estadísticas avanzadas** por empresa, período y lugar
-  **Procedimientos almacenados** para todas las operaciones críticas
-  **Validaciones robustas** (duplicados, servicio activo, estado de empleado)
-  **Interfaz moderna** con diseño personalizado
-  **Manejo de invitados** sin datos personales
-  **Registro manual alternativo** para casos sin credencial
-  **Optimizado para alta concurrencia** en horarios pico
-  **Sistema de respaldos automáticos y manuales**
-  **Panel de configuración avanzada**

##  Funcionalidades del Sistema


###  Panel Principal

![Panel Principal](./docs/screenshots/panel_principal.png)

**Contenedor Principal del Sistema:**

**Lista de Últimos Servicios:**
- Visualización de los servicios más recientes
- Ordenados cronológicamente (más recientes primero)
- Información resumida: fecha, lugar, proyección
- Selección rápida de servicio para consulta

**Detalles del Servicio Seleccionado:**
- Información completa del servicio seleccionado
- Fecha y hora de inicio
- Lugar (Comedor/Quincho)
- Proyección inicial de comensales
- Total de invitados esperados
- Duración del servicio (cronómetro en tiempo real)
- Estadísticas actuales:
  - Contador principal de comensales registrados
  - Total de invitados
  - Comparativa proyección vs real
  - Actualización automática sin recargas

###  Registro de Comensales

![Registro de Comensales](./docs/screenshots/registro_comensales.png)

**Método Actual: Ingreso por Teclado**
- Campo de entrada para ID de credencial
- Validación automática de duplicados
- Confirmación visual inmediata con ventana temporal
- Información mostrada:
  - Nombre completo del empleado
  - Empresa
  - Hora exacta de registro
- Ventana de confirmación desaparece automáticamente (4 segundos)

**Método Futuro: RFID Automático**
- Lectura automática de credencial
- Registro instantáneo (<1 segundo)
- Cero intervención del operador
- Guía completa de implementación incluida

**Visualización en Tiempo Real:**
- Listado completo de todos los registros del servicio actual
- Información por columnas:
  - Nombre y apellido del comensal
  - Empresa de pertenencia
  - Hora de registro (formato HH:mm:ss)
- Actualización automática al registrar nuevo comensal
- Tabla optimizada para lectura rápida por personal de cocina

**Características del Sistema de Registro:**
-  Validación de empleado activo
-  Detección de registros duplicados en servicio actual
-  Vinculación automática al servicio activo
-  Registro alternativo manual (sin credencial)
-  Gestión de invitados (solo cantidad, sin datos personales)
-  Contador automático de comensales
-  Sincronización con estadísticas del panel principal

###  Gestión de Empleados

![Gestión de Empleados](./docs/screenshots/gestion_empleados.png)

**Operaciones ABML Completas:**
- **Alta**: Crear nuevos empleados con datos completos
- **Baja lógica**: Desactivar empleados manteniendo historial
- **Modificación**: Actualizar información de empleados
- **Listado y Búsqueda**: Filtros por nombre, apellido, empresa

**Gestión de Credenciales:**
- Asignación de ID de credencial a empleados
- Reasignación de credenciales (pérdida/daño)
- Validación de unicidad de credenciales


###  Gestión de Empresas

![Gestión de Empresas](./docs/screenshots/gestion_empresas.png)

**Operaciones ABML Completas:**
- **Alta**: Crear nuevas empresas con nombre y descripción
- **Baja lógica**: Desactivar empresas manteniendo historial
- **Modificación**: Actualizar información de empresas existentes
- **Listado y Búsqueda**: Filtros por nombre, estado activo/inactivo

**Visualización de Estadísticas:**
- Total de empleados por empresa
- Total de asistencias del mes actual
- Identificación rápida de empresas sin empleados activos

**Validaciones Implementadas:**
-  No se puede eliminar empresa con empleados activos
-  Nombre de empresa único (no duplicados)
-  Al desactivar empresa, se sugiere desactivar empleados asociados
-  Advertencias antes de operaciones críticas

**Integración con el Sistema:**
- Vinculación automática con módulo de empleados
- Datos utilizados en reportes de asistencia por empresa
- Estadísticas mensuales actualizadas en tiempo real
- Filtrado de registros por compañía

###  Gestión de Servicios

![Gestión de Servicios](./docs/screenshots/gestion_servicios.png)

**Control de Jornadas:**
- Inicio de servicio por lugar (Comedor/Quincho)
- Registro de proyección de comensales
- Total de invitados esperados
- Cierre de servicio con estadísticas finales

**Información Automática:**
-  Estado, duración y progreso del servicio
-  Total de comensales reales vs proyectados
-  Comparativa de eficiencia

###  Configuración del Sistema

![Configuración del Sistema](./docs/screenshots/configuracion.png)

**Panel de Administración Completo:**

**1. Configuración de Base de Datos**

![Configuración de Base de Datos](./docs/screenshots/config_basedatos.png)

-  Modificar cadena de conexión en tiempo real
-  Probar conectividad antes de guardar
-  Ver información de la BD:
  - Nombre de la base de datos
  - Tamaño en MB
  - Fecha de creación
  - Última actualización
-  Estadísticas de uso del servidor

**2. Sistema de Respaldos**

![Sistema de Respaldos](./docs/screenshots/config_respaldos.png)

**Respaldo Manual:**
- Crear backup inmediato a ubicación específica
- Selección de carpeta destino
- Útil antes de actualizaciones o cambios importantes

**Respaldo Automático Programado:**
-  **Mensual**: Backup cada mes
- Configuración de ruta de destino
- Historial de último respaldo (fecha, ubicación, tamaño)

**Restauración:**
- Restaurar desde archivo de backup (.bak)
- Selección de archivo de respaldo
- Proceso guiado con confirmaciones
- Sobrescribe completamente la BD actual

**3. Información de la Aplicación**

![Información de la Aplicación](./docs/screenshots/config_info.png)

- Versión del sistema
- Fecha de compilación
- Framework utilizado (.NET Framework 4.8)
- Librerías UI (ReaLTaiizor & WinForms)

###  Reportes y Estadísticas

![Módulo de Reportes](./docs/screenshots/reportes.png)

**Sistema de Reportes Avanzados:**

**1. Lista de Servicios**

![Reporte de Lista de Servicios](./docs/screenshots/reporte_servicios.png)

- Todos los servicios del período seleccionado
- Fecha, lugar, proyección, duración del servicio
- Total de comensales reales vs proyección
- Total de invitados
- Total general (comensales + invitados)
- Útil para revisión histórica y análisis día por día

**2. Asistencias por Empresas**

![Reporte de Asistencias por Empresas](./docs/screenshots/reporte_empresas.png)

- Total de asistencias por cada compañía del predio
- Comparativa y ranking entre empresas
- Útil para facturación segmentada por empresa
- Análisis de participación corporativa
- Identificar empresas con mayor/menor uso del comedor

**3. Cobertura vs Proyección**

![Reporte de Cobertura vs Proyección](./docs/screenshots/reporte_cobertura.png)

- Comparación entre proyección inicial y asistencia real
- Porcentaje de cobertura por servicio
- Diferencia absoluta (positiva/negativa)
- Mejora de planificación y compras futuras

**4. Distribución por Día de Semana**

![Reporte de Distribución por Día](./docs/screenshots/reporte_diasemana.png)

- Patrones de asistencia semanal
- Total acumulado por cada día de la semana
- Identificación de días pico y días bajos
- Optimización de compras según día
- Ajuste de proyecciones por patrón semanal

**Características Comunes de Todos los Reportes:**
-  Filtros por rango de fechas (desde - hasta)
-  Filtros por lugar (Comedor/Quincho/Todos)
-  Visualización en grilla interactiva
-  Exportación a PDF
-  Metadatos incluidos (fecha de generación, filtros aplicados)
-  Encabezados corporativos personalizables

---

##  Arquitectura del Sistema

```
Sistema-Control-Almuerzos/
├── SCA/
│   ├── dominio/                     # Capa de Entidades
│   │   ├── Empleado.cs              # Modelo de empleados
│   │   ├── Empresa.cs               # Modelo de empresas
│   │   ├── Lugar.cs                 # Modelo de lugares (comedor/quincho)
│   │   ├── Servicio.cs              # Modelo de servicios por jornada
│   │   ├── Registro.cs              # Modelo de registros de almuerzos
│   │   ├── Estadisticas.cs          # Modelos estadísticos 
│   │   ├── Reportes.cs              # Modelos de reportes 
│   │   └── Configuracion.cs         # Modelos de configuración 
│   │
│   ├── negocio/                       # Capa de Lógica de Negocio
│   │   ├── AccesoDatos.cs             # Clase centralizada para BD con IDisposable
│   │   ├── NegocioException.cs        # Excepciones personalizadas con mensajes amigables
│   │   ├── EmpleadoNegocio.cs         # Lógica de empleados
│   │   ├── EmpresaNegocio.cs          # Lógica de empresas
│   │   ├── LugarNegocio.cs            # Lógica de lugares
│   │   ├── ServicioNegocio.cs         # Lógica de servicios
│   │   ├── RegistroNegocio.cs         # Lógica de registros
│   │   ├── EstadisticasNegocio.cs     # Lógica de estadísticas
│   │   ├── ReporteNegocio.cs          # Generación de 4 reportes avanzados
│   │   ├── ConfiguracionNegocio.cs    # Lógica de configuración y respaldos
│   │   └── Mappers/                   # Conversión de DataReader a Entidades
│   │       ├── EmpleadoMapper.cs      # Mapeo de empleados
│   │       ├── EmpresaMapper.cs       # Mapeo de empresas
│   │       ├── LugarMapper.cs         # Mapeo de lugares
│   │       ├── ServicioMapper.cs      # Mapeo de servicios
│   │       ├── RegistroMapper.cs      # Mapeo de registros
│   │       └── ConfiguracionMapper.cs # Mapeo de configuración
│   │
│   └── app/                          # Capa de Presentación
│       ├── Program.cs                # Punto de entrada
│       ├── frmPrincipal.cs           # Ventana principal
│       ├── Gestores/                 # Componentes de gestión especializados 
│       │   ├── GestorCronometro.cs   # Gestión de cronómetro de servicio 
│       │   ├── GestorEstadisticas.cs # Actualización de estadísticas en tiempo real
│       │   └── GestorNavegacion.cs   # Control de navegación entre vistas 
│       ├── Helpers/                  # Utilidades de presentación
│       │   ├── MensajesConstantes.cs # ~120 constantes centralizadas 
│       │   ├── MensajesUI.cs         # Mensajes y manejo de excepciones en UI
│       │   └── ListadoHelper.cs      # Utilidades para DataGridView 
│       ├── UserControls/             # Controles de usuario modulares
│       │   ├── ucServicio.cs             # Registro por credencial RFID
│       │   ├── ucRegistroManual.cs       # Registro manual de comensales
│       │   ├── ucNotificacion.cs         # Notificación visual de registro
│       │   ├── ucEmpleados.cs            # Gestión de empleados
│       │   ├── ucEmpresas.cs             # Gestión de empresas
│       │   ├── ucConfiguracion.cs        # Configuración del sistema
│       │   ├── ucReportes.cs             # Sistema de reportes
│       │   ├── ucEstadisticas.cs         # Análisis estadístico
│       │   └── ucAdmin.cs                # Panel administrativo
│       └── Iconos/                   # Recursos gráficos
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
- `sp_ListarServiciosRango`: Servicios en período con filtros de lugar
- `sp_AsistenciasPorEmpresas`: Totales de asistencia por compañía
- `sp_ReporteCoberturaVsProyeccion`: Análisis de precisión de proyecciones
- `sp_DistribucionPorDiaSemana`: Patrones de asistencia semanal

#### Configuración y Administración
- `sp_ObtenerInfoBaseDatos`: Información del servidor SQL (nombre, tamaño, fechas)
- `sp_ObtenerUltimoRespaldo`: Datos del último backup realizado
- `sp_CrearRespaldo`: Crear backup manual de la base de datos
- `sp_RestaurarRespaldo`: Restaurar base de datos desde archivo de backup

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


##  Sistema de Respaldos y Recuperación

El sistema incluye un módulo completo de respaldos para proteger la información crítica del comedor.

### Tipos de Respaldo Disponibles

**1. Respaldo Manual**
- Se ejecuta bajo demanda desde el módulo de Configuración
- Requiere selección de carpeta destino
- Ideal antes de:
  - Actualizaciones importantes del sistema
  - Cambios masivos de datos
  - Migraciones de servidor
  - Modificaciones en la estructura de BD

**2. Respaldo Mensual Automático Programado**

**Configuración:**
1. Abrir módulo **Configuración**
2. Ir a pestaña **Respaldos**
3. Seleccionar frecuencia deseada
4. Establecer ruta de destino para archivos
5. Guardar configuración
6. El sistema ejecutará backups automáticamente

### Información de Respaldos

El sistema muestra:
- **Fecha del último respaldo**: Cuándo se realizó
- **Ruta del archivo**: Ubicación del backup
- **Tamaño del archivo**: Espacio ocupado en MB

### Restauración desde Backup

**¿Cuándo restaurar?**
- Pérdida de datos por error humano
- Corrupción de base de datos
- Reversión a estado anterior (rollback)
- Migración o clonación de sistema
- Recuperación ante desastres

**Pasos para Restaurar:**
1. Ir al módulo **Configuración**
2. Pestaña **Respaldos**
3. Hacer clic en **"Restaurar Respaldo"**
4. Seleccionar archivo de backup (.bak)
5. Confirmar operación
6. El sistema restaurará la BD automáticamente

**ADVERTENCIA IMPORTANTE**: 
- La restauración sobrescribe **completamente** la base de datos actual
- Todos los datos posteriores al backup se perderán
- Se recomienda crear un backup manual antes de restaurar
- La aplicación debe cerrarse durante la restauración


##  Implementación y Adaptabilidad

### Flexibilidad de Implementación

Este sistema está diseñado para adaptarse a diferentes escenarios de implementación:

**Opción 1: Nueva Base de Datos**
- El proyecto incluye scripts SQL completos para crear la base de datos desde cero
- `Script_Sistema_Control_Almuerzos.sql`: Creación de tablas, relaciones y constraints
- `Procedimientos_Vistas_Triggers.sql`: Objetos de base de datos (SPs, vistas, triggers)
- `Datos_Iniciales.sql`: Datos de ejemplo para testing
- Configuración de cadena de conexión desde el módulo de Configuración
- Sistema listo para usar en minutos

**Opción 2: Adaptación a Base de Datos Existente**
- El sistema puede integrarse con una base de datos corporativa existente
- Se pueden adaptar los procedimientos almacenados para trabajar con tablas preexistentes
- Los mappers (`negocio/Mappers/`) facilitan la adaptación a estructuras diferente

## Requisitos del Sistema

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

## Módulos del Sistema

| Módulo | Descripción |
|--------|-------------|
| **ucServicio** | Registro de comensales por credencial RFID | 
| **ucRegistroManual** | Registro manual seleccionando de lista | 
| **ucNotificacion** | Notificación visual animada de registro exitoso |
| **ucEmpleados** | Gestión de empleados y credenciales | 
| **ucEmpresas** | Gestión de empresas | 
| **ucConfiguracion** | Configuración del sistema y respaldos | 
| **ucReportes** | Generación de reportes con exportación PDF | 
| **ucEstadisticas** | Dashboard de análisis estadístico |
| **ucAdmin** | Panel administrativo (contenedor de módulos) | 

---

##  Características Técnicas

### Seguridad

- **Validación de entrada**: Todos los inputs son validados
- **Prevención de SQL Injection**: Uso exclusivo de parámetros y SPs
- **Manejo específico de excepciones**: SqlException en capa de negocio 
- **Transacciones seguras**: Rollback automático en errores
- **Baja lógica**: No se eliminan datos, solo se desactivan
- **Integridad referencial**: Llaves foráneas con restricciones

### Rendimiento

- **Índices optimizados**: En campos de búsqueda frecuente
- **Consultas parametrizadas**: Para mejor plan de ejecución
- **Stored Procedures**: Lógica pre-compilada en servidor
- **Mappers optimizados**: Conversión eficiente de DataReader a entidades
- **Filtrado en base de datos**: Reducción de datos transferidos
- **Actualización eficiente**: Solo datos necesarios en tiempo real
- **Gestores especializados**: Separación de responsabilidades para mejor mantenibilidad

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
-  Mensajería centralizada con constantes (MensajesConstantes)
-  Confirmaciones antes de operaciones críticas
-  Feedback visual inmediato
-  Gestores especializados para cronómetro, estadísticas y navegación

##  Roadmap

**Estado**: Funcional y listo para producción

**Módulos:**
-  Diseño e implementación de base de datos
-  Arquitectura en 3 capas completa
-  Módulo de gestión de empleados (ABML completo)
-  Módulo de gestión de empresas y lugares
-  Sistema de servicios por jornada
-  Registro de comensales por ingreso de ID (teclado)
-  Panel de visualización en tiempo real para cocina

**Sistema de Reportes:**
-  4 tipos de reportes avanzados:
  - Lista de servicios
  - Asistencias por empresas
  - Cobertura vs proyección
  - Distribución por día de semana
-  Exportación a PDF
-  Filtros por fecha y lugar

**Administración:**
-  Módulo de configuración completo
-  Sistema de respaldos automáticos y manuales
-  Gestión de cadena de conexión
-  Información de base de datos y aplicación

**Calidad:**
-  Validaciones robustas en todas las capas
-  Manejo centralizado de excepciones 
-  Mensajería centralizada con constantes 
-  Interfaz moderna y profesional
-  Gestores especializados 
-  Helpers optimizados 
-  Mappers eficientes 
-  Documentación técnica completa
-  Manual de usuario detallado

---

## Migración a Aplicación Web


El sistema actual de Windows Forms podría evolucionar hacia una **aplicación web** utilizando **ASP.NET Core MVC**, lo que permitiría las siguientes mejoras:

**Portal de Comensales:**
-  **Sistema de autenticación**: Usuario y contraseña personalizado para cada comensal
-  **Menú semanal**: Visualización del menú planificado para cada día
-  **Reserva anticipada de lugar**: Seleccionar con antelación dónde almorzar (Comedor/Quincho)
-  **Confirmación/Cancelación**: Gestionar reservas con anticipación para mejor proyección

**Mejoras Administrativas:**
-  **Acceso multiplataforma**: Gestión desde cualquier dispositivo 
-  **Gestión de menús**: Módulo para planificación y publicación de menús semanales
-  **Sistema de permisos**: Roles diferenciados (Admin, Cocina, Comensales)
-  **Reportes en línea**: Generación y descarga de reportes sin instalación

**Ventajas de la Migración:**
-  Mayor accesibilidad y flexibilidad
-  Reducción de costos de mantenimiento de equipos locales
-  Mejor experiencia de usuario para comensales
-  Escalabilidad mejorada para múltiples ubicaciones
-  Integración más sencilla con sistemas corporativos existentes
-  Actualizaciones centralizadas sin necesidad de redistribución

### Arquitectura Propuesta

La migración mantendría la actual arquitectura en 3 capas, adaptándola:
- **Capa de Dominio**: Reutilizable sin modificaciones mayores
- **Capa de Negocio**: Adaptable con mínimos cambios
- **Capa de Presentación**: Reemplazo completo con tecnologías web (Razor Pages, Blazor, React, etc.)
- **Capa adicional API**: Servicios RESTful para aplicaciones móviles

**Nota**: Esta migración representa una evolución natural del proyecto y podría implementarse de manera gradual, manteniendo el sistema actual como referencia funcional.

##  Documentación

### Documentos Disponibles

| Documento | Descripción | Ubicación |
|-----------|-------------|-----------|
| **README.md** | Documentación técnica completa (este archivo) | Raíz del proyecto |
| **MANUAL_USUARIO.md** | Guía para usuarios finales del sistema | Raíz del proyecto |
| **Guia_Implementacion_RFID.md** | Guía para implementar lector RFID | Raíz del proyecto |
| **DER_SdCdA.drawio** | Diagrama Entidad-Relación editable | Raíz del proyecto |
| **Script_Sistema_Control_Almuerzos.sql** | Script completo de creación de BD | Raíz del proyecto |
| **Procedimientos_Vistas_Triggers.sql** | Objetos de BD detallados | Raíz del proyecto |
| **Datos_Iniciales.sql** | Datos de prueba para testing | Raíz del proyecto |

### Guías Específicas

**Para Desarrolladores:**
- Leer este README completo
- Revisar arquitectura en sección correspondiente
- Consultar `NegocioException.cs` para manejo de errores en capa de negocio
- Consultar `MensajesUI.cs` para manejo de mensajes y excepciones en UI
- Revisar carpeta `Mappers/` para conversión de datos

**Para Usuarios:**
- Leer `MANUAL_USUARIO.md`
- Revisar flujos de trabajo comunes
- Consultar sección de Preguntas Frecuentes

---

##  Herramientas y Tecnologías Utilizadas

### Desarrollo del Sistema

**IDE y Entorno de Desarrollo:**
- **Visual Studio 2022 Community Edition** - Desarrollo de aplicación Windows Forms
- **SQL Server Management Studio (SSMS) 19** - Gestión de base de datos
- **Draw.io Desktop** - Diseño del Diagrama Entidad-Relación

**Frameworks y Librerías:**
- **.NET Framework 4.8** - Framework principal de la aplicación
- **System.Data.SqlClient** - Conectividad con SQL Server
- **ReaLTaiizor 3.8.1.3** - Componentes de interfaz modernos y personalizados
- **iTextSharp 5.5.13.4** - Generación de reportes PDF
- **BouncyCastle.Cryptography 2.4.0** - Dependencia de iTextSharp

**Base de Datos:**
- **SQL Server 2019 Express Edition** - Motor de base de datos
- **Transact-SQL (T-SQL)** - Lenguaje de consultas y procedimientos almacenados

### Documentación y Guías

Las siguientes herramientas fueron utilizadas para la elaboración de documentación técnica, guías de usuario, y asistencia en la estructuración del código:

- **GitHub Copilot** (Claude Sonnet 4.5)
  - Generación de documentación técnica (README.md)
  - Elaboración de manual de usuario (MANUAL_USUARIO.md)
  - Creación de guía de implementación RFID
  - Asistencia en refactorización de código
  - Sugerencias de mejores prácticas
  - Optimización de procedimientos almacenados
  - Revisión de consultas SQL complejas
  - Generación de casos de prueba

**Control de Versiones:**
- **Git** - Control de versiones local
- **GitHub** - Repositorio remoto y colaboración

**Edición de Documentos:**
- **Visual Studio Code** - Edición de archivos Markdown
- **Markdown Preview Enhanced** - Vista previa de documentación

### Nota sobre el Uso de IA

El uso de herramientas de IA generativa fue exclusivamente para:
- **Documentación**: Redacción clara y profesional de guías
- **Refactorización**: Mejora de estructura y legibilidad del código existente
- **Consultoría**: Validación de soluciones técnicas y mejores prácticas
- **Patrones de diseño**: Sugerencias para organización de código (Mappers, Helpers, Gestores)

**Toda la lógica de negocio, arquitectura del sistema, diseño de base de datos y funcionalidades fueron desarrolladas por el autor del proyecto.**

---

##  Enlaces Útiles

- [Repositorio en GitHub](https://github.com/f-Rra/Sistema-Control-Almuerzos)
- [Documentación de .NET Framework](https://docs.microsoft.com/en-us/dotnet/framework/)
- [SQL Server Documentation](https://docs.microsoft.com/en-us/sql/sql-server/)
- [ReaLTaiizor UI Components](https://github.com/Taiizor/ReaLTaiizor)
- [iTextSharp Documentation](https://github.com/itext/itextsharp)

---

**Facundo Herrera**
- 🎓 Estudiante de Tecnicatura Universitaria en Programación
- 🏫 Universidad Tecnológica Nacional - Facultad Regional General Pacheco (UTN-FRGP)
- 🐙 GitHub: [@f-Rra](https://github.com/f-Rra)
- 📧 Email: Facundo.Herrera@alumnos.frgp.utn.edu.ar

---

