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
1. **✅ ucReportes** User Control para reportes (implementado y validado)
    - Estado actual: estructura implementada y verificada. Se aplicaron mejoras de UI (panelTop aumentado, etiquetas sobre controles, DGV redimensionado), ComboBox `Lugar` carga `Todos` por defecto, cabeceras renombradas y columnas internas ocultas.
    - Exportación: exportar a PDF implementado en `ucReportes` (método `ExportarPDF` usando iTextSharp). Dependencia instalada y verificada; Designer y compilación OK.
    - Verificación: exportación a PDF probada y valida — la salida incluye título, timestamp y la línea de filtros justo debajo de "Generado:".
    - Fecha verificación: 29/09/2025.
    - Pendientes: ajustes menores de UX/columnas según feedback, pero funcionalidad principal lista.
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
2. **🔄 ReporteNegocio**: consultas disponibles; la capa de presentación incluye exportación a PDF (implementada y verificada en `ucReportes`). Se recomienda añadir pruebas unitarias/integración para la generación de datos y, si se requiere, exponer una generación en negocio para exportaciones batch o en otros formatos (CSV/Excel).
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

1) Reportes y visualización (alta prioridad)
    - Estado: ✅ Implementado y validado. `ucReportes` y la exportación a PDF funcionan correctamente en el entorno de desarrollo (iTextSharp instalado, Designer y build OK).
    - Acciones inmediatas: recoger feedback de UX y ajustar anchos/orden de columnas si es necesario; planificar tests automáticos para la generación de datos del reporte.

2) ucRegistroManual (media-alta)
    - Estado: funcional y con filtros automáticos. Quedan mejoras UX menores (atajos, resaltado) y validaciones de concurrencia.

3) Último servicio (media)
    - Estado: implementado (resumen en `gbxUltimo` al iniciar y al finalizar). Evaluar desglose por empresa si se requiere.

4) Estadísticas en tiempo real en la UI (media)
    - Mantener `ActualizarEstadisticas()` desde `ucVistaPrincipal` y `ucRegistroManual`. Evaluar refresco periódico si se agregan fuentes externas.

5) Configuración de conexión (baja-media)
    - Mover cadena de conexión de `AccesoDatos.cs` a `App.config` para facilitar despliegues.

6) Módulo Admin (iteración 1)
    - Estado: pendiente. Priorizar pantalla de lectura para empresas y empleados y luego CRUD.

7) RFID (futuro)
    - No iniciado. Diseñar interfaz y simulador antes de integrar.

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

### ✅ Cambios recientes (resumen rápido)

- Se movió el ORDER BY para la lista de servicios al procedimiento almacenado correspondiente (ahora ordena Fecha DESC, IdServicio DESC) para que los reportes muestren del último al primero.
- Se agregó una función de exportación a PDF desde `ucReportes` (archivo generado con iTextSharp) que incluye los filtros aplicados en una línea bajo el campo "Generado:".

### Reportes / ucReportes (avance reciente)

- **Estado:** 🔄 En progreso — la estructura del `ucReportes` está implementada y se han aplicado varias mejoras de UI y funcionalidad; queda verificar y compilar tras añadir la dependencia PDF.
- **Cambios principales realizados:**
    - Ajustes de layout: `panelTop` se amplió verticalmente para igualar el alto del panel superior; las etiquetas de filtros (labels) se colocaron sobre los controles y alineadas a la izquierda para coherencia visual con los otros UCs.
    - DataGridView (`dgvReporte`) redimensionado para aproximarse al tamaño de `dgvRegistros` y mejorar legibilidad.
    - ComboBox de `Lugar` carga la opción inicial como `Todos` (en lugar de un ítem en blanco) y se usa como selección por defecto al generar el reporte.
    - Columnas: se renombraron cabeceras que contenían palabras pegadas; algunas columnas internas/código (`IdServicio`, `IdLugar`, `Estado`) se ocultan en la lista principal por defecto.
    - SQL: el ordenamiento de la lista de servicios se movió al procedimiento almacenado (ORDER BY Fecha DESC, IdServicio DESC) para devolver del último al primero.
    - Exportación: se implementó exportación a PDF (`ExportarPDF`) usando iTextSharp; el PDF incluye título, fecha/hora de generación y, justo debajo de "Generado:", una línea con los filtros aplicados (Fechas, Lugar, Tipo de reporte).

- **Notas técnicas y dependencias:**
    - La implementación del export a PDF utiliza la librería `iTextSharp` y los namespaces `iTextSharp.text` y `iTextSharp.text.pdf` en `ucReportes.cs`.
    - Es necesario instalar el paquete NuGet `iTextSharp` en el proyecto `app` antes de compilar.

- **Pasos de verificación (recomendado):**
    1. Abrir la solución en Visual Studio.
    2. Instalar iTextSharp en el proyecto `app` (dos opciones):

