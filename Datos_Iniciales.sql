-- =============================================
-- DATOS INICIALES
-- Sistema de Control de Almuerzos
-- =============================================

USE BD_Control_Almuerzos;
GO

-- =============================================
-- 1. LUGARES
-- =============================================
INSERT INTO Lugares (Nombre) VALUES 
('Comedor'),
('Quincho');
GO

-- =============================================
-- 2. EMPRESAS (12 empresas del predio)
-- =============================================
INSERT INTO Empresas (Nombre, Estado) VALUES 
('Logística', 1),
('Servicios', 1),
('Mantenimiento', 1),
('Gastronomia', 1),
('Seguridad', 1),
('Gerencia', 1),
('Administración', 1),
('Recursos Humanos', 1),
('Tecnología', 1),
('Calidad', 1),
('Compras', 1),
('Limpieza', 1);
GO

-- =============================================
-- 3. EMPLEADOS (60 empleados distribuidos)
-- =============================================
INSERT INTO Empleados (IdCredencial, Nombre, Apellido, IdEmpresa, Estado) VALUES 

('RF001', 'Juan', 'Pérez', 1, 1),
('RF002', 'María', 'García', 1, 1),
('RF003', 'Carlos', 'López', 1, 1),
('RF004', 'Ana', 'Martínez', 1, 1),
('RF005', 'Luis', 'Rodríguez', 1, 1),
('RF006', 'Sofía', 'Fernández', 1, 1),
('RF007', 'Diego', 'González', 1, 1),
('RF008', 'Valentina', 'Silva', 1, 1),

('SX001', 'Andrés', 'Morales', 2, 1),
('SX002', 'Camila', 'Vargas', 2, 1),
('SX003', 'Roberto', 'Herrera', 2, 1),
('SX004', 'Patricia', 'Castro', 2, 1),
('SX005', 'Miguel', 'Torres', 2, 1),
('SX006', 'Isabella', 'Reyes', 2, 1),
('SX007', 'Francisco', 'Jiménez', 2, 1),

('LI001', 'Daniela', 'Moreno', 3, 1),
('LI002', 'Alejandro', 'Ruiz', 3, 1),
('LI003', 'Gabriela', 'Díaz', 3, 1),
('LI004', 'Ricardo', 'Flores', 3, 1),
('LI005', 'Natalia', 'Cruz', 3, 1),
('LI006', 'Fernando', 'Ortiz', 3, 1),

('SG001', 'Lucía', 'Ramos', 4, 1),
('SG002', 'Eduardo', 'Acosta', 4, 1),
('SG003', 'Carmen', 'Medina', 4, 1),
('SG004', 'Héctor', 'Vega', 4, 1),
('SG005', 'Rosa', 'Carrillo', 4, 1),

('MI001', 'Manuel', 'Guerrero', 5, 1),
('MI002', 'Elena', 'Mendoza', 5, 1),
('MI003', 'Alberto', 'Salazar', 5, 1),
('MI004', 'Verónica', 'Rojas', 5, 1),
('MI005', 'Jorge', 'Paredes', 5, 1),

('SP001', 'Adriana', 'Miranda', 6, 1),
('SP002', 'Raúl', 'Cortés', 6, 1),
('SP003', 'Monica', 'Soto', 6, 1),
('SP004', 'Pablo', 'Valdez', 6, 1),
('SP005', 'Claudia', 'Espinoza', 6, 1),

('AC001', 'Mario', 'Aguilar', 7, 1),
('AC002', 'Silvia', 'Villanueva', 7, 1),
('AC003', 'Oscar', 'Molina', 7, 1),
('AC004', 'Diana', 'Campos', 7, 1),
('AC005', 'Arturo', 'Navarro', 7, 1),

('RH001', 'Beatriz', 'Figueroa', 8, 1),
('RH002', 'César', 'Cordero', 8, 1),
('RH003', 'Gloria', 'Aguirre', 8, 1),
('RH004', 'Felipe', 'Ponce', 8, 1),

('IT001', 'Teresa', 'Palacios', 9, 1),
('IT002', 'Rafael', 'Escobar', 9, 1),
('IT003', 'Lorena', 'Zúñiga', 9, 1),
('IT004', 'Guillermo', 'Fuentes', 9, 1),

