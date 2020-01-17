CREATE TABLE [dbo].[tbl_queja_tipo] (
    [IdQueja_tipo]   INT           NOT NULL,
    [qt_descripcion] VARCHAR (500) NOT NULL,
    [estado]         BIT           NOT NULL,
    CONSTRAINT [PK_tbl_queja_tipo] PRIMARY KEY CLUSTERED ([IdQueja_tipo] ASC)
);

