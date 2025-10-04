
### **Vista General con TabControl**

┌─────────────────────────────────────────────────────────────────────────────┐
│ ADMINISTRADOR │ Empleados │ Empresas │ Estadísticas │ Configuración         │
├───────────────────────────────┬─────────────────────────────────────────────┤
│ LISTA DE EMPLEADOS            │ DETALLES Y EDICIÓN                          │
│                               │                                             │
│  [Buscar...] [Empresa ▼]      │ ┌─────────────────────────────────────────┐ │
│                               │ │ Empleado Seleccionado: Juan Pérez       │ │
│ ┌───────────────────────────┐ │ └─────────────────────────────────────────┘ │
│ │ ● Juan Pérez              │ │                                             │
│ │   1234567 - Empresa A     │ │ Número de Credencial:                       │
│ ├───────────────────────────┤ │ ┌─────────────┐                             │
│ │   María García            │ │ │ 1234567     │  [Verificar disponibilidad] │
│ │   2345678 - Empresa B     │ │ └─────────────┘                             │
│ ├───────────────────────────┤ │                                             │
│ │   Carlos López            │ │ Datos Personales:                           │
│ │   3456789 - Empresa C     │ │ ┌──────────────┐  ┌──────────────┐          │
│ ├───────────────────────────┤ │ │ Juan         │  │ Pérez        │          │
│ │   Ana Martínez            │ │ └──────────────┘  └──────────────┘          │
│ │   4567890 - Empresa A     │ │   Nombre            Apellido                │
│ ├───────────────────────────┤ │                                             │
│ │   Pedro Sánchez           │ │ Empresa Asignada:                           │
│ │   5678901 - Empresa D     │ │ ┌─────────────────────────────────┐         │
│ └───────────────────────────┘ │ │ Empresa A                    ▼  │         │
│                               │ └─────────────────────────────────┘         │
│ [+ Nuevo Empleado]            │                                             │
│                               │ Estado:  ● Activo  ○ Inactivo               │
│ Total: 150 empleados          │                                             │
│ Activos: 145 │ Inactivos: 5   │ ┌─────────┐ ┌─────────┐ ┌─────────┐         │
│                               │ │ Guardar │ │ Cancelar│ │ Eliminar│         │
│                               │ └─────────┘ └─────────┘ └─────────┘         │
└───────────────────────────────┴─────────────────────────────────────────────┘


┌─────────────────────────────────────────────────────────────────────────────┐
│ ADMINISTRADOR │ Empleados │ ● Empresas │ Estadísticas │ Configuración       │
├───────────────────────────────┬─────────────────────────────────────────────┤
│ LISTA DE EMPRESAS             │ DETALLES Y EDICIÓN                          │
│                               │                                             │
│  [Buscar empresa...]          │ ┌─────────────────────────────────────────┐ │
│    [Estado: Todas ▼]          │ │ Empresa Seleccionada: Empresa A         │ │
│                               │ └─────────────────────────────────────────┘ │
│ ┌───────────────────────────┐ │                                             │
│ │ ● Empresa A               │ │ Nombre de la Empresa:                       │
│ │   45 empleados - Activa   │ │ ┌───────────────────────────────────────┐   │
│ ├───────────────────────────┤ │ │ Empresa A                             │   │
│ │   Empresa B               │ │ └───────────────────────────────────────┘   │
│ │   32 empleados - Activa   │ │                                             │
│ ├───────────────────────────┤ │ Estado:                                     │
│ │   Empresa C               │ │ ● Activa    ○ Inactiva                      │
│ │   28 empleados - Activa   │ │                                             │
│ ├───────────────────────────┤ │ ┌─────────────────────────────────────────┐ │
│ │   Empresa D               │ │ │  ESTADÍSTICAS DE LA EMPRESA             │ │
│ │   25 empleados - Activa   │ │ ├─────────────────────────────────────────┤ │
│ ├───────────────────────────┤ │ │ Total de empleados:         45          │ │
│ │   Empresa E               │ │ │ Empleados activos:          43          │ │
│ │   15 empleados - Activa   │ │ │ Empleados inactivos:         2          │ │
│ ├───────────────────────────┤ │ │                                         │ │
│ │   Empresa F               │ │ │ Asistencias (mes actual):   892         │ │
│ │   5 empleados - Activa    │ │ │ Promedio diario:            41          │ │
│ └───────────────────────────┘ │ │ Última asistencia:     02/10/2025       │ │
│                               │ └─────────────────────────────────────────┘ │
│ [+ Nueva Empresa]             │                                             │
│                               │ ┌─────────────────────────────────────────┐ │
│ Total: 8 empresas             │ │  EMPLEADOS DE ESTA EMPRESA              │ │
│ Activas: 8 │ Inactivas: 0     │ │                                         │ │
│                               │ │ [Ver lista completa de empleados ]      │ │
│                               │ └─────────────────────────────────────────┘ │
│                               │                                             │
│                               │ ┌─────────┐ ┌─────────┐ ┌─────────┐         │
│                               │ │ Guardar │ │ Cancelar│ │Eliminar │         │
│                               │ └─────────┘ └─────────┘ └─────────┘         │
└───────────────────────────────┴─────────────────────────────────────────────┘


┌─────────────────────────────────────────────────────────────────────────────┐
│ ADMINISTRADOR │ Empleados │ Empresas │ ● Estadísticas │ Configuración       │
├─────────────────────────────────────────────────────────────────────────────┤
│ ┌─────────────────────────────────────────────────────────────────────────┐ │
│ │ ESTADÍSTICAS GENERALES DEL SISTEMA                                      │ │
│ └─────────────────────────────────────────────────────────────────────────┘ │
│                                                                             │
│ ┌───────────────────────┐ ┌───────────────────────┐ ┌──────────────────┐    │
│ │  EMPLEADOS            │ │  EMPRESAS             │ │  SERVICIOS       │    │
│ │                       │ │                       │ │                  │    │
│ │ Total Registrados:    │ │ Total Activas:        │ │ Este mes:        │    │  
│ │      150              │ │       8               │ │      22          │    │
│ │                       │ │                       │ │                  │    │
│ │ Activos:        145   │ │ Con empleados:        │ │ Total del año:   │    │
│ │ Inactivos:        5   │ │       8               │ │     245          │    │
│ │                       │ │                       │ │                  │    │
│ │ Credenciales únicas:  │ │ Promedio emp/empresa: │ │ Promedio/día:    │    │
│ │      150              │ │      18.75            │ │      68          │    │
│ └───────────────────────┘ └───────────────────────┘ └──────────────────┘    │
│                                                                             │
│ ┌─────────────────────────────────────────────────────────────────────────┐ │
│ │ ASISTENCIAS Y TENDENCIAS                                                │ │
│ ├─────────────────────────────────────────────────────────────────────────┤ │
│ │                                                                         │ │
│ │ Asistencias Totales (mes actual):                              1,496    │ │
│ │ Asistencias de Empleados:                                       1,420   │ │
│ │ Asistencias de Invitados:                                          76   │ │
│ │                                                                         │ │
│ │ Promedio diario de asistencias:                                    68   │ │
│ │ Día con mayor asistencia:                            Viernes (85)       │ │
│ │ Día con menor asistencia:                            Lunes (52)         │ │
│ │                                                                         │ │
│ │ Cobertura promedio vs proyección:                               92.5%   │ │
│ │ Duración promedio de servicio:                            2h 35min      │ │
│ └─────────────────────────────────────────────────────────────────────────┘ │
│                                                                             │
│ ┌─────────────────────────────────────────────────────────────────────────┐ │
│ │  TOP 5 EMPRESAS POR ASISTENCIAS (MES ACTUAL)                            │ │
│ ├─────────────────────────────────────────────────────────────────────────┤ │
│ │ 1. Empresa A ████████████████████████████████████████ 892 (35.2%)       │ │
│ │ 2. Empresa B █████████████████████████████ 625 (24.7%)                  │ │
│ │ 3. Empresa C ████████████████████ 478 (18.9%)                           │ │
│ │ 4. Empresa D ██████████████ 325 (12.8%)                                 │ │
│ │ 5. Empresa E ████████ 212 (8.4%)                                        │ │
│ └─────────────────────────────────────────────────────────────────────── ─┘ │
│                                                                             │
│ ┌─────────────────────────────────────────────────────────────────────────┐ │
│ │ INFORMACIÓN DEL SISTEMA                                                 │ │
│ ├─────────────────────────────────────────────────────────────────────────┤ │
│ │ Base de datos:                    BD_Control_Almuerzos                  │ │
│ │ Última actualización:              02/10/2025 22:25:10                  │ │
│ │ Tamaño de BD:                      125.4 MB                             │ │
│ │ Último respaldo:                   01/10/2025 23:00:00                  │ │
│ └─────────────────────────────────────────────────────────────────────────┘ │
│                                                                             │
│ [ Actualizar Estadísticas] [ Generar Reporte Completo]                      │
└─────────────────────────────────────────────────────────────────────────────┘


