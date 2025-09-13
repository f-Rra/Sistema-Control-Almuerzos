-- =====================================================
-- SISTEMA DE CONTROL DE ALMUERZOS - SCRIPT DE BASE DE DATOS
-- =====================================================

-- Creación de la base de datos
CREATE DATABASE SistemaControlAlmuerzos;
GO

USE SistemaControlAlmuerzos;
GO

-- Tabla de Usuarios eliminada - Se usa autenticación por lugar con ComboBox

-- Tabla de Empresas del predio
CREATE TABLE Empresas (
    IdEmpresa INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Estado BIT DEFAULT 1
);

-- Tabla de Empleados
CREATE TABLE Empleados (
    IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    IdEmpresa INT NOT NULL,
    IdCredencial VARCHAR(50) NOT NULL UNIQUE,
    Estado BIT DEFAULT 1, 
    FOREIGN KEY (IdEmpresa) REFERENCES Empresas(IdEmpresa)
);

-- Tabla de Lugares disponibles para almorzar
CREATE TABLE Lugares (
    IdLugar INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Estado BIT DEFAULT 1
);

-- Tabla de Servicios (cada jornada)
CREATE TABLE Servicios (
    IdServicio INT IDENTITY(1,1) PRIMARY KEY,
    IdLugar INT NOT NULL,
    Fecha DATE NOT NULL,
    TotalComensales INT DEFAULT 0,
    TotalInvitados INT DEFAULT 0,
    FOREIGN KEY (IdLugar) REFERENCES Lugares(IdLugar),
    CONSTRAINT CK_Servicios_Fecha CHECK (Fecha <= GETDATE())
);

-- Tabla de Registros (cada asistencia)
CREATE TABLE Registros (
    IdRegistro INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT,
    IdEmpresa INT NOT NULL,
    IdServicio INT NOT NULL,
    IdLugar INT NOT NULL,
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado),
    FOREIGN KEY (IdEmpresa) REFERENCES Empresas(IdEmpresa),
    FOREIGN KEY (IdServicio) REFERENCES Servicios(IdServicio),
    FOREIGN KEY (IdLugar) REFERENCES Lugares(IdLugar),
    CONSTRAINT UQ_Registros_Empleado_Servicio UNIQUE (IdEmpleado, IdServicio)
);

-- Datos iniciales
-- Lugares
INSERT INTO Lugares (Nombre) VALUES 
('Comedor'),
('Quincho');

-- Empresas del predio (10 empresas)
INSERT INTO Empresas (Nombre) VALUES 
('Empresa A'),
('Empresa B'),
('Empresa C'),
('Empresa D'),
('Empresa E'),
('Empresa F'),
('Empresa G'),
('Empresa H'),
('Empresa I'),
('Empresa J');

-- Usuarios eliminados - Autenticación por ComboBox de lugares

-- Empleados de prueba (50 empleados distribuidos en las 10 empresas)
INSERT INTO Empleados (Nombre, Apellido, IdEmpresa, IdCredencial) VALUES 
-- Empresa A (5 empleados)
('Juan', 'Pérez', 1, 'RFID001'),
('María', 'García', 1, 'RFID002'),
('Carlos', 'López', 1, 'RFID003'),
('Ana', 'Martínez', 1, 'RFID004'),
('Luis', 'Rodríguez', 1, 'RFID005'),

-- Empresa B (5 empleados)
('Sofía', 'Fernández', 2, 'RFID006'),
('Diego', 'González', 2, 'RFID007'),
('Valentina', 'Silva', 2, 'RFID008'),
('Andrés', 'Morales', 2, 'RFID009'),
('Camila', 'Vargas', 2, 'RFID010'),

-- Empresa C (5 empleados)
('Roberto', 'Herrera', 3, 'RFID011'),
('Patricia', 'Castro', 3, 'RFID012'),
('Miguel', 'Torres', 3, 'RFID013'),
('Isabella', 'Reyes', 3, 'RFID014'),
('Francisco', 'Jiménez', 3, 'RFID015'),

-- Empresa D (5 empleados)
('Daniela', 'Moreno', 4, 'RFID016'),
('Alejandro', 'Ruiz', 4, 'RFID017'),
('Gabriela', 'Díaz', 4, 'RFID018'),
('Ricardo', 'Flores', 4, 'RFID019'),
('Natalia', 'Cruz', 4, 'RFID020'),

-- Empresa E (5 empleados)
('Fernando', 'Ortiz', 5, 'RFID021'),
('Lucía', 'Ramos', 5, 'RFID022'),
('Eduardo', 'Acosta', 5, 'RFID023'),
('Carmen', 'Medina', 5, 'RFID024'),
('Héctor', 'Vega', 5, 'RFID025'),

-- Empresa F (5 empleados)
('Rosa', 'Carrillo', 6, 'RFID026'),
('Manuel', 'Guerrero', 6, 'RFID027'),
('Elena', 'Mendoza', 6, 'RFID028'),
('Alberto', 'Salazar', 6, 'RFID029'),
('Verónica', 'Rojas', 6, 'RFID030'),

