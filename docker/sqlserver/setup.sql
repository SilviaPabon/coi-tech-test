-- Crear base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CoiDB')
BEGIN
    CREATE DATABASE CoiDB;
END
GO

USE CoiDB;
GO

-- Crear tablas
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Products')
BEGIN
    CREATE TABLE Products (
        id INT IDENTITY(1,1) PRIMARY KEY,
        name NVARCHAR(150) NOT NULL,
        description NVARCHAR(MAX) NULL,
        price DECIMAL(18, 2) NOT NULL,
        dateCreation DATETIME2 DEFAULT GETDATE(),
        dateUpdate DATETIME2 DEFAULT GETDATE(),
        status BIT DEFAULT 1
    );
END
GO

-- Este bloque se ejecutará solo en desarrollo para popular la base de datos
-- Cambiar la variable @IsDevelopment a 0 para entorno de producción
DECLARE @IsDevelopment BIT = 1;

IF @IsDevelopment = 1
BEGIN
    -- Insertar datos de ejemplo para productos
    IF NOT EXISTS (SELECT TOP 1 * FROM Products)
    BEGIN
        INSERT INTO Products (name, description, price)
        VALUES 
            ('Laptop', 'High performance laptop with 16GB RAM', 1299.99),
            ('Smartphone', 'Latest model with 128GB storage', 699.99),
            ('Tablet', '10 inch display with 64GB storage', 399.99),
            ('Headphones', 'Wireless noise cancelling headphones', 199.99),
            ('Monitor', '27 inch 4K monitor', 349.99);
    END
END

PRINT 'La base de datos ha sido inicializada correctamente.'
GO