┌─────────────────────────────────────────────────────────────────────────────┐
│ ADMINISTRADOR │ Empleados │ Empresas │ Estadísticas │ ● Configuración       │
├─────────────────────────────────────────────────────────────────────────────┤
│ ┌─────────────────────────────────────────────────────────────────────────┐ │
│ │  CONFIGURACIÓN DEL SISTEMA                                              │ │
│ └─────────────────────────────────────────────────────────────────────────┘ │
│                                                                             │
│ ┌─────────────────────────────────────────────────────────────────────────┐ │
│ │  BASE DE DATOS                                                          │ │
│ ├─────────────────────────────────────────────────────────────────────────┤ │
│ │                                                                         │ │
│ │ Cadena de Conexión:                                                     │ │
│ │ ┌─────────────────────────────────────────────────────────────────────┐ │ │
│ │ │ server=.\SQLEXPRESS; database=BD_Control_Almuerzos; integrated...   │ │ │
│ │ └─────────────────────────────────────────────────────────────────────┘ │ │
│ │                                                                         │ │
│ │ [Probar Conexión] [Guardar Cambios]                                     │ │
│ │                                                                         │ │
│ │ Estado de conexión: Conectado correctamente                             │ │
│ │                                                                         │ │
│ └─────────────────────────────────────────────────────────────────────────┘ │
│                                                                             │
│ ┌─────────────────────────────────────────────────────────────────────────┐ │
│ │  RESPALDOS Y RESTAURACIÓN                                               │ │
│ ├─────────────────────────────────────────────────────────────────────────┤ │
│ │                                                                         │ │
│ │ Ruta de respaldos:                                                      │ │
│ │ ┌─────────────────────────────────────────────┐                         │ │
│ │ │ C:\Respaldos\BD_Control_Almuerzos\          │   [ Examinar]           │ │
│ │ └─────────────────────────────────────────────┘                         │ │
│ │                                                                         │ │
│ │ Frecuencia de respaldo automático:                                      │ │
│ │ ● Diario (23:00)   ○ Semanal   ○ Manual                                 │ │
│ │                                                                         │ │
│ │ Último respaldo:  01/10/2025 23:00:00                                   │ │
│ │ Tamaño:           125.4 MB                                              │ │
│ │                                                                         │ │
│ │ [ Crear Respaldo Ahora] [Restaurar desde Respaldo]                      │ │
│ │                                                                         │ │
│ └─────────────────────────────────────────────────────────────────────────┘ │
│                                                                             │
│ ┌─────────────────────────────────────────────────────────────────────────┐ │
│ │ LECTOR RFID (FUTURO)                                                    │ │
│ ├─────────────────────────────────────────────────────────────────────────┤ │
│ │                                                                         │ │
│ │ Puerto COM:                                                             │ │
│ │ ┌──────────┐                                                            │ │
│ │ │ COM3  ▼  │  [Detectar Automáticamente]                                │ │
│ │ └──────────┘                                                            │ │
│ │                                                                         │ │
│ │ Velocidad (Baud Rate):                                                  │ │
│ │ ┌──────────┐                                                            │ │
│ │ │ 9600  ▼  │                                                            │ │
│ │ └──────────┘                                                            │ │
│ │                                                                         │ │
│ │ Estado: ○ No configurado                                                │ │
│ │                                                                         │ │
│ │ [ Configurar] [ Probar Lector]                                          │ │
│ │                                                                         │ │
│ └─────────────────────────────────────────────────────────────────────────┘ │
│                                                                             │
│ ┌─────────────────────────────────────────────────────────────────────────┐ │
│ │  PREFERENCIAS DE INTERFAZ                                               │ │
│ ├─────────────────────────────────────────────────────────────────────────┤ │
│ │                                                                         │ │
│ │ Formato de fecha:  ● dd/MM/yyyy   ○ MM/dd/yyyy   ○ yyyy-MM-dd           │ │
│ │                                                                         │ │
│ │ Sonido de confirmación al registrar:  [] Habilitado                     │ │
│ │                                                                         │ │
│ │ Actualización automática de estadísticas:  [] Habilitado                │ │
│ │                                                                         │ │
│ └─────────────────────────────────────────────────────────────────────────┘ │
│                                                                             │
│ ┌─────────────────────────────────────────────────────────────────────────┐ │
│ │ INFORMACIÓN DE LA APLICACIÓN                                            │ │
│ ├─────────────────────────────────────────────────────────────────────────┤ │
│ │                                                                         │ │
│ │ Versión:                       2.0.0                                    │ │
│ │ Fecha de compilación:          02/10/2025                               │ │
│ │ Framework:                     .NET Framework 4.8.1                     │ │
│ │ UI Library:                    ReaLTaiizor                              │ │
│ │                                                                         │ │
│ │ [Ver Logs del Sistema] [Reportar Problema]                              │ │
│ │                                                                         │ │
│ └─────────────────────────────────────────────────────────────────────────┘ │
│                                                                             │
│                                [Guardar Todos los Cambios]                  │
└─────────────────────────────────────────────────────────────────────────────┘


## 🎨 ESTRUCTURA VISUAL

### **Vista General con Sistema de Navegación por Botones**

```
┌─────────────────────────────────────────────────────────────────────────────┐
│ [Empleados] [Empresas] [Estadísticas] [Configuración]   ← Barra de botones │
├─────────────────────────────────────────────────────────────────────────────┤
│                                                                             │
│                         PANEL ACTIVO (Dinámico)                             │
│                                                                             │
│  - pnlEmpleados     (visible cuando se presiona btnEmpleados)               │
│  - pnlEmpresas      (visible cuando se presiona btnEmpresas)                │
│  - pnlEstadisticas  (visible cuando se presiona btnEstadisticas)            │
│  - pnlConfiguracion (visible cuando se presiona btnConfiguracion)           │
│                                                                             │
└─────────────────────────────────────────────────────────────────────────────┘
```

### **Sistema de Colores**
```csharp
Color colorDorado = Color.FromArgb(255, 208, 36);   // Estado ACTIVO
Color colorNegro = Color.FromArgb(35, 34, 33);      // Estado INACTIVO
Color colorFondo = Color.FromArgb(255, 248, 225);   // Fondo general
```

---

## 📝 PASO A PASO PARA EL DESARROLLO

### **FASE 1: Preparación y Estructura Base** ✅ (Ya implementada)


#### **Paso 1.2: Estructura de Navegación**

**Panel de Botones (pnlBotones):**
```
Dock: Top
Height: 70px
BackColor: Color.FromArgb(255, 248, 225)
Padding: 15px
```

**Botones de Navegación (ReaLTaiizor.Controls.Button):**
```
btnEmpleados
btnEmpresas
btnEstadisticas
btnConfiguracion

Propiedades comunes:
- Size: 150x40
- Font: Segoe UI, 11pt, Bold
- BorderColor: Color.FromArgb(35, 34, 33)
- Anchor: Top (centrados)
- Spacing: 165px entre cada uno
```

**Paneles de Contenido:**
```
pnlEmpleados
pnlEmpresas
pnlEstadisticas
pnlConfiguracion

Propiedades comunes:
- Dock: Fill (pero posicionados debajo de pnlBotones)
- Location: (0, 70)
- Padding: 15px
- BackColor: Color.FromArgb(255, 248, 225)
- Visible: false (excepto el activo)
```

#### **Paso 1.3: Sistema de Selección de Botones** ✅

**Código ya implementado:**
```csharp
private ReaLTaiizor.Controls.Button botonActivo;

private void SeleccionarBoton(ReaLTaiizor.Controls.Button boton)
{
    Color colorDorado = Color.FromArgb(255, 208, 36);
    Color colorNegro = Color.FromArgb(35, 34, 33);

    // Restaurar botón anterior
    if (botonActivo != null)
    {
        botonActivo.InactiveColor = colorNegro;
        botonActivo.PressedColor = colorDorado;
    }

    // Activar nuevo botón
    botonActivo = boton;
    boton.InactiveColor = colorDorado;
    boton.PressedColor = colorDorado;
}

private void MostrarPanel(Panel panelAMostrar)
{
    // Ocultar todos
    pnlEmpleados.Visible = false;
    pnlEmpresas.Visible = false;
    pnlEstadisticas.Visible = false;
    pnlConfiguracion.Visible = false;

    // Mostrar el seleccionado
    panelAMostrar.Visible = true;
    panelAMostrar.BringToFront();
}
```

---

### **FASE 2: Panel EMPLEADOS**

#### **Paso 2.1: Diseñar el layout de división (SplitContainer)**

Agregar dentro de `pnlEmpleados`:

```csharp
// EN EL DESIGNER
SplitContainer splitEmpleados = new SplitContainer();
splitEmpleados.Dock = DockStyle.Fill;
splitEmpleados.Orientation = Orientation.Vertical;
splitEmpleados.SplitterDistance = 450;
splitEmpleados.FixedPanel = FixedPanel.Panel1;
splitEmpleados.IsSplitterFixed = true;
splitEmpleados.SplitterWidth = 2;
pnlEmpleados.Controls.Add(splitEmpleados);
```

#### **Paso 2.2: Panel Izquierdo - Lista de Empleados**

**Estructura del Panel1:**
```
┌─────────────────────────────────────┐
│ Panel Superior (Búsqueda y Filtros) │
├─────────────────────────────────────┤
│                                     │
│      DataGridView (dgvEmpleados)    │
│                                     │
├─────────────────────────────────────┤
│ Panel Inferior (Totales + Agregar)  │
└─────────────────────────────────────┘
```

**Controles a agregar:**

1. **Panel Superior:**
```csharp
Panel pnlBusquedaEmpleados = new Panel();
pnlBusquedaEmpleados.Dock = DockStyle.Top;
pnlBusquedaEmpleados.Height = 80;
pnlBusquedaEmpleados.Padding = new Padding(10);

// TextBox de búsqueda
TextBox txtBuscarEmpleado = new TextBox();
txtBuscarEmpleado.Location = new Point(10, 10);
txtBuscarEmpleado.Width = 200;
txtBuscarEmpleado.PlaceholderText = "Buscar empleado...";
txtBuscarEmpleado.TextChanged += txtBuscarEmpleado_TextChanged;

// ComboBox filtro empresa
ComboBox cbFiltroEmpresa = new ComboBox();
cbFiltroEmpresa.Location = new Point(220, 10);
cbFiltroEmpresa.Width = 150;
cbFiltroEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;

// ComboBox filtro estado
ComboBox cbFiltroEstado = new ComboBox();
cbFiltroEstado.Location = new Point(10, 45);
cbFiltroEstado.Width = 120;
cbFiltroEstado.Items.AddRange(new[] { "Todos", "Activos", "Inactivos" });
cbFiltroEstado.SelectedIndex = 0;
```

