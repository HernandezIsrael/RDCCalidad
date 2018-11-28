using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class ProyectosController : Controller
    {
        ProyectosHelper proc = new ProyectosHelper();
        EmpresasProveedorHelper emp = new EmpresasProveedorHelper();
        // GET: Proyectos
        public ActionResult LibProyectos()
        {
            Proyectos item = new Proyectos();
            ViewBag.ListEmpresas = emp.DataSourceEmpresasGrupo();
            //ViewBag.ListProyectos = proc.DataSourceProgramas();
            //ViewBag.ListMoneda = proc.DataSourceMonedas();
            item.Id_Empresa = -1;
            return View(item);
        }
        public ActionResult EditProyecto(int id=0) {
            ViewBag.ListEmpresas = emp.DataSourceEmpresasGrupo();
            ViewBag.ListProyectos = proc.DataSourceProgramas();
            ViewBag.ListMoneda = proc.DataSourceMonedas();

            return PartialView(proc.ObtenerProyecto(id));
        }
        public JsonResult GetBancos(int id = 0,int idemp=0)
        {

            return Json(new SelectList(proc.DataSourceBancos(idemp,id), "Id", "Banco", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetCuentas(int idmon = 0, int idemp = 0,int idBan=0)
        {

            return Json(new SelectList(proc.DataSourceCuenta(idemp,idBan,idmon), "Id", "Cuenta", JsonRequestBehavior.AllowGet));
        }
        public ActionResult ListaProyectos(int id=0) {
            return PartialView(proc.ListarProyectos(id));
        }
        [HttpPost]
        public ActionResult Save(Proyectos items)
        {
            Proyectos item = new Proyectos();
            ViewBag.ListEmpresas = emp.DataSourceEmpresasGrupo();
            ViewBag.ListProyectos = proc.DataSourceProgramas();
            ViewBag.ListMoneda = proc.DataSourceMonedas();
            if (ModelState.IsValid)
            {

               
                items.F_Alta = DateTime.Now;
                items.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = proc.Guardar(items);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = items.Id_Proyecto;
                    return PartialView("~/Views/Proyectos/EditProyecto.cshtml", item);
                }
            }
            else
            {
               
                items.F_Alta = DateTime.Now;
                items.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = proc.Guardar(items);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = items.Id_Proyecto;
                    return PartialView("~/Views/Proyectos/EditProyecto.cshtml", item);
                }
            }
            int f = items.Id_Empresa.Value;
            item.Id_Empresa = f;
            item.Id_Institucion = -1;
            return JavaScript("PopupOnClosed()");

        }


    }
}