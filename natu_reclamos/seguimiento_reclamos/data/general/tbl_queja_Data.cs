using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_queja_Data
    {
        public List<tbl_queja_Info> get_list(DateTime? fecha_ini, DateTime? Fecha_fin)
        {
            try
            {
                List<tbl_queja_Info> Lista;
                fecha_ini = fecha_ini == null ? new DateTime(DateTime.Now.Year, 1, 1) : Convert.ToDateTime(fecha_ini).Date;
                Fecha_fin = Fecha_fin == null ? new DateTime(DateTime.Now.Year, 12, 31) : Convert.ToDateTime(Fecha_fin).Date;
                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja
                             join c in Context.tbl_queja_canal
                             on new { q.IdQueja_canal} equals new { c.IdQueja_canal}
                             join s in Context.tbl_sucursal
                             on new { q.IdSucursal} equals new { s.IdSucursal}
                             join d in Context.tbl_departamento
                             on new { q.IdDepartamento} equals new { d.IdDepartamento}
                             join e in Context.tbl_queja_estado
                             on new { q.IdQueja_estado} equals new { e.IdQueja_estado}
                             join o in Context.tbl_queja_origen
                             on new { q.IdQueja_origen} equals new { o.IdQueja_origen}
                             join t in Context.tbl_queja_tipo
                             on new { q.IdQueja_tipo} equals new { t.IdQueja_tipo}
                             join m in Context.tbl_queja_tipo_motivo
                             on new { q.IdQueja_motivo} equals new { m.IdQueja_motivo}
                             join me in Context.tbl_mes
                             on new { q.IdMes } equals new { me.IdMes}                             
                             where q.estado == true
                             && fecha_ini <= q.qu_fecha && q.qu_fecha <= Fecha_fin
                             select new tbl_queja_Info
                             {
                                 IdQueja = q.IdQueja,
                                 IdDepartamento = q.IdDepartamento,
                                 IdQueja_canal = q.IdQueja_canal,
                                 IdQueja_estado = q.IdQueja_estado,
                                 IdQueja_tipo = q.IdQueja_tipo,
                                 IdQueja_origen = q.IdQueja_origen,
                                 IdQueja_motivo = q.IdQueja_motivo,
                                 IdSucursal = q.IdSucursal,
                                 cl_correo = q.cl_correo,
                                 cl_nombre = q.cl_nombre,
                                 cl_telefono = q.cl_telefono,
                                 qu_detalle = q.qu_detalle,
                                 qu_solucion = q.qu_solucion,
                                 IdUsuario = q.IdUsuario,
                                 qu_fecha = q.qu_fecha,
                                 qu_anio = q.qu_anio,
                                 IdMes = q.IdMes,
                                 estado = q.estado,                                 
                                 info_canal = new tbl_queja_canal_Info
                                 {
                                     IdQueja_canal = c.IdQueja_canal,
                                     qc_descripcion = c.qc_descripcion
                                 },
                                 info_departamento = new tbl_departamento_Info
                                 {
                                     IdDepartamento = d.IdDepartamento,
                                     de_descripcion = d.de_descripcion
                                 },
                                 info_estado = new tbl_queja_estado_Info
                                 {
                                     IdQueja_estado = e.IdQueja_estado,
                                     qe_descripcion = e.qe_descripcion,
                                     qe_se_modifica = e.qe_se_modifica
                                 },
                                 info_motivo = new tbl_queja_tipo_motivo_Info
                                 {
                                     IdQueja_motivo = m.IdQueja_motivo,
                                     IdQueja_tipo = m.IdQueja_tipo,
                                     qm_descripcion = m.qm_descripcion
                                 },
                                 info_tipo = new tbl_queja_tipo_Info
                                 {
                                     IdQueja_tipo = t.IdQueja_tipo,
                                     qt_descripcion = t.qt_descripcion
                                 },
                                 info_origen = new tbl_queja_origen_Info
                                 {
                                     IdQueja_origen = o.IdQueja_origen,
                                     qo_descripcion = o.qo_descripcion
                                 },
                                 info_sucursal = new tbl_sucursal_Info
                                 {
                                     IdSucursal = s.IdSucursal,
                                     su_descripcion = s.su_descripcion
                                 },
                                 info_mes = new tbl_mes_Info
                                 {
                                     IdMes = me.IdMes,
                                     me_descripcion = me.me_descripcion
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

        public tbl_queja_Info get_info_correo(decimal IdQueja)
        {
            try
            {
                tbl_queja_Info info;
                using (Entities_general Context = new Entities_general())
                {
                    info = (from q in Context.tbl_queja
                             join c in Context.tbl_queja_canal
                             on new { q.IdQueja_canal } equals new { c.IdQueja_canal }
                             join s in Context.tbl_sucursal
                             on new { q.IdSucursal } equals new { s.IdSucursal }
                             join d in Context.tbl_departamento
                             on new { q.IdDepartamento } equals new { d.IdDepartamento }
                             join e in Context.tbl_queja_estado
                             on new { q.IdQueja_estado } equals new { e.IdQueja_estado }
                             join o in Context.tbl_queja_origen
                             on new { q.IdQueja_origen } equals new { o.IdQueja_origen }
                             join t in Context.tbl_queja_tipo
                             on new { q.IdQueja_tipo } equals new { t.IdQueja_tipo }
                             join m in Context.tbl_queja_tipo_motivo
                             on new { q.IdQueja_motivo } equals new { m.IdQueja_motivo }
                             join me in Context.tbl_mes
                             on new { q.IdMes } equals new { me.IdMes }
                             where q.estado == true
                             && q.IdQueja == IdQueja
                             select new tbl_queja_Info
                             {
                                 IdQueja = q.IdQueja,
                                 IdDepartamento = q.IdDepartamento,
                                 IdQueja_canal = q.IdQueja_canal,
                                 IdQueja_estado = q.IdQueja_estado,
                                 IdQueja_tipo = q.IdQueja_tipo,
                                 IdQueja_origen = q.IdQueja_origen,
                                 IdQueja_motivo = q.IdQueja_motivo,
                                 IdSucursal = q.IdSucursal,
                                 cl_correo = q.cl_correo,
                                 cl_nombre = q.cl_nombre,
                                 cl_telefono = q.cl_telefono,
                                 qu_detalle = q.qu_detalle,
                                 qu_solucion = q.qu_solucion,
                                 IdUsuario = q.IdUsuario,
                                 qu_fecha = q.qu_fecha,
                                 qu_anio = q.qu_anio,
                                 IdMes = q.IdMes,
                                 estado = q.estado,
                                 info_canal = new tbl_queja_canal_Info
                                 {
                                     IdQueja_canal = c.IdQueja_canal,
                                     qc_descripcion = c.qc_descripcion
                                 },
                                 info_departamento = new tbl_departamento_Info
                                 {
                                     IdDepartamento = d.IdDepartamento,
                                     de_descripcion = d.de_descripcion
                                 },
                                 info_estado = new tbl_queja_estado_Info
                                 {
                                     IdQueja_estado = e.IdQueja_estado,
                                     qe_descripcion = e.qe_descripcion,
                                     qe_se_modifica = e.qe_se_modifica
                                 },
                                 info_motivo = new tbl_queja_tipo_motivo_Info
                                 {
                                     IdQueja_motivo = m.IdQueja_motivo,
                                     IdQueja_tipo = m.IdQueja_tipo,
                                     qm_descripcion = m.qm_descripcion
                                 },
                                 info_tipo = new tbl_queja_tipo_Info
                                 {
                                     IdQueja_tipo = t.IdQueja_tipo,
                                     qt_descripcion = t.qt_descripcion
                                 },
                                 info_origen = new tbl_queja_origen_Info
                                 {
                                     IdQueja_origen = o.IdQueja_origen,
                                     qo_descripcion = o.qo_descripcion
                                 },
                                 info_sucursal = new tbl_sucursal_Info
                                 {
                                     IdSucursal = s.IdSucursal,
                                     su_descripcion = s.su_descripcion
                                 },
                                 info_mes = new tbl_mes_Info
                                 {
                                     IdMes = me.IdMes,
                                     me_descripcion = me.me_descripcion
                                 }
                             }).FirstOrDefault();
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public tbl_queja_Info get_info(decimal IdQueja)
        {
            try
            {
                tbl_queja_Info info = new tbl_queja_Info();

                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja q = Context.tbl_queja.FirstOrDefault(v => v.IdQueja == IdQueja);
                    if (q == null) return null;
                    else
                        info = new tbl_queja_Info
                        {
                            IdQueja = q.IdQueja,
                            IdDepartamento = q.IdDepartamento,
                            IdQueja_canal = q.IdQueja_canal,
                            IdQueja_estado = q.IdQueja_estado,
                            IdQueja_tipo = q.IdQueja_tipo,
                            IdQueja_origen = q.IdQueja_origen,
                            IdQueja_motivo = q.IdQueja_motivo,
                            IdSucursal = q.IdSucursal,
                            cl_correo = q.cl_correo,
                            cl_nombre = q.cl_nombre,
                            cl_telefono = q.cl_telefono,
                            qu_detalle = q.qu_detalle,
                            qu_solucion = q.qu_solucion,
                            IdUsuario = q.IdUsuario,
                            qu_fecha = q.qu_fecha,
                            qu_anio = q.qu_anio,
                            IdMes = q.IdMes,
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
                    var lst = from q in Context.tbl_queja
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdQueja) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(tbl_queja_Info q)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja Entity = new tbl_queja
                    {
                        IdQueja = q.IdQueja = get_id(),
                        IdDepartamento =Convert.ToInt32(q.IdDepartamento),
                        IdQueja_canal = Convert.ToInt32(q.IdQueja_canal),
                        IdQueja_estado = Convert.ToInt32(q.IdQueja_estado),
                        IdQueja_tipo = Convert.ToInt32(q.IdQueja_tipo),
                        IdQueja_origen = Convert.ToInt32(q.IdQueja_origen),
                        IdQueja_motivo = Convert.ToInt32(q.IdQueja_motivo),
                        IdSucursal = Convert.ToInt32(q.IdSucursal),
                        cl_correo = q.cl_correo,
                        cl_nombre = q.cl_nombre,
                        cl_telefono = q.cl_telefono,
                        qu_detalle = q.qu_detalle,
                        qu_solucion = q.qu_solucion,
                        IdUsuario = q.IdUsuario,
                        qu_fecha = q.qu_fecha,
                        qu_anio = q.qu_anio,
                        IdMes = q.IdMes,
                        estado = q.estado = true
                    };
                    Context.tbl_queja.Add(Entity);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_queja_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja Entity = Context.tbl_queja.FirstOrDefault(q => q.IdQueja == info.IdQueja);
                    if (Entity == null) return false;
                    Entity.IdDepartamento = Convert.ToInt32(info.IdDepartamento);
                    Entity.IdQueja_canal = Convert.ToInt32(info.IdQueja_canal);
                    Entity.IdQueja_estado = Convert.ToInt32(info.IdQueja_estado);
                    Entity.IdQueja_tipo = Convert.ToInt32(info.IdQueja_tipo);
                    Entity.IdQueja_origen = Convert.ToInt32(info.IdQueja_origen);
                    Entity.IdQueja_motivo = Convert.ToInt32(info.IdQueja_motivo);
                    Entity.IdSucursal = Convert.ToInt32(info.IdSucursal);
                    Entity.cl_correo = info.cl_correo;
                    Entity.cl_nombre = info.cl_nombre;
                    Entity.cl_telefono = info.cl_telefono;
                    Entity.qu_detalle = info.qu_detalle;
                    Entity.qu_solucion = info.qu_solucion;
                    Entity.IdUsuario = info.IdUsuario;
                    Entity.qu_fecha = info.qu_fecha;
                    Entity.qu_anio = info.qu_anio;
                    Entity.IdMes = info.IdMes;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(tbl_queja_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_queja Entity = Context.tbl_queja.FirstOrDefault(q => q.IdQueja == info.IdQueja);
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
