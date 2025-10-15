# 📋 Guía de Implementación: ucEmpresas

## 🎯 Objetivo
Completar la funcionalidad del UserControl `ucEmpresas` siguiendo el mismo patrón implementado en `ucEmpleados`.

---

## 📊 Análisis del Código Actual

### ✅ Ya implementado:
- Estructura básica de la clase con variables privadas
- Métodos esqueleto: `CargarEmpresas()`, `LimpiarFormulario()`, `ValidarFormulario()`, `CargarEmpresa()`
- Eventos de botones conectados
- Validación básica del formulario
- Controles de interfaz (Designer)

### ❌ Falta implementar:
- Lógica completa del método `CargarEmpresas()`
- Evento `dgvEmpresas_SelectionChanged`
- Método `CargarEmpresaEnFormulario()`
- Método `OcultarColumnas()`
- Corregir mensaje de éxito en `btnGuardarEmpresa_Click`
- Implementar filtros de búsqueda
- Agregar contador de empresas

---

## 📝 Paso a Paso de Implementación

### **PASO 1: Completar el método CargarEmpresas()**

**Objetivo:** Cargar la lista de empresas desde la base de datos y mostrarla en el DataGridView

**Acciones necesarias:**

1.1. Llamar al método `listar()` del objeto `negE` (EmpresaNegocio) para obtener la lista de empresas

1.2. Validar que la lista no sea nula antes de continuar

1.3. Limpiar el DataSource actual del DataGridView asignándole `null`

1.4. Establecer la propiedad `AutoGenerateColumns` del DataGridView en `true`

1.5. Asignar la lista de empresas al DataSource del DataGridView

1.6. Llamar al método `OcultarColumnas()` para configurar las columnas visibles

1.7. Actualizar un label con el total de empresas mostradas (similar a `lblTotalEmpleados` en ucEmpleados)

**Referencia:** Observar el método `CargarEmpleados()` en ucEmpleados (líneas 31-55)

---

### **PASO 2: Crear el método OcultarColumnas()**

**Objetivo:** Configurar qué columnas del DataGridView deben ser visibles u ocultas

**Acciones necesarias:**

2.1. Obtener la colección de columnas del DataGridView

2.2. Validar que la colección no sea nula

2.3. Definir un array de strings con los nombres de las columnas que deben mostrarse
   - Ejemplo: `{"Nombre"}` (ya que Empresa solo tiene IdEmpresa, Nombre y Estado)

2.4. Recorrer todas las columnas del DataGridView

2.5. Para cada columna, verificar si su nombre está en el array de columnas a mostrar

2.6. Si NO está en el array, ocultar la columna estableciendo `Visible = false`

2.7. Si SÍ está en el array, mostrar la columna estableciendo `Visible = true`

2.8. Opcional: Cambiar los encabezados de las columnas para que sean más descriptivos
   - Ejemplo: "Nombre" → "Empresa"

2.9. Opcional: Configurar el orden de visualización de las columnas usando `DisplayIndex`

**Referencia:** Observar el método `OcultarColumnas()` en ucEmpleados (líneas 57-83)

---

### **PASO 3: Implementar el evento dgvEmpresas_SelectionChanged**

**Objetivo:** Detectar cuando el usuario selecciona una fila del DataGridView y cargar sus datos en el formulario

**Acciones necesarias:**

3.1. Verificar que exista una fila seleccionada (`CurrentRow != null`)

3.2. Obtener el valor de la celda "IdEmpresa" de la fila actual

3.3. Convertir el valor a tipo `int`

3.4. Llamar al método `CargarEmpresaEnFormulario()` pasando el IdEmpresa como parámetro

**Referencia:** Observar el evento `dgvEmpleados_SelectionChanged` en ucEmpleados (líneas 105-111)

---

### **PASO 4: Crear el método CargarEmpresaEnFormulario(int idEmpresa)**

**Objetivo:** Buscar una empresa por su ID y llenar el formulario con sus datos para edición

