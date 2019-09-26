using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.reportes
{
    public class tbl_reporte_Info
    {
        [Display(Name ="Sucursal")]
        public Nullable<int> IdSucursal { get; set; }
        [Display(Name = "Tipo")]
        public Nullable<int> IdQueja_tipo { get; set; }
        [Display(Name = "Motivo")]
        public Nullable<int> IdQueja_motivo { get; set; }
        [Display(Name = "Departamento")]
        public Nullable<int> IdDepartamento { get; set; }
        [Display(Name = "Fecha inicio")]
        public Nullable<DateTime> Fecha_ini { get; set; }
        [Display(Name = "Fecha fin")]
        public Nullable<DateTime> Fecha_fin { get; set; }
        [Display(Name = "Mejoras totales")]
        public Nullable<decimal> cantidad_quejas_totales { get; set; }
        public List<tbl_reporte_sucursal> lst_det_sucursal { get; set; }
        public List<tbl_reporte_sucursal_tipo> lst_det_sucursal_tipo { get; set; }
        public List<tbl_reporte_tipo> lst_det_tipo { get; set; }
        public List<tbl_reporte_tipo_motivo> lst_det_tipo_motivo { get; set; }
        public List<tbl_reporte_departamento> lst_det_departamento { get; set; }
        public List<tbl_reporte_departamento_tipo> lst_det_departamento_tipo { get; set; }
        public tbl_reporte_Info()
        {
            lst_det_sucursal = new List<tbl_reporte_sucursal>();
            lst_det_sucursal_tipo = new List<tbl_reporte_sucursal_tipo>();
            lst_det_tipo = new List<tbl_reporte_tipo>();
            lst_det_tipo_motivo = new List<tbl_reporte_tipo_motivo>();
            lst_det_departamento = new List<tbl_reporte_departamento>();
            lst_det_departamento_tipo = new List<tbl_reporte_departamento_tipo>();
        }
        
    }

    public class tbl_reporte_sucursal
    {
        [Display(Name = "Cantidad mejoras")]
        public decimal cantidad_quejas { get; set; }
        [Display(Name = "Sucursal")]
        public string su_descripcion { get; set; }
    }

    public class tbl_reporte_sucursal_tipo
    {
        [Display(Name = "Cantidad mejoras")]
        public decimal cantidad_quejas { get; set; }
        [Display(Name = "Sucursal")]
        public string su_descripcion { get; set; }
        [Display(Name = "Tipo")]
        public string qt_descripcion { get; set; }
    }

    public class tbl_reporte_tipo
    {
        [Display(Name = "Cantidad mejoras")]
        public decimal cantidad_quejas { get; set; }
        [Display(Name = "Tipo")]
        public string qt_descripcion { get; set; }
    }

    public class tbl_reporte_tipo_motivo
    {
        [Display(Name = "Cantidad mejoras")]
        public decimal cantidad_quejas { get; set; }
        [Display(Name = "Tipo")]
        public string qt_descripcion { get; set; }
        [Display(Name = "Motivo")]
        public string qm_descripcion { get; set; }
    }

    public class tbl_reporte_departamento
    {
        [Display(Name = "Cantidad mejoras")]
        public decimal cantidad_quejas { get; set; }
        [Display(Name = "Departamento")]
        public string de_descripcion { get; set; }
    }

    public class tbl_reporte_departamento_tipo
    {
        [Display(Name = "Cantidad mejoras")]
        public decimal cantidad_quejas { get; set; }
        [Display(Name = "Departamento")]
        public string de_descripcion { get; set; }
        [Display(Name ="Tipo")]
        public string qt_descripcion { get; set; }
    }
}