-- Empresa G (5 empleados)
('Jorge', 'Paredes', 7, 'RFID031'),
('Adriana', 'Miranda', 7, 'RFID032'),
('Raúl', 'Cortés', 7, 'RFID033'),
('Monica', 'Soto', 7, 'RFID034'),
('Pablo', 'Valdez', 7, 'RFID035'),

-- Empresa H (5 empleados)
('Claudia', 'Espinoza', 8, 'RFID036'),
('Mario', 'Aguilar', 8, 'RFID037'),
('Silvia', 'Villanueva', 8, 'RFID038'),
('Oscar', 'Molina', 8, 'RFID039'),
('Diana', 'Campos', 8, 'RFID040'),

-- Empresa I (5 empleados)
('Arturo', 'Navarro', 9, 'RFID041'),
('Beatriz', 'Figueroa', 9, 'RFID042'),
('César', 'Cordero', 9, 'RFID043'),
('Gloria', 'Aguirre', 9, 'RFID044'),
('Felipe', 'Ponce', 9, 'RFID045'),

-- Empresa J (5 empleados)
('Teresa', 'Palacios', 10, 'RFID046'),
('Rafael', 'Escobar', 10, 'RFID047'),
('Lorena', 'Zúñiga', 10, 'RFID048'),
('Guillermo', 'Fuentes', 10, 'RFID049'),
('Mónica', 'Bravo', 10, 'RFID050');

-- Servicios de prueba (para reportes)
INSERT INTO Servicios (IdLugar, Fecha, TotalComensales, TotalInvitados) VALUES 
-- Comedor - últimos días
(1, DATEADD(day, -1, GETDATE()), 45, 3),
(1, DATEADD(day, -2, GETDATE()), 38, 2),
(1, DATEADD(day, -3, GETDATE()), 42, 1),
(1, DATEADD(day, -4, GETDATE()), 35, 0),
(1, DATEADD(day, -5, GETDATE()), 40, 4),

-- Quincho - últimos días
(2, DATEADD(day, -1, GETDATE()), 32, 1),
(2, DATEADD(day, -2, GETDATE()), 28, 0),
(2, DATEADD(day, -3, GETDATE()), 35, 2),
(2, DATEADD(day, -4, GETDATE()), 30, 1),
(2, DATEADD(day, -5, GETDATE()), 33, 3);

-- Registros de prueba (para mostrar en GridView)
INSERT INTO Registros (IdEmpleado, IdEmpresa, IdServicio, IdLugar, Fecha, Hora) VALUES 
-- Registros del servicio más reciente del comedor
(1, 1, 1, 1, DATEADD(day, -1, GETDATE()), '12:15:00'),
(2, 1, 1, 1, DATEADD(day, -1, GETDATE()), '12:18:00'),
(6, 2, 1, 1, DATEADD(day, -1, GETDATE()), '12:20:00'),
(11, 3, 1, 1, DATEADD(day, -1, GETDATE()), '12:22:00'),
(16, 4, 1, 1, DATEADD(day, -1, GETDATE()), '12:25:00'),

-- Registros del servicio más reciente del quincho
(21, 5, 6, 2, DATEADD(day, -1, GETDATE()), '12:30:00'),
(26, 6, 6, 2, DATEADD(day, -1, GETDATE()), '12:32:00'),
(31, 7, 6, 2, DATEADD(day, -1, GETDATE()), '12:35:00'),
(36, 8, 6, 2, DATEADD(day, -1, GETDATE()), '12:38:00'),
(41, 9, 6, 2, DATEADD(day, -1, GETDATE()), '12:40:00');

/*
RELACIONES DEL MODELO:
- Empresas (1) → Empleados (N)
- Lugares (1) → Servicios (N)
- Empleados (1) → Registros (N)
- Empresas (1) → Registros (N)
- Servicios (1) → Registros (N)
- Lugares (1) → Registros (N)

DESCRIPCIÓN DE TABLAS:
- Empleados: almacena la información de cada empleado con su credencial RFID
- Empresas: contiene los datos de las empresas del predio
- Lugares: Contiene los datos de los lugares disponibles para almorzar (Comedor, Quincho)
- Servicios: representa cada jornada realizada en comedor o quincho
- Registros: guarda cada asistencia vinculada a un servicio

RESTRICCIONES IMPORTANTES:
- Un empleado no puede registrarse dos veces en el mismo servicio
- Las fechas de servicios no pueden ser futuras
- La autenticación se realiza por selección de lugar (ComboBox)
- Comedor y Quincho: acceso directo sin contraseña
- Administrador: contraseña hardcodeada en código (admin123)

MODELO DE AUTENTICACIÓN:
- Sin tabla Usuarios en base de datos
- ComboBox con opciones: Comedor, Quincho, Administrador
- Campo contraseña visible solo para Administrador
- Validación de contraseña en código para rol admin
*/