**Acciones necesarias:**

4.1. Buscar la empresa en la lista cargada en el DataGridView usando el idEmpresa
   - Recorrer la lista y comparar IdEmpresa
   - O usar LINQ: `listaEmpresas.Find(e => e.IdEmpresa == idEmpresa)`

4.2. Asignar la empresa encontrada a la variable `seleccionada`

4.3. Validar que `seleccionada` no sea nula

4.4. Llenar los controles del formulario con los datos de la empresa:
   - Asignar `txtNombre.Text` con el nombre de la empresa
   - Establecer el RadioButton correspondiente según el estado (Activo/Inactivo)

4.5. Establecer `modoEdicion = true`

4.6. Habilitar el botón "Eliminar" (`btnEliminarEmpresa.Enabled = true`)

**Referencia:** Observar el método `CargarEmpleadoEnFormulario()` en ucEmpleados (líneas 113-126)

**Nota importante:** Para buscar la empresa por ID necesitarás:
- Opción A: Guardar la lista de empresas en una variable de clase
- Opción B: Crear un método en EmpresaNegocio.cs llamado `buscarPorId(int id)` (recomendado para seguir el patrón de EmpleadoNegocio)

---

### **PASO 5: Corregir el método btnGuardarEmpresa_Click**

**Objetivo:** Arreglar el mensaje de éxito que actualmente dice "Empleado guardado" en lugar de "Empresa guardada"

**Acciones necesarias:**

5.1. Localizar la línea donde se muestra el mensaje de éxito

5.2. Cambiar el texto de "Empleado guardado correctamente" a "Empresa guardada correctamente"

5.3. Verificar que el método `CargarEmpresa()` esté asignando correctamente todos los campos:
   - IdEmpresa (solo en modo edición)
   - Nombre
   - Estado

**Referencia:** Observar el método `btnGuardarEmpleado_Click` en ucEmpleados (líneas 133-142)

---

### **PASO 6: Agregar funcionalidad de búsqueda/filtro (Opcional pero recomendado)**

**Objetivo:** Permitir filtrar empresas por nombre mientras el usuario escribe

**Acciones necesarias:**

6.1. Verificar que existe un TextBox para búsqueda en el Designer (similar a `txtBuscarEmpleado`)

6.2. Crear el evento `TextChanged` del TextBox de búsqueda

6.3. Dentro del evento:
   - Obtener la lista completa de empresas desde `negE.listar()`
   - Aplicar un filtro usando LINQ o FindAll para buscar coincidencias en el nombre
   - Convertir el texto de búsqueda a mayúsculas para comparación sin distinción de mayúsculas
   - Actualizar el DataSource del DataGridView con la lista filtrada
   - Actualizar el contador de empresas

**Referencia:** Observar el método `txtBuscarEmpleado_TextChanged` en ucEmpleados (líneas 202-210)

---

### **PASO 7: Mejorar el método CargarEmpresas con parámetro de filtro**

**Objetivo:** Permitir que el método CargarEmpresas reciba un filtro opcional de búsqueda

**Acciones necesarias:**

7.1. Modificar la firma del método para recibir un parámetro string opcional:
   - `CargarEmpresas(string filtro = "")`

7.2. Después de obtener la lista de empresas, verificar si el filtro no está vacío

7.3. Si hay filtro, aplicar búsqueda por nombre:
   - Usar `FindAll` o LINQ para filtrar empresas cuyo nombre contenga el texto del filtro
   - Comparar en mayúsculas para ignorar mayúsculas/minúsculas

7.4. Actualizar todas las llamadas a `CargarEmpresas()` en el código:
   - Las que no necesitan filtro: `CargarEmpresas()`
   - La del TextBox de búsqueda: `CargarEmpresas(txtBuscar.Text)`

**Referencia:** Observar el método `CargarEmpleados(string filtro = "", int idEmpresa = 0)` en ucEmpleados (líneas 31-55)

---

