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
    public class VRContaController : Controller
    {
        RContaHelper conta = new RContaHelper();
        FTPHelper ftp = new FTPHelper();
        // GET: VRConta
        public ActionResult LibConta()
        {
            return View(conta.ListConta());
        }
        public ActionResult EditRConta(int id = 0)
        {
            ViewBag.ListTipos = conta.DatatSourceTipoConta();
            ViewBag.ListUserConta = conta.DatatSourceUsConta();
            ViewBag.ListSolicitado = conta.DatatSourceSolicitado();
            ViewBag.LisEmpresas = conta.DatatSourceEmpresas();
            if (id > 0)
            {
                ViewBag.LProyectos = conta.DatatSourceProyectos(id);
                ViewBag.ListDocumentos = conta.ListDocumentos(id);
            }
            else
                ViewBag.LProyectos = conta.DatatSourceProyectos(-1);

            return View(conta.ObtenerRconta(id));
        }
        public JsonResult GetProyectos(int id = 0)
        {
            return Json(new SelectList(conta.DatatSourceProyectos(id), "Id", "NombreCompleto", JsonRequestBehavior.AllowGet));
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
        public ActionResult Save(RConta item)
        {
            if (ModelState.IsValid)
            {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                item.Activo = true;
                int i = conta.Guardar(item);
                if (i == 0)
                {
                }
                ViewBag.ListTipos = conta.DatatSourceTipoConta();
                ViewBag.ListUserConta = conta.DatatSourceUsConta();
                ViewBag.ListSolicitado = conta.DatatSourceSolicitado();
                ViewBag.LisEmpresas = conta.DatatSourceEmpresas();
                if (item.IdRConta > 0)
                {
                    ViewBag.LProyectos = conta.DatatSourceProyectos(item.IdRConta);
                    ViewBag.ListDocumentos = conta.ListDocumentos(item.IdRConta);
                }
                else
                    ViewBag.LProyectos = conta.DatatSourceProyectos(-1);
            }
            return View("~/Views/VRConta/EditRConta.cshtml", item);
        }
        [HttpPost]
        public ActionResult Subir(HttpPostedFileBase file,int IdRConta =0)
        {
            RConta item = conta.ObtenerRconta(IdRConta);
            if (file == null) return View("~/Views/VRConta/EditRConta.cshtml", item);
            string FileName = file.FileName;
            int IdUser = int.Parse(Session["IdUser"].ToString());
            string NV = string.Empty;
            ViewBag.ListTipos = conta.DatatSourceTipoConta();
            ViewBag.ListUserConta = conta.DatatSourceUsConta();
            ViewBag.ListSolicitado = conta.DatatSourceSolicitado();
            ViewBag.LisEmpresas = conta.DatatSourceEmpresas();
          
            if (conta.spInsDocumentosRConta(item.IdRConta, FileName, IdUser, 0, out NV))
            {
                if (ftp.FTPSubir(NV, file))
                {
                    return View("~/Views/VRConta/EditRConta.cshtml", item);
                }
            }
            if (item.IdRConta > 0)
            {
                ViewBag.LProyectos = conta.DatatSourceProyectos(item.IdRConta);
                ViewBag.ListDocumentos = conta.ListDocumentos(item.IdRConta);
            }
            else
                ViewBag.LProyectos = conta.DatatSourceProyectos(-1);
            return View("~/Views/VRConta/EditRConta.cshtml", item);
        }
    }
}