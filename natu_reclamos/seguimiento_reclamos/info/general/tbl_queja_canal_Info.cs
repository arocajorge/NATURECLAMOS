using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_queja_canal_Info
    {
        [Key]
        [Required]
        [Display(Name ="ID")]
        public int IdQueja_canal { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string qc_descripcion { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
