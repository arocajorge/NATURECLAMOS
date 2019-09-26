using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;
using web.Filters;
using web.Models;
using info.general;
using data.general;

namespace web.Controllers {
    [WebSecurityAuthorize]
    public class AccountController : Controller {

        tbl_usuario_data odata = new tbl_usuario_data();
        string mensaje = "";
        [AllowAnonymous]
        public ActionResult Login() {
            FormsAuthentication.SignOut();
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(tbl_usuario_info model, string returnUrl) {
            try
            {
                if (ModelState.IsValid)
                {
                    tbl_usuario_info info = odata.get_info(model.IdUsuario, model.us_contrasenia);
                    if (info == null)
                        return View();
                    else
                    {
                        FormsAuthentication.SetAuthCookie(info.IdUsuario, true);
                        
                        return RedirectToAction("Nuevo", "Reclamo");
                    }
                }
                
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public ActionResult LogOff() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        
        public ActionResult Index()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus) {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch(createStatus) {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion

        public ActionResult Nuevo()
        {
            try
            {
                tbl_usuario_info model = new tbl_usuario_info();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Nuevo(tbl_usuario_info model)
        {
            try
            {
                if (model == null)
                    return View();
                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View();
                }
                if (!odata.guardarDB(model,ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Modificar(string IdUsuario)
        {
            try
            {
                if (IdUsuario == null)
                    return RedirectToAction("Index", "Account");
                tbl_usuario_info model = odata.get_info(IdUsuario);
                if (model == null)
                    return RedirectToAction("Index", "Account");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(tbl_usuario_info model)
        {
            try
            {
                if (model == null)
                    return View();
                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View();
                }
                if (!odata.modificarDB(model))
                {
                    ViewBag.mensaje = "No se pudo modificar el registro";
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Anular(string IdUsuario)
        {
            try
            {
                if (IdUsuario == null)
                    return RedirectToAction("Index", "Account");
                tbl_usuario_info model = odata.get_info(IdUsuario);
                if (model == null)
                    return RedirectToAction("Index", "Account");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Anular(tbl_usuario_info model)
        {
            try
            {
                if (model == null)
                    return View();
                if (!odata.anularDB(model))
                {
                    ViewBag.mensaje = "No se pudo anular el registro";
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_usuario()
        {
            var model = odata.get_list();
            return PartialView("_GridViewPartial_usuario", model);
        }

        private bool validar(tbl_usuario_info i_validar, ref string msg)
        {
            try
            {
                if (i_validar.IdUsuario == null)
                {
                    msg = "El campo usuario es obligatorio";
                    return false;
                }
                if (i_validar.us_contrasenia == null)
                {
                    msg = "El compo contraseña es obligatorio";
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}