2. **DataGridView:**
```csharp
DataGridView dgvEmpleados = new DataGridView();
dgvEmpleados.Dock = DockStyle.Fill;
dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
dgvEmpleados.MultiSelect = false;
dgvEmpleados.ReadOnly = true;
dgvEmpleados.AllowUserToAddRows = false;
dgvEmpleados.AllowUserToDeleteRows = false;
dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
dgvEmpleados.BackgroundColor = Color.White;
dgvEmpleados.BorderStyle = BorderStyle.None;
dgvEmpleados.SelectionChanged += dgvEmpleados_SelectionChanged;

// Columnas
dgvEmpleados.Columns.Add("IdEmpleado", "ID");
dgvEmpleados.Columns["IdEmpleado"].Visible = false;
dgvEmpleados.Columns.Add("Credencial", "Credencial");
dgvEmpleados.Columns["Credencial"].Width = 100;
dgvEmpleados.Columns.Add("NombreCompleto", "Nombre Completo");
dgvEmpleados.Columns.Add("Empresa", "Empresa");
dgvEmpleados.Columns.Add("Estado", "Estado");
dgvEmpleados.Columns["Estado"].Width = 80;
```

3. **Panel Inferior:**
```csharp
Panel pnlInferiorEmpleados = new Panel();
pnlInferiorEmpleados.Dock = DockStyle.Bottom;
pnlInferiorEmpleados.Height = 60;
pnlInferiorEmpleados.Padding = new Padding(10);

Label lblTotalEmpleados = new Label();
lblTotalEmpleados.Text = "Total: 0 empleados";
lblTotalEmpleados.Location = new Point(10, 20);
lblTotalEmpleados.AutoSize = true;

ReaLTaiizor.Controls.Button btnNuevoEmpleado = new ReaLTaiizor.Controls.Button();
btnNuevoEmpleado.Text = "+ Nuevo Empleado";
btnNuevoEmpleado.Size = new Size(150, 35);
btnNuevoEmpleado.Location = new Point(250, 12);
btnNuevoEmpleado.Click += btnNuevoEmpleado_Click;
```

#### **Paso 2.3: Panel Derecho - Formulario de Edición**

**Estructura del Panel2:**
```
┌─────────────────────────────────────┐
│   GroupBox: Detalles del Empleado   │
│                                     │
│   [Credencial]  [Verificar]         │
│   [Nombre]      [Apellido]          │
│   [Empresa ▼]                       │
│   ● Activo  ○ Inactivo              │
│                                     │
│   [Guardar] [Cancelar] [Eliminar]   │
└─────────────────────────────────────┘
```

**Controles a agregar:**

```csharp
GroupBox gbEmpleadoDetalle = new GroupBox();
gbEmpleadoDetalle.Text = "Detalles del Empleado";
gbEmpleadoDetalle.Dock = DockStyle.Fill;
gbEmpleadoDetalle.Padding = new Padding(20);
gbEmpleadoDetalle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

int yPos = 30;
int labelWidth = 150;
int controlWidth = 250;
int spacing = 50;

// Credencial
Label lblCredencial = new Label();
lblCredencial.Text = "Número de Credencial:";
lblCredencial.Location = new Point(20, yPos);
lblCredencial.AutoSize = true;

TextBox txtCredencial = new TextBox();
txtCredencial.Location = new Point(20, yPos + 25);
txtCredencial.Width = 150;
txtCredencial.MaxLength = 20;

ReaLTaiizor.Controls.Button btnVerificarCredencial = new ReaLTaiizor.Controls.Button();
btnVerificarCredencial.Text = "Verificar";
btnVerificarCredencial.Location = new Point(180, yPos + 23);
btnVerificarCredencial.Size = new Size(100, 25);
btnVerificarCredencial.Click += btnVerificarCredencial_Click;

yPos += spacing;

// Nombre
Label lblNombre = new Label();
lblNombre.Text = "Nombre:";
lblNombre.Location = new Point(20, yPos);
lblNombre.AutoSize = true;

TextBox txtNombre = new TextBox();
txtNombre.Location = new Point(20, yPos + 25);
txtNombre.Width = controlWidth;
txtNombre.MaxLength = 50;

yPos += spacing;

// Apellido
Label lblApellido = new Label();
lblApellido.Text = "Apellido:";
lblApellido.Location = new Point(20, yPos);
lblApellido.AutoSize = true;

TextBox txtApellido = new TextBox();
txtApellido.Location = new Point(20, yPos + 25);
txtApellido.Width = controlWidth;
txtApellido.MaxLength = 50;

yPos += spacing;

// Empresa
Label lblEmpresa = new Label();
lblEmpresa.Text = "Empresa Asignada:";
lblEmpresa.Location = new Point(20, yPos);
lblEmpresa.AutoSize = true;

ComboBox cbEmpresaEmpleado = new ComboBox();
cbEmpresaEmpleado.Location = new Point(20, yPos + 25);
cbEmpresaEmpleado.Width = controlWidth;
cbEmpresaEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;

yPos += spacing;

// Estado
Label lblEstado = new Label();
lblEstado.Text = "Estado:";
lblEstado.Location = new Point(20, yPos);
lblEstado.AutoSize = true;

RadioButton rbActivoEmpleado = new RadioButton();
rbActivoEmpleado.Text = "Activo";
rbActivoEmpleado.Location = new Point(20, yPos + 25);
rbActivoEmpleado.Checked = true;

RadioButton rbInactivoEmpleado = new RadioButton();
rbInactivoEmpleado.Text = "Inactivo";
rbInactivoEmpleado.Location = new Point(120, yPos + 25);

yPos += spacing + 20;

// Botones de acción
Panel pnlBotonesEmpleado = new Panel();
pnlBotonesEmpleado.Location = new Point(20, yPos);
pnlBotonesEmpleado.Size = new Size(400, 45);

ReaLTaiizor.Controls.Button btnGuardarEmpleado = new ReaLTaiizor.Controls.Button();
btnGuardarEmpleado.Text = "Guardar";
btnGuardarEmpleado.Size = new Size(100, 35);
btnGuardarEmpleado.Location = new Point(0, 0);
btnGuardarEmpleado.Click += btnGuardarEmpleado_Click;

ReaLTaiizor.Controls.Button btnCancelarEmpleado = new ReaLTaiizor.Controls.Button();
btnCancelarEmpleado.Text = "Cancelar";
btnCancelarEmpleado.Size = new Size(100, 35);
btnCancelarEmpleado.Location = new Point(110, 0);
btnCancelarEmpleado.Click += btnCancelarEmpleado_Click;

ReaLTaiizor.Controls.Button btnEliminarEmpleado = new ReaLTaiizor.Controls.Button();
btnEliminarEmpleado.Text = "Eliminar";
btnEliminarEmpleado.Size = new Size(100, 35);
btnEliminarEmpleado.Location = new Point(220, 0);
btnEliminarEmpleado.Enabled = false;
btnEliminarEmpleado.Click += btnEliminarEmpleado_Click;

pnlBotonesEmpleado.Controls.AddRange(new Control[] { 
    btnGuardarEmpleado, btnCancelarEmpleado, btnEliminarEmpleado 
});
```

#### **Paso 2.4: Implementar código de Empleados**

**Agregar en ucAdmin.cs:**

