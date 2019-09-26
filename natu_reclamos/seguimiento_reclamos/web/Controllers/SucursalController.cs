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
    public class SucursalController : Controller
    {
        tbl_sucursal_Data odata = new tbl_sucursal_Data();
        string mensaje = "";
        public ActionResult Index()
        {
            return View();
        }
        private bool validar(tbl_sucursal_Info i_validar, ref string msg)
        {
            try
            {
                if (i_validar.su_descripcion == null)
                {
                    msg = "El campo descripción es obligatorio";
                    return false;
                }
                if (i_validar.su_codigo == null)
                {
                    msg = "El campo código es obligatorio";
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
            tbl_sucursal_Info model = new tbl_sucursal_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(tbl_sucursal_Info model)
        {
            try
            {
                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View(model);
                }
                if (!odata.guardarDB(model))
                {
                    ViewBag.mensaje = "No se pudo guardar el registro";
                    return View(model);
                }
                return RedirectToAction("Index", "Sucursal");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Modificar(int? IdSucursal)
        {
            if(IdSucursal == null)
                return RedirectToAction("Index", "Sucursal");

            tbl_sucursal_Info model = odata.get_info(Convert.ToInt32(IdSucursal));
            if (model == null)
                return RedirectToAction("Index", "Sucursal");

            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(tbl_sucursal_Info model)
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
                return RedirectToAction("Index", "Sucursal");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Anular(int? IdSucursal)
        {
            if (IdSucursal == null)
                return RedirectToAction("Index", "Sucursal");

            tbl_sucursal_Info model = odata.get_info(Convert.ToInt32(IdSucursal));
            if (model == null)
                return RedirectToAction("Index", "Sucursal");

            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(tbl_sucursal_Info model)
        {
            try
            {
                if (!odata.anularDB(model))
                {
                    ViewBag.mensaje = "No se pudo anular el registro";
                    return View(model);
                }
                return RedirectToAction("Index", "Sucursal");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_sucursal()
        {
            var model = odata.get_list();
            return PartialView("_GridViewPartial_sucursal", model);
        }        
    }
}