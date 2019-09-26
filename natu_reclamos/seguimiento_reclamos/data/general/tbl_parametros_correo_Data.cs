using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_parametros_correo_Data
    {
        public tbl_parametros_correo_Info get_info()
        {
            try
            {
                tbl_parametros_correo_Info info;

                using (Entities_general Context = new Entities_general())
                {
                    info = (from q in Context.tbl_parametros_correo
                            where q.Id == 1
                            select new tbl_parametros_correo_Info
                            {
                                Id = q.Id,
                                correo_cuenta = q.correo_cuenta,
                                correo_contrasenia = q.correo_contrasenia,
                                correo_cuenta_destinatario = q.correo_cuenta_destinatario,
                                correo_asunto = q.correo_asunto,
                                host = q.host,
                                puerto = q.puerto,
                                enviar_correo_al_guardar_queja = q.enviar_correo_al_guardar_queja,
                                permitir_ssl = q.permitir_ssl,

                                ftp_contrasenia = q.ftp_contrasenia,
                                ftp_url = q.ftp_url,
                                ftp_usuario = q.ftp_usuario
                            }).FirstOrDefault();
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(tbl_parametros_correo_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_parametros_correo Entity = Context.tbl_parametros_correo.FirstOrDefault();
                    if(Entity == null)
                    {
                        Entity = new tbl_parametros_correo
                        {
                            Id = info.Id = 1,
                            correo_cuenta = info.correo_cuenta,
                            correo_contrasenia = info.correo_contrasenia,
                            correo_cuenta_destinatario = info.correo_cuenta_destinatario,
                            correo_asunto = info.correo_asunto,
                            host = info.host,
                            puerto = info.puerto,
                            enviar_correo_al_guardar_queja = info.enviar_correo_al_guardar_queja,
                            permitir_ssl = info.permitir_ssl,
                            ftp_contrasenia = info.ftp_contrasenia,
                            ftp_url = info.ftp_url,
                            ftp_usuario = info.ftp_usuario
                        };
                        Context.tbl_parametros_correo.Add(Entity);
                    }else
                    {
                        Entity.correo_cuenta = info.correo_cuenta;
                        Entity.correo_contrasenia = info.correo_contrasenia;
                        Entity.correo_cuenta_destinatario = info.correo_cuenta_destinatario;
                        Entity.correo_asunto = info.correo_asunto;
                        Entity.host = info.host;
                        Entity.puerto = info.puerto;
                        Entity.enviar_correo_al_guardar_queja = info.enviar_correo_al_guardar_queja;
                        Entity.permitir_ssl = info.permitir_ssl;
                        Entity.ftp_contrasenia = info.ftp_contrasenia;
                        Entity.ftp_url = info.ftp_url;
                        Entity.ftp_usuario = info.ftp_usuario;
                    }
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
