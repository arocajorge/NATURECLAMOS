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
    public class DepartamentoController : Controller
    {
        tbl_departamento_Data odata = new tbl_departamento_Data();
        string mensaje = "";
        public ActionResult Index()
        {
            return View();
        }
        
        private bool validar(tbl_departamento_Info i_validar, ref string msg)
        {
            try
            {
                if (i_validar.de_descripcion == null)
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
            tbl_departamento_Info model = new tbl_departamento_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(tbl_departamento_Info model)
        {
            try
            {
                if(!validar(model,ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View(model);
                }
                if(!odata.guardarDB(model))
                {
                    ViewBag.mensaje = "No se pudo guardar el registro";
                    return View(model);
                }
                return RedirectToAction("Index", "Departamento");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Modificar(int? IdDepartamento)
        {
            try
            {
                if (IdDepartamento == null)
                    return RedirectToAction("Index", "Departamento");
                tbl_departamento_Info model = odata.get_info(Convert.ToInt32(IdDepartamento));
                if(model == null)
                    return RedirectToAction("Index", "Departamento");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(tbl_departamento_Info model)
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
                return RedirectToAction("Index", "Departamento");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Anular(int? IdDepartamento)
        {
            try
            {
                if (IdDepartamento == null)
                    return RedirectToAction("Index", "Departamento");
                tbl_departamento_Info model = odata.get_info(Convert.ToInt32(IdDepartamento));
                if (model == null)
                    return RedirectToAction("Index", "Departamento");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Anular(tbl_departamento_Info model)
        {
            try
            {
                if (!odata.anularDB(model))
                {
                    ViewBag.mensaje = "No se pudo anular el registro";
                    return View(model);
                }
                return RedirectToAction("Index", "Departamento");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_departamento()
        {
            var model = odata.get_list();
            return PartialView("_GridViewPartial_departamento", model);
        }
    }
}