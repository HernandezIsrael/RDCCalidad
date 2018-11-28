using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class TipoServicioController : Controller
    {
        TipoServHelper Serv = new TipoServHelper();
        // GET: TipoServicio
        public ActionResult LibTipoServicio()
        {
            return View(Serv.ListarTipoServicios());
        }
        public ActionResult EditTipoServicio(int id=0) {
            return PartialView(Serv.ObtenerServicio(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Tipo_Servicio item)
        {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = Serv.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_tipo_servicio;
                    return PartialView("~/Views/TipoServicio/EditTipoServicio.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = Serv.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_tipo_servicio;
                    return PartialView("~/Views/TipoServicio/EditTipoServicio.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }

    }
}