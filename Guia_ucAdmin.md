
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

*** Resumen de las 4 Pestañas ***
Pestaña 1: Empleados ✅
Lista de empleados (izquierda)
Formulario de edición (derecha)
Búsqueda y filtros
CRUD completo
Pestaña 2: Empresas ✅
Lista de empresas (izquierda)
Detalles + estadísticas de empresa (derecha)
Formulario de edición
Contador de empleados por empresa
Pestaña 3: Estadísticas ✅
Vista completa sin división
Cards con métricas principales
Gráfico de barras (top empresas)
Información del sistema
Solo lectura
Pestaña 4: Configuración ✅
Vista completa sin división
Secciones colapsables/agrupadas:
Base de datos
Respaldos
Lector RFID (futuro)
Preferencias
Info de la aplicación

*** Ventajas de este Diseño ***

✅ Consistencia visual - Todas las pestañas siguen el mismo patrón
✅ Split View para CRUD - Empleados y Empresas usan panel dividido
✅ Vista completa para info - Estadísticas y Config no necesitan división
✅ Fácil navegación - TabControl arriba siempre visible
✅ Escalable - Fácil agregar más pestañas si es necesario

---

## 📝 PASO A PASO PARA EL DESARROLLO

### **FASE 1: Preparación y Estructura Base**

#### **Paso 1.1: Crear el UserControl ucAdmin**

1. En Visual Studio, click derecho en carpeta `UserControls`
2. **Agregar > UserControl**
3. Nombre: `ucAdmin.cs`
4. Se crearán automáticamente:
   - `ucAdmin.cs` (código)
   - `ucAdmin.Designer.cs` (diseño)
   - `ucAdmin.resx` (recursos)

#### **Paso 1.2: Configurar propiedades del UserControl**

```csharp
// En ucAdmin.Designer.cs (vista Diseño)
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.BackColor = System.Drawing.Color.White;
this.Size = new System.Drawing.Size(1050, 650);
```

#### **Paso 1.3: Agregar el TabControl principal**

1. Abrir **ucAdmin.cs** en modo Diseño
2. Desde Toolbox, arrastrar un **TabControl**
3. Configurar propiedades:
   ```
   Name: tcAdmin
   Dock: Fill
   Font: Segoe UI, 10pt
   ```
4. Agregar 4 TabPages:
   - `tpEmpleados` - Text: "Empleados"
   - `tpEmpresas` - Text: "Empresas"
   - `tpEstadisticas` - Text: "Estadísticas"
   - `tpConfiguracion` - Text: "Configuración"

---

### **FASE 2: Pestaña EMPLEADOS**

#### **Paso 2.1: Diseñar el layout de división (Split Container)**

1. En `tpEmpleados`, agregar un **SplitContainer**:
   ```
   Name: splitEmpleados
   Dock: Fill
   Orientation: Vertical
   SplitterDistance: 350
   FixedPanel: Panel1
   IsSplitterFixed: true
   ```

#### **Paso 2.2: Panel Izquierdo - Lista de Empleados**

**Agregar controles:**

1. **Panel superior con búsqueda:**
   - TextBox `txtBuscarEmpleado` (Placeholder: "Buscar por nombre o credencial...")
   - ComboBox `cbFiltroEmpresa` (con opción "Todas las empresas")
   - ComboBox `cbFiltroEstado` (Todos/Activos/Inactivos)

2. **DataGridView:**
   ```
   Name: dgvEmpleados
   Dock: Fill
   SelectionMode: FullRowSelect
   MultiSelect: false
   ReadOnly: true
   AllowUserToAddRows: false
   AutoSizeColumnsMode: Fill
   ```
   
   **Columnas:**
   - `IdEmpleado` (Hidden)
   - `Credencial` (Width: 100px)
   - `NombreCompleto` (Width: 200px)
   - `Empresa` (Width: 150px)
   - `Estado` (Width: 80px)

3. **Panel inferior:**
   - Label `lblTotalEmpleados` ("Total: 0 empleados")
   - Button `btnNuevoEmpleado` ("+ Nuevo Empleado")

