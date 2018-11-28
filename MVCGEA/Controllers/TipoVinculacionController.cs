using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class TipoVinculacionController : Controller
    {
        TipoVinculacionesHelper vin = new TipoVinculacionesHelper();
        // GET: TipoVinculacion
        public ActionResult LibTipoVinculaciones()
        {
            return View(vin.ListarTipoVinculaciones());
        }
        public ActionResult EditTipoVinculaciones(int id=0) {
            return PartialView(vin.ObtenerTipo(id));
        }
        [HttpPost]
        public ActionResult Save(CaTipoRVinculaciones item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = vin.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoRVinculaciones;
                    return PartialView("~/Views/TipoVinculacion/EditTipoVinculaciones.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = vin.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoRVinculaciones;
                    return PartialView("~/Views/TipoVinculacion/EditTipoVinculaciones.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}