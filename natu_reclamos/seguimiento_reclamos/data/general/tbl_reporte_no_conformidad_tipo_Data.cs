using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_reporte_no_conformidad_tipo_Data
    {
        public List<tbl_reporte_no_conformidad_tipo_Info> get_list()
        {
            try
            {
                List<tbl_reporte_no_conformidad_tipo_Info> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_reporte_no_conformidad_tipo
                             where q.estado == true
                             select new tbl_reporte_no_conformidad_tipo_Info
                             {
                                 IdNoConformidad_tipo = q.IdNoConformidad_tipo,
                                 nt_descripcion = q.nt_descripcion,
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

        public tbl_reporte_no_conformidad_tipo_Info get_info(int IdNoConformidad_tipo)
        {
            try
            {
                tbl_reporte_no_conformidad_tipo_Info info = new tbl_reporte_no_conformidad_tipo_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_reporte_no_conformidad_tipo q = Context.tbl_reporte_no_conformidad_tipo.FirstOrDefault(v => v.IdNoConformidad_tipo == IdNoConformidad_tipo);
                    if (q == null) return null;
                    info = new tbl_reporte_no_conformidad_tipo_Info
                    {
                        IdNoConformidad_tipo = q.IdNoConformidad_tipo,
                        nt_descripcion = q.nt_descripcion,
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
                    var lst = from q in Context.tbl_reporte_no_conformidad_tipo
                              select q;

                    if (lst.Count() != 0)
                        ID = lst.Max(q => q.IdNoConformidad_tipo) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(tbl_reporte_no_conformidad_tipo_Info q)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_reporte_no_conformidad_tipo Entity = new tbl_reporte_no_conformidad_tipo
                    {
                        IdNoConformidad_tipo = q.IdNoConformidad_tipo = get_id(),
                        nt_descripcion = q.nt_descripcion,
                        estado = q.estado = true
                    };
                    Context.tbl_reporte_no_conformidad_tipo.Add(Entity);
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_reporte_no_conformidad_tipo_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_reporte_no_conformidad_tipo Entity = Context.tbl_reporte_no_conformidad_tipo.FirstOrDefault(q => q.IdNoConformidad_tipo == info.IdNoConformidad_tipo);
                    if (Entity == null) return false;
                    Entity.nt_descripcion = info.nt_descripcion;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(tbl_reporte_no_conformidad_tipo_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_reporte_no_conformidad_tipo Entity = Context.tbl_reporte_no_conformidad_tipo.FirstOrDefault(q => q.IdNoConformidad_tipo == info.IdNoConformidad_tipo);
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
