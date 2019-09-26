using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_reporte_no_conformidad_Data
    {
        tbl_reporte_no_conformidad_det_Data odata_det = new tbl_reporte_no_conformidad_det_Data();
        public List<tbl_reporte_no_conformidad_Info> get_list()
        {
            try
            {
                List<tbl_reporte_no_conformidad_Info> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_reporte_no_conformidad
                             join t in Context.tbl_reporte_no_conformidad_tipo
                             on new { q.IdNoConformidad_tipo} equals new { t.IdNoConformidad_tipo}
                             where q.estado == true
                             select new tbl_reporte_no_conformidad_Info
                             {
                                 IdNoConformidad = q.IdNoConformidad,
                                 IdNoConformidad_tipo = q.IdNoConformidad_tipo,
                                 IdQueja = q.IdQueja,
                                 nc_fecha = q.nc_fecha,
                                 nc_descripcion = q.nc_descripcion,
                                 nc_causa = q.nc_causa,
                                 nc_cumplimiento = q.nc_cumplimiento,
                                 nc_verificacion = q.nc_verificacion,
                                 nc_fecha_verificacion = q.nc_fecha_verificacion,
                                 IdUsuario = q.IdUsuario,
                                 estado = q.estado,
                                 info_tipo = new tbl_reporte_no_conformidad_tipo_Info
                                 {
                                     IdNoConformidad_tipo = t.IdNoConformidad_tipo,
                                     nt_descripcion = t.nt_descripcion,
                                     estado = t.estado
                                 }
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public tbl_reporte_no_conformidad_Info get_info(decimal IdNoConformidad)
        {
            try
            {
                tbl_reporte_no_conformidad_Info info = new tbl_reporte_no_conformidad_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_reporte_no_conformidad q = Context.tbl_reporte_no_conformidad.FirstOrDefault(v => v.IdNoConformidad == IdNoConformidad);
                    if (q == null) return null;
                    info = new tbl_reporte_no_conformidad_Info
                    {
                        IdNoConformidad = q.IdNoConformidad,
                        IdNoConformidad_tipo = q.IdNoConformidad_tipo,
                        IdQueja = q.IdQueja,
                        nc_fecha = q.nc_fecha,
                        nc_descripcion = q.nc_descripcion,
                        nc_causa = q.nc_causa,
                        nc_cumplimiento = q.nc_cumplimiento,
                        nc_verificacion = q.nc_verificacion,
                        nc_fecha_verificacion = q.nc_fecha_verificacion,
                        IdUsuario = q.IdUsuario,
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

        public tbl_reporte_no_conformidad_Info get_info_x_queja(decimal IdQueja)
        {
            try
            {
                tbl_reporte_no_conformidad_Info info = new tbl_reporte_no_conformidad_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_reporte_no_conformidad q = Context.tbl_reporte_no_conformidad.FirstOrDefault(v => v.IdQueja == IdQueja && v.estado == true);
                    if (q == null) return null;
                    info = new tbl_reporte_no_conformidad_Info
                    {
                        IdNoConformidad = q.IdNoConformidad,
                        IdNoConformidad_tipo = q.IdNoConformidad_tipo,
                        IdQueja = q.IdQueja,
                        nc_fecha = q.nc_fecha,
                        nc_descripcion = q.nc_descripcion,
                        nc_causa = q.nc_causa,
                        nc_cumplimiento = q.nc_cumplimiento,
                        nc_verificacion = q.nc_verificacion,
                        nc_fecha_verificacion = q.nc_fecha_verificacion,
                        IdUsuario = q.IdUsuario,
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

        public decimal get_id()
        {
            try
            {
                decimal ID = 1;

                using (Entities_general Context = new Entities_general())
                {
                    var lst = from q in Context.tbl_reporte_no_conformidad
                              select q;
                    if (lst.Count() != 0)
                        ID = lst.Max(q => q.IdNoConformidad)+1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(tbl_reporte_no_conformidad_Info q)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_reporte_no_conformidad Entity = new tbl_reporte_no_conformidad
                    {
                        IdNoConformidad = q.IdNoConformidad = get_id(),
                        IdNoConformidad_tipo = q.IdNoConformidad_tipo,
                        IdQueja = q.IdQueja,
                        nc_fecha = q.nc_fecha,
                        nc_descripcion = q.nc_descripcion,
                        nc_causa = q.nc_causa,
                        nc_cumplimiento = q.nc_cumplimiento,
                        nc_verificacion = q.nc_verificacion,
                        nc_fecha_verificacion = q.nc_fecha_verificacion,
                        IdUsuario = q.IdUsuario,
                        estado = q.estado = true
                    };
                    Context.tbl_reporte_no_conformidad.Add(Entity);
                    Context.SaveChanges();
                }
                foreach (var item in q.lst_det)
                {
                    item.IdNoConformidad = q.IdNoConformidad;
                }
                odata_det.guardarDB(q.lst_det);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_reporte_no_conformidad_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_reporte_no_conformidad Entity = Context.tbl_reporte_no_conformidad.FirstOrDefault(q => q.IdNoConformidad == info.IdNoConformidad);
                    if (Entity == null) return false;
                    Entity.IdNoConformidad_tipo = info.IdNoConformidad_tipo;
                    Entity.IdQueja = info.IdQueja;
                    Entity.nc_fecha = info.nc_fecha;
                    Entity.nc_descripcion = info.nc_descripcion;
                    Entity.nc_causa = info.nc_causa;
                    Entity.nc_cumplimiento = info.nc_cumplimiento;
                    Entity.nc_verificacion = info.nc_verificacion;
                    Entity.nc_fecha_verificacion = info.nc_fecha_verificacion;
                    Context.SaveChanges();
                }
                odata_det.eliminarDB(info.IdNoConformidad);
                foreach (var item in info.lst_det)
                {
                    item.IdNoConformidad = info.IdNoConformidad;
                }
                odata_det.guardarDB(info.lst_det);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(tbl_reporte_no_conformidad_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_reporte_no_conformidad Entity = Context.tbl_reporte_no_conformidad.FirstOrDefault(q => q.IdNoConformidad == info.IdNoConformidad);
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
