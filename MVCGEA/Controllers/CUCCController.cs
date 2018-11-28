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
    public class CUCCController : Controller
    {
        CuccHelper contrato = new CuccHelper();
        FTPHelper ftp = new FTPHelper();
        // GET: CUCC
        public ActionResult LibCucc()
        {
            return View(contrato.ListCucc());
        }
        public ActionResult EditCucc(int id = 0) {
            Contratos item = contrato.ObtenerContrato(id);
            ViewBag.TipoContrato = contrato.DataSourceTipoContratos();
            ViewBag.LEmpresas = contrato.DatatSourceEmpresas();
            if (item.Id_Contrato > 0)
            {
                ViewBag.LProyectos = contrato.DatatSourceProyectos(item.Id_Empresa.Value);
                ViewBag.ListContratos = contrato.ListContratos(id);
            }
            else
                ViewBag.LProyectos = contrato.DatatSourceProyectos(-1);
            ViewBag.UserLegal = contrato.DataSourceUsuariosLegal();
            return View(item);
        }
        public JsonResult GetProyectos(int id = 0)
        {
            return Json(new SelectList(contrato.DatatSourceProyectos(id), "Id", "NombreCompleto", JsonRequestBehavior.AllowGet));
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
        public ActionResult Save(Contratos item) {
            if (ModelState.IsValid) {
                item.Creado_por = int.Parse(Session["IdUser"].ToString());
                item.F_Alta = DateTime.Now;
                int i = contrato.Guardar(item);
                if (i==0) {
                }
                ViewBag.TipoContrato = contrato.DataSourceTipoContratos();
                ViewBag.LEmpresas = contrato.DatatSourceEmpresas();
                if (item.Id_Contrato > 0)
                {
                    ViewBag.LProyectos = contrato.DatatSourceProyectos(item.Id_Empresa.Value);
                    ViewBag.ListContratos = contrato.ListContratos(item.Id_Contrato);
                }
                else
                    ViewBag.LProyectos = contrato.DatatSourceProyectos(-1);
                ViewBag.UserLegal = contrato.DataSourceUsuariosLegal();
            }
            return View("~/Views/Cucc/EditCucc.cshtml", item);
        }
    }
}