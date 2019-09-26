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
    public class CanalController : Controller
    {
        tbl_queja_canal_Data odata = new tbl_queja_canal_Data();
        string mensaje = "";
        public ActionResult Index()
        {
            return View();
        }
        private bool validar(tbl_queja_canal_Info i_validar, ref string msg)
        {
            try
            {
                if (i_validar.qc_descripcion == null)
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
            tbl_queja_canal_Info model = new tbl_queja_canal_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(tbl_queja_canal_Info model)
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
                return RedirectToAction("Index", "Canal");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Modificar(int? IdQueja_canal)
        {
            try
            {
                if(IdQueja_canal == null)
                    return RedirectToAction("Index", "Canal");
                tbl_queja_canal_Info model = odata.get_info(Convert.ToInt32(IdQueja_canal));
                if(model == null)
                    return RedirectToAction("Index", "Canal");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(tbl_queja_canal_Info model)
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
            return RedirectToAction("Index", "Canal");
        }
        public ActionResult Anular(int? IdQueja_canal)
        {
            try
            {
                if (IdQueja_canal == null)
                    return RedirectToAction("Index", "Canal");
                tbl_queja_canal_Info model = odata.get_info(Convert.ToInt32(IdQueja_canal));
                if (model == null)
                    return RedirectToAction("Index", "Canal");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Anular(tbl_queja_canal_Info model)
        {
            if (!odata.anularDB(model))
            {
                ViewBag.mensaje = "No se pudo anular el registro";
                return View(model);
            }
            return RedirectToAction("Index", "Canal");
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_canal()
        {
            var model = odata.get_list();                
            return PartialView("_GridViewPartial_canal", model);
        }
    }
}