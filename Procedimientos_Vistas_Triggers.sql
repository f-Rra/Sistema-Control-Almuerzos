
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
        e.NombreEmpresa as Empresa, 
        e.IdEmpresa,
        e.NombreCompleto
    FROM vw_EmpleadosSinAlmorzarBase e
    WHERE e.IdEmpleado NOT IN (
        SELECT IdEmpleado 
        FROM Registros 
        WHERE IdServicio = @IdServicio
    )
    ORDER BY e.Nombre, e.Apellido;
END
GO

CREATE OR ALTER PROCEDURE SP_FiltrarEmpleadosSinAlmorzar
    @IdServicio INT,
    @IdEmpresa INT = NULL,        
    @Nombre NVARCHAR(100) = NULL  
AS
BEGIN
    SELECT 
        e.IdEmpleado, 
        e.Nombre, 
        e.Apellido, 
        e.IdCredencial,
        e.NombreEmpresa as Empresa, 
        e.IdEmpresa,
        e.NombreCompleto
    FROM vw_EmpleadosSinAlmorzarBase e
    WHERE e.IdEmpleado NOT IN (
        SELECT IdEmpleado 
        FROM Registros 
        WHERE IdServicio = @IdServicio
    )
    AND (@IdEmpresa IS NULL OR e.IdEmpresa = @IdEmpresa)
    AND (@Nombre IS NULL OR e.NombreCompleto LIKE '%' + @Nombre + '%')
    ORDER BY e.Nombre, e.Apellido;
END
GO

CREATE OR ALTER PROCEDURE SP_EmpleadosSinAlmorzarPorEmpresa
    @IdServicio INT,
    @IdEmpresa INT
AS
BEGIN
    EXEC SP_FiltrarEmpleadosSinAlmorzar @IdServicio, @IdEmpresa, NULL;
END
GO

CREATE OR ALTER PROCEDURE SP_EmpleadosSinAlmorzarPorNombre
    @IdServicio INT,
    @Nombre NVARCHAR(100)
AS
BEGIN
    EXEC SP_FiltrarEmpleadosSinAlmorzar @IdServicio, NULL, @Nombre;
END
GO

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
      AND DuracionMinutos IS NULL; 
END
GO

CREATE OR ALTER PROCEDURE SP_ObtenerUltimoServicio
AS
BEGIN
    SELECT TOP 1
        s.IdServicio, 
        s.IdLugar, 
        l.Nombre as NombreLugar,
        s.Fecha,
        s.Proyeccion,
        s.DuracionMinutos,
        s.TotalComensales, 
        s.TotalInvitados
    FROM Servicios s
    INNER JOIN Lugares l ON s.IdLugar = l.IdLugar
    WHERE s.DuracionMinutos IS NOT NULL 
    ORDER BY s.Fecha DESC, s.IdServicio DESC;
END
GO

CREATE OR ALTER PROCEDURE SP_AltaServicio
    @IdLugar INT,
    @Proyeccion INT = NULL
AS
BEGIN
    INSERT INTO Servicios (IdLugar, Fecha, Proyeccion, DuracionMinutos, TotalComensales, TotalInvitados)
    VALUES (@IdLugar, CAST(GETDATE() AS DATE), @Proyeccion, NULL, 0, 0);
    
    SELECT CAST(SCOPE_IDENTITY() AS INT) as IdServicio;
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

CREATE OR ALTER PROCEDURE SP_RegistrarEmpleado
    @IdEmpleado INT,
    @IdEmpresa INT,
    @IdServicio INT,
    @IdLugar INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Registros WHERE IdEmpleado = @IdEmpleado AND IdServicio = @IdServicio)
    BEGIN
        INSERT INTO Registros (IdEmpleado, IdEmpresa, IdServicio, IdLugar, Fecha, Hora)
        VALUES (@IdEmpleado, @IdEmpresa, @IdServicio, @IdLugar, 
                CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME));
    END
    ELSE
    BEGIN
        RETURN;
    END
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
        emp.Nombre as Empresa,
        l.Nombre as Lugar
    FROM Registros r
    INNER JOIN Empleados e ON r.IdEmpleado = e.IdEmpleado
    INNER JOIN Empresas emp ON r.IdEmpresa = emp.IdEmpresa
    INNER JOIN Lugares l ON r.IdLugar = l.IdLugar
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

CREATE OR ALTER PROCEDURE SP_ListarServiciosRango
    @FechaDesde DATE,
    @FechaHasta DATE,
    @IdLugar INT = NULL
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
      AND (@IdLugar IS NULL OR s.IdLugar = @IdLugar)
    ORDER BY s.Fecha DESC, s.IdServicio DESC;
