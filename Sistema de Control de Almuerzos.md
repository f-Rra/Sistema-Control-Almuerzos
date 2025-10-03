# Sistema de Control de Almuerzos 

## Introducción

Actualmente, el método basado en códigos QR y la app Mis Puntos presentan diversas dificultades: generan demoras y filas por la lentitud del escaneo, dependen de la conectividad de cada usuario, representan una barrera tecnológica en algunos casos y requieren si o si de una conexión a internet. 

Frente a esta situación, este proyecto propone la implementación de un sistema de control de almuerzos basado en el uso de las credenciales RFID. 

El Sistema de Control de Almuerzos permitirá:
- Acelerar el registro de comensales.
- Reducir las filas y tiempos de espera.
- Evitar problemas de conectividad y accesibilidad.
- Llevar un registro preciso y centralizado de todos los comensales.

## Arquitectura del Sistema

### Stack Tecnológico
- **Frontend**: Windows Forms (.NET Framework 4.8.1)
- **Backend**: Arquitectura en 3 capas (Presentación, Negocio, Dominio)
- **Base de Datos**: SQL Server con Stored Procedures
- **Lector RFID**: Compatible con credenciales corporativas existentes
- **UI Framework**: ReaLTaiizor para componentes modernos

### Componentes del Sistema
1. **Capa de Presentación**: Interfaz gráfica con UserControls modulares
2. **Capa de Negocio**: Lógica de validaciones y reglas de negocio
3. **Capa de Dominio**: Modelos y entidades del sistema
4. **Base de Datos**: Almacenamiento persistente con integridad referencial

### Estructura de Proyectos
- **app**: Capa de presentación (Forms y UserControls)
- **negocio**: Capa de negocio y acceso a datos
- **dominio**: Modelos y entidades del dominio

## Funcionalidades Principales

### Identificación y Credenciales

El sistema maneja la identificación de empleados a través de credenciales RFID, donde cada empleado pasa su tarjeta y el sistema automáticamente registra su asistencia. Para casos especiales, existe la funcionalidad de gestionar invitados de manera rápida ingresando únicamente la cantidad, sin necesidad de datos personales.

### Gestión de Servicios

El sistema opera bajo un modelo de servicios por jornada, donde cada lugar de almuerzo (comedor y quincho) funciona de manera independiente. Al comienzo de cada jornada, el sistema solicita la cantidad total de invitados y la proyeccion de comensales. El personal del lugar debe iniciar un nuevo servicio desde la aplicación, creando una sesión activa que guardara todos los registros de ese período. Durante el servicio, cada empleado que pasa su credencial queda automáticamente vinculado a esa sesión activa. Al finalizar la jornada, se genera un resumen completo de la actividad del día.

### Registro de Almuerzos

Cada registro de almuerzo guarda información completa incluyendo el empleado, su empresa, fecha y hora exacta, y el servicio al que pertenece. El sistema también contempla casos donde un empleado no dispone de su credencial, proporcionando una opción de registro manual que permite cargar la información directamente en la aplicación sin necesidad de la tarjeta física.

### Reportes

El sistema genera reportes automatizados que incluyen la cantidad total de comensales por día y por empresa, listado de servicios, cobertura vs proyeccion, asistencias por empresa y distribucion por dia de semana. Estos reportes permiten optimizar la logística y planificación de los servicios.

### Usabilidad

La interfaz de usuario está diseñada específicamente para el personal operativo del comedor y quincho, con flujos de trabajo simplificados que requieren pocos pasos para completar las tareas principales, facilitando su uso en entornos de trabajo dinámico.


## Modelo de Datos 

El modelo de datos está compuesto por las siguientes tablas principales: 

- **Empleados**: almacena la información de cada empleado (IdEmpleado, Nombre, Apellido, IdEmpresa, IdCredencial, Estado). 
- **Empresas**: contiene los datos de las empresas del predio (IdEmpresa, Nombre, Estado).
- **Lugares**: contiene los datos de los lugares disponibles para almorzar (IdLugar, Nombre, Descripcion, Estado).
- **Servicios**: representa cada jornada realizada en comedor o quincho (IdServicio, IdLugar, Fecha, Proyeccion, DuracionMinutos, TotalComensales, TotalInvitados). 
- **Registros**: guarda cada asistencia vinculada a un servicio (IdRegistro, IdEmpleado, IdEmpresa, IdServicio, Fecha, Hora, IdLugar).

### Relaciones entre Entidades
- Un **Empleado** pertenece a una **Empresa**
- Un **Servicio** se realiza en un **Lugar** específico
- Un **Registro** vincula un **Empleado** con un **Servicio**
- Múltiples **Registros** pueden existir por **Servicio**

## Seguridad y Validaciones

### Validaciones Implementadas
- ✅ **Validación de credenciales duplicadas**: El sistema detecta si un empleado ya fue registrado en el servicio actual, evitando dobles registros
- ✅ **Verificación de servicio activo**: No permite registros sin un servicio activo iniciado
- ✅ **Validación de estado de empleados**: Solo empleados con estado "Activo" pueden ser registrados
- ✅ **Confirmación antes de finalizar**: Solicita confirmación explícita antes de cerrar un servicio
- ✅ **Validación de fechas en reportes**: Impide seleccionar fechas futuras o rangos inválidos

