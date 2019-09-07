USE [master]
GO
/****** Object:  Database [Proyecto_Ayni]    Script Date: 07/09/2019 19:42:49 ******/
CREATE DATABASE [Proyecto_Ayni]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Proyecto_Ayni', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Proyecto_Ayni.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Proyecto_Ayni_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Proyecto_Ayni_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Proyecto_Ayni] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Proyecto_Ayni].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Proyecto_Ayni] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET ARITHABORT OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Proyecto_Ayni] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Proyecto_Ayni] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Proyecto_Ayni] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Proyecto_Ayni] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Proyecto_Ayni] SET  MULTI_USER 
GO
ALTER DATABASE [Proyecto_Ayni] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Proyecto_Ayni] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Proyecto_Ayni] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Proyecto_Ayni] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Proyecto_Ayni] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Proyecto_Ayni] SET QUERY_STORE = OFF
GO
USE [Proyecto_Ayni]
GO
/****** Object:  User [sql_seg]    Script Date: 07/09/2019 19:42:49 ******/
CREATE USER [sql_seg] FOR LOGIN [sql_seg] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 07/09/2019 19:42:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoTransaccion]    Script Date: 07/09/2019 19:42:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoTransaccion](
	[idEstadoTransaccion] [int] IDENTITY(1,1) NOT NULL,
	[EstadoTransaccion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoTransaccion] PRIMARY KEY CLUSTERED 
(
	[idEstadoTransaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publicacion]    Script Date: 07/09/2019 19:42:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publicacion](
	[idPublicacion] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[Valor] [int] NULL,
	[idTipoPublicacion] [int] NOT NULL,
 CONSTRAINT [PK_Publicacion] PRIMARY KEY CLUSTERED 
(
	[idPublicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PublicacionCategoria]    Script Date: 07/09/2019 19:42:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublicacionCategoria](
	[idPublicacionCategoria] [int] IDENTITY(1,1) NOT NULL,
	[idPublicacion] [int] NOT NULL,
	[idCategoria] [int] NOT NULL,
 CONSTRAINT [PK_PublicacionCategoria] PRIMARY KEY CLUSTERED 
(
	[idPublicacionCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPublicacion]    Script Date: 07/09/2019 19:42:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPublicacion](
	[idTipoPublicacion] [int] IDENTITY(1,1) NOT NULL,
	[tipoPublicacion] [nchar](10) NOT NULL,
 CONSTRAINT [PK_TipoPublicacion] PRIMARY KEY CLUSTERED 
(
	[idTipoPublicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaccion]    Script Date: 07/09/2019 19:42:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaccion](
	[idTransacion] [int] IDENTITY(1,1) NOT NULL,
	[idUsuarioOfrece] [int] NOT NULL,
	[idUsuarioRecibe] [int] NOT NULL,
	[idPublicacion] [int] NOT NULL,
	[idEstadoTransaccion] [int] NOT NULL,
 CONSTRAINT [PK_Transaccion] PRIMARY KEY CLUSTERED 
(
	[idTransacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 07/09/2019 19:42:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nchar](10) NULL,
	[CantidadFavoresRealizados] [int] NULL,
	[CantidadFavoresRecibidos] [int] NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Publicacion]    Script Date: 07/09/2019 19:42:49 ******/
CREATE NONCLUSTERED INDEX [IX_Publicacion] ON [dbo].[Publicacion]
(
	[idPublicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_TipoPublicacion] FOREIGN KEY([idTipoPublicacion])
REFERENCES [dbo].[TipoPublicacion] ([idTipoPublicacion])
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_TipoPublicacion]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Usuario]
GO
ALTER TABLE [dbo].[PublicacionCategoria]  WITH CHECK ADD  CONSTRAINT [FK_PublicacionCategoria_Categoria] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[PublicacionCategoria] CHECK CONSTRAINT [FK_PublicacionCategoria_Categoria]
GO
ALTER TABLE [dbo].[PublicacionCategoria]  WITH CHECK ADD  CONSTRAINT [FK_PublicacionCategoria_Publicacion] FOREIGN KEY([idPublicacion])
REFERENCES [dbo].[Publicacion] ([idPublicacion])
GO
ALTER TABLE [dbo].[PublicacionCategoria] CHECK CONSTRAINT [FK_PublicacionCategoria_Publicacion]
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [FK_Transaccion_EstadoTransaccion] FOREIGN KEY([idEstadoTransaccion])
REFERENCES [dbo].[EstadoTransaccion] ([idEstadoTransaccion])
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [FK_Transaccion_EstadoTransaccion]
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [FK_Transaccion_Publicacion] FOREIGN KEY([idPublicacion])
REFERENCES [dbo].[Publicacion] ([idPublicacion])
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [FK_Transaccion_Publicacion]
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [FK_Transaccion_Usuario_Ofrece] FOREIGN KEY([idUsuarioOfrece])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [FK_Transaccion_Usuario_Ofrece]
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [FK_Transaccion_Usuario_Recibe] FOREIGN KEY([idUsuarioRecibe])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [FK_Transaccion_Usuario_Recibe]
GO
USE [master]
GO
ALTER DATABASE [Proyecto_Ayni] SET  READ_WRITE 
GO