#### **Paso 2.3: Panel Derecho - Formulario de Edición**

**Agregar controles:**

1. **GroupBox:** `gbEmpleadoDetalle` - Text: "Detalles del Empleado"

2. **Dentro del GroupBox:**
   ```
   Label: "Número de Credencial:"
   TextBox: txtCredencial (MaxLength: 20)
   Button: btnVerificarCredencial ("Verificar disponibilidad")
   
   Label: "Nombre:"
   TextBox: txtNombre (MaxLength: 50)
   
   Label: "Apellido:"
   TextBox: txtApellido (MaxLength: 50)
   
   Label: "Empresa Asignada:"
   ComboBox: cbEmpresaEmpleado (DropDownStyle: DropDownList)
   
   Label: "Estado:"
   RadioButton: rbActivoEmpleado ("Activo")
   RadioButton: rbInactivoEmpleado ("Inactivo")
   
   Panel de botones:
   Button: btnGuardarEmpleado ("Guardar")
   Button: btnCancelarEmpleado ("Cancelar")
   Button: btnEliminarEmpleado ("Eliminar")
   ```

#### **Paso 2.4: Implementar código de Empleados**

**En ucAdmin.cs:**

```csharp
using dominio;
using negocio;
using System;
using System.Windows.Forms;

public partial class ucAdmin : UserControl
{
    private EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
    private EmpresaNegocio empresaNegocio = new EmpresaNegocio();
    private Empleado empleadoSeleccionado = null;
    private bool modoEdicion = false;

    public ucAdmin()
    {
        InitializeComponent();
    }

    private void ucAdmin_Load(object sender, EventArgs e)
    {
        CargarEmpleados();
        CargarEmpresas();
        LimpiarFormularioEmpleado();
    }

    // MÉTODOS DE CARGA
    private void CargarEmpleados(string filtro = "")
    {
        try
        {
            dgvEmpleados.DataSource = empleadoNegocio.listar();
            lblTotalEmpleados.Text = $"Total: {dgvEmpleados.RowCount} empleados";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar empleados: {ex.Message}");
        }
    }

    private void CargarEmpresas()
    {
        try
        {
            var empresas = empresaNegocio.listar();
            
            cbFiltroEmpresa.DataSource = empresas;
            cbFiltroEmpresa.DisplayMember = "Nombre";
            cbFiltroEmpresa.ValueMember = "IdEmpresa";
            
            cbEmpresaEmpleado.DataSource = empresas;
            cbEmpresaEmpleado.DisplayMember = "Nombre";
            cbEmpresaEmpleado.ValueMember = "IdEmpresa";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar empresas: {ex.Message}");
        }
    }

    // EVENTOS DE EMPLEADOS
    private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvEmpleados.CurrentRow != null)
        {
            int idEmpleado = (int)dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value;
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
            MessageBox.Show($"Error al cargar empleado: {ex.Message}");
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
            
            if (modoEdicion)
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
                MessageBox.Show("Empleado desactivado", "Éxito");
                CargarEmpleados();
                LimpiarFormularioEmpleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
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
            MessageBox.Show("Ingrese un número de credencial");
            return;
        }

        try
        {
            bool existe = empleadoNegocio.existeCredencial(txtCredencial.Text.Trim());
            
            if (existe && !modoEdicion)
            {
                MessageBox.Show("Esta credencial ya está en uso", "No disponible", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Credencial disponible", "Disponible", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private void txtBuscarEmpleado_TextChanged(object sender, EventArgs e)
    {
        // Implementar filtro en tiempo real
        CargarEmpleados(txtBuscarEmpleado.Text);
    }

    // MÉTODOS AUXILIARES
    private bool ValidarFormularioEmpleado()
    {
        if (string.IsNullOrWhiteSpace(txtCredencial.Text))
        {
            MessageBox.Show("Ingrese el número de credencial");
            txtCredencial.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("Ingrese el nombre");
            txtNombre.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtApellido.Text))
        {
            MessageBox.Show("Ingrese el apellido");
            txtApellido.Focus();
            return false;
        }

        if (cbEmpresaEmpleado.SelectedIndex == -1)
        {
            MessageBox.Show("Seleccione una empresa");
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

### **FASE 3: Pestaña EMPRESAS**

#### **Paso 3.1: Diseñar layout similar a Empleados**

Repetir estructura con **SplitContainer**:
- Panel izquierdo: Lista de empresas
- Panel derecho: Formulario + Estadísticas

#### **Paso 3.2: Panel Izquierdo - Lista de Empresas**

**Controles:**
```
TextBox: txtBuscarEmpresa
ComboBox: cbFiltroEstadoEmpresa (Todas/Activas/Inactivas)
DataGridView: dgvEmpresas
  Columnas: IdEmpresa, Nombre, CantidadEmpleados, Estado
