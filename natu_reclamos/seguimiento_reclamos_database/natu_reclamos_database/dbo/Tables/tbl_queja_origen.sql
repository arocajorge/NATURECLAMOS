CREATE TABLE [dbo].[tbl_queja_origen] (
    [IdQueja_origen] INT           NOT NULL,
    [qo_descripcion] VARCHAR (500) NOT NULL,
    [estado]         BIT           NOT NULL,
    CONSTRAINT [PK_tbl_queja_origen] PRIMARY KEY CLUSTERED ([IdQueja_origen] ASC)
);