### **PASO 8: Agregar contador de total de empresas**

**Objetivo:** Mostrar al usuario cuántas empresas hay en total

**Acciones necesarias:**

8.1. Verificar que existe un Label para mostrar el total (similar a `lblTotalEmpleados`)

8.2. En el método `CargarEmpresas()`, después de asignar el DataSource:
   - Contar la cantidad de empresas en la lista
   - Actualizar el texto del Label con el formato: "Total Empresas: X"

8.3. Considerar mostrar el total filtrado cuando se aplica búsqueda

**Referencia:** Observar cómo se actualiza `lblTotalEmpleados.Text` en ucEmpleados (línea 55)

---

### **PASO 9: Agregar método buscarPorId en EmpresaNegocio.cs (Si no existe)**

**Objetivo:** Crear un método en la capa de negocio para buscar una empresa por su ID

**Acciones necesarias en EmpresaNegocio.cs:**

9.1. Crear un nuevo método público que retorne un objeto `Empresa`

9.2. El método debe recibir un parámetro `int id`

9.3. Instanciar un objeto `AccesoDatos`

9.4. Configurar el procedimiento almacenado para buscar por ID (si existe, sino usar sp_ListarEmpresas)

9.5. Usar un bloque try-finally para cerrar la conexión

9.6. Si se obtiene un registro, crear un objeto Empresa y llenarlo con los datos

9.7. Retornar la empresa encontrada o null si no existe

**Referencia:** Observar el método `buscarPorId()` en EmpleadoNegocio.cs (si existe)

**Alternativa más simple:** 
- En lugar de crear un método en el negocio, guardar la lista de empresas en una variable de clase
- Buscar en esa lista cuando se selecciona una fila

---

### **PASO 10: Validaciones adicionales (Opcional)**

**Objetivo:** Mejorar la experiencia de usuario con validaciones más completas

**Acciones sugeridas:**

10.1. En `ValidarFormulario()`:
   - Validar que el nombre no sea solo espacios en blanco (usar Trim())
   - Validar longitud mínima del nombre (ej: 2 caracteres)
   - Validar que no exista otra empresa con el mismo nombre

10.2. En `btnEliminarEmpresa_Click()`:
   - Verificar si la empresa tiene empleados activos asociados
   - Mostrar advertencia si tiene empleados: "No se puede desactivar una empresa con empleados activos"
   - Solo permitir desactivar si no tiene empleados

10.3. Agregar mensajes informativos según el contexto

**Referencia:** Observar `ValidarFormularioEmpleado()` en ucEmpleados (líneas 228-254)

---

## ✅ Checklist de Verificación

Después de implementar todos los pasos, verifica que:

- [ ] Al cargar el UserControl, la grilla muestra todas las empresas
- [ ] Las columnas IdEmpresa y Estado están ocultas
- [ ] Al seleccionar una fila, los datos se cargan en el formulario
- [ ] El botón "Eliminar" se habilita solo cuando hay una empresa seleccionada
- [ ] Se puede agregar una nueva empresa correctamente
- [ ] Se puede modificar una empresa existente correctamente
- [ ] Se puede desactivar una empresa (si no tiene empleados activos)
- [ ] El botón "Nuevo" limpia el formulario correctamente
- [ ] El botón "Cancelar" limpia el formulario
- [ ] Las validaciones del formulario funcionan correctamente
- [ ] El contador de total de empresas se actualiza correctamente
- [ ] La búsqueda por nombre filtra correctamente (si se implementó)
- [ ] Los mensajes de éxito/error son claros y correctos

---

## 🔍 Comparación con ucEmpleados

