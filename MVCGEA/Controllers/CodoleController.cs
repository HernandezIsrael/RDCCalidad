using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Net.Mime;
using System.IO;

namespace MVCGEA.Controllers
{
    public class CodoleController : Controller
    {
        CodoleHelper codole = new CodoleHelper();
        FTPHelper ftp = new FTPHelper();
        // GET: Codole
        public ActionResult LibCodole(){
            return View(codole.ListCodole());
        }
        public ActionResult EditCodole(int id=0) {
            CODOLE item = codole.ObetnerCodole(id);
            ViewBag.Tipos = codole.DatatSourceTipoCodole();
            ViewBag.Empresas = codole.DatatSourceEmpresas();
            ViewBag.Solicitado = codole.DatatSourceSolicitado();
            ViewBag.Creadopor = codole.DataSourceUsuariosLegal();
            ViewBag.Validado = codole.DataSourceUsuariosLegal();
            if (id > 0)
            {
                ViewBag.Proyectos = codole.DatatSourceProyectos(item.Id_Empresa.Value);
                ViewBag.Documentos = codole.ListDocumentos(id);
            }
            else
                ViewBag.Proyectos = codole.DatatSourceProyectos(0);

            return View(item);
        }
        public JsonResult GetProyectos( int id = 0)
        {
            return Json(new SelectList(codole.DatatSourceProyectos(id), "Id", "NombreCompleto", JsonRequestBehavior.AllowGet));
        }
        [HttpPost]

        public ActionResult Save(CODOLE item)
        {
            if (ModelState.IsValid) {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                int i = codole.Guardar(item);
                if (i == 0)
                {
                   
                }
                CODOLE items = codole.ObetnerCodole(item.Id_Codole);
                ViewBag.Tipos = codole.DatatSourceTipoCodole();
                ViewBag.Empresas = codole.DatatSourceEmpresas();
                ViewBag.Solicitado = codole.DatatSourceSolicitado();
                ViewBag.Creadopor = codole.DataSourceUsuariosLegal();
                ViewBag.Validado = codole.DataSourceUsuariosLegal();
                if (item.Id_Codole > 0)
                {
                    ViewBag.Proyectos = codole.DatatSourceProyectos(item.Id_Empresa.Value);
                    ViewBag.Documentos = codole.ListDocumentos(item.Id_Codole);
                }
                else
                    ViewBag.Proyectos = codole.DatatSourceProyectos(0);
                item = items;
            }

            else {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                int i = codole.Guardar(item);
                if (i == 0)
                {

                }
                CODOLE items = codole.ObetnerCodole(item.Id_Codole);
                ViewBag.Tipos = codole.DatatSourceTipoCodole();
                ViewBag.Empresas = codole.DatatSourceEmpresas();
                ViewBag.Solicitado = codole.DatatSourceSolicitado();
                ViewBag.Creadopor = codole.DataSourceUsuariosLegal();
                ViewBag.Validado = codole.DataSourceUsuariosLegal();
                if (item.Id_Codole > 0)
                {
                    ViewBag.Proyectos = codole.DatatSourceProyectos(item.Id_Empresa.Value);
                    ViewBag.Documentos = codole.ListDocumentos(item.Id_Codole);
                }
                else
                    ViewBag.Proyectos = codole.DatatSourceProyectos(0);
                item = items;
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Subir(HttpPostedFileBase file, int Id_Pago = 0)
        {
            return View("~/Views/CapturaNurc/EditNurc.cshtml", codole);
        }
        public FileResult Download(string name,string name2)
        {
            Stream file = null;
            if (ftp.FTPDownload(name, out file))
                return File(file, MediaTypeNames.Application.Octet, name2);
            else
                return null;
        }
    }
}