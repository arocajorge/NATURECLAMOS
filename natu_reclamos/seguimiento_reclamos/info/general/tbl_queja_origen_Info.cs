using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_queja_origen_Info
    {
        [Key]
        [Required]
        [Display(Name ="ID")]
        public int IdQueja_origen { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string qo_descripcion { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
