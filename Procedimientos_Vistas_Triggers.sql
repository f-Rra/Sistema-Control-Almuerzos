
-- =============================================
-- PROCEDIMIENTOS DE LUGARES
-- =============================================

CREATE OR ALTER PROCEDURE sp_ListarLugares
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

CREATE OR ALTER PROCEDURE sp_ObtenerLugarPorNombre
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

-- =============================================
-- PROCEDIMIENTOS DE SERVICIOS
-- =============================================

CREATE OR ALTER PROCEDURE sp_ListarServicios
AS
BEGIN
    SELECT 
        s.IdServicio,
        s.Fecha,
        s.Proyeccion,
        s.DuracionMinutos,
        s.TotalComensales,
        s.TotalInvitados,
        l.Nombre as NombreLugar
    FROM Servicios s
    INNER JOIN Lugares l ON s.IdLugar = l.IdLugar
    ORDER BY s.Fecha DESC, l.Nombre;
END
GO


CREATE OR ALTER PROCEDURE sp_ObtenerServicioActivo
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

CREATE OR ALTER PROCEDURE sp_ObtenerUltimoServicio
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

CREATE OR ALTER PROCEDURE sp_IniciarServicio
    @IdLugar INT,
    @Proyeccion INT = NULL
AS
BEGIN
    INSERT INTO Servicios (IdLugar, Fecha, Proyeccion, DuracionMinutos, TotalComensales, TotalInvitados)
    VALUES (@IdLugar, CAST(GETDATE() AS DATE), @Proyeccion, NULL, 0, 0);
    
    SELECT CAST(SCOPE_IDENTITY() AS INT) as IdServicio;
END
GO

CREATE OR ALTER PROCEDURE sp_FinalizarServicio
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

CREATE OR ALTER PROCEDURE sp_ListarServiciosPorFecha
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

CREATE OR ALTER PROCEDURE sp_ListarServiciosPorLugar
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

CREATE OR ALTER PROCEDURE sp_ListarServiciosRango
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

-- =============================================
-- PROCEDIMIENTOS DE REGISTROS
-- =============================================

CREATE OR ALTER PROCEDURE sp_RegistrarEmpleado
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

CREATE OR ALTER PROCEDURE sp_ListarRegistrosPorServicio
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

CREATE OR ALTER PROCEDURE sp_VerificarEmpleadoRegistrado
    @IdEmpleado INT,
    @IdServicio INT
AS
BEGIN
    SELECT COUNT(*) as Registrado
    FROM Registros
    WHERE IdEmpleado = @IdEmpleado AND IdServicio = @IdServicio;
END
GO

CREATE OR ALTER PROCEDURE sp_ContarRegistrosPorServicio
    @IdServicio INT
AS
BEGIN
    SELECT COUNT(*) as TotalRegistros
    FROM Registros
    WHERE IdServicio = @IdServicio;
END
GO

-- =============================================
-- PROCEDIMIENTOS DE REPORTES
-- =============================================

CREATE OR ALTER PROCEDURE sp_AsistenciasPorEmpresas
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

CREATE OR ALTER PROCEDURE sp_ReporteCoberturaVsProyeccion
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

CREATE OR ALTER PROCEDURE sp_DistribucionPorDiaSemana
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

-- =============================================
-- PROCEDIMIENTOS DE EMPLEADOS
-- =============================================

CREATE OR ALTER PROCEDURE sp_ListarEmpleados
AS
BEGIN
    SELECT 
        e.IdEmpleado, 
        e.Nombre, 
        e.Apellido, 
        e.IdCredencial, 
        emp.Nombre as Empresa, 
        emp.IdEmpresa,
        e.Estado
    FROM Empleados e
    INNER JOIN Empresas emp ON e.IdEmpresa = emp.IdEmpresa
    ORDER BY e.Estado DESC, e.Nombre, e.Apellido;
END
GO

CREATE OR ALTER PROCEDURE sp_BuscarEmpleadoPorCredencial
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

CREATE OR ALTER PROCEDURE sp_ListarEmpleadosPorEmpresa
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

CREATE OR ALTER PROCEDURE sp_EmpleadosSinAlmorzar
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
    FROM vw_EmpleadosSinAlmorzar e
    WHERE e.IdEmpleado NOT IN (
        SELECT IdEmpleado 
        FROM Registros 
        WHERE IdServicio = @IdServicio
    )
    ORDER BY e.Nombre, e.Apellido;
END
GO

CREATE OR ALTER PROCEDURE sp_FiltrarEmpleadosSinAlmorzar
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
    FROM vw_EmpleadosSinAlmorzar e
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

CREATE OR ALTER PROCEDURE sp_AgregarEmpleado
    @IdCredencial NVARCHAR(50),
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @IdEmpresa INT,
    @Estado BIT = 1
AS
BEGIN
    INSERT INTO Empleados (IdCredencial, Nombre, Apellido, IdEmpresa, Estado)
    VALUES (@IdCredencial, @Nombre, @Apellido, @IdEmpresa, @Estado);
    
    SELECT CAST(SCOPE_IDENTITY() AS INT) as IdEmpleado;
END
GO

CREATE OR ALTER PROCEDURE sp_ModificarEmpleado
    @IdEmpleado INT,
    @IdCredencial NVARCHAR(50),
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @IdEmpresa INT,
    @Estado BIT
AS
BEGIN
    UPDATE Empleados 
    SET IdCredencial = @IdCredencial,
        Nombre = @Nombre,
        Apellido = @Apellido,
        IdEmpresa = @IdEmpresa,
        Estado = @Estado
    WHERE IdEmpleado = @IdEmpleado;
END
GO

CREATE OR ALTER PROCEDURE sp_DesactivarEmpleado
    @IdEmpleado INT
