# 🍽️ Sistema de Control de Almuerzos

Un sistema completo de gestión de comedores corporativos desarrollado en C# con Windows Forms, diseñado para el registro eficiente de comensales mediante credenciales RFID y generación de reportes automáticos.

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue)
![C#](https://img.shields.io/badge/C%23-10.0-green)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-red)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-lightblue)

---

## ✨ Características Principales

- ✅ **Arquitectura de 3 capas** (Dominio, Negocio, Presentación)
- ✅ **Registro rápido de comensales** por ID de credencial (preparado para RFID)
- ✅ **Gestión completa de empleados** con asignación de credenciales
- ✅ **Sistema de servicios por jornada** (comedor y quincho)
- ✅ **Visualización en tiempo real** para personal de cocina
- ✅ **Reportes automáticos** con exportación a PDF
- ✅ **Estadísticas avanzadas** por empresa, período y lugar
- ✅ **Procedimientos almacenados** para todas las operaciones críticas
- ✅ **Validaciones robustas** (duplicados, servicio activo, estado de empleado)
- ✅ **Interfaz moderna** con diseño profesional (ReaLTaiizor)
- ✅ **Manejo de invitados** sin datos personales
- ✅ **Registro manual alternativo** para casos sin credencial
- ✅ **Optimizado para alta concurrencia** en horarios pico

## 🚀 Funcionalidades del Sistema

### 📝 Registro de Comensales

**Método Actual: Ingreso por Teclado**
- Registro mediante ID de credencial
- Validación automática de duplicados
- Confirmación visual inmediata
- Tiempo promedio: 3-5 segundos por persona

**Método Futuro: RFID Automático (Documentado)**
- Lectura automática de credencial
- Registro instantáneo (<1 segundo)
- Cero intervención del operador
- Guía completa de implementación incluida

**Características:**
- ✅ Validación de empleado activo
- ✅ Detección de registros duplicados en servicio actual
- ✅ Vinculación automática al servicio activo
- ✅ Registro alternativo manual (sin credencial)
- ✅ Gestión de invitados (solo cantidad, sin datos personales)

### 👥 Gestión de Empleados

**Operaciones CRUD Completas:**
- **Alta**: Crear nuevos empleados con datos completos
- **Modificación**: Actualizar información de empleados
- **Baja lógica**: Desactivar empleados manteniendo historial
- **Búsqueda**: Filtros por nombre, apellido, empresa

**Gestión de Credenciales:**
- Asignación de ID de credencial a empleados
- Reasignación de credenciales (pérdida/daño)
- Validación de unicidad de credenciales
- Historial de asignaciones

**Organización por Empresa:**
- Agrupación de empleados por compañía
- Estadísticas por empresa
- Reportes segmentados

### 🏢 Gestión de Servicios

**Control de Jornadas:**
- Inicio de servicio por lugar (Comedor/Quincho)
- Registro de proyección de comensales
- Total de invitados esperados
- Cierre de servicio con estadísticas finales

**Información Automática:**
- ⏱️ Duración del servicio
- 👥 Total de comensales reales vs proyectados
- 📊 Desglose por empresa
- 📈 Comparativa de eficiencia

### 📊 Panel de Cocina (Tiempo Real)

**Visualización Instantánea:**
- Listado de todos los registros del servicio actual
- Contador principal de comensales
- Total de invitados
- Comparativa proyección vs real
- Actualización automática sin recargas

**Optimizado para Alta Concurrencia:**
- Sin colapsos en horario pico
- Diseñado para >30 registros simultáneos
- Interfaz responsive y estable

### 📈 Reportes y Estadísticas

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
- 📄 Formato PDF profesional
- 📊 Gráficos y visualizaciones
- 🏢 Encabezados corporativos
- 📅 Marca temporal automática

---

## 🏗️ Arquitectura del Sistema

### Estructura del Proyecto

```
Sistema-Control-Almuerzos/
├── SCA/
│   ├── dominio/                    # Capa de Entidades
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
│       │   ├── ucPaneles.cs              # Vista para cocina
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
└── README.md                             # Este archivo
```

## 🗄️ Base de Datos

### Modelo de Datos

#### Tablas Principales

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
- `SP_ListarEmpleados`: Listado completo con empresa y credencial
- `SP_BuscarEmpleadoPorId`: Búsqueda específica por ID
- `SP_BuscarEmpleadoPorCredencial`: Búsqueda por ID de credencial
- `SP_AltaEmpleado`: Inserción con validaciones
- `SP_ModificarEmpleado`: Actualización completa
- `SP_BajaEmpleado`: Baja lógica
- `SP_AsignarCredencial`: Asignar ID de credencial único

#### Gestión de Servicios
- `SP_IniciarServicio`: Crear nuevo servicio activo
- `SP_FinalizarServicio`: Cerrar servicio con cálculos
- `SP_ObtenerServicioActivo`: Obtener servicio en curso
- `SP_ListarServicios`: Historial de servicios

#### Gestión de Registros
- `SP_RegistrarAlmuerzo`: Registro principal con validaciones
- `SP_RegistrarInvitados`: Registro de invitados sin datos
- `SP_VerificarRegistroDuplicado`: Validar si ya se registró
- `SP_ListarRegistrosPorServicio`: Registros del servicio actual
- `SP_ContarRegistrosPorServicio`: Total de comensales

#### Reportes y Estadísticas
- `SP_ReporteDiario`: Estadísticas de un día específico
- `SP_ReportePorPeriodo`: Análisis de rango de fechas
- `SP_ReportePorEmpresa`: Datos específicos de empresa
- `SP_EstadisticasGenerales`: Resumen general del sistema

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

## 🛠️ Instalación y Configuración

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

**Hardware Futuro (RFID - Opcional):**
- Lector RFID 13.56 MHz (ISO 14443)
- Conexión USB o Serial (RS232)
- Credenciales RFID compatibles

### Configuración Inicial del Sistema

#### Primera Ejecución

1. El sistema abrirá automáticamente
2. Navegar a **ucConfiguracion** para:
   - Crear lugares (Comedor, Quincho)
   - Agregar empresas del predio
   - Configurar parámetros generales

3. Ir a **ucEmpleados** para:
   - Cargar empleados
   - Asignar credenciales (IDs únicos)

4. Ir a **ucConfiguracion > Servicios** para:
   - Iniciar el primer servicio de prueba

#### Datos de Prueba (Opcional)

Si ejecutaste `Datos_Iniciales.sql`, el sistema ya incluye:
- ✅ 2 Lugares: Comedor y Quincho
- ✅ 3 Empresas de ejemplo
- ✅ 10 Empleados con credenciales asignadas
- ✅ 1 Servicio de ejemplo con registros

## 💻 Uso del Sistema

### Flujos de Trabajo Principales

#### 1. Inicio de Jornada

```
ucConfiguracion > Servicios
  ↓
[Iniciar Nuevo Servicio]
  ↓
• Seleccionar Lugar (Comedor/Quincho)
• Ingresar Proyección de Comensales
• Ingresar Total de Invitados Esperados
  ↓
[Confirmar]
  ↓
✅ Servicio activo (sistema listo para registrar)
```

#### 2. Registro de Comensales

```
ucRegistroManual
  ↓
Empleado dice su ID de credencial (ej: "4523")
  ↓
Operador ingresa ID → [Enter]
  ↓
Sistema valida automáticamente:
  ✓ Credencial existe
  ✓ Empleado activo
  ✓ No registrado previamente en este servicio
  ✓ Servicio activo
  ↓
✅ Confirmación visual + Registro guardado
```

**Método Alternativo (Sin Credencial):**
```
ucRegistroManual > [Registro Manual]
  ↓
Buscar empleado por nombre/apellido
  ↓
Seleccionar de lista → [Confirmar]
  ↓
✅ Registro guardado
```

#### 3. Monitoreo en Cocina

```
ucVistaPrincipal (Vista en tiempo real)
  ↓
Visualización automática:
  • Total de comensales registrados
  • Comparativa Proyección vs Real
  • Listado completo con timestamps
  • Desglose por empresa
  ↓
Actualización automática con cada nuevo registro
```

#### 4. Cierre de Jornada

```
ucConfiguracion > Servicios
  ↓
[Finalizar Servicio Activo]
  ↓
Sistema calcula automáticamente:
  • Duración total del servicio
  • Total real de comensales
  • Cobertura (Real vs Proyección)
  • Desglose por empresa
  ↓
✅ Servicio cerrado (disponible para reportes)
```

#### 5. Generación de Reportes

```
ucReportes
  ↓
Seleccionar tipo de reporte:
  • Diario
  • Por Período
  • Por Empresa
  • Estadísticas Generales
  ↓
Configurar parámetros (fechas, filtros)
  ↓
[Generar Reporte]
  ↓
Visualización en pantalla
  ↓
[Exportar PDF] (opcional)
  ↓
✅ Archivo PDF guardado
```

### Módulos del Sistema

| Módulo | Descripción | Usuario Típico |
|--------|-------------|----------------|
| **ucVistaPrincipal** | Pantalla de bienvenida y navegación | Todos |
| **ucRegistroManual** | Registro de comensales | Personal de entrada |
| **ucPaneles** | Visualización en tiempo real | Personal de cocina |
| **ucEmpleados** | Gestión de empleados y credenciales | Administrador |
| **ucEmpresas** | Gestión de empresas | Administrador |
| **ucConfiguracion** | Configuración de servicios y lugares | Administrador |
| **ucReportes** | Generación de reportes | Administrador |
| **ucEstadisticas** | Análisis estadístico | Administrador |
| **ucAdmin** | Panel administrativo general | Administrador |

---

## 🔧 Características Técnicas

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
- **Arquitectura local**: Sin latencia de red (preparado para centralizar)

### Validaciones Implementadas

**A Nivel de Base de Datos:**
- ✅ Unicidad de credenciales (Triggers)
- ✅ Integridad referencial (FK Constraints)
- ✅ Validación de servicio único activo (Triggers)
- ✅ Actualización automática de contadores (Triggers)

**A Nivel de Negocio:**
- ✅ Empleado debe estar activo
- ✅ No puede registrarse dos veces en el mismo servicio
- ✅ Debe existir un servicio activo para registrar
- ✅ Credencial debe ser única al asignar
- ✅ No se puede cerrar un servicio sin inicio

**A Nivel de Presentación:**
- ✅ Campos obligatorios marcados
- ✅ Formato de datos validado
- ✅ Confirmaciones antes de operaciones críticas
- ✅ Feedback visual inmediato

## 🗺️ Roadmap

### ✅ Fase 1: Sistema Base (COMPLETADO)

**Estado**: Funcional y listo para producción

- [x] Diseño y implementación de base de datos
- [x] Arquitectura en 3 capas completa
- [x] Módulo de gestión de empleados
- [x] Módulo de gestión de empresas y lugares
- [x] Sistema de servicios por jornada
- [x] Registro por ingreso de ID (teclado)
- [x] Panel de visualización para cocina
- [x] Sistema de reportes y estadísticas
- [x] Exportación a PDF
- [x] Interfaz completa y funcional
- [x] Validaciones robustas
- [x] Documentación técnica

### 📋 Fase 2: Integración RFID (PLANIFICADO)

**Estado**: Documentado para implementación futura

**Objetivos:**
- [ ] Guía de selección de hardware RFID
- [ ] Configuración de lectores (USB/Serial)
- [ ] Modificación de capa de presentación (captura automática)
- [ ] Testing con credenciales corporativas reales
- [ ] Manual de implementación paso a paso
- [ ] Procedimiento de migración sin downtime

**Prerequisitos:**
- Adquisición de lectores RFID compatibles (ISO 14443)
- Credenciales corporativas con chip RFID
- Configuración de puerto de comunicación
- Ambiente de testing

## 📚 Documentación

### Documentos Disponibles

| Documento | Descripción | Ubicación |
|-----------|-------------|-----------|
| **README.md** | Documentación técnica completa (este archivo) | Raíz del proyecto |
| **MANUAL_USUARIO.md** | Guía para usuarios finales | Raíz del proyecto |
| **DER_SdCdA.drawio** | Diagrama Entidad-Relación (abrir con draw.io) | Raíz del proyecto |
| **Script_Sistema_Control_Almuerzos.sql** | Script completo de creación de BD | Raíz del proyecto |
| **Procedimientos_Vistas_Triggers.sql** | Objetos de BD detallados | Raíz del proyecto |
| **Datos_Iniciales.sql** | Datos de prueba para testing | Raíz del proyecto |

### Guías Específicas

**Para Desarrolladores:**
- Leer este README completo
- Revisar arquitectura en sección correspondiente
- Explorar código con comentarios inline
- Consultar `ExceptionHelper.cs` para manejo de errores

**Para Usuarios Finales:**
- Leer `MANUAL_USUARIO.md`
- Revisar flujos de trabajo comunes
- Consultar sección de Preguntas Frecuentes

---

## 📊 Estadísticas del Proyecto

- **Líneas de código**: ~8,000+ (C# + SQL)
- **Clases**: 25+
- **Procedimientos almacenados**: 20+
- **Tiempo de desarrollo**: 4 meses
- **Tecnologías**: 5 (C#, SQL Server, Windows Forms, ReaLTaiizor, iTextSharp)

---

## 🔗 Enlaces Útiles

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