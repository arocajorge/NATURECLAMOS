CREATE TABLE [dbo].[tbl_mes] (
    [IdMes]          INT          NOT NULL,
    [me_descripcion] VARCHAR (50) NOT NULL,
    [me_codigo]      VARCHAR (30) NULL,
    CONSTRAINT [PK_tbl_mes] PRIMARY KEY CLUSTERED ([IdMes] ASC)
);

