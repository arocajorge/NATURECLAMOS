using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info.general
{
    public class tbl_parametros_correo_Info
    {
        [Key]
        [Display(Name ="ID")]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Correo")]
        [Required]
        public string correo_cuenta { get; set; }
        [Display(Name = "Correo destinatario")]
        [Required]
        public string correo_cuenta_destinatario { get; set; }
        [Display(Name = "Contraseña")]
        [Required]
        public string correo_contrasenia { get; set; }
        [Display(Name = "Asunto")]
        [Required]        
        public string correo_asunto { get; set; }
        [Display(Name = "Permitir ssl")]
        [Required]
        public bool permitir_ssl { get; set; }
        [Display(Name = "Puerto")]
        [Required]
        public int puerto { get; set; }
        [Display(Name = "Host")]
        [Required]
        public string host { get; set; }
        [Display(Name = "¿Enviar correo al guardar mejora?")]
        [Required]
        public bool enviar_correo_al_guardar_queja { get; set; }
        [Display(Name = "Usuario ftp")]
        public string ftp_usuario { get; set; }
        [Display(Name = "Contraseña ftp")]
        public string ftp_contrasenia { get; set; }
        [Display(Name = "Url ftp")]
        public string ftp_url { get; set; }
    }
}