```csharp
using dominio;
using negocio;
using System;
using System.Windows.Forms;

public partial class ucAdmin : UserControl
{
    // VARIABLES DE CLASE
    private EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
    private EmpresaNegocio empresaNegocio = new EmpresaNegocio();
    private Empleado empleadoSeleccionado = null;
    private bool modoEdicion = false;

    public ucAdmin()
    {
        InitializeComponent();
        SeleccionarBoton(btnEmpleados); // Botón activo por defecto
    }

    private void ucAdmin_Load(object sender, EventArgs e)
    {
        CargarEmpleados();
        CargarEmpresas();
        LimpiarFormularioEmpleado();
    }

    // ══════════════════════════════════════════════════════════════
    // MÉTODOS DE CARGA DE DATOS
    // ══════════════════════════════════════════════════════════════

    private void CargarEmpleados(string filtro = "")
    {
        try
        {
            var empleados = empleadoNegocio.listar();
            
            // Aplicar filtros si existen
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                empleados = empleados.FindAll(e => 
                    e.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                    e.Apellido.ToUpper().Contains(filtro.ToUpper()) ||
                    e.IdCredencial.Contains(filtro)
                );
            }

            // Filtrar por empresa si está seleccionada
            if (cbFiltroEmpresa.SelectedIndex > 0)
            {
                int idEmpresa = (int)cbFiltroEmpresa.SelectedValue;
                empleados = empleados.FindAll(e => e.Empresa.IdEmpresa == idEmpresa);
            }

            // Filtrar por estado
            if (cbFiltroEstado.SelectedIndex == 1) // Activos
                empleados = empleados.FindAll(e => e.Estado);
            else if (cbFiltroEstado.SelectedIndex == 2) // Inactivos
                empleados = empleados.FindAll(e => !e.Estado);

            dgvEmpleados.Rows.Clear();
            foreach (var emp in empleados)
            {
                dgvEmpleados.Rows.Add(
                    emp.IdEmpleado,
                    emp.IdCredencial,
                    $"{emp.Nombre} {emp.Apellido}",
                    emp.Empresa.Nombre,
                    emp.Estado ? "Activo" : "Inactivo"
                );
            }

            lblTotalEmpleados.Text = $"Total: {dgvEmpleados.RowCount} empleados";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar empleados: {ex.Message}", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarEmpresas()
    {
        try
        {
            var empresas = empresaNegocio.listar();
            
            // Para el filtro (con opción "Todas")
            var empresasFiltro = new List<Empresa>();
            empresasFiltro.Add(new Empresa { IdEmpresa = 0, Nombre = "Todas las empresas" });
            empresasFiltro.AddRange(empresas);
            
            cbFiltroEmpresa.DataSource = empresasFiltro;
            cbFiltroEmpresa.DisplayMember = "Nombre";
            cbFiltroEmpresa.ValueMember = "IdEmpresa";
            
            // Para el formulario de edición
            cbEmpresaEmpleado.DataSource = empresas;
            cbEmpresaEmpleado.DisplayMember = "Nombre";
            cbEmpresaEmpleado.ValueMember = "IdEmpresa";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar empresas: {ex.Message}", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ══════════════════════════════════════════════════════════════
    // EVENTOS DE EMPLEADOS
    // ══════════════════════════════════════════════════════════════

    private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvEmpleados.CurrentRow != null)
        {
            int idEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
            CargarEmpleadoEnFormulario(idEmpleado);
        }
    }

    private void CargarEmpleadoEnFormulario(int idEmpleado)
    {
        try
        {
            empleadoSeleccionado = empleadoNegocio.buscarPorId(idEmpleado);
            
            txtCredencial.Text = empleadoSeleccionado.IdCredencial;
            txtNombre.Text = empleadoSeleccionado.Nombre;
            txtApellido.Text = empleadoSeleccionado.Apellido;
            cbEmpresaEmpleado.SelectedValue = empleadoSeleccionado.Empresa.IdEmpresa;
            
            if (empleadoSeleccionado.Estado)
                rbActivoEmpleado.Checked = true;
            else
                rbInactivoEmpleado.Checked = true;
            
            modoEdicion = true;
            btnEliminarEmpleado.Enabled = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar empleado: {ex.Message}", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnNuevoEmpleado_Click(object sender, EventArgs e)
    {
        LimpiarFormularioEmpleado();
        modoEdicion = false;
        empleadoSeleccionado = null;
        txtCredencial.Focus();
    }

    private void btnGuardarEmpleado_Click(object sender, EventArgs e)
    {
        if (!ValidarFormularioEmpleado())
            return;

        try
        {
            Empleado emp = new Empleado();
            
            if (modoEdicion && empleadoSeleccionado != null)
                emp.IdEmpleado = empleadoSeleccionado.IdEmpleado;
            
            emp.IdCredencial = txtCredencial.Text.Trim();
            emp.Nombre = txtNombre.Text.Trim();
            emp.Apellido = txtApellido.Text.Trim();
            emp.Empresa = new Empresa();
            emp.Empresa.IdEmpresa = (int)cbEmpresaEmpleado.SelectedValue;
            emp.Estado = rbActivoEmpleado.Checked;

            if (modoEdicion)
                empleadoNegocio.modificar(emp);
            else
                empleadoNegocio.agregar(emp);

            MessageBox.Show("Empleado guardado correctamente", "Éxito", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            CargarEmpleados();
            LimpiarFormularioEmpleado();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al guardar: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnEliminarEmpleado_Click(object sender, EventArgs e)
    {
        if (empleadoSeleccionado == null)
            return;

        var result = MessageBox.Show(
            $"¿Está seguro de desactivar al empleado {empleadoSeleccionado.Nombre} {empleadoSeleccionado.Apellido}?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                empleadoNegocio.eliminar(empleadoSeleccionado.IdEmpleado);
                MessageBox.Show("Empleado desactivado correctamente", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEmpleados();
                LimpiarFormularioEmpleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnCancelarEmpleado_Click(object sender, EventArgs e)
    {
        LimpiarFormularioEmpleado();
    }

    private void btnVerificarCredencial_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCredencial.Text))
        {
            MessageBox.Show("Ingrese un número de credencial", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            bool existe = empleadoNegocio.existeCredencial(txtCredencial.Text.Trim());
            
            // Si existe y NO estamos en modo edición, es un problema
            // Si existe y SÍ estamos en modo edición, verificar que sea la misma credencial
            if (existe)
            {
                if (!modoEdicion || 
                    (modoEdicion && empleadoSeleccionado.IdCredencial != txtCredencial.Text.Trim()))
                {
                    MessageBox.Show("Esta credencial ya está en uso", "No disponible", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Credencial actual del empleado", "Información", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Credencial disponible", "Disponible", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void txtBuscarEmpleado_TextChanged(object sender, EventArgs e)
    {
        CargarEmpleados(txtBuscarEmpleado.Text);
    }

    // ══════════════════════════════════════════════════════════════
    // MÉTODOS AUXILIARES
    // ══════════════════════════════════════════════════════════════

    private bool ValidarFormularioEmpleado()
    {
        if (string.IsNullOrWhiteSpace(txtCredencial.Text))
        {
            MessageBox.Show("Ingrese el número de credencial", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCredencial.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("Ingrese el nombre", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNombre.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtApellido.Text))
        {
            MessageBox.Show("Ingrese el apellido", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtApellido.Focus();
            return false;
        }

        if (cbEmpresaEmpleado.SelectedIndex == -1)
        {
            MessageBox.Show("Seleccione una empresa", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void LimpiarFormularioEmpleado()
    {
        txtCredencial.Clear();
        txtNombre.Clear();
        txtApellido.Clear();
        cbEmpresaEmpleado.SelectedIndex = -1;
        rbActivoEmpleado.Checked = true;
        btnEliminarEmpleado.Enabled = false;
        empleadoSeleccionado = null;
        modoEdicion = false;
    }
}
```

---

### **FASE 3: Panel EMPRESAS**

(Estructura similar a Empleados, pero con formulario más simple)

#### **Paso 3.1: Diseñar layout**

Agregar SplitContainer en `pnlEmpresas` con la misma estructura que Empleados.

#### **Paso 3.2: Panel Izquierdo - Lista de Empresas**

Similar al de empleados pero con columnas:
- IdEmpresa (hidden)
- Nombre
- CantidadEmpleados
- Estado

#### **Paso 3.3: Panel Derecho - Formulario + Estadísticas**

```
┌─────────────────────────────────────┐
│   GroupBox: Detalles de la Empresa  │
│   [Nombre]                          │
│   ● Activa  ○ Inactiva              │
│   [Guardar] [Cancelar] [Eliminar]   │
├─────────────────────────────────────┤
│   GroupBox: Estadísticas            │
│   Total empleados: XX               │
│   Activos: XX                       │
│   Inactivos: XX                     │
│   Asistencias (mes): XXX            │
└─────────────────────────────────────┘
```

---

### **FASE 4: Panel ESTADÍSTICAS**

Sin división, todo en un solo panel con scroll.

#### **Paso 4.1: Diseñar Cards de Métricas**

```csharp
// Configurar pnlEstadisticas
pnlEstadisticas.AutoScroll = true;

// Panel contenedor
Panel pnlContenedorStats = new Panel();
pnlContenedorStats.AutoSize = true;
pnlContenedorStats.AutoSizeMode = AutoSizeMode.GrowAndShrink;
pnlContenedorStats.Padding = new Padding(20);
pnlEstadisticas.Controls.Add(pnlContenedorStats);

// GroupBox Estadísticas Generales
GroupBox gbEstadisticasGenerales = new GroupBox();
gbEstadisticasGenerales.Text = "ESTADÍSTICAS GENERALES DEL SISTEMA";
gbEstadisticasGenerales.Size = new Size(pnlEstadisticas.Width - 80, 180);
gbEstadisticasGenerales.Location = new Point(20, 20);
gbEstadisticasGenerales.Font = new Font("Segoe UI", 11, FontStyle.Bold);

// Crear 3 cards lado a lado
int cardWidth = 300;
int cardHeight = 120;
int cardSpacing = 20;

// Card 1: EMPLEADOS
Panel cardEmpleados = CrearCard("EMPLEADOS", 20, 40, cardWidth, cardHeight);
Label lblTotalEmpleados = new Label();
lblTotalEmpleados.Text = "Total Registrados: 0";
lblTotalEmpleados.Location = new Point(10, 30);
lblTotalEmpleados.AutoSize = true;

Label lblActivosInactivos = new Label();
lblActivosInactivos.Text = "Activos: 0 | Inactivos: 0";
lblActivosInactivos.Location = new Point(10, 55);
lblActivosInactivos.AutoSize = true;

Label lblCredencialesUnicas = new Label();
lblCredencialesUnicas.Text = "Credenciales únicas: 0";
lblCredencialesUnicas.Location = new Point(10, 80);
lblCredencialesUnicas.AutoSize = true;

cardEmpleados.Controls.AddRange(new Control[] { 
    lblTotalEmpleados, lblActivosInactivos, lblCredencialesUnicas 
});
gbEstadisticasGenerales.Controls.Add(cardEmpleados);

// Card 2: EMPRESAS
Panel cardEmpresas = CrearCard("EMPRESAS", 
    20 + cardWidth + cardSpacing, 40, cardWidth, cardHeight);
Label lblTotalEmpresas = new Label();
lblTotalEmpresas.Text = "Total Activas: 0";
lblTotalEmpresas.Location = new Point(10, 30);
lblTotalEmpresas.AutoSize = true;

Label lblPromedioEmpleados = new Label();
lblPromedioEmpleados.Text = "Promedio emp/empresa: 0";
lblPromedioEmpleados.Location = new Point(10, 55);
lblPromedioEmpleados.AutoSize = true;

cardEmpresas.Controls.AddRange(new Control[] { 
    lblTotalEmpresas, lblPromedioEmpleados 
});
gbEstadisticasGenerales.Controls.Add(cardEmpresas);

// Card 3: SERVICIOS
Panel cardServicios = CrearCard("SERVICIOS", 
    20 + (cardWidth + cardSpacing) * 2, 40, cardWidth, cardHeight);
Label lblServiciosMes = new Label();
lblServiciosMes.Text = "Este mes: 0";
lblServiciosMes.Location = new Point(10, 30);
lblServiciosMes.AutoSize = true;

Label lblServiciosAnio = new Label();
lblServiciosAnio.Text = "Total del año: 0";
lblServiciosAnio.Location = new Point(10, 55);
lblServiciosAnio.AutoSize = true;

Label lblPromedioDia = new Label();
lblPromedioDia.Text = "Promedio/día: 0";
lblPromedioDia.Location = new Point(10, 80);
lblPromedioDia.AutoSize = true;

cardServicios.Controls.AddRange(new Control[] { 
    lblServiciosMes, lblServiciosAnio, lblPromedioDia 
});
gbEstadisticasGenerales.Controls.Add(cardServicios);

pnlContenedorStats.Controls.Add(gbEstadisticasGenerales);
```

