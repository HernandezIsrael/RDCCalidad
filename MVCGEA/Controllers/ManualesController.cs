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

namespace MVCGEA.Controllers
{
    public class ManualesController : Controller
    {

        ManualesHelper manuales = new ManualesHelper();

        public ActionResult LibManuales()
        {
            return View(manuales.ListManuales());
        }

        public ActionResult FileRegistration(int id = 0)
        {
            ViewBag.Menus = manuales.GetListMenu();
            ViewBag.Areas = manuales.GetListAreas();
            ViewBag.TipoUsuarios = manuales.GetManualesTipoUsuarios();
            return View(manuales.GetInfoManual(id));
        }

        public ActionResult AddManual(Manuales m)
        {
            int newID = 0;
            if (m.IdManual == -1)
            {
                m.FAlta = DateTime.Now;
                m.NombreDoc = "";
                m.NombreVirtual = "0";
            }

            m.Activo = true;
            m.CreadoPor = int.Parse(Session["IdUser"].ToString());
            m.FActualizacion = DateTime.Now;
            manuales.InsertManual(m, out newID);
            return Redirect(Url.Action("FileRegistration", "Manuales", new { id = newID }));
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, int manualId = 0)
        {
            Manuales m = manuales.GetInfoManual(manualId);
            StockHelper stock = new StockHelper();
            FTPHelper ftp = new FTPHelper();

            int outValue;
            string extension = Path.GetExtension(file.FileName).ToLower();
            string NV = string.Empty;
            //string archivo = "";
            bool result = false;

            if (file == null && manualId == 0)
            {
                return Redirect(Url.Action("FileRegistration", "Manuales", new { id = manualId }));
            }

            NV = stock.Renombre();
            NV = NV + extension;

            m.NombreDoc = file.FileName;
            m.NombreVirtual = NV;

            //file.SaveAs(Server.MapPath("~/signalr/Manuales/Manuales" + archivo));

            m.FActualizacion = DateTime.Now;
            manuales.InsertManual(m, out outValue);

            result = ftp.FTPSubir(NV, file);

            return Redirect(Url.Action("FileRegistration", "Manuales", new { id = manualId }));
        }

        public FileResult Download(string name, string name2)
        {
            //string path = Server.MapPath("~/signalr/Manuales/Manuales" + name);
            //byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            //return File(fileBytes, MediaTypeNames.Application.Octet, name);
            Stream file = null;
            FTPHelper ftp = new FTPHelper();


            if (ftp.FTPDownload(name, out file))
                return File(file, MediaTypeNames.Application.Octet, name2);
            else
                return null;
        }
    }
}