using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class MediosController : Controller
    {
        MedioEntregaHelper entrega = new MedioEntregaHelper();
        // GET: Medios
        public ActionResult LibMedios()
        {
            return View(entrega.ListarMedios());
        }
        public ActionResult EditMedio(int id=0)
        {
            return PartialView(entrega.ObtrenerMedio(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Medio_Entrega item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = entrega.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Medio;
                    return PartialView("~/Views/Medios/EditMedio.cshtml", item);
                }

            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = entrega.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Medio;
                    return PartialView("~/Views/Medio/EditMedio.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}