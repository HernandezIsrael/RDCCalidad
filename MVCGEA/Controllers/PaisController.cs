using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class PaisController : Controller
    {
        PaisHelper paises = new PaisHelper();
        // GET: Pais
        public ActionResult LibPais()
        {
            return View(paises.ListarPaises());
        }
        public ActionResult EditPais(int id=0) {

            return View(paises.ObtenerPais(id));
        }
        public ActionResult EditEstados(int id=0) {
            ViewBag.id = id;
            return PartialView(paises.Listarestados(id));
        }
       
        public ActionResult Save(Ca_Pais item)
        {
            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = paises.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Pais;
                    return View("~/Views/Pais/EditPais.cshtml", item);
                }
            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = paises.Guardar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Pais;
                    return View("~/Views/Pais/EditPais.cshtml", item);
                }
            }
            return View("~/Views/Pais/EditPais.cshtml", item);
        }
        public ActionResult EditEstado(int id=0,int idpais=0) {
           
            return PartialView(paises.ObtenerEstado(id, idpais));
        }
        [HttpPost]
        public ActionResult SaveState(Ca_Estado item) {
        

            if (ModelState.IsValid)
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = paises.GuardarEstado(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Estado;
                    return PartialView("~/Views/Pais/EditEstado.cshtml", item);
                }

            }
            else
            {
                item.F_Alta = DateTime.Now;
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = paises.GuardarEstado(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Estado;
                    return PartialView("~/Views/Pais/EditEstado.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }

    }
}