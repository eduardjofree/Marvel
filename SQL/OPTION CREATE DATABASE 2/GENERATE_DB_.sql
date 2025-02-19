USE [master]
GO
/****** Object:  Database [MarvelDB]    Script Date: 17/02/2025 3:35:38 p. m. ******/
CREATE DATABASE [MarvelDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MarvelDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MarvelDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MarvelDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MarvelDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MarvelDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MarvelDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MarvelDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MarvelDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MarvelDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MarvelDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MarvelDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MarvelDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MarvelDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MarvelDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MarvelDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MarvelDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MarvelDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MarvelDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MarvelDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MarvelDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MarvelDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MarvelDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MarvelDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MarvelDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MarvelDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MarvelDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MarvelDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MarvelDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MarvelDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MarvelDB] SET  MULTI_USER 
GO
ALTER DATABASE [MarvelDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MarvelDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MarvelDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MarvelDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MarvelDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MarvelDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MarvelDB] SET QUERY_STORE = OFF
GO
USE [MarvelDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17/02/2025 3:35:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavoriteComics]    Script Date: 17/02/2025 3:35:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoriteComics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ComicId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17/02/2025 3:35:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
	[Identificacion] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250214224618_InitialCreate', N'9.0.2')
GO
USE [master]
GO
ALTER DATABASE [MarvelDB] SET  READ_WRITE 
GO
