CREATE TABLE [dbo].[tbl_queja_tipo_motivo] (
    [IdQueja_motivo] INT            NOT NULL,
    [IdQueja_tipo]   INT            NOT NULL,
    [qm_descripcion] VARCHAR (1000) NOT NULL,
    [estado]         BIT            NOT NULL,
    CONSTRAINT [PK_tbl_queja_tipo_motivo] PRIMARY KEY CLUSTERED ([IdQueja_motivo] ASC),
    CONSTRAINT [FK_tbl_queja_tipo_motivo_tbl_queja_tipo] FOREIGN KEY ([IdQueja_tipo]) REFERENCES [dbo].[tbl_queja_tipo] ([IdQueja_tipo])
);

