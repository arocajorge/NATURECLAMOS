using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_parametros_correo_Info
    {
        public int Id { get; set; }
        public string correo_cuenta { get; set; }
        public string correo_cuenta_destinatario { get; set; }
        public string correo_contrasenia { get; set; }
        public string correo_asunto { get; set; }
        public bool permitir_ssl { get; set; }
        public int puerto { get; set; }
        public string host { get; set; }
        public bool enviar_correo_al_guardar_queja { get; set; }
        public string ftp_usuario { get; set; }
        public string ftp_contrasenia { get; set; }
        public string ftp_url { get; set; }
    }
}
