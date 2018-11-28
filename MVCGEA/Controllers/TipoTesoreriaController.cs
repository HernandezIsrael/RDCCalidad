using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class TipoTesoreriaController : Controller
    {
        TipoTesoreriaHelper teso = new TipoTesoreriaHelper();
        // GET: TipoTesoreria
        public ActionResult LibTipoTesoreria()
        {
            return View(teso.ListarTiposTesoreria());
        }
        public ActionResult EditTipoTesoreria(int id=0) {
            return PartialView(teso.ObtenerTipoTesoreria(id));
        }
        [HttpPost]
        public ActionResult Save(CaTipoTesoreria item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = teso.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoTesoreria;
                    return PartialView("~/Views/TipoTesoreria/EditTipoTesoreria.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = teso.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoTesoreria;
                    return PartialView("~/Views/TipoTesoreria/EditTipoTesoreria.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}