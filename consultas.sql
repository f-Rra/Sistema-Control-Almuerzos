-- Consultas SQL - Sistema de Control de Almuerzos

-- Gestion de Lugares
CREATE OR ALTER PROCEDURE SP_ListarLugares
AS
BEGIN
    SELECT 
        IdLugar, 
        Nombre
    FROM Lugares 
    WHERE Estado = 1
    ORDER BY Nombre;
END
GO

CREATE OR ALTER PROCEDURE SP_ObtenerLugarPorNombre
    @Nombre NVARCHAR(50)
AS
BEGIN
    SELECT 
        IdLugar,
        Nombre,
        Estado
    FROM Lugares 
    WHERE Nombre = @Nombre AND Estado = 1;
END
GO

-- Gestion de Empleados
CREATE OR ALTER PROCEDURE SP_ListarEmpleados
AS
BEGIN
    SELECT 
        e.IdEmpleado, 
        e.Nombre, 
        e.Apellido, 
        e.IdCredencial, 
        emp.Nombre as Empresa, 
        emp.IdEmpresa
    FROM Empleados e
    INNER JOIN Empresas emp ON e.IdEmpresa = emp.IdEmpresa
    WHERE e.Estado = 1
    ORDER BY e.Nombre, e.Apellido;
END
GO

CREATE OR ALTER PROCEDURE SP_BuscarEmpleadoPorCredencial
    @Credencial NVARCHAR(50)
AS
BEGIN
    SELECT 
        e.IdEmpleado, 
        e.Nombre, 
        e.Apellido, 
        e.IdCredencial,
        emp.Nombre as Empresa, 
        emp.IdEmpresa
    FROM Empleados e
    INNER JOIN Empresas emp ON e.IdEmpresa = emp.IdEmpresa
    WHERE e.IdCredencial = @Credencial AND e.Estado = 1;
END
GO

CREATE OR ALTER PROCEDURE SP_BuscarEmpleadosPorNombre
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT 
        e.IdEmpleado, 
        e.Nombre, 
        e.Apellido, 
        e.IdCredencial,
        emp.Nombre as Empresa, 
        emp.IdEmpresa
    FROM Empleados e
    INNER JOIN Empresas emp ON e.IdEmpresa = emp.IdEmpresa
    WHERE (e.Nombre + ' ' + e.Apellido) LIKE '%' + @Nombre + '%'
      AND e.Estado = 1
    ORDER BY e.Nombre, e.Apellido;
END
GO

CREATE OR ALTER PROCEDURE SP_ListarEmpleadosPorEmpresa
    @IdEmpresa INT
AS
BEGIN
    SELECT 
        e.IdEmpleado, 
        e.Nombre, 
        e.Apellido, 
        e.IdCredencial
    FROM Empleados e
    WHERE e.IdEmpresa = @IdEmpresa AND e.Estado = 1
    ORDER BY e.Nombre, e.Apellido;
END
GO

CREATE OR ALTER PROCEDURE SP_EmpleadosSinAlmorzar
    @IdServicio INT
AS
BEGIN
    SELECT 
        e.IdEmpleado, 
        e.Nombre, 
        e.Apellido, 
        e.IdCredencial,
        emp.Nombre as Empresa, 
        emp.IdEmpresa
    FROM Empleados e
    INNER JOIN Empresas emp ON e.IdEmpresa = emp.IdEmpresa
    WHERE e.Estado = 1
      AND e.IdEmpleado NOT IN (
        SELECT IdEmpleado 
        FROM Registros 
        WHERE IdServicio = @IdServicio
      )
    ORDER BY e.Nombre, e.Apellido;
END
GO

-- Gestion de Servicios
CREATE OR ALTER PROCEDURE SP_ObtenerServicioActivo
    @IdLugar INT
AS
BEGIN
    SELECT 
        IdServicio, 
        IdLugar, 
        Fecha,
        Proyeccion,
        DuracionMinutos,
        TotalComensales, 
        TotalInvitados
    FROM Servicios
    WHERE IdLugar = @IdLugar 
      AND Fecha = CAST(GETDATE() AS DATE)
      AND DuracionMinutos IS NULL; -- Activo si aún no se estableció la duración final
