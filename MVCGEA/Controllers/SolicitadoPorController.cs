using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class SolicitadoPorController : Controller
    {
        SolicitadoPorHelper soli = new SolicitadoPorHelper();
        // GET: SolicitadoPor
        public ActionResult LibSolicitado()
        {
            return View(soli.ListarSolicitados());
        }
        public ActionResult EditSolicitado(int id = 0)
        {
            return PartialView(soli.ObtenerSolicitados(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Solicitado_por item)
        {
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = soli.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Solicitado_por;
                    return PartialView("~/Views/SolicitadoPor/EditSolicitado.cshtml", item);
                }

            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = soli.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Solicitado_por;
                    return PartialView("~/Views/SolicitadoPor/EditSolicitado.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}