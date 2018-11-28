using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class EmpresasProveedoresController : Controller
    {
        EmpresasProveedorHelper prov = new EmpresasProveedorHelper();

        public ActionResult LibEmpresasProveedores()
        {
            ViewBag.ListEmpresas = prov.DataSourceEmpresas();
            Re_Proveedores_Empresa item = new Re_Proveedores_Empresa();
            item.Id_Empresa = -1;
            return View(item);
        }

        public ActionResult EditEmpresasProveedor(int id = 0)
        {
            return PartialView(prov.DataSourceInProveedorxEmpresa(id));
        }

        public JsonResult GetEnter(int id = 0)
        {

            return Json(new SelectList(prov.DataSourceNotInProveedores(id), "Id", "NombreCompleto", JsonRequestBehavior.AllowGet));
        }
        public ActionResult Eliminar(int id = 0, int idusr = 0)
        {
            Re_Proveedores_Empresa item = new Re_Proveedores_Empresa();
            ViewBag.ListEmpresas = prov.DataSourceEmpresas();
            prov.Eliminar(id);
            item.Id_Empresa = idusr;
            return View("~/Views/EmpresasProveedores/LibEmpresasProveedores.cshtml", item);
        }

        [HttpPost]
        public ActionResult Save(Re_Proveedores_Empresa item)
        {
            ViewBag.ListEmpresas = prov.DataSourceEmpresas();
            if (ModelState.IsValid)
            {

                item.Activo = true;
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = prov.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Proveedores_Empresa;
                    return View();
                }
            }
            else
            {
                item.Activo = true;
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = prov.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Proveedores_Empresa;
                    return View();
                }
            }
            item.Id_Empresa = 0;
            return View("~/Views/EmpresasProveedores/LibEmpresasProveedores.cshtml", item);
        }
    }
}