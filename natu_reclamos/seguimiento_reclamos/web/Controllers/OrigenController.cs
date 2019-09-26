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
    public class OrigenController : Controller
    {
        tbl_queja_origen_Data odata = new tbl_queja_origen_Data();
        string mensaje = "";
        public ActionResult Index()
        {
            return View();
        }
        private bool validar(tbl_queja_origen_Info i_validar, ref string msg)
        {
            try
            {
                if (i_validar.qo_descripcion == null)
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
            try
            {
                tbl_queja_origen_Info model = new tbl_queja_origen_Info();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Nuevo(tbl_queja_origen_Info model)
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
                    ViewBag.mensaje = "No se ha podido guardar el registro";
                    return View(model);
                }
                return RedirectToAction("Index", "Origen");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Modificar(int? IdQueja_origen)
        {
            try
            {
                if(IdQueja_origen == null)
                    return RedirectToAction("Index", "Origen");
                tbl_queja_origen_Info model = odata.get_info(Convert.ToInt32(IdQueja_origen));
                if(model == null)
                    return RedirectToAction("Index", "Origen");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(tbl_queja_origen_Info model)
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
                    ViewBag.mensaje = "No se ha podido modificar el registro";
                    return View(model);
                }
                return RedirectToAction("Index", "Origen");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Anular(int? IdQueja_origen)
        {
            try
            {
                if (IdQueja_origen == null)
                    return RedirectToAction("Index", "Origen");
                tbl_queja_origen_Info model = odata.get_info(Convert.ToInt32(IdQueja_origen));
                if (model == null)
                    return RedirectToAction("Index", "Origen");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Anular(tbl_queja_origen_Info model)
        {
            try
            {
                if (!odata.anularDB(model))
                {
                    ViewBag.mensaje = "No se ha podido anular el registro";
                    return View(model);
                }
                return RedirectToAction("Index", "Origen");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_origen()
        {
            var model = odata.get_list();
            return PartialView("_GridViewPartial_origen", model);
        }
    }
}