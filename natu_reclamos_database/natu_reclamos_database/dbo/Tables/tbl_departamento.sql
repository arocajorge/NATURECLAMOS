CREATE TABLE [dbo].[tbl_departamento] (
    [IdDepartamento] INT           NOT NULL,
    [de_descripcion] VARCHAR (500) NOT NULL,
    [estado]         BIT           NOT NULL,
    CONSTRAINT [PK_tbl_departamento] PRIMARY KEY CLUSTERED ([IdDepartamento] ASC)
);

