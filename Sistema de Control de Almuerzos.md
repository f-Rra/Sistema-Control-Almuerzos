# Sistema de Control de Almuerzos 

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

## Conclusión

El sistema de control de almuerzos con credenciales RFID representa una solución práctica y eficiente para la gestión diaria en el comedor y el quincho del predio.
Su implementación permitirá agilizar el registro de comensales, eliminar la dependencia de conectividad, facilitar el uso a todos los empleados, llevar un control más preciso y generar reportes automáticos y confiables.

Asimismo, se deja planteada la posibilidad de futuras mejoras, como:
- **Módulo ASP.NET**: para que los empleados elijan el lugar de almuerzo al inicio del día
- **Sistema de puntos**: similar al utilizado actualmente

