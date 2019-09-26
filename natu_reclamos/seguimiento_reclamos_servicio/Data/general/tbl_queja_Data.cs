using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.general
{
    public class tbl_queja_Data
    {
        public List<tbl_queja_Info> get_list()
        {
            try
            {
                List<tbl_queja_Info> Lista;
                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.vwtbl_queja_alerta
                                                      
                             select new tbl_queja_Info
                             {
                                 IdQueja = q.IdQueja,
                                 estado = q.estado,   
                                 dias_sin_atencion = q.dias_sin_atencion, 
                                 qu_fecha = q.qu_fecha,                             
                                 info_canal = new tbl_queja_canal_Info
                                 {
                                     qc_descripcion = q.qc_descripcion
                                 },
                                 info_departamento = new tbl_departamento_Info
                                 {
                                     de_descripcion = q.de_descripcion
                                 },
                                 info_estado = new tbl_queja_estado_Info
                                 {
                                     qe_descripcion = q.qe_descripcion,                                     
                                 },
                                 info_motivo = new tbl_queja_tipo_motivo_Info
                                 {                                     
                                     qm_descripcion = q.qm_descripcion
                                 },
                                 info_tipo = new tbl_queja_tipo_Info
                                 {
                                     qt_descripcion = q.qt_descripcion
                                 },
                                 info_origen = new tbl_queja_origen_Info
                                 {
                                     qo_descripcion = q.qo_descripcion
                                 },
                                 info_sucursal = new tbl_sucursal_Info
                                 {
                                     su_descripcion = q.su_descripcion
                                 },
                                 info_mes = new tbl_mes_Info
                                 {
                                     me_descripcion = q.me_descripcion
                                 }
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }        
    }
}
