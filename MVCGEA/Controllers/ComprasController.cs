using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class ComprasController : Controller
    {
        ReqComprasHelper req = new ReqComprasHelper();
        // GET: Compras
        public ActionResult LibReqCompraA()
        {
            int IdUser = int.Parse(Session["IdUser"].ToString());   
            return View(req.ListReqCompra(IdUser));
        }
    }
}