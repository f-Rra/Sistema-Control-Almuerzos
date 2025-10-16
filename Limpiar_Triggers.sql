-- =============================================
-- LIMPIAR TRIGGERS PROBLEMÁTICOS
-- Sistema de Control de Almuerzos
-- =============================================
-- Este script elimina triggers que puedan causar conflictos
-- durante la inserción de datos iniciales
-- =============================================

USE BD_Control_Almuerzos;
GO

-- Eliminar trigger de cálculo automático si existe
IF EXISTS (SELECT 1 FROM sys.triggers WHERE name = 'trg_CalcularDatosServicio')
BEGIN
    DROP TRIGGER trg_CalcularDatosServicio;
    PRINT 'Trigger trg_CalcularDatosServicio eliminado';
END
ELSE
BEGIN
    PRINT 'Trigger trg_CalcularDatosServicio no existe';
END
GO

-- Eliminar cualquier otro trigger problemático en la tabla Servicios
DECLARE @sql NVARCHAR(MAX) = '';

SELECT @sql = @sql + 'DROP TRIGGER ' + QUOTENAME(name) + '; '
FROM sys.triggers
WHERE parent_id = OBJECT_ID('Servicios')
  AND name <> 'TR_ValidarRegistroUnico';

IF @sql <> ''
BEGIN
    EXEC sp_executesql @sql;
    PRINT 'Triggers adicionales eliminados de la tabla Servicios';
END
ELSE
BEGIN
    PRINT 'No hay triggers adicionales en la tabla Servicios';
END
GO

-- Listar triggers restantes
PRINT '';
PRINT '================================================';
PRINT 'TRIGGERS ACTIVOS EN EL SISTEMA:';
PRINT '================================================';
SELECT 
    t.name AS Trigger_Name,
    OBJECT_NAME(t.parent_id) AS Table_Name,
    t.is_disabled AS Is_Disabled
FROM sys.triggers t
WHERE t.parent_class = 1  -- Triggers de tabla
ORDER BY Table_Name, Trigger_Name;
GO

PRINT '';
PRINT '================================================';
PRINT 'Limpieza completada. Ahora puede ejecutar:';
PRINT '1. Datos_Iniciales.sql';
PRINT '================================================';
GO
