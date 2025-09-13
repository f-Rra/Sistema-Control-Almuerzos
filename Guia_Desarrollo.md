# Sistema de Control de Almuerzos - Guía de Desarrollo

## 🏗️ Arquitectura del Proyecto

### **Estructura de Solución:**
```
SistemaControlAlmuerzos.sln
├── 📁 app (Capa de Presentación)
│   ├── Forms/
│   │   ├── FormLogin.cs
│   │   ├── FormPrincipal.cs
│   │   ├── FormRegistroManual.cs
│   │   ├── FormReportes.cs
│   │   └── FormAdmin.cs
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

## 🎨 Interfaz de Usuario - GUNA UI2

### **Componentes Principales:**
- **Guna.UI2.WinForms.Guna2Form**: Formularios base
- **Guna.UI2.WinForms.Guna2Button**: Botones estilizados
- **Guna.UI2.WinForms.Guna2TextBox**: Campos de texto
- **Guna.UI2.WinForms.Guna2DataGridView**: GridView mejorado
- **Guna.UI2.WinForms.Guna2ComboBox**: ComboBox estilizado
- **Guna.UI2.WinForms.Guna2Panel**: Paneles contenedores

### **Tema y Colores:**
```csharp
// Colores principales del sistema
Color PrimaryColor = Color.FromArgb(94, 148, 255);    // Azul principal
Color SecondaryColor = Color.FromArgb(255, 255, 255); // Blanco
Color AccentColor = Color.FromArgb(255, 193, 7);      // Amarillo
Color DangerColor = Color.FromArgb(220, 53, 69);      // Rojo
Color SuccessColor = Color.FromArgb(40, 167, 69);     // Verde




### Interfaz de Usuario - Single Window Application

#### FormPrincipal - Interfaz Unificada Completa
```
┌─────────────────────────────────────────────────────────────┐
│  [Comedor ▼] [Iniciar Servicio] │ Estado: Inactivo │ 🕐 00:00:00 │ ← Panel Superior
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
│ [Comedor] [Finalizar Servicio] │ Estado: Activo │ 🕐 02:45:30  │
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
```

```

## 🚀 Orden de Desarrollo

### **Fase 1: Configuración Base**
1. **Crear solución** con estructura de 3 proyectos
2. **Configurar referencias** entre proyectos
3. **Instalar GUNA UI2** desde NuGet
4. **Crear clases de modelo** en Dominio
5. **Configurar AccesoDatos** en Negocio

### **Fase 2: Interfaz Unificada (Single Window)**
1. **FormPrincipal único** con panel superior integrado
2. **Panel superior**: ComboBox de lugares + botón Iniciar/Finalizar Servicio
3. **Panel lateral**: Botones de navegación (Principal, Reg.Manual, Reportes, Admin)
4. **Área dinámica**: UserControls que se cargan según selección
5. **Estados dinámicos**: ComboBox habilitado/deshabilitado según servicio

### **Fase 3: Formularios Integrados**
1. **FormReportes** configurado para integrarse en panel
2. **FormRegistroManual** configurado para integrarse en panel
3. **FormAdmin** configurado para integrarse en panel
4. **Sistema de navegación** con formularios sin borde
5. **Estados compartidos** entre FormPrincipal y formularios
6. **Método MostrarFormularioEnPanel** para integración

### **Fase 4: Lógica de Servicios**
1. **ServicioNegocio** para gestión de servicios
2. **Cronómetro** integrado en panel superior
3. **Estados dinámicos** del sistema
4. **Validaciones** de servicio activo/inactivo

### **Fase 5: Funcionalidades Específicas**
1. **EmpleadoNegocio** para registro manual
2. **ReporteNegocio** para consultas y exportación
3. **Integración RFID** simulada
4. **Validaciones** y manejo de errores

### **Fase 6: Módulo Administrativo**
1. **Gestión de empleados** (CRUD completo)
2. **Gestión de empresas** (CRUD completo)
3. **Asignación de credenciales** RFID
4. **Configuración del sistema** y respaldos

### **Fase 7: Integración RFID (Futuro)**
1. **RFIDReader** para lectura de credenciales
2. **Integración** con FormPrincipal
3. **Manejo de errores** de dispositivo
4. **Registro automático**

## 🔧 Arquitectura Single Window Application

### **Estructura de Componentes:**
- **FormPrincipal**: Formulario contenedor único
- **Panel Superior**: ComboBox + Botón Servicio + Cronómetro + Estado
- **Panel Lateral**: Botones de navegación entre módulos
- **Panel Contenido**: Área donde se integran los formularios
- **Formularios Integrados**: FormReportes, FormRegistroManual, FormAdmin (sin borde, TopLevel=false)

### **Gestión de Estados:**
- **Estado Inactivo**: ComboBox habilitado, botón "Iniciar Servicio"
- **Estado Activo**: ComboBox deshabilitado, botón "Finalizar Servicio", cronómetro activo
- **Estado Admin**: Panel superior modificado, acceso completo a funciones

### **Patrones de Diseño:**
- **Single Window Pattern**: Una sola ventana con navegación interna
- **Embedded Forms Pattern**: Formularios independientes integrados sin borde
- **State Management**: Control centralizado de estados del sistema
- **Repository Pattern**: AccesoDatos.cs para persistencia
- **Service Layer**: Clases de negocio para lógica específica

## 🎯 Experiencia de Usuario (UX)

### **Principios del Diseño Single Window:**
- **Contexto Siempre Visible**: Estado del servicio y cronómetro siempre presentes
- **Navegación Intuitiva**: Panel lateral con iconos y estados claros
- **Transiciones Fluidas**: Cambio entre módulos sin perder contexto
- **Feedback Inmediato**: Estados visuales claros (habilitado/deshabilitado)

### **Ventajas de la Interfaz Unificada:**
- **Eliminación de Ventanas Múltiples**: Reduce complejidad de navegación
- **Estado Centralizado**: Información del servicio siempre visible
- **Flujo Simplificado**: Sin necesidad de login separado
- **Experiencia Cohesiva**: Sensación de aplicación integrada

### **Comportamientos Dinámicos:**
- **Panel Superior Adaptativo**: Cambia según lugar seleccionado (Comedor/Quincho/Admin)
- **Botones Contextuales**: Habilitación/deshabilitación según estado del servicio
- **Área de Contenido Dinámica**: Carga módulos según selección del panel lateral

## 📊 Testing y Validación

### **Pruebas de Interfaz Unificada:**
1. **Navegación entre Módulos**: Transiciones fluidas entre formularios integrados
2. **Estados del Sistema**: Validación de comportamientos dinámicos
3. **Gestión de Servicios**: Inicio, funcionamiento y finalización
4. **Integración de Formularios**: Carga correcta sin borde en panel contenido

### **Pruebas de Funcionalidad:**
1. **Selección de Lugar**: ComboBox y validaciones de acceso
2. **Cronómetro de Servicio**: Inicio, pausa y finalización correcta
3. **Registro Manual**: Filtros, selección y registro de empleados
4. **Módulo Admin**: Acceso restringido y funciones administrativas

### **Pruebas de Usabilidad:**
1. **Flujo de Trabajo**: Tareas comunes sin interrupciones
2. **Feedback Visual**: Estados claros y comprensibles
3. **Accesibilidad**: Navegación con teclado y elementos grandes
4. **Rendimiento**: Carga rápida de módulos y datos en tiempo real