AS
BEGIN
    UPDATE Empleados 
    SET Estado = 0 
    WHERE IdEmpleado = @IdEmpleado;
END
GO

CREATE OR ALTER PROCEDURE sp_VerificarCredencial
    @IdCredencial NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(*) as Registrado
    FROM Empleados
    WHERE IdCredencial = @IdCredencial;
END
GO

CREATE OR ALTER PROCEDURE sp_BuscarEmpleadoPorId
    @IdEmpleado INT
AS
BEGIN
    SELECT 
        e.IdEmpleado, 
        e.IdCredencial, 
        e.Nombre, 
        e.Apellido, 
        e.Estado, 
        emp.IdEmpresa, 
        emp.Nombre as NombreEmpresa
    FROM Empleados e
    INNER JOIN Empresas emp ON e.IdEmpresa = emp.IdEmpresa
    WHERE e.IdEmpleado = @IdEmpleado;
END
GO

-- =============================================
-- PROCEDIMIENTOS DE EMPRESAS
-- =============================================

CREATE OR ALTER PROCEDURE sp_ListarEmpresas
AS
BEGIN
    SELECT IdEmpresa, Nombre
    FROM Empresas
    WHERE Estado = 1
    ORDER BY Nombre;
END
GO

CREATE OR ALTER PROCEDURE sp_AgregarEmpresa
    @Nombre NVARCHAR(100),
    @Estado BIT = 1
AS
BEGIN
    INSERT INTO Empresas (Nombre, Estado)
    VALUES (@Nombre, @Estado);
    
    SELECT CAST(SCOPE_IDENTITY() AS INT) as IdEmpresa;
END
GO

CREATE OR ALTER PROCEDURE sp_ModificarEmpresa
    @IdEmpresa INT,
    @Nombre NVARCHAR(100),
    @Estado BIT
AS
BEGIN
    UPDATE Empresas 
    SET Nombre = @Nombre,
        Estado = @Estado
    WHERE IdEmpresa = @IdEmpresa;
END
GO

CREATE OR ALTER PROCEDURE sp_DesactivarEmpresa
    @IdEmpresa INT
AS
BEGIN
    UPDATE Empresas 
    SET Estado = 0 
    WHERE IdEmpresa = @IdEmpresa;
END
GO

-- =============================================
-- VISTAS
-- =============================================

CREATE OR ALTER VIEW vw_EmpleadosSinAlmorzar AS
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

CREATE OR ALTER VIEW vw_EmpresasConEmpleados AS
SELECT 
    emp.IdEmpresa,
    emp.Nombre as Empresa,
    emp.Estado,
    COUNT(e.IdEmpleado) as CantidadEmpleados
FROM Empresas emp
LEFT JOIN Empleados e ON emp.IdEmpresa = e.IdEmpresa AND e.Estado = 1
GROUP BY emp.IdEmpresa, emp.Nombre, emp.Estado;
GO

-- =============================================
-- TRIGGERS
-- =============================================

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

-- =============================================
-- TRIGGER SUGERIDO: Auditoría de cambios en Empleados
-- =============================================
-- Este trigger registra los cambios importantes en la tabla Empleados
-- Útil para mantener un historial de modificaciones

CREATE OR ALTER TRIGGER TR_AuditoriaEmpleados
ON Empleados
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Para actualizaciones
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO HistorialEmpleados (IdEmpleado, Accion, FechaHora, Usuario, ValorAnterior, ValorNuevo)
        SELECT 
            i.IdEmpleado,
            'UPDATE' as Accion,
            GETDATE() as FechaHora,
            SYSTEM_USER as Usuario,
            CONCAT('Nombre:', d.Nombre, ' ', d.Apellido, ' | Empresa:', d.IdEmpresa, ' | Estado:', d.Estado) as ValorAnterior,
            CONCAT('Nombre:', i.Nombre, ' ', i.Apellido, ' | Empresa:', i.IdEmpresa, ' | Estado:', i.Estado) as ValorNuevo
        FROM inserted i
        INNER JOIN deleted d ON i.IdEmpleado = d.IdEmpleado
        WHERE i.Nombre <> d.Nombre 
           OR i.Apellido <> d.Apellido 
           OR i.IdEmpresa <> d.IdEmpresa 
           OR i.Estado <> d.Estado;
    END
    
    -- Para eliminaciones
    IF NOT EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO HistorialEmpleados (IdEmpleado, Accion, FechaHora, Usuario, ValorAnterior, ValorNuevo)
        SELECT 
            d.IdEmpleado,
            'DELETE' as Accion,
            GETDATE() as FechaHora,
            SYSTEM_USER as Usuario,
            CONCAT('Nombre:', d.Nombre, ' ', d.Apellido, ' | Empresa:', d.IdEmpresa, ' | Estado:', d.Estado) as ValorAnterior,
            NULL as ValorNuevo
        FROM deleted d;
    END
END
GO

-- =============================================
-- TRIGGER SUGERIDO: Validar empresa activa al agregar empleado
-- =============================================
-- Este trigger evita que se agreguen empleados a empresas inactivas

CREATE OR ALTER TRIGGER TR_ValidarEmpresaActiva
ON Empleados
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Verificar si la empresa está activa
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        INNER JOIN Empresas emp ON i.IdEmpresa = emp.IdEmpresa
        WHERE emp.Estado = 0
    )
    BEGIN
        RAISERROR('No se puede agregar un empleado a una empresa inactiva', 16, 1);
        RETURN;
    END
    
    -- Si la empresa está activa, insertar el empleado
    INSERT INTO Empleados (IdCredencial, Nombre, Apellido, IdEmpresa, Estado)
    SELECT IdCredencial, Nombre, Apellido, IdEmpresa, Estado
    FROM inserted;
END
GO
