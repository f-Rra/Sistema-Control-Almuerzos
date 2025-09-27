# Sistema de Control de Almuerzos - Guía de Desarrollo

## 🏗️ Arquitectura del Proyecto

### **Estructura de Solución:**
```
SistemaControlAlmuerzos.sln
├── 📁 app (Capa de Presentación)
│   ├── Forms/
│   │   └── FormPrincipal.cs
│   ├── UserControls/
│   │   ├── ucVistaPrincipal.cs
│   │   ├── ucRegistroManual.cs
│   │   ├── ucReportes.cs
│   │   └── ucAdministrador.cs
│   ├── Program.cs
│   ├── App.config
│   └── app.csproj
├── 📁 Dominio (Capa de Entidades)
│   ├── Models/
│   │   ├── Empleado.cs
│   │   ├── Empresa.cs
│   │   ├── Lugar.cs
│   │   ├── Servicio.cs
│   │   └── Registro.cs
│   └── Dominio.csproj
└── 📁 Negocio (Capa de Lógica)
    ├── Services/
    │   ├── LugarNegocio.cs
    │   ├── EmpleadoNegocio.cs
    │   ├── ServicioNegocio.cs
    │   ├── RegistroNegocio.cs
    │   ├── EmpresaNegocio.cs
    │   └── ReporteNegocio.cs
    ├── AccesoDatos.cs
    └── Negocio.csproj
```
### Interfaz de Usuario - Single Window Application

#### FormPrincipal - Interfaz Unificada Completa (Estado actual)
```
┌─────────────────────────────────────────────────────────────┐
│  [Comedor ▼] [Fecha: __/__/__] [Proyección: ___] [Invitados: ___] [Iniciar Servicio]
│   │ Estado: Inactivo │ 🕐 00:00:00 │ Progreso: 50% │ Estadísticas: Reg: 150/Faltan: 210 │ ← Panel Superior
├─────────────────────────────────────────────────────────────┤
│ ┌─────────────┐ │                                           │
│ │ ● Principal │ │           VISTA PRINCIPAL                 │
│ │   Reg.Manual│ │                                           │
│ │   Reportes  │ │  ┌─────────────────────────────────────┐  │
│ │   Admin     │ │  │        REGISTROS EN TIEMPO REAL     │  │
│ │             │ │  │ ┌─────────────────────────────────┐ │  │
│ │             │ │  │ │ Hora  │ Nombre      │ Empresa   │ │  │
│ │             │ │  │ │ (vacío - servicio inactivo)     │ │  │
│ │             │ │  │ └─────────────────────────────────┘ │  │
│ │             │ │  └─────────────────────────────────────┘  │
│ │             │ │                                           │
│ │             │ │  ┌─────────────────────────────────────┐  │
│ │             │ │  │      ESTADÍSTICAS DEL SERVICIO     │  │
│ │             │ │  │  Empleados: 0 │ Invitados: 0 │ Total: 0 │
│ │             │ │  └─────────────────────────────────────┘  │
│ └─────────────┘ │                                           │
│   Panel Lateral │                ÁREA DINÁMICA             │
└─────────────────────────────────────────────────────────────┘

** Estado con Servicio Activo **
┌─────────────────────────────────────────────────────────────┐
│ [Comedor] [Finalizar Servicio] │ Estado: Activo │ 🕐 02:45:30 │ Progreso: 80% │ Reg: 220/Faltan: 40 │
├─────────────────────────────────────────────────────────────┤
│ ┌─────────────┐ │  ┌─────────────────────────────────────┐  │
│ │ ● Principal │ │  │        REGISTROS EN TIEMPO REAL     │  │
│ │   Reg.Manual│ │  │ ┌─────────────────────────────────┐ │  │
│ │   Reportes  │ │  │ │12:30│Juan Pérez   │Empresa A  │ │  │
│ │   Admin     │ │  │ │12:32│María García │Empresa B  │ │  │
│ │             │ │  │ │12:35│Carlos López │Empresa C  │ │  │
│ │             │ │  │ └─────────────────────────────────┘ │  │
│ │             │ │  └─────────────────────────────────────┘  │
│ │             │ │                                           │
│ │             │ │  ┌─────────────────────────────────────┐  │
│ │             │ │  │      ESTADÍSTICAS DEL SERVICIO     │  │
│ │             │ │  │ Empleados: 15 │ Invitados: 2 │ Total: 17│
│ │             │ │  └─────────────────────────────────────┘  │
│ └─────────────┘ │                                           │
└─────────────────────────────────────────────────────────────┘
```

