using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_sucursal_Data
    {
        public List<tbl_sucursal_Info> get_list()
        {
            try
            {
                List<tbl_sucursal_Info> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_sucursal
                             where q.estado == true
                             select new tbl_sucursal_Info
                             {
                                 IdSucursal = q.IdSucursal,
                                 su_codigo = q.su_codigo,
                                 su_descripcion = q.su_descripcion,
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

        public tbl_sucursal_Info get_info(int IdSucursal)
        {
            try
            {
                tbl_sucursal_Info info = new tbl_sucursal_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_sucursal Entity = Context.tbl_sucursal.FirstOrDefault(q => q.IdSucursal == IdSucursal);
                    if (Entity == null)
                        return null;

                    info = new tbl_sucursal_Info
                    {
                        IdSucursal = Entity.IdSucursal,
                        su_codigo = Entity.su_codigo,
                        su_descripcion = Entity.su_descripcion,
                        estado = Entity.estado,
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
                    var lst = from q in Context.tbl_sucursal
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdSucursal) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(tbl_sucursal_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_sucursal Entity = new tbl_sucursal
                    {
                        IdSucursal = info.IdSucursal = get_id(),
                        su_codigo = info.su_codigo,
                        su_descripcion = info.su_descripcion,
                        estado = info.estado = true,
                    };
                    Context.tbl_sucursal.Add(Entity);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_sucursal_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_sucursal Entity = Context.tbl_sucursal.FirstOrDefault(q => q.IdSucursal == info.IdSucursal);
                    if (Entity == null)
                        return false;
                    Entity.su_codigo = info.su_codigo;
                    Entity.su_descripcion = info.su_descripcion;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(tbl_sucursal_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_sucursal Entity = Context.tbl_sucursal.FirstOrDefault(q => q.IdSucursal == info.IdSucursal);
                    if (Entity == null)
                        return false;
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
