using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Mime;
using Ionic.Zip;

namespace MVCGEA.Controllers
{
    public class NIngresosController : Controller
    {
        IngresosHelper ingre = new IngresosHelper();
        FTPHelper ftp = new FTPHelper();
        CompressHelper Zip = new CompressHelper();
        // GET: NIngresos
        public ActionResult LibNIngresos()
        {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            return View(ingre.ListIngresos(IdUser));
        }
        public ActionResult ListIngresoC() {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            return PartialView(ingre.ListIngresosC(IdUser));
        }
        public ActionResult LibViewPago(int id=0) {
            ViewBag.Doctos = ingre.DataSourceDocumentos(id);
            ViewBag.ListConceptos = ingre.DataSourceConceptos(id);
            return View(ingre.ObtenerVPago(id));
        }
        public ActionResult EditNurc(int id=0) {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            Pagos item = new Pagos();
            item = ingre.ObtenerNurc(id, IdUser);
            ViewBag.Listmsj = "";
            ViewBag.ShowError = false;
            if (item.Id_Pago > 0)
            {
                ViewBag.Empresa = ingre.DataSourceEmpresasUsuario(IdUser);
                ViewBag.Proveedores = ingre.DataSourceProveedores(item.Id_Empresa.Value);
                ViewBag.Proyectos = ingre.DataSourceProyectos(item.Id_Empresa.Value);
                ViewBag.Rubros = ingre.DataSourceRubros(item.Id_Proyecto.Value);
                ViewBag.Moneda = ingre.DataSourceMoneda();
                ViewBag.BancosE = ingre.DataSourceBancosProveedor(item.Id_Empresa.Value, item.Id_Moneda.Value);
                ViewBag.CuentaE = ingre.DataSourceCuentaProveedor(item.Id_Banco_Empresa.Value, item.Id_Empresa.Value, item.Id_Moneda.Value);
                ViewBag.ClabeE = ingre.DataSourceClabeProveedor(item.Id_Banco_Empresa.Value, item.Id_Empresa.Value, item.Id_Moneda.Value);
                ViewBag.BancoP = ingre.DataSourceBancosProveedor(item.Id_Proveedor.Value, item.Id_Moneda.Value);
                ViewBag.CuentaP = ingre.DataSourceCuentaProveedor(item.Id_Banco.Value, item.Id_Proveedor.Value, item.Id_Moneda.Value);
                ViewBag.ClabeP = ingre.DataSourceClabeProveedor(item.Id_Banco.Value, item.Id_Proveedor.Value, item.Id_Moneda.Value);
                ViewBag.Tipo = ingre.DataSourceTipoDocumento();
                ViewBag.TipoPago = ingre.DataSourceTipoPago();
                ViewBag.Solicitantes = ingre.DataSourceSolicitantes();
                ViewBag.Doctos = ingre.DataSourceDocumentos(item.Id_Pago);
                ViewBag.ListConceptos = ingre.DataSourceConceptos(item.Id_Pago);
            }
            else {
                ViewBag.Empresa = ingre.DataSourceEmpresasUsuario(IdUser);
                ViewBag.Proveedores = ingre.DataSourceProveedores(-1);
                ViewBag.Proyectos = ingre.DataSourceProyectos(-1);
                ViewBag.Rubros = ingre.DataSourceRubros(-1);
                ViewBag.Moneda = ingre.DataSourceMoneda();
                ViewBag.BancosE = ingre.DataSourceBancosProveedor(-1, -1);
                ViewBag.CuentaE = ingre.DataSourceCuentaProveedor(-1,-1, -1);
                ViewBag.ClabeE = ingre.DataSourceClabeProveedor(-1, -1, -1);
                ViewBag.BancoP = ingre.DataSourceBancosProveedor(-1, -1);
                ViewBag.CuentaP = ingre.DataSourceCuentaProveedor(-1,-1, -1);
                ViewBag.ClabeP = ingre.DataSourceClabeProveedor(-1, -1, -1);
                ViewBag.Tipo = ingre.DataSourceTipoDocumento();
                ViewBag.TipoPago = ingre.DataSourceTipoPago();
                ViewBag.Solicitantes = ingre.DataSourceSolicitantes();
                ViewBag.Doctos = ingre.DataSourceDocumentos(item.Id_Pago);
            }      
            return View(item);
        }
        public ActionResult EditConceptos(int id=0) {
            Conceptos item = new Conceptos();
            ViewBag.ListConceptos = ingre.DataSourceConceptos(id);
            return PartialView(item);
        }
        public ActionResult FileUpload(int id=0) {
            Documentos item = new Documentos();
            ViewBag.Doctos = ingre.DataSourceDocumentos(id);
            return PartialView(item);
        }
        public JsonResult GetProyectos(int idemp = 0)
        {
            return Json(new SelectList(ingre.DataSourceProyectos(idemp), "Id", "Texto", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetRubros(int id = 0)
        {
            return Json(new SelectList(ingre.DataSourceRubros(id), "Id", "Texto", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetProveedores(int id = 0)
        {
            return Json(new SelectList(ingre.DataSourceProveedores(id), "Id", "Texto", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetBancos(int id = 0, int idmoneda = 0)
        {
            return Json(new SelectList(ingre.DataSourceBancosProveedor(id, idmoneda), "Id", "Texto", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetClabe(int idbanco = 0, int idproveedor = 0, int idmoneda = 0)
        {
            return Json(new SelectList(ingre.DataSourceClabeProveedor(idbanco, idproveedor, idmoneda), "Id", "Texto", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetCuenta(int idbanco = 0, int idproveedor = 0, int idmoneda = 0)
        {
            return Json(new SelectList(ingre.DataSourceCuentaProveedor(idbanco, idproveedor, idmoneda), "Id", "Texto", JsonRequestBehavior.AllowGet));
        }
        public FileResult Download(string name, string name2)
        {
            Stream file = null;
            if (ftp.FTPDownload(name, out file))
                return File(file, MediaTypeNames.Application.Octet, name2);
            else
                return null;
        }
        public FileResult DownloadZip(int id = 0)
        {
            string nombre = string.Format("NURC{0}.zip", id);
            List<ListDocuments> files = ingre.DataSourceDocumentos(id).Select(x => new ListDocuments { NAME = x.Nombre, VNAME = x.Nombre_Virtual }).ToList();
            MemoryStream zip = new MemoryStream();
            if (Zip.DowloadZip(files, out zip))
               return File(zip.ToArray(), MediaTypeNames.Application.Zip, nombre);
            else
                return null;
        }
        public ActionResult DelConcepto(int id = 0)
        {
            Conceptos item = new Conceptos();
            item.Id_Conceptos = id;
            ingre.GuardarConcepto(item);
            return Json("Concepto Borrado", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveConcepto(string concep, int idpago = 0)
        {
            Conceptos item = new Conceptos();
            item.Creado_por = int.Parse(Session["IdUser"].ToString());
            item.F_Alta = DateTime.Now;
            item.Activo = true;
            item.Id_Pago = idpago;
            item.Conceptos1 = concep;
            ingre.GuardarConcepto(item);
            return Json("Concepto guardado");
        }
        [HttpPost]
        public async Task<JsonResult> UploadHomeReport(int id = 0, int Id_Tipo_Documento = 0)
        {
            try
            {
                int IdUser = int.Parse(Session["IdUser"].ToString());
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var stream = fileContent.InputStream;
                        var fileName = Path.GetFileName(file);
                        var path = Path.Combine(Server.MapPath("~/signalr"), fileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                        ingre.GuardarDocumento(id, fileName, Id_Tipo_Documento, IdUser);
                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }
            return Json("File uploaded successfully");
        }
        public ActionResult BorrarDocumento(int id = 0, int idPago = 0)
        {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            ingre.BorrarDocumento(id, IdUser);
            return Json("Exito", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Save(Pagos item, string btnSave)
        {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            List<Msj> msj;
            ViewBag.Listmsj = "";
            ViewBag.Empresa = ingre.DataSourceEmpresasUsuario(IdUser);
            ViewBag.Proveedores = ingre.DataSourceProveedores(item.Id_Empresa.HasValue?item.Id_Empresa.Value:-1);
            ViewBag.Proyectos = ingre.DataSourceProyectos(item.Id_Empresa.HasValue ? item.Id_Empresa.Value : -1);
            ViewBag.Rubros = ingre.DataSourceRubros(item.Id_Proyecto.HasValue? item.Id_Proyecto.Value :-1);
            ViewBag.Moneda = ingre.DataSourceMoneda();
            ViewBag.BancosE = ingre.DataSourceBancosProveedor(item.Id_Empresa.HasValue ? item.Id_Empresa.Value : -1, item.Id_Moneda.HasValue?item.Id_Moneda.Value:1);
            ViewBag.CuentaE = ingre.DataSourceCuentaProveedor(item.Id_Banco_Empresa.HasValue? item.Id_Banco_Empresa.Value:-1, item.Id_Empresa.HasValue ? item.Id_Empresa.Value : -1, item.Id_Moneda.HasValue ? item.Id_Moneda.Value : 1);

            ViewBag.ClabeE = ingre.DataSourceClabeProveedor(item.Id_Banco_Empresa.HasValue? item.Id_Banco_Empresa.Value:-1, item.Id_Empresa.HasValue ? item.Id_Empresa.Value : -1, item.Id_Moneda.HasValue ? item.Id_Moneda.Value : 1);

            ViewBag.BancoP = ingre.DataSourceBancosProveedor(item.Id_Proveedor.HasValue?item.Id_Proveedor.Value:-1, item.Id_Moneda.Value);

            ViewBag.CuentaP = ingre.DataSourceCuentaProveedor(item.Id_N_Cuenta.HasValue?item.Id_N_Cuenta.Value:-1, item.Id_Proveedor.HasValue ? item.Id_Proveedor.Value : -1, item.Id_Moneda.HasValue ? item.Id_Moneda.Value : 1);

            ViewBag.ClabeP = ingre.DataSourceClabeProveedor(item.Id_Banco.HasValue?item.Id_Banco.Value:-1, item.Id_Proveedor.HasValue ? item.Id_Proveedor.Value : -1, item.Id_Moneda.HasValue ? item.Id_Moneda.Value : 1);

            ViewBag.Tipo = ingre.DataSourceTipoDocumento();
            ViewBag.TipoPago = ingre.DataSourceTipoPago();
            ViewBag.Solicitantes = ingre.DataSourceSolicitantes();
            ViewBag.Doctos = ingre.DataSourceDocumentos(item.Id_Pago);
            ViewBag.ListConceptos = ingre.DataSourceConceptos(item.Id_Pago);
            if (btnSave.Equals("Save"))
            {
                item.Id_Clasificacion = 2;
                item.Id_Pago.ToString();
                item.Id_Estatus_Pago = 1;
                item.Creado_por = IdUser;
                item.Activo = true;


                if (ingre.Guardar(item, out msj) == 0)
                    return Redirect("LibNIngresos");
                else
                {
                    ViewBag.Listmsj = JsonConvert.SerializeObject(msj, Newtonsoft.Json.Formatting.None);
                    ViewBag.ShowError = true;
                    return View("~/Views/NIngresos/EditNurc.cshtml", item);
                }
            }
            else if (btnSave.Equals("Send"))
            {
                item.Id_Clasificacion = 2;
                item.Id_Pago.ToString();
                item.Id_Estatus_Pago = 2;
                item.Creado_por = IdUser;
                item.Activo = true;
                if (ingre.Guardar(item, out msj) == 0)
                    return Redirect("LibNIngresos");
                else
                {
                    ViewBag.Listmsj = JsonConvert.SerializeObject(msj, Newtonsoft.Json.Formatting.None);
                    ViewBag.ShowError = true;
                    return View("~/Views/NIngresos/EditNurc.cshtml", item);
                }
            }
            else
            {
                return View("~/Views/NIngresos/EditNurc.cshtml", item);
            }
        }
    }
}