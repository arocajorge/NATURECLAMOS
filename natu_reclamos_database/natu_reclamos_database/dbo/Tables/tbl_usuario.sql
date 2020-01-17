CREATE TABLE [dbo].[tbl_usuario] (
    [IdUsuario]      VARCHAR (50)  NOT NULL,
    [us_contrasenia] VARCHAR (200) NOT NULL,
    [us_nombre]      VARCHAR (500) NULL,
    [us_tipo]        VARCHAR (50)  NULL,
    [us_estado]      BIT           NOT NULL,
    CONSTRAINT [PK_tbl_usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);





