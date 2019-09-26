using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using info.reportes;
using data.reportes;
using data.general;
using info.general;
using web.Filters;

namespace web.Controllers
{
    [WebSecurityAuthorize]
    public class ReporteController : Controller
    {
        private void cargar_combos()
        {
            try
            {
                tbl_queja_tipo_Data odata_tipo = new tbl_queja_tipo_Data();
                ViewBag.lst_tipo = odata_tipo.get_list();
                tbl_sucursal_Data odata_sucursal = new tbl_sucursal_Data();
                ViewBag.lst_sucursal = odata_sucursal.get_list();
                tbl_departamento_Data odata_departamento = new tbl_departamento_Data();
                ViewBag.lst_departamento = odata_departamento.get_list();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Index()
        {
            tbl_reporte_Info model = new tbl_reporte_Info();
            cargar_combos();
            return View("Index",model);
        }
        [HttpPost]
        public ActionResult Index(tbl_reporte_Info options)
        {
            cargar_combos();
            if (options.IdQueja_tipo != null)
            {
                tbl_queja_tipo_motivo_Data data_motivo = new tbl_queja_tipo_motivo_Data();
                ViewBag.lst_motivo = data_motivo.get_list(Convert.ToInt32(options.IdQueja_tipo));
            }
            return View("Index", options);
        }        

        public ActionResult ChartPartial_rpt2(tbl_reporte_Info model)
        {
            tbl_reporte_Data odata = new tbl_reporte_Data();
            model.lst_det_sucursal_tipo = odata.get_list_sucursal_tipo(model.IdSucursal == null ? 0 : Convert.ToInt32(model.IdSucursal), model.IdQueja_tipo == null ? 0 : Convert.ToInt32(model.IdQueja_tipo), model.Fecha_ini, model.Fecha_fin);
            return PartialView("_ChartPartial_rpt2", model);
        }

        public ActionResult ChartPartial_rpt1(tbl_reporte_Info model)
        {
            tbl_reporte_Data odata = new tbl_reporte_Data();
            model.lst_det_sucursal = odata.get_list_sucursal(model.IdSucursal == null ? 0 : Convert.ToInt32(model.IdSucursal), model.IdQueja_tipo == null ? 0 : Convert.ToInt32(model.IdQueja_tipo), model.Fecha_ini, model.Fecha_fin);
            return PartialView("_ChartPartial_rpt1", model);
        }

        public ActionResult Tipos()
        {
            tbl_reporte_Info model = new tbl_reporte_Info();
            cargar_combos();
            return View("Tipos",model);
        }
        [HttpPost]
        public ActionResult Tipos(tbl_reporte_Info options)
        {
            cargar_combos();
            if (options.IdQueja_tipo != null)
            {
                tbl_queja_tipo_motivo_Data od_motivo = new tbl_queja_tipo_motivo_Data();
                ViewBag.lst_motivo = od_motivo.get_list(Convert.ToInt32(options.IdQueja_tipo));
            }
            return View("Tipos", options);
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
                tbl_reporte_Info model = new tbl_reporte_Info { IdQueja_tipo = IdQueja_tipo };
                return PartialView("_ComboBoxPartial_motivo_x_tipo",model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult ChartPartial_rpt1t(tbl_reporte_Info model)
        {
            tbl_reporte_Data odata = new tbl_reporte_Data();
            model.lst_det_tipo = odata.get_list_tipo(model.IdSucursal == null ? 0 : Convert.ToInt32(model.IdSucursal), model.IdQueja_tipo == null ? 0 : Convert.ToInt32(model.IdQueja_tipo), model.IdQueja_motivo == null ? 0 : Convert.ToInt32(model.IdQueja_motivo), model.Fecha_ini, model.Fecha_fin);
            return PartialView("_ChartPartial_rpt1t", model);
        }

        public ActionResult ChartPartial_rpt2t(tbl_reporte_Info model)
        {
            tbl_reporte_Data odata = new tbl_reporte_Data();
            model.lst_det_tipo_motivo = odata.get_list_tipo_motivo(model.IdSucursal == null ? 0 : Convert.ToInt32(model.IdSucursal),model.IdQueja_tipo == null ? 0 : Convert.ToInt32(model.IdQueja_tipo), model.IdQueja_motivo == null ? 0 : Convert.ToInt32(model.IdQueja_motivo), model.Fecha_ini, model.Fecha_fin);
            return PartialView("_ChartPartial_rpt2t", model);
        }

        public ActionResult Departamentos()
        {
            tbl_reporte_Info model = new tbl_reporte_Info();
            cargar_combos();
            return View("Departamentos", model);
        }
        [HttpPost]
        public ActionResult Departamentos(tbl_reporte_Info options)
        {
            cargar_combos();
            return View("Departamentos", options);
        }

        public ActionResult ChartPartial_rpt1d(tbl_reporte_Info model)
        {
            tbl_reporte_Data odata = new tbl_reporte_Data();
            model.lst_det_departamento = odata.get_list_departamento(model.IdDepartamento == null ? 0 : Convert.ToInt32(model.IdDepartamento), model.IdQueja_tipo == null ? 0 : Convert.ToInt32(model.IdQueja_tipo), model.Fecha_ini, model.Fecha_fin);
            return PartialView("_ChartPartial_rpt1d", model);
        }

        public ActionResult ChartPartial_rpt2d(tbl_reporte_Info model)
        {
            tbl_reporte_Data odata = new tbl_reporte_Data();
            model.lst_det_departamento_tipo = odata.get_list_departamento_tipo(model.IdDepartamento == null ? 0 : Convert.ToInt32(model.IdDepartamento), model.IdQueja_tipo == null ? 0 : Convert.ToInt32(model.IdQueja_tipo), model.Fecha_ini, model.Fecha_fin);
            return PartialView("_ChartPartial_rpt2d", model);
        }
    }
}