('CA001', 'Mónica', 'Bravo', 10, 1),
('CA002', 'Sergio', 'Mendez', 10, 1),
('CA003', 'Valeria', 'Robles', 10, 1),
('CA004', 'Martín', 'Chávez', 10, 1),

('CB001', 'Laura', 'Ríos', 11, 1),
('CB002', 'Ignacio', 'Peralta', 11, 1),
('CB003', 'Paola', 'Vázquez', 11, 1),
('CB004', 'Ramiro', 'Sandoval', 11, 1),

('LS001', 'Marcela', 'Guzmán', 12, 1),
('LS002', 'Esteban', 'Maldonado', 12, 1),
('LS003', 'Carla', 'Ibarra', 12, 1);
GO

-- =============================================
-- 4. SERVICIOS 
-- =============================================


DECLARE @FechaBase DATE = CAST(GETDATE() AS DATE);

-- Semana 1 (hace 2 semanas) - LUNES a VIERNES
INSERT INTO Servicios (IdLugar, Fecha, Proyeccion, DuracionMinutos, TotalComensales, TotalInvitados) VALUES 
-- LUNES hace 14 días
(1, DATEADD(day, -14, @FechaBase), 50, 90, 48, 2),
(2, DATEADD(day, -14, @FechaBase), 35, 85, 33, 2),

-- MARTES hace 13 días
(1, DATEADD(day, -13, @FechaBase), 50, 95, 45, 3),
(2, DATEADD(day, -13, @FechaBase), 35, 88, 32, 1),

-- MIÉRCOLES hace 12 días
(1, DATEADD(day, -12, @FechaBase), 50, 92, 47, 1),
(2, DATEADD(day, -12, @FechaBase), 35, 90, 34, 3),

-- JUEVES hace 11 días
(1, DATEADD(day, -11, @FechaBase), 50, 88, 52, 4),
(2, DATEADD(day, -11, @FechaBase), 35, 87, 31, 2),

-- VIERNES hace 10 días
(1, DATEADD(day, -10, @FechaBase), 50, 93, 46, 2),
(2, DATEADD(day, -10, @FechaBase), 35, 89, 35, 1),

-- Semana 2 (hace 1 semana) - LUNES a VIERNES
-- LUNES hace 7 días
(1, DATEADD(day, -7, @FechaBase), 50, 91, 43, 1),
(2, DATEADD(day, -7, @FechaBase), 35, 86, 30, 1),

-- MARTES hace 6 días
(1, DATEADD(day, -6, @FechaBase), 50, 94, 49, 3),
(2, DATEADD(day, -6, @FechaBase), 35, 91, 35, 2),

-- MIÉRCOLES hace 5 días
(1, DATEADD(day, -5, @FechaBase), 50, 89, 44, 2),
(2, DATEADD(day, -5, @FechaBase), 35, 88, 33, 1),

-- JUEVES hace 4 días
(1, DATEADD(day, -4, @FechaBase), 50, 96, 50, 4),
(2, DATEADD(day, -4, @FechaBase), 35, 87, 32, 0),

-- VIERNES hace 3 días
(1, DATEADD(day, -3, @FechaBase), 50, 90, 47, 3),
(2, DATEADD(day, -3, @FechaBase), 35, 89, 36, 2),

-- Semana actual - LUNES y MARTES (ejemplos recientes)
-- LUNES (ayer o anteayer)
(1, DATEADD(day, -2, @FechaBase), 50, 92, 45, 3),
(2, DATEADD(day, -2, @FechaBase), 35, 88, 32, 1),

-- MARTES (ayer)
(1, DATEADD(day, -1, @FechaBase), 50, 94, 48, 4),
(2, DATEADD(day, -1, @FechaBase), 35, 90, 33, 3);
GO

-- =============================================
-- 5. REGISTROS 
-- =============================================

DECLARE @FechaBase DATE = CAST(GETDATE() AS DATE);

