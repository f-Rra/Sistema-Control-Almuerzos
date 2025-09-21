# Sistema de Control de Almuerzos - Documentación Completa

## Introducción

Actualmente, el método basado en códigos QR y la app Mis Puntos presentan diversas dificultades: generan demoras y filas por la lentitud del escaneo, dependen de la conectividad de cada usuario, representan una barrera tecnológica en algunos casos y requieren si o si de una conexión a internet. 

Frente a esta situación, este proyecto propone la implementación de un sistema de control de almuerzos basado en el uso de las credenciales RFID. 

El Sistema de Control de Almuerzos permitirá:
- Acelerar el registro de comensales.
- Reducir las filas y tiempos de espera.
- Evitar problemas de conectividad y accesibilidad.
- Llevar un registro preciso y centralizado de todos los comensales.

## Funcionalidades Principales

### Identificación y Credenciales

El sistema maneja la identificación de empleados a través de credenciales RFID, donde cada empleado pasa su tarjeta y el sistema automáticamente registra su asistencia. Para casos especiales, existe la funcionalidad de gestionar invitados de manera rápida ingresando únicamente la cantidad, sin necesidad de datos personales.

### Gestión de Servicios

El sistema opera bajo un modelo de servicios por jornada, donde cada lugar de almuerzo (comedor y quincho) funciona de manera independiente. Al comienzo de cada jornada, el personal del lugar debe iniciar un nuevo servicio desde la aplicación, creando una sesión activa que guardara todos los registros de ese período. Durante el servicio, cada empleado que pasa su credencial queda automáticamente vinculado a esa sesión activa. Al finalizar la jornada, el sistema solicita la cantidad total de invitados para completar el registro y cierra la sesión, generando un resumen completo de la actividad del día.

### Registro de Almuerzos

Cada registro de almuerzo guarda información completa incluyendo el empleado, su empresa, fecha y hora exacta, y el servicio al que pertenece. El sistema también contempla casos donde un empleado no dispone de su credencial, proporcionando una opción de registro manual que permite cargar la información directamente en la aplicación sin necesidad de la tarjeta física.

### Reportes

El sistema genera reportes automatizados que incluyen la cantidad total de comensales por día, por empresa, y análisis de picos de concurrencia que muestran la distribución horaria de asistencia. Estos reportes permiten optimizar la logística y planificación de los servicios.

### Casos Especiales

El sistema está diseñado para manejar situaciones especiales como la gestión de invitados que se registran únicamente por cantidad sin datos personales, el alta de nuevos empleados desde el módulo administrativo, la baja de empleados que dejan la empresa, y casos donde un empleado olvida su credencial y requiere registro manual.

### Aspectos Técnicos

La infraestructura se basa en lectores RFID USB conectados directamente a las computadoras del comedor y quincho, proporcionando una solución robusta y confiable. La base de datos se implementa en SQL Server dentro de un contenedor Docker, facilitando el despliegue y mantenimiento, con capacidades de respaldo en la nube para garantizar la seguridad de los datos.

### Seguridad y Control

El sistema implementa un modelo de seguridad simplificado basado en lugares de acceso diferenciados para comedor, quincho y administrador. La autenticación se realiza mediante selección de lugar en un ComboBox para comedor y quincho (acceso directo sin contraseña), y contraseña hardcodeada en código para el administrador, garantizando que solo personal autorizado pueda acceder a las funcionalidades correspondientes a su rol.

### Usabilidad

La interfaz de usuario está diseñada específicamente para el personal operativo del comedor y quincho, con flujos de trabajo simplificados que requieren pocos pasos para completar las tareas principales, facilitando su uso en entornos de trabajo dinámico.

## Modelo de Datos 

El modelo de datos está compuesto por las siguientes tablas principales: 

- **Empleados**: almacena la información de cada empleado (IdEmpleado, Nombre, Apellido, IdEmpresa, IdCredencial, Estado). 
- **Empresas**: contiene los datos de las empresas del predio (IdEmpresa, Nombre, Estado).
- **Lugares**: contiene los datos de los lugares disponibles para almorzar (IdLugar, Nombre, Descripcion, Estado).
- **Servicios**: representa cada jornada realizada en comedor o quincho (IdServicio, IdLugar, Fecha, Proyeccion, DuracionMinutos, TotalComensales, TotalInvitados). 
- **Registros**: guarda cada asistencia vinculada a un servicio (IdRegistro, IdEmpleado, IdEmpresa, IdServicio, Fecha, Hora, IdLugar).

