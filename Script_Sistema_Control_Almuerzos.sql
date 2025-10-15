-- =====================================================
-- SISTEMA DE CONTROL DE ALMUERZOS - SCRIPT DE BASE DE DATOS
-- =====================================================

-- Creación de la base de datos
CREATE DATABASE BD_Control_Almuerzos;
GO

USE BD_Control_Almuerzos;
GO

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
    -- Proyección prevista de comensales para el servicio (opcional)
    Proyeccion INT NULL,
    -- Duración total del servicio en minutos (se gestiona con cronómetro desde backend)
    DuracionMinutos INT NULL,
    TotalComensales INT DEFAULT 0,
    TotalInvitados INT DEFAULT 0,
    FOREIGN KEY (IdLugar) REFERENCES Lugares(IdLugar),
    CONSTRAINT CK_Servicios_Fecha CHECK (Fecha <= CAST(GETDATE() AS DATE))
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

-- =============================================
-- DATOS INICIALES
-- =============================================
-- Los datos de prueba se encuentran en el archivo: Datos_Iniciales.sql
-- Ese archivo contiene:
--   - 2 Lugares (Comedor y Quincho)
--   - 12 Empresas (Roemmers, Southex, y otras del predio)
--   - 60 Empleados distribuidos entre las empresas
--   - 24 Servicios (últimas 2 semanas con TODAS las columnas completas)
--   - 150+ Registros de asistencia detallados
--
-- IMPORTANTE: Ejecutar Datos_Iniciales.sql DESPUÉS de crear las tablas
-- para cargar datos de prueba completos y funcionales para los reportes.
-- =============================================

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
- Servicios: representa cada jornada realizada en comedor o quincho. Incluye Proyección (estimación de comensales) y Duración total en minutos (gestionada por cronómetro en backend).
- Registros: guarda cada asistencia vinculada a un servicio
*/

