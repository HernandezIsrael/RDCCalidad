using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.IO;
using System.Net.Mime;

namespace MVCGEA.Controllers
{
    public class RPlancioController : Controller
    {
        FTPHelper ftp = new FTPHelper();
        PlancioHelper plan = new PlancioHelper();
        // GET: RPlancio
        public ActionResult LibRPlancio()
        {
            return View(plan.ListPlancio());
        }
        public ActionResult EditRPlancio(int id=0) {
            ViewBag.ListTipos = plan.DatatSourceTipoPlan();
            ViewBag.ListUserPlan = plan.DatatSourceUsPlan();
            ViewBag.ListSolicitado = plan.DatatSourceSolicitado();
            ViewBag.LisEmpresas = plan.DatatSourceEmpresas();
            if (id > 0)
            {
                ViewBag.LProyectos = plan.DatatSourceProyectos(id);
                ViewBag.ListDocumentos = plan.ListDocumentos(id);
            }
            else
                ViewBag.LProyectos = plan.DatatSourceProyectos(-1);
            return View(plan.ObtenerPlancio(id));
        }
        public JsonResult GetProyectos(int id = 0)
        {
            return Json(new SelectList(plan.DatatSourceProyectos(id), "Id", "NombreCompleto", JsonRequestBehavior.AllowGet));
        }
        public FileResult Download(string name, string name2)
        {
            Stream file = null;
            if (ftp.FTPDownload(name, out file))
                return File(file, MediaTypeNames.Application.Octet, name2);
            else
                return null;
        }
        [HttpPost]
        public ActionResult Save(RPlancio item)
        {
            if (ModelState.IsValid)
            {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                item.Activo = true;
                int i = plan.Guardar(item);
                if (i == 0)
                {
                }
                ViewBag.ListTipos = plan.DatatSourceTipoPlan();
                ViewBag.ListUserPlan = plan.DatatSourceUsPlan();
                ViewBag.ListSolicitado = plan.DatatSourceSolicitado();
                ViewBag.LisEmpresas = plan.DatatSourceEmpresas();
                if (item.IdRPlancio > 0)
                {
                    ViewBag.LProyectos = plan.DatatSourceProyectos(item.IdRPlancio);
                    ViewBag.ListDocumentos = plan.ListDocumentos(item.IdRPlancio);
                }
                else
                    ViewBag.LProyectos = plan.DatatSourceProyectos(-1);
            }
            return View("~/Views/RPlancio/EditRPlancio.cshtml", item);
        }
        [HttpPost]
        public ActionResult Subir(HttpPostedFileBase file, int IdRPlancio = 0)
        {
            RPlancio item = plan.ObtenerPlancio(IdRPlancio);
            ViewBag.ListTipos = plan.DatatSourceTipoPlan();
            ViewBag.ListUserPlan = plan.DatatSourceUsPlan();
            ViewBag.ListSolicitado = plan.DatatSourceSolicitado();
            ViewBag.LisEmpresas = plan.DatatSourceEmpresas();
            if (item.IdRPlancio > 0)
            {
                ViewBag.LProyectos = plan.DatatSourceProyectos(item.IdRPlancio);
                ViewBag.ListDocumentos = plan.ListDocumentos(item.IdRPlancio);
            }
            else
                ViewBag.LProyectos = plan.DatatSourceProyectos(-1);
            if (file == null) return View("~/Views/RPlancio/EditRPlancio.cshtml", item);
            string FileName = file.FileName;
            int IdUser = int.Parse(Session["IdUser"].ToString());
            string NV = string.Empty;
          
            if (plan.spInsDocumentosPlan(item.IdRPlancio, FileName, IdUser, 0, out NV))
            {
                if (ftp.FTPSubir(NV, file))
                {
                    return View("~/Views/RPlancio/EditRPlancio.cshtml", item);
                }
            }
          
            if (item.IdRPlancio > 0)
            {
                ViewBag.LProyectos = plan.DatatSourceProyectos(item.IdRPlancio);
                ViewBag.ListDocumentos = plan.ListDocumentos(item.IdRPlancio);
            }
            else
                ViewBag.LProyectos = plan.DatatSourceProyectos(-1);
            return View("~/Views/RPlancio/EditRPlancio.cshtml", item);
        }
    }
}