-- Servicio del COMEDOR - hace 2 días (Id = 21)
INSERT INTO Registros (IdEmpleado, IdEmpresa, IdServicio, IdLugar, Fecha, Hora) VALUES 
(1, 1, 21, 1, DATEADD(day, -2, @FechaBase), '12:05:00'),
(2, 1, 21, 1, DATEADD(day, -2, @FechaBase), '12:08:00'),
(3, 1, 21, 1, DATEADD(day, -2, @FechaBase), '12:10:00'),
(4, 1, 21, 1, DATEADD(day, -2, @FechaBase), '12:12:00'),
(5, 1, 21, 1, DATEADD(day, -2, @FechaBase), '12:15:00'),
(7, 1, 21, 1, DATEADD(day, -2, @FechaBase), '12:18:00'),

(9, 2, 21, 1, DATEADD(day, -2, @FechaBase), '12:20:00'),
(10, 2, 21, 1, DATEADD(day, -2, @FechaBase), '12:22:00'),
(11, 2, 21, 1, DATEADD(day, -2, @FechaBase), '12:25:00'),
(13, 2, 21, 1, DATEADD(day, -2, @FechaBase), '12:28:00'),
(14, 2, 21, 1, DATEADD(day, -2, @FechaBase), '12:30:00'),

(16, 3, 21, 1, DATEADD(day, -2, @FechaBase), '12:32:00'),
(17, 3, 21, 1, DATEADD(day, -2, @FechaBase), '12:35:00'),
(18, 3, 21, 1, DATEADD(day, -2, @FechaBase), '12:38:00'),
(19, 3, 21, 1, DATEADD(day, -2, @FechaBase), '12:40:00'),
(20, 3, 21, 1, DATEADD(day, -2, @FechaBase), '12:42:00'),

(22, 4, 21, 1, DATEADD(day, -2, @FechaBase), '12:45:00'),
(23, 4, 21, 1, DATEADD(day, -2, @FechaBase), '12:47:00'),
(24, 4, 21, 1, DATEADD(day, -2, @FechaBase), '12:50:00'),
(25, 4, 21, 1, DATEADD(day, -2, @FechaBase), '12:52:00'),

(27, 5, 21, 1, DATEADD(day, -2, @FechaBase), '12:55:00'),
(28, 5, 21, 1, DATEADD(day, -2, @FechaBase), '12:57:00'),
(29, 5, 21, 1, DATEADD(day, -2, @FechaBase), '13:00:00'),
(30, 5, 21, 1, DATEADD(day, -2, @FechaBase), '13:02:00'),

(31, 6, 21, 1, DATEADD(day, -2, @FechaBase), '13:05:00'),
(32, 6, 21, 1, DATEADD(day, -2, @FechaBase), '13:07:00'),
(33, 6, 21, 1, DATEADD(day, -2, @FechaBase), '13:10:00'),
(34, 6, 21, 1, DATEADD(day, -2, @FechaBase), '13:12:00'),

(36, 7, 21, 1, DATEADD(day, -2, @FechaBase), '13:15:00'),
(37, 7, 21, 1, DATEADD(day, -2, @FechaBase), '13:17:00'),
(38, 7, 21, 1, DATEADD(day, -2, @FechaBase), '13:20:00'),
(39, 7, 21, 1, DATEADD(day, -2, @FechaBase), '13:22:00'),

(41, 8, 21, 1, DATEADD(day, -2, @FechaBase), '13:25:00'),
(42, 8, 21, 1, DATEADD(day, -2, @FechaBase), '13:27:00'),
(43, 8, 21, 1, DATEADD(day, -2, @FechaBase), '13:30:00'),

(45, 9, 21, 1, DATEADD(day, -2, @FechaBase), '13:32:00'),
(46, 9, 21, 1, DATEADD(day, -2, @FechaBase), '13:35:00'),
(47, 9, 21, 1, DATEADD(day, -2, @FechaBase), '13:37:00'),

(49, 10, 21, 1, DATEADD(day, -2, @FechaBase), '13:40:00'),
(50, 10, 21, 1, DATEADD(day, -2, @FechaBase), '13:42:00'),
(51, 10, 21, 1, DATEADD(day, -2, @FechaBase), '13:45:00'),

(53, 11, 21, 1, DATEADD(day, -2, @FechaBase), '13:47:00'),
(54, 11, 21, 1, DATEADD(day, -2, @FechaBase), '13:50:00'),

