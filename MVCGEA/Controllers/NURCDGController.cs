using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class NURCDGController : Controller
    {
        NurcDGHelper Dg = new NurcDGHelper();
        // GET: NURCDG
        public ActionResult LibNurcAutorizacion()
        {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            return View(Dg.ListPagosEgresos(IdUser));
        }
        public ActionResult EditCS(int id=0) {
            ViewBag.ListCS = Dg.ListCS();
            return PartialView(Dg.ObtenerNurc(id));
        }
        public ActionResult EditCancelar(int id=0) {
            Pagos item = new Pagos();
            item.Id_Pago = id;
            return PartialView(item);
        }
        public ActionResult EditAutorizar(int id=0) {
            Pagos item = Dg.ObtenerNurc(id);
            ViewBag.ListBancos = Dg.ListBancos(item.Id_Empresa.Value,item.Id_Moneda.Value);
            return PartialView(item);
        }
        public JsonResult GetClabes(int id = 0,int idbanco=0, int idmoneda = 0)
        {
            return Json(new SelectList(Dg.ListClabe(id,idbanco,idmoneda), "Id", "CB", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetCuentas(int id = 0, int idbanco = 0, int idmoneda = 0)
        {
            return Json(new SelectList(Dg.ListCuenta(id,idbanco,idmoneda), "Id", "NC", JsonRequestBehavior.AllowGet));
        }
        [HttpPost]
        public ActionResult SaveCS(Pagos item) {
            if (ModelState.IsValid)
            {
                int i = Dg.GuardarCS(item.Id_Pago, item.Id_CS1.Value, item.Id_CS2.Value);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Solicitado_por;
                    return PartialView("~/Views/NURCDG/EditCS.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
        public ActionResult Save(int id=0)
        {
            int IdUser = int.Parse(Session["IdUser"].ToString());
                int i = Dg.Guardar(id,IdUser);
                if (i == 0)
                {
                }
          return  View("~/Views/NURCDG/LibNurcAutorizacion.cshtml", Dg.ListPagosEgresos(IdUser));
        }
        [HttpPost]
        public ActionResult Cancel(Pagos item)
        {
            if (ModelState.IsValid)
            {
                int IdUser = int.Parse(Session["IdUser"].ToString());
                int i = Dg.Cancelar(item.Id_Pago, IdUser, item.Comentarios);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Solicitado_por;
                    return PartialView("~/Views/NURCDG/EditCancelar.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");

        }
        [HttpPost]
        public ActionResult SaveNURC(Pagos item)
        {
            if (ModelState.IsValid)
            {
                int IdUser = int.Parse(Session["IdUser"].ToString());
                Pagos nurc= Dg.ObtenerNurc(item.Id_Pago);
                nurc.Id_Banco_Empresa = item.Id_Banco_Empresa;
                nurc.Id_N_Cuenta_Empresa = item.Id_N_Cuenta_Empresa;
                nurc.Id_Clabe_Empresa = item.Id_Clabe_Empresa;
                nurc.Id_Estatus_Pago = 10;
                int i = Dg.GuardarCompleto(nurc);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = IdUser;
                    return PartialView("~/Views/NURCDG/EditAutorizar.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}