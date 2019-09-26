CREATE TABLE [dbo].[tbl_sucursal] (
    [IdSucursal]     INT            NOT NULL,
    [su_codigo]      VARCHAR (10)   NULL,
    [su_descripcion] VARCHAR (1000) NOT NULL,
    [estado]         BIT            NOT NULL,
    CONSTRAINT [PK_tbl_sucursal] PRIMARY KEY CLUSTERED ([IdSucursal] ASC)
);

