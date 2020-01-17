﻿CREATE TABLE [dbo].[tbl_queja] (
    [IdQueja]         NUMERIC (18)  NOT NULL,
    [IdQueja_canal]   INT           NOT NULL,
    [IdQueja_origen]  INT           NOT NULL,
    [IdSucursal]      INT           NOT NULL,
    [IdDepartamento]  INT           NOT NULL,
    [IdQueja_tipo]    INT           NOT NULL,
    [IdQueja_motivo]  INT           NOT NULL,
    [IdQueja_estado]  INT           NOT NULL,
    [qu_detalle]      VARCHAR (MAX) NULL,
    [qu_solucion]     VARCHAR (MAX) NULL,
    [qu_fecha]        DATETIME      NOT NULL,
    [qu_fecha_evento] DATETIME      NULL,
    [IdMes]           INT           NOT NULL,
    [qu_anio]         INT           NOT NULL,
    [cl_nombre]       VARCHAR (500) NULL,
    [cl_telefono]     VARCHAR (200) NULL,
    [cl_correo]       VARCHAR (500) NULL,
    [IdUsuario]       VARCHAR (50)  NOT NULL,
    [IdUsuarioCierre] VARCHAR (50)  NULL,
    [estado]          BIT           NOT NULL,
    CONSTRAINT [PK_tbl_queja] PRIMARY KEY CLUSTERED ([IdQueja] ASC),
    CONSTRAINT [FK_tbl_queja_tbl_departamento] FOREIGN KEY ([IdDepartamento]) REFERENCES [dbo].[tbl_departamento] ([IdDepartamento]),
    CONSTRAINT [FK_tbl_queja_tbl_mes] FOREIGN KEY ([IdMes]) REFERENCES [dbo].[tbl_mes] ([IdMes]),
    CONSTRAINT [FK_tbl_queja_tbl_queja_canal] FOREIGN KEY ([IdQueja_canal]) REFERENCES [dbo].[tbl_queja_canal] ([IdQueja_canal]),
    CONSTRAINT [FK_tbl_queja_tbl_queja_estado] FOREIGN KEY ([IdQueja_estado]) REFERENCES [dbo].[tbl_queja_estado] ([IdQueja_estado]),
    CONSTRAINT [FK_tbl_queja_tbl_queja_origen] FOREIGN KEY ([IdQueja_origen]) REFERENCES [dbo].[tbl_queja_origen] ([IdQueja_origen]),
    CONSTRAINT [FK_tbl_queja_tbl_queja_tipo] FOREIGN KEY ([IdQueja_tipo]) REFERENCES [dbo].[tbl_queja_tipo] ([IdQueja_tipo]),
    CONSTRAINT [FK_tbl_queja_tbl_queja_tipo_motivo] FOREIGN KEY ([IdQueja_motivo]) REFERENCES [dbo].[tbl_queja_tipo_motivo] ([IdQueja_motivo]),
    CONSTRAINT [FK_tbl_queja_tbl_sucursal] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[tbl_sucursal] ([IdSucursal]),
    CONSTRAINT [FK_tbl_queja_tbl_usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[tbl_usuario] ([IdUsuario])
);
