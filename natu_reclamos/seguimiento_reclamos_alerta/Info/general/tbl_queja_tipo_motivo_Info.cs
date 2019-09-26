using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_queja_tipo_motivo_Info
    {
        public int IdQueja_motivo { get; set; }
        public int IdQueja_tipo { get; set; }
        public string qm_descripcion { get; set; }
        public bool estado { get; set; }
    }
}
