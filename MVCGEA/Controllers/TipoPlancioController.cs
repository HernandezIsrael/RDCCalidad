using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class TipoPlancioController : Controller
    {
        TipoRPlaneacionHelper plan = new TipoRPlaneacionHelper();
        // GET: TipoPlancio
        public ActionResult LibTipoPlancio() {
            return View(plan.ListarTiposPlancio());
        }
        public ActionResult EditTipoPlaneacion(int id=0) {
            return PartialView(plan.ObtenerTipo(id));
        }
        [HttpPost]
        public ActionResult Save(CaTipoRPlancio item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = plan.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoRPlancio;
                    return PartialView("~/Views/TipoPlancio/EditTipoPlaneacion.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = plan.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoRPlancio;
                    return PartialView("~/Views/TipoPlancio/EditTipoPlaneacion.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}