END
GO

CREATE OR ALTER PROCEDURE SP_AltaServicio
    @IdLugar INT,
    @Proyeccion INT = NULL
AS
BEGIN
    INSERT INTO Servicios (IdLugar, Fecha, Proyeccion, DuracionMinutos, TotalComensales, TotalInvitados)
    VALUES (@IdLugar, CAST(GETDATE() AS DATE), @Proyeccion, NULL, 0, 0);
    
    SELECT SCOPE_IDENTITY() as IdServicio;
END
GO

CREATE OR ALTER PROCEDURE SP_FinalizarServicio
    @IdServicio INT,
    @TotalComensales INT,
    @TotalInvitados INT,
    @DuracionMinutos INT = NULL
AS
BEGIN
    UPDATE Servicios 
    SET TotalComensales = @TotalComensales,
        TotalInvitados = @TotalInvitados,
        DuracionMinutos = @DuracionMinutos
    WHERE IdServicio = @IdServicio;
END
GO

CREATE OR ALTER PROCEDURE SP_ListarServiciosPorFecha
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SELECT 
        s.IdServicio, 
        s.Fecha, 
        s.Proyeccion,
        s.DuracionMinutos,
        s.TotalComensales, 
        s.TotalInvitados,
        l.Nombre as Lugar,
        (s.TotalComensales + s.TotalInvitados) as Total
    FROM Servicios s
    INNER JOIN Lugares l ON s.IdLugar = l.IdLugar
    WHERE s.Fecha BETWEEN @FechaDesde AND @FechaHasta
    ORDER BY s.Fecha DESC, l.Nombre;
END
GO

CREATE OR ALTER PROCEDURE SP_ListarServiciosPorLugar
    @IdLugar INT,
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SELECT 
        s.IdServicio, 
        s.Fecha, 
        s.Proyeccion,
        s.DuracionMinutos,
        s.TotalComensales, 
        s.TotalInvitados,
        (s.TotalComensales + s.TotalInvitados) as Total
    FROM Servicios s
    WHERE s.IdLugar = @IdLugar
      AND s.Fecha BETWEEN @FechaDesde AND @FechaHasta
    ORDER BY s.Fecha DESC;
END
GO

-- Gestion de Registros
CREATE OR ALTER PROCEDURE SP_RegistrarEmpleado
    @IdEmpleado INT,
    @IdEmpresa INT,
    @IdServicio INT,
    @IdLugar INT
AS
BEGIN
    INSERT INTO Registros (IdEmpleado, IdEmpresa, IdServicio, IdLugar, Fecha, Hora)
    VALUES (@IdEmpleado, @IdEmpresa, @IdServicio, @IdLugar, 
            CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME));
END
GO

CREATE OR ALTER PROCEDURE SP_ListarRegistrosPorServicio
    @IdServicio INT
AS
BEGIN
    SELECT 
        r.IdRegistro, 
        r.Hora, 
        r.Fecha,
        e.Nombre + ' ' + e.Apellido as Empleado,
        emp.Nombre as Empresa
    FROM Registros r
    INNER JOIN Empleados e ON r.IdEmpleado = e.IdEmpleado
    INNER JOIN Empresas emp ON r.IdEmpresa = emp.IdEmpresa
    WHERE r.IdServicio = @IdServicio
    ORDER BY r.Hora;
END
GO

CREATE OR ALTER PROCEDURE SP_VerificarEmpleadoRegistrado
    @IdEmpleado INT,
    @IdServicio INT
AS
BEGIN
    SELECT COUNT(*) as Existe
    FROM Registros
    WHERE IdEmpleado = @IdEmpleado AND IdServicio = @IdServicio;
END
GO

CREATE OR ALTER PROCEDURE SP_ContarRegistrosPorServicio
    @IdServicio INT
