using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace MVCGEA.Controllers
{
    public class UsuarioEmpresasController : Controller
    {
        UsuarioEmpresaHelper emp = new UsuarioEmpresaHelper();
        // GET: UsuarioEmpresas
        public ActionResult LibUsuarioEmpresas()
        {
            ViewBag.ListUsuarios = emp.ListarUsuarios();
            Re_Usuario_Empresa item = new Re_Usuario_Empresa();
            return View(item);
        }
        public ActionResult EditUsuarioEmpresas(int id=0)
        {
            return PartialView(emp.ListarempresasxUsuario(id));
        }
        public JsonResult GetEnter(int id = 0)
        {

            return Json(new SelectList(emp.DataSourceEmpresasNotIn(id), "Id", "NombreCompleto", JsonRequestBehavior.AllowGet));
        }


        public ActionResult Eliminar(int id = 0, int idusr = 0)
        {
            Re_Usuario_Empresa item = new Re_Usuario_Empresa();
            ViewBag.ListUsuarios = emp.ListarUsuarios();
            emp.Eliminar(id);
            item.Id_Usuario = idusr;
            return View("~/Views/UsuarioEmpresas/LibUsuarioEmpresas.cshtml", item);
        }
        [HttpPost]
        public ActionResult Save(Re_Usuario_Empresa item)
        {
            ViewBag.ListUsuarios = emp.ListarUsuarios();
            if (ModelState.IsValid)
            {
               
                item.Activo = true;
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = emp.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Re_Usuario_Empresas;
                    return View();
                }
            }
            else
            {
                item.Activo = true;
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = emp.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Re_Usuario_Empresas;
                    return View();
                }
            }
            item.Id_Empresa = 0;
            return View("~/Views/UsuarioEmpresas/LibUsuarioEmpresas.cshtml", item);
        }
     
        

    }
}