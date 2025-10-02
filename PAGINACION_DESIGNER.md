# 📄 Paginación en DataGridView desde Designer

## ❌ Respuesta corta: NO es posible paginación real desde Designer

El `DataGridView` de Windows Forms **NO tiene paginación integrada** que puedas configurar desde las propiedades del Designer. 

## ¿Por qué NO?

El DataGridView está diseñado para mostrar **todos** los registros del DataSource. No tiene propiedades como:
- ❌ `PageSize`
- ❌ `CurrentPage`
- ❌ `TotalPages`
- ❌ `ShowPager`

## ✅ Soluciones alternativas

### Opción 1: BindingNavigator (Navegación básica)
**Disponible en Designer:** ✅ Sí, pero NO es paginación real

**Pasos:**
1. Agregar `BindingNavigator` al formulario desde el Toolbox
2. Establecer su propiedad `BindingSource` al mismo BindingSource del DataGridView
3. Esto da botones de navegación: |< < > >|

**Limitaciones:**
- Solo navega **registro por registro**, no por páginas
- Carga TODOS los datos en memoria
- No reduce el consumo de recursos
- Solo útil para < 1000 registros

**Ejemplo visual:**
```
[|<] [<] Registro 5 de 1000 [>] [>|]
```

### Opción 2: Paginación Manual (Recomendada)
**Disponible en Designer:** ⚠️ Parcial (controles sí, lógica no)

**Lo que SÍ puedes hacer en Designer:**

1. **Agregar controles de paginación:**
   - Botón `btnPrimera` (texto: "Primera")
   - Botón `btnAnterior` (texto: "◄ Anterior")
   - Label `lblPagina` (texto: "Página 1 de 10")
   - Botón `btnSiguiente` (texto: "Siguiente ►")
   - Botón `btnUltima` (texto: "Última")
   - ComboBox `cbTamañoPagina` (Items: 10, 25, 50, 100)

2. **Layout visual en Designer:**
```
┌──────────────────────────────────────────────────┐
│ DataGridView (llena el espacio)                 │
│                                                  │
└──────────────────────────────────────────────────┘
[Primera] [◄ Anterior] Página 1 de 10 [Siguiente ►] [Última]  Tamaño: [25 ▼]
```

**Lo que NO puedes hacer en Designer:**
- ❌ La lógica de paginación (DEBE ser código)
- ❌ Calcular offset/limit
- ❌ Llamar al stored procedure con parámetros
- ❌ Manejar eventos de botones

### Opción 3: Usar un Control de Terceros
**Disponible en Designer:** ✅ Sí, con controles premium

Controles comerciales con paginación integrada:
- **DevExpress GridControl** ($$$)
- **Telerik RadGridView** ($$$)
- **Syncfusion DataGrid** ($$$)

Estos SÍ tienen paginación desde Designer, pero son **pagos**.

## 📝 Implementación paso a paso (Opción 2)

### Paso 1: Diseñar controles en Designer

**En ucVistaPrincipal.Designer.cs o usando el Designer visual:**

1. Selecciona el UserControl
2. Agrega un `Panel` en la parte inferior (Dock: Bottom, Height: 40)
3. Dentro del panel, agrega:
   - `Button` btnPrimera (Text: "Primera", Location: 10,8)
   - `Button` btnAnterior (Text: "◄", Location: 90,8)
   - `Label` lblPagina (Text: "Página 1 de 1", Location: 140,12)
   - `Button` btnSiguiente (Text: "►", Location: 250,8)
   - `Button` btnUltima (Text: "Última", Location: 300,8)
   - `ComboBox` cbTamañoPagina (Location: 400,8, Width: 60)

4. Ajusta el DataGridView: Dock = Fill (o ajusta su Height para que no tape los botones)

### Paso 2: Configurar propiedades en Designer

**ComboBox cbTamañoPagina:**
- En propiedades → Items (Collection)
- Agregar: 10, 25, 50, 100
- DropDownStyle: DropDownList
- SelectedIndex: 1 (25)

**Botones:**
- Enabled: False (los habilitarás en código según la página actual)

### Paso 3: Código (OBLIGATORIO, no hay otra forma)

**Agregar variables de clase:**
```csharp
private int paginaActual = 1;
private int tamañoPagina = 25;
private int totalRegistros = 0;
private int totalPaginas = 0;
```

**Conectar eventos de botones (doble click en cada botón en Designer):**

```csharp
private void btnPrimera_Click(object sender, EventArgs e)
{
    paginaActual = 1;
    CargarRegistros();
}

private void btnAnterior_Click(object sender, EventArgs e)
{
    if (paginaActual > 1)
    {
        paginaActual--;
        CargarRegistros();
    }
}

private void btnSiguiente_Click(object sender, EventArgs e)
{
    if (paginaActual < totalPaginas)
    {
        paginaActual++;
        CargarRegistros();
    }
}

private void btnUltima_Click(object sender, EventArgs e)
{
    paginaActual = totalPaginas;
    CargarRegistros();
}

private void cbTamañoPagina_SelectedIndexChanged(object sender, EventArgs e)
{
    tamañoPagina = int.Parse(cbTamañoPagina.SelectedItem.ToString());
    paginaActual = 1;
    CargarRegistros();
}
```