```powershell
# Opción A: Package Manager Console (Visual Studio)
Install-Package iTextSharp

# Opción B: dotnet CLI (desde la raíz del repo en PowerShell)
dotnet add .\SCA\app\app.csproj package iTextSharp
```

    3. Abrir `ucReportes` en el Designer de Visual Studio y confirmar que no hay errores de parsing (si Visual Studio marca líneas en el Designer, inspeccionar las líneas indicadas y eliminar referencias a controles obsoletos o handlers huérfanos).
    4. Compilar la solución (Build -> Rebuild Solution) y ejecutar la UC: generar un reporte y usar el botón "Exportar" para crear un PDF. Verificar que el PDF contiene la tabla con las columnas visibles y la línea de filtros bajo "Generado:".

- **Siguientes pasos recomendados:**
    - Validar en máquina local que el Designer carga correctamente; si hay errores, revisar `ucReportes.Designer.cs` por declaraciones duplicadas o asignaciones a handlers inexistentes (esto se corrigió parcialmente en la última iteración pero conviene confirmar).
    - Si se quiere exportar la grilla completa como imagen (no solo el área visible), considerar implementar una rutina que dibuje fila por fila en un lienzo o que temporalmente expanda la grilla para captura.
    - (Opcional) Añadir pruebas unitarias básicas para la generación de datos del reporte en `ReporteNegocio` y una prueba de integración mínima que verifique el número de columnas/filas exportadas.

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





## Mockup de ucReportes (seleccionado)

Sugerencia: filtros y botones en el panel superior (frmPrincipal); el UC solo contiene grillas (DGVs).

### Mockup C — Panel superior (original) + Tipo de reporte (4 opciones), y un único DGV

Panel superior (frmPrincipal) — filtros globales (como en la imagen base) + tipo de reporte

```
┌───────────────────────────────────────────────────────────────────────────────────────────┐
│                                    FILTROS DE REPORTE                                      │
│  Desde: [__/__]   Hasta: [__/__]    Lugar: [Todos ▼]    Tipo de reporte: [ Lista de servicios ▼ ]  │
│                                                                                   [GENERAR]│
└───────────────────────────────────────────────────────────────────────────────────────────┘
```

Área de datos (UC) — un solo DGV (Servicios)

```
┌──────────────────────────────────────────────────────────────────────────────┐
│                         SERVICIOS ANTERIORES                                  │
│ +--------------------------------------------------------------------------+ │
│ |                                DGV ÚNICO                                  | │
│ |   (Columnas según "Tipo de reporte" seleccionado)                         | │
│ +--------------------------------------------------------------------------+ │
└──────────────────────────────────────────────────────────────────────────────┘
```

Alcance de filtros:
- Desde/Hasta/Lugar: se aplican a todos los tipos de reporte.
- Tipo de reporte (Combo): define qué dataset se carga en el DGV (ver opciones abajo).

Interacciones sugeridas:
- Generar aplica filtros (Desde/Hasta/Lugar) y el tipo de reporte seleccionado, cargando el DGV.
- (Opcional) Doble clic en una fila puede abrir un detalle del servicio en otra vista o diálogo.

Notas generales
- Los filtros y acciones viven en el panel superior; el UC contiene únicamente el DGV.
- Usar WaitCursor durante cargas; evitar bloqueos en UI.
- Recordar la última selección de "Tipo de reporte" para persistir tras recargas.

Tipo de reporte (4 opciones)
- Lista de servicios: Fecha, Lugar, IdServicio, Proyección, Empleados, Invitados, Total, Duración, Cumplimiento%.
- Asistencias por empresas (ranking): Empresa, Total, % sobre el total del período. (Si Lugar=Todos, ranking global; si hay Lugar, ranking por comedor.)
- Cobertura vs proyección: Fecha, Lugar, Proyección, Total, Diferencia (Total−Proy), Cumplimiento%.
- Distribución por día de semana: DíaSemana (Lun..Dom), Total, OcurrenciasEnElRango, PromedioPorOcurrencia (=Total/Ocurrencias), % sobre el total. Si Lugar=Todos, global; si hay Lugar, específico.

Nota: Si preferís otra cuarta opción (p. ej. Intensidad por franjas de 15 min o Estabilidad por lugar), decime y la reemplazo sin problema.

Mapeo de detalle automático (DGV derecho) según la columna seleccionada en el DGV izquierdo:
- Fecha (o click en la fila): mostrar Registros del servicio seleccionado (detalle completo). Empresa y Texto (si existiera) filtran aquí.
- Lugar: mostrar Ranking “Por empresa” del servicio seleccionado.
- Comensales (empleados): mostrar Registros del servicio filtrando tipo Empleado (excluye invitados).
- Invitados: mostrar Registros del servicio filtrando tipo Invitado.
- Total: mostrar Registros del servicio (todos).
- Duración: mostrar Concurrencia por hora del servicio seleccionado.

Notas del mapeo:
- Si una columna no aplica a un tipo de detalle, usar el default: Registros del servicio.
- Si no hay selección en el DGV izquierdo, mantener el derecho vacío con una indicación amigable.





