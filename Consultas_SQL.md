# Consultas SQL - Sistema de Control de Almuerzos

## 🏢 Gestión de Lugares (Reemplaza Autenticación de Usuarios)

### **1. Listar Lugares para ComboBox**
```sql
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
```

### **2. Obtener Lugar por Nombre**
```sql
CREATE OR ALTER PROCEDURE SP_ObtenerLugarPorNombre
    @Nombre NVARCHAR(50)
AS
BEGIN
    SELECT 
        IdLugar,
        Nombre,
        Descripcion,
        Estado
    FROM Lugares 
    WHERE Nombre = @Nombre AND Estado = 1;
END
```

## 🏢 Gestión de Empleados

### **3. Listar Todos los Empleados Activos**
```sql
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
```

### **4. Buscar Empleado por Credencial RFID**
```sql
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
```

### **5. Buscar Empleados por Nombre**
```sql
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
```

### **6. Empleados por Empresa**
```sql
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
```

### **7. Empleados que NO han almorzado en un servicio**
```sql
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
```

## 🍽️ Gestión de Servicios

### **8. Obtener Servicio Activo por Lugar**
```sql
CREATE OR ALTER PROCEDURE SP_ObtenerServicioActivo
    @IdLugar INT
AS
BEGIN
    SELECT 
        IdServicio, 
        IdLugar, 
        Fecha, 
        TotalComensales, 
        TotalInvitados
    FROM Servicios
    WHERE IdLugar = @IdLugar 
      AND Fecha = CAST(GETDATE() AS DATE)
      AND TotalComensales = 0; -- Servicio iniciado pero no finalizado
END
```

### **9. Alta de Servicio**
```sql
CREATE OR ALTER PROCEDURE SP_AltaServicio
    @IdLugar INT
AS
BEGIN
    INSERT INTO Servicios (IdLugar, Fecha, TotalComensales, TotalInvitados)
    VALUES (@IdLugar, CAST(GETDATE() AS DATE), 0, 0);
    
    SELECT SCOPE_IDENTITY() as IdServicio;
END
```

### **10. Finalizar Servicio**
```sql
CREATE OR ALTER PROCEDURE SP_FinalizarServicio
    @IdServicio INT,
    @TotalComensales INT,
    @TotalInvitados INT
AS
BEGIN
    UPDATE Servicios 
    SET TotalComensales = @TotalComensales,
        TotalInvitados = @TotalInvitados
    WHERE IdServicio = @IdServicio;
END
```

### **11. Listar Servicios por Fecha**
```sql
CREATE OR ALTER PROCEDURE SP_ListarServiciosPorFecha
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SELECT 
        s.IdServicio, 
        s.Fecha, 
        s.TotalComensales, 
        s.TotalInvitados,
        l.Nombre as Lugar,
        (s.TotalComensales + s.TotalInvitados) as Total
    FROM Servicios s
    INNER JOIN Lugares l ON s.IdLugar = l.IdLugar
    WHERE s.Fecha BETWEEN @FechaDesde AND @FechaHasta
    ORDER BY s.Fecha DESC, l.Nombre;
END
```

### **12. Servicios por Lugar**
```sql
CREATE OR ALTER PROCEDURE SP_ListarServiciosPorLugar
    @IdLugar INT,
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SELECT 
        s.IdServicio, 
        s.Fecha, 
        s.TotalComensales, 
        s.TotalInvitados,
        (s.TotalComensales + s.TotalInvitados) as Total
    FROM Servicios s
    WHERE s.IdLugar = @IdLugar
      AND s.Fecha BETWEEN @FechaDesde AND @FechaHasta
    ORDER BY s.Fecha DESC;
END
```

## 📝 Gestión de Registros

### **13. Registrar Empleado en Servicio**
```sql
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
```

### **14. Listar Registros de un Servicio**
```sql
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
```

### **15. Verificar si Empleado ya está Registrado**
```sql
CREATE OR ALTER PROCEDURE SP_VerificarEmpleadoRegistrado
    @IdEmpleado INT,
    @IdServicio INT
AS
BEGIN
    SELECT COUNT(*) as Existe
    FROM Registros
    WHERE IdEmpleado = @IdEmpleado AND IdServicio = @IdServicio;
END
```

### **16. Contar Registros por Servicio**
```sql
CREATE OR ALTER PROCEDURE SP_ContarRegistrosPorServicio
    @IdServicio INT
AS
BEGIN
    SELECT COUNT(*) as TotalRegistros
    FROM Registros
    WHERE IdServicio = @IdServicio;
END
```

## 📊 Reportes y Estadísticas

### **17. Estadísticas del Servicio Activo**
```sql
CREATE OR ALTER PROCEDURE SP_EstadisticasServicioActivo
    @IdServicio INT
AS
BEGIN
    SELECT 
        COUNT(*) as TotalEmpleados,
        s.TotalInvitados,
        (COUNT(*) + s.TotalInvitados) as TotalGeneral
    FROM Registros r
    INNER JOIN Servicios s ON r.IdServicio = s.IdServicio
    WHERE r.IdServicio = @IdServicio;
END
```

### **18. Registros por Empresa en un Servicio**
```sql
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
```

