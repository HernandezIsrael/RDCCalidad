using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGEA.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ErrorPage(string msg = "")
        {
            int image = ErrorImage();
            ViewBag.Msg = msg;
            ViewBag.Img = string.Empty;

            switch (image)
            {
                case 0:
                    ViewBag.Img = "noise2.gif";
                    break;
                case 1:
                    ViewBag.Img = "goat_1.gif";
                    break;
                default:
                    ViewBag.Img = "noise2.gif";
                    break;
            }

            return View();
        }

        private int ErrorImage()
        {
            Random rd = new Random();
            int photo = rd.Next(0, 2);
            return photo;
        }
    }
}