**Método auxiliar para crear cards:**
```csharp
private Panel CrearCard(string titulo, int x, int y, int width, int height)
{
    Panel card = new Panel();
    card.Location = new Point(x, y);
    card.Size = new Size(width, height);
    card.BackColor = Color.White;
    card.BorderStyle = BorderStyle.FixedSingle;

    Label lblTitulo = new Label();
    lblTitulo.Text = titulo;
    lblTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
    lblTitulo.Location = new Point(10, 10);
    lblTitulo.AutoSize = true;
    lblTitulo.ForeColor = Color.FromArgb(35, 34, 33);
    
    card.Controls.Add(lblTitulo);
    return card;
}
```

#### Paso 4.2: GroupBox de Asistencias y Tendencias

```csharp
GroupBox gbAsistencias = new GroupBox();
gbAsistencias.Text = "ASISTENCIAS Y TENDENCIAS";
gbAsistencias.Size = new Size(pnlEstadisticas.Width - 80, 200);
gbAsistencias.Location = new Point(20, 220);
gbAsistencias.Font = new Font("Segoe UI", 11, FontStyle.Bold);

int yPosLabel = 30;
int lineSpacing = 25;

Label lblAsistenciasTotales = new Label();
lblAsistenciasTotales.Text = "Asistencias Totales (mes actual): 0";
lblAsistenciasTotales.Location = new Point(20, yPosLabel);
lblAsistenciasTotales.AutoSize = true;

Label lblAsistenciasEmpleados = new Label();
lblAsistenciasEmpleados.Text = "Asistencias de Empleados: 0";
lblAsistenciasEmpleados.Location = new Point(20, yPosLabel + lineSpacing);
lblAsistenciasEmpleados.AutoSize = true;

Label lblAsistenciasInvitados = new Label();
lblAsistenciasInvitados.Text = "Asistencias de Invitados: 0";
lblAsistenciasInvitados.Location = new Point(20, yPosLabel + lineSpacing * 2);
lblAsistenciasInvitados.AutoSize = true;

Label lblPromedioDiario = new Label();
lblPromedioDiario.Text = "Promedio diario de asistencias: 0";
lblPromedioDiario.Location = new Point(20, yPosLabel + lineSpacing * 3);
lblPromedioDiario.AutoSize = true;

Label lblDiaMayor = new Label();
lblDiaMayor.Text = "Día con mayor asistencia: -";
lblDiaMayor.Location = new Point(20, yPosLabel + lineSpacing * 4);
lblDiaMayor.AutoSize = true;

Label lblDiaMenor = new Label();
lblDiaMenor.Text = "Día con menor asistencia: -";
lblDiaMenor.Location = new Point(20, yPosLabel + lineSpacing * 5);
lblDiaMenor.AutoSize = true;

gbAsistencias.Controls.AddRange(new Control[] {
    lblAsistenciasTotales, lblAsistenciasEmpleados, lblAsistenciasInvitados,
    lblPromedioDiario, lblDiaMayor, lblDiaMenor
});

pnlContenedorStats.Controls.Add(gbAsistencias);
```

#### Paso 4.3: Top 5 Empresas

```csharp
GroupBox gbTopEmpresas = new GroupBox();
gbTopEmpresas.Text = "TOP 5 EMPRESAS POR ASISTENCIAS (MES ACTUAL)";
gbTopEmpresas.Size = new Size(pnlEstadisticas.Width - 80, 250);
gbTopEmpresas.Location = new Point(20, 440);
gbTopEmpresas.Font = new Font("Segoe UI", 11, FontStyle.Bold);

DataGridView dgvTopEmpresas = new DataGridView();
dgvTopEmpresas.Location = new Point(20, 35);
dgvTopEmpresas.Size = new Size(gbTopEmpresas.Width - 50, 180);
dgvTopEmpresas.ReadOnly = true;
dgvTopEmpresas.AllowUserToAddRows = false;
dgvTopEmpresas.AllowUserToDeleteRows = false;
dgvTopEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
dgvTopEmpresas.BackgroundColor = Color.White;
dgvTopEmpresas.BorderStyle = BorderStyle.None;

dgvTopEmpresas.Columns.Add("Posicion", "#");
dgvTopEmpresas.Columns["Posicion"].Width = 40;
dgvTopEmpresas.Columns.Add("Empresa", "Empresa");
dgvTopEmpresas.Columns.Add("Asistencias", "Asistencias");
dgvTopEmpresas.Columns["Asistencias"].Width = 100;
dgvTopEmpresas.Columns.Add("Porcentaje", "Porcentaje");
dgvTopEmpresas.Columns["Porcentaje"].Width = 100;

gbTopEmpresas.Controls.Add(dgvTopEmpresas);
pnlContenedorStats.Controls.Add(gbTopEmpresas);
```

#### Paso 4.4: Información del Sistema

```csharp
GroupBox gbInfoSistema = new GroupBox();
gbInfoSistema.Text = "INFORMACIÓN DEL SISTEMA";
gbInfoSistema.Size = new Size(pnlEstadisticas.Width - 80, 150);
gbInfoSistema.Location = new Point(20, 710);
gbInfoSistema.Font = new Font("Segoe UI", 11, FontStyle.Bold);

Label lblBaseDatos = new Label();
lblBaseDatos.Text = "Base de datos: BD_Control_Almuerzos";
lblBaseDatos.Location = new Point(20, 35);
lblBaseDatos.AutoSize = true;

Label lblUltimaActualizacion = new Label();
lblUltimaActualizacion.Text = "Última actualización: --/--/---- --:--:--";
lblUltimaActualizacion.Location = new Point(20, 60);
lblUltimaActualizacion.AutoSize = true;

Label lblTamanioBD = new Label();
lblTamanioBD.Text = "Tamaño de BD: 0 MB";
lblTamanioBD.Location = new Point(20, 85);
lblTamanioBD.AutoSize = true;

Label lblUltimoRespaldo = new Label();
lblUltimoRespaldo.Text = "Último respaldo: --/--/---- --:--:--";
lblUltimoRespaldo.Location = new Point(20, 110);
lblUltimoRespaldo.AutoSize = true;

gbInfoSistema.Controls.AddRange(new Control[] {
    lblBaseDatos, lblUltimaActualizacion, lblTamanioBD, lblUltimoRespaldo
});

pnlContenedorStats.Controls.Add(gbInfoSistema);
```

#### Paso 4.5: Botones de Acción

```csharp
Panel pnlBotonesStats = new Panel();
pnlBotonesStats.Location = new Point(20, 880);
pnlBotonesStats.Size = new Size(400, 50);

ReaLTaiizor.Controls.Button btnActualizarEstadisticas = new ReaLTaiizor.Controls.Button();
btnActualizarEstadisticas.Text = "Actualizar Estadísticas";
btnActualizarEstadisticas.Size = new Size(180, 40);
btnActualizarEstadisticas.Location = new Point(0, 0);
btnActualizarEstadisticas.Click += btnActualizarEstadisticas_Click;

ReaLTaiizor.Controls.Button btnGenerarReporte = new ReaLTaiizor.Controls.Button();
btnGenerarReporte.Text = "Generar Reporte Completo";
btnGenerarReporte.Size = new Size(200, 40);
btnGenerarReporte.Location = new Point(195, 0);
btnGenerarReporte.Click += btnGenerarReporte_Click;

pnlBotonesStats.Controls.AddRange(new Control[] {
    btnActualizarEstadisticas, btnGenerarReporte
});

pnlContenedorStats.Controls.Add(pnlBotonesStats);
```

#### Paso 4.6: Implementar método de carga

```csharp
private void CargarEstadisticas()
{
    try
    {
        // CARD EMPLEADOS
        var statsEmpleados = empleadoNegocio.obtenerEstadisticasGenerales();
        lblTotalEmpleados.Text = $"Total Registrados: {statsEmpleados.Total}";
        lblActivosInactivos.Text = $"Activos: {statsEmpleados.Activos} | Inactivos: {statsEmpleados.Inactivos}";
        lblCredencialesUnicas.Text = $"Credenciales únicas: {statsEmpleados.Total}";

        // CARD EMPRESAS
        var statsEmpresas = empresaNegocio.obtenerEstadisticas();
        lblTotalEmpresas.Text = $"Total Activas: {statsEmpresas.TotalActivas}";
        lblPromedioEmpleados.Text = $"Promedio emp/empresa: {statsEmpresas.PromedioEmpleados:F2}";

        // CARD SERVICIOS
        var statsServicios = servicioNegocio.obtenerEstadisticasMes();
        lblServiciosMes.Text = $"Este mes: {statsServicios.ServiciosMes}";
        lblServiciosAnio.Text = $"Total del año: {statsServicios.ServiciosAnio}";
        lblPromedioDia.Text = $"Promedio/día: {statsServicios.PromedioDiario}";

        // ASISTENCIAS
        lblAsistenciasTotales.Text = $"Asistencias Totales (mes actual): {statsServicios.AsistenciasTotales}";
        lblAsistenciasEmpleados.Text = $"Asistencias de Empleados: {statsServicios.AsistenciasEmpleados}";
        lblAsistenciasInvitados.Text = $"Asistencias de Invitados: {statsServicios.AsistenciasInvitados}";
        lblPromedioDiario.Text = $"Promedio diario de asistencias: {statsServicios.PromedioDiario}";
        lblDiaMayor.Text = $"Día con mayor asistencia: {statsServicios.DiaMayor}";
        lblDiaMenor.Text = $"Día con menor asistencia: {statsServicios.DiaMenor}";

        // TOP EMPRESAS
        dgvTopEmpresas.Rows.Clear();
        var topEmpresas = reporteNegocio.obtenerTopEmpresas(5);
        int posicion = 1;
        foreach (var empresa in topEmpresas)
        {
            dgvTopEmpresas.Rows.Add(
                posicion++,
                empresa.NombreEmpresa,
                empresa.TotalAsistencias,
                $"{empresa.Porcentaje:F1}%"
            );
        }

        // INFO SISTEMA
        lblUltimaActualizacion.Text = $"Última actualización: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        lblTamanioBD.Text = $"Tamaño de BD: {ObtenerTamanioBD()} MB";
        lblUltimoRespaldo.Text = $"Último respaldo: {ObtenerUltimoRespaldo()}";
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error al cargar estadísticas: {ex.Message}", 
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

private void btnActualizarEstadisticas_Click(object sender, EventArgs e)
{
    CargarEstadisticas();
    MessageBox.Show("Estadísticas actualizadas correctamente", "Éxito",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
}

private void btnGenerarReporte_Click(object sender, EventArgs e)
{
    // TODO: Implementar generación de reporte en PDF o Excel
    MessageBox.Show("Función de reporte en desarrollo", "Información",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
}
```

