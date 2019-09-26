using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_queja_tipo_Data
    {
        public List<tbl_queja_tipo_Info> get_list()
        {
            try
            {
                List<tbl_queja_tipo_Info> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja_tipo
                             where q.estado == true
                             select new tbl_queja_tipo_Info
                             {
                                 IdQueja_tipo = q.IdQueja_tipo,
                                 qt_descripcion = q.qt_descripcion,
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

        public tbl_queja_tipo_Info get_info(int IdQueja_tipo)
        {
            try
            {
                tbl_queja_tipo_Info info = new tbl_queja_tipo_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_tipo q = Context.tbl_queja_tipo.FirstOrDefault(v => v.IdQueja_tipo == IdQueja_tipo);
                    if (q == null) return null;
                    info = new tbl_queja_tipo_Info
                    {
                        IdQueja_tipo = q.IdQueja_tipo,
                        qt_descripcion = q.qt_descripcion,
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
                    var lst = from q in Context.tbl_queja_tipo
                              select q;

                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdQueja_tipo) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(tbl_queja_tipo_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_tipo Entity = new tbl_queja_tipo
                    {
                        IdQueja_tipo = info.IdQueja_tipo = get_id(),
                        qt_descripcion = info.qt_descripcion,
                        estado = info.estado = true,
                    };
                    Context.tbl_queja_tipo.Add(Entity);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_queja_tipo_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_tipo Entity = Context.tbl_queja_tipo.FirstOrDefault(q => q.IdQueja_tipo == info.IdQueja_tipo);
                    if (Entity == null) return false;
                    Entity.qt_descripcion = info.qt_descripcion;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(tbl_queja_tipo_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja_tipo Entity = Context.tbl_queja_tipo.FirstOrDefault(q => q.IdQueja_tipo == info.IdQueja_tipo);
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
