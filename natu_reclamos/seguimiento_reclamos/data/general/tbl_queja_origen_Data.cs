using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_queja_origen_Data
    {
        public List<tbl_queja_origen_Info> get_list()
        {
            try
            {
                List<tbl_queja_origen_Info> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja_origen
                             where q.estado == true
                             select new tbl_queja_origen_Info
                             {
                                 IdQueja_origen = q.IdQueja_origen,
                                 qo_descripcion = q.qo_descripcion,
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

        public tbl_queja_origen_Info get_info(int IdQueja_origen)
        {
            try
            {
                tbl_queja_origen_Info info = new tbl_queja_origen_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_origen q = Context.tbl_queja_origen.FirstOrDefault(v => v.IdQueja_origen == IdQueja_origen);
                    if (q == null) return null;
                    info = new tbl_queja_origen_Info
                    {
                        IdQueja_origen = q.IdQueja_origen,
                        qo_descripcion = q.qo_descripcion,
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
                    var lst = from q in Context.tbl_queja_origen
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdQueja_origen) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(tbl_queja_origen_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_origen Entity = new tbl_queja_origen
                    {
                        IdQueja_origen = info.IdQueja_origen = get_id(),
                        qo_descripcion = info.qo_descripcion,
                        estado = info.estado = true
                    };
                    Context.tbl_queja_origen.Add(Entity);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_queja_origen_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_origen Entity = Context.tbl_queja_origen.FirstOrDefault(q => q.IdQueja_origen == info.IdQueja_origen);
                    if (Entity == null) return false;
                    Entity.qo_descripcion = info.qo_descripcion;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(tbl_queja_origen_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_origen Entity = Context.tbl_queja_origen.FirstOrDefault(q => q.IdQueja_origen == info.IdQueja_origen);
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