**Nota**: La tabla Usuarios fue eliminada del diseño final, simplificando la autenticación mediante selección directa de lugares.

## Aplicación WinForm

### Arquitectura de la Aplicación

La aplicación de escritorio está desarrollada en C# con Windows Forms (.NET Framework 4.8.1) utilizando ReaLTaiizor para el diseño Material Design y se compone de los siguientes módulos principales:

#### 1. Interfaz Unificada (Single Window)
- **Funcionalidad**: Aplicación integrada sin ventanas separadas
- **Características**:
  - Panel superior con controles de operación del servicio:
    - ComboBox de selección de lugar (Comedor/Quincho)
    - Campo de Fecha del servicio
    - Campo de Proyección prevista de comensales
    - Campo de Invitados (cantidad)
    - Botón Iniciar/Finalizar servicio
    - Estado del servicio visible (Activo/Inactivo)
    - Cronómetro de duración del servicio (solo UI)
    - Indicadores de Progreso y Estadísticas rápidas
  - Acceso directo para Comedor y Quincho (sin contraseña)
  - Campo de contraseña visible solo para Administrador
  - Validación de contraseña hardcodeada ("admin123") para administrador
  - Panel lateral para navegación entre módulos

#### 2. User Control Vista Principal (ucVistaPrincipal)
- **Funcionalidad**: User Control principal integrado en el área de contenido
- **Características**:
  - GridView de registros en tiempo real del servicio activo
  - Panel de estadísticas en tiempo real (empleados, invitados, total)
  - Actualización automática cada 2 segundos durante servicio activo
  - Interfaz limpia sin elementos de navegación (están en panel superior/lateral)
  - Implementado como UserControl para mejor rendimiento y reutilización
- **Comportamiento Dinámico**:
  - **Sin Servicio Activo**: GridView vacío, estadísticas en cero, mensaje informativo
  - **Con Servicio Activo**: GridView con registros actualizándose, estadísticas dinámicas

#### 3. User Control de Registro Manual (ucRegistroManual)
- **Funcionalidad**: Registro manual de empleados sin credencial RFID
- **Características**:
  - User Control independiente que se carga en panel contenido
  - GridView con lista de empleados que aún no han almorzado
  - Filtros de búsqueda por nombre, empresa o credencial
  - Selección directa del empleado desde el GridView
  - Registro inmediato en el servicio activo
  - Comunicación con FormPrincipal mediante eventos
  - Mejor rendimiento al no crear ventanas adicionales

#### 4. User Control de Reportes (ucReportes)
- **Funcionalidad**: Generación y visualización de reportes
- **Características**:
  - User Control independiente que se carga en panel contenido
  - Filtros de fecha (desde/hasta) y lugar
  - GridView con servicios anteriores
  - Estadísticas por empresa y distribución horaria
  - Exportación a PDF para mejor legibilidad
  - Botones para ver detalles de servicios específicos
  - Interfaz Material Design consistente

#### 5. User Control Administrador (ucAdministrador)
- **Funcionalidad**: Gestión completa del sistema
- **Características**:
  - User Control independiente que se carga en panel contenido
  - Acceso restringido solo para usuarios administrador
  - Gestión de empleados (CRUD completo)
  - Gestión de empresas (CRUD completo)
  - Asignación de credenciales RFID
  - Panel de estadísticas del sistema
  - Funciones de respaldo y configuración
  - Controles Material Design para mejor experiencia de usuario



### Flujo de la Aplicación


#### 1. Inicio de la Aplicación
- La aplicación inicia directamente con FormPrincipal (interfaz unificada)
- Panel superior muestra ComboBox de lugar (Comedor, Quincho, Administrador)
- Si selecciona Administrador, aparece campo de contraseña
- Para Comedor y Quincho: acceso directo sin contraseña
- Para Administrador: validación de contraseña hardcodeada en código
- No hay formulario de login separado

#### 2. FormPrincipal - Interfaz Unificada (MaterialForm)
- **Panel Superior**: Información del lugar seleccionado y estado del servicio
- **Panel Lateral**: Botones de navegación Material Design (Principal, Reg.Manual, Reportes, Admin)
- **Área de Contenido**: Muestra vista principal o User Controls integrados
- **Comportamiento Dinámico**:
  - **Sin Servicio Activo**: Botón "Iniciar Servicio" visible, "Finalizar Servicio" oculto, "Registrar Manualmente" deshabilitado, cronómetro en 00:00:00
  - **Con Servicio Activo**: Botón "Finalizar Servicio" visible, "Iniciar Servicio" oculto, "Registrar Manualmente" habilitado, cronómetro funcionando