### Integridad de Datos
- **Foreign Keys**: Todas las relaciones entre tablas están protegidas con claves foráneas
- **Constraints**: Validaciones a nivel de base de datos para campos críticos
- **Transacciones**: Operaciones atómicas para garantizar consistencia
- **Manejo de excepciones**: Sistema robusto de captura y presentación de errores con mensajes user-friendly
- **Preservación de stack trace**: Manejo correcto de excepciones sin pérdida de información de debugging

### Control de Acceso
- **Validación de estado**: Solo servicios activos pueden recibir registros
- **Restricción de módulos**: Reportes y Administración solo accesibles con servicio inactivo
- **Auditoría**: Cada registro mantiene timestamp exacto de hora y fecha

## Flujo de Trabajo Diario

### 1. Inicio del Servicio
1. Personal abre la aplicación
2. Selecciona el lugar (Comedor/Quincho)
3. Ingresa proyección de comensales
4. Ingresa cantidad de invitados estimados
5. Hace clic en "Iniciar Servicio"
6. Sistema activa cronómetro y habilita registro

### 2. Durante el Servicio
1. Empleado pasa su credencial RFID
2. Sistema valida automáticamente:
   - Verifica que el empleado esté activo
   - Detecta si ya fue registrado en el servicio
   - Confirma identidad y empresa
3. Registra instantáneamente con timestamp
4. Actualiza contador en tiempo real
5. Muestra barra de progreso vs proyección
6. Permite registro manual para casos sin credencial

### 3. Finalización del Servicio
1. Personal hace clic en "Finalizar Servicio"
2. Sistema solicita confirmación
3. Detiene cronómetro y calcula duración total
4. Guarda estadísticas finales (total comensales, invitados, duración)
5. Genera resumen del día
6. Habilita acceso a módulos de Reportes y Administración


## Beneficios del Sistema

### Mejoras Operativas
- 📉 **Reducción significativa de filas**: Procesamiento instantáneo elimina demoras en horarios pico
- 🔌 **0% dependencia de conectividad individual**: Funciona sin internet en dispositivos de empleados
- ✅ **100% precisión en conteo**: Eliminación de errores humanos y conteo manual
- ⏱️ **Registro en tiempo real**: Actualización instantánea de estadísticas durante el servicio
- 🎯 **Automatización completa**: Desde inicio hasta cierre de servicio

### Mejoras Administrativas
- 📊 **Reportes automáticos**: Generación instantánea de reportes diarios, semanales y mensuales
- 📈 **Análisis de tendencias**: Datos históricos para identificar patrones de asistencia
- 💰 **Mejor proyección para compras**: Datos precisos para optimizar compras de insumos
- 🎯 **Optimización de recursos**: Distribución eficiente según demanda real por lugar
- 📋 **Exportación a PDF**: Reportes profesionales listos para presentar
- 🏢 **Seguimiento por empresa**: Estadísticas detalladas de asistencia por compañía

### Experiencia del Usuario
- 👍 **Interfaz intuitiva**: Diseño simple sin necesidad de capacitación extensa
- 📱 **Sin app requerida**: No necesita instalar nada en el teléfono del empleado
- 🆘 **Registro manual disponible**: Opción de respaldo para casos sin credencial
- 🎨 **Interfaz moderna**: UI actualizada con componentes visuales atractivos
- ✨ **Feedback visual inmediato**: Confirmación instantánea de cada registro


## Roadmap de Desarrollo

### Versión 2.0 
**Mejoras de integración y análisis**

- [ ] **Módulo web ASP.NET** para pre-reservas
  - Portal donde empleados elijan lugar de almuerzo al inicio del día
  - Notificaciones por email de confirmación
  - Panel de administración web
  
- [ ] **Dashboard ejecutivo** con gráficos
  - Visualización de tendencias con charts
  - KPIs en tiempo real
  - Exportación de gráficos a PowerPoint
  
- [ ] **Integración con sistema de RRHH**
  - Sincronización automática de altas/bajas de empleados
  - Actualización de datos desde sistema corporativo
  - API REST para intercambio de datos

- [ ] **Sistema de notificaciones**
  - Alertas por email de servicios finalizados
  - Notificaciones de proyecciones vs real
  - Reportes automáticos diarios

### Versión 3.0 
**Expansión móvil y beneficios**

- [ ] **App móvil** para consultas
  - Consulta de historial personal
  - Notificaciones push
  - Menú del día

- [ ] **Encuestas de satisfacción**
  - Post-servicio automáticas
  - Calificación de comidas
  - Sugerencias y comentarios
  
- [ ] **Gestión de menú digital**
  - Publicación de menú del día
  - información nutricional
  - Opciones vegetarianas/veganas destacadas


## Conclusión

El sistema de control de almuerzos con credenciales RFID representa una solución práctica y eficiente para la gestión diaria en el comedor y el quincho del predio.
Su implementación permitirá agilizar el registro de comensales, eliminar la dependencia de conectividad, facilitar el uso a todos los empleados, llevar un control más preciso y generar reportes automáticos y confiables.


