CREATE TABLE [dbo].[tbl_reporte_no_conformidad_tipo] (
    [IdNoConformidad_tipo] INT           NOT NULL,
    [nt_descripcion]       VARCHAR (200) NOT NULL,
    [estado]               BIT           NOT NULL,
    CONSTRAINT [PK_tbl_reporte_no_conformidad_tipo] PRIMARY KEY CLUSTERED ([IdNoConformidad_tipo] ASC)
);