Label: lblTotalEmpresas
Button: btnNuevaEmpresa
```

#### **Paso 3.3: Panel Derecho - Formulario + Stats**

**Controles:**
```
GroupBox: gbEmpresaDetalle
  TextBox: txtNombreEmpresa
  RadioButton: rbActivaEmpresa / rbInactivaEmpresa
  Button: btnGuardarEmpresa, btnCancelarEmpresa, btnEliminarEmpresa

GroupBox: gbEstadisticasEmpresa
  Label: lblTotalEmpleadosEmpresa
  Label: lblEmpleadosActivos
  Label: lblEmpleadosInactivos
  Label: lblAsistenciasMes
  Label: lblPromedioAsistencias
```

#### **Paso 3.4: Implementar código de Empresas**

```csharp
// Variables de clase
private Empresa empresaSeleccionada = null;
private bool modoEdicionEmpresa = false;

// Métodos principales
private void CargarEmpresas()
{
    dgvEmpresas.DataSource = empresaNegocio.listar();
    lblTotalEmpresas.Text = $"Total: {dgvEmpresas.RowCount} empresas";
}

private void dgvEmpresas_SelectionChanged(object sender, EventArgs e)
{
    if (dgvEmpresas.CurrentRow != null)
    {
        int idEmpresa = (int)dgvEmpresas.CurrentRow.Cells["IdEmpresa"].Value;
        CargarEmpresaEnFormulario(idEmpresa);
    }
}

private void CargarEmpresaEnFormulario(int idEmpresa)
{
    empresaSeleccionada = empresaNegocio.buscarPorId(idEmpresa);
    txtNombreEmpresa.Text = empresaSeleccionada.Nombre;
    rbActivaEmpresa.Checked = empresaSeleccionada.Estado;
    
    // Cargar estadísticas
    CargarEstadisticasEmpresa(idEmpresa);
    modoEdicionEmpresa = true;
}

private void CargarEstadisticasEmpresa(int idEmpresa)
{
    // Implementar consultas de estadísticas por empresa
    var stats = empleadoNegocio.obtenerEstadisticasPorEmpresa(idEmpresa);
    lblTotalEmpleadosEmpresa.Text = $"Total: {stats.Total}";
    lblEmpleadosActivos.Text = $"Activos: {stats.Activos}";
    // ... resto de estadísticas
}

private void btnGuardarEmpresa_Click(object sender, EventArgs e)
{
    // Similar a guardar empleado
}

// ... resto de métodos similares a Empleados
```

---

### **FASE 4: Pestaña ESTADÍSTICAS**

#### **Paso 4.1: Diseñar vista de métricas**

**Layout sin división, todo en un Panel:**

```
Panel: pnlEstadisticas (Dock: Fill)
  AutoScroll: true

GroupBox: gbEstadisticasGenerales - "Estadísticas Generales"
  Panel: pnlCardsEmpleados
    Label: "EMPLEADOS"
    Label: lblTotalRegistrados ("Total: 0")
    Label: lblActivosInactivos ("Activos: 0 | Inactivos: 0")
  
  Panel: pnlCardsEmpresas
    Label: "EMPRESAS"
    Label: lblTotalEmpresas ("Total: 0")
    Label: lblPromedioEmpleados ("Promedio: 0")
  
  Panel: pnlCardsServicios
    Label: "SERVICIOS"
    Label: lblServiciosMes ("Este mes: 0")
    Label: lblServiciosAnio ("Total año: 0")

