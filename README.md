# Sistema de Control de Almuerzos (SCA)

Aplicación WinForms (C# .NET Framework 4.8.1) para gestionar y controlar el ingreso de comensales al comedor/quincho de un predio empresarial. Implementa una interfaz unificada (ventana única) con navegación lateral y un panel superior de control de servicio.

## Novedades recientes
- Actualización del diseño de `frmPrincipal` con panel superior enriquecido:
	- Selección de Lugar (Comedor/Quincho)
	- Fecha del servicio
	- Proyección prevista de comensales
	- Campo de invitados
	- Estado del servicio (Activo/Inactivo)
	- Duración del servicio con cronómetro
	- Progreso del servicio y estadísticas rápidas
- Actualización del script SQL para soportar proyección y duración del servicio:
	- Nuevas columnas en `Servicios`: Proyeccion, HoraInicio, HoraFin y DuracionMinutos (calculada)

## Estructura
- `SCA/app`: Capa de presentación (WinForms + ReaLTaiizor)
- `SCA/negocio`: Capa de negocio (servicios, reportes, CRUD)
- `SCA/dominio`: Entidades de dominio
- `Script_Sistema_Control_Almuerzos.sql`: Script de base de datos (SQL Server)

## Requisitos
- .NET Framework 4.8.1
- SQL Server
- Paquete UI: ReaLTaiizor (NuGet)

## Próximos pasos
- Mapear nuevas columnas (Proyeccion, HoraInicio, HoraFin, DuracionMinutos) en `Dominio.Servicio` y en `ServicioNegocio`
- Enlazar los controles nuevos del `frmPrincipal` con la lógica de negocio (iniciar/finalizar servicio, cronómetro y progreso)
- Añadir reportes que utilicen proyección para comparar vs. asistencia real