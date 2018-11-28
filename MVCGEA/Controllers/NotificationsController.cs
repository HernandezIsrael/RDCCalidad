using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Web.Mvc;

namespace MVCGEA.Controllers
{
    public class NotificationsController : Controller
    {

        /*
	        ---------------------------------------------
	        |                                           |
	        | (icon) [CreadoPor] [Título] [Descripción] |
	        |                                           |
	        ---------------------------------------------
            -------------------------------------------------------------------------
	        |                                                                       |
	        | (cheked) [Israel] [Ha aprobado tu solicitud (tal) como] [aprobada]    |
	        |                                                                       |
	        -------------------------------------------------------------------------

         */

        NotificationHelper notification = new NotificationHelper();

        public void CreateNotification(string title, string desc, string url, int usuarioReceptor, int creadoPor, string icon, bool returnAndUseID = false, int newStatus = 0)
        {
            int error = 0;
            int newID = 0;
            Notifications n = new Notifications();
            n.CreadoPor = creadoPor;
            n.Titulo = title;
            n.Descripcion = desc;
            n.FAlta = DateTime.Now;
            n.Link = url;
            n.Vista = "#";
            n.Controlador = "#";
            n.IdStatus = 2;
            n.EnviadoA = usuarioReceptor;
            n.Icono = icon;
            n.Activo = true;

            if (returnAndUseID)
            {
                error = notification.InsertAndGetNotification(n, out newID);
                n = notification.GetNotification(newID);
                if (newStatus != 0)
                {
                    n.Link = string.Format("{0}&notificationID={1}&newNotificationStatus={2}", n.Link, n.IdNotification, newStatus);
                }
                else
                {
                    n.Link = string.Format("{0}&notificationID={1}", n.Link, n.IdNotification);
                }
            }

            error = notification.InsertNotification(n);

        }

        public void CreateActionNotification(string title, string desc, string vista, string controlador, int usuarioReceptor, int creadoPor, string icon) //Todos las vistas a donde se vayan a direccionar deberán llevar como parámetros opcionales: notificationID = 0 y newNotificationStatus = 0
        {
            int error = 0;
            Notifications n = new Notifications();
            n.CreadoPor = creadoPor;
            n.Titulo = title;
            n.Descripcion = desc;
            n.FAlta = DateTime.Now;
            n.Vista = vista;
            n.Controlador = controlador;
            n.Link = "#";
            n.IdStatus = 2;
            n.EnviadoA = usuarioReceptor;
            n.Icono = icon;
            n.Activo = true;
            error = notification.InsertNotification(n);
        }

        public void ChangeStatus(int notificationID, int newStatus)
        {
            int error = 0;
            Notifications n = new Notifications();
            n = notification.GetNotification(notificationID);
            n.IdStatus = newStatus;
            error = notification.InsertNotification(n);
        }

        public ActionResult Clear(Notifications notify)
        {
            notify.Activo = false;
            notification.ClearNotification(notify);

            return Json(new
            {
                msg = "Successfully cleared"
            });
        }
    }
}