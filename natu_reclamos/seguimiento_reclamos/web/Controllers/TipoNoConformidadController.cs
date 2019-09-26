using DevExpress.Web.Mvc;
using data.general;
using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Filters;

namespace web.Controllers
{
    [WebSecurityAuthorize]
    public class TipoNoConformidadController : Controller
    {
        tbl_reporte_no_conformidad_tipo_Data odata = new tbl_reporte_no_conformidad_tipo_Data();
        string mensaje = "";
        public ActionResult Index()
        {
            return View();
        }
        private bool validar(tbl_reporte_no_conformidad_tipo_Info i_validar, ref string msg)
        {
            try
            {
                if (i_validar.nt_descripcion == null)
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
                tbl_reporte_no_conformidad_tipo_Info model = new tbl_reporte_no_conformidad_tipo_Info();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Nuevo(tbl_reporte_no_conformidad_tipo_Info model)
        {
            try
            {
                if(!validar(model,ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View(model);
                }
                if (!odata.guardarDB(model))
                {
                    ViewBag.mensaje = "No se ha podido guardar el registro";
                    return View(model);
                }

                return RedirectToAction("Index", "TipoNoConformidad");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_tipoNoConformidad()
        {
            var model = odata.get_list();
            return PartialView("_GridViewPartial_tipoNoConformidad", model);
        }
        public ActionResult Modificar(int? IdNoConformidad_tipo)
        {
            try
            {
                if(IdNoConformidad_tipo == null)
                    return RedirectToAction("Index", "TipoNoConformidad");
                tbl_reporte_no_conformidad_tipo_Info model = odata.get_info(Convert.ToInt32(IdNoConformidad_tipo));
                if (model == null)
                    return RedirectToAction("Index", "TipoNoConformidad");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(tbl_reporte_no_conformidad_tipo_Info model)
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

                return RedirectToAction("Index", "TipoNoConformidad");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Anular(int? IdNoConformidad_tipo)
        {
            try
            {
                if (IdNoConformidad_tipo == null)
                    return RedirectToAction("Index", "TipoNoConformidad");
                tbl_reporte_no_conformidad_tipo_Info model = odata.get_info(Convert.ToInt32(IdNoConformidad_tipo));
                if (model == null)
                    return RedirectToAction("Index", "TipoNoConformidad");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Anular(tbl_reporte_no_conformidad_tipo_Info model)
        {
            try
            {
                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View(model);
                }
                if (!odata.anularDB(model))
                {
                    ViewBag.mensaje = "No se ha podido anular el registro";
                    return View(model);
                }

                return RedirectToAction("Index", "TipoNoConformidad");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}