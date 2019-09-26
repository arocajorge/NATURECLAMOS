using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_usuario_info
    {
        [Key]
        [Required]
        [Display(Name ="Usuario")]
        public string IdUsuario { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string us_contrasenia { get; set; }
        [Display(Name = "Nombre")]
        public string us_nombre { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool us_estado { get; set; }
    }
}