| Característica | ucEmpleados | ucEmpresas |
|---|---|---|
| **Instancia de negocio** | EmpleadoNegocio | EmpresaNegocio ✅ |
| **Objeto seleccionado** | empleadoSeleccionado | seleccionada ✅ |
| **Modo edición** | modoEdicion | modoEdicion ✅ |
| **Método cargar lista** | CargarEmpleados() | CargarEmpresas() ⚠️ |
| **Método ocultar columnas** | OcultarColumnas() | ❌ Falta implementar |
| **Evento SelectionChanged** | ✅ Implementado | ❌ Falta implementar |
| **Cargar en formulario** | CargarEmpleadoEnFormulario() | ❌ Falta implementar |
| **Validaciones** | ValidarFormularioEmpleado() | ValidarFormulario() ⚠️ |
| **Limpiar formulario** | LimpiarFormularioEmpleado() | LimpiarFormulario() ✅ |
| **Cargar objeto** | CargarEmpleado() | CargarEmpresa() ✅ |
| **Búsqueda/Filtro** | ✅ txtBuscarEmpleado | ⚠️ Verificar si existe control |
| **Contador total** | lblTotalEmpleados | ⚠️ Agregar contador |

**Leyenda:**
- ✅ Implementado completamente
- ⚠️ Implementado parcialmente o necesita mejoras
- ❌ No implementado

---

## 🎯 Prioridad de Implementación

### **Alta Prioridad (Funcionalidad básica):**
1. Completar `CargarEmpresas()` (Paso 1)
2. Implementar `OcultarColumnas()` (Paso 2)
3. Implementar evento `dgvEmpresas_SelectionChanged` (Paso 3)
4. Crear `CargarEmpresaEnFormulario()` (Paso 4)
5. Corregir mensaje en `btnGuardarEmpresa_Click` (Paso 5)

### **Media Prioridad (Mejoras de UX):**
6. Agregar contador de empresas (Paso 8)
7. Crear método `buscarPorId` en EmpresaNegocio (Paso 9)

### **Baja Prioridad (Opcionales):**
8. Implementar búsqueda por nombre (Paso 6 y 7)
9. Validaciones adicionales (Paso 10)

---

## 📚 Notas Importantes

### Diferencias clave entre Empleados y Empresas:

1. **Empresas es más simple:**
   - Solo tiene 3 campos: IdEmpresa, Nombre, Estado
   - No tiene relaciones con otras tablas (como Empleado → Empresa)
   - No necesita ComboBox de selección como en Empleados

2. **No necesita verificación de duplicados en tiempo real:**
   - Empleados tiene botón "Verificar Credencial"
   - Empresas puede validar nombre duplicado solo al guardar

3. **Filtros más simples:**
   - Empleados filtra por nombre, apellido, credencial Y empresa
   - Empresas solo filtra por nombre

4. **Consideración especial al eliminar:**
   - Antes de desactivar una empresa, verificar que no tenga empleados activos
   - Usar la vista `vw_EmpresasConEmpleados` o crear método en negocio

### Estructura de carpetas:
```
SCA/
  app/
    UserControls/
      ucEmpresas.cs          ← Código lógico (aquí trabajas)
      ucEmpresas.Designer.cs ← Diseño de interfaz (generado automáticamente)
      ucEmpresas.resx        ← Recursos (generado automáticamente)
```

### Buenas prácticas aplicadas en ucEmpleados:
- Uso de `ExceptionHelper` para mensajes consistentes
- Separación de responsabilidades (cada método tiene una tarea específica)
- Validaciones antes de operaciones críticas
- Limpieza del formulario después de operaciones exitosas
- Feedback visual al usuario (habilitar/deshabilitar botones)

---

## 🚀 Siguiente Paso

Una vez completada la implementación de ucEmpresas, considera:

1. **Probar exhaustivamente** todas las funcionalidades
2. **Documentar** cualquier comportamiento especial
3. **Refactorizar** código duplicado entre ucEmpleados y ucEmpresas (si aplica)
4. **Agregar características extras** como exportar a PDF/Excel

---

**Fecha de creación:** 15 de octubre de 2025  
**Basado en:** Implementación de ucEmpleados  
**Archivo de referencia:** `SCA\app\UserControls\ucEmpleados.cs`
