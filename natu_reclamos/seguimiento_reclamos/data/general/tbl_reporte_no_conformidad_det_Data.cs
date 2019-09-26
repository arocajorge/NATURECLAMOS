using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_reporte_no_conformidad_det_Data
    {
        public List<tbl_reporte_no_conformidad_det_Info> get_list(decimal IdNoConformidad)
        {
            try
            {
                List<tbl_reporte_no_conformidad_det_Info> Lista = new List<tbl_reporte_no_conformidad_det_Info>();

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_reporte_no_conformidad_det
                             where q.IdNoConformidad == IdNoConformidad
                             select new tbl_reporte_no_conformidad_det_Info
                             {
                                 IdNoConformidad = q.IdNoConformidad,
                                 secuencia = q.secuencia,
                                 nd_actividad = q.nd_actividad,
                                 nd_plazo = q.nd_plazo,
                                 nd_responsable = q.nd_responsable
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarDB(decimal IdNoConformidad)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    Context.Database.ExecuteSqlCommand("DELETE tbl_reporte_no_conformidad_det WHERE IdNoConformidad = "+IdNoConformidad);
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(List<tbl_reporte_no_conformidad_det_Info> Lista)
        {
            try
            {
                int secuencia = 1;
                using (Entities_general Context = new Entities_general())
                {
                    foreach (var q in Lista)
                    {
                        tbl_reporte_no_conformidad_det Entity = new tbl_reporte_no_conformidad_det
                        {
                            IdNoConformidad = q.IdNoConformidad,
                            secuencia = q.secuencia = secuencia,
                            nd_actividad = q.nd_actividad,
                            nd_plazo = q.nd_plazo,
                            nd_responsable = q.nd_responsable
                        };
                        Context.tbl_reporte_no_conformidad_det.Add(Entity);
                        secuencia++;
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
