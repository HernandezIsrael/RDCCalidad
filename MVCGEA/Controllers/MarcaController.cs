using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class MarcaController : Controller
    {
        MarcaHelper mh = new MarcaHelper();
        // GET: Marca
        public ActionResult LibMarca()
        {
            return View(mh.ListarMarcas());
        }
        public ActionResult EditMarca(int id=0)
        {
            return PartialView(mh.ObtenerMarca(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Marca item) {

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = mh.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Marca;
                    return PartialView("~/Views/Marca/EditMarca.cshtml", item);
                }

            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = mh.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Marca;
                    return PartialView("~/Views/Marca/EditMarca.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
    }
}