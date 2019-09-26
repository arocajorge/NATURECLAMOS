CREATE TABLE [dbo].[tbl_queja_estado] (
    [IdQueja_estado] INT            NOT NULL,
    [qe_descripcion] VARCHAR (1000) NOT NULL,
    [qe_se_modifica] BIT            NOT NULL,
    [estado]         BIT            NOT NULL,
    CONSTRAINT [PK_tbl_queja_estado] PRIMARY KEY CLUSTERED ([IdQueja_estado] ASC)
);