#### Vista Registro Manual (Panel Lateral: Reg.Manual)
```
┌─────────────────────────────────────────────────────────────┐
│ [Comedor] [Finalizar Servicio] │ Estado: Activo │ 🕐 02:45:30  │
├─────────────────────────────────────────────────────────────┤
│ ┌─────────────┐ │  ┌─────────────────────────────────────┐  │
│ │   Principal │ │  │        REGISTRO MANUAL              │  │
│ │ ● Reg.Manual│ │  │                                     │  │
│ │   Reportes  │ │  │  ┌─────────────────────────────────┐ │  │
│ │   Admin     │ │  │  │     FILTROS DE BÚSQUEDA        │ │  │
│ │             │ │  │  │ Nombre: [________] Empresa:[▼] │ │  │
│ │             │ │  │  └─────────────────────────────────┘ │  │
│ │             │ │  │                                     │  │
│ │             │ │  │  ┌─────────────────────────────────┐ │  │
│ │             │ │  │  │   EMPLEADOS SIN ALMORZAR        │ │  │
│ │             │ │  │  │ ┌─────────────────────────────┐ │ │  │
│ │             │ │  │  │ │Juan Pérez    │ Empresa A   │ │ │  │
│ │             │ │  │  │ │María García  │ Empresa B   │ │ │  │
│ │             │ │  │  │ │Carlos López  │ Empresa C   │ │ │  │
│ │             │ │  │  │ └─────────────────────────────┘ │ │  │
│ │             │ │  │  │                                 │ │  │
│ │             │ │  │  │      [REGISTRAR SELECCIONADO]   │ │  │
│ │             │ │  │  └─────────────────────────────────┘ │  │
│ └─────────────┘ │  └─────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────┘
```

#### Vista Reportes (Panel Lateral: Reportes)
```
┌─────────────────────────────────────────────────────────────┐
│ [Comedor] [Finalizar Servicio] │ Estado: Activo │ 🕐 02:45:30  │
├─────────────────────────────────────────────────────────────┤
│ ┌─────────────┐ │  ┌─────────────────────────────────────┐  │
│ │   Principal │ │  │           MÓDULO REPORTES           │  │
│ │   Reg.Manual│ │  │                                     │  │
│ │ ● Reportes  │ │  │  ┌─────────────────────────────────┐ │  │
│ │   Admin     │ │  │  │      FILTROS DE REPORTE         │ │  │
│ │             │ │  │  │ Desde:[__/__] Hasta:[__/__]     │ │  │
│ │             │ │  │  │ Lugar:[Todos▼] [GENERAR]        │ │  │
│ │             │ │  │  └─────────────────────────────────┘ │  │
│ │             │ │  │                                     │  │
│ │             │ │  │  ┌─────────────────────────────────┐ │  │
│ │             │ │  │  │     SERVICIOS ANTERIORES        │ │  │
│ │             │ │  │  │ ┌─────────────────────────────┐ │ │  │
│ │             │ │  │  │ │15/01│Comedor│45│3│48        │ │ │  │
│ │             │ │  │  │ │14/01│Quincho│32│1│33        │ │ │  │
│ │             │ │  │  │ │13/01│Comedor│38│2│40        │ │ │  │
│ │             │ │  │  │ └─────────────────────────────┘ │ │  │
│ │             │ │  │  │                                 │ │  │
│ │             │ │  │  │ [EXPORTAR PDF] [VER DETALLES]   │ │  │
│ │             │ │  │  └─────────────────────────────────┘ │  │
│ └─────────────┘ │  └─────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────┘
```

