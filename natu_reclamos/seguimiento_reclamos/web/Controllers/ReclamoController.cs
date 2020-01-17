using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using info.general;
using data.general;
using web.Filters;
using System.Net.Mail;
using System.Net;
using DevExpress.Web;

namespace web.Controllers
{
    [Authorize]
    [WebSecurityAuthorize]
    
    public class ReclamoController : Controller
    {
        tbl_queja_Data odata = new tbl_queja_Data();
        tbl_parametros_correo_Data odata_param = new tbl_parametros_correo_Data();
        tbl_parametros_correo_Info info_param = new tbl_parametros_correo_Info();
        string mensaje = "";
        public ActionResult Index(DateTime? FechaIni, DateTime? FechaFin, int? IdQueja_estadoFiltro, int? IdDepartamentoFiltro)
        {
            tbl_queja_Info options = new tbl_queja_Info
            {
                fecha_ini = FechaIni,
                fecha_fin = FechaFin,
                IdQueja_estadoFiltro = IdQueja_estadoFiltro ?? 1,
                IdDepartamentoFiltro = IdDepartamentoFiltro
            };
            cargar_combos();
            return View(options);
        }
        [HttpPost]
        public ActionResult Index(tbl_queja_Info options)
        {
            cargar_combos();
            return View(options);
        }

