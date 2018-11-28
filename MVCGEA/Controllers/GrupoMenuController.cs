using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class GrupoMenuController : Controller
    {
        // GET: GrupoMenu
       GrupoMenuHelper GrupoHelp = new GrupoMenuHelper();
        public ActionResult LibGruposMenu()
        {
            return View(GrupoHelp.ListaGrupoMenu());
        }

        public ActionResult EditGruposMenu(int id=0)
        {
            return PartialView(GrupoHelp.ObtenerGrupoMenu(id));
        }
        [HttpPost]
        public ActionResult Save(Grupos_Menu item)
        {
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = GrupoHelp.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Menu_Grupo;
                    return PartialView("~/Views/GrupoMenu/EditGruposMenu.cshtml", item);
                }

            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = GrupoHelp.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Menu_Grupo;
                    return PartialView("~/Views/GrupoMenu/EditGruposMenu.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }

    }
}