#  Manual de Usuario - Sistema Control de Almuerzos

## ¿Qué es el Sistema Control de Almuerzos?

El Sistema Control de Almuerzos es una aplicación diseñada para gestionar de forma eficiente el registro de comensales en comedores corporativos. Con este sistema es posible:

-  **Registrar comensales** de forma rápida mediante credenciales
-  **Gestionar empleados** y sus credenciales
-  **Organizar por empresas** del predio
-  **Ver estadísticas en tiempo real** del servicio
-  **Generar reportes automáticos** para análisis
-  **Administrar servicios** por jornada (comedor y quincho)

---

## Índice

### Sección Personal de Cocina
1. [Tipos de Usuario](#-tipos-de-usuario)
2. [Panel Principal](#-panel-principal-frmPrincipal)
3. [Gestión del Servicio](#-gestión-del-servicio)
4. [Registro de Comensales](#-registro-de-comensales)
5. [Registro Manual](#-registro-manual-método-alternativo)

### Sección Administrador
7. [Gestión de Empleados](#-gestión-de-empleados)
8. [Gestión de Empresas](#-gestión-de-empresas)
9. [Configuración del Sistema](#-configuración-del-sistema)
10. [Reportes](#-reportes)
11. [Estadísticas](#-estadísticas)

### Sección General
12. [Preguntas Frecuentes](#-preguntas-frecuentes)
13. [Solución de Problemas](#-solución-de-problemas-comunes)
14. [Consejos de Uso](#-consejos-para-usar-mejor-el-sistema)
15. [Soporte Técnico](#-soporte-técnico)
16. [Mejoras Futuras](#-mejoras-futuras-del-sistema)

---

##  Tipos de Usuario

###  Personal de Cocina

**¿Qué puede hacer?**
-  **Ver el panel principal** con información del servicio actual
-  **Registrar comensales** mediante ID de credencial
-  **Realizar registro manual** (sin credencial)
-  Ver confirmaciones de registro
-  Ver en tiempo real quién se registró
-  Conocer el total de comensales actual
-  Ver comparativa con la proyección
-  Consultar detalles del servicio (lugar, duración, invitados)

**¿Cuándo lo usa?**
- Durante todo el horario de servicio del comedor
- Para registrar a los comensales que van llegando
- Para planificar porciones según la demanda real
- Para control de producción
- Para monitorear el avance del servicio

**Nota**: El personal de cocina trabaja principalmente desde el panel principal que muestra toda la información necesaria del servicio.

---

###  Administrador
**¿Qué puede hacer?**
-  **Todo lo anterior, más:**
-  Gestionar empleados y credenciales
-  Gestionar empresas y lugares
-  Generar reportes y estadísticas
-  Configurar el sistema

---

# SECCIÓN: PERSONAL DE COCINA

---

##  Panel Principal (frmPrincipal)

![Panel Principal](./docs/screenshots/manual_panel_principal.png)

### ¿Para Qué Sirve?

El panel principal es la **pantalla de inicio del sistema**. Es lo primero que se ve al abrir la aplicación, antes de iniciar cualquier servicio. Desde aquí se puede:
- Consultar el histórico de servicios anteriores
- Acceder a todas las funcionalidades del sistema mediante el menú lateral

---

### 1. Lista de Últimos Servicios

**¿Qué muestra?**
- Listado de los servicios más recientes realizados
- Ordenados cronológicamente (más recientes primero)
- Información resumida por servicio:
  - Fecha del servicio
  - Lugar (Comedor/Quincho)
  - Proyección inicial
  - Total de comensales reales

**¿Para qué sirve?**
- Consultar servicios anteriores rápidamente
- Ver histórico reciente sin necesidad de generar reportes
- Seleccionar un servicio para ver detalles completos
- Referencia para proyecciones futuras

**Interacción:**
- Hacer clic en cualquier servicio de la lista
- Se mostrarán sus detalles en el panel derecho

---

### 2. Detalles del Servicio Seleccionado

**Ubicación**: Panel derecho del formulario

**¿Qué muestra?**

Esta sección muestra información detallada de cualquier servicio **finalizado** que se seleccione de la lista de últimos servicios. 

**Al seleccionar un servicio de la lista:**

#### Información del Servicio
- **Fecha**: Día del servicio
- **Lugar**: Comedor o Quincho
- **Proyección**: Cantidad estimada inicial
- **Invitados esperados**: Cantidad configurada
- **Duración Total**: Tiempo que estuvo abierto el servicio (en minutos)
- **Total de Comensales Registrados**: Cantidad final de empleados que almorzaron
- **Cobertura**: Porcentaje alcanzado (Real / Proyección × 100)
- **Diferencia**: Cuántos más o menos respecto a la proyección

**¿Para qué sirve?**
- Consultar resultados de servicios anteriores
- Comparar asistencia entre diferentes días
- Usar datos históricos para mejorar proyecciones futuras
- Verificar información sin necesidad de generar reportes

---

##  Gestión del Servicio

### ¿Qué es un Servicio?

Un **servicio** representa una jornada de comedor (un día de atención). Cada servicio tiene:
-  **Lugar**: Comedor o Quincho
-  **Fecha**: Día del servicio
-  **Proyección**: Cantidad estimada de comensales
-  **Invitados esperados**: Cantidad estimada de invitados
-  **Estado**: Activo (en curso) o Finalizado (cerrado)

---

### Configuración e Inicio del Servicio

![Configuración de Servicio](./docs/screenshots/manual_config_servicio.png)

**Cuándo hacerlo**: Al comienzo de cada jornada (antes de que lleguen comensales)

#### Paso 1: Acceder a la Configuración
1. En el **Panel Principal** (frmPrincipal)
2. Sección superior: **Configuración del Servicio**
3. Completar los siguientes campos:

**1. Lugar** (Obligatorio)
- Desplegable: **Comedor** o **Quincho**
- Define dónde se brindará el servicio

**2. Proyección de Comensales** (Obligatorio)
- Cantidad estimada de personas que almorzarán
- Debe ser mayor a 0

**3. Total de Invitados Esperados** (Opcional)
- Cantidad de invitados externos (no empleados)
- Puede dejarse en 0
- Casos comunes: visitas, proveedores, entrevistados

**Nota sobre invitados**: Solo se registra la cantidad, no datos personales

#### Paso 2: Iniciar el Servicio
1. Verificar que todos los campos estén completos
2. Hacer clic en **"Iniciar Servicio"**
3. El sistema validará y creará el servicio
4. Se iniciará el cronómetro
5. Se habilitará el registro de comensales

**¿Qué sucede después?**
- El panel principal muestra toda la información del servicio activo
- El cronómetro comienza a correr
- La vista principal (ucVistaPrincipal) se activa para registros
- Los contadores se inicializan en 0

---

### Vista Principal del Servicio

![Vista Principal del Servicio](./docs/screenshots/manual_vista_principal.png)

#### ¿Qué contiene?

**Listado de Registros en Tiempo Real**

Esta tabla muestra todos los comensales que se han registrado en el servicio actual:

**Columnas visibles:**
- **Nombre y Apellido**: Identificación del comensal
- **Empresa**: Compañía a la que pertenece
- **Hora de Registro**: Formato HH:mm:ss (ej: 12:35:42)

**Características:**
-  **Actualización automática**: Cada nuevo registro aparece inmediatamente al tope
-  **Orden cronológico**: Los más recientes primero
-  **Sin necesidad de refrescar**: El sistema actualiza solo
-  **Scroll automático**: Se desplaza para mostrar el último registro

**Uso práctico:**
- Verificar que una persona específica se haya registrado
- Consultar la hora exacta de registro
- Ver distribución por empresa durante el servicio
- Control visual de quién ya almorzó

---

### Cierre del Servicio

**Cuándo hacerlo**: Al finalizar la jornada (cuando ya no llegarán más comensales)

#### Paso 1: Verificar que el Servicio esté Completo
Antes de cerrar:
-  Ya no llegarán más comensales
-  Todos los registros están completos
-  El equipo confirmó el cierre

#### Paso 2: Finalizar el Servicio
1. Hacer clic en **"Finalizar Servicio"**
2. Confirmar la operación
3. **Advertencia**: No se podrá registrar más comensales

#### Paso 3: Resumen Automático
El sistema calculará:
- **Duración total**: Tiempo desde inicio hasta cierre (en minutos)
- **Total de comensales**: Cantidad real registrada
- **Total de invitados**: Cantidad configurada
- **Cobertura**: Porcentaje alcanzado (Real / Proyección × 100)
- **Diferencia**: Cuántos más o menos respecto a la proyección

**Una vez cerrado:**
-  El servicio cambia a estado "Finalizado"
-  No se pueden registrar más comensales
-  Queda disponible en la lista de servicios para consulta
-  Se puede iniciar un nuevo servicio

**Importante**: Un servicio cerrado NO se puede reabrir (mantiene integridad de datos históricos)

---

### ¿Se Puede Tener Más de Un Servicio Activo?

**No**. Solo un servicio activo a la vez por lugar.

**Excepción**: Se puede tener Comedor activo + Quincho activo simultáneamente (son lugares diferentes)

---

##  Registro de Comensales

![Registro de Comensales](./docs/screenshots/manual_registro.png)

### ¿Cómo Registrar un Comensal? (Método Principal)

Este es el proceso más común y rápido, usado para el 95% de los registros:

#### Paso 1: Ubicación del Campo de Registro
- El campo de registro está en la parte inferior del **Panel Principal**
- No es necesario cambiar de pantalla
- Siempre visible durante el servicio

#### Paso 2: Verificar que Exista un Servicio Activo
- En el panel superior debe aparecer la información del servicio
- El campo de registro estará deshabilitado si no hay servicio

#### Paso 3: Ingresar ID de la Credencial
1. El comensal se acerca al mostrador
2. Personal solicita o lee el ID de la credencial
3. Escribir el ID en el **campo de texto** inferior
4. Hacer clic en **"Ingresar Registro"**

#### Paso 4: Confirmación Visual
El sistema mostrará una ventana temporal con:
-  **"Comensal Registrado"** (título)
-  **Nombre completo** del empleado
-  **Empresa** a la que pertenece
-  **Hora exacta de registro** (formato HH:mm:ss)

**Características de la confirmación:**
- Aparece en el centro de la pantalla
- Desaparece automáticamente después de 4 segundos
- Fondo amarillo corporativo (color distintivo)
- Texto grande y legible
- No requiere cerrar manualmente

#### Paso 5: Actualización Automática
Inmediatamente después del registro:
-  El **contador de comensales** aumenta en +1
-  El **nuevo registro aparece** al tope de la tabla
-  El **campo de texto se limpia** automáticamente
-  El **porcentaje de cobertura** se recalcula
-  Listo para el siguiente registro

---

##  Registro Manual (Método Alternativo)

![Registro Manual](./docs/screenshots/manual_registro_manual.png)

**Módulo**: `Registro Manual` (desde menú lateral)
**Usuario**: Personal de Cocina

### ¿Cuándo Usar Registro Manual?

**Situaciones comunes:**
-  Empleado olvidó su credencial en casa
-  Credencial dañada o ilegible
-  Tarjeta perdida (aún no se asignó nueva)
-  Credencial no funciona por error técnico
-  Empleado nuevo sin credencial asignada

---

### ¿Cómo Hacer un Registro Manual?

#### Paso 1: Acceder al Módulo
1. Desde el menú lateral, hacer clic en **"Registro Manual"**
2. Se abrirá una pantalla dedicada para búsqueda

#### Paso 2: Buscar al Empleado
1. En el **campo de búsqueda** superior, escribir:
   - Nombre del empleado, O
   - Apellido del empleado, O
   - Parte del nombre
2. Los resultados aparecen **automáticamente mientras escribes**
3. No es necesario presionar Enter ni botón de búsqueda

**Ejemplo**: Escribir "Juan" mostrará:
- Juan Pérez (Empresa A)
- Juan González (Empresa B)
- María Juana López (Empresa C)

#### Paso 3: Filtrar por Empresa (Opcional)
- Si hay muchos resultados, usar el **filtro de empresa**
- Seleccionar la empresa del desplegable
- La lista se reduce solo a empleados de esa empresa

#### Paso 4: Seleccionar al Empleado Correcto
1. **Verificar los datos** en la grilla:
   - Nombre completo
   - Empresa
   - Estado (debe estar Activo)
2. Hacer **clic en la fila** del empleado correcto
3. La fila se resaltará indicando la selección

#### Paso 5: Confirmar Registro
1. Hacer clic en el botón **"Agregar"** o **"Registrar"**
2. El sistema validará que:
   - Haya un servicio activo
   - El empleado no esté ya registrado hoy
   - El empleado esté en estado activo
3. Aparecerá la misma **confirmación visual** del método principal

#### Paso 6: Continuar Registrando
- El campo de búsqueda se limpia automáticamente
- Listo para buscar al siguiente empleado
- Puedes quedarte en esta pantalla o volver al panel principal

**Ventaja**: No depende de la credencial física, solo del nombre del empleado.

---

### ¿Qué Pasa si Hay un Error?

El sistema mostrará mensajes claros en caso de problema:

####  "Credencial no encontrada"
**Causa**: El ID ingresado no existe en el sistema  
**Solución**: 
- Verificar que el número sea correcto
- Usar el método de registro manual
- Contactar al administrador si el empleado es nuevo

####  "El empleado ya se registró en este servicio"
**Causa**: El empleado ya almorzó hoy  
**Solución**: 
- Explicar al empleado que ya está registrado
- Verificar en el panel de cocina si es necesario

####  "No hay servicio activo"
**Causa**: No se ha iniciado el servicio del día  
**Solución**: 
- Contactar al administrador
- El administrador debe iniciar el servicio del día

####  "Empleado inactivo"
**Causa**: El empleado fue dado de baja en el sistema  
**Solución**: 
- Contactar al administrador
- Verificar el estado del empleado

---

# SECCIÓN: ADMINISTRADOR

---

## Gestión de Empleados

![Gestión de Empleados](./docs/screenshots/manual_empleados.png)

**Módulo**: `Gestión de Empleados`
**Usuario**: Administrador

### ¿Para Qué Sirve?

Administrar toda la información de empleados del predio:
- Alta de nuevos empleados
- Modificación de datos
- Asignación de credenciales
- Baja de empleados

---

### ¿Cómo Ver Todos los Empleados?

1. Desde el panel **Administrador**, hacer clic en **Empleados**
2. Se mostrará una lista con todos los empleados que incluye:
   - Nombre y apellido
   - Empresa
   - ID de credencial asignada

### ¿Cómo Buscar un Empleado Específico?

1. En la pantalla de empleados, usar la **caja de búsqueda**
2. Es posible buscar por:
   - **Nombre**
   - **Apellido**
   - **Empresa**
3. Los resultados aparecerán automáticamente

---

### ¿Cómo Agregar un Nuevo Empleado?

#### Paso 1: Iniciar Alta
1. En la pantalla de empleados, hacer clic en **"Nuevo Empleado"**

#### Paso 2: Completar Datos Obligatorios
- **Nombre**: Nombre del empleado
- **Apellido**: Apellido del empleado
- **Empresa**: Seleccionar de la lista desplegable

#### Paso 3: Asignar Credencial (Opcional)
- **ID de Credencial**: Número único de su tarjeta corporativa
- Si no se tiene aún, se puede dejar en blanco y asignar después

#### Paso 4: Guardar
1. Hacer clic en **"Guardar"**
2. El sistema validará que no exista una credencial duplicada
3. El empleado quedará registrado como **Activo**

**Importante**: Cada credencial solo puede estar asignada a un empleado.

---

### ¿Cómo Modificar Datos de un Empleado?

#### Situaciones Comunes:
- Cambió de empresa
- Hay un error en el nombre
- Necesita nueva credencial (perdió la anterior)

#### Pasos:
1. **Seleccionar el empleado** de la lista
2. Hacer clic en **"Modificar"**
3. Cambiar la información necesaria
4. Hacer clic en **"Aceptar"** para guardar los cambios

---

### ¿Cómo Asignar o Cambiar una Credencial?

#### Situación 1: Empleado Nuevo (Sin Credencial)
1. Modificar el empleado
2. Ingresar el **ID de credencial** en el campo correspondiente
3. Guardar

#### Situación 2: Credencial Perdida o Dañada
1. Modificar el empleado
2. Cambiar el **ID de credencial** por el nuevo número
3. Guardar

**El sistema validará**:
-  Que el nuevo ID no esté en uso por otro empleado
-  Que el formato sea correcto

---

### ¿Cómo Dar de Baja un Empleado?

**Situación**: El empleado ya no trabaja en el predio.

#### Pasos:
1. **Seleccionar el empleado** de la lista
2. Hacer clic en **"Eliminar"**
3. Confirmar la baja

**¿Qué pasa al dar de baja?**
-  El empleado no podrá registrarse más en el comedor
-  **Se mantiene su historial** (no se borra del sistema)
-  Su credencial queda liberada para reasignar a otro empleado
-  Aparece en reportes históricos

**Nota**: La baja es **lógica**, no se elimina físicamente de la base de datos.

---

## Gestión de Empresas

![Gestión de Empresas](./docs/screenshots/manual_empresas.png)

**Módulo**: `Gestión de Empresas`
**Usuario**: Administrador

### ¿Para Qué Sirve?

Administrar las empresas del predio que utilizan el servicio de comedor:
- Alta de nuevas empresas
- Modificación de información
- Visualización de estadísticas por empresa
- Baja de empresas

---

### ¿Cómo Ver Todas las Empresas?

1. Desde el panel **Administrador**, hacer clic en **Empresas**
2. Se mostrará una lista con todas las empresas que incluye:
   - Nombre de la empresa
   - Total de empleados activos
   - Total de asistencias del mes actual
   - Estado (Activo/Inactivo)

### ¿Cómo Buscar una Empresa Específica?

1. En la pantalla de empresas, usar la **caja de búsqueda**
2. Escribir el **nombre** de la empresa
3. Los resultados aparecerán automáticamente

---

### ¿Cómo Agregar una Nueva Empresa?

#### Paso 1: Iniciar Alta
1. En la pantalla de empresas, hacer clic en **"Agregar Empresa"** o **"Nueva"**

#### Paso 2: Completar Datos Obligatorios
- **Nombre**: Nombre de la empresa
- **Descripción** (Opcional): Información adicional sobre la empresa

#### Paso 3: Guardar
1. Hacer clic en **"Guardar"** o **"Aceptar"**
2. El sistema validará que no exista una empresa con el mismo nombre
3. La empresa quedará registrada como **Activa**

**Importante**: Cada empresa debe tener un nombre único en el sistema.

---

### ¿Cómo Modificar Datos de una Empresa?

#### Situaciones Comunes:
- Cambió el nombre de la empresa
- Se necesita actualizar la descripción
- Hay un error en los datos

#### Pasos:
1. **Seleccionar la empresa** de la lista
2. Hacer clic en **"Modificar"** o **"Editar"**
3. Cambiar la información necesaria
4. Hacer clic en **"Aceptar"** para guardar los cambios

---

### ¿Cómo Dar de Baja una Empresa?

**Situación**: La empresa ya no opera en el predio o no utiliza más el servicio.

#### Pasos:
1. **Seleccionar la empresa** de la lista
2. Hacer clic en **"Eliminar"** o **"Dar de Baja"**
3. El sistema verificará si tiene empleados activos asociados
4. Confirmar la baja

**¿Qué pasa al dar de baja?**
-  **Si tiene empleados activos**: El sistema mostrará una advertencia y sugerirá desactivar primero a los empleados
-  **Si NO tiene empleados activos**: La empresa se desactivará normalmente
-  **Se mantiene el historial** de registros anteriores
-  Aparece en reportes históricos

**Nota**: La baja es **lógica**, no se elimina físicamente de la base de datos.

---

### Estadísticas de Empresas

Cada empresa muestra automáticamente:

#### Total de Empleados
- Cantidad de empleados activos vinculados a la empresa
- Se actualiza automáticamente al agregar/eliminar empleados

#### Asistencias del Mes
- Total de registros de almuerzos del mes actual
- Incluye todos los empleados de la empresa
- Se reinicia automáticamente cada mes
- Útil para facturación mensual

**Uso práctico**: Si una empresa tiene 50 empleados pero solo 200 asistencias en el mes, significa un promedio de 4 almuerzos por empleado (puede indicar ausentismo o trabajo remoto).

---

##  Configuración del Sistema

### ¿Para Qué Sirve?

El módulo de configuración permite:
-  Gestionar la conexión a la base de datos
-  Crear y restaurar respaldos (backups)
-  Consultar información del sistema
-  Ver información de la base de datos

---

### 1. Configuración de Base de Datos

![Configuración de Base de Datos](./docs/screenshots/manual_config_bd.png)

#### ¿Qué se puede hacer?

**Ver Información de la Base de Datos:**
- Nombre de la base de datos actual
- Tamaño ocupado en MB
- Fecha de creación
- Fecha de última actualización
- Nombre del servidor SQL

**Modificar Conexión:**
- Cambiar la cadena de conexión si se migra de servidor
- Probar la conectividad antes de guardar cambios
- Actualizar credenciales de acceso

#### ¿Cuándo modificar la conexión?
- Migración a nuevo servidor
- Cambio de credenciales de SQL Server
- Problemas de conectividad
- Configuración inicial del sistema

**IMPORTANTE**: Solo personal técnico capacitado debe modificar la cadena de conexión. Una configuración incorrecta puede dejar el sistema inoperativo.

---

### 2. Sistema de Respaldos (Backups)

![Sistema de Respaldos](./docs/screenshots/manual_config_respaldos.png)

#### ¿Por qué son importantes los respaldos?

Los respaldos protegen la información crítica del comedor contra:
- Fallas de hardware
- Errores humanos
- Corrupción de datos
- Desastres naturales

---

#### Tipos de Respaldo

**A. Respaldo Manual**

**¿Cuándo hacerlo?**
- Antes de actualizaciones importantes
- Antes de cambios masivos en datos
- Antes de modificar la configuración
- Cuando se requiera un respaldo inmediato

**¿Cómo crear un respaldo manual?**
1. Ir al módulo **Configuración**
2. Pestaña **"Respaldos"**
3. Hacer clic en **"Crear Respaldo Manual"** o **"Backup Ahora"**
4. Seleccionar la **carpeta destino** donde guardar el archivo
5. Esperar a que se complete el proceso
6. Verificar que el archivo .bak se haya creado

**B. Respaldo Automático Programado**

**¿Para qué sirve?**
- Crea respaldos automáticamente sin intervención humana
- Garantiza que siempre haya respaldos recientes
- Reduce el riesgo de pérdida de datos

**Frecuencias disponibles:**
-  **Mensual**: Un backup cada mes (recomendado)

**¿Cómo configurar respaldo automático?**
1. Ir al módulo **Configuración**
2. Pestaña **"Respaldos"**
3. Seleccionar frecuencia deseada
4. Establecer **ruta de destino** para los archivos
5. Hacer clic en **"Guardar Configuración"**
6. El sistema ejecutará los backups automáticamente

**Información del último respaldo:**
- Fecha y hora del último backup
- Ubicación del archivo
- Tamaño del archivo en MB

---

#### ¿Cómo Restaurar un Respaldo?

**¿Cuándo restaurar?**
- Se perdieron datos importantes
- La base de datos se corrompió
- Se necesita volver a un estado anterior
- Migración a nueva instalación

**Pasos para restaurar:**
1. Ir al módulo **Configuración**
2. Pestaña **"Respaldos"**
3. Hacer clic en **"Restaurar Respaldo"**
4. Seleccionar el **archivo .bak** a restaurar
5. Confirmar la operación
6. Esperar a que se complete el proceso
7. **Reiniciar la aplicación**

**ADVERTENCIA CRÍTICA:**
- La restauración **sobrescribe completamente** la base de datos actual
- **Todos los datos posteriores al backup se perderán**
- **No se puede deshacer** esta operación
- Se recomienda **crear un backup manual antes de restaurar**

**Recomendación**: Solo restaurar respaldos en situaciones críticas y con supervisión técnica.

---

### 3. Información de la Aplicación

![Información de la Aplicación](./docs/screenshots/manual_config_info.png)

#### ¿Qué información muestra?

**Datos del Sistema:**
- **Nombre**: Sistema de Control de Almuerzos
- **Versión**: Número de versión actual (ej: 1.0.0)
- **Fecha de compilación**: Cuándo se compiló esta versión
- **Framework**: .NET Framework 4.8
- **Librerías UI**: ReaLTaiizor & Windows Forms

**¿Para qué sirve esta información?**
- Verificar que se esté usando la versión más reciente
- Reportar bugs con información técnica precisa
- Validar compatibilidad con actualizaciones
- Soporte técnico

---

### Buenas Prácticas de Configuración

#### Respaldos:
-  Configurar respaldo automático mensual **siempre**
-  Crear backup manual antes de cualquier cambio importante
-  Verificar periódicamente que los backups se estén creando
-  Guardar respaldos en ubicación diferente al servidor (disco externo, nube)
-  Probar la restauración al menos una vez al año

#### Conexión de Base de Datos:
-  No modificar la cadena de conexión sin conocimientos técnicos
-  Probar la conexión antes de guardar cambios
-  Documentar cualquier cambio realizado
-  Mantener respaldo de la cadena anterior

#### Seguridad:
-  Solo administradores deben acceder a Configuración
-  No compartir la cadena de conexión
-  Proteger los archivos de respaldo con contraseña si contienen datos sensibles

---

## Reportes

### ¿Para Qué Sirven los Reportes?

Los reportes permiten:
-  Analizar asistencia histórica
-  Planificar compras de insumos
-  Identificar tendencias
-  Comparar asistencia por empresa
-  Generar documentos oficiales

---

### Tipos de Reportes Disponibles

El sistema incluye 4 tipos de reportes que se generan seleccionando un rango de fechas (Desde - Hasta) y opcionalmente filtrando por lugar (Comedor/Quincho o Todos).

---

#### 1.  Lista de Servicios

![Reporte de Lista de Servicios](./docs/screenshots/manual_reporte_servicios.png)

**¿Qué muestra?**
- Listado de todos los servicios realizados en el período seleccionado
- Fecha de cada servicio
- Proyección inicial de comensales
- Duración del servicio (en minutos)
- Total de comensales reales
- Total de invitados
- Total general (comensales + invitados)

**¿Cuándo usarlo?**
- Revisión de servicios realizados
- Verificar rendimiento histórico
- Análisis día por día
- Identificar servicios con mayor/menor asistencia

**¿Cómo generarlo?**
1. Ir a **"Reportes"**
2. Seleccionar **"Lista de servicios"** en el tipo de reporte
3. Elegir **Fecha Desde** y **Fecha Hasta**
4. Seleccionar **Lugar** (Todos, Comedor o Quincho)
5. Hacer clic en **"Generar"**

**Ejemplo de uso**: Ver todos los servicios de la última semana para analizar asistencia diaria.

---

#### 2.  Asistencias por Empresas

![Reporte de Asistencias por Empresas](./docs/screenshots/manual_reporte_empresas.png)

**¿Qué muestra?**
- Total de asistencias por cada empresa del predio
- Comparativa entre empresas
- Ranking de asistencia

**¿Cuándo usarlo?**
- Facturación por empresa
- Análisis de participación por compañía
- Identificar empresas con mayor/menor uso del comedor
- Reportes para gerencia

**¿Cómo generarlo?**
1. Ir a **"Reportes"**
2. Seleccionar **"Asistencias por empresas"** en el tipo de reporte
3. Elegir **Fecha Desde** y **Fecha Hasta**
4. Seleccionar **Lugar** (Todos, Comedor o Quincho)
5. Hacer clic en **"Generar"**

**Ejemplo de uso**: Generar reporte mensual para facturar a cada empresa según su uso del comedor.

---

#### 3. Cobertura vs Proyección

![Reporte de Cobertura vs Proyección](./docs/screenshots/manual_reporte_cobertura.png)

**¿Qué muestra?**
- Fecha del servicio
- Lugar (Comedor/Quincho)
- Proyección inicial
- Total de personas atendidas (comensales + invitados)
- Porcentaje de cobertura (Real / Proyección × 100)
- Diferencia entre proyección y realidad

**¿Cuándo usarlo?**
- Evaluar precisión de proyecciones
- Identificar días con sobre/subestimación
- Mejorar estimaciones futuras
- Análisis de planificación

**¿Cómo generarlo?**
1. Ir a **"Reportes"**
2. Seleccionar **"Cobertura vs proyección"** en el tipo de reporte
3. Elegir **Fecha Desde** y **Fecha Hasta**
4. Seleccionar **Lugar** (Todos, Comedor o Quincho)
5. Hacer clic en **"Generar"**

**Ejemplo de uso**: Analizar el último mes para ver si las proyecciones fueron acertadas y ajustar futuras estimaciones.

**Interpretación del porcentaje de cobertura**:
- **>100%**: Se superó la proyección (más gente de la esperada) → Puede haber faltado comida
- **80-100%**: Se cumplió la proyección → Planificación correcta
- **<80%**: No se alcanzó la proyección → Posible desperdicio de comida

---

#### 4.  Distribución por Día de Semana

![Reporte de Distribución por Día](./docs/screenshots/manual_reporte_diasemana.png)

**¿Qué muestra?**
- Total de asistencias agrupadas por día de la semana (Lunes, Martes, Miércoles, etc.)
- Permite identificar patrones semanales
- Muestra qué días hay más/menos demanda

**¿Cuándo usarlo?**
- Identificar patrones de asistencia semanal
- Planificar compras según día de la semana
- Ajustar proyecciones por día
- Análisis estratégico de tendencias

**¿Cómo generarlo?**
1. Ir a **"Reportes"**
2. Seleccionar **"Distribución por día de semana"** en el tipo de reporte
3. Elegir **Fecha Desde** y **Fecha Hasta**
4. Seleccionar **Lugar** (Todos, Comedor o Quincho)
5. Hacer clic en **"Generar"**

**Ejemplo de uso**: Analizar un mes completo para ver qué días de la semana tienen mayor asistencia.

**Patrones comunes observados**:
- **Lunes y Viernes**: Generalmente menor asistencia (home office, ausentismo)
- **Martes, Miércoles y Jueves**: Mayor asistencia (días pico de trabajo presencial)

**Uso práctico**: Si el reporte muestra que los miércoles tienen 30% más asistencia que los viernes, ajustar compras en consecuencia.

---

### ¿Cómo Exportar un Reporte a PDF?

Todos los reportes se pueden exportar a formato PDF profesional.

#### Pasos:
1. **Generar el reporte** (cualquiera de los anteriores)
2. Hacer clic en **"Exportar PDF"** o **"Guardar como PDF"**
3. Elegir la **ubicación** donde guardar el archivo
4. Asignar un **nombre** al archivo
5. Hacer clic en **"Guardar"**

#### El PDF incluirá:
-  Encabezado con logo (si está configurado)
-  Fecha y hora de generación
-  Todas las estadísticas y datos
-  Gráficos (si aplica)
-  Tablas formateadas profesionalmente

**Uso del PDF**:
-  Enviar por email
-  Imprimir para archivo físico
-  Presentaciones gerenciales
-  Respaldo documental

---

### ¿Cómo Usar los Reportes en Conjunto?

Los 4 reportes se complementan entre sí para un análisis completo:

**Análisis Semanal Completo**:
1. **Lista de servicios** → Ver rendimiento día por día
2. **Distribución por día de semana** → Identificar patrones semanales
3. **Cobertura vs proyección** → Evaluar precisión de estimaciones
4. **Asistencias por empresas** → Ver participación por compañía

**Ejemplo de flujo de análisis**:
```
Paso 1: Generar "Lista de servicios" del mes
        → Identificar días con asistencia inusual

Paso 2: Generar "Cobertura vs proyección"
        → Ver si las proyecciones fueron precisas

Paso 3: Generar "Distribución por día de semana"
        → Confirmar patrones semanales

Paso 4: Generar "Asistencias por empresas"
        → Verificar participación de cada compañía
```

**Tip**: Combinar todos los reportes del mismo período para obtener una visión 360° de la operación del comedor.

---

##  Estadísticas

![Módulo de Estadísticas](./docs/screenshots/manual_estadisticas.png)

**Módulo**: `Estadísticas`
**Usuario**: Administrador

### ¿Para Qué Sirven las Estadísticas?

Las estadísticas proporcionan una **visión general instantánea** del sistema sin necesidad de generar reportes. Muestran información clave en tiempo real sobre:
-  Actividad general del comedor
-  Desempeño por empresa
-  Tendencias de asistencia
-  Indicadores de rendimiento

---

### ¿Qué Estadísticas Muestra el Sistema?

#### 1.  Resumen General

**Indicadores Principales:**

- **Total de Empleados Registrados**
  - Cantidad total de empleados activos en el sistema
  - Indica el tamaño de la población potencial de comensales

- **Total de Empresas Activas**
  - Cantidad de empresas operando en el predio
  - Útil para análisis de diversidad corporativa

- **Total de Servicios Realizados**
  - Cantidad histórica de servicios completados
  - Indica la madurez operativa del sistema

- **Total de Asistencias Históricas**
  - Suma de todos los registros de almuerzos desde el inicio
  - Métrica clave de volumen operativo

---

#### 2.  Top 5 Empresas del Mes

**¿Qué muestra?**
- Ranking de las 5 empresas con mayor asistencia en el mes actual
- Por cada empresa:
  - Nombre
  - Total de asistencias del mes
  - Posición en el ranking (#1, #2, etc.)

**¿Para qué sirve?**
- Identificar empresas más activas
- Reconocer patrones de uso por compañía
- Análisis de participación corporativa
- Facturación prioritaria

**Ejemplo de uso**: Si la Empresa A tiene 500 asistencias y la Empresa B solo 50, puede indicar diferencias en cantidad de empleados, cultura de uso del comedor, o trabajo remoto.

---

#### 3.  Tendencia de Asistencias (Últimos 7 Días)

**¿Qué muestra?**
- Gráfico de barras o listado con asistencias diarias de la última semana
- Por cada día:
  - Fecha
  - Total de comensales registrados
  - Variación respecto al día anterior (si corresponde)

**¿Para qué sirve?**
- Visualizar tendencias recientes
- Identificar días con mayor/menor actividad
- Detectar anomalías o patrones inusuales
- Planificación de compras de corto plazo

**Patrones típicos**:
- **Aumento gradual**: Más empleados volviendo a la presencialidad
- **Caída brusca**: Feriado, evento corporativo, o problema operativo
- **Estabilidad**: Operación normal y predecible

---

#### 4.  Estadísticas del Mes Actual

**¿Qué muestra?**
- **Total de Servicios del Mes**: Cantidad de días operativos
- **Total de Asistencias del Mes**: Suma de todos los registros
- **Promedio Diario**: Asistencias totales ÷ servicios realizados
- **Proyección vs Real**: Comparativa de estimaciones

**¿Para qué sirve?**
- Evaluar rendimiento mensual
- Calcular métricas de gestión
- Preparar reportes gerenciales
- Análisis de capacidad

**Ejemplo práctico**: 
- 20 servicios realizados en el mes
- 1000 asistencias totales
- **Promedio diario = 50 comensales**
- Esta información ayuda a planificar compras y personal

---

### ¿Cuál es la Diferencia entre Estadísticas y Reportes?

| Característica | Estadísticas | Reportes |
|----------------|--------------|----------|
| **Propósito** | Vista general rápida | Análisis detallado |
| **Datos** | Información actual/reciente | Datos históricos configurables |
| **Interacción** | Solo visualización | Filtros y exportación |
| **Formato** | Pantalla (widgets, gráficos) | PDF exportable |
| **Período** | Fijo (mes actual, última semana) | Personalizable (desde - hasta) |
| **Uso** | Consulta rápida diaria | Análisis formal, presentaciones |

**Cuándo usar cada uno:**

- **Estadísticas**: 
  - Revisión rápida al inicio del día
  - Monitoreo casual de tendencias
  - Consulta de métricas clave

- **Reportes**: 
  - Análisis profundo de períodos específicos
  - Presentaciones a gerencia
  - Documentación formal
  - Facturación detallada

---

## Preguntas Frecuentes

### **P: ¿Qué hago si un empleado dice que no se pudo registrar?**
**R:** 
1. Verificar que haya un servicio activo
2. Intentar ingresar su credencial
3. Si no funciona, usar el método de registro manual
4. Verificar con el administrador el estado de su credencial

---

### **P: ¿Se puede cambiar la proyección después de iniciar el servicio?**
**R:** No, la proyección se establece al iniciar y no se puede modificar. Esto es intencional para mantener un registro histórico preciso de las estimaciones vs la realidad.

---

### **P: ¿Qué pasa si cierro el servicio por error?**
**R:** Una vez cerrado un servicio, no se puede reabrir. Se deberá iniciar un nuevo servicio para continuar registrando. Contactar al administrador si esto ocurre.

---

### **P: ¿Se puede registrar a alguien que no está en el sistema?**
**R:** No. Todos los empleados deben estar previamente cargados en el sistema. Contactar al administrador para dar de alta al nuevo empleado.

---

### **P: ¿El sistema funciona sin internet?**
**R:** Sí, el sistema funciona completamente sin conexión a internet. Solo necesita conexión a la base de datos local (que puede estar en la misma computadora o en la red local).

---

### **P: ¿Se pueden perder los datos si se va la luz?**
**R:** Los registros se guardan instantáneamente en la base de datos, por lo que no se pierden. Sin embargo, es recomendable:
- Usar un UPS (sistema de energía ininterrumpida)
- Que el técnico configure backups automáticos

---

### **P: ¿Se puede usar el sistema en varias computadoras?**
**R:** Sí, pero requiere configuración de red. Contactar al técnico en sistemas para:
- Configurar la base de datos centralizada
- Instalar el sistema en cada computadora
- Configurar las conexiones de red

---

### **P: ¿Cuánto demora registrar a una persona?**
**R:** 
- Con credencial (teclado): 3-5 segundos
- Sin credencial (manual): 10-15 segundos
- Con RFID (futuro): <1 segundo

---

### **P: ¿Los reportes se pueden editar?**
**R:** No, los reportes se generan automáticamente desde los datos reales del sistema y no son editables. Esto garantiza la integridad de la información.

---

## Solución de Problemas Comunes

### **Problema: El sistema no abre o se cierra solo**

**Posibles causas y soluciones:**

1. **Error de base de datos**
   - Verificar que SQL Server esté corriendo
   - Contactar al técnico en sistemas

2. **Archivos faltantes**
   - Reinstalar la aplicación
   - Verificar que todos los archivos estén presentes

3. **Permisos insuficientes**
   - Ejecutar como administrador
   - Contactar al técnico para configurar permisos

---

### **Problema: No aparecen empleados en la búsqueda**

**Soluciones:**

1. **Verificar filtros**
   - Asegurarse de no tener filtros activos
   - Limpiar la caja de búsqueda

2. **Verificar que haya empleados cargados**
   - Ir al módulo de empleados
   - Si está vacío, contactar al administrador

3. **Problema de conexión a BD**
   - Contactar al técnico en sistemas

---

### **Problema: No se puede iniciar un servicio**

**Posibles causas:**

1. **Ya hay un servicio activo**
   - Verificar si hay un servicio sin cerrar
   - Cerrar el servicio anterior primero

2. **Error de permisos**
   - Verificar que se tenga rol de administrador
   - Contactar al administrador del sistema

3. **Faltan datos obligatorios**
   - Completar todos los campos requeridos
   - Verificar que la proyección sea mayor a 0

---

### **Problema: El panel de cocina no se actualiza**

**Soluciones:**

1. **Refrescar la pantalla**
   - Salir y volver a entrar al módulo
   - Puede haber un problema temporal

2. **Verificar servicio activo**
   - Asegurarse de que haya un servicio iniciado
   - Verificar que sea el servicio del día actual

3. **Reiniciar la aplicación**
   - Cerrar completamente el sistema
   - Volver a abrir

---

### **Problema: No se genera el reporte PDF**

**Soluciones:**

1. **Verificar permisos de carpeta**
   - Elegir una carpeta donde se tenga permiso de escritura
   - Ejemplo: Escritorio o Documentos

2. **Verificar que haya datos**
   - Asegurarse de que el período seleccionado tenga registros
   - Probar con otra fecha

3. **Librerías faltantes**
   - Reinstalar la aplicación
   - Contactar al técnico

---

### **Problema: Mensaje "Credencial no encontrada" pero el empleado existe**

**Soluciones:**

1. **Verificar el ID**
   - Confirmar que el número sea correcto
   - Puede haber un error al dictarlo

2. **Verificar asignación**
   - Ir a módulo de empleados
   - Verificar que tenga credencial asignada

3. **Usar registro manual**
   - Como alternativa temporal
   - Buscar por nombre y registrar

---

##  Consejos para Usar Mejor el Sistema

###  Para Personal de Cocina

**Registro de Comensales:**
-  Aprender los atajos de teclado (Enter para confirmar)
-  Verificar visualmente la confirmación antes de atender al siguiente

**Manejo de Casos Especiales:**
-  Sin credencial: Usar registro manual sin dudar
-  Empleado nuevo: Derivar al administrador

**Uso del Panel en Tiempo Real:**
-  Mantener el panel visible durante todo el servicio
-  No es necesario actualizar manualmente (se actualiza solo)

**Comunicación:**
-  Si la demanda supera mucho la proyección, avisar inmediatamente
-  Compartir datos con el equipo de cocina

---

### Para Administradores

**Gestión de Empleados:**
-  Dar de alta empleados nuevos **antes** de su primer día
-  Actualizar credenciales perdidas el mismo día
-  Revisar empleados inactivos mensualmente

**Análisis de Datos:**
-  Generar reporte mensual para gerencia
-  Identificar días de pico para ajustar compras
-  Calcular costo por comensal con datos precisos

**Backups:**
-  Asegurarse de que el técnico configure backups automáticos
-  Solicitar backup manual antes de actualizaciones importantes

---

###  Seguridad y Buenas Prácticas

**Protección de Datos:**
-  No compartir acceso al módulo de administración
-  No dejar la computadora sin atender con sesión abierta
-  Registrar solo comensales reales (no registros ficticios)

**Integridad de Información:**
-  Verificar datos antes de guardar
-  No editar manualmente la base de datos (puede romper el sistema)
-  Documentar cualquier situación irregular

**Respaldos:**
-  Coordinar con IT backups automáticos diarios
-  Mantener respaldos de reportes importantes
-  Probar la restauración periódicamente

---

##  Soporte Técnico

### ¿Cuándo Contactar al Soporte?

**Situaciones que requieren soporte:**
-  El sistema no abre o se cierra inesperadamente
-  Errores de base de datos
-  Problemas de instalación o configuración
-  Se necesita capacitación adicional
-  Solicitud de nuevas funcionalidades
-  Migración de datos

**Situaciones que NO requieren soporte:**
-  Empleado olvidó credencial → Usar registro manual
-  Credencial no existe → Verificar con administrador
-  Duda sobre cómo usar un módulo → Consultar este manual

---

##  Mejoras Futuras del Sistema

### Fase 2: Integración RFID (Próximamente)

**¿Qué cambiará?**
-  En lugar de ingresar el ID por teclado, el empleado solo pasará su credencial por un lector
-  El registro será **automático e instantáneo** (<1 segundo)
-  No se necesitará que el empleado diga nada

**¿Qué se mantiene igual?**
-  Todas las funcionalidades actuales
-  Los mismos reportes y estadísticas
-  La misma interfaz

**¿Necesitaré capacitación nueva?**
- No, el sistema será aún más simple de usar

---


