# 📖 Manual de Usuario - Sistema de Control de Almuerzos

## 🎯 ¿Qué es el Sistema de Control de Almuerzos?

El Sistema de Control de Almuerzos es una aplicación diseñada para gestionar de forma eficiente el registro de comensales en comedores corporativos. Con este sistema es posible:

- 📝 **Registrar comensales** de forma rápida mediante credenciales
- 👥 **Gestionar empleados** y sus credenciales
- 🏢 **Organizar por empresas** del predio
- 📊 **Ver estadísticas en tiempo real** del servicio
- 📈 **Generar reportes automáticos** para análisis
- 💼 **Administrar servicios** por jornada (comedor y quincho)

---

## 📋 Índice

1. [Tipos de Usuario](#-tipos-de-usuario)
2. [Inicio del Sistema](#-cómo-iniciar-el-sistema)
3. [Registro de Comensales](#-registro-de-comensales)
4. [Panel de Cocina](#-panel-de-cocina-visualización-en-tiempo-real)
5. [Gestión de Empleados](#-gestión-de-empleados)
6. [Gestión de Servicios](#-gestión-de-servicios)
7. [Reportes y Estadísticas](#-reportes-y-estadísticas)
8. [Preguntas Frecuentes](#-preguntas-frecuentes)
9. [Solución de Problemas](#-solución-de-problemas-comunes)
10. [Consejos de Uso](#-consejos-para-usar-mejor-el-sistema)

---

## 👥 Tipos de Usuario

###  Personal de Cocina
**¿Qué puede hacer?**
- ✅ **Registrar comensales** mediante ID de credencial
- ✅ **Realizar registro manual** (sin credencial)
- ✅ **Registrar invitados**
- ✅ Ver confirmaciones de registro
- ✅ Ver en tiempo real quién se registró
- ✅ Conocer el total de comensales actual
- ✅ Ver comparativa con la proyección
- ✅ Consultar desglose por empresa

**¿Cuándo lo usa?**
- Durante todo el horario de servicio del comedor
- Para registrar a los comensales que van llegando
- Para planificar porciones según la demanda real
- Para control de producción

**Nota**: El personal de cocina se encarga tanto del registro de comensales como de la visualización en tiempo real.

---

###  Administrador
**¿Qué puede hacer?**
- ✅ **Todo lo anterior, más:**
- ✅ Gestionar empleados y credenciales
- ✅ Gestionar empresas y lugares
- ✅ Generar reportes y estadísticas
- ✅ Configurar el sistema

---

## 📝 Registro de Comensales

**Módulo**: `Registro de Comensales`  
**Usuario**: Personal de Cocina

### ¿Cómo Registrar un Comensal? (Método Principal)

Este es el proceso más común y rápido:

#### Paso 1: Acceder al Módulo
1. Desde el menú principal, hacer clic en el boton 🏠 para acceder a la vista principal
2. Asegurarse de que haya un **servicio activo** (aparecerá indicado en pantalla)

#### Paso 2: Ingresar ID de la credencial en el Sistema
1. Escribir el ID en el campo de texto
2. Presionar **Enter** o hacer clic en **"Ingresar Registro"**

#### Paso 3: Confirmación
El sistema mostrará:
- ✅ **Nombre completo** del empleado
- ✅ **Empresa** a la que pertenece
- ✅ **Hora de registro**
- ✅ Mensaje de confirmación

---

### ¿Cómo Registrar sin Credencial? (Método Alternativo)

#### Paso 1: Seleccionar Registro Manual
1. En el menu principal, hacer clic en **"Registro Manual"**

#### Paso 2: Buscar al Empleado
1. Escribir el **nombre** o **apellido** del empleado
2. Los resultados aparecerán automáticamente mientras se escribe

#### Paso 3: Seleccionar de la Lista
1. Hacer clic en el empleado correcto de la lista
2. Verificar que sea la persona correcta (nombre + empresa)

#### Paso 4: Confirmar Registro
1. Hacer clic en **"Agregar"**
2. El sistema registrará al empleado

---

### ¿Cómo Registrar Invitados?

#### Método Simple
1. Hacer clic en el campo **Invitados**
2. Ingresar la **cantidad** de invitados previo al inicio del servicio

**Nota**: No se requieren datos personales de invitados, solo la cantidad total.

---

### ¿Qué Pasa si Hay un Error?

El sistema mostrará mensajes claros en caso de problema:

#### ❌ "Credencial no encontrada"
**Causa**: El ID ingresado no existe en el sistema  
**Solución**: 
- Verificar que el número sea correcto
- Usar el método de registro manual
- Contactar al administrador si el empleado es nuevo

#### ❌ "El empleado ya se registró en este servicio"
**Causa**: El empleado ya almorzó hoy  
**Solución**: 
- Explicar al empleado que ya está registrado
- Verificar en el panel de cocina si es necesario

#### ❌ "No hay servicio activo"
**Causa**: No se ha iniciado el servicio del día  
**Solución**: 
- Contactar al administrador
- El administrador debe iniciar el servicio del día

#### ❌ "Empleado inactivo"
**Causa**: El empleado fue dado de baja en el sistema  
**Solución**: 
- Contactar al administrador
- Verificar el estado del empleado

---

## 👨‍🍳 Panel de Cocina (Visualización en Tiempo Real)

**Módulo**: `Vista Principal` 
**Usuario**: Personal de Cocina

### ¿Para Qué Sirve?

Este panel muestra en tiempo real:
- 📊 Cuántos comensales se registraron hasta el momento
- 👥 Quiénes son (listado completo)
- 📈 Comparativa con la proyección del día
- 👫 Total de invitados

#### Actualización Automática
- ✅ Cada vez que alguien se registra, aparece **inmediatamente** en la lista
- ✅ Los contadores se actualizan **en tiempo real**
- ✅ No es necesario recargar o actualizar manualmente

---

## 👥 Gestión de Empleados

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
- ✅ Que el nuevo ID no esté en uso por otro empleado
- ✅ Que el formato sea correcto

---

### ¿Cómo Dar de Baja un Empleado?

**Situación**: El empleado ya no trabaja en el predio.

#### Pasos:
1. **Seleccionar el empleado** de la lista
2. Hacer clic en **"Eliminar"**
3. Confirmar la baja

**¿Qué pasa al dar de baja?**
- ❌ El empleado no podrá registrarse más en el comedor
- ✅ **Se mantiene su historial** (no se borra del sistema)
- ✅ Su credencial queda liberada para reasignar a otro empleado
- ✅ Aparece en reportes históricos

**Nota**: La baja es **lógica**, no se elimina físicamente de la base de datos.

---

## ⚙️ Gestión de Servicios

### ¿Qué es un Servicio?

Un **servicio** representa una jornada de comedor (un día de atención). Cada servicio tiene:
- 📍 **Lugar**: Comedor o Quincho
- 📅 **Fecha**: Día del servicio
- 📊 **Proyección**: Cantidad estimada de comensales
- 👥 **Invitados esperados**: Cantidad estimada de invitados
- ⏱️ **Estado**: Activo (en curso) o Finalizado (cerrado)

---

### ¿Cómo Iniciar el Servicio del Día?

**Cuándo hacerlo**: Al comienzo de cada jornada (antes de que lleguen comensales)

#### Paso 1: Configurar el Servicio
Completar los siguientes datos:

**Lugar** (Obligatorio)
- Seleccionar: **Comedor** o **Quincho**

**Proyección de Comensales** (Obligatorio)
- Cantidad estimada de personas que almorzarán
- Ejemplo: 50
- **¿Cómo calcularlo?**: Basarse en promedio histórico o reservas

**Total de Invitados Esperados** (Opcional)
- Cantidad estimada de invitados externos
- Ejemplo: 5
- Puede dejarse en 0 si no se esperan invitados

#### Paso 2: Iniciar
1. Hacer clic en **"Iniciar Servicio"**
2. El sistema creará el servicio con estado **Activo**
3. **Ahora el personal puede comenzar a registrar comensales** ✅

---

### ¿Cómo Cerrar el Servicio del Día?

**Cuándo hacerlo**: Al finalizar la jornada (cuando ya no llegarán más comensales)

### Finalizar Servicio
1. Hacer clic en **"Finalizar Servicio"** 
2. El sistema solicitará confirmación

#### Resumen Automático
El sistema generará automáticamente:
- ⏱️ **Duración total**: Tiempo desde inicio hasta cierre
- 👥 **Total de comensales**: Cantidad real registrada
- 📊 **Cobertura**: Porcentaje de proyección alcanzada
- 🏢 **Desglose por empresa**: Cantidad de cada compañía
- 👫 **Total de invitados**: Cantidad real de invitados

**Una vez cerrado**:
- ❌ No se pueden registrar más comensales en ese servicio
- ✅ El servicio queda disponible para reportes históricos
- ✅ Se puede iniciar un nuevo servicio (del día siguiente o siguiente turno)

---

### ¿Se Puede Tener Más de Un Servicio Activo?

**No**. El sistema solo permite **un servicio activo a la vez** por lugar.

**Razón**: Para evitar confusión sobre dónde se registran los comensales.

**Si se necesita abrir quincho mientras hay comedor activo**:
- Se puede tener un servicio activo en cada lugar simultáneamente
- Ejemplo: Comedor activo + Quincho activo al mismo tiempo ✅

---

## 📊 Reportes y Estadísticas

**Módulo**: `Reportes y Estadísticas`  
**Usuario**: Administrador

### ¿Para Qué Sirven los Reportes?

Los reportes permiten:
- 📈 Analizar asistencia histórica
- 💰 Planificar compras de insumos
- 📊 Identificar tendencias
- 🏢 Comparar asistencia por empresa
- 📋 Generar documentos oficiales

---

### Tipos de Reportes Disponibles

El sistema incluye 4 tipos de reportes que se generan seleccionando un rango de fechas (Desde - Hasta) y opcionalmente filtrando por lugar (Comedor/Quincho o Todos).

---

#### 1. 📋 Lista de Servicios

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

#### 2. 🏢 Asistencias por Empresas

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

#### 3. 📊 Cobertura vs Proyección

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

#### 4. 📅 Distribución por Día de Semana

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
- 📋 Encabezado con logo (si está configurado)
- 📅 Fecha y hora de generación
- 📊 Todas las estadísticas y datos
- 📈 Gráficos (si aplica)
- 🔢 Tablas formateadas profesionalmente

**Uso del PDF**:
- 📧 Enviar por email
- 🖨️ Imprimir para archivo físico
- 💼 Presentaciones gerenciales
- 📑 Respaldo documental

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

## ❓ Preguntas Frecuentes

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

## 🆘 Solución de Problemas Comunes

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

## 💡 Consejos para Usar Mejor el Sistema

### 👨‍� Para Personal de Cocina

**Registro de Comensales:**
- ⚡ Aprender los atajos de teclado (Enter para confirmar)
- 👀 Verificar visualmente la confirmación antes de atender al siguiente

**Manejo de Casos Especiales:**
- 🆔 Sin credencial: Usar registro manual sin dudar
- ❓ Empleado nuevo: Derivar al administrador

**Uso del Panel en Tiempo Real:**
- 📊 Mantener el panel visible durante todo el servicio
- 🔄 No es necesario actualizar manualmente (se actualiza solo)

**Comunicación:**
- 📞 Si la demanda supera mucho la proyección, avisar inmediatamente
- 💬 Compartir datos con el equipo de cocina

---

### 👨‍💼 Para Administradores

**Gestión de Empleados:**
- 🆕 Dar de alta empleados nuevos **antes** de su primer día
- 🔄 Actualizar credenciales perdidas el mismo día
- 📋 Revisar empleados inactivos mensualmente

**Análisis de Datos:**
- 📊 Generar reporte mensual para gerencia
- 📈 Identificar días de pico para ajustar compras
- 💰 Calcular costo por comensal con datos precisos

**Backups:**
- 💾 Asegurarse de que el técnico configure backups automáticos
- 📁 Solicitar backup manual antes de actualizaciones importantes

---

### 🔒 Seguridad y Buenas Prácticas

**Protección de Datos:**
- 🔐 No compartir acceso al módulo de administración
- 👀 No dejar la computadora sin atender con sesión abierta
- 📝 Registrar solo comensales reales (no registros ficticios)

**Integridad de Información:**
- ✅ Verificar datos antes de guardar
- 🚫 No editar manualmente la base de datos (puede romper el sistema)
- 📋 Documentar cualquier situación irregular

**Respaldos:**
- 💾 Coordinar con IT backups automáticos diarios
- 📁 Mantener respaldos de reportes importantes
- 🔄 Probar la restauración periódicamente

---

## 📞 Soporte Técnico

### ¿Cuándo Contactar al Soporte?

**Situaciones que requieren soporte:**
- ❌ El sistema no abre o se cierra inesperadamente
- ❌ Errores de base de datos
- ❌ Problemas de instalación o configuración
- ❌ Se necesita capacitación adicional
- ❌ Solicitud de nuevas funcionalidades
- ❌ Migración de datos

**Situaciones que NO requieren soporte:**
- ✅ Empleado olvidó credencial → Usar registro manual
- ✅ Credencial no existe → Verificar con administrador
- ✅ Duda sobre cómo usar un módulo → Consultar este manual

---

## 🚀 Mejoras Futuras del Sistema

### Fase 2: Integración RFID (Próximamente)

**¿Qué cambiará?**
- 🔄 En lugar de ingresar el ID por teclado, el empleado solo pasará su credencial por un lector
- ⚡ El registro será **automático e instantáneo** (<1 segundo)
- 🙌 No se necesitará que el empleado diga nada

**¿Qué se mantiene igual?**
- ✅ Todas las funcionalidades actuales
- ✅ Los mismos reportes y estadísticas
- ✅ La misma interfaz

**¿Necesitaré capacitación nueva?**
- No, el sistema será aún más simple de usar

---

*Manual de Usuario v1.0 - Sistema de Control de Almuerzos*  
*Desarrollado por Facundo Herrera - Tecnicatura Universitaria en Programación (UTN)*  
*Última actualización: Noviembre 2025*
