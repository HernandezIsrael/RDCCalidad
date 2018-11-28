using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class CSController : Controller
    {
        // GET: CS
        CSHelper socios = new CSHelper();
        UsersHelper users = new UsersHelper();
        public ActionResult LibCS()
        {
           // ViewBag.Listpartner = socios.ListarSocios();
            return View(socios.ListarCS());
        }
        public ActionResult EditCS(int id = 0) {

            ViewBag.Listpartner = socios.CmbCS();
            return PartialView(socios.ObtenerCS(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_CS cdcs)
        {
            //cdcs.Usuarios = users.ObtenerUsuario(cdcs.Id_Usuario.Value);

            if (ModelState.IsValid)
            {
                cdcs.F_Alta = DateTime.Now;
                cdcs.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = socios.Guardar(cdcs);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = cdcs.Id_CS;
                    return PartialView("~/Views/CS/EditCS.cshtml", cdcs);
                }

            }
            else
            {
                cdcs.F_Alta = DateTime.Now;
                cdcs.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = socios.Guardar(cdcs);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = cdcs.Id_CS;
                    return PartialView("~/Views/CS/EditCS.cshtml", cdcs);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}