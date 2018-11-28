using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class HomeController : Controller
    {
        private UsersHelper user = new UsersHelper();
        private MenuHelper menu = new MenuHelper();
        private NotificationHelper notification = new NotificationHelper();

        public ActionResult Index()
        {
            ViewBag.image = string.Format("{0}.jpg", UsersHelper.Photo());
            ViewBag.showError = false;
            return View();
        }

        public ActionResult Main()
        {
            Usuarios user = new Usuarios();
            HomeHelper home = new HomeHelper();

            user = home.GetUserInfo(int.Parse(Session["IdUser"].ToString()));

            ViewBag.UserInfo = user;
            ViewBag.News = home.GetNews();

            return View();
        }

        public ActionResult NewsConfig(int msg = 0)
        {
            HomeHelper home = new HomeHelper();
            ViewBag.News = home.GetNews();
            ViewBag.Msg = msg;
            ViewBag.MsgString = msg;

            switch (msg)
            {
                case 1:
                    ViewBag.MsgString = "El formato de archivo seleccionado no corresponde al formato de imagen requerido";
                    break;
                case 2:
                    ViewBag.MsgString = "No se ha seleccionado el archivo de imagen";
                    break;
                case 3:
                    ViewBag.MsgString = "Se han actualizado los cambios";
                    break;

            }

            return View(home.GetNewById());
        }

        public ActionResult UpdateNews(NewsFeed item, int id)
        {
            HomeHelper home = new HomeHelper();
            NewsFeed old = home.GetNewById(id);
            int result = 0;

            old.Cabecera = item.Cabecera;
            old.Descripcion = item.Descripcion;
            old.FAlta = DateTime.Now;
            old.Mostrar = item.Mostrar;
            old.URL = item.URL;

            result = home.UpdateNewsFeed(old);

            if (result > 0)
            {
                return Redirect(Url.Action("NewsConfig", "Home", new { msg = 3 }));
            }
            else
            {
                return Redirect(Url.Action("NewsConfig", "Home", new { msg = 3 }));
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios Users)
        {
            Usuarios List = user.Login(Users.Usuario, Users.Pass);
            if (List != null)
            {
                Session["IdUser"] = List.Id_Usuario;
                Session["IdCompany"] = 0;
                Session["IdUserRol"] = List.Id_Tipo_Usuario;
                Session["Email"] = List.Email;
                Session["Name"] = string.Format("{0} {1}", List.Nombre, List.Apellidos);
                return Redirect("Main");
            }
            else
            {
                ViewBag.image = string.Format("{0}.jpg", UsersHelper.Photo());
                ViewBag.showError = true;
                return Redirect("Index");
            }
        }

        public ActionResult Logout()
        {
            ViewBag.image = string.Format("{0}.jpg", UsersHelper.Photo());
            Session.RemoveAll();
            return View();
        }

        public ActionResult _HeadNavbar()
        {
            int IdUSerRol;
            IdUSerRol = int.Parse(Session["IdUserRol"].ToString());
            var list = menu._Menu(IdUSerRol);
            Random rd = new Random();

            ViewBag.image = string.Format("{0}.jpg", UsersHelper.Photo());
            return PartialView("_HeadNavbar", list);

        }

        public ActionResult _SubNavbar()
        {

            var notify = notification.GetNotifications(int.Parse(Session["IdUser"].ToString()));
            return PartialView("_SubNavbar", notify);

        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, int id = 0)
        {

            try
            {
                HomeHelper home = new HomeHelper();
                NewsFeed n = home.GetNewById(id);

                string archivo = string.Empty;
                string extension = string.Empty;

                if (file == null)
                {
                    return Redirect(Url.Action("NewsConfig", "Home", new { msg = 2 }));
                }

                extension = Path.GetExtension(file.FileName).ToLower();

                if (extension != ".png")
                {
                    if (extension != ".jpg")
                    {
                        if (extension != ".jpeg")
                        {
                            return Redirect(Url.Action("NewsConfig", "Home", new { msg = 1 }));
                        }
                    }
                }

                archivo = "/Calidad/Image/News/Noticia" + n.Orden + "-id-" + n.IdItem + extension;

                n.Imagen = archivo;

                home.UpdateNewsFeed(n);

                
                file.SaveAs(Server.MapPath(archivo));

                return Redirect(Url.Action("NewsConfig", "Home", new { msg = 3 }));
            }
            catch (Exception ex)
            {
                return Redirect(Url.Action("ErrorPage", "Error", new { msg = ex.Message }));
            }

        }


    }
}