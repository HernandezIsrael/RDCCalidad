using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace MVCGEA.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        CategoriaHelper categorias = new CategoriaHelper();
        public ActionResult LibCategorias() {
            ViewBag.showError = false;
            ViewBag.OnIdError = 0;
            return View(categorias.ListarCategorias());
        }
        public ActionResult EditCategoria(int id=0) {
            
            return PartialView(categorias.ObtenerCategoria(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Categoria item) {
            if (ModelState.IsValid)
            {
                
                item.Creado_por =int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                int i = categorias.Guardar(item);
                if (i==0) {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Categoria;
                    return PartialView("~/Views/Categoria/EditCategoria.cshtml", item);
                }
            }
            else {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                int i = categorias.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Categoria;
                    return PartialView("~/Views/Categoria/EditCategoria.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}