- **Cronómetro**: Se inicia automáticamente al activar el servicio, muestra formato HH:MM:SS, siempre visible en panel superior
- **Navegación**: Los botones del panel lateral cargan User Controls en el área de contenido
- **Tema Material**: Utiliza ReaLTaiizor para interfaz moderna y consistente

#### 3. Navegación a Registro Manual
- Click en botón "Reg.Manual" del panel lateral
- Validación: solo disponible si hay servicio activo
- ucRegistroManual se carga en área de contenido
- Muestra GridView con empleados que aún no han almorzado
- Incluye filtros de búsqueda para encontrar empleados rápidamente
- Al registrar, se actualiza automáticamente la vista principal mediante eventos
- Panel superior mantiene cronómetro y estado del servicio visible
- Transición instantánea sin parpadeo gracias a User Controls

#### 4. Navegación a Otros Módulos
- **Reportes**: Click en botón "Reportes" carga ucReportes en área de contenido
- **Admin**: Click en botón "Admin" valida permisos y carga ucAdministrador
- **Principal**: Click en botón "Principal" vuelve a ucVistaPrincipal
- Todos los User Controls se integran perfectamente, manteniendo panel superior visible
- Mejor rendimiento y experiencia de usuario con Material Design

#### 5. Finalización de Servicio
- Botón "Finalizar Servicio" disponible desde cualquier vista
- Se solicita la cantidad de invitados
- Se actualiza la columna TotalInvitados en la tabla Servicios
- Se calcula la duración con el cronómetro en backend y se persiste en `DuracionMinutos`
- Se cierra el servicio y se vuelve al estado inactivo
- ComboBox se habilita nuevamente para seleccionar otro lugar

#### 6. Cambio de Lugar
- ComboBox habilitado solo cuando no hay servicio activo
- Permite cambiar entre Comedor, Quincho y Administrador
- Al seleccionar Administrador, aparece campo de contraseña
- Cambio de lugar resetea la interfaz al estado inicial


## Ventajas de la Arquitectura con User Controls y ReaLTaiizor

### **Beneficios Técnicos:**
- **Mejor Rendimiento**: User Controls consumen menos memoria que formularios separados
- **Experiencia Fluida**: Transiciones instantáneas sin parpadeo entre módulos
- **Mantenimiento Simplificado**: Código más organizado y modular
- **Reutilización**: Controles que se pueden usar en múltiples contextos
- **Material Design**: Interfaz moderna y consistente con ReaLTaiizor

### **Beneficios de Usuario:**
- **Interfaz Moderna**: Diseño Material Design profesional y atractivo
- **Navegación Intuitiva**: Transiciones suaves entre módulos
- **Contexto Siempre Visible**: Estado del servicio y cronómetro siempre presentes
- **Menor Complejidad**: Una sola ventana principal sin ventanas emergentes

## Conclusión

El sistema de control de almuerzos con credenciales RFID representa una solución práctica y eficiente para la gestión diaria en el comedor y el quincho del predio.

Su implementación con User Controls y ReaLTaiizor permitirá agilizar el registro de comensales, eliminar la dependencia de conectividad móvil, facilitar el uso a todos los empleados, llevar un control más preciso, generar reportes automáticos y confiables, y proporcionar una experiencia de usuario moderna y profesional.

Asimismo, se deja planteada la posibilidad de futuras mejoras, como:
- **Módulo ASP.NET**: para que los empleados elijan el lugar de almuerzo al inicio del día
- **Sistema de puntos**: similar al utilizado actualmente
- **Temas personalizables**: Aprovechando las capacidades de ReaLTaiizor

## Anexo: Cambios recientes

- UI: `frmPrincipal` actualizado con campos de Fecha, Proyección, Invitados, Estado, Cronómetro, Progreso y Estadísticas rápidas en el panel superior.
- BD: `Servicios` incorpora `Proyeccion INT` y `DuracionMinutos INT`. No se almacenan `HoraInicio/HoraFin`; la duración se calcula por cronómetro y se persiste solo el total en minutos.