---

### FASE 5: Panel CONFIGURACIÓN

#### Paso 5.1: Estructura del Panel

```csharp
// Configurar pnlConfiguracion
pnlConfiguracion.AutoScroll = true;

Panel pnlContenedorConfig = new Panel();
pnlContenedorConfig.AutoSize = true;
pnlContenedorConfig.AutoSizeMode = AutoSizeMode.GrowAndShrink;
pnlContenedorConfig.Padding = new Padding(20);
pnlConfiguracion.Controls.Add(pnlContenedorConfig);
```

#### Paso 5.2: Sección Base de Datos

```csharp
GroupBox gbBaseDatos = new GroupBox();
gbBaseDatos.Text = "BASE DE DATOS";
gbBaseDatos.Size = new Size(pnlConfiguracion.Width - 80, 180);
gbBaseDatos.Location = new Point(20, 20);
gbBaseDatos.Font = new Font("Segoe UI", 11, FontStyle.Bold);

Label lblCadenaConexion = new Label();
lblCadenaConexion.Text = "Cadena de Conexión:";
lblCadenaConexion.Location = new Point(20, 35);
lblCadenaConexion.AutoSize = true;

TextBox txtCadenaConexion = new TextBox();
txtCadenaConexion.Location = new Point(20, 60);
txtCadenaConexion.Size = new Size(gbBaseDatos.Width - 80, 50);
txtCadenaConexion.Multiline = true;
txtCadenaConexion.ReadOnly = true;
txtCadenaConexion.BackColor = Color.WhiteSmoke;

Panel pnlBotonesDB = new Panel();
pnlBotonesDB.Location = new Point(20, 120);
pnlBotonesDB.Size = new Size(400, 40);

ReaLTaiizor.Controls.Button btnProbarConexion = new ReaLTaiizor.Controls.Button();
btnProbarConexion.Text = "Probar Conexión";
btnProbarConexion.Size = new Size(140, 35);
btnProbarConexion.Location = new Point(0, 0);
btnProbarConexion.Click += btnProbarConexion_Click;

ReaLTaiizor.Controls.Button btnGuardarConexion = new ReaLTaiizor.Controls.Button();
btnGuardarConexion.Text = "Guardar Cambios";
btnGuardarConexion.Size = new Size(140, 35);
btnGuardarConexion.Location = new Point(150, 0);
btnGuardarConexion.Click += btnGuardarConexion_Click;

Label lblEstadoConexion = new Label();
lblEstadoConexion.Text = "Estado: No probado";
lblEstadoConexion.Location = new Point(300, 10);
lblEstadoConexion.AutoSize = true;

pnlBotonesDB.Controls.AddRange(new Control[] {
    btnProbarConexion, btnGuardarConexion, lblEstadoConexion
});

gbBaseDatos.Controls.AddRange(new Control[] {
    lblCadenaConexion, txtCadenaConexion, pnlBotonesDB
});

pnlContenedorConfig.Controls.Add(gbBaseDatos);
```

#### Paso 5.3: Sección Respaldos

```csharp
GroupBox gbRespaldos = new GroupBox();
gbRespaldos.Text = "RESPALDOS Y RESTAURACIÓN";
gbRespaldos.Size = new Size(pnlConfiguracion.Width - 80, 250);
gbRespaldos.Location = new Point(20, 220);
gbRespaldos.Font = new Font("Segoe UI", 11, FontStyle.Bold);

Label lblRutaRespaldos = new Label();
lblRutaRespaldos.Text = "Ruta de respaldos:";
lblRutaRespaldos.Location = new Point(20, 35);
lblRutaRespaldos.AutoSize = true;

TextBox txtRutaRespaldos = new TextBox();
txtRutaRespaldos.Location = new Point(20, 60);
txtRutaRespaldos.Width = 400;

ReaLTaiizor.Controls.Button btnExaminarRuta = new ReaLTaiizor.Controls.Button();
btnExaminarRuta.Text = "Examinar";
btnExaminarRuta.Size = new Size(100, 25);
btnExaminarRuta.Location = new Point(430, 58);
btnExaminarRuta.Click += btnExaminarRuta_Click;

Label lblFrecuencia = new Label();
lblFrecuencia.Text = "Frecuencia de respaldo automático:";
lblFrecuencia.Location = new Point(20, 100);
lblFrecuencia.AutoSize = true;

RadioButton rbRespaldoDiario = new RadioButton();
rbRespaldoDiario.Text = "Diario (23:00)";
rbRespaldoDiario.Location = new Point(20, 125);
rbRespaldoDiario.Checked = true;

RadioButton rbRespaldomManual = new RadioButton();
rbRespaldomManual.Text = "Manual";
rbRespaldomManual.Location = new Point(150, 125);

Label lblUltimoRespaldo = new Label();
lblUltimoRespaldo.Text = "Último respaldo: --/--/---- --:--:--";
lblUltimoRespaldo.Location = new Point(20, 160);
lblUltimoRespaldo.AutoSize = true;

Panel pnlBotonesRespaldo = new Panel();
pnlBotonesRespaldo.Location = new Point(20, 190);
pnlBotonesRespaldo.Size = new Size(400, 40);

ReaLTaiizor.Controls.Button btnCrearRespaldo = new ReaLTaiizor.Controls.Button();
btnCrearRespaldo.Text = "Crear Respaldo Ahora";
btnCrearRespaldo.Size = new Size(180, 35);
btnCrearRespaldo.Location = new Point(0, 0);
btnCrearRespaldo.Click += btnCrearRespaldo_Click;

ReaLTaiizor.Controls.Button btnRestaurarRespaldo = new ReaLTaiizor.Controls.Button();
btnRestaurarRespaldo.Text = "Restaurar desde Respaldo";
btnRestaurarRespaldo.Size = new Size(200, 35);
btnRestaurarRespaldo.Location = new Point(190, 0);
btnRestaurarRespaldo.Click += btnRestaurarRespaldo_Click;

pnlBotonesRespaldo.Controls.AddRange(new Control[] {
    btnCrearRespaldo, btnRestaurarRespaldo
});

gbRespaldos.Controls.AddRange(new Control[] {
    lblRutaRespaldos, txtRutaRespaldos, btnExaminarRuta,
    lblFrecuencia, rbRespaldoDiario, rbRespaldomManual,
    lblUltimoRespaldo, pnlBotonesRespaldo
});

pnlContenedorConfig.Controls.Add(gbRespaldos);
```

#### Paso 5.4: Sección RFID (Futuro)

```csharp
GroupBox gbRFID = new GroupBox();
gbRFID.Text = "LECTOR RFID (FUTURO)";
gbRFID.Size = new Size(pnlConfiguracion.Width - 80, 200);
gbRFID.Location = new Point(20, 490);
gbRFID.Font = new Font("Segoe UI", 11, FontStyle.Bold);
gbRFID.Enabled = false; // Deshabilitado por ahora

Label lblPuertoCOM = new Label();
lblPuertoCOM.Text = "Puerto COM:";
lblPuertoCOM.Location = new Point(20, 35);
lblPuertoCOM.AutoSize = true;

ComboBox cbPuertoCOM = new ComboBox();
cbPuertoCOM.Location = new Point(20, 60);
cbPuertoCOM.Width = 150;
cbPuertoCOM.Items.AddRange(new[] { "COM1", "COM2", "COM3", "COM4" });

Label lblBaudRate = new Label();
lblBaudRate.Text = "Velocidad (Baud Rate):";
lblBaudRate.Location = new Point(20, 100);
lblBaudRate.AutoSize = true;

ComboBox cbBaudRate = new ComboBox();
cbBaudRate.Location = new Point(20, 125);
cbBaudRate.Width = 150;
cbBaudRate.Items.AddRange(new[] { "9600", "19200", "38400", "57600", "115200" });
cbBaudRate.SelectedIndex = 0;

Label lblEstadoRFID = new Label();
lblEstadoRFID.Text = "Estado: No configurado";
lblEstadoRFID.Location = new Point(20, 160);
lblEstadoRFID.AutoSize = true;

gbRFID.Controls.AddRange(new Control[] {
    lblPuertoCOM, cbPuertoCOM, lblBaudRate, cbBaudRate, lblEstadoRFID
});

pnlContenedorConfig.Controls.Add(gbRFID);
```

#### Paso 5.5: Preferencias e Información