END
GO

CREATE OR ALTER PROCEDURE SP_AsistenciasPorEmpresas
    @FechaDesde DATE,
    @FechaHasta DATE,
    @IdLugar INT = NULL
AS
BEGIN
    SELECT 
        emp.Nombre as Empresa,
        COUNT(*) as TotalAsistencias
    FROM Registros r
    INNER JOIN Empresas emp ON r.IdEmpresa = emp.IdEmpresa
    WHERE r.Fecha BETWEEN @FechaDesde AND @FechaHasta
      AND (@IdLugar IS NULL OR r.IdLugar = @IdLugar)
    GROUP BY emp.Nombre, emp.IdEmpresa
    ORDER BY TotalAsistencias DESC;
END
GO

CREATE OR ALTER PROCEDURE SP_ReporteCoberturaVsProyeccion
    @FechaDesde DATE,
    @FechaHasta DATE,
    @IdLugar INT = NULL
AS
BEGIN
    SELECT 
        s.Fecha,
        l.Nombre as Lugar,
        ISNULL(s.Proyeccion, 0) as Proyeccion,
        (s.TotalComensales + s.TotalInvitados) as Atendidos,
        CASE WHEN ISNULL(s.Proyeccion, 0) > 0 
             THEN CAST((s.TotalComensales + s.TotalInvitados) * 100.0 / s.Proyeccion AS DECIMAL(10,2))
             ELSE NULL END as CoberturaPorcentaje,
        (s.TotalComensales + s.TotalInvitados) - ISNULL(s.Proyeccion, 0) as Diferencia
    FROM Servicios s
    INNER JOIN Lugares l ON s.IdLugar = l.IdLugar
    WHERE s.Fecha BETWEEN @FechaDesde AND @FechaHasta
      AND (@IdLugar IS NULL OR s.IdLugar = @IdLugar)
    ORDER BY s.Fecha DESC, l.Nombre;
END
GO

CREATE OR ALTER PROCEDURE SP_DistribucionPorDiaSemana
    @FechaDesde DATE,
    @FechaHasta DATE,
    @IdLugar INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET DATEFIRST 1;
    WITH Datos AS (
        SELECT 
            DATEPART(WEEKDAY, s.Fecha) as DiaNumero,
            (s.TotalComensales + s.TotalInvitados) as Total
        FROM Servicios s
        WHERE s.Fecha BETWEEN @FechaDesde AND @FechaHasta
          AND (@IdLugar IS NULL OR s.IdLugar = @IdLugar)
    )
    SELECT 
        DiaNumero as Orden,
        CASE DiaNumero
            WHEN 1 THEN 'Lunes'
            WHEN 2 THEN 'Martes'
            WHEN 3 THEN 'Miércoles'
            WHEN 4 THEN 'Jueves'
            WHEN 5 THEN 'Viernes'
            WHEN 6 THEN 'Sábado'
            WHEN 7 THEN 'Domingo'
            ELSE CAST(DiaNumero AS VARCHAR(10))
        END as Dia,
        SUM(Total) as Total
    FROM Datos
    GROUP BY DiaNumero
    ORDER BY Orden;
END
GO

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

CREATE OR ALTER PROCEDURE SP_VerificarIntegridadDatos
AS
BEGIN
    SELECT IdEmpleado, Nombre, Apellido
    FROM Empleados
    WHERE IdEmpresa IS NULL OR IdEmpresa NOT IN (SELECT IdEmpresa FROM Empresas);
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
    DELETE FROM Registros 
    WHERE Fecha < DATEADD(YEAR, -@Anios, GETDATE());
    DELETE FROM Servicios 
    WHERE Fecha < DATEADD(YEAR, -@Anios, GETDATE());
END
GO

CREATE OR ALTER PROCEDURE SP_BackupDatos
    @FechaBackup NVARCHAR(8)
AS
BEGIN
    EXEC('SELECT * INTO Empleados_Backup_' + @FechaBackup + ' FROM Empleados');
    EXEC('SELECT * INTO Registros_Backup_' + @FechaBackup + ' FROM Registros WHERE Fecha >= DATEADD(MONTH, -1, GETDATE())');
END
GO

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

CREATE OR ALTER VIEW vw_EmpleadosSinAlmorzarBase AS
SELECT 
    e.IdEmpleado,
    e.Nombre,
    e.Apellido,
    e.IdCredencial,
    e.IdEmpresa,
    emp.Nombre as NombreEmpresa,
    CONCAT(e.Nombre, ' ', e.Apellido) as NombreCompleto
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
