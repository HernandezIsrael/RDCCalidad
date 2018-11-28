using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace MVCGEA.Controllers
{
    public class TipoEjecucionController : Controller
    {
        TipoEjecucionHelper ejec = new TipoEjecucionHelper();
        // GET: TipoEjecucion
        public ActionResult LibTipoEjecucion()
        {
            return View(ejec.ListarTiposDocumentos());
        }
        public ActionResult EditTipoEjecucion(int id=0) {
            return PartialView(ejec.ObetenerTipoEjecucion(id));
        }
        [HttpPost]
        public ActionResult Save(CaTipoREjecucion item)
        {
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = ejec.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoREjecucion;
                    return PartialView("~/Views/TipoEjecucion/EditTipoEjecucion.cshtml", item);
                }

            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = ejec.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoREjecucion;
                    return PartialView("~/Views/TipoEjecucion/EditTipoEjecucion.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}