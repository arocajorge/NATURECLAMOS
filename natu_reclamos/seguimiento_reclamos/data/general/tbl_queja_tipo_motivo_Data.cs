using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_queja_tipo_motivo_Data
    {
        public List<tbl_queja_tipo_motivo_Info> get_list(int IdQueja_tipo)
        {
            try
            {
                List<tbl_queja_tipo_motivo_Info> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja_tipo_motivo
                             where q.estado == true
                             && q.IdQueja_tipo == IdQueja_tipo
                             select new tbl_queja_tipo_motivo_Info
                             {
                                 IdQueja_motivo = q.IdQueja_motivo,
                                 IdQueja_tipo = q.IdQueja_tipo,
                                 qm_descripcion = q.qm_descripcion,
                                 estado = q.estado
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<tbl_queja_tipo_motivo_Info> get_list()
        {
            try
            {
                List<tbl_queja_tipo_motivo_Info> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja_tipo_motivo
                             where q.estado == true
                             select new tbl_queja_tipo_motivo_Info
                             {
                                 IdQueja_motivo = q.IdQueja_motivo,
                                 IdQueja_tipo = q.IdQueja_tipo,
                                 qm_descripcion = q.qm_descripcion,
                                 estado = q.estado
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public tbl_queja_tipo_motivo_Info get_info(int IdQueja_motivo)
        {
            try
            {
                tbl_queja_tipo_motivo_Info info = new tbl_queja_tipo_motivo_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_tipo_motivo q = Context.tbl_queja_tipo_motivo.FirstOrDefault(v => v.IdQueja_motivo == IdQueja_motivo);
                    if (q == null) return null;
                    info = new tbl_queja_tipo_motivo_Info
                    {
                        IdQueja_motivo = q.IdQueja_motivo,
                        IdQueja_tipo = q.IdQueja_tipo,
                        qm_descripcion = q.qm_descripcion,
                        estado = q.estado
                    };                    
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int get_id()
        {
            try
            {
                int ID = 1;

                using (Entities_general Context = new Entities_general())
                {
                    var lst = from q in Context.tbl_queja_tipo_motivo
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdQueja_motivo) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(tbl_queja_tipo_motivo_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_tipo_motivo Entity = new tbl_queja_tipo_motivo
                    {
                        IdQueja_motivo = info.IdQueja_motivo = get_id(),
                        IdQueja_tipo = info.IdQueja_tipo,
                        qm_descripcion = info.qm_descripcion,
                        estado = info.estado = true
                    };
                    Context.tbl_queja_tipo_motivo.Add(Entity);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_queja_tipo_motivo_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_tipo_motivo Entity = Context.tbl_queja_tipo_motivo.FirstOrDefault(q => q.IdQueja_motivo == info.IdQueja_motivo);
                    if (Entity == null) return false;
                    Entity.qm_descripcion = info.qm_descripcion;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(tbl_queja_tipo_motivo_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_tipo_motivo Entity = Context.tbl_queja_tipo_motivo.FirstOrDefault(q => q.IdQueja_motivo == info.IdQueja_motivo);
                    if (Entity == null) return false;
                    Entity.estado = info.estado = false;
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
