CREATE TABLE [dbo].[tbl_reporte_no_conformidad_det] (
    [IdNoConformidad] NUMERIC (18)   NOT NULL,
    [secuencia]       INT            NOT NULL,
    [nd_actividad]    VARCHAR (2000) NOT NULL,
    [nd_plazo]        INT            NOT NULL,
    [nd_responsable]  VARCHAR (400)  NULL,
    CONSTRAINT [PK_tbl_reporte_no_conformidad_det] PRIMARY KEY CLUSTERED ([IdNoConformidad] ASC, [secuencia] ASC),
    CONSTRAINT [FK_tbl_reporte_no_conformidad_det_tbl_reporte_no_conformidad] FOREIGN KEY ([IdNoConformidad]) REFERENCES [dbo].[tbl_reporte_no_conformidad] ([IdNoConformidad])
);

