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
    public class RVinculacionesController : Controller
    {
        FTPHelper ftp = new FTPHelper();
        RVinculacionesHelper vin = new RVinculacionesHelper();
        // GET: RVinculaciones
        public ActionResult LibRVinculaciones()
        {
            return View(vin.ListVinculaciones());
        }
        public ActionResult EditRVinculacion(int id=0) {
            ViewBag.ListTipos = vin.DatatSourceTipoVin();
            ViewBag.ListUserVin = vin.DatatSourceUsVin();
            ViewBag.ListSolicitado = vin.DatatSourceSolicitado();
            ViewBag.LisEmpresas = vin.DatatSourceEmpresas();
            if (id > 0)
            {
                ViewBag.LProyectos = vin.DatatSourceProyectos(id);
                ViewBag.ListDocumentos = vin.ListDocumentos(id);
            }
            else
                ViewBag.LProyectos = vin.DatatSourceProyectos(-1);
            return View(vin.ObtenerVinculacion(id));
        }
        public JsonResult GetProyectos(int id = 0)
        {
            return Json(new SelectList(vin.DatatSourceProyectos(id), "Id", "NombreCompleto", JsonRequestBehavior.AllowGet));
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
        public ActionResult Save(RVinculaciones item)
        {
            if (ModelState.IsValid)
            {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                item.Activo = true;
                int i = vin.Guardar(item);
                if (i == 0)
                {
                }
                ViewBag.ListTipos = vin.DatatSourceTipoVin();
                ViewBag.ListUserVin = vin.DatatSourceUsVin();
                ViewBag.ListSolicitado = vin.DatatSourceSolicitado();
                ViewBag.LisEmpresas = vin.DatatSourceEmpresas();
                if (item.IdRVinculaciones > 0)
                {
                    ViewBag.LProyectos = vin.DatatSourceProyectos(item.IdRVinculaciones);
                    ViewBag.ListDocumentos = vin.ListDocumentos(item.IdRVinculaciones);
                }
                else
                    ViewBag.LProyectos = vin.DatatSourceProyectos(-1);
            }
            return View("~/Views/RVinculaciones/EditRVinculacion.cshtml", item);
        }
        [HttpPost]
        public ActionResult Subir(HttpPostedFileBase file, int IdRVinculaciones = 0)
        {
            RVinculaciones item = vin.ObtenerVinculacion(IdRVinculaciones);
            ViewBag.ListTipos = vin.DatatSourceTipoVin();
            ViewBag.ListUserVin = vin.DatatSourceUsVin();
            ViewBag.ListSolicitado = vin.DatatSourceSolicitado();
            ViewBag.LisEmpresas = vin.DatatSourceEmpresas();
            if (item.IdRVinculaciones > 0)
            {
                ViewBag.LProyectos = vin.DatatSourceProyectos(item.IdRVinculaciones);
                ViewBag.ListDocumentos = vin.ListDocumentos(item.IdRVinculaciones);
            }
            else
                ViewBag.LProyectos = vin.DatatSourceProyectos(-1);
            if (file == null) return View("~/Views/RVinculaciones/EditRVinculacion.cshtml", item);
            string FileName = file.FileName;
            int IdUser = int.Parse(Session["IdUser"].ToString());
            string NV = string.Empty;

            if (vin.spInsDocumentosRVincu(item.IdRVinculaciones, FileName, IdUser, 0, out NV))
            {
                if (ftp.FTPSubir(NV, file))
                {
                    return View("~/Views/RVinculaciones/EditRVinculacion.cshtml", item);
                }
            }

            if (item.IdRVinculaciones > 0)
            {
                ViewBag.LProyectos = vin.DatatSourceProyectos(item.IdRVinculaciones);
                ViewBag.ListDocumentos = vin.ListDocumentos(item.IdRVinculaciones);
            }
            else
                ViewBag.LProyectos = vin.DatatSourceProyectos(-1);
            return View("~/Views/RVinculaciones/EditRVinculacion.cshtml", item);
        }
    }
}