using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace MVCGEA.Controllers
{
    public class ANIngresosController : Controller
    {
        AutoIngresosHelper ingre = new AutoIngresosHelper();
        // GET: ANIngresos
        public ActionResult LibIngresos()
        {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            return View(ingre.ListPagos(IdUser));
        }
        public ActionResult EditCancelar(int id = 0)
        {
            Pagos item = new Pagos();
            item.Id_Pago = id;
            return PartialView(item);
        }
        public ActionResult Save(int id = 0)
        {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            Pagos item = ingre.ObtenerPagos(id);
            item.Creado_por = IdUser;
            int i = ingre.Guardar(item);
            if (i == 0)
            {
            }
            return View("~/Views/ANIngresos/LibIngresos.cshtml", ingre.ListPagos(IdUser));
        }
        [HttpPost]
        public ActionResult Cancel(Pagos item)
        {
            if (ModelState.IsValid)
            {
                int IdUser = int.Parse(Session["IdUser"].ToString());
                item.Creado_por = IdUser;
                int i = ingre.Cancelar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Solicitado_por;
                    return View("~/Views/ANIngresos/LibIngresos.cshtml", ingre.ListPagos(IdUser));
                }
            }
            return JavaScript("PopupOnClosed()");

        }
    }
}