### **19. Picos de Concurrencia por Hora**
```sql
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
```

### **20. Resumen Diario por Lugar**
```sql
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
```

### **21. Top 5 Empresas con Más Asistencia**
```sql
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
```

### **22. Promedio Diario de Asistencia**
```sql
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
```

## 🏢 Gestión de Empresas

### **23. Listar Todas las Empresas**
```sql
CREATE OR ALTER PROCEDURE SP_ListarEmpresas
AS
BEGIN
    SELECT IdEmpresa, Nombre
    FROM Empresas
    WHERE Estado = 1
    ORDER BY Nombre;
END
```

### **24. Empleados por Empresa**
```sql
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
```

## 🔧 Consultas de Mantenimiento

### **25. Verificar Integridad de Datos**
```sql
CREATE OR ALTER PROCEDURE SP_VerificarIntegridadDatos
AS
BEGIN
    -- Empleados sin empresa
    SELECT IdEmpleado, Nombre, Apellido
    FROM Empleados
    WHERE IdEmpresa IS NULL OR IdEmpresa NOT IN (SELECT IdEmpresa FROM Empresas);
    
    -- Registros sin empleado válido
    SELECT r.IdRegistro, r.IdEmpleado
    FROM Registros r
    LEFT JOIN Empleados e ON r.IdEmpleado = e.IdEmpleado
    WHERE e.IdEmpleado IS NULL;
END
```

### **26. Limpiar Datos Antiguos**
```sql
CREATE OR ALTER PROCEDURE SP_LimpiarDatosAntiguos
    @Anios INT = 1
AS
BEGIN
    -- Eliminar registros de más de X años
    DELETE FROM Registros 
    WHERE Fecha < DATEADD(YEAR, -@Anios, GETDATE());
    
    -- Eliminar servicios de más de X años
    DELETE FROM Servicios 
    WHERE Fecha < DATEADD(YEAR, -@Anios, GETDATE());
END
```

### **27. Backup de Datos Importantes**
```sql
CREATE OR ALTER PROCEDURE SP_BackupDatos
    @FechaBackup NVARCHAR(8)
AS
BEGIN
    -- Crear tabla de backup de empleados
    EXEC('SELECT * INTO Empleados_Backup_' + @FechaBackup + ' FROM Empleados');
    
    -- Crear tabla de backup de registros
    EXEC('SELECT * INTO Registros_Backup_' + @FechaBackup + ' FROM Registros WHERE Fecha >= DATEADD(MONTH, -1, GETDATE())');
END
```

## 📈 Consultas para Dashboard

### **28. Estadísticas del Día Actual**
```sql
CREATE OR ALTER PROCEDURE SP_EstadisticasDiaActual
AS
BEGIN
    SELECT 
        l.Nombre as Lugar,
        COUNT(s.IdServicio) as ServiciosHoy,
        SUM(s.TotalComensales) as TotalEmpleados,
        SUM(s.TotalInvitados) as TotalInvitados,
        SUM(s.TotalComensales + s.TotalInvitados) as TotalGeneral
    FROM Servicios s
    INNER JOIN Lugares l ON s.IdLugar = l.IdLugar
    WHERE s.Fecha = CAST(GETDATE() AS DATE)
    GROUP BY l.Nombre, l.IdLugar;
END
```

### **29. Tendencia Últimos 7 Días**
```sql
CREATE OR ALTER PROCEDURE SP_TendenciaUltimos7Dias
AS
BEGIN
    SELECT 
        s.Fecha,
        SUM(s.TotalComensales + s.TotalInvitados) as TotalDiario
    FROM Servicios s
    WHERE s.Fecha >= DATEADD(DAY, -7, GETDATE())
    GROUP BY s.Fecha
    ORDER BY s.Fecha;
END
```

### **30. Empleados Más Frecuentes**
```sql
CREATE OR ALTER PROCEDURE SP_EmpleadosMasFrecuentes
    @Meses INT = 1
AS
BEGIN
    SELECT TOP 10
        e.Nombre + ' ' + e.Apellido as Empleado,
        emp.Nombre as Empresa,
        COUNT(*) as Asistencias
    FROM Registros r
    INNER JOIN Empleados e ON r.IdEmpleado = e.IdEmpleado
    INNER JOIN Empresas emp ON e.IdEmpresa = emp.IdEmpresa
    WHERE r.Fecha >= DATEADD(MONTH, -@Meses, GETDATE())
    GROUP BY e.IdEmpleado, e.Nombre, e.Apellido, emp.Nombre
    ORDER BY Asistencias DESC;
END
```

## 🎯 Vistas Útiles

### **Vista: Empleados con Empresa**
```sql
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
```

### **Vista: Servicios Completos**
```sql
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
```

### **Vista: Registros Detallados**
```sql
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
```

## 🔄 Triggers

### **Trigger: Actualizar Estadísticas al Registrar**
```sql
CREATE OR ALTER TRIGGER TR_ActualizarEstadisticas
ON Registros
AFTER INSERT
AS
BEGIN
    -- Aquí se pueden agregar lógicas adicionales
    -- como actualizar contadores en tiempo real
    SET NOCOUNT ON;
END
```

### **Trigger: Validar Registro Único**
```sql
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
```
