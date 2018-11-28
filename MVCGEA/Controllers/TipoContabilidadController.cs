using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class TipoContabilidadController : Controller
    {
        TipoDContaHelper cont = new TipoDContaHelper();
        // GET: TipoContabilidad
        public ActionResult LibTipoConta()
        {
            return View(cont.ListarTipoConta());
        }
        public ActionResult EditTipoConta(int id=0) {
            return PartialView(cont.ObtenerTipoConta(id));
        }
        [HttpPost]
        public ActionResult Save(CaTipoRConta item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = cont.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoRConta;
                    return PartialView("~/Views/TipoContabilidad/EditTipoConta.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = cont.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoRConta;
                    return PartialView("~/Views/TipoContabilidad/EditTipoConta.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}