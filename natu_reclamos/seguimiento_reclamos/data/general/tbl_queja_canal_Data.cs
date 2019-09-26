using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_queja_canal_Data
    {
        public List<tbl_queja_canal_Info> get_list()
        {
            try
            {
                List<tbl_queja_canal_Info> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja_canal
                             where q.estado == true
                             select new tbl_queja_canal_Info
                             {
                                 IdQueja_canal = q.IdQueja_canal,
                                 qc_descripcion = q.qc_descripcion,
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

        public tbl_queja_canal_Info get_info(int IdQueja_canal)
        {
            try
            {
                tbl_queja_canal_Info info = new tbl_queja_canal_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_canal q = Context.tbl_queja_canal.FirstOrDefault(v => v.IdQueja_canal == IdQueja_canal);
                    if (q == null) return null;
                    info = new tbl_queja_canal_Info
                    {
                        IdQueja_canal = q.IdQueja_canal,
                        qc_descripcion = q.qc_descripcion,
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
                    var lst = from q in Context.tbl_queja_canal
                              select q;

                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdQueja_canal) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(tbl_queja_canal_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_canal Entity = new tbl_queja_canal
                    {
                        IdQueja_canal = info.IdQueja_canal = get_id(),
                        qc_descripcion = info.qc_descripcion,
                        estado = info.estado = true
                    };
                    Context.tbl_queja_canal.Add(Entity);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_queja_canal_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_canal Entity = Context.tbl_queja_canal.FirstOrDefault(q => q.IdQueja_canal == info.IdQueja_canal);
                    if (Entity == null) return false;
                    Entity.qc_descripcion = info.qc_descripcion;
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(tbl_queja_canal_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_canal Entity = Context.tbl_queja_canal.FirstOrDefault(q => q.IdQueja_canal == info.IdQueja_canal);
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
