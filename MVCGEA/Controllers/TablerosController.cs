using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;

namespace MVCGEA.Controllers
{
    public class TablerosController : Controller
    {
        TablerosHelper tablero = new TablerosHelper();
        // GET: Tableros
        public ActionResult LibEstadoCuenta()
        {
            int id =int.Parse(Session["IdUser"].ToString());
            ViewBag.List = JsonConvert.SerializeObject(tablero.ListarUltimosSaldos(id), Newtonsoft.Json.Formatting.None);
            return View(tablero.ListarUltimosSaldos(id));
        }
        public ActionResult ListMovimientos(int id=0) {
            ViewBag.ListMov = tablero.ListMovimientos2(id);
            return PartialView();
        }
        [HttpPost]
        public JsonResult NewChart()
        {
            Random r = new Random();

            int id = int.Parse(Session["IdUser"].ToString());
            List<spSelVUltimosSaldos2_Result> items = tablero.ListarUltimosSaldos(id);
            List<object> iData = new List<object>();
            //Creating sample data  
            DataTable dt = new DataTable();
            dt.Columns.Add("Empresa", System.Type.GetType("System.String"));
            dt.Columns.Add("Money", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("Color", System.Type.GetType("System.String"));
            foreach (spSelVUltimosSaldos2_Result item in items) {
                DataRow dr = dt.NewRow();
                dr["Empresa"] = item.Empresa;
                dr["Money"] = item.Tsaldo.Value;
                int i = r.Next(0, 40);
                dr["Color"] = tablero.Colores()[i];
                dt.Rows.Add(dr);
            }
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProMedios(int id=0)
        {
            Random r = new Random();

            int IdUser = int.Parse(Session["IdUser"].ToString());
            List<spSelPromedioSaldos_Result> items = tablero.ListPromedioSaldo(id);
            List<object> iData = new List<object>();
            //Creating sample data  
            DataTable dt = new DataTable();
            dt.Columns.Add("Empresa", System.Type.GetType("System.String"));
            dt.Columns.Add("Money", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("Color", System.Type.GetType("System.String"));
            foreach (spSelPromedioSaldos_Result item in items)
            {
                DataRow dr = dt.NewRow();
                dr["Empresa"] = item.N_Cuenta;
                dr["Money"] = item.SALDO;
                int i = r.Next(0, 40);
                dr["Color"] = tablero.Colores()[i];
                dt.Rows.Add(dr);
            }
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LibProyectos(int id=0) {
            return View(tablero.ListProyectos());
        }
        public ActionResult ListRubros(int id=0) {
            ViewBag.ListRu = tablero.ListRubros(id);
            return PartialView();
        }
        public JsonResult RubrosBar(int id = 0)
        {
            Random r = new Random();

            int IdUser = int.Parse(Session["IdUser"].ToString());
            List<V_Rubros_Proyecto> items = tablero.ListRubros(id);
            List<object> iData = new List<object>();
            //Creating sample data  
            DataTable dt = new DataTable();
            dt.Columns.Add("Rubro", System.Type.GetType("System.String"));
            dt.Columns.Add("Finan", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("Gasto", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("Dif", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("Color", System.Type.GetType("System.String"));
            foreach (V_Rubros_Proyecto item in items)
            {
                DataRow dr = dt.NewRow();
                dr["Rubro"] = item.Codigo_Rubro;
                dr["Finan"] = item.Financiamiento;
                dr["Gasto"] = item.Gastado;
                dr["Dif"] = item.DIF;
                int i = r.Next(0, 40);
                dr["Color"] = tablero.Colores()[i];
                dt.Rows.Add(dr);
            }
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LibHNurc() {
            DateTime Fini = DateTime.Now.AddDays(-100);
            DateTime Ffin = DateTime.Now;
            return View(tablero.ListHistorico(Fini,Ffin));
        }
    }
}