```csharp
GroupBox gbPreferencias = new GroupBox();
gbPreferencias.Text = "PREFERENCIAS DE INTERFAZ";
gbPreferencias.Size = new Size(pnlConfiguracion.Width - 80, 150);
gbPreferencias.Location = new Point(20, 710);
gbPreferencias.Font = new Font("Segoe UI", 11, FontStyle.Bold);

Label lblFormatoFecha = new Label();
lblFormatoFecha.Text = "Formato de fecha:";
lblFormatoFecha.Location = new Point(20, 35);
lblFormatoFecha.AutoSize = true;

RadioButton rbFormatoFecha1 = new RadioButton();
rbFormatoFecha1.Text = "dd/MM/yyyy";
rbFormatoFecha1.Location = new Point(20, 60);
rbFormatoFecha1.Checked = true;

CheckBox chkSonidoConfirmacion = new CheckBox();
chkSonidoConfirmacion.Text = "Sonido de confirmación al registrar";
chkSonidoConfirmacion.Location = new Point(20, 90);
chkSonidoConfirmacion.AutoSize = true;

CheckBox chkActualizacionAuto = new CheckBox();
chkActualizacionAuto.Text = "Actualización automática de estadísticas";
chkActualizacionAuto.Location = new Point(20, 115);
chkActualizacionAuto.AutoSize = true;
chkActualizacionAuto.Checked = true;

gbPreferencias.Controls.AddRange(new Control[] {
    lblFormatoFecha, rbFormatoFecha1, chkSonidoConfirmacion, chkActualizacionAuto
});

pnlContenedorConfig.Controls.Add(gbPreferencias);

// INFO DE LA APLICACIÓN
GroupBox gbInfoApp = new GroupBox();
gbInfoApp.Text = "INFORMACIÓN DE LA APLICACIÓN";
gbInfoApp.Size = new Size(pnlConfiguracion.Width - 80, 150);
gbInfoApp.Location = new Point(20, 880);
gbInfoApp.Font = new Font("Segoe UI", 11, FontStyle.Bold);

Label lblVersion = new Label();
lblVersion.Text = "Versión: 2.0.0";
lblVersion.Location = new Point(20, 35);
lblVersion.AutoSize = true;

Label lblFramework = new Label();
lblFramework.Text = "Framework: .NET Framework 4.8.1";
lblFramework.Location = new Point(20, 60);
lblFramework.AutoSize = true;

Label lblUILibrary = new Label();
lblUILibrary.Text = "UI Library: ReaLTaiizor";
lblUILibrary.Location = new Point(20, 85);
lblUILibrary.AutoSize = true;

gbInfoApp.Controls.AddRange(new Control[] {
    lblVersion, lblFramework, lblUILibrary
});

pnlContenedorConfig.Controls.Add(gbInfoApp);
```

---

### FASE 6: Métodos en Capa de Negocio

Necesitas agregar estos métodos en tus clases de negocio:

#### EmpleadoNegocio.cs

```csharp
public void agregar(Empleado empleado)
{
    AccesoDatos datos = new AccesoDatos();
    try
    {
        datos.setearConsulta(@"
            INSERT INTO Empleados (IdCredencial, Nombre, Apellido, IdEmpresa, Estado) 
            VALUES (@credencial, @nombre, @apellido, @empresa, @estado)");
        
        datos.setearParametro("@credencial", empleado.IdCredencial);
        datos.setearParametro("@nombre", empleado.Nombre);
        datos.setearParametro("@apellido", empleado.Apellido);
        datos.setearParametro("@empresa", empleado.Empresa.IdEmpresa);
        datos.setearParametro("@estado", empleado.Estado);
        
        datos.ejecutarAccion();
    }
    finally
    {
        datos.cerrarConexion();
    }
}

public void modificar(Empleado empleado)
{
    AccesoDatos datos = new AccesoDatos();
    try
    {
        datos.setearConsulta(@"
            UPDATE Empleados 
            SET IdCredencial = @credencial, 
                Nombre = @nombre, 
                Apellido = @apellido, 
                IdEmpresa = @empresa, 
                Estado = @estado 
            WHERE IdEmpleado = @id");
        
        datos.setearParametro("@id", empleado.IdEmpleado);
        datos.setearParametro("@credencial", empleado.IdCredencial);
        datos.setearParametro("@nombre", empleado.Nombre);
        datos.setearParametro("@apellido", empleado.Apellido);
        datos.setearParametro("@empresa", empleado.Empresa.IdEmpresa);
        datos.setearParametro("@estado", empleado.Estado);
        
        datos.ejecutarAccion();
    }
    finally
    {
        datos.cerrarConexion();
    }
}

public bool existeCredencial(string credencial)
{
    AccesoDatos datos = new AccesoDatos();
    try
    {
        datos.setearConsulta("SELECT COUNT(*) FROM Empleados WHERE IdCredencial = @credencial");
        datos.setearParametro("@credencial", credencial);
        datos.ejecutarLectura();
        
        if (datos.Lector.Read())
        {
            return (int)datos.Lector[0] > 0;
        }
        return false;
    }
    finally
    {
        datos.cerrarConexion();
    }
}

public Empleado buscarPorId(int id)
{
    AccesoDatos datos = new AccesoDatos();
    Empleado empleado = new Empleado();
    
    try
    {
        datos.setearConsulta(@"
            SELECT e.IdEmpleado, e.IdCredencial, e.Nombre, e.Apellido, 
                   e.Estado, emp.IdEmpresa, emp.Nombre as NombreEmpresa
            FROM Empleados e
            INNER JOIN Empresas emp ON e.IdEmpresa = emp.IdEmpresa
            WHERE e.IdEmpleado = @id");
        
        datos.setearParametro("@id", id);
        datos.ejecutarLectura();
        
        if (datos.Lector.Read())
        {
            empleado.IdEmpleado = (int)datos.Lector["IdEmpleado"];
            empleado.IdCredencial = datos.Lector["IdCredencial"].ToString();
            empleado.Nombre = datos.Lector["Nombre"].ToString();
            empleado.Apellido = datos.Lector["Apellido"].ToString();
            empleado.Estado = (bool)datos.Lector["Estado"];
            
            empleado.Empresa = new Empresa();
            empleado.Empresa.IdEmpresa = (int)datos.Lector["IdEmpresa"];
            empleado.Empresa.Nombre = datos.Lector["NombreEmpresa"].ToString();
        }
        
        return empleado;
    }
    finally
    {
        datos.cerrarConexion();
    }
}

public EstadisticasEmpleados obtenerEstadisticasGenerales()
{
    AccesoDatos datos = new AccesoDatos();
    EstadisticasEmpleados stats = new EstadisticasEmpleados();
    
    try
    {
        datos.setearConsulta(@"
            SELECT 
                COUNT(*) as Total,
                SUM(CASE WHEN Estado = 1 THEN 1 ELSE 0 END) as Activos,
                SUM(CASE WHEN Estado = 0 THEN 1 ELSE 0 END) as Inactivos
            FROM Empleados");
        
        datos.ejecutarLectura();
        
        if (datos.Lector.Read())
        {
            stats.Total = (int)datos.Lector["Total"];
            stats.Activos = (int)datos.Lector["Activos"];
            stats.Inactivos = (int)datos.Lector["Inactivos"];
        }
        
        return stats;
    }
    finally
    {
        datos.cerrarConexion();
    }
}
```

#### EmpresaNegocio.cs

```csharp
public void agregar(Empresa empresa)
{
    AccesoDatos datos = new AccesoDatos();
    try
    {
        datos.setearConsulta("INSERT INTO Empresas (Nombre, Estado) VALUES (@nombre, @estado)");
        datos.setearParametro("@nombre", empresa.Nombre);
        datos.setearParametro("@estado", empresa.Estado);
        datos.ejecutarAccion();
    }
    finally
    {
        datos.cerrarConexion();
    }
}

public void modificar(Empresa empresa)
{
    AccesoDatos datos = new AccesoDatos();
    try
    {
        datos.setearConsulta("UPDATE Empresas SET Nombre = @nombre, Estado = @estado WHERE IdEmpresa = @id");
        datos.setearParametro("@id", empresa.IdEmpresa);
        datos.setearParametro("@nombre", empresa.Nombre);
        datos.setearParametro("@estado", empresa.Estado);
        datos.ejecutarAccion();
    }
    finally
    {
        datos.cerrarConexion();
    }
}

public Empresa buscarPorId(int id)
{
    AccesoDatos datos = new AccesoDatos();
    Empresa empresa = new Empresa();
    
    try
    {
        datos.setearConsulta("SELECT IdEmpresa, Nombre, Estado FROM Empresas WHERE IdEmpresa = @id");
        datos.setearParametro("@id", id);
        datos.ejecutarLectura();
        
        if (datos.Lector.Read())
        {
            empresa.IdEmpresa = (int)datos.Lector["IdEmpresa"];
            empresa.Nombre = datos.Lector["Nombre"].ToString();
            empresa.Estado = (bool)datos.Lector["Estado"];
        }
        
        return empresa;
    }
    finally
    {
        datos.cerrarConexion();
    }
}

public EstadisticasEmpresas obtenerEstadisticas()
{
    AccesoDatos datos = new AccesoDatos();
    EstadisticasEmpresas stats = new EstadisticasEmpresas();
    
    try
    {
        datos.setearConsulta(@"
            SELECT 
                COUNT(DISTINCT e.IdEmpresa) as TotalEmpresas,
                COUNT(emp.IdEmpleado) as TotalEmpleados,
                AVG(CAST(EmpleadosPorEmpresa as FLOAT)) as PromedioEmpleados
            FROM Empresas e
            LEFT JOIN Empleados emp ON e.IdEmpresa = emp.IdEmpresa
            CROSS APPLY (
                SELECT COUNT(*) as EmpleadosPorEmpresa 
                FROM Empleados 
                WHERE IdEmpresa = e.IdEmpresa
            ) x
            WHERE e.Estado = 1");
        
        datos.ejecutarLectura();
        
        if (datos.Lector.Read())
        {
            stats.TotalActivas = (int)datos.Lector["TotalEmpresas"];
            stats.PromedioEmpleados = datos.Lector["PromedioEmpleados"] != DBNull.Value 
                ? Convert.ToDouble(datos.Lector["PromedioEmpleados"]) 
                : 0;
        }
        
        return stats;
    }
    finally
    {
        datos.cerrarConexion();
    }
}
```