(57, 12, 21, 1, DATEADD(day, -2, @FechaBase), '13:52:00'),
(58, 12, 21, 1, DATEADD(day, -2, @FechaBase), '13:55:00');

INSERT INTO Registros (IdEmpleado, IdEmpresa, IdServicio, IdLugar, Fecha, Hora) VALUES 

(6, 1, 22, 2, DATEADD(day, -2, @FechaBase), '12:10:00'),
(8, 1, 22, 2, DATEADD(day, -2, @FechaBase), '12:15:00'),
(2, 1, 22, 2, DATEADD(day, -2, @FechaBase), '12:20:00'),
(4, 1, 22, 2, DATEADD(day, -2, @FechaBase), '12:25:00'),

(12, 2, 22, 2, DATEADD(day, -2, @FechaBase), '12:30:00'),
(15, 2, 22, 2, DATEADD(day, -2, @FechaBase), '12:35:00'),
(10, 2, 22, 2, DATEADD(day, -2, @FechaBase), '12:40:00'),
(13, 2, 22, 2, DATEADD(day, -2, @FechaBase), '12:45:00'),

(21, 3, 22, 2, DATEADD(day, -2, @FechaBase), '12:50:00'),
(18, 3, 22, 2, DATEADD(day, -2, @FechaBase), '12:55:00'),
(19, 3, 22, 2, DATEADD(day, -2, @FechaBase), '13:00:00'),

(26, 4, 22, 2, DATEADD(day, -2, @FechaBase), '13:05:00'),
(23, 4, 22, 2, DATEADD(day, -2, @FechaBase), '13:10:00'),
(24, 4, 22, 2, DATEADD(day, -2, @FechaBase), '13:15:00'),

(31, 5, 22, 2, DATEADD(day, -2, @FechaBase), '13:20:00'),
(28, 5, 22, 2, DATEADD(day, -2, @FechaBase), '13:25:00'),
(29, 5, 22, 2, DATEADD(day, -2, @FechaBase), '13:30:00'),

(35, 6, 22, 2, DATEADD(day, -2, @FechaBase), '13:35:00'),
(32, 6, 22, 2, DATEADD(day, -2, @FechaBase), '13:40:00'),
(33, 6, 22, 2, DATEADD(day, -2, @FechaBase), '13:45:00'),

(40, 7, 22, 2, DATEADD(day, -2, @FechaBase), '13:50:00'),
(44, 8, 22, 2, DATEADD(day, -2, @FechaBase), '13:52:00'),
(48, 9, 22, 2, DATEADD(day, -2, @FechaBase), '13:54:00'),
(52, 10, 22, 2, DATEADD(day, -2, @FechaBase), '13:56:00'),
(55, 11, 22, 2, DATEADD(day, -2, @FechaBase), '13:58:00'),
(59, 12, 22, 2, DATEADD(day, -2, @FechaBase), '14:00:00');

INSERT INTO Registros (IdEmpleado, IdEmpresa, IdServicio, IdLugar, Fecha, Hora) VALUES 

(1, 1, 23, 1, DATEADD(day, -1, @FechaBase), '12:06:00'),
(2, 1, 23, 1, DATEADD(day, -1, @FechaBase), '12:09:00'),
(3, 1, 23, 1, DATEADD(day, -1, @FechaBase), '12:11:00'),
(4, 1, 23, 1, DATEADD(day, -1, @FechaBase), '12:13:00'),
(5, 1, 23, 1, DATEADD(day, -1, @FechaBase), '12:16:00'),
(6, 1, 23, 1, DATEADD(day, -1, @FechaBase), '12:19:00'),
(7, 1, 23, 1, DATEADD(day, -1, @FechaBase), '12:21:00'),
(8, 1, 23, 1, DATEADD(day, -1, @FechaBase), '12:23:00'),

(9, 2, 23, 1, DATEADD(day, -1, @FechaBase), '12:26:00'),
(10, 2, 23, 1, DATEADD(day, -1, @FechaBase), '12:28:00'),
(11, 2, 23, 1, DATEADD(day, -1, @FechaBase), '12:31:00'),
(12, 2, 23, 1, DATEADD(day, -1, @FechaBase), '12:33:00'),
(13, 2, 23, 1, DATEADD(day, -1, @FechaBase), '12:36:00'),

