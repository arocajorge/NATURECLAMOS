using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_queja_estado_Data
    {
        public List<tbl_queja_estado_Info> get_list()
        {
            try
            {
                List<tbl_queja_estado_Info> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja_estado
                             where q.estado == true
                             select new tbl_queja_estado_Info
                             {
                                 IdQueja_estado = q.IdQueja_estado,
                                 qe_descripcion = q.qe_descripcion,
                                 qe_se_modifica = q.qe_se_modifica,
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

        public tbl_queja_estado_Info get_info(int IdQueja_estado)
        {
            try
            {
                tbl_queja_estado_Info info = new tbl_queja_estado_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_estado q = Context.tbl_queja_estado.FirstOrDefault(v => v.IdQueja_estado == IdQueja_estado);
                    if (q == null) return null;
                    info = new tbl_queja_estado_Info
                    {
                        IdQueja_estado = q.IdQueja_estado,
                        qe_descripcion = q.qe_descripcion,
                        qe_se_modifica = q.qe_se_modifica,
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
                    var lst = from q in Context.tbl_queja_estado
                              select q;

                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdQueja_estado) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(tbl_queja_estado_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_estado Entity = new tbl_queja_estado
                    {
                        IdQueja_estado = info.IdQueja_estado = get_id(),
                        qe_descripcion = info.qe_descripcion,
                        qe_se_modifica = info.qe_se_modifica,
                        estado = info.estado = true
                    };
                    Context.tbl_queja_estado.Add(Entity);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_queja_estado_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_estado Entity = Context.tbl_queja_estado.FirstOrDefault(q => q.IdQueja_estado == info.IdQueja_estado);
                    if (Entity == null) return false;
                    Entity.qe_descripcion = info.qe_descripcion;
                    Entity.qe_se_modifica = info.qe_se_modifica;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(tbl_queja_estado_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_estado Entity = Context.tbl_queja_estado.FirstOrDefault(q => q.IdQueja_estado == info.IdQueja_estado);
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
