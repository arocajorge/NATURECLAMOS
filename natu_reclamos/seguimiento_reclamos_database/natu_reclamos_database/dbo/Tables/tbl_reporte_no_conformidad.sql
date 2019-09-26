CREATE TABLE [dbo].[tbl_reporte_no_conformidad] (
    [IdNoConformidad]       NUMERIC (18)   NOT NULL,
    [IdNoConformidad_tipo]  INT            NOT NULL,
    [IdQueja]               NUMERIC (18)   NOT NULL,
    [nc_fecha]              DATETIME       NOT NULL,
    [nc_descripcion]        VARCHAR (5000) NOT NULL,
    [nc_causa]              VARCHAR (5000) NULL,
    [nc_cumplimiento]       VARCHAR (5000) NULL,
    [nc_verificacion]       VARCHAR (5000) NULL,
    [nc_fecha_verificacion] DATETIME       NULL,
    [IdUsuario]             VARCHAR (50)   NOT NULL,
    [estado]                BIT            NOT NULL,
    CONSTRAINT [PK_tbl_reporte_no_conformidad] PRIMARY KEY CLUSTERED ([IdNoConformidad] ASC),
    CONSTRAINT [FK_tbl_reporte_no_conformidad_tbl_queja] FOREIGN KEY ([IdQueja]) REFERENCES [dbo].[tbl_queja] ([IdQueja]),
    CONSTRAINT [FK_tbl_reporte_no_conformidad_tbl_reporte_no_conformidad_tipo] FOREIGN KEY ([IdNoConformidad_tipo]) REFERENCES [dbo].[tbl_reporte_no_conformidad_tipo] ([IdNoConformidad_tipo])
);