(16, 3, 23, 1, DATEADD(day, -1, @FechaBase), '12:39:00'),
(17, 3, 23, 1, DATEADD(day, -1, @FechaBase), '12:41:00'),
(18, 3, 23, 1, DATEADD(day, -1, @FechaBase), '12:44:00'),
(19, 3, 23, 1, DATEADD(day, -1, @FechaBase), '12:46:00'),
(20, 3, 23, 1, DATEADD(day, -1, @FechaBase), '12:49:00'),
(21, 3, 23, 1, DATEADD(day, -1, @FechaBase), '12:51:00'),

(22, 4, 23, 1, DATEADD(day, -1, @FechaBase), '12:54:00'),
(23, 4, 23, 1, DATEADD(day, -1, @FechaBase), '12:56:00'),
(24, 4, 23, 1, DATEADD(day, -1, @FechaBase), '12:59:00'),
(25, 4, 23, 1, DATEADD(day, -1, @FechaBase), '13:01:00'),

(27, 5, 23, 1, DATEADD(day, -1, @FechaBase), '13:04:00'),
(28, 5, 23, 1, DATEADD(day, -1, @FechaBase), '13:06:00'),
(29, 5, 23, 1, DATEADD(day, -1, @FechaBase), '13:09:00'),
(30, 5, 23, 1, DATEADD(day, -1, @FechaBase), '13:11:00'),
(31, 5, 23, 1, DATEADD(day, -1, @FechaBase), '13:14:00'),

(32, 6, 23, 1, DATEADD(day, -1, @FechaBase), '13:16:00'),
(33, 6, 23, 1, DATEADD(day, -1, @FechaBase), '13:19:00'),
(34, 6, 23, 1, DATEADD(day, -1, @FechaBase), '13:21:00'),
(35, 6, 23, 1, DATEADD(day, -1, @FechaBase), '13:24:00'),

(36, 7, 23, 1, DATEADD(day, -1, @FechaBase), '13:26:00'),
(37, 7, 23, 1, DATEADD(day, -1, @FechaBase), '13:29:00'),
(38, 7, 23, 1, DATEADD(day, -1, @FechaBase), '13:31:00'),
(39, 7, 23, 1, DATEADD(day, -1, @FechaBase), '13:34:00'),
(40, 7, 23, 1, DATEADD(day, -1, @FechaBase), '13:36:00'),

(41, 8, 23, 1, DATEADD(day, -1, @FechaBase), '13:39:00'),
(42, 8, 23, 1, DATEADD(day, -1, @FechaBase), '13:41:00'),
(43, 8, 23, 1, DATEADD(day, -1, @FechaBase), '13:44:00'),

(45, 9, 23, 1, DATEADD(day, -1, @FechaBase), '13:46:00'),
(46, 9, 23, 1, DATEADD(day, -1, @FechaBase), '13:49:00'),
(47, 9, 23, 1, DATEADD(day, -1, @FechaBase), '13:51:00'),
(48, 9, 23, 1, DATEADD(day, -1, @FechaBase), '13:54:00'),

(49, 10, 23, 1, DATEADD(day, -1, @FechaBase), '13:56:00'),
(50, 10, 23, 1, DATEADD(day, -1, @FechaBase), '13:59:00'),
(51, 10, 23, 1, DATEADD(day, -1, @FechaBase), '14:01:00'),

(53, 11, 23, 1, DATEADD(day, -1, @FechaBase), '14:04:00'),
(54, 11, 23, 1, DATEADD(day, -1, @FechaBase), '14:06:00'),

(57, 12, 23, 1, DATEADD(day, -1, @FechaBase), '14:09:00'),
(58, 12, 23, 1, DATEADD(day, -1, @FechaBase), '14:11:00'),
(59, 12, 23, 1, DATEADD(day, -1, @FechaBase), '14:14:00');

INSERT INTO Registros (IdEmpleado, IdEmpresa, IdServicio, IdLugar, Fecha, Hora) VALUES 

(6, 1, 24, 2, DATEADD(day, -1, @FechaBase), '12:12:00'),
(8, 1, 24, 2, DATEADD(day, -1, @FechaBase), '12:17:00'),
(1, 1, 24, 2, DATEADD(day, -1, @FechaBase), '12:22:00'),
(3, 1, 24, 2, DATEADD(day, -1, @FechaBase), '12:27:00'),

