using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class EmpresasController : Controller
    {
        EmpresasHelper emp = new EmpresasHelper();
        // GET: Empresas
        public ActionResult LibEmpresas()
        {
            return View(emp.ListarEmpresas());
        }
        public ActionResult EditEmpresa(int id=0) {
            ViewBag.showError = false;
            ViewBag.ListPais = emp.DataSourcePais();
            Empresas item = emp.ObtenerEmpresa(id);

            if (id > 0)
            {
                ViewBag.ListEstados = emp.DataSourceEstados(item.Id_Pais.Value);
                ViewBag.ListClabes = emp.ListClabesEmpresa(id);
                ViewBag.ListCuentas = emp.ListarCuentasEmpresa(id);
            }
            return View(item);
        }
        public ActionResult EditCuenta(int id =0,int idempresa=0) {
            ViewBag.ListProyectos = emp.DataSourceProyectos(idempresa);
            ViewBag.ListBancos = emp.DataSourceBancos();
            ViewBag.ListMoneda = emp.DataSourceMoendas();
            return PartialView(emp.ObtenerCuenta(id,idempresa));
        }
        public ActionResult EditClabe(int id = 0, int idempresa = 0)
        {
            ViewBag.ListProyectos = emp.DataSourceProyectos(idempresa);
            ViewBag.ListBancos = emp.DataSourceBancos();
            ViewBag.ListMoneda = emp.DataSourceMoendas();
            return PartialView(emp.ObtenerClabe(id, idempresa));
        }
        public JsonResult GetState(int id=0)
        {
            
            return Json(new SelectList(emp.DataSourceEstados(id), "Id_Estado", "Estado", JsonRequestBehavior.AllowGet));


        }
        public ActionResult Save(Empresas item)
        {
            ViewBag.ListPais = emp.DataSourcePais();
            ViewBag.ListEstados = emp.DataSourceEstados(item.Id_Pais.Value);
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.Id_Tipo_Empresa = 1;
                item.Activo = true;
                int i = emp.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return View(item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.Id_Tipo_Empresa = 1;
                item.Activo = true;
                int i = emp.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return View(item);
                }
            }
          
            return View("~/Views/Empresas/EditEmpresa.cshtml", item);
        }
        public ActionResult SaveCuenta(Ca_N_Cuenta item)
        {
            ViewBag.ListProyectos = emp.DataSourceProyectos(item.Id_Empresa.Value);
            ViewBag.ListBancos = emp.DataSourceBancos();
            ViewBag.ListMoneda = emp.DataSourceMoendas();
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
              
                int i = emp.GuardarCuenta(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return PartialView("~/Views/Empresas/EditCuenta.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
              
                int i = emp.GuardarCuenta(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return PartialView("~/Views/Empresas/EditCuenta.cshtml", item);
                }
            }

            return JavaScript("PopupOnClosed()");
        }
        public ActionResult SaveClabe(Ca_Clabe item)
        {
            ViewBag.ListProyectos = emp.DataSourceProyectos(item.Id_Empresa.Value);
            ViewBag.ListBancos = emp.DataSourceBancos();
            ViewBag.ListMoneda = emp.DataSourceMoendas();
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
              
                int i = emp.Guardarclabe(item);
                if (i == 0)
                {
                   
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return PartialView("~/Views/Empresas/EditClabe.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
              
                int i = emp.Guardarclabe(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return PartialView("~/Views/Empresas/EditClabe.cshtml", item);
                }
            }

            return JavaScript("PopupOnClosed()");
        }
    }
}