AS
BEGIN
    SELECT COUNT(*) as TotalRegistros
    FROM Registros
    WHERE IdServicio = @IdServicio;
END
GO

-- Reportes y Estadisticas
CREATE OR ALTER PROCEDURE SP_EstadisticasServicioActivo
    @IdServicio INT
AS
BEGIN
    SELECT 
        COUNT(r.IdRegistro) as TotalEmpleados,
        ISNULL(s.TotalInvitados, 0) as TotalInvitados,
        COUNT(r.IdRegistro) + ISNULL(s.TotalInvitados, 0) as TotalGeneral
    FROM Servicios s
    LEFT JOIN Registros r ON r.IdServicio = s.IdServicio
    WHERE s.IdServicio = @IdServicio
    GROUP BY ISNULL(s.TotalInvitados, 0);
END
GO

CREATE OR ALTER PROCEDURE SP_RegistrosPorEmpresa
    @IdServicio INT
AS
BEGIN
    SELECT 
        emp.Nombre as Empresa, 
        COUNT(*) as Cantidad
    FROM Registros r
    INNER JOIN Empresas emp ON r.IdEmpresa = emp.IdEmpresa
    WHERE r.IdServicio = @IdServicio
    GROUP BY emp.Nombre, emp.IdEmpresa
    ORDER BY Cantidad DESC;
END
GO

CREATE OR ALTER PROCEDURE SP_PicosConcurrencia
    @IdServicio INT
AS
BEGIN
    SELECT 
        DATEPART(HOUR, r.Hora) as Hora,
        COUNT(*) as Cantidad
    FROM Registros r
    WHERE r.IdServicio = @IdServicio
    GROUP BY DATEPART(HOUR, r.Hora)
    ORDER BY Hora;
END
GO

CREATE OR ALTER PROCEDURE SP_ResumenDiarioPorLugar
    @Fecha DATE
AS
BEGIN
    SELECT 
        s.Fecha,
        l.Nombre as Lugar,
        s.TotalComensales,
        s.TotalInvitados,
        (s.TotalComensales + s.TotalInvitados) as Total
    FROM Servicios s
    INNER JOIN Lugares l ON s.IdLugar = l.IdLugar
    WHERE s.Fecha = @Fecha
    ORDER BY l.Nombre;
END
GO

CREATE OR ALTER PROCEDURE SP_TopEmpresasAsistencia
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SELECT TOP 5
        emp.Nombre as Empresa,
        COUNT(*) as TotalAsistencias
    FROM Registros r
    INNER JOIN Empresas emp ON r.IdEmpresa = emp.IdEmpresa
    WHERE r.Fecha BETWEEN @FechaDesde AND @FechaHasta
    GROUP BY emp.Nombre, emp.IdEmpresa
    ORDER BY TotalAsistencias DESC;
END
GO

CREATE OR ALTER PROCEDURE SP_PromedioDiarioAsistencia
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SELECT 
        AVG(CAST(s.TotalComensales + s.TotalInvitados AS FLOAT)) as PromedioDiario
    FROM Servicios s
    WHERE s.Fecha BETWEEN @FechaDesde AND @FechaHasta;
END
GO

-- Gestion de Empresas
CREATE OR ALTER PROCEDURE SP_ListarEmpresas
AS
BEGIN
    SELECT IdEmpresa, Nombre
    FROM Empresas
    WHERE Estado = 1
    ORDER BY Nombre;
END
GO

CREATE OR ALTER PROCEDURE SP_EmpleadosPorEmpresa
    @IdEmpresa INT
AS
BEGIN
    SELECT 
        e.IdEmpleado, 
        e.Nombre, 
        e.Apellido, 
        e.IdCredencial
    FROM Empleados e
    WHERE e.IdEmpresa = @IdEmpresa AND e.Estado = 1
    ORDER BY e.Nombre, e.Apellido;
END
GO

