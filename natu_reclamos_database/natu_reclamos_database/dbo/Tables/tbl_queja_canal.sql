CREATE TABLE [dbo].[tbl_queja_canal] (
    [IdQueja_canal]  INT           NOT NULL,
    [qc_descripcion] VARCHAR (500) NOT NULL,
    [estado]         BIT           NOT NULL,
    CONSTRAINT [PK_tbl_queja_canal] PRIMARY KEY CLUSTERED ([IdQueja_canal] ASC)
);