---

### FASE 7: Integración con frmPrincipal

#### Paso 7.1: Agregar ucAdmin al formulario principal

En `frmPrincipal.cs`:

```csharp
public partial class frmPrincipal : Form
{
    private ucAdmin vistaAdmin;
    private Servicio servicioActivo = null;
    
    public frmPrincipal()
    {
        InitializeComponent();
        InicializarVistas();
    }
    
    private void InicializarVistas()
    {
        // Crear instancia de ucAdmin
        vistaAdmin = new ucAdmin();
        vistaAdmin.Dock = DockStyle.Fill;
        vistaAdmin.Visible = false;
        
        // Agregar al panel de contenido
        panelContenido.Controls.Add(vistaAdmin);
    }
    
    // Método para mostrar la vista de administración
    private void MostrarAdmin()
    {
        // Validar que no haya servicio activo
        if (servicioActivo != null)
        {
            MessageBox.Show("No se puede acceder al panel de administración mientras hay un servicio activo.",
                "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        OcultarTodasLasVistas();
        vistaAdmin.Visible = true;
        vistaAdmin.BringToFront();
        
        // Opcional: Refrescar datos
        // vistaAdmin.RefrescarDatos();
    }
    
    private void OcultarTodasLasVistas()
    {
        foreach (Control control in panelContenido.Controls)
        {
            if (control is UserControl)
            {
                control.Visible = false;
            }
        }
    }
    
    // Evento del botón de administración
    private void btnAdmin_Click(object sender, EventArgs e)
    {
        MostrarAdmin();
    }
    
    // Controlar habilitación del botón según estado del servicio
    private void ActualizarEstadoBotones()
    {
        if (servicioActivo != null)
        {
            btnAdmin.Enabled = false;
            btnAdmin.BackColor = Color.Gray;
        }
        else
        {
            btnAdmin.Enabled = true;
            btnAdmin.BackColor = Color.FromArgb(255, 208, 36);
        }
    }
}
```

---

### FASE 8: Clases de Apoyo (DTOs para Estadísticas)

Crear estas clases en la capa `dominio`:

```csharp
// EstadisticasEmpleados.cs
public class EstadisticasEmpleados
{
    public int Total { get; set; }
    public int Activos { get; set; }
    public int Inactivos { get; set; }
}

// EstadisticasEmpresas.cs
public class EstadisticasEmpresas
{
    public int TotalActivas { get; set; }
    public double PromedioEmpleados { get; set; }
}

// EstadisticasServicios.cs
public class EstadisticasServicios
{
    public int ServiciosMes { get; set; }
    public int ServiciosAnio { get; set; }
    public int PromedioDiario { get; set; }
    public int AsistenciasTotales { get; set; }
    public int AsistenciasEmpleados { get; set; }
    public int AsistenciasInvitados { get; set; }
    public string DiaMayor { get; set; }
    public string DiaMenor { get; set; }
}

// TopEmpresa.cs
public class TopEmpresa
{
    public string NombreEmpresa { get; set; }
    public int TotalAsistencias { get; set; }
    public double Porcentaje { get; set; }
}
```

---

### FASE 9: Testing y Validación

#### Checklist de Pruebas

**Panel Empleados:**
- [ ] Cargar lista de empleados
- [ ] Buscar empleado por nombre/credencial
- [ ] Filtrar por empresa
- [ ] Filtrar por estado (activo/inactivo)
- [ ] Crear nuevo empleado
- [ ] Verificar credencial única
- [ ] Modificar empleado existente
- [ ] Desactivar empleado
- [ ] Validar campos obligatorios
- [ ] Seleccionar empleado en grid carga formulario

**Panel Empresas:**
- [ ] Cargar lista de empresas
- [ ] Crear nueva empresa
- [ ] Modificar empresa existente
- [ ] Desactivar empresa
- [ ] Ver estadísticas de empresa seleccionada
- [ ] Validar nombre único

**Panel Estadísticas:**
- [ ] Cargar todas las métricas correctamente
- [ ] Actualizar estadísticas con botón
- [ ] Top 5 empresas muestra datos correctos
- [ ] Información del sistema se muestra

**Panel Configuración:**
- [ ] Cargar cadena de conexión
- [ ] Probar conexión a BD
- [ ] Crear respaldo manual
- [ ] Guardar preferencias
- [ ] Mostrar información de la aplicación

**Integración:**
- [ ] Navegación entre paneles funciona correctamente
- [ ] Botón activo se resalta
- [ ] Solo un panel visible a la vez
- [ ] Acceso bloqueado durante servicio activo
- [ ] ucAdmin se integra correctamente en frmPrincipal

---

### FASE 10: Mejoras y Pulido Final

#### Paso 10.1: Agregar método de refresco público

```csharp
// En ucAdmin.cs
public void RefrescarDatos()
{
    // Determinar qué panel está visible y refrescar sus datos
    if (pnlEmpleados.Visible)
    {
        CargarEmpleados();
        CargarEmpresas();
    }
    else if (pnlEmpresas.Visible)
    {
        CargarEmpresas();
    }
    else if (pnlEstadisticas.Visible)
    {
        CargarEstadisticas();
    }
    else if (pnlConfiguracion.Visible)
    {
        CargarConfiguracion();
    }
}
```

#### Paso 10.2: Agregar tooltips

```csharp
private void ConfigurarTooltips()
{
    ToolTip tooltip = new ToolTip();
    tooltip.SetToolTip(btnNuevoEmpleado, "Limpiar formulario para crear un nuevo empleado");
    tooltip.SetToolTip(btnVerificarCredencial, "Verificar si la credencial ya está en uso");
    tooltip.SetToolTip(btnGuardarEmpleado, "Guardar cambios del empleado");
    tooltip.SetToolTip(btnEliminarEmpleado, "Desactivar empleado seleccionado");
    tooltip.SetToolTip(btnActualizarEstadisticas, "Refrescar todas las estadísticas");
    tooltip.SetToolTip(btnProbarConexion, "Probar conexión a la base de datos");
}
```

#### Paso 10.3: Agregar atajos de teclado

```csharp
protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
    // Ctrl + N = Nuevo empleado
    if (keyData == (Keys.Control | Keys.N) && pnlEmpleados.Visible)
    {
        btnNuevoEmpleado_Click(null, null);
        return true;
    }
    
    // Ctrl + S = Guardar
    if (keyData == (Keys.Control | Keys.S) && pnlEmpleados.Visible)
    {
        btnGuardarEmpleado_Click(null, null);
        return true;
    }
    
    // F5 = Actualizar estadísticas
    if (keyData == Keys.F5 && pnlEstadisticas.Visible)
    {
        btnActualizarEstadisticas_Click(null, null);
        return true;
    }
    
    return base.ProcessCmdKey(ref msg, keyData);
}
```

---

## ✅ CHECKLIST FINAL DE IMPLEMENTACIÓN

### Estructura Base
- [x] ucAdmin creado con sistema de botones
- [x] 4 paneles implementados
- [x] Sistema de navegación funcionando
- [x] Colores y estilos aplicados

### Panel Empleados
- [ ] SplitContainer agregado
- [ ] Lista de empleados con DataGridView
- [ ] Formulario de edición completo
- [ ] Búsqueda y filtros
- [ ] CRUD implementado
- [ ] Validaciones funcionando

### Panel Empresas
- [ ] SplitContainer agregado
- [ ] Lista de empresas
- [ ] Formulario de edición
- [ ] Estadísticas por empresa
- [ ] CRUD implementado

### Panel Estadísticas
- [ ] Cards de métricas
- [ ] Asistencias y tendencias
- [ ] Top 5 empresas
- [ ] Información del sistema
- [ ] Botón actualizar

### Panel Configuración
- [ ] Configuración de BD
- [ ] Sistema de respaldos
- [ ] Sección RFID (deshabilitada)
- [ ] Preferencias
- [ ] Información de la app

### Capa de Negocio
- [ ] EmpleadoNegocio con todos los métodos
- [ ] EmpresaNegocio con todos los métodos
- [ ] Clases DTO creadas
- [ ] Métodos de estadísticas

### Integración
- [ ] ucAdmin agregado a frmPrincipal
- [ ] Navegación desde menú principal
- [ ] Control de acceso por servicio
- [ ] Método RefrescarDatos()

### Testing
- [ ] Todas las funciones probadas
- [ ] Validaciones verificadas
- [ ] Manejo de errores correcto

---

## 🎯 Tiempo Estimado Total

| Fase | Tiempo |
|------|--------|
| Panel Empleados | 4-5 horas |
| Panel Empresas | 3-4 horas |
| Panel Estadísticas | 2-3 horas |
| Panel Configuración | 2-3 horas |
| Métodos de Negocio | 2-3 horas |
| Integración y Testing | 2-3 horas |
| **TOTAL** | **15-21 horas** |

---

## 📌 VENTAJAS DEL SISTEMA DE BOTONES vs TabControl

✅ **Mayor control de diseño**
✅ **Colores personalizables al 100%**
✅ **Animaciones y transiciones futuras**
✅ **Responsive y adaptable**
✅ **Más profesional y moderno**
✅ **Fácil de mantener y extender**

---

## 🚀 Próximos Pasos Recomendados

1. Implementar animaciones de transición entre paneles
2. Agregar exportación a Excel/PDF
3. Sistema de logs de auditoría
4. Configuración de permisos por rol
5. Integración con lector RFID real