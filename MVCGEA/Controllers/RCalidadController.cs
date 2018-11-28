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
    public class RCalidadController : Controller
    {
        FTPHelper ftp = new FTPHelper();
        CalidadHelper proc = new CalidadHelper();
        // GET: RCalidad
        public ActionResult LibRCalidad()
        {
            return View(proc.ListProcesos());
        }
        public ActionResult EditProceso(int id=0) {
            ViewBag.ListTipos = proc.DatatSourceTipoCal();
            ViewBag.ListUserCal = proc.DatatSourceUsCal();
            ViewBag.ListSolicitado = proc.DatatSourceSolicitado();
            ViewBag.LisEmpresas = proc.DatatSourceEmpresas();
            if (id > 0)
            {
                ViewBag.LProyectos = proc.DatatSourceProyectos(id);
                ViewBag.ListDocumentos = proc.ListDocumentos(id);
            }
            else
                ViewBag.LProyectos = proc.DatatSourceProyectos(-1);
            return View(proc.ObtenerProc(id));
        }
        public JsonResult GetProyectos(int id = 0)
        {
            return Json(new SelectList(proc.DatatSourceProyectos(id), "Id", "NombreCompleto", JsonRequestBehavior.AllowGet));
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
        public ActionResult Save(RProcesos item)
        {
            if (ModelState.IsValid)
            {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                item.Activo = true;
                int i = proc.Guardar(item);
                if (i == 0)
                {
                }
                ViewBag.ListTipos = proc.DatatSourceTipoCal();
                ViewBag.ListUserCal = proc.DatatSourceUsCal();
                ViewBag.ListSolicitado = proc.DatatSourceSolicitado();
                ViewBag.LisEmpresas = proc.DatatSourceEmpresas();
                if (item.IdRProcesos > 0)
                {
                    ViewBag.LProyectos = proc.DatatSourceProyectos(item.IdRProcesos);
                    ViewBag.ListDocumentos = proc.ListDocumentos(item.IdRProcesos);
                }
                else
                    ViewBag.LProyectos = proc.DatatSourceProyectos(-1);
            }
            return View("~/Views/RCalidad/EditProceso.cshtml", item);
        }
        [HttpPost]
        public ActionResult Subir(HttpPostedFileBase file, int IdRProcesos = 0)
        {
            RProcesos item = proc.ObtenerProc(IdRProcesos);
            if (file == null) return View("~/Views/RCalidad/EditProceso.cshtml", item);
            string FileName = file.FileName;
            int IdUser = int.Parse(Session["IdUser"].ToString());
            string NV = string.Empty;
            ViewBag.ListTipos = proc.DatatSourceTipoCal();
            ViewBag.ListUserCal = proc.DatatSourceUsCal();
            ViewBag.ListSolicitado = proc.DatatSourceSolicitado();
            ViewBag.LisEmpresas = proc.DatatSourceEmpresas();
            if (proc.spInsDocumentosRProcesos(item.IdRProcesos, FileName, IdUser, 0, out NV))
            {
                if (ftp.FTPSubir(NV, file))
                {
                    return View("~/Views/RCalidad/EditProceso.cshtml", item);
                }
            }
            if (item.IdRProcesos > 0)
            {
                ViewBag.LProyectos = proc.DatatSourceProyectos(item.IdRProcesos);
                ViewBag.ListDocumentos = proc.ListDocumentos(item.IdRProcesos);
            }
            else
                ViewBag.LProyectos = proc.DatatSourceProyectos(-1);
            return View("~/Views/RCalidad/EditProceso.cshtml", item);
        }
    }
}