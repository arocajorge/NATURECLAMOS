using info.reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.reportes
{
    public class tbl_reporte_Data
    {
        public List<tbl_reporte_sucursal> get_list_sucursal(int IdSucursal, int IdQueja_tipo, DateTime? fecha_ini, DateTime? Fecha_fin)
        {
            try
            {
                int IdSucursal_ini = IdSucursal;
                int IdSucursal_fin = IdSucursal == 0 ? 9999 : IdSucursal;

                int IdQueja_tipo_ini = IdQueja_tipo;
                int IdQueja_tipo_fin = IdQueja_tipo == 0 ? 9999 : IdQueja_tipo;

                fecha_ini = fecha_ini == null ? new DateTime(DateTime.Now.Year,1,1) : Convert.ToDateTime(fecha_ini).Date;
                Fecha_fin = Fecha_fin == null ? new DateTime(DateTime.Now.Year, 12, 31) : Convert.ToDateTime(Fecha_fin).Date;
                
                List<tbl_reporte_sucursal> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja
                             join s in Context.tbl_sucursal
                             on q.IdSucursal equals s.IdSucursal
                             where IdSucursal_ini <= q.IdSucursal && q.IdSucursal <= IdSucursal_fin
                             && IdQueja_tipo_ini <= q.IdQueja_tipo && q.IdQueja_tipo <= IdQueja_tipo_fin
                             && fecha_ini <= q.qu_fecha && q.qu_fecha <= Fecha_fin
                             && q.estado == true
                             group q by new { q.IdSucursal, s.su_descripcion} into grouping
                             select new tbl_reporte_sucursal
                             {
                                 su_descripcion = grouping.Key.su_descripcion,
                                 cantidad_quejas = grouping.Count()
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<tbl_reporte_sucursal_tipo> get_list_sucursal_tipo(int IdSucursal, int IdQueja_tipo, DateTime? fecha_ini, DateTime? Fecha_fin)
        {
            try
            {
                int IdSucursal_ini = IdSucursal;
                int IdSucursal_fin = IdSucursal == 0 ? 9999 : IdSucursal;

                int IdQueja_tipo_ini = IdQueja_tipo;
                int IdQueja_tipo_fin = IdQueja_tipo == 0 ? 9999 : IdQueja_tipo;

                fecha_ini = fecha_ini == null ? new DateTime(DateTime.Now.Year, 1, 1) : Convert.ToDateTime(fecha_ini).Date;
                Fecha_fin = Fecha_fin == null ? new DateTime(DateTime.Now.Year, 12, 31) : Convert.ToDateTime(Fecha_fin).Date;

                List<tbl_reporte_sucursal_tipo> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja
                             join s in Context.tbl_sucursal
                             on q.IdSucursal equals s.IdSucursal
                             join t in Context.tbl_queja_tipo
                             on q.IdQueja_tipo equals t.IdQueja_tipo
                             where IdSucursal_ini <= q.IdSucursal && q.IdSucursal <= IdSucursal_fin
                             && IdQueja_tipo_ini <= q.IdQueja_tipo && q.IdQueja_tipo <= IdQueja_tipo_fin
                             && fecha_ini <= q.qu_fecha && q.qu_fecha <= Fecha_fin
                             && q.estado == true
                             group q by new { q.IdSucursal, s.su_descripcion, t.qt_descripcion } into grouping
                             select new tbl_reporte_sucursal_tipo
                             {
                                 su_descripcion = grouping.Key.su_descripcion,
                                 qt_descripcion = grouping.Key.qt_descripcion,
                                 cantidad_quejas = grouping.Count()
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<tbl_reporte_tipo> get_list_tipo(int IdSucursal, int IdQueja_tipo, int IdQueja_motivo, DateTime? fecha_ini, DateTime? Fecha_fin)
        {
            try
            {
                int IdQueja_tipo_ini = IdQueja_tipo;
                int IdQueja_tipo_fin = IdQueja_tipo == 0 ? 9999 : IdQueja_tipo;

                int IdQueja_motivo_ini = IdQueja_motivo;
                int IdQueja_motivo_fin = IdQueja_motivo == 0 ? 9999 : IdQueja_motivo;

                int IdSucursal_ini = IdSucursal;
                int IdSucursal_fin = IdSucursal == 0 ? 9999 : IdSucursal;

                fecha_ini = fecha_ini == null ? new DateTime(DateTime.Now.Year, 1, 1) : Convert.ToDateTime(fecha_ini).Date;
                Fecha_fin = Fecha_fin == null ? new DateTime(DateTime.Now.Year, 12, 31) : Convert.ToDateTime(Fecha_fin).Date;

                List<tbl_reporte_tipo> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja
                             join t in Context.tbl_queja_tipo
                             on q.IdQueja_tipo equals t.IdQueja_tipo
                             where IdQueja_tipo_ini <= q.IdQueja_tipo && q.IdQueja_tipo <= IdQueja_tipo_fin
                             && IdQueja_motivo_ini <= q.IdQueja_motivo && q.IdQueja_motivo <= IdQueja_motivo_fin
                             && IdSucursal_ini <= q.IdSucursal && q.IdSucursal <= IdSucursal_fin
                             && fecha_ini <= q.qu_fecha && q.qu_fecha <= Fecha_fin
                             && q.estado == true
                             group q by new { q.IdQueja_tipo, t.qt_descripcion } into grouping
                             select new tbl_reporte_tipo
                             {
                                 qt_descripcion = grouping.Key.qt_descripcion,
                                 cantidad_quejas = grouping.Count()
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<tbl_reporte_tipo_motivo> get_list_tipo_motivo(int IdSucursal, int IdQueja_tipo, int IdQueja_motivo, DateTime? fecha_ini, DateTime? Fecha_fin)
        {
            try
            {
                int IdQueja_tipo_ini = IdQueja_tipo;
                int IdQueja_tipo_fin = IdQueja_tipo == 0 ? 9999 : IdQueja_tipo;

                int IdQueja_motivo_ini = IdQueja_motivo;
                int IdQueja_motivo_fin = IdQueja_motivo == 0 ? 9999 : IdQueja_motivo;

                int IdSucursal_ini = IdSucursal;
                int IdSucursal_fin = IdSucursal == 0 ? 9999 : IdSucursal;

                fecha_ini = fecha_ini == null ? new DateTime(DateTime.Now.Year, 1, 1) : Convert.ToDateTime(fecha_ini).Date;
                Fecha_fin = Fecha_fin == null ? new DateTime(DateTime.Now.Year, 12, 31) : Convert.ToDateTime(Fecha_fin).Date;

                List<tbl_reporte_tipo_motivo> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja
                             join t in Context.tbl_queja_tipo
                             on q.IdQueja_tipo equals t.IdQueja_tipo
                             join m in Context.tbl_queja_tipo_motivo
                             on q.IdQueja_motivo equals m.IdQueja_motivo
                             where IdQueja_tipo_ini <= q.IdQueja_tipo && q.IdQueja_tipo <= IdQueja_tipo_fin
                             && IdQueja_motivo_ini <= q.IdQueja_motivo && q.IdQueja_motivo <= IdQueja_motivo_fin
                             && IdSucursal_ini <= q.IdSucursal && q.IdSucursal <= IdSucursal_fin
                             && fecha_ini <= q.qu_fecha && q.qu_fecha <= Fecha_fin
                             && q.estado == true
                             group q by new { q.IdQueja_tipo, t.qt_descripcion, m.IdQueja_motivo, m.qm_descripcion } into grouping
                             select new tbl_reporte_tipo_motivo
                             {
                                 qt_descripcion = grouping.Key.qt_descripcion,
                                 qm_descripcion = grouping.Key.qm_descripcion,
                                 cantidad_quejas = grouping.Count()
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<tbl_reporte_departamento> get_list_departamento(int IdDepartamento,int IdQueja_tipo, DateTime? fecha_ini, DateTime? Fecha_fin)
        {
            try
            {
                int IdDepartamento_ini = IdDepartamento;
                int IdDepartamento_fin = IdDepartamento == 0 ? 9999 : IdDepartamento;

                int IdQueja_tipo_ini = IdQueja_tipo;
                int IdQueja_tipo_fin = IdQueja_tipo == 0 ? 9999 : IdQueja_tipo;

                fecha_ini = fecha_ini == null ? new DateTime(DateTime.Now.Year, 1, 1) : Convert.ToDateTime(fecha_ini).Date;
                Fecha_fin = Fecha_fin == null ? new DateTime(DateTime.Now.Year, 12, 31) : Convert.ToDateTime(Fecha_fin).Date;

                List<tbl_reporte_departamento> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja
                             join d in Context.tbl_departamento
                             on q.IdDepartamento equals d.IdDepartamento
                             where IdDepartamento_ini <= q.IdDepartamento && q.IdDepartamento <= IdDepartamento_fin
                             && IdQueja_tipo_ini <= q.IdQueja_tipo && q.IdQueja_tipo <= IdQueja_tipo_fin
                             && fecha_ini <= q.qu_fecha && q.qu_fecha <= Fecha_fin
                             && q.estado == true
                             group q by new { q.IdDepartamento, d.de_descripcion } into grouping
                             select new tbl_reporte_departamento
                             {
                                 de_descripcion = grouping.Key.de_descripcion,
                                 cantidad_quejas = grouping.Count()
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<tbl_reporte_departamento_tipo> get_list_departamento_tipo(int IdDepartamento,int IdQueja_tipo, DateTime? fecha_ini, DateTime? Fecha_fin)
        {
            try
            {
                int IdDepartamento_ini = IdDepartamento;
                int IdDepartamento_fin = IdDepartamento == 0 ? 9999 : IdDepartamento;

                fecha_ini = fecha_ini == null ? new DateTime(DateTime.Now.Year, 1, 1) : Convert.ToDateTime(fecha_ini).Date;
                Fecha_fin = Fecha_fin == null ? new DateTime(DateTime.Now.Year, 12, 31) : Convert.ToDateTime(Fecha_fin).Date;

                int IdQueja_tipo_ini = IdQueja_tipo;
                int IdQueja_tipo_fin = IdQueja_tipo == 0 ? 9999 : IdQueja_tipo;

                List<tbl_reporte_departamento_tipo> Lista;

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_queja
                             join d in Context.tbl_departamento
                             on q.IdDepartamento equals d.IdDepartamento
                             join t in Context.tbl_queja_tipo
                             on q.IdQueja_tipo equals t.IdQueja_tipo
                             where IdDepartamento_ini <= q.IdDepartamento && q.IdDepartamento <= IdDepartamento_fin
                             && IdQueja_tipo_ini <= q.IdQueja_tipo && q.IdQueja_tipo <= IdQueja_tipo_fin
                             && fecha_ini <= q.qu_fecha && q.qu_fecha <= Fecha_fin
                             && q.estado == true
                             group q by new { q.IdDepartamento, d.de_descripcion, t.qt_descripcion } into grouping
                             select new tbl_reporte_departamento_tipo
                             {
                                 de_descripcion = grouping.Key.de_descripcion,
                                 qt_descripcion = grouping.Key.qt_descripcion,
                                 cantidad_quejas = grouping.Count()
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
