using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_mes_Info
    {
        public int IdMes { get; set; }
        [Display(Name ="Mes")]
        public string me_descripcion { get; set; }
        public string me_codigo { get; set; }
    }
}
