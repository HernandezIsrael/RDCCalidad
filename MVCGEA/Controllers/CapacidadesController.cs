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
using System.Net.Mime;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;

namespace MVCGEA.Controllers
{
    public class CapacidadesController : Controller
    {
        CapacidadesHelper capacidades = new CapacidadesHelper();
        StockHelper stock = new StockHelper();
        FTPHelper ftp = new FTPHelper();

        public ActionResult LibServicios()
        {
            ViewBag.Docs = capacidades.GetAllDocs();
            return View(capacidades.GetServicios());
        }

        public ActionResult NewServicio(int id = 0)
        {
            ViewBag.Empresas = capacidades.GetEmpresas();
            ViewBag.Proveedores = capacidades.GetProveedores();
            ViewBag.Servicios = capacidades.GetTipoServicios();
            ViewBag.Direcciones = capacidades.GetDirecciones();
            ViewBag.Estatus = capacidades.GetStatus();
            ViewBag.Divisas = capacidades.GetDivisas();
            ViewBag.Lapsos = capacidades.GetLapsos();
            if (id != 0)
            {
                ViewBag.Docs = capacidades.GetDocs(id);
            }
            return View(capacidades.GetRawServicio(id));
        }

        public ActionResult AddServicio(Servicios s)
        {
            int ok = 0;
            s.Anio = DateTime.Parse(string.Format("{0}-01-01", s.FCorte.Year));
            s.Mes = DateTime.Parse(string.Format("1989-{0}-01", s.FCorte.Month));
            s.FCorte = s.FCorte;
            s.FAlta = DateTime.Now;
            s.CreadoPor = int.Parse(Session["IdUser"].ToString());
            s.Activo = true;
            s.Factura = false;
            s.XML = false;
            s.CPago = false;
            s.Otros = false;
            ok = capacidades.InsertServicio(s);
            return Redirect(Url.Action("LibServicios", "Capacidades"));
        }

