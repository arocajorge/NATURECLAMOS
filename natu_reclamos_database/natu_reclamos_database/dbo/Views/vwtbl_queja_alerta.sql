CREATE VIEW [dbo].[vwtbl_queja_alerta]
AS
SELECT        ISNULL(ROW_NUMBER() OVER(ORDER BY tbl_queja.IdQueja),0) AS IdRow, tbl_queja.IdQueja, tbl_mes.me_descripcion, tbl_departamento.de_descripcion, tbl_queja_tipo.qt_descripcion, tbl_queja_tipo_motivo.qm_descripcion, tbl_sucursal.su_descripcion, tbl_queja_canal.qc_descripcion, 
                         tbl_queja_estado.qe_descripcion, tbl_queja_origen.qo_descripcion, tbl_queja.estado, tbl_queja.qu_fecha, abs(DATEDIFF(day, getdate(), qu_fecha)) dias_sin_atencion
FROM            tbl_departamento INNER JOIN
                         tbl_queja ON tbl_departamento.IdDepartamento = tbl_queja.IdDepartamento INNER JOIN
                         tbl_mes ON tbl_queja.IdMes = tbl_mes.IdMes INNER JOIN
                         tbl_queja_canal ON tbl_queja.IdQueja_canal = tbl_queja_canal.IdQueja_canal INNER JOIN
                         tbl_queja_estado ON tbl_queja.IdQueja_estado = tbl_queja_estado.IdQueja_estado INNER JOIN
                         tbl_queja_origen ON tbl_queja.IdQueja_origen = tbl_queja_origen.IdQueja_origen INNER JOIN
                         tbl_queja_tipo ON tbl_queja.IdQueja_tipo = tbl_queja_tipo.IdQueja_tipo INNER JOIN
                         tbl_queja_tipo_motivo ON tbl_queja.IdQueja_motivo = tbl_queja_tipo_motivo.IdQueja_motivo INNER JOIN
                         tbl_sucursal ON tbl_queja.IdSucursal = tbl_sucursal.IdSucursal INNER JOIN
                         tbl_usuario ON tbl_queja.IdUsuario = tbl_usuario.IdUsuario
WHERE        (tbl_queja.estado = 1) AND (tbl_queja_estado.qe_descripcion <> 'CERRADO') AND DATEDIFF(day, getdate(), qu_fecha) <= 2