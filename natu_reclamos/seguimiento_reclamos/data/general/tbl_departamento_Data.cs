using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_departamento_Data
    {
        public List<tbl_departamento_Info> get_list()
        {
            try
            {
                List<tbl_departamento_Info> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_departamento
                             where q.estado == true
                             select new tbl_departamento_Info
                             {
                                 IdDepartamento = q.IdDepartamento,
                                 de_descripcion = q.de_descripcion,
                                 estado = q.estado,
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public tbl_departamento_Info get_info(int IdDepartamento)
        {
            try
            {
                tbl_departamento_Info info = new tbl_departamento_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_departamento q = Context.tbl_departamento.FirstOrDefault(v => v.IdDepartamento == IdDepartamento);
                    if (q == null)
                        return null;
                    info = new tbl_departamento_Info
                    {
                        IdDepartamento = q.IdDepartamento,
                        de_descripcion = q.de_descripcion,
                        estado = q.estado,
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
                    var lst = from q in Context.tbl_departamento
                              select q;

                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdDepartamento) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(tbl_departamento_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_departamento Entity = new tbl_departamento
                    {
                        IdDepartamento = info.IdDepartamento = get_id(),
                        de_descripcion = info.de_descripcion,
                        estado = info.estado = true
                    };
                    Context.tbl_departamento.Add(Entity);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_departamento_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_departamento Entity = Context.tbl_departamento.FirstOrDefault(q => q.IdDepartamento == info.IdDepartamento);
                    if (Entity == null) return false;
                    Entity.de_descripcion = info.de_descripcion;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(tbl_departamento_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_departamento Entity = Context.tbl_departamento.FirstOrDefault(q => q.IdDepartamento == info.IdDepartamento);
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
