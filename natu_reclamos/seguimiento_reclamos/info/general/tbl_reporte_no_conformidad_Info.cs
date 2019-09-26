using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_reporte_no_conformidad_Info
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        public decimal IdNoConformidad { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public int IdNoConformidad_tipo { get; set; }
        [Required]
        [Display(Name = "Mejora")]
        public decimal IdQueja { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public System.DateTime nc_fecha { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string nc_descripcion { get; set; }
        [Display(Name = "Causa")]
        public string nc_causa { get; set; }
        [Display(Name = "Cumplimiento")]
        public string nc_cumplimiento { get; set; }
        [Display(Name = "Verificación")]
        public string nc_verificacion { get; set; }
        [Display(Name = "Fecha verificación")]
        public Nullable<System.DateTime> nc_fecha_verificacion { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string IdUsuario { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
        public tbl_reporte_no_conformidad_tipo_Info info_tipo { get; set; }
        [Display(Name ="Acciones a tomar")]
        public List<tbl_reporte_no_conformidad_det_Info> lst_det { get; set; }
        public tbl_reporte_no_conformidad_Info()
        {
            info_tipo = new tbl_reporte_no_conformidad_tipo_Info();
            lst_det = new List<tbl_reporte_no_conformidad_det_Info>();
            tbl_reporte_no_conformidad_det_Info det = new tbl_reporte_no_conformidad_det_Info
            {
                secuencia = 1
            };            
            lst_det.Add(det);
            det = new tbl_reporte_no_conformidad_det_Info
            {
                secuencia = 2
            };
            lst_det.Add(det);
        }
    }
}
