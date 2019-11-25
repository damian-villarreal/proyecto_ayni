
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/25/2019 01:51:23
-- Generated from EDMX file: C:\Users\Manu\source\repos\ayni\ayni\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Proyecto_Ayni];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Postulacion_Publicacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Postulacion] DROP CONSTRAINT [FK_Postulacion_Publicacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Postulacion_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Postulacion] DROP CONSTRAINT [FK_Postulacion_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Pregunta_Publicacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregunta] DROP CONSTRAINT [FK_Pregunta_Publicacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Pregunta_Respuesta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregunta] DROP CONSTRAINT [FK_Pregunta_Respuesta];
GO
IF OBJECT_ID(N'[dbo].[FK_Pregunta_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregunta] DROP CONSTRAINT [FK_Pregunta_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Publicacion_Categoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publicacion] DROP CONSTRAINT [FK_Publicacion_Categoria];
GO
IF OBJECT_ID(N'[dbo].[FK_Publicacion_EstadoPublicacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publicacion] DROP CONSTRAINT [FK_Publicacion_EstadoPublicacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Publicacion_TipoPublicacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publicacion] DROP CONSTRAINT [FK_Publicacion_TipoPublicacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Publicacion_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publicacion] DROP CONSTRAINT [FK_Publicacion_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Respuesta_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Respuesta] DROP CONSTRAINT [FK_Respuesta_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Saldo_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Saldo] DROP CONSTRAINT [FK_Saldo_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Transaccion_EstadoTransaccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaccion] DROP CONSTRAINT [FK_Transaccion_EstadoTransaccion];
GO
IF OBJECT_ID(N'[dbo].[FK_Transaccion_Publicacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaccion] DROP CONSTRAINT [FK_Transaccion_Publicacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Transaccion_Usuario_Ofrece]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaccion] DROP CONSTRAINT [FK_Transaccion_Usuario_Ofrece];
GO
IF OBJECT_ID(N'[dbo].[FK_Transaccion_Usuario_Recibe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaccion] DROP CONSTRAINT [FK_Transaccion_Usuario_Recibe];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categoria];
GO
IF OBJECT_ID(N'[dbo].[EstadoPublicacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoPublicacion];
GO
IF OBJECT_ID(N'[dbo].[EstadoTransaccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoTransaccion];
GO
IF OBJECT_ID(N'[dbo].[Postulacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Postulacion];
GO
IF OBJECT_ID(N'[dbo].[Pregunta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pregunta];
GO
IF OBJECT_ID(N'[dbo].[Publicacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publicacion];
GO
IF OBJECT_ID(N'[dbo].[Respuesta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Respuesta];
GO
IF OBJECT_ID(N'[dbo].[Saldo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Saldo];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TipoPublicacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoPublicacion];
GO
IF OBJECT_ID(N'[dbo].[Transaccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transaccion];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categoria'
CREATE TABLE [dbo].[Categoria] (
    [idCategoria] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'EstadoPublicacion'
CREATE TABLE [dbo].[EstadoPublicacion] (
    [idEstadoPublicacion] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'EstadoTransaccion'
CREATE TABLE [dbo].[EstadoTransaccion] (
    [idEstadoTransaccion] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Publicacion'
CREATE TABLE [dbo].[Publicacion] (
    [idPublicacion] int IDENTITY(1,1) NOT NULL,
    [Titulo] varchar(50)  NOT NULL,
    [idUsuario] int  NOT NULL,
    [Valor] int  NOT NULL,
    [idTipoPublicacion] int  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Fecha_publicacion] datetime  NOT NULL,
    [Fecha_fin] datetime  NULL,
    [idEstadoPublicacion] int  NOT NULL,
    [Fecha_inicio] datetime  NULL,
    [idCategoria] int  NOT NULL,
    [Ubicacion] nchar(100)  NULL,
    [Imagen] nvarchar(max)  NULL
);
GO

-- Creating table 'TipoPublicacion'
CREATE TABLE [dbo].[TipoPublicacion] (
    [idTipoPublicacion] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nchar(10)  NOT NULL
);
GO

-- Creating table 'Transaccion'
CREATE TABLE [dbo].[Transaccion] (
    [idTransacion] int IDENTITY(1,1) NOT NULL,
    [idUsuarioOfrece] int  NOT NULL,
    [idUsuarioRecibe] int  NOT NULL,
    [idPublicacion] int  NOT NULL,
    [idEstadoTransaccion] int  NOT NULL,
    [confirm_ofrece] bit  NULL,
    [confirm_recibe] bit  NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [idUsuario] int IDENTITY(1,1) NOT NULL,
    [NombreUsuario] nvarchar(50)  NOT NULL,
    [CantidadFavoresRealizados] int  NOT NULL,
    [CantidadFavoresRecibidos] int  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [PrivateKey] nvarchar(max)  NULL,
    [Words] nvarchar(max)  NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Apellido] nchar(50)  NOT NULL,
    [Calificación] decimal(10,2)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Postulacion'
CREATE TABLE [dbo].[Postulacion] (
    [idPostulacion] int IDENTITY(1,1) NOT NULL,
    [idPublicacion] int  NOT NULL,
    [idPostulante] int  NOT NULL,
    [Aceptado] bit  NOT NULL,
    [fecha] datetime  NOT NULL
);
GO

-- Creating table 'Saldo'
CREATE TABLE [dbo].[Saldo] (
    [IdUsuario] int  NOT NULL,
    [Cantidad] int  NULL
);
GO

-- Creating table 'Pregunta'
CREATE TABLE [dbo].[Pregunta] (
    [idPregunta] int IDENTITY(1,1) NOT NULL,
    [IdPublicacion] int  NOT NULL,
    [idUsuario] int  NOT NULL,
    [Descripcion] nvarchar(max)  NULL,
    [Fecha] datetime  NULL,
    [idRespuesta] int  NULL
);
GO

-- Creating table 'Respuesta'
CREATE TABLE [dbo].[Respuesta] (
    [idRespuesta] int IDENTITY(1,1) NOT NULL,
    [idUsuario] int  NULL,
    [Fecha] datetime  NULL,
    [Descripcion] nchar(10)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idCategoria] in table 'Categoria'
ALTER TABLE [dbo].[Categoria]
ADD CONSTRAINT [PK_Categoria]
    PRIMARY KEY CLUSTERED ([idCategoria] ASC);
GO

-- Creating primary key on [idEstadoPublicacion] in table 'EstadoPublicacion'
ALTER TABLE [dbo].[EstadoPublicacion]
ADD CONSTRAINT [PK_EstadoPublicacion]
    PRIMARY KEY CLUSTERED ([idEstadoPublicacion] ASC);
GO

-- Creating primary key on [idEstadoTransaccion] in table 'EstadoTransaccion'
ALTER TABLE [dbo].[EstadoTransaccion]
ADD CONSTRAINT [PK_EstadoTransaccion]
    PRIMARY KEY CLUSTERED ([idEstadoTransaccion] ASC);
GO

-- Creating primary key on [idPublicacion] in table 'Publicacion'
ALTER TABLE [dbo].[Publicacion]
ADD CONSTRAINT [PK_Publicacion]
    PRIMARY KEY CLUSTERED ([idPublicacion] ASC);
GO

-- Creating primary key on [idTipoPublicacion] in table 'TipoPublicacion'
ALTER TABLE [dbo].[TipoPublicacion]
ADD CONSTRAINT [PK_TipoPublicacion]
    PRIMARY KEY CLUSTERED ([idTipoPublicacion] ASC);
GO

-- Creating primary key on [idTransacion] in table 'Transaccion'
ALTER TABLE [dbo].[Transaccion]
ADD CONSTRAINT [PK_Transaccion]
    PRIMARY KEY CLUSTERED ([idTransacion] ASC);
GO

-- Creating primary key on [idUsuario] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([idUsuario] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [idPostulacion] in table 'Postulacion'
ALTER TABLE [dbo].[Postulacion]
ADD CONSTRAINT [PK_Postulacion]
    PRIMARY KEY CLUSTERED ([idPostulacion] ASC);
GO

-- Creating primary key on [IdUsuario] in table 'Saldo'
ALTER TABLE [dbo].[Saldo]
ADD CONSTRAINT [PK_Saldo]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- Creating primary key on [idPregunta] in table 'Pregunta'
ALTER TABLE [dbo].[Pregunta]
ADD CONSTRAINT [PK_Pregunta]
    PRIMARY KEY CLUSTERED ([idPregunta] ASC);
GO

-- Creating primary key on [idRespuesta] in table 'Respuesta'
ALTER TABLE [dbo].[Respuesta]
ADD CONSTRAINT [PK_Respuesta]
    PRIMARY KEY CLUSTERED ([idRespuesta] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idEstadoPublicacion] in table 'Publicacion'
ALTER TABLE [dbo].[Publicacion]
ADD CONSTRAINT [FK_Publicacion_EstadoPublicacion]
    FOREIGN KEY ([idEstadoPublicacion])
    REFERENCES [dbo].[EstadoPublicacion]
        ([idEstadoPublicacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Publicacion_EstadoPublicacion'
CREATE INDEX [IX_FK_Publicacion_EstadoPublicacion]
ON [dbo].[Publicacion]
    ([idEstadoPublicacion]);
GO

-- Creating foreign key on [idEstadoTransaccion] in table 'Transaccion'
ALTER TABLE [dbo].[Transaccion]
ADD CONSTRAINT [FK_Transaccion_EstadoTransaccion]
    FOREIGN KEY ([idEstadoTransaccion])
    REFERENCES [dbo].[EstadoTransaccion]
        ([idEstadoTransaccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transaccion_EstadoTransaccion'
CREATE INDEX [IX_FK_Transaccion_EstadoTransaccion]
ON [dbo].[Transaccion]
    ([idEstadoTransaccion]);
GO

-- Creating foreign key on [idTipoPublicacion] in table 'Publicacion'
ALTER TABLE [dbo].[Publicacion]
ADD CONSTRAINT [FK_Publicacion_TipoPublicacion]
    FOREIGN KEY ([idTipoPublicacion])
    REFERENCES [dbo].[TipoPublicacion]
        ([idTipoPublicacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Publicacion_TipoPublicacion'
CREATE INDEX [IX_FK_Publicacion_TipoPublicacion]
ON [dbo].[Publicacion]
    ([idTipoPublicacion]);
GO

-- Creating foreign key on [idUsuario] in table 'Publicacion'
ALTER TABLE [dbo].[Publicacion]
ADD CONSTRAINT [FK_Publicacion_Usuario]
    FOREIGN KEY ([idUsuario])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Publicacion_Usuario'
CREATE INDEX [IX_FK_Publicacion_Usuario]
ON [dbo].[Publicacion]
    ([idUsuario]);
GO

-- Creating foreign key on [idPublicacion] in table 'Transaccion'
ALTER TABLE [dbo].[Transaccion]
ADD CONSTRAINT [FK_Transaccion_Publicacion]
    FOREIGN KEY ([idPublicacion])
    REFERENCES [dbo].[Publicacion]
        ([idPublicacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transaccion_Publicacion'
CREATE INDEX [IX_FK_Transaccion_Publicacion]
ON [dbo].[Transaccion]
    ([idPublicacion]);
GO

-- Creating foreign key on [idUsuarioOfrece] in table 'Transaccion'
ALTER TABLE [dbo].[Transaccion]
ADD CONSTRAINT [FK_Transaccion_Usuario_Ofrece]
    FOREIGN KEY ([idUsuarioOfrece])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transaccion_Usuario_Ofrece'
CREATE INDEX [IX_FK_Transaccion_Usuario_Ofrece]
ON [dbo].[Transaccion]
    ([idUsuarioOfrece]);
GO

-- Creating foreign key on [idUsuarioRecibe] in table 'Transaccion'
ALTER TABLE [dbo].[Transaccion]
ADD CONSTRAINT [FK_Transaccion_Usuario_Recibe]
    FOREIGN KEY ([idUsuarioRecibe])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transaccion_Usuario_Recibe'
CREATE INDEX [IX_FK_Transaccion_Usuario_Recibe]
ON [dbo].[Transaccion]
    ([idUsuarioRecibe]);
GO

-- Creating foreign key on [idCategoria] in table 'Publicacion'
ALTER TABLE [dbo].[Publicacion]
ADD CONSTRAINT [FK_Publicacion_Categoria]
    FOREIGN KEY ([idCategoria])
    REFERENCES [dbo].[Categoria]
        ([idCategoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Publicacion_Categoria'
CREATE INDEX [IX_FK_Publicacion_Categoria]
ON [dbo].[Publicacion]
    ([idCategoria]);
GO

-- Creating foreign key on [idPublicacion] in table 'Postulacion'
ALTER TABLE [dbo].[Postulacion]
ADD CONSTRAINT [FK_Postulacion_Publicacion]
    FOREIGN KEY ([idPublicacion])
    REFERENCES [dbo].[Publicacion]
        ([idPublicacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Postulacion_Publicacion'
CREATE INDEX [IX_FK_Postulacion_Publicacion]
ON [dbo].[Postulacion]
    ([idPublicacion]);
GO

-- Creating foreign key on [idPostulante] in table 'Postulacion'
ALTER TABLE [dbo].[Postulacion]
ADD CONSTRAINT [FK_Postulacion_Usuario]
    FOREIGN KEY ([idPostulante])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Postulacion_Usuario'
CREATE INDEX [IX_FK_Postulacion_Usuario]
ON [dbo].[Postulacion]
    ([idPostulante]);
GO

-- Creating foreign key on [IdUsuario] in table 'Saldo'
ALTER TABLE [dbo].[Saldo]
ADD CONSTRAINT [FK_Saldo_Usuario]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdPublicacion] in table 'Pregunta'
ALTER TABLE [dbo].[Pregunta]
ADD CONSTRAINT [FK_Pregunta_Publicacion]
    FOREIGN KEY ([IdPublicacion])
    REFERENCES [dbo].[Publicacion]
        ([idPublicacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pregunta_Publicacion'
CREATE INDEX [IX_FK_Pregunta_Publicacion]
ON [dbo].[Pregunta]
    ([IdPublicacion]);
GO

-- Creating foreign key on [idRespuesta] in table 'Pregunta'
ALTER TABLE [dbo].[Pregunta]
ADD CONSTRAINT [FK_Pregunta_Respuesta]
    FOREIGN KEY ([idRespuesta])
    REFERENCES [dbo].[Respuesta]
        ([idRespuesta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pregunta_Respuesta'
CREATE INDEX [IX_FK_Pregunta_Respuesta]
ON [dbo].[Pregunta]
    ([idRespuesta]);
GO

-- Creating foreign key on [idUsuario] in table 'Pregunta'
ALTER TABLE [dbo].[Pregunta]
ADD CONSTRAINT [FK_Pregunta_Usuario]
    FOREIGN KEY ([idUsuario])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pregunta_Usuario'
CREATE INDEX [IX_FK_Pregunta_Usuario]
ON [dbo].[Pregunta]
    ([idUsuario]);
GO

-- Creating foreign key on [idUsuario] in table 'Respuesta'
ALTER TABLE [dbo].[Respuesta]
ADD CONSTRAINT [FK_Respuesta_Usuario]
    FOREIGN KEY ([idUsuario])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Respuesta_Usuario'
CREATE INDEX [IX_FK_Respuesta_Usuario]
ON [dbo].[Respuesta]
    ([idUsuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------