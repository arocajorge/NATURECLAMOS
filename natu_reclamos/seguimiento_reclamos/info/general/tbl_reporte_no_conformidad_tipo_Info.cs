using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_reporte_no_conformidad_tipo_Info
    {
        [Key]
        [Required]
        [Display(Name ="ID")]
        public int IdNoConformidad_tipo { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string nt_descripcion { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