GroupBox: gbAsistencias - "Asistencias y Tendencias"
  Label: lblAsistenciasTotales
  Label: lblPromedioDiario
  Label: lblDiaMayorAsistencia
  Label: lblCobertura
  
GroupBox: gbTopEmpresas - "Top 5 Empresas"
  DataGridView: dgvTopEmpresas (Small, ReadOnly)
  
Button: btnActualizarEstadisticas
Button: btnGenerarReporte
```

#### **Paso 4.2: Implementar código de Estadísticas**

```csharp
private void CargarEstadisticas()
{
    try
    {
        // Estadísticas de empleados
        var statsEmpleados = empleadoNegocio.obtenerEstadisticasGenerales();
        lblTotalRegistrados.Text = $"Total: {statsEmpleados.Total}";
        lblActivosInactivos.Text = $"Activos: {statsEmpleados.Activos} | Inactivos: {statsEmpleados.Inactivos}";

        // Estadísticas de empresas
        var statsEmpresas = empresaNegocio.obtenerEstadisticas();
        lblTotalEmpresas.Text = $"Total: {statsEmpresas.Total}";
        lblPromedioEmpleados.Text = $"Promedio: {statsEmpresas.PromedioEmpleados:F2}";

        // Estadísticas de servicios
        var statsServicios = servicioNegocio.obtenerEstadisticas();
        lblServiciosMes.Text = $"Este mes: {statsServicios.ServiciosMes}";
        lblServiciosAnio.Text = $"Total año: {statsServicios.ServiciosAnio}";

        // Top empresas
        dgvTopEmpresas.DataSource = reporteNegocio.obtenerTopEmpresas(5);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error al cargar estadísticas: {ex.Message}");
    }
}

private void btnActualizarEstadisticas_Click(object sender, EventArgs e)
{
    CargarEstadisticas();
    MessageBox.Show("Estadísticas actualizadas", "Éxito");
}
```

---

### **FASE 5: Pestaña CONFIGURACIÓN**

#### **Paso 5.1: Diseñar secciones de configuración**

```
Panel: pnlConfiguracion (Dock: Fill, AutoScroll: true)

GroupBox: gbBaseDatos - "Base de Datos"
  TextBox: txtCadenaConexion (Multiline, ReadOnly)
  Button: btnProbarConexion
  Button: btnGuardarConexion
  Label: lblEstadoConexion

GroupBox: gbRespaldos - "Respaldos y Restauración"
  TextBox: txtRutaRespaldos
  Button: btnExaminarRuta
  RadioButton: rbRespaldoDiario / rbRespaldomManual
  Label: lblUltimoRespaldo
  Button: btnCrearRespaldo
  Button: btnRestaurarRespaldo

GroupBox: gbRFID - "Lector RFID (Futuro)"
  ComboBox: cbPuertoCOM
  Button: btnDetectarPuerto
  ComboBox: cbBaudRate
  Label: lblEstadoRFID
  Button: btnConfigurarRFID

GroupBox: gbPreferencias - "Preferencias"
  RadioButton: rbFormatoFecha1, rbFormatoFecha2, rbFormatoFecha3
  CheckBox: chkSonidoConfirmacion
  CheckBox: chkActualizacionAuto

GroupBox: gbInfoApp - "Información de la Aplicación"
  Label: lblVersion
  Label: lblFramework
  Button: btnVerLogs
```

#### **Paso 5.2: Implementar código de Configuración**

```csharp
private void btnProbarConexion_Click(object sender, EventArgs e)
{
    try
    {
        AccesoDatos datos = new AccesoDatos();
        datos.abrirConexion();
        datos.cerrarConexion();
        
        lblEstadoConexion.Text = "✅ Conectado correctamente";
        lblEstadoConexion.ForeColor = Color.Green;
    }
    catch (Exception ex)
    {
        lblEstadoConexion.Text = "❌ Error de conexión";
        lblEstadoConexion.ForeColor = Color.Red;
        MessageBox.Show($"Error: {ex.Message}");
    }
}

