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
    public class VRRHHController : Controller
    {
        RRRHHHelper rrhh = new RRRHHHelper();
        FTPHelper ftp = new FTPHelper();
        // GET: VRRHH
        public ActionResult LibRRHH()
        {
            return View(rrhh.ListVRRHH());
        }
        public ActionResult EditRRHH(int id=0) {
            ViewBag.ListTipos = rrhh.DatatSourceTipoRRHH();
            ViewBag.ListUserRRHH = rrhh.DatatSourceUsRRHH();
            ViewBag.ListSolicitado = rrhh.DatatSourceSolicitado();
            ViewBag.LisEmpresas = rrhh.DatatSourceEmpresas();
            if (id > 0)
            {
                ViewBag.LProyectos = rrhh.DatatSourceProyectos(id);
                ViewBag.ListDocumentos = rrhh.ListDocumentos(id);
            }
            else
                ViewBag.LProyectos = rrhh.DatatSourceProyectos(-1);
            return View(rrhh.ObtenerRRHH(id));
        }
        public JsonResult GetProyectos(int id = 0)
        {
            return Json(new SelectList(rrhh.DatatSourceProyectos(id), "Id", "NombreCompleto", JsonRequestBehavior.AllowGet));
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
        public ActionResult Save(RRHHD item)
        {
            if (ModelState.IsValid)
            {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                item.Activo = true;
                int i = rrhh.Guardar(item);
                if (i == 0)
                {
                }
                ViewBag.ListTipos = rrhh.DatatSourceTipoRRHH();
                ViewBag.ListUserRRHH = rrhh.DatatSourceUsRRHH();
                ViewBag.ListSolicitado = rrhh.DatatSourceSolicitado();
                ViewBag.LisEmpresas = rrhh.DatatSourceEmpresas();
                if (item.IdRRHHD > 0)
                {
                    ViewBag.LProyectos = rrhh.DatatSourceProyectos(item.IdRRHHD);
                    ViewBag.ListDocumentos = rrhh.ListDocumentos(item.IdRRHHD);
                }
                else
                    ViewBag.LProyectos = rrhh.DatatSourceProyectos(-1);
            }
            return View("~/Views/VRRHH/EditRRHH.cshtml", item);
        }

        [HttpPost]
        public ActionResult Subir(HttpPostedFileBase file, int IdRRHHD = 0)
        {
            RRHHD item = rrhh.ObtenerRRHH(IdRRHHD);
            if (file == null) return View("~/Views/VRRHH/EditRRHH.cshtml", item);
            string FileName = file.FileName;
            int IdUser = int.Parse(Session["IdUser"].ToString());
            string NV = string.Empty;
            ViewBag.ListTipos = rrhh.DatatSourceTipoRRHH();
            ViewBag.ListUserRRHH = rrhh.DatatSourceUsRRHH();
            ViewBag.ListSolicitado = rrhh.DatatSourceSolicitado();
            ViewBag.LisEmpresas = rrhh.DatatSourceEmpresas();
            if (rrhh.spInsDocumentosRRHHD(item.IdRRHHD, FileName, IdUser, 0, out NV))
            {
                if (ftp.FTPSubir(NV, file))
                {
                    return View("~/Views/VRRHH/EditRRHH.cshtml", item);
                }
            }
            if (item.IdRRHHD > 0)
            {
                ViewBag.LProyectos = rrhh.DatatSourceProyectos(item.IdRRHHD);
                ViewBag.ListDocumentos = rrhh.ListDocumentos(item.IdRRHHD);
            }
            else
                ViewBag.LProyectos = rrhh.DatatSourceProyectos(-1);
            return View("~/Views/VRRHH/EditRRHH.cshtml", item);
        }
    }
}