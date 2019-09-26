using Data.general;
using info.general;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Serv
{
    public partial class ServicioAlertaReclamos : ServiceBase
    {
        public static DateTime fecha_ult_ejecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
        public static bool ejecutado = false;

        public ServicioAlertaReclamos()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = TimeSpan.FromSeconds(40).TotalMilliseconds;
            aTimer.Enabled = true;
        }

        protected override void OnStop()
        {
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                int hora = 8;
                int minuto = 0;

                DateTime fecha_ejecucion = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, minuto, 0);
                DateTime fecha_actual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);


                if (ejecutado)
                {
                    if (fecha_ult_ejecucion < fecha_actual)
                    {
                        ejecutado = false;
                    }
                    else
                        return;
                }

                if (fecha_ejecucion != fecha_actual)
                 return;                
                else
                {
                    ejecutado = true;
                }

                tbl_parametros_correo_Data odata_param = new tbl_parametros_correo_Data();
                tbl_parametros_correo_Info info_param = new tbl_parametros_correo_Info();
                info_param = odata_param.get_info();

                List<tbl_queja_Info> list_quejas = new List<tbl_queja_Info>();
                tbl_queja_Data odata_queja = new tbl_queja_Data();
                list_quejas = odata_queja.get_list();

                if (list_quejas.Count == 0)
                {
                    Console.WriteLine("No existen reclamos sin atención");
                    return;
                }

                #region Armar cuerpo del correo correo
                MailMessage mail = new MailMessage();

                String[] correos = info_param.correo_cuenta_destinatario.Split(';');

                if (correos.Count() == 0)
                    return;

                foreach (var item in correos)
                {
                    if (!string.IsNullOrEmpty(item.Trim()))
                        mail.To.Add(item.Trim());
                }
                mail.From = new MailAddress(info_param.correo_cuenta);
                mail.Subject = "Alerta de seguimiento de reclamos no atendidos";

                string Body = "";
                Body += "<p> Acontinuación se detallan los reclamos sin atención </p><br>";
                Body += "<table border:'1'>";
                Body += "<tr>";
                Body += "<td><strong># Reclamo</strong></td>";
                Body += "<td><strong>Mes</strong></td>";
                Body += "<td><strong>Departamento</strong></td>";
                Body += "<td><strong>Tipo</strong></td>";
                Body += "<td><strong>Motivo</strong></td>";
                Body += "<td><strong>Sucursal</strong></td>";
                Body += "<td><strong>Canal</strong></td>";
                Body += "<td><strong>Estado</strong></td>";
                Body += "<td><strong>Fecha</strong></td>";
                Body += "<td><strong>Días sin atención</strong></td>";
                Body += "</tr>";

                foreach (var info_queja in list_quejas)
                {
                    Body += "<tr>";
                    Body += "<td>" + info_queja.IdQueja + "</td>";
                    Body += "<td>" + info_queja.info_mes.me_descripcion + "</td>";
                    Body += "<td>" + info_queja.info_departamento.de_descripcion + "</td>";
                    Body += "<td>" + info_queja.info_tipo.qt_descripcion + "</td>";
                    Body += "<td>" + info_queja.info_motivo.qm_descripcion + "</td>";
                    Body += "<td>" + info_queja.info_sucursal.su_descripcion + "</td>";
                    Body += "<td>" + info_queja.info_canal.qc_descripcion + "</td>";
                    Body += "<td>" + info_queja.info_estado.qe_descripcion + "</td>";
                    Body += "<td>" + info_queja.qu_fecha.ToShortDateString() + "</td>";
                    Body += "<td>" + info_queja.dias_sin_atencion + "</td>";
                    Body += "</tr>";
                }
                Body += "</table>";
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Body, null, "text/html");
                mail.AlternateViews.Add(htmlView);
                #endregion

                #region smtp
                SmtpClient smtp = new SmtpClient();
                smtp.Host = info_param.host;
                smtp.EnableSsl = info_param.permitir_ssl;
                smtp.Port = info_param.puerto;
                smtp.Credentials = new NetworkCredential(info_param.correo_cuenta, info_param.correo_contrasenia);
                smtp.Send(mail);
                #endregion

                Console.WriteLine("Correo enviado satisfactoriamente, \n Conteo de quejas: " + list_quejas.Count);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
