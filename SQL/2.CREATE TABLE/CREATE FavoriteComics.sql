USE MarvelDB;
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'FavoriteComics')
BEGIN
    CREATE TABLE dbo.FavoriteComics (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL,
        ComicId INT NOT NULL
    );
    PRINT 'Tabla FavoriteComics creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La tabla FavoriteComics ya existe.';
END
GO

-- Verificar que la tabla se creó correctamente
SELECT * FROM FavoriteComics;