using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class TipoProcController : Controller
    {
        TipoProcesosHelper Proc = new TipoProcesosHelper();
        // GET: TipoProc
        public ActionResult LibTipoProcesos()
        {
            return View(Proc.ListarProcesos());
        }
        public ActionResult EditProcesos(int id=0) {
            return PartialView(Proc.ObtenerProceso(id));
        }
        [HttpPost]
        public ActionResult Save(CaTipoRProcesos item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = Proc.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoRProcesos;
                    return PartialView("~/Views/TipoProc/EditProcesos.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = Proc.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoRProcesos;
                    return PartialView("~/Views/TipoProc/EditProcesos.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}