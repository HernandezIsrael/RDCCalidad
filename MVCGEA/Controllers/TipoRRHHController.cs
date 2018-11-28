using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class TipoRRHHController : Controller
    {
        TipoRRHHHelper rrhh = new TipoRRHHHelper();
        // GET: TipoRRHH
        public ActionResult LibTipoRRHH()
        {
            return View(rrhh.ListarTiposRRHHH());
        }
        public ActionResult EditTipoRRHH(int id=0) {
            return PartialView(rrhh.ObtenerTipo(id));
        }
        [HttpPost]
        public ActionResult Save(CaTipoRRHHD item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = rrhh.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoRRHHD;
                    return PartialView("~/Views/TipoRRHH/EditTipoRRHH.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = rrhh.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.IdTipoRRHHD;
                    return PartialView("~/Views/TipoRRHH/EditTipoRRHH.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}