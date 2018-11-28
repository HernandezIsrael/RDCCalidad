using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class ProveedoresController : Controller
    {
        EmpresasHelper prov = new EmpresasHelper();
        // GET: Proveedores
        public ActionResult LibProveedores()
        {
            return View(prov.ListarProveedores());
        }
        public ActionResult EditProveedor(int id=0)
        {

            ViewBag.showError = false;
            ViewBag.ListPais = prov.DataSourcePais();
            Empresas item = prov.ObtenerEmpresa(id);

            if (id > 0)
            {
                ViewBag.ListEstados = prov.DataSourceEstados(item.Id_Pais.Value);
                ViewBag.ListClabes = prov.ListClabesEmpresa(id);
                ViewBag.ListCuentas = prov.ListarCuentasEmpresa(id);
            }
            return View(item);
        }
        public JsonResult GetState(int id = 0)
        {

            return Json(new SelectList(prov.DataSourceEstados(id), "Id_Estado", "Estado", JsonRequestBehavior.AllowGet));


        }
        public ActionResult Save(Empresas item)
        {
            ViewBag.ListPais = prov.DataSourcePais();
            ViewBag.ListEstados = prov.DataSourceEstados(item.Id_Pais.Value);
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.Id_Tipo_Empresa = 2;
                item.Activo = true;
                int i = prov.Guardar(item);
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
                item.Id_Tipo_Empresa = 2;
                item.Activo = true;
                int i = prov.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return View(item);
                }
            }

            return View("~/Views/Proveedores/EditProveedor.cshtml", item);
        }


        public ActionResult EditCuenta(int id = 0, int idempresa = 0)
        {
            ViewBag.ListProyectos = prov.DataSourceProyectos(idempresa);
            ViewBag.ListBancos = prov.DataSourceBancos();
            ViewBag.ListMoneda = prov.DataSourceMoendas();
            return PartialView(prov.ObtenerCuenta(id, idempresa));
        }
        public ActionResult EditClabe(int id = 0, int idempresa = 0)
        {
            ViewBag.ListProyectos = prov.DataSourceProyectos(idempresa);
            ViewBag.ListBancos = prov.DataSourceBancos();
            ViewBag.ListMoneda = prov.DataSourceMoendas();
            return PartialView(prov.ObtenerClabe(id, idempresa));
        }
        public ActionResult SaveCuenta(Ca_N_Cuenta item)
        {
            ViewBag.ListProyectos = prov.DataSourceProyectos(item.Id_Empresa.Value);
            ViewBag.ListBancos = prov.DataSourceBancos();
            ViewBag.ListMoneda = prov.DataSourceMoendas();
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.Id_Proyecto = -1;
                int i = prov.GuardarCuenta(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return PartialView("~/Views/Proveedores/EditCuenta.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.Id_Proyecto = -1;
                int i = prov.GuardarCuenta(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return PartialView("~/Views/Proveedores/EditCuenta.cshtml", item);
                }
            }

            return JavaScript("PopupOnClosed()");
        }
        public ActionResult SaveClabe(Ca_Clabe item)
        {
            ViewBag.ListProyectos = prov.DataSourceProyectos(item.Id_Empresa.Value);
            ViewBag.ListBancos = prov.DataSourceBancos();
            ViewBag.ListMoneda = prov.DataSourceMoendas();
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.Id_Proyecto = -1;
                int i = prov.Guardarclabe(item);
                if (i == 0)
                {

                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return PartialView("~/Views/Proveedores/EditClabe.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.Id_Proyecto = -1;
                int i = prov.Guardarclabe(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Empresa;
                    return PartialView("~/Views/Proveedores/EditClabe.cshtml", item);
                }
            }

            return JavaScript("PopupOnClosed()");
        }

    }
}