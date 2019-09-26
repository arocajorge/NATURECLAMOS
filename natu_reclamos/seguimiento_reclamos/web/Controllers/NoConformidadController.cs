using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using data.general;
using info.general;
using web.Filters;

namespace web.Controllers
{
    [WebSecurityAuthorize]
    public class NoConformidadController : Controller
    {
        tbl_reporte_no_conformidad_Data odata = new tbl_reporte_no_conformidad_Data();
        tbl_reporte_no_conformidad_det_Data odata_det = new tbl_reporte_no_conformidad_det_Data();
        tbl_reporte_no_conformidad_det_List list = new tbl_reporte_no_conformidad_det_List();
        string mensaje = "";
        public ActionResult Index()
        {
            return View();
        }
        private bool validar(tbl_reporte_no_conformidad_Info i_validar, ref string msg)
        {
            try
            {
                if(i_validar.IdNoConformidad_tipo == 0)
                {
                    msg = "El campo Tipo es obligatorio";
                    return false;
                }
                if (i_validar.IdQueja == 0)
                {
                    msg = "El campo mejora es obligatorio";
                    return false;
                }
                if (i_validar.nc_descripcion == null)
                {
                    msg = "El campo descripción es obligatorio";
                    return false;
                }
                if (i_validar.nc_fecha == null)
                {
                    msg = "El campo fecha es obligatorio";
                    return false;
                }
                
                i_validar.IdUsuario = User.Identity.Name;
                i_validar.lst_det = (List<tbl_reporte_no_conformidad_det_Info>)HttpContext.Session["Persons"];
                i_validar.lst_det = i_validar.lst_det.Where(q => q.nd_actividad != null).ToList();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Nuevo(decimal? IdQueja)
        {
            try
            {
                if(IdQueja == null)
                    return RedirectToAction("Index", "NoConformidad");
                tbl_reporte_no_conformidad_Info model = odata.get_info_x_queja(Convert.ToDecimal(IdQueja));
                if (model != null)
                    return RedirectToAction("Modificar", "NoConformidad", new { IdNoConformidad = model.IdNoConformidad });
                model = new tbl_reporte_no_conformidad_Info
                {
                    nc_fecha = DateTime.Now.Date,
                    IdQueja = Convert.ToDecimal(IdQueja)
                };
                cargar_combos();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Nuevo(tbl_reporte_no_conformidad_Info model)
        {
            try
            {
                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    cargar_combos();
                    return View(model);
                }
                if (!odata.guardarDB(model))
                {
                    ViewBag.mensaje = "No se ha podido guardar el registro";
                    cargar_combos();
                    return View(model);
                }
                HttpContext.Session["Persons"] = null;
                return RedirectToAction("Index", "NoConformidad");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Modificar(decimal? IdNoConformidad)
        {
            try
            {
                if(IdNoConformidad == null)
                    return RedirectToAction("Index", "NoConformidad");
                tbl_reporte_no_conformidad_Info model = odata.get_info(Convert.ToDecimal(IdNoConformidad));
                if (model == null)
                    return RedirectToAction("Index", "NoConformidad");
                model.lst_det = odata_det.get_list(Convert.ToInt32(IdNoConformidad));
                list.set_list(model.lst_det);
                cargar_combos();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(tbl_reporte_no_conformidad_Info model)
        {
            try
            {
                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    cargar_combos();
                    return View(model);
                }
                if (!odata.modificarDB(model))
                {
                    ViewBag.mensaje = "No se ha podido modificar el registro";
                    cargar_combos();
                    return View(model);
                }
                return RedirectToAction("Index", "NoConformidad");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Anular(decimal? IdNoConformidad)
        {
            try
            {
                if (IdNoConformidad == null)
                    return RedirectToAction("Index", "NoConformidad");
                tbl_reporte_no_conformidad_Info model = odata.get_info(Convert.ToDecimal(IdNoConformidad));
                if (model == null)
                    return RedirectToAction("Index", "NoConformidad");
                model.lst_det = odata_det.get_list(Convert.ToInt32(IdNoConformidad));
                list.set_list(model.lst_det);
                cargar_combos();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Anular(tbl_reporte_no_conformidad_Info model)
        {
            try
            {
                if (!odata.anularDB(model))
                {
                    ViewBag.mensaje = "No se ha podido anular el registro";
                    cargar_combos();
                    return View(model);
                }
                return RedirectToAction("Index", "NoConformidad");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_noConformidad()
        {
            var model = odata.get_list();
            return PartialView("_GridViewPartial_noConformidad", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_noConformidad_det(decimal? IdNoConformidad)
        {
            tbl_reporte_no_conformidad_Info model = new tbl_reporte_no_conformidad_Info();
            if (IdNoConformidad != null)
            {
                List<tbl_reporte_no_conformidad_det_Info> lst_det = odata_det.get_list(Convert.ToDecimal(IdNoConformidad));
                if (lst_det.Count > 0)
                    model.lst_det = lst_det;

                list.set_list(model.lst_det);
            }
            return PartialView("_GridViewPartial_noConformidad_det",model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] tbl_reporte_no_conformidad_det_Info info_det)
        {
            if (ModelState.IsValid)
                list.AddRow(info_det);
            tbl_reporte_no_conformidad_Info model = new tbl_reporte_no_conformidad_Info();
            model.lst_det = list.get_list();
            return PartialView("_GridViewPartial_noConformidad_det", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] tbl_reporte_no_conformidad_det_Info info_det)
        {
            if (ModelState.IsValid)
                list.UpdateRow(info_det);
            tbl_reporte_no_conformidad_Info model = new tbl_reporte_no_conformidad_Info();
            model.lst_det = list.get_list();
            return PartialView("_GridViewPartial_noConformidad_det", model);
        }

        public ActionResult EditingDelete(int secuencia)
        {
            list.DeleteRow(secuencia);
            tbl_reporte_no_conformidad_Info model = new tbl_reporte_no_conformidad_Info();
            model.lst_det = list.get_list();
            return PartialView("_GridViewPartial_noConformidad_det", model);
        }

        private void cargar_combos()
        {
            try
            {
                tbl_reporte_no_conformidad_tipo_Data odata_t = new tbl_reporte_no_conformidad_tipo_Data();
                ViewBag.lst_tipo = odata_t.get_list(); 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class tbl_reporte_no_conformidad_det_List
    {
        public List<tbl_reporte_no_conformidad_det_Info> get_list()
        {
            if (HttpContext.Current.Session["Persons"] == null)
            {
                List<tbl_reporte_no_conformidad_det_Info> list = new List<tbl_reporte_no_conformidad_det_Info>();

                HttpContext.Current.Session["Persons"] = list;
            }
            return (List<tbl_reporte_no_conformidad_det_Info>)HttpContext.Current.Session["Persons"];
        }

        public void set_list(List<tbl_reporte_no_conformidad_det_Info> list)
        {
            HttpContext.Current.Session["Persons"] = list;            
        }

        public void AddRow(tbl_reporte_no_conformidad_det_Info info_det)
        {
            List<tbl_reporte_no_conformidad_det_Info> list = get_list();
            info_det.secuencia = list.Count + 1;
            list.Add(info_det);
        }

        public void UpdateRow(tbl_reporte_no_conformidad_det_Info info_det)
        {
            tbl_reporte_no_conformidad_det_Info edited_info = get_list().Where(m => m.secuencia == info_det.secuencia).First();

            edited_info.nd_actividad = info_det.nd_actividad;
            edited_info.nd_plazo = info_det.nd_plazo;
            edited_info.nd_responsable = info_det.nd_responsable;
        }

        public void DeleteRow(int secuencia)
        {
            List<tbl_reporte_no_conformidad_det_Info> list = get_list();
            list.Remove(list.Where(m => m.secuencia == secuencia).First());
        }
    }
}