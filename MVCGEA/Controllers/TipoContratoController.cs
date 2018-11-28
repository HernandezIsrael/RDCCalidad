using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class TipoContratoController : Controller
    {
        TipoContratoHelper Items = new TipoContratoHelper();
        // GET: TipoContrato
        public ActionResult LibTipoContrato()
        {
            return View(Items.ListarTipoContrato());
        }
        public ActionResult EditTipoContrato(int id=0) {
            return PartialView(Items.ObtenerTipoContrato(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Tipo_Contrato item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = Items.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Tipo_Contrato;
                    return PartialView("~/Views/TipoContrato/EditTipoContrato.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = Items.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Tipo_Contrato;
                    return PartialView("~/Views/TipoContrato/EditTipoContrato.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}