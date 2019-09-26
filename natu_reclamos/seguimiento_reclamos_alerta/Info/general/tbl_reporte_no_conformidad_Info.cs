using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_reporte_no_conformidad_Info
    {
        public decimal IdNoConformidad { get; set; }
        public int IdNoConformidad_tipo { get; set; }
        public decimal IdQueja { get; set; }
        public System.DateTime nc_fecha { get; set; }
        public string nc_descripcion { get; set; }
        public string nc_causa { get; set; }
        public string nc_cumplimiento { get; set; }
        public string nc_verificacion { get; set; }
        public Nullable<System.DateTime> nc_fecha_verificacion { get; set; }
        public string IdUsuario { get; set; }
        public bool estado { get; set; }
        public tbl_reporte_no_conformidad_tipo_Info info_tipo { get; set; }
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
