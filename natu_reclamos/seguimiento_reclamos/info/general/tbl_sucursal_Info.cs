using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_sucursal_Info
    {
        [Key]
        [Required]
        [Display(Name ="ID")]
        public int IdSucursal { get; set; }
        [Display(Name ="Código")]
        public string su_codigo { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string su_descripcion { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
