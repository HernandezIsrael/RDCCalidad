using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class ProgramasController : Controller
    {
        FinanciamientosHerlper fin = new FinanciamientosHerlper();
        // GET: Programas
        public ActionResult LibProgramas()
        {
            return View(fin.ListarInstituciones());
        }
       
        public ActionResult EditPrograma(int id=0) {

            return View(fin.ObtenerInstitucion(id));
        }
        [HttpPost]
        public ActionResult Save(Ca_Instituciones inst)
        {
            if (ModelState.IsValid)
            {
                inst.F_Alta = DateTime.Now;
                inst.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = fin.Guardar(inst);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = inst.Id_Institucion;
                    return PartialView("~/Views/Programas/EditPrograma.cshtml", inst);
                }

            }
            else
            {
                inst.F_Alta = DateTime.Now;
                inst.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = fin.Guardar(inst);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = inst.Id_Institucion;
                    return PartialView("~/Views/Programas/EditPrograma.cshtml", inst);
                }
            }
            return View("~/Views/Programas/EditPrograma.cshtml",inst);
        }
        public ActionResult LibRubros(int id=0) {
            ViewBag.id = id;
            return PartialView(fin.ListarRubros(id));
        }
        public ActionResult EditRubro(int id=0,int idInst=0)
        {
            return PartialView(fin.ObtenerRubro(id, idInst));
        }

        [HttpPost]
        public ActionResult SaveRubro(Ca_Rubros rb)
        {
            if (ModelState.IsValid)
            {
                rb.F_Alta = DateTime.Now;
                rb.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = fin.GuardarRubro(rb);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = rb.Id_Institucion;
                    return PartialView("~/Views/Programas/EditRubro.cshtml", rb);
                }

            }
            else
            {
                rb.F_Alta = DateTime.Now;
                rb.Creado_por = int.Parse(Session["IdUser"].ToString());
                int i = fin.GuardarRubro(rb);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = rb.Id_Institucion;
                    return PartialView("~/Views/Programas/EditRubro.cshtml", rb);
                }
            }
            return JavaScript("PopupOnClosed()");
        }




    }
}