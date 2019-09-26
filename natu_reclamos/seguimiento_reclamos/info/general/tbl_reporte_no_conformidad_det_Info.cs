using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace info.general
{
    public class tbl_reporte_no_conformidad_det_Info
    {
        [Required]
        [Display(Name ="ID")]
        public decimal IdNoConformidad { get; set; }
        [Key]
        [Required]
        [Display(Name = "Secuencia")]
        public int secuencia { get; set; }
        [Required]
        [Display(Name = "Actividad")]
        public string nd_actividad { get; set; }
        [Required]
        [Display(Name = "Días plazo")]
        public int nd_plazo { get; set; }
        [Required]
        [Display(Name = "Responsable")]
        public string nd_responsable { get; set; }

        

    }
}