        public FileResult Download(string name, string name2)
        {
            //string path = Server.MapPath("~/signalr/Servicios/" + name);
            //byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            //return File(fileBytes, MediaTypeNames.Application.Octet, name);

            Stream file = null;


            if (ftp.FTPDownload(name, out file))
                return File(file, MediaTypeNames.Application.Octet, name2);
            else
                return null;
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, int servicioID = 0, int tipoDoc = 0)
        {
            SEDocumentosServicios doc = new SEDocumentosServicios();
            Servicios s = capacidades.GetRawServicio(servicioID);

            string extension = Path.GetExtension(file.FileName).ToLower();
            string NV = string.Empty; //stock.Renombre();
            string archivo = "";
            bool result = false;

            //NV = NV + extension;

            if (file == null && servicioID == 0 && tipoDoc != 0)
            {
                return Redirect(Url.Action("NewServicio", "Capacidades", new { id = servicioID }));
            }

            switch (tipoDoc)
            {
                case 2:
                    archivo = ("FACT" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName)).ToLower();
                    s.Factura = true;
                    break;
                case 3:
                    archivo = ("XML" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName)).ToLower();
                    s.XML = true;
                    break;
                case 4:
                    archivo = ("CP" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName)).ToLower();
                    s.CPago = true;
                    break;
                default:
                    archivo = ("DEF" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName)).ToLower();
                    s.Otros = true;
                    break;
            }



            //file.SaveAs(Server.MapPath("~/signalr/Servicios/" + file.FileName));

            doc.IdServicio = servicioID;
            doc.IdTipoDocumentoServicio = tipoDoc;
            doc.Nombre = file.FileName;
            //doc.NombreVirtual = NV;
            doc.Id_FTP = 1;
            doc.FAlta = DateTime.Now;
            doc.CreadoPor = int.Parse(Session["IdUser"].ToString());
            doc.Activo = true;

            if (capacidades.InsertFile(doc, out NV) == 1)
            {
                result = ftp.FTPSubir(NV, file);
            }
            capacidades.InsertServicio(s);
            return Redirect(Url.Action("NewServicio", "Capacidades", new { id = servicioID }));
        }

        /*********************** ACTIVO FIJO ****************************/

        public ActionResult LibActivoFijo()
        {
            return View(capacidades.GetActivoFijo());
        }

        public ActionResult AFDetail(int id = 0, int error = 0, int confirm = 0)
        {
            ViewBag.Empresas = capacidades.GetEmpresas();
            ViewBag.Proveedores = capacidades.GetProveedores();
            ViewBag.Categorias = capacidades.GetCategorias();
            ViewBag.Marcas = capacidades.GetMarcas();
            ViewBag.Condiciones = capacidades.GetCondiciones();
            ViewBag.Monedas = capacidades.GetDivisas();
            ViewBag.Error = error;
            ViewBag.ErrorMsg = "NO MSG";
            ViewBag.Confirm = 0;
            switch (error)
            {
                case 1:
                    ViewBag.ErrorMsg = "Datos incompletos. Favor de verificar que no existan campos obligatorios (*) sin completar.";
                    break;
            }
            if (confirm > 0)
            {
                ViewBag.Confirm = confirm;
            }
            return View(capacidades.GetAFDetail(id));
        }

        public ActionResult UpdateAFInfo(Activo_Fijo producto)
        {
            int newID = 0;
            try
            {

                if (producto.Id_Moneda < 1 || producto.Id_Categoria < 1 || producto.Id_Condicion < 1 || producto.Id_Empresa < 1 || producto.Id_Marca < 1 || producto.Id_Proveedor < 1)
                {
                    return Redirect(Url.Action("AFDetail", "Capacidades", new { error = 1 }));
                }

                producto.Activo = true;
                producto.Creado_por = int.Parse(Session["IdUser"].ToString());
                producto.F_Alta = DateTime.Now;
                newID = capacidades.InsertAF(producto);
                return Redirect(Url.Action("AFDetail", "Capacidades", new { id = newID, confirm = 1 }));
            }
            catch (Exception ex)
            {
                return Redirect(Url.Action("ErrorPage", "Error", new { msg = ex.Message }));
            }
        }

        /*********************** PDF ****************************/

        public ActionResult PDF()
        {
            ControllerContext context = this.ControllerContext;
            string partialViewName = "PDF";

            byte[] buf = null;
            MemoryStream pdfTemp = new MemoryStream();
            ViewEngineResult result = ViewEngines.Engines.FindPartialView(context, partialViewName);
            string imageUrl = Server.MapPath("~/Image/1.jpg");


            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageUrl);
            jpg.SetAbsolutePosition(450, 750);
            jpg.ScaleAbsolute(120F, 120F);

            if (result.View != null)
            {
                string htmlTextView = GetViewToString(context, result);
                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, pdfTemp);
                writer.CloseStream = false;
                doc.Open();

                //doc.Add(jpg);
                //doc.Add(new iTextSharp.text.Paragraph("Documento PDF al Vuelo"));

                AddHTMLText(doc, htmlTextView);

                doc.Close();

                buf = new byte[pdfTemp.Position];
                pdfTemp.Position = 0;
                pdfTemp.Read(buf, 0, buf.Length);
            }
            return File(buf, "application/pdf", "tempPdf.pdf");
        }

        private string GetViewToString(ControllerContext context, ViewEngineResult result)
        {
            string viewResult = "";
            ViewDataDictionary viewData = new ViewDataDictionary();
            TempDataDictionary tempData = new TempDataDictionary();
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (HtmlTextWriter output = new HtmlTextWriter(sw))
                {
                    ViewContext viewContext = new ViewContext(context, result.View, viewData, tempData, output);
                    result.View.Render(viewContext, output);
                }
                viewResult = sb.ToString();
            }
            return viewResult;
        }

        private void AddHTMLText(iTextSharp.text.Document doc, string html)
        {
#pragma warning disable CS0612 // Type or member is obsolete
            List<iTextSharp.text.IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(html), null);
#pragma warning restore CS0612 // Type or member is obsolete

            foreach (var item in htmlarraylist)
            {
                doc.Add(item);
            }
        }

        /*********************** PDF ****************************/

        public ActionResult PreviewPDF(int id = 0)
        {
            // id es el el ID de la empresa
            Empresas empresa = capacidades.GetEmpresa(id);
            ViewBag.Cliente = empresa.Razon_Social;
            ViewBag.Servicios = capacidades.GetReporteServicios(id);
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [HandleError]
        public FileResult Export(string HtmlString)
        {
            string imageUrl = Server.MapPath("~/Image/Clusmext-logo.png");
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageUrl);
            //jpg.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            jpg.SetAbsolutePosition(-5, 775);
            jpg.ScaleAbsolute(206F, 62F);

            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(HtmlString);
                Document pdfDoc = new Document(PageSize.A4, 32.5f, 20f, 20f, 20f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(jpg);
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", string.Format("{0}.pdf", DateTime.Now));
            }
        }

        public ActionResult PDFPreview()
        {
            return View();
        }

    }
}