private void btnCrearRespaldo_Click(object sender, EventArgs e)
{
    try
    {
        string rutaRespaldo = txtRutaRespaldos.Text;
        string nombreArchivo = $"Respaldo_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
        
        // Ejecutar backup de SQL Server
        AccesoDatos datos = new AccesoDatos();
        datos.ejecutarConsulta($"BACKUP DATABASE BD_Control_Almuerzos TO DISK='{rutaRespaldo}\\{nombreArchivo}'");
        
        MessageBox.Show("Respaldo creado correctamente", "Éxito");
        lblUltimoRespaldo.Text = $"Último respaldo: {DateTime.Now}";
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error al crear respaldo: {ex.Message}");
    }
}

// Cargar configuración desde App.config
private void CargarConfiguracion()
{
    txtCadenaConexion.Text = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
    txtRutaRespaldos.Text = ConfigurationManager.AppSettings["RutaRespaldos"] ?? @"C:\Respaldos";
    lblVersion.Text = $"Versión: {Application.ProductVersion}";
    lblFramework.Text = "Framework: .NET Framework 4.8.1";
}
```

---

### **FASE 6: Integración con frmPrincipal**

#### **Paso 6.1: Agregar ucAdmin al formulario principal**

**En frmPrincipal.cs:**

```csharp
// Variable de instancia
private ucAdmin vistaAdmin;

// En el constructor o Load
vistaAdmin = new ucAdmin();
vistaAdmin.Dock = DockStyle.Fill;
vistaAdmin.Visible = false;
panelContenido.Controls.Add(vistaAdmin);

// Método para mostrar ucAdmin
private void MostrarAdmin()
{
    ocultarVistas();
    vistaAdmin.Visible = true;
    // Refresh de datos si es necesario
}

