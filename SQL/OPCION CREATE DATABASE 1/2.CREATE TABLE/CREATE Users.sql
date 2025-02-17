USE MarvelDB;
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Users')
BEGIN
    CREATE TABLE dbo.Users (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(255) NOT NULL,
        Identificacion NVARCHAR(50) UNIQUE NOT NULL,
        Email NVARCHAR(255) UNIQUE NOT NULL,
        Password NVARCHAR(255) NOT NULL
    );
    PRINT 'Tabla Users creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La tabla Users ya existe.';
END
GO

-- Verificar que la tabla se creó correctamente
SELECT * FROM Users;
