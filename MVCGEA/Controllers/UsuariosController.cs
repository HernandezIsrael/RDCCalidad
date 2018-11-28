using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class UsuariosController : Controller
    {
        UsuariosHelper UsuarioHelp = new UsuariosHelper();
        // GET: Usuarios
        public ActionResult EditUsuarios(int id = 0)
        {
            return PartialView(UsuarioHelp.ObtenerUsuario(id));
        }
        public ActionResult LibUsuarios()
        {
            return View(UsuarioHelp.ListarUsuarios());
        }
        [HttpPost]
        public ActionResult SaveUsuarios(Usuarios item)
        {
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = UsuarioHelp.Guardar(item);                
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Usuario;
                    return PartialView("~/Views/Usuarios/EditUsuarios.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = UsuarioHelp.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Usuario;
                    return PartialView("~/Views/Usuarios/EditUsuarios.cshtml", item);
                }
            }
            return JavaScript("Woo()");

        }
    }
}