#### Vista Administrador (Panel Lateral: Admin)
```
┌─────────────────────────────────────────────────────────────┐
│ [Administrador] [---] │ Estado: Admin │ 🔐 Modo Administrador │
├─────────────────────────────────────────────────────────────┤
│ ┌─────────────┐ │  ┌─────────────────────────────────────┐  │
│ │   Principal │ │  │        MÓDULO ADMINISTRADOR         │  │
│ │   Reg.Manual│ │  │                                     │  │
│ │   Reportes  │ │  │  ┌─────────────────────────────────┐ │  │
│ │ ● Admin     │ │  │  │ [EMPLEADOS] [EMPRESAS] [CONFIG] │ │  │
│ │             │ │  │  └─────────────────────────────────┘ │  │
│ │             │ │  │                                     │  │
│ │             │ │  │  ┌─────────────────────────────────┐ │  │
│ │             │ │  │  │      PANEL DE ESTADÍSTICAS      │ │  │
│ │             │ │  │  │                                 │ │  │
│ │             │ │  │  │ Empleados Activos: 150          │ │  │
│ │             │ │  │  │ Empresas: 8                     │ │  │
│ │             │ │  │  │ Credenciales RFID: 150          │ │  │
│ │             │ │  │  │ Última Actualización: 15/01/24  │ │  │
│ │             │ │  │  │                                 │ │  │
│ │             │ │  │  │ [RESPALDO] [CONFIGURACIÓN]      │ │  │
│ │             │ │  │  └─────────────────────────────────┘ │  │
│ └─────────────┘ │  └─────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────┘


### 🚀 Orden de Desarrollo
```
### **✅ Fase 1: Configuración Base - COMPLETADA**
1. **✅ Crear solución** con estructura de 3 proyectos
2. **✅ Configurar referencias** entre proyectos
3. **✅ Instalar ReaLTaiizor** desde NuGet: `Install-Package ReaLTaiizor`
4. **✅ Crear clases de modelo** en Dominio
5. **✅ Configurar AccesoDatos** en Negocio

### **✅ Fase 2: Interfaz Unificada (Single Window) - COMPLETADA**
1. **✅ FormPrincipal único** con panel superior integrado (base visual)
2. **✅ Panel superior**: Lugar, Fecha, Proyección, Invitados, Estado, Duración, Progreso, Estadísticas
3. **✅ Panel lateral**: Botones de navegación (Principal, Registros, Reportes, Admin)
4. **✅ Área dinámica**: UserControls que se cargan según selección (MostrarVista + métodos CargarVistaX)
5. **✅ Estados dinámicos**: ComboBox habilitado/deshabilitado según servicio

### **🔄 Fase 3: User Controls Integrados - EN PROGRESO**
1. **❌ ucReportes** User Control para reportes (estructura creada, funcionalidad pendiente)
2. **✅ ucRegistroManual** User Control para registro manual (filtros automáticos y registro)
3. **❌ ucAdministrador** User Control para administración
4. **✅ ucVistaPrincipal** User Control para vista principal
5. **✅ Sistema de navegación** con User Controls (MostrarVista/MostrarVistaX)
6. **✅ Métodos CargarVistaX** para integración (Principal, Reg.Manual, Reportes, Admin)

### **✅ Fase 4: Lógica de Servicios - COMPLETADA**
1. **✅ ServicioNegocio** para gestión de servicios
2. **✅ Cronómetro/Duración**: UI agregada (panel superior). La duración se gestiona por cronómetro en backend y se persiste solo en `DuracionMinutos`.
3. **✅ Estados/Progreso**: UI y actualización en tiempo real (llamadas a `ActualizarEstadisticas()` en eventos clave)
4. **✅ Validaciones** de servicio activo/inactivo

### **🔄 Fase 5: Funcionalidades Específicas - PARCIALMENTE COMPLETADA**
1. **✅ EmpleadoNegocio** para registro manual (búsqueda por credencial, filtros y listados)
2. **🔄 ReporteNegocio**: consultas disponibles; exportación pendiente
3. **❌ Integración RFID** simulada (futuro)
4. **✅ Validaciones** y manejo de errores

### **🔄 Fase 6: Módulo Administrativo - PARCIALMENTE COMPLETADA**
1. **❌ Gestión de empleados** (CRUD completo - backend)
2. **❌ Gestión de empresas** (CRUD completo - backend)
3. **❌ Asignación de credenciales** RFID (lógica lista)
4. **❌ Configuración del sistema** y respaldos (falta UI)

