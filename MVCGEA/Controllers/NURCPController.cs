using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Newtonsoft.Json;
using System.Text;

namespace MVCGEA.Controllers
{
    
    public class NURCPController : Controller
    {
        // GET: NURCP
        NURCCPHelper nurc = new NURCCPHelper();
        public ActionResult LibPagosProgramados()
        {
            ViewBag.ShowError = false;
            return View(nurc.LisPagos());
        }
        public ActionResult CancelNurc(int id=0) {
            return PartialView(nurc.ObetnerNurc(id));
        }
        public ActionResult AutorizarNurc(int id = 0)
        {
            return PartialView(nurc.ObetnerNurc(id));
        }
        [HttpPost]
        public ActionResult Cancel(Pagos item)
        {
            if (ModelState.IsValid)
            {
                
                int IdUser = int.Parse(Session["IdUser"].ToString());
                item.Creado_por = IdUser;
                int i = nurc.Cancelar(item);
                if (i == 0)
                {
                    ViewBag.showError = true;
                    ViewBag.OnIdError = item.Id_Solicitado_por;
                    return PartialView("~/Views/NURCP/CancelNurc.cshtml", item);
                }
            }
            return JavaScript("PopupOnClosed()");
        }
        [HttpPost]
        public ActionResult SaveDoctos(HttpPostedFileBase file, Pagos item)
        {
            List<Msj> msj = new List<Msj>();
            Msj param;
            int IdUser = int.Parse(Session["IdUser"].ToString());
            item.Creado_por = IdUser;
            if (file == null) {
                param = new Msj();
                param.Mnj = "Debe de adjuntar el comprobante de pago";
                msj.Add(param);
                ViewBag.Listmsj = JsonConvert.SerializeObject(msj, Newtonsoft.Json.Formatting.None);
                ViewBag.ShowError = true;
                return PartialView("~/Views/NURCP/LibPagosProgramados.cshtml", nurc.LisPagos());
            }
            string archivo = file.FileName;
            string VirtualName = string.Empty;
            if (nurc.spInsDocumento_Pago(archivo, IdUser, item.Id_Pago, 4, out VirtualName) == 1)
            {
                if (nurc.spPupEstatusPagoCambio(item) == 1)
                {
                    return Redirect("LibPagosProgramados");
                }
                else {
                    param = new Msj();
                    param.Mnj = "Error al Adjuntar documento Codigo L66";
                    msj.Add(param);
                    ViewBag.Listmsj = JsonConvert.SerializeObject(msj, Newtonsoft.Json.Formatting.None);
                    ViewBag.ShowError = true;
                    return View("~/Views/NURCP/LibPagosProgramados.cshtml", nurc.LisPagos());
                }
            }
            else {
                param = new Msj();
                param.Mnj = "Error al Adjuntar documento Codigo L64";
                msj.Add(param);
                ViewBag.Listmsj = JsonConvert.SerializeObject(msj, Newtonsoft.Json.Formatting.None);
                ViewBag.ShowError = true;
                return View("~/Views/NURCP/LibPagosProgramados.cshtml", nurc.LisPagos());
            }

           
        }
    }
}