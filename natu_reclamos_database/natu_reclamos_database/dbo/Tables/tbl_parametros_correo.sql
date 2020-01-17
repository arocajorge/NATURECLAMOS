CREATE TABLE [dbo].[tbl_parametros_correo] (
    [Id]                             INT           NOT NULL,
    [correo_cuenta]                  VARCHAR (500) NOT NULL,
    [correo_cuenta_destinatario]     VARCHAR (MAX) NOT NULL,
    [correo_contrasenia]             VARCHAR (500) NOT NULL,
    [correo_asunto]                  VARCHAR (MAX) NULL,
    [puerto]                         INT           NOT NULL,
    [host]                           VARCHAR (200) NOT NULL,
    [permitir_ssl]                   BIT           NOT NULL,
    [enviar_correo_al_guardar_queja] BIT           NOT NULL,
    [ftp_usuario]                    VARCHAR (200) NULL,
    [ftp_contrasenia]                VARCHAR (200) NULL,
    [ftp_url]                        VARCHAR (400) NULL,
    CONSTRAINT [PK_tbl_parametros_correo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