### **❌ Fase 7: Integración RFID (Futuro) - NO INICIADA**
1. **❌ RFIDReader** para lectura de credenciales
2. **❌ Integración** con FormPrincipal
3. **❌ Manejo de errores** de dispositivo
4. **❌ Registro automático**



## Prioridades

1) Reportes y visualización
    - Implementar `ucReportes` (listar servicios, filtros por fecha/lugar, KPIs)
    - Agregar exportación (PDF/CSV) en una iteración siguiente

2) ucRegistroManual (mejoras menores)
    - Ajustes de UX (resaltado selección, atajos de teclado)
    - Validaciones adicionales en registro concurrente

3) Último servicio (inicio y fin)
    - Mostrar detalle del último servicio en `gbxUltimo` al iniciar y al finalizar servicio
    - Agregar desglose por empresa (opcional) bajo `gbxUltimo`

4) Estadísticas en tiempo real en la UI
    - Mantener llamada a `ActualizarEstadisticas()` desde `ucVistaPrincipal` y `ucRegistroManual`
    - Considerar refresco periódico si se agregan fuentes externas

5) Configuración de conexión
    - Mover cadena de conexión de `AccesoDatos.cs` a `App.config` para facilitar despliegues

6) Módulo Admin (iteración 1)
    - Pantalla básica para listar empresas y empleados (solo lectura)
    - Definir endpoints/métodos de negocio para CRUD en iteración 2

7) RFID (futuro)
    - Definir interfaz del lector (abstracción) y simulación para pruebas
    - Integrar lectura con el flujo de `ucVistaPrincipal`

---

## ✅ Cambios realizados recientemente

### Backend/SQL
- Agregado `SP_ObtenerUltimoServicio` (sin parámetros) que devuelve el último servicio finalizado incluyendo `NombreLugar` mediante JOIN con `Lugares`.
- Unificación de filtros de empleados: `SP_FiltrarEmpleadosSinAlmorzar(@IdServicio, @IdEmpresa=NULL, @Nombre=NULL)` sobre la vista base `vw_EmpleadosSinAlmorzarBase`.
- Mantenidos `SP_EmpleadosSinAlmorzarPorEmpresa` y `SP_EmpleadosSinAlmorzarPorNombre` como wrappers de compatibilidad.
- Refuerzo de unicidad de registros en `SP_RegistrarEmpleado` (idempotente ante duplicados).

### Negocio (C#)
- `ServicioNegocio.obtenerUltimoServicio()` para consumir `SP_ObtenerUltimoServicio` y mapear `NombreLugar`.
- `EmpleadoNegocio.filtrarEmpleadosSinAlmorzar(...)` con parámetros opcionales y manejo de `DBNull`.

### Presentación (WinForms)
- `frmPrincipal`:
  - `CargarUltimoServicio()` muestra datos en `gbxUltimo` al iniciar la app y al finalizar un servicio.
  - `OcultarTodasLasVistas()` para limpiar el área dinámica antes de mostrar `gbxUltimo`.
  - Navegación por vistas consolidada: `MostrarVista`, `MostrarVistaPrincipal/RegistroManual/Reportes/Admin`.
- `ucRegistroManual`:
  - Filtros automáticos por nombre (TextChanged) y empresa (SelectionChangeCommitted) sin botón de búsqueda.
  - Opción inicial de empresa en blanco (en lugar de “Todas las empresas”).
  - Uso del SP unificado de filtros, columnas ordenadas y ocultamiento de internas.
- `ucVistaPrincipal`:
  - Registro por credencial con validaciones y actualización de estadísticas en `frmPrincipal`.

### UX/Comportamiento
- Al finalizar servicio se actualizan estadísticas y se muestra el panel `gbxUltimo` con el resumen del servicio.
- Estado visual ACTIVO/INACTIVO con íconos y cronómetro funcional.

---

## Estado actual resumido
- Interfaz unificada y navegación: ✅
- Registro manual con filtros unificados: ✅
- Último servicio visible al iniciar y al finalizar: ✅ (detalle básico)
- Reportes: 🔄 (estructura creada, funcionalidad pendiente)
- Admin: ❌
- RFID: ❌ (futuro)





