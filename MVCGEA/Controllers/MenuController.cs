using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace MVCGEA.Controllers
{
    public class MenuController : Controller
    {
        UsuariosHelper userHelp = new UsuariosHelper();
        MenuHelper menuayuda = new MenuHelper();
        // GET: Menu                        
        public ActionResult LibMenu()
        {
            return View(userHelp.ListarUsuarios());
        }
        public ActionResult MenuUsuario(int id = 0, int idTipoUsuario = 0)
        {            
            return View(menuayuda.ListarMenuUsuario(id, idTipoUsuario));
        }
        public ActionResult EditMenu(int id = 0, int idTipoUsuario = 0)
        {
            return View(menuayuda.ListarMenuUsuario(id, idTipoUsuario));
        }
        public ActionResult EditMenuDetalle(int id = 0, int idusuario = 0, int idTipoUsuario = 0)
        {
            ViewBag.ListaGrupo = menuayuda.CmbCS();
           
            return PartialView(menuayuda.ObtenerMenu( id,idusuario,idTipoUsuario));
        }

        [HttpPost]
        public ActionResult Save(Menu item)
        {
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = menuayuda.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Menu;
                    return PartialView("~/Views/Menu/EditMenu.cshtml", item);
                }

            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = menuayuda.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Menu;
                    return PartialView("~/Views/Menu/EditMenu.cshtml", item);
                }
            }
            return JavaScript("Woo()");
        }
    }
}