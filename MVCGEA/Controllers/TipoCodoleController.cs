using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace MVCGEA.Controllers
{
    public class TipoCodoleController : Controller
    {/*
        TipoCodoleHelper tc = new TipoCodoleHelper();
        // GET: TipoCodole
        public ActionResult LibTipoCodole()
        {
            return View(tc.ListarTipos());
        }
        public ActionResult EditTipoCodole(int id = 0)
        {
            return PartialView(tc.ObtenerTipo(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Tipo_Codole item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = tc.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Tipo_Codole;
                    return PartialView("~/Views/TipoCodole/EditTipoCodole.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = tc.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Tipo_Codole;
                    return PartialView("~/Views/TipoCodole/EditTipoCodole.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }*/
    }
}