(14, 2, 24, 2, DATEADD(day, -1, @FechaBase), '12:32:00'),
(15, 2, 24, 2, DATEADD(day, -1, @FechaBase), '12:37:00'),
(9, 2, 24, 2, DATEADD(day, -1, @FechaBase), '12:42:00'),
(11, 2, 24, 2, DATEADD(day, -1, @FechaBase), '12:47:00'),

(16, 3, 24, 2, DATEADD(day, -1, @FechaBase), '12:52:00'),
(17, 3, 24, 2, DATEADD(day, -1, @FechaBase), '12:57:00'),
(20, 3, 24, 2, DATEADD(day, -1, @FechaBase), '13:02:00'),

(22, 4, 24, 2, DATEADD(day, -1, @FechaBase), '13:07:00'),
(26, 4, 24, 2, DATEADD(day, -1, @FechaBase), '13:12:00'),
(25, 4, 24, 2, DATEADD(day, -1, @FechaBase), '13:17:00'),

(27, 5, 24, 2, DATEADD(day, -1, @FechaBase), '13:22:00'),
(30, 5, 24, 2, DATEADD(day, -1, @FechaBase), '13:27:00'),
(31, 5, 24, 2, DATEADD(day, -1, @FechaBase), '13:32:00'),

(32, 6, 24, 2, DATEADD(day, -1, @FechaBase), '13:37:00'),
(35, 6, 24, 2, DATEADD(day, -1, @FechaBase), '13:42:00'),
(34, 6, 24, 2, DATEADD(day, -1, @FechaBase), '13:47:00'),

(36, 7, 24, 2, DATEADD(day, -1, @FechaBase), '13:52:00'),
(39, 7, 24, 2, DATEADD(day, -1, @FechaBase), '13:54:00'),
(37, 7, 24, 2, DATEADD(day, -1, @FechaBase), '13:56:00'),

(41, 8, 24, 2, DATEADD(day, -1, @FechaBase), '13:58:00'),
(44, 8, 24, 2, DATEADD(day, -1, @FechaBase), '14:00:00'),

(45, 9, 24, 2, DATEADD(day, -1, @FechaBase), '14:02:00'),
(48, 9, 24, 2, DATEADD(day, -1, @FechaBase), '14:04:00'),

(49, 10, 24, 2, DATEADD(day, -1, @FechaBase), '14:06:00'),
(52, 10, 24, 2, DATEADD(day, -1, @FechaBase), '14:08:00'),
(51, 10, 24, 2, DATEADD(day, -1, @FechaBase), '14:10:00'),

(53, 11, 24, 2, DATEADD(day, -1, @FechaBase), '14:12:00'),
(56, 11, 24, 2, DATEADD(day, -1, @FechaBase), '14:14:00'),
(54, 11, 24, 2, DATEADD(day, -1, @FechaBase), '14:16:00'),

(57, 12, 24, 2, DATEADD(day, -1, @FechaBase), '14:18:00'),
(58, 12, 24, 2, DATEADD(day, -1, @FechaBase), '14:20:00'),
(60, 12, 24, 2, DATEADD(day, -1, @FechaBase), '14:22:00');

GO

-- =============================================
-- VERIFICACIÓN DE DATOS
-- =============================================
PRINT '================================================';
PRINT 'RESUMEN DE DATOS INSERTADOS:';
PRINT '================================================';
PRINT 'Lugares: ' + CAST((SELECT COUNT(*) FROM Lugares) AS VARCHAR(10));
PRINT 'Empresas: ' + CAST((SELECT COUNT(*) FROM Empresas) AS VARCHAR(10));
PRINT 'Empleados: ' + CAST((SELECT COUNT(*) FROM Empleados WHERE Estado = 1) AS VARCHAR(10));
PRINT 'Servicios: ' + CAST((SELECT COUNT(*) FROM Servicios) AS VARCHAR(10));
PRINT 'Registros: ' + CAST((SELECT COUNT(*) FROM Registros) AS VARCHAR(10));
PRINT '================================================';
PRINT '';
PRINT 'Datos de prueba listos para usar en reportes!';
PRINT '================================================';
GO
