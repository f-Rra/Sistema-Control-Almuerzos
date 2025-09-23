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

### **🔄 Fase 2: Interfaz Unificada (Single Window) - EN PROGRESO**
1. **✅ FormPrincipal único** con panel superior integrado (base visual)
2. **✅ Panel superior**: Lugar, Fecha, Proyección, Invitados, Estado, Duración, Progreso, Estadísticas
3. **✅ Panel lateral**: Botones de navegación (Principal, Registros, Reportes, Admin)
4. **❌ Área dinámica**: UserControls que se cargan según selección
5. **✅ Estados dinámicos**: ComboBox habilitado/deshabilitado según servicio

### **❌ Fase 3: User Controls Integrados - PENDIENTE**
1. **❌ ucReportes** User Control para reportes
2. **❌ ucRegistroManual** User Control para registro manual
3. **❌ ucAdministrador** User Control para administración
4. **✅ ucVistaPrincipal** User Control para vista principal
5. **❌ Sistema de navegación** con User Controls
6. **❌ Método CargarUserControl** para integración

### **🔄 Fase 4: Lógica de Servicios - PARCIALMENTE COMPLETADA**
1. **✅ ServicioNegocio** para gestión de servicios
2. **✅ Cronómetro/Duración**: UI agregada (panel superior). La duración se gestiona por cronómetro en backend y se persiste solo en `DuracionMinutos`.
3. **🔄 Estados/Progreso**: UI presente; falta actualización en tiempo real
4. **✅ Validaciones** de servicio activo/inactivo

### **🔄 Fase 5: Funcionalidades Específicas - PARCIALMENTE COMPLETADA**
1. **✅ EmpleadoNegocio** para registro manual
2. **✅ ReporteNegocio** para consultas y exportación
3. **❌ Integración RFID** simulada (lógica lista, falta UI)
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

1) Área dinámica y navegación
    - Implementar el método central para cargar UserControls en `frmPrincipal` (CargarUserControl/MostrarVista)
    - Conectar botones del panel lateral a la carga de vistas (Principal, Reg.Manual, Reportes, Admin)

2) ucRegistroManual (MVP)
    - Listar “Empleados sin almorzar” por servicio (usa SP_EmpleadosSinAlmorzar)
    - Filtros por nombre y empresa; acción “Registrar seleccionado” usando `RegistroNegocio.registrarEmpleado`

3) ucReportes (básico)
    - Filtros por fecha/lugar; listar servicios (SP_ListarServiciosPorFecha/PorLugar)
    - Totales y gráficos simples en una segunda iteración

4) Estadísticas en tiempo real en la UI
    - Actualizar progreso/estadísticas de `frmPrincipal` ante cada registro (ya se invoca ActualizarEstadisticas)
    - Opcional: timer o eventos para refrescar componentes asociados

5) Configuración de conexión
    - Mover cadena de conexión de `AccesoDatos.cs` a `App.config` para facilitar despliegues

6) Módulo Admin (iteración 1)
    - Pantalla básica para listar empresas y empleados (solo lectura)
    - Definir endpoints/métodos de negocio para CRUD en iteración 2

7) RFID (futuro)
    - Definir interfaz del lector (abstracción) y simulación para pruebas
    - Integrar lectura con el flujo de `ucVistaPrincipal`




