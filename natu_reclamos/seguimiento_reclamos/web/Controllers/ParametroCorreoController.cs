using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using info.general;
using data.general;
using web.Filters;

namespace web.Controllers
{
    [WebSecurityAuthorize]
    public class ParametroCorreoController : Controller
    {
        tbl_parametros_correo_Data odata = new tbl_parametros_correo_Data();
        string mensaje = "";
        public ActionResult Index()
        {
            tbl_parametros_correo_Info model = odata.get_info();
            if (model == null)
                model = new tbl_parametros_correo_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(tbl_parametros_correo_Info model)
        {
            if (!validar(model,ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                return View(model);
            }
            if (!odata.guardarDB(model))
            {
                ViewBag.mensaje = "No se ha podido guardar el registro";
                return View(model);
            }
            return RedirectToAction("Index"); ;
        }
        private bool validar(tbl_parametros_correo_Info i_validar, ref string msg)
        {
            if (string.IsNullOrEmpty(i_validar.correo_cuenta))
            {
                msg = "El campo cuenta es obligatorio";
                return false;
            }
            if (string.IsNullOrEmpty(i_validar.correo_cuenta_destinatario))
            {
                msg = "El campo cuenta destinatario es obligatorio";
                return false;
            }
            if (string.IsNullOrEmpty(i_validar.correo_contrasenia))
            {
                msg = "El campo contraseña es obligatorio";
                return false;
            }
            if (string.IsNullOrEmpty(i_validar.correo_asunto))
            {
                msg = "El campo asunto es obligatorio";
                return false;
            }
            if (string.IsNullOrEmpty(i_validar.host))
            {
                msg = "El campo host es obligatorio";
                return false;
            }

            return true;
        }
    }
}