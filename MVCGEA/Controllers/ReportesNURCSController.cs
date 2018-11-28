using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.IO;
using System.Web.UI;
using ClosedXML.Excel;
using System.Web.UI.WebControls;
using System.Data;
using PagedList;
using System.Net.Mime;

namespace MVCGEA.Controllers
{
    public class ReportesNURCSController : Controller
    {
        VPagosHelper report = new VPagosHelper();
        CompressHelper Zip = new CompressHelper();
        // GET: ReportesNURCS
        public ActionResult LibReporteNurcs(int? page,string search, string CurrentFilter)
        {
            ViewBag.CurrentFilter = search;
            int PageNumber = (page ?? 1);
            int PageSize = 30;
            return View(report.ListaNurcs(PageNumber, PageSize,search,CurrentFilter));
        }

        [HttpPost]
        public FileResult Export()
        {

           
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[39] { new DataColumn("NURC")
                            ,new DataColumn("Estatus")
                            ,new DataColumn("Fecha de Pago")
                            ,new DataColumn("Autorizaciones")
                            ,new DataColumn("Folio Fiscal")
                            ,new DataColumn("No Transferencia")
                            ,new DataColumn("No Cotización")
                            ,new DataColumn("Clasificación")
                            ,new DataColumn("Tipo de Pago")
                            ,new DataColumn("Factura")
                            ,new DataColumn("XML")
                            ,new DataColumn("Comprobante de pago")
                            ,new DataColumn("SAT")
                            ,new DataColumn("Contrato")
                            ,new DataColumn("Empresa")
                            ,new DataColumn("R.F.C")
                            ,new DataColumn("Banco")
                            ,new DataColumn("No Cuenta")
                            ,new DataColumn("Proveedor")
                            ,new DataColumn("R.F.C Proveedor")
                            ,new DataColumn("Banco Proveedor")
                            ,new DataColumn("No Cuenta Proveedor")
                            ,new DataColumn("Proyecto")
                            ,new DataColumn("Programa")
                            ,new DataColumn("Rubro")
                            ,new DataColumn("Concepto")
                            ,new DataColumn("Acticipo")
                            ,new DataColumn("Importe")
                            ,new DataColumn("I.V.A")
                            ,new DataColumn("Rent. I.V.A")
                            ,new DataColumn("Rent. Otros")
                            ,new DataColumn("Rent. I.S.R")
                            ,new DataColumn("Total")
                            ,new DataColumn("Moneda")
                            ,new DataColumn("Cambio")
                            ,new DataColumn("Total Conversión")
                            ,new DataColumn("Moneda Conversión")
                            ,new DataColumn("CS1")
                            ,new DataColumn("CS2") });
            foreach (ExcelNurc customer in report.Excel())
            {
                dt.Rows.Add(customer.NURC
                    ,customer.Estatus
                    ,customer.FechaPago.HasValue==true? customer.FechaPago.Value.ToShortDateString():""
                    ,customer.Autorizaciones
                    ,customer.Folio_Fiscal
                    ,customer.NoTransferencia
                    ,customer.NoCatización
                    ,customer.Clasificación
                    ,customer.TipodePago
                    ,customer.Factura
                    ,customer.XML
                    ,customer.Comprobante_Pago
                    ,customer.SAT
                    ,customer.Contrato
                    ,customer.Empresa
                    ,customer.RFC
                    ,customer.Banco
                    ,customer.NoCuenta
                    ,customer.Proveedor
                    ,customer.RFC_Proveedor
                    ,customer.Banco_Proveedor
                    ,customer.NoCuentaProveedor
                    ,customer.Proyecto
                    ,customer.Programa
                    ,customer.Rubro
                    ,customer.Concepto
                    ,customer.Acticipo.HasValue==true?customer.Acticipo:false
                    ,customer.Importe.Value.ToString("C")
                    ,customer.IVA.Value.ToString("C")
                    , customer.Rent_IVA.Value.ToString("C")
                    , customer.Rent_Otros.Value.ToString("C")
                    , customer.Rent_ISR.Value.ToString("C")
                    , customer.Total.Value.ToString("C")
                    , customer.Moneda
                    ,customer.Cambio.Value.ToString("C")
                    , customer.Total_Conversión.Value.ToString("C")
                    , customer.Moneda_Conversión
                    ,customer.CS1
                    ,customer.CS2);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "NURCS.xlsx");
                }
            }
        }
        public FileResult DownloadZip(int id = 0)
        {
            string nombre = string.Format("NURC{0}.zip", id);
            List<ListDocuments> files = report.DataSourceDocumentos(id).Select(x => new ListDocuments { NAME = x.Nombre, VNAME = x.Nombre_Virtual }).ToList();
            MemoryStream zip = new MemoryStream();
            if (Zip.DowloadZip(files, out zip))
                return File(zip.ToArray(), MediaTypeNames.Application.Zip, nombre);
            else
                return null;
        }


    }
}