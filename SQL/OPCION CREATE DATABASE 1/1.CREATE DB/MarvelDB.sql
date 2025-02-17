IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'MarvelDB')
BEGIN
    CREATE DATABASE MarvelDB;
    PRINT 'Base de datos MarvelDB creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La base de datos MarvelDB ya existe.';
END
GO