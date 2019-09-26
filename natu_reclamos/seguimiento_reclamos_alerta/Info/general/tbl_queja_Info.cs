using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace info.general
{
    public class tbl_queja_Info
    {
        public decimal IdQueja { get; set; }
        public Nullable<int> IdQueja_canal { get; set; }
        public Nullable<int> IdQueja_origen { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public Nullable<int> IdDepartamento { get; set; }
        public Nullable<int> IdQueja_tipo { get; set; }
        public Nullable<int> IdQueja_motivo { get; set; }
        public Nullable<int> IdQueja_estado { get; set; }
        public string qu_detalle { get; set; }
        public string qu_solucion { get; set; }
        public System.DateTime qu_fecha { get; set; }
        public int IdMes { get; set; }
        public int qu_anio { get; set; }
        public string cl_nombre { get; set; }
        public string cl_telefono { get; set; }
        public string cl_correo { get; set; }
        public string IdUsuario { get; set; }
        public bool estado { get; set; }

        #region Filtros
        public Nullable<DateTime> fecha_ini { get; set; }
        public Nullable<DateTime> fecha_fin { get; set; }
        #endregion

        public tbl_queja_canal_Info info_canal { get; set; }
        public tbl_queja_estado_Info info_estado { get; set; }
        public tbl_queja_origen_Info info_origen { get; set; }
        public tbl_queja_tipo_Info info_tipo { get; set; }
        public tbl_queja_tipo_motivo_Info info_motivo { get; set; }
        public tbl_sucursal_Info info_sucursal { get; set; }
        public tbl_departamento_Info info_departamento { get; set; }
        public tbl_mes_Info info_mes { get; set; }        
        public string im_nombre { get; set; }
        public Nullable<int> dias_sin_atencion { get; set; }
        public List<tbl_queja_imagen> lst_imagenes { get; set; }

        public tbl_queja_Info()
        {
            info_canal = new tbl_queja_canal_Info();
            info_estado = new tbl_queja_estado_Info();
            info_origen = new tbl_queja_origen_Info();
            info_tipo = new tbl_queja_tipo_Info();
            info_motivo = new tbl_queja_tipo_motivo_Info();
            info_sucursal = new tbl_sucursal_Info();
            info_departamento = new tbl_departamento_Info();
            info_mes = new tbl_mes_Info();
            lst_imagenes = new List<tbl_queja_imagen>();
        }
    }
}
