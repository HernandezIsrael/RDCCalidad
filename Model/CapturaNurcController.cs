using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace MVCGEA.Controllers
{
    public class CapturaNurcController : Controller
    {
        const string UploadDirectory = "~/XML/";
        NurcEgresosHelper nsegresos = new NurcEgresosHelper();
        // GET: CapturaNurc
        public ActionResult LibNurcCaptura()
        {
            return View();
        }
        public ActionResult LibViewPagos(int id=0) {
            ViewBag.Doctos = nsegresos.DataSourceDocumentos(id);
            ViewBag.ListConceptos = nsegresos.DataSourceConceptos(id);
            return View(nsegresos.ViewPago(id));
        }
        public ActionResult LibNurcProcesados(int? page, string search, string CurrentFilter) {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            ViewBag.CurrentFilter = search;
            int PageNumber = (page ?? 1);
            int PageSize = 30;
            return PartialView(nsegresos.ProcesadosUsuario(IdUser, PageNumber, PageSize, search, CurrentFilter));
        }
        public ActionResult LibNCaptura(int? page, string search2, string CurrentFilter2)
        {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            ViewBag.CurrentFilter2 = search2;
            int PageNumber = (page ?? 1);
            int PageSize = 30;
            return PartialView(nsegresos.CapturaUsuario(IdUser, PageNumber, PageSize, search2, CurrentFilter2));
        }
        public ActionResult EditNurc(int id=0) {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            Pagos item = new Pagos();
            ViewBag.Listmsj = "";
            ViewBag.ShowError = false;
            if (id > 0) {
                item = nsegresos.SelectNurc(id);
               
            }
            else {
                item = nsegresos.CrearNurc(IdUser);
            }
            ViewBag.Empresas = nsegresos.DataSourceEmpresasUsuario(IdUser);
            ViewBag.Solicitantes = nsegresos.DataSourceSolicitantes();
            ViewBag.TipoPago = nsegresos.DataSourceTipoPago();
            ViewBag.Moneda = nsegresos.DataSourceMoneda();
            ViewBag.ListaDocumento = nsegresos.DataSourceTipoDocumento();
            return View(item);
        }
        public JsonResult GetProyectos(int idemp = 0)
        {
            return Json(new SelectList(nsegresos.DataSourceProyectos(idemp), "Id", "Proyecto", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetRubros(int id = 0)
        {
            return Json(new SelectList(nsegresos.DataSourceRubros(id), "Id", "Rubro", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetProveedores(int id = 0)
        {
            return Json(new SelectList(nsegresos.DataSourceProveedores(id), "Id", "Proveedores", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetBancosProveedor(int id = 0,int idmoneda=0)
        {
            return Json(new SelectList(nsegresos.DataSourceBancosProveedor(id,idmoneda), "Id", "Banco", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetClabeProveedor(int idbanco=0, int idproveedor=0, int idmoneda=0)
        {
            return Json(new SelectList(nsegresos.DataSourceClabeProveedor(idbanco , idproveedor , idmoneda), "Id", "Clabe", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetCuentaProveedor(int idbanco = 0, int idproveedor = 0, int idmoneda = 0)
        {
            return Json(new SelectList(nsegresos.DataSourceCuentaProveedor(idbanco, idproveedor, idmoneda), "Id", "Cuenta", JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetCuentaContrato(int idempresa = 0, int idproveedor = 0)
        {
            return Json(new SelectList(nsegresos.DataSourceContrato(idempresa, idproveedor), "Id", "Contrato", JsonRequestBehavior.AllowGet));
        }
        public ActionResult FileUpload(int id=0) {
            Documentos item = new Documentos();       
            ViewBag.Doctos = nsegresos.DataSourceDocumentos(id);
            return PartialView(item);
        }
        public ActionResult EditConceptos(int id=0) {
            Conceptos item = new Conceptos();
            ViewBag.ListConceptos = nsegresos.DataSourceConceptos(id);
            item.Id_Pago = id;
            return PartialView(item);
        }
        [HttpPost]
        public async Task<JsonResult> UploadHomeReport(int id=0,int Id_Tipo_Documento=0)
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
                        using (var fileStream =System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                        nsegresos.GuardarDocumento(id, fileName, Id_Tipo_Documento, IdUser);
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
        public ActionResult BorrarDocumento(int id=0,int idPago=0) {
            int IdUser = int.Parse(Session["IdUser"].ToString());
            nsegresos.BorrarDocumento(id, IdUser);
            return Json("Exito",JsonRequestBehavior.AllowGet);
        }
        public ActionResult DelConcepto(int id = 0)
        {
            Conceptos item = new Conceptos();
            item.Id_Conceptos = id;
            nsegresos.GuardarConcepto(item);
            return Json("Concepto Borrado",JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveConcepto( string concep ,int idpago=0) {
            Conceptos item = new Conceptos();
            item.Creado_por = int.Parse(Session["IdUser"].ToString());
            item.F_Alta = DateTime.Now;
            item.Activo = true;
            item.Id_Pago = idpago;
            item.Conceptos1 = concep;
            nsegresos.GuardarConcepto(item);
            return Json("Concepto guardado");
        }
        [HttpPost]
       
        public ActionResult Save(Pagos item,string btnSave)
        {
            if (btnSave.Equals("Save"))
            {
                item.Id_Pago.ToString();
                item.Id_Estatus_Pago = 1;
                List<Msj> msj;
                ViewBag.Listmsj = "";
                int IdUser = int.Parse(Session["IdUser"].ToString());

                ViewBag.Empresas = nsegresos.DataSourceEmpresasUsuario(IdUser);
                ViewBag.Solicitantes = nsegresos.DataSourceSolicitantes();
                ViewBag.TipoPago = nsegresos.DataSourceTipoPago();
                ViewBag.Moneda = nsegresos.DataSourceMoneda();
                ViewBag.ListaDocumento = nsegresos.DataSourceTipoDocumento();
                if (nsegresos.Guardar(item, out msj) == 0)
                    return Redirect("LibNurcCaptura");
                else
                {
                    ViewBag.Listmsj = JsonConvert.SerializeObject(msj, Newtonsoft.Json.Formatting.None);
                    ViewBag.ShowError = true;
                    return View("~/Views/CapturaNurc/EditNurc.cshtml", item);
                }
            }
            else if (btnSave.Equals("Send"))
            {
                item.Id_Pago.ToString();
                item.Id_Estatus_Pago = 2;
                List<Msj> msj;
                ViewBag.Listmsj = "";
                int IdUser = int.Parse(Session["IdUser"].ToString());


                ViewBag.Empresas = nsegresos.DataSourceEmpresasUsuario(IdUser);
                ViewBag.Solicitantes = nsegresos.DataSourceSolicitantes();
                ViewBag.TipoPago = nsegresos.DataSourceTipoPago();
                ViewBag.Moneda = nsegresos.DataSourceMoneda();
                ViewBag.ListaDocumento = nsegresos.DataSourceTipoDocumento();
                if (nsegresos.Guardar(item, out msj) == 0)
                    return Redirect("LibNurcCaptura");
                else
                {
                    ViewBag.Listmsj = JsonConvert.SerializeObject(msj, Newtonsoft.Json.Formatting.None);
                    ViewBag.ShowError = true;
                    return View("~/Views/CapturaNurc/EditNurc.cshtml", item);
                }
            }
            
            else {
                return View("~/Views/CapturaNurc/EditNurc.cshtml", item);
            }
        }

        [HttpPost]
        public ActionResult Subir(HttpPostedFileBase file,int Id_Pago=0)
        {
            Pagos Nurc = nsegresos.SelectNurc(Id_Pago);
            int IdUser = int.Parse(Session["IdUser"].ToString());
            if (file == null) return View("~/Views/CapturaNurc/EditNurc.cshtml", Nurc);
            string archivo = file.FileName;
            string url = string.Format("{0}{1}{2}", UploadDirectory,DateTime.Now.ToString("ss"),archivo);
            try
            {
               
                file.SaveAs(Server.MapPath(url));
                XmlSerializer Serial = new XmlSerializer(typeof(Comprobante));
                XmlTextReader leer = new XmlTextReader(Server.MapPath(url));
                Comprobante Factura = (Comprobante)Serial.Deserialize(leer);
                int i = 0;
                int idempresa = nsegresos.SelectEmpesa(Factura.Receptor.Rfc);
                int idproveedor = nsegresos.SelectEmpesa(Factura.Emisor.Rfc);
                Nurc.Id_Proyecto = 0;

                foreach (ComprobanteComplemento item in Factura.Complemento)
                {
                    for (int x = 0; x < item.Any[i].Attributes.Count; x++)
                    {
                        if (item.Any[i].Attributes[x].Name.ToUpper() == "UUID")
                        {
                            Nurc.Folio_Fiscal = item.Any[i].Attributes[x].Value;
                            break;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(Nurc.Folio_Fiscal)) break;
                    i++;
                }
                if (Factura.Fecha != null)
                    Nurc.F_Emision_Factura = Factura.Fecha;
                if (Factura.Receptor.Rfc != null)
                    if (idempresa != 0)
                    {
                        Nurc.Id_Empresa = idempresa;
                        if (idproveedor != 0)
                            Nurc.Id_Proveedor = idproveedor;
                    }
                nsegresos.BorrarConceptos(Nurc.Id_Pago);
                /**********************************************************************/
                foreach (ComprobanteConcepto con in Factura.Conceptos)
                {
                    try
                    {
                        Conceptos concepto = new Conceptos();
                        concepto.Id_Pago = Nurc.Id_Pago;
                        concepto.Conceptos1 = con.Descripcion;
                        concepto.Creado_por = IdUser;
                        concepto.F_Alta = DateTime.Now;
                        concepto.Activo = true;
                        nsegresos.GuardarConcepto(concepto);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex) {

            }
            ViewBag.Empresas = nsegresos.DataSourceEmpresasUsuario(IdUser);
            ViewBag.Solicitantes = nsegresos.DataSourceSolicitantes();
            ViewBag.TipoPago = nsegresos.DataSourceTipoPago();
            ViewBag.Moneda = nsegresos.DataSourceMoneda();
            ViewBag.ListaDocumento = nsegresos.DataSourceTipoDocumento();
           
            return View("~/Views/CapturaNurc/EditNurc.cshtml", Nurc);
        }

        //[HttpPost]

        //public ActionResult Send(Pagos item)
        //{
        //    item.Id_Pago.ToString();
        //    item.Id_Estatus_Pago = 2;
        //    List<Msj> msj;
        //    ViewBag.Listmsj = "";
        //    int IdUser = int.Parse(Session["IdUser"].ToString());
        //    if (item.Id_Pago > 0)
        //    {
        //        item = nsegresos.SelectNurc(item.Id_Pago);
        //        ViewBag.ListProyectos = nsegresos.DataSourceProyectos(int.Parse(item.Id_Empresa.Value.ToString()));
        //        ViewBag.ListRubros = nsegresos.DataSourceRubros(int.Parse(item.Id_Proyecto.Value.ToString()));
        //    }
        //    else
        //    {
        //        item = nsegresos.CrearNurc(IdUser);
        //    }
        //    ViewBag.Empresas = nsegresos.DataSourceEmpresasUsuario(IdUser);
        //    ViewBag.Solicitantes = nsegresos.DataSourceSolicitantes();
        //    ViewBag.TipoPago = nsegresos.DataSourceTipoPago();
        //    ViewBag.Moneda = nsegresos.DataSourceMoneda();
        //    ViewBag.ListaDocumento = nsegresos.DataSourceTipoDocumento();
        //    if (nsegresos.Guardar(item, out msj) == 0)
        //        return Redirect("LibNurcCaptura");
        //    else
        //    {

        //        ViewBag.Listmsj = JsonConvert.SerializeObject(msj,Formatting.None);
        //        ViewBag.ShowError = true;
        //        return View("~/Views/CapturaNurc/EditNurc.cshtml", item);
        //    }

        //}
    }
}