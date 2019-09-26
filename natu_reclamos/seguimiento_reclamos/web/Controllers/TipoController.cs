using DevExpress.Web.Mvc;
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
    public class TipoController : Controller
    {
        tbl_queja_tipo_Data odata = new tbl_queja_tipo_Data();
        string mensaje = "";
        public ActionResult Index()
        {
            return View();
        }
        private bool validar(tbl_queja_tipo_Info i_validar,ref string msg)
        {
            try
            {
                if (i_validar.qt_descripcion == null)
                {
                    msg = "El campo descripción es obligatorio";
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Nuevo()
        {
            tbl_queja_tipo_Info model = new tbl_queja_tipo_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(tbl_queja_tipo_Info model)
        {
            try
            {
                if (!validar(model,ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View(model);
                }
                if (!odata.guardarDB(model))
                {
                    ViewBag.mensaje = "No se pudo guardar el registro";
                    return View(model);
                }

                return RedirectToAction("Index", "Tipo");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Modificar(int? IdQueja_tipo)
        {
            try
            {
                if(IdQueja_tipo == null)
                    return RedirectToAction("Index", "Tipo");
                tbl_queja_tipo_Info model = odata.get_info(Convert.ToInt32(IdQueja_tipo));
                if(model == null)
                    return RedirectToAction("Index", "Tipo");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(tbl_queja_tipo_Info model)
        {
            try
            {
                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View(model);
                }
                if (!odata.modificarDB(model))
                {
                    ViewBag.mensaje = "No se pudo modificar el registro";
                    return View(model);
                }

                return RedirectToAction("Index", "Tipo");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Anular(int? IdQueja_tipo)
        {
            try
            {
                if (IdQueja_tipo == null)
                    return RedirectToAction("Index", "Tipo");
                tbl_queja_tipo_Info model = odata.get_info(Convert.ToInt32(IdQueja_tipo));
                if (model == null)
                    return RedirectToAction("Index", "Tipo");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Anular(tbl_queja_tipo_Info model)
        {
            try
            {
                if (!odata.anularDB(model))
                {
                    ViewBag.mensaje = "No se pudo anular el registro";
                    return View(model);
                }

                return RedirectToAction("Index", "Tipo");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_tipo()
        {
            var model = odata.get_list();
            return PartialView("_GridViewPartial_tipo", model);
        }
    }
}