        public ActionResult Imprimir(DateTime? fecha_ini, DateTime? fecha_fin, int IdDepartamento = 0, int IdQueja_estado = 0)
        {
            Rpt_quejas model = new Rpt_quejas();
            model.p_fecha_ini.Value = fecha_ini;
            model.p_fecha_fin.Value = fecha_fin;
            model.p_IdDepartamento.Value = IdDepartamento;
            model.p_IdQueja_estado.Value = IdQueja_estado;
            
            return View("Imprimir", model);
        }
        private bool validar(tbl_queja_Info i_validar, ref string msg)
        {
            try
            {
                if (i_validar.IdDepartamento == 0 || i_validar.IdDepartamento == null)
                {
                    msg = "El campo departamento es obligatorio";
                    return false;
                }
                if (i_validar.IdQueja_canal == 0 || i_validar.IdQueja_canal == null)
                {
                    msg = "El campo canal es obligatorio";
                    return false;
                }
                if (i_validar.IdSucursal == 0 || i_validar.IdSucursal == null)
                {
                    msg = "El campo sucursal es obligatorio";
                    return false;
                }
                if (i_validar.IdQueja_estado == 0 || i_validar.IdQueja_estado == null)
                {
                    msg = "El campo estado es obligatorio";
                    return false;
                }
                if (i_validar.IdQueja_origen == 0 || i_validar.IdQueja_origen == null)
                {
                    msg = "El campo origen es obligatorio";
                    return false;
                }
                if (i_validar.IdQueja_tipo == 0 || i_validar.IdQueja_tipo == null)
                {
                    msg = "El campo tipo es obligatorio";
                    return false;
                }
                if (i_validar.IdQueja_motivo == 0 || i_validar.IdQueja_motivo == null)
                {
                    msg = "El campo motivo es obligatorio";
                    return false;
                }
                if (i_validar.qu_fecha == null)
                {
                    msg = "El campo fecha es obligatorio";
                    return false;
                }
                i_validar.qu_anio = i_validar.qu_fecha.Year;
                i_validar.IdMes = i_validar.qu_fecha.Month;
                i_validar.IdUsuario = User.Identity.Name == null ? "admin" : User.Identity.Name;

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Nuevo(DateTime? FechaIni, DateTime? FechaFin, int? IdQueja_estadoFiltro, int? IdDepartamentoFiltro)
        {
            tbl_queja_Info model = new tbl_queja_Info
            {
                qu_fecha = DateTime.Now.Date,
                qu_fecha_evento = DateTime.Now.Date,
                IdQueja_estado = 1
            };
            if (FechaIni != null && FechaFin != null)
            {
                model.fecha_ini = FechaIni;
                model.fecha_fin = FechaFin;
                model.IdQueja_estadoFiltro = IdQueja_estadoFiltro;
                model.IdDepartamentoFiltro = IdDepartamentoFiltro;
            }
            cargar_combos();
            return View(model);
        }
        private void cargar_combos()
        {
            try
            {
                tbl_departamento_Data od_departamento = new tbl_departamento_Data();
                ViewBag.lst_departamento = od_departamento.get_list();
                tbl_queja_canal_Data od_canal = new tbl_queja_canal_Data();
                ViewBag.lst_canal = od_canal.get_list();
                tbl_queja_estado_Data od_estado = new tbl_queja_estado_Data();
                ViewBag.lst_estado = od_estado.get_list();
                tbl_sucursal_Data od_sucursal = new tbl_sucursal_Data();
                ViewBag.lst_sucursal = od_sucursal.get_list();
                tbl_queja_tipo_Data od_tipo = new tbl_queja_tipo_Data();
                ViewBag.lst_tipo = od_tipo.get_list();
                tbl_queja_tipo_motivo_Data od_motivo = new tbl_queja_tipo_motivo_Data();
                ViewBag.lst_motivo = od_motivo.get_list();
                tbl_queja_origen_Data od_origen = new tbl_queja_origen_Data();
                ViewBag.lst_origen = od_origen.get_list();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Nuevo(tbl_queja_Info model)
        {
            try
            {
                var files = UploadControlExtension.GetUploadedFiles("UploadControl", HomeControllerControllerUploadControlSettings.UploadControlValidationSettings, FileUploadComplete);

                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    cargar_combos();
                    return View(model);
                }
                if (!odata.guardarDB(model))
                {
                    ViewBag.mensaje = "No se pudo guardar el registro";
                    cargar_combos();
                    return View(model);
                }

                foreach (var item in files)
                {
                    if (item.ContentLength != 0)
                        FilesHelper.FtpUploadFile(item, item.FileName, model.IdQueja.ToString());
                }

                info_param = odata_param.get_info();
                if (info_param != null && info_param.enviar_correo_al_guardar_queja == true)
                    enviar_correo(model.IdQueja, true);

                return RedirectToAction("Index", "Reclamo", new { fecha_ini = model.fecha_ini, fecha_fin = model.fecha_fin, IdDepartamento = model.IdDepartamentoFiltro, IdQueja_estado = model.IdQueja_estadoFiltro });
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region subir multiples imagenes
        public void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
               //Por ahora no se como funciona esto
            }
        }
        
        #endregion

        private void enviar_correo(decimal IdQueja, bool EsNuevo)
        {
            #region Armar cuerpo del correo correo
            MailMessage mail = new MailMessage();

            String[] correos = info_param.correo_cuenta_destinatario.Split(';');

            if (correos.Count() == 0)
                return;

            foreach (var item in correos)
            {
                if(!string.IsNullOrEmpty(item.Trim()))
                    mail.To.Add(item.Trim());
            }            
            mail.From = new MailAddress(info_param.correo_cuenta);
            mail.Subject = info_param.correo_asunto;

            string Body = "";
            tbl_queja_Info info_queja = odata.get_info_correo(IdQueja);
            if (info_queja != null)
            {
                if (EsNuevo == true)
                {
                    Body += "<p> Se ha creado una nueva mejora desde la aplicación <strong>Seguimiento de mejoras Naturissimo</strong></p><br>";
                }
                else
                {
                    Body += "<p> Se ha modificado la mejora desde la aplicación <strong>Seguimiento de mejoras Naturissimo</strong></p><br>";
                }

                Body += "<strong># de Mejora: </strong>"+info_queja.IdQueja.ToString()+"<br>";
                Body += "<strong> Fecha: </strong>"+ info_queja .qu_fecha+ "<br>";
                Body += "<strong> Estado: </strong>"+ info_queja.info_estado.qe_descripcion + "<br>";
                Body += "<strong> Sucursal: </strong>"+ info_queja.info_sucursal.su_descripcion+ "<br>";
                Body += "<strong> Origen: </strong>"+info_queja.info_origen.qo_descripcion+"<br>";
                Body += "<strong> Canal: </strong>"+info_queja.info_canal.qc_descripcion+"<br>";
                Body += "<strong> Departamento: </strong>"+info_queja.info_departamento.de_descripcion+"<br>";
                Body += "<strong> Tipo: </strong>"+info_queja.info_tipo.qt_descripcion+"<br>";
                Body += "<strong> Motivo: </strong>"+info_queja.info_motivo.qm_descripcion+"<br>";
                Body += "<strong> Detalle: </strong>"+info_queja.qu_detalle+"<br>";
                Body += "<strong> Solución: </strong>"+info_queja.qu_solucion+"<br>";
                Body += "<strong> Usuario: </strong>"+info_queja.IdUsuario+"<br>";
                Body += "<strong> Nombre cliente: </strong>" + info_queja.cl_nombre + "<br>";
                Body += "<strong> Correo cliente: </strong>" + info_queja.cl_correo + "<br>";
                Body += "<strong> Teléfono cliente: </strong>" + info_queja.cl_telefono + "<br>";
            }
            else
                Body = "Mensaje sin contenido";

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
        }

        public ActionResult Modificar(decimal? IdQueja, DateTime? FechaIni, DateTime? FechaFin, int? IdQueja_estadoFiltro, int? IdDepartamentoFiltro)
        {
            try
            {
                if (IdQueja == null)
                    return RedirectToAction("Index", "Reclamo", new { fecha_ini = FechaIni, fecha_fin = FechaFin, IdDepartamento = IdDepartamentoFiltro, IdQueja_estado = IdQueja_estadoFiltro });
                tbl_queja_Info model = odata.get_info(Convert.ToInt32(IdQueja));
                if (model == null)
                    return RedirectToAction("Index", "Reclamo", new { fecha_ini = FechaIni, fecha_fin = FechaFin, IdDepartamento = IdDepartamentoFiltro, IdQueja_estado = IdQueja_estadoFiltro });
                cargar_combos();
                if (FechaIni != null && FechaFin != null)
                {
                    model.fecha_ini = FechaIni;
                    model.fecha_fin = FechaFin;
                    model.IdQueja_estadoFiltro = IdQueja_estadoFiltro;
                    model.IdDepartamentoFiltro = IdDepartamentoFiltro;
                }
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(tbl_queja_Info model)
        {
            try
            {
                var files = UploadControlExtension.GetUploadedFiles("UploadControl", HomeControllerControllerUploadControlSettings.UploadControlValidationSettings, FileUploadComplete);

                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    cargar_combos();
                    return View(model);
                }

                if (!odata.modificarDB(model))
                {
                    ViewBag.mensaje = "No se pudo modificar el registro";
                    cargar_combos();
                    return View(model);
                }

                foreach (var item in files)
                {
                    if (item.ContentLength != 0)
                        FilesHelper.FtpUploadFile(item, item.FileName, model.IdQueja.ToString());
                }

                info_param = odata_param.get_info();
                if (info_param != null && info_param.enviar_correo_al_guardar_queja == true)
                    enviar_correo(model.IdQueja, false);

                return RedirectToAction("Index", "Reclamo", new { fecha_ini = model.fecha_ini, fecha_fin = model.fecha_fin, IdDepartamento = model.IdDepartamentoFiltro, IdQueja_estado = model.IdQueja_estadoFiltro });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_reclamos(DateTime? fecha_ini, DateTime? fecha_fin, int? IdDepartamento, int? IdQueja_estado=0)
        {
            ViewBag.lst_queja = odata.get_list(fecha_ini, fecha_fin, IdDepartamento ?? 0, IdQueja_estado ?? 0);
            tbl_queja_Info model = new tbl_queja_Info
            {
                fecha_ini = fecha_ini,
                fecha_fin = fecha_fin,
                IdDepartamentoFiltro = IdDepartamento,
                IdQueja_estadoFiltro = IdQueja_estado
            };
            return PartialView("_GridViewPartial_reclamos",model);
        }

        public ActionResult Anular(decimal? IdQueja, DateTime? FechaIni, DateTime? FechaFin, int? IdQueja_estadoFiltro, int? IdDepartamentoFiltro)
        {
            try
            {
                if (IdQueja == null)
                    return RedirectToAction("Index", "Reclamo", new { fecha_ini = FechaIni, fecha_fin = FechaFin, IdDepartamento = IdDepartamentoFiltro, IdQueja_estado = IdQueja_estadoFiltro });
                tbl_queja_Info model = odata.get_info(Convert.ToInt32(IdQueja));
                if (model == null)
                    return RedirectToAction("Index", "Reclamo", new { fecha_ini = FechaIni, fecha_fin = FechaFin, IdDepartamento = IdDepartamentoFiltro, IdQueja_estado = IdQueja_estadoFiltro });
                cargar_combos();
                if (FechaIni != null && FechaFin != null)
                {
                    model.fecha_ini = FechaIni;
                    model.fecha_fin = FechaFin;
                    model.IdQueja_estadoFiltro = IdQueja_estadoFiltro;
                    model.IdDepartamentoFiltro = IdDepartamentoFiltro;
                }
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult Anular(tbl_queja_Info model)
        {
            try
            {
                if (!odata.anularDB(model))
                {
                    ViewBag.mensaje = "No se pudo anular el registro";
                    cargar_combos();
                    return View(model);
                }
                return RedirectToAction("Index", "Reclamo", new { fecha_ini = model.fecha_ini, fecha_fin = model.fecha_fin, IdDepartamento = model.IdDepartamentoFiltro, IdQueja_estado = model.IdQueja_estadoFiltro });
            }
            catch (Exception)
            {

                throw;
            }
        }        

        public ActionResult ComboBoxPartial_motivo_x_tipo(int? IdQueja_tipo)
        {
            try
            {
                if (IdQueja_tipo != null)
                {
                    tbl_queja_tipo_motivo_Data od_motivo = new tbl_queja_tipo_motivo_Data();
                    ViewBag.lst_motivo = od_motivo.get_list(Convert.ToInt32(IdQueja_tipo));
                }
                return PartialView("_ComboBoxPartial_motivo_x_tipo");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Adjuntos(decimal IdQueja = 0)
        {
            tbl_queja_Info model = new tbl_queja_Info();
            model.lst_imagenes = FilesHelper.get_list_directory(IdQueja);

            return View("_Adjuntos",model);
        }        
    }

    public class HomeControllerControllerUploadControlSettings
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadControlValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            MaxFileSize = 4194304
        };
    }
}