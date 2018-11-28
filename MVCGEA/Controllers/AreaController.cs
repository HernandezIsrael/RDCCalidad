using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class AreaController : Controller
    {
        // CA_Areas Areas = new CA_Areas();
        AreasHelper Areas = new AreasHelper();
        // GET: Area
        public ActionResult LibAreas() {
            ViewBag.showError = false;
            ViewBag.OnIdError = 0;
            return View(Areas.ListAreas());
        }
        public ActionResult EditBanco(int id = 0) {
            return PartialView(Areas.ObtenerArea(id));
        }
        //public ActionResult Save(CA_Areas areas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        areas.Fecha_Creado = DateTime.Now;
        //        areas.Creado_Por = int.Parse(Session["IdUser"].ToString());
        //        int i = Areas.Guardar(areas);
        //        if (i == 0)
        //        {
        //            ViewBag.showError = true;
        //            ViewBag.OnIdError = areas.Id_CA_Area;
        //        }
        //    }
        //    else
        //    {
        //        areas.Fecha_Creado = DateTime.Now;
        //        areas.Creado_Por = int.Parse(Session["IdUser"].ToString());
        //        int i = Areas.Guardar(areas);
        //        if (i == 0)
        //        {
        //            ViewBag.showError = true;
        //            ViewBag.OnIdError = areas.Id_CA_Area;
        //        }
        //    }
        //    return View("~/Views/Area/LibAreas.cshtml", Areas.ListAreas());
        //}
        [HttpPost]
        public ActionResult Save(CA_Areas areas)
        {
            if (ModelState.IsValid)
            {
                areas.Fecha_Creado = DateTime.Now;
                areas.Creado_Por = int.Parse(Session["IdUser"].ToString());
                int i = Areas.Guardar(areas);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = areas.Id_CA_Area;
                    return PartialView("~/Views/Area/EditBanco.cshtml", areas);
                }
               
            }
            else
            {
                areas.Fecha_Creado = DateTime.Now;
                areas.Creado_Por = int.Parse(Session["IdUser"].ToString());
                int i = Areas.Guardar(areas);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = areas.Id_CA_Area;
                    return PartialView("~/Views/Area/EditBanco.cshtml", areas);
                }
            }
            return JavaScript("Woo()");
        }

    }
} 