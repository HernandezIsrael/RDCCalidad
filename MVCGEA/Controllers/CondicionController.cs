using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class CondicionController : Controller
    {
        CondicionHelper condiciones = new CondicionHelper();
        // GET: Condicion
        public ActionResult LibCondicion() {
            return View(condiciones.ListarCondiciones());
        }
        public ActionResult EditCondicion(int id=0) {
            return PartialView(condiciones.ObtenerCondicion(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Condicion item) {
            if (ModelState.IsValid) {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                int i = condiciones.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Condicion;
                    return PartialView("~/Views/Condicion/EditCondicion.cshtml", item);
                }
            }
            else {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                int i = condiciones.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Condicion;
                    return PartialView("~/Views/Condicion/EditCondicion.cshtml", item);
                }
            }

            return JavaScript("PopupOnClosed()");
        }
    }
}