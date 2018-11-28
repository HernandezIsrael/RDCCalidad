using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class TipoPagoController : Controller
    {
        TipoPagoHelper Tp = new TipoPagoHelper();
        // GET: TipoPago
        public ActionResult LibTipoPago()
        {
            return View(Tp.ListarTipoPagos());
        }
        public ActionResult EditTipoPago(int id=0) {
            return PartialView(Tp.ObtenerTipoPago(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Tipo_Pago item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = Tp.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Tipo_Pago;
                    return PartialView("~/Views/TipoPago/EditTipoPago.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = Tp.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Tipo_Pago;
                    return PartialView("~/Views/TipoPago/EditTipoPago.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}