// En el evento del botón de administración
private void btnAdmin_Click(object sender, EventArgs e)
{
    MostrarAdmin();
}
```

#### **Paso 6.2: Controlar acceso según estado del servicio**

```csharp
// ucAdmin solo accesible cuando NO hay servicio activo
private void ValidarAccesoAdmin()
{
    if (servicioActivo != null)
    {
        btnAdmin.Enabled = false;
        btnAdmin.Cursor = Cursors.No;
    }
    else
    {
        btnAdmin.Enabled = true;
        btnAdmin.Cursor = Cursors.Hand;
    }
}
```

---

### **FASE 7: Métodos en Capa de Negocio**

#### **Paso 7.1: Agregar métodos en EmpleadoNegocio.cs**

```csharp
public void agregar(Empleado empleado)
{
    AccesoDatos datos = new AccesoDatos();
    try
    {
        datos.setearConsulta("INSERT INTO Empleados (IdCredencial, Nombre, Apellido, IdEmpresa, Estado) VALUES (@credencial, @nombre, @apellido, @empresa, @estado)");
        datos.setearParametro("@credencial", empleado.IdCredencial);
        datos.setearParametro("@nombre", empleado.Nombre);
        datos.setearParametro("@apellido", empleado.Apellido);
        datos.setearParametro("@empresa", empleado.Empresa.IdEmpresa);
        datos.setearParametro("@estado", empleado.Estado);
        datos.ejecutarAccion();
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

public void modificar(Empleado empleado)
{
    AccesoDatos datos = new AccesoDatos();
    try
    {
        datos.setearConsulta("UPDATE Empleados SET IdCredencial = @credencial, Nombre = @nombre, Apellido = @apellido, IdEmpresa = @empresa, Estado = @estado WHERE IdEmpleado = @id");
        datos.setearParametro("@id", empleado.IdEmpleado);
        datos.setearParametro("@credencial", empleado.IdCredencial);
        datos.setearParametro("@nombre", empleado.Nombre);
        datos.setearParametro("@apellido", empleado.Apellido);
        datos.setearParametro("@empresa", empleado.Empresa.IdEmpresa);
        datos.setearParametro("@estado", empleado.Estado);
        datos.ejecutarAccion();
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
    catch (Exception ex)
    {
        throw ex;
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
    catch (Exception ex)
    {
        throw ex;
    }
    finally
    {
        datos.cerrarConexion();
    }
}
```

#### **Paso 7.2: Agregar métodos en EmpresaNegocio.cs**

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
    catch (Exception ex)
    {
        throw ex;
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
    catch (Exception ex)
    {
        throw ex;
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
    catch (Exception ex)
    {
        throw ex;
    }
    finally
    {
        datos.cerrarConexion();
    }
}
```

---

### **FASE 8: Testing y Validación**

#### **Paso 8.1: Pruebas de Empleados**

- [ ] Crear nuevo empleado
- [ ] Verificar credencial única
- [ ] Modificar datos de empleado
- [ ] Cambiar estado (activar/desactivar)
- [ ] Buscar empleado por nombre
- [ ] Filtrar por empresa
- [ ] Validaciones de campos vacíos

#### **Paso 8.2: Pruebas de Empresas**

- [ ] Crear nueva empresa
- [ ] Modificar nombre
- [ ] Cambiar estado
- [ ] Ver estadísticas de empresa
- [ ] Validar nombre único

#### **Paso 8.3: Pruebas de Estadísticas**

- [ ] Verificar totales correctos
- [ ] Actualizar datos en tiempo real
- [ ] Generar reporte completo

#### **Paso 8.4: Pruebas de Configuración**

- [ ] Probar conexión a BD
- [ ] Crear respaldo
- [ ] Cambiar preferencias

---

### **FASE 9: Pulido Final**

#### **Paso 9.1: Mejorar UX**

- Agregar tooltips a botones
- Implementar atajos de teclado
- Agregar confirmaciones
- Mensajes de error amigables

#### **Paso 9.2: Validaciones adicionales**

- No permitir eliminar empresa con empleados activos
- Validar formato de credencial
- Confirmar antes de desactivar

#### **Paso 9.3: Optimizaciones**

- Cache de listas de empresas
- Paginación si hay muchos registros
- Índices en BD para búsquedas

---

## ✅ Checklist de Implementación

### **Estructura:**
- [ ] Crear ucAdmin.cs
- [ ] Agregar TabControl con 4 pestañas
- [ ] Configurar SplitContainer en Empleados
- [ ] Configurar SplitContainer en Empresas

### **Pestaña Empleados:**
- [ ] DataGridView con empleados
- [ ] Formulario de edición
- [ ] Botones CRUD
- [ ] Búsqueda y filtros
- [ ] Métodos agregar(), modificar(), eliminar()
- [ ] Validaciones

### **Pestaña Empresas:**
- [ ] DataGridView con empresas
- [ ] Formulario de edición
- [ ] Panel de estadísticas por empresa
- [ ] Métodos CRUD
- [ ] Validaciones

### **Pestaña Estadísticas:**
- [ ] Cards con métricas
- [ ] Top 5 empresas
- [ ] Botón actualizar
- [ ] Método CargarEstadisticas()

### **Pestaña Configuración:**
- [ ] Sección Base de Datos
- [ ] Sección Respaldos
- [ ] Sección RFID
- [ ] Sección Preferencias
- [ ] Métodos de configuración

### **Integración:**
- [ ] Agregar ucAdmin a frmPrincipal
- [ ] Botón de navegación
- [ ] Control de acceso por estado de servicio

### **Testing:**
- [ ] Probar todos los CRUD
- [ ] Validar restricciones
- [ ] Verificar estadísticas
- [ ] Pruebas de integración

---

## 🎯 Tiempo Estimado

| Fase | Tiempo Estimado |
|------|-----------------|
| Fase 1: Estructura base | 30 min |
| Fase 2: Pestaña Empleados | 3-4 horas |
| Fase 3: Pestaña Empresas | 2-3 horas |
| Fase 4: Pestaña Estadísticas | 2 horas |
| Fase 5: Pestaña Configuración | 2 horas |
| Fase 6: Integración | 1 hora |
| Fase 7: Métodos de Negocio | 2 horas |
| Fase 8: Testing | 2 horas |
| Fase 9: Pulido | 1 hora |
| **TOTAL** | **15-18 horas** |