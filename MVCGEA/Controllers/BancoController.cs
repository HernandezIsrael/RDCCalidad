using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        BancoHelper bancos = new BancoHelper();
        public ActionResult EditBancos(int id = 0)
        {
            return PartialView(bancos.ObtenerBanco(id));
        }
        public ActionResult LibBancos()
        {
            return View(bancos.ListBancos());
        }
        [HttpPost]
        public ActionResult Save(Ca_Bancos item)
        {
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = bancos.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Banco;
                    return PartialView("~/Views/Banco/EditBancos.cshtml", item);
                }

            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = bancos.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Banco;
                    return PartialView("~/Views/Banco/EditBancos.cshtml", item);
                }
            }
            return JavaScript("Woo()");
        }

    }

}