-- Consultas de Mantenimiento
CREATE OR ALTER PROCEDURE SP_VerificarIntegridadDatos
AS
BEGIN
    -- Empleados sin empresa
    SELECT IdEmpleado, Nombre, Apellido
    FROM Empleados
    WHERE IdEmpresa IS NULL OR IdEmpresa NOT IN (SELECT IdEmpresa FROM Empresas);
    
    -- Registros sin empleado valido
    SELECT r.IdRegistro, r.IdEmpleado
    FROM Registros r
    LEFT JOIN Empleados e ON r.IdEmpleado = e.IdEmpleado
    WHERE e.IdEmpleado IS NULL;
END
GO

CREATE OR ALTER PROCEDURE SP_LimpiarDatosAntiguos
    @Anios INT = 1
AS
BEGIN
    -- Eliminar registros de mas de X anios
    DELETE FROM Registros 
    WHERE Fecha < DATEADD(YEAR, -@Anios, GETDATE());
    
    -- Eliminar servicios de mas de X anios
    DELETE FROM Servicios 
    WHERE Fecha < DATEADD(YEAR, -@Anios, GETDATE());
END
GO

CREATE OR ALTER PROCEDURE SP_BackupDatos
    @FechaBackup NVARCHAR(8)
AS
BEGIN
    -- Crear tabla de backup de empleados
    EXEC('SELECT * INTO Empleados_Backup_' + @FechaBackup + ' FROM Empleados');
    
    -- Crear tabla de backup de registros
    EXEC('SELECT * INTO Registros_Backup_' + @FechaBackup + ' FROM Registros WHERE Fecha >= DATEADD(MONTH, -1, GETDATE())');
END
GO

-- Vistas Utiles
CREATE OR ALTER VIEW vw_EmpleadosConEmpresa AS
SELECT 
    e.IdEmpleado,
    e.Nombre,
    e.Apellido,
    e.IdCredencial,
    emp.Nombre as Empresa,
    emp.IdEmpresa
FROM Empleados e
INNER JOIN Empresas emp ON e.IdEmpresa = emp.IdEmpresa
WHERE e.Estado = 1;
GO

CREATE OR ALTER VIEW vw_ServiciosCompletos AS
SELECT 
    s.IdServicio,
    s.Fecha,
    s.TotalComensales,
    s.TotalInvitados,
    l.Nombre as Lugar,
    (s.TotalComensales + s.TotalInvitados) as Total
FROM Servicios s
INNER JOIN Lugares l ON s.IdLugar = l.IdLugar;
GO

CREATE OR ALTER VIEW vw_RegistrosDetallados AS
SELECT 
    r.IdRegistro,
    r.Hora,
    r.Fecha,
    e.Nombre + ' ' + e.Apellido as Empleado,
    emp.Nombre as Empresa,
    l.Nombre as Lugar
FROM Registros r
INNER JOIN Empleados e ON r.IdEmpleado = e.IdEmpleado
INNER JOIN Empresas emp ON r.IdEmpresa = emp.IdEmpresa
INNER JOIN Lugares l ON r.IdLugar = l.IdLugar;
GO

-- Triggers
CREATE OR ALTER TRIGGER TR_ActualizarEstadisticas
ON Registros
AFTER INSERT
AS
BEGIN
    -- Aqui se pueden agregar logicas adicionales
    -- como actualizar contadores en tiempo real
    SET NOCOUNT ON;
END
GO

CREATE OR ALTER TRIGGER TR_ValidarRegistroUnico
ON Registros
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (
        SELECT 1 FROM inserted i
        INNER JOIN Registros r ON i.IdEmpleado = r.IdEmpleado 
                              AND i.IdServicio = r.IdServicio
    )
    BEGIN
        INSERT INTO Registros (IdEmpleado, IdEmpresa, IdServicio, IdLugar, Fecha, Hora)
        SELECT IdEmpleado, IdEmpresa, IdServicio, IdLugar, Fecha, Hora
        FROM inserted;
    END
    ELSE
    BEGIN
        RAISERROR('El empleado ya está registrado en este servicio', 16, 1);
    END
END
GO
