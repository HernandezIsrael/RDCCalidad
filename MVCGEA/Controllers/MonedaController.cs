using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class MonedaController : Controller
    {
        MonedaHelper pesito = new MonedaHelper();
        // GET: Moneda
        public ActionResult LibMoneda()
        {
            return View(pesito.ListarMonedas());
        }
        public ActionResult EditMoneda(int id=0)
        {
            return PartialView(pesito.ObtenerMoneda(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Moneda centavos)
        {

            if (ModelState.IsValid)
            {
                centavos.F_Alta = DateTime.Now;
                centavos.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = pesito.Guardar(centavos);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = centavos.Id_Moneda;
                    return PartialView("~/Views/Moneda/EditMoneda.cshtml", centavos);
                }

            }
            else
            {
                centavos.F_Alta = DateTime.Now;
                centavos.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = pesito.Guardar(centavos);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = centavos.Id_Moneda;
                    return PartialView("~/Views/Moneda/EditMoneda.cshtml", centavos);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}