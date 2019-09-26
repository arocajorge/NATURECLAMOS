using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_queja_estado_Info
    {
        [Key]
        [Required]
        [Display(Name ="ID")]
        public int IdQueja_estado { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string qe_descripcion { get; set; }
        [Required]
        [Display(Name = "Se modifica")]
        public bool qe_se_modifica { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