**Modificar método CargarRegistros:**
```csharp
private void CargarRegistros()
{
    if (!servicioIdActual.HasValue) return;
    
    // 1. Obtener total de registros
    totalRegistros = negR.contarRegistrosPorServicio(servicioIdActual.Value);
    totalPaginas = (int)Math.Ceiling(totalRegistros / (double)tamañoPagina);
    
    // 2. Calcular offset
    int offset = (paginaActual - 1) * tamañoPagina;
    
    // 3. Cargar solo la página actual
    var registros = negR.listarPorServicioPaginado(
        servicioIdActual.Value, 
        offset, 
        tamañoPagina
    );
    
    dgvRegistros.DataSource = registros;
    OcultarColumnas();
    ActualizarControlesPaginacion();
}

private void ActualizarControlesPaginacion()
{
    lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";
    btnPrimera.Enabled = paginaActual > 1;
    btnAnterior.Enabled = paginaActual > 1;
    btnSiguiente.Enabled = paginaActual < totalPaginas;
    btnUltima.Enabled = paginaActual < totalPaginas;
}
```

**Agregar método en RegistroNegocio.cs:**
```csharp
public List<Registro> listarPorServicioPaginado(int idServicio, int offset, int pageSize)
{
    List<Registro> lista = new List<Registro>();
    AccesoDatos datos = new AccesoDatos();
    
    try
    {
        datos.setearProcedimiento("SP_ListarRegistrosPorServicioPaginado");
        datos.setearParametro("@IdServicio", idServicio);
        datos.setearParametro("@Offset", offset);
        datos.setearParametro("@PageSize", pageSize);
        datos.ejecutarLectura();
        
        while (datos.Lector.Read())
        {
            Registro registro = new Registro();
            registro.IdRegistro = (int)datos.Lector["IdRegistro"];
            registro.Hora = (TimeSpan)datos.Lector["Hora"];
            registro.Fecha = (DateTime)datos.Lector["Fecha"];
            registro.NombreEmpleado = (string)datos.Lector["Empleado"];
            registro.NombreEmpresa = (string)datos.Lector["Empresa"];
            registro.NombreLugar = (string)datos.Lector["Lugar"];
            lista.Add(registro);
        }
        
        return lista;
    }
    catch (Exception)
    {
        throw;
    }
    finally
    {
        datos.cerrarConexion();
    }
}
```

**Crear stored procedure en SQL:**
```sql
CREATE PROCEDURE SP_ListarRegistrosPorServicioPaginado
    @IdServicio INT,
    @Offset INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        r.IdRegistro,
        r.Hora,
        r.Fecha,
        Empleado = CONCAT(e.Nombre, ' ', e.Apellido),
        Empresa = emp.Nombre,
        Lugar = l.Nombre
    FROM Registros r
    INNER JOIN Empleados e ON r.IdEmpleado = e.IdEmpleado
    INNER JOIN Empresas emp ON r.IdEmpresa = emp.IdEmpresa
    INNER JOIN Lugares l ON r.IdLugar = l.IdLugar
    WHERE r.IdServicio = @IdServicio
    ORDER BY r.Hora DESC
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END
```

## ⚡ Resumen

| Aspecto | Desde Designer | Requiere Código |
|---------|----------------|-----------------|
| Agregar botones | ✅ Sí | ❌ No |
| Configurar layout | ✅ Sí | ❌ No |
| Lógica de paginación | ❌ No | ✅ Sí (OBLIGATORIO) |
| Eventos de botones | ❌ No | ✅ Sí (OBLIGATORIO) |
| Consulta paginada | ❌ No | ✅ Sí (OBLIGATORIO) |
| Stored procedure | ❌ No | ✅ Sí (OBLIGATORIO) |

## 🎯 Conclusión

**NO puedes hacer paginación real solo desde el Designer.**

Lo que SÍ puedes hacer en Designer:
- ✅ Agregar y posicionar los controles visuales (botones, labels, combobox)
- ✅ Configurar propiedades básicas (texto, tamaño, colores)
- ✅ Crear el layout visual

Lo que DEBES hacer en código:
- ✅ Toda la lógica de paginación
- ✅ Eventos de los botones
- ✅ Llamadas a la base de datos
- ✅ Actualización de estados

**Recomendación:** Para tu proyecto, si tienes < 500 registros por servicio, NO necesitas paginación. El DataGridView maneja bien esa cantidad. Si tienes > 1000, entonces sí implementa la solución del Paso 2.

---

**¿Necesitas ayuda implementando esto?** Puedo generar el código completo para un UserControl específico si me lo indicas.
