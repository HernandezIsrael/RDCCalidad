using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Newtonsoft.Json;

namespace MVCGEA.Controllers
{
    public class TravelController : Controller
    {

        TravelHelper travelHelper = new TravelHelper();
        NotificationsController notify = new NotificationsController();

        // GET: Travel
        public ActionResult LibRequest(int notificationID = 0, int newNotificationStatus = 0)
        {
            if(notificationID != 0 && newNotificationStatus !=0)
            {
                switch (newNotificationStatus)
                {
                    case 1:
                        notify.ChangeStatus(notificationID, newNotificationStatus);
                        break;
                }
            }

            return View(travelHelper.GetUserRequest(int.Parse(Session["IdUser"].ToString())));
        }

        public ActionResult NewTravelRequest(int id = 0)
        {
            TrvReq req = new TrvReq();
            req = travelHelper.GetRequest(id);
            ViewBag.Empresas = travelHelper.GetEmpresas();
            ViewBag.Transporte = travelHelper.GetTransporte();
            ViewBag.Turnos = travelHelper.GetTurnos();

            return View(req);
        }

        public ActionResult AddRequest(TrvReq req)
        {
            req.Activo = true;
            req.Creadopor = int.Parse(Session["IdUser"].ToString());
            req.FAlta = DateTime.Now;
            req.IdEstatus = 1;
            travelHelper.InsertRequest(req);

            notify.CreateActionNotification(string.Format("ha creado una solicitud de vijae"), string.Format("({0}, {1})", req.PaisDes, req.Destino), "LibRequest", "Travel", 1, int.Parse(Session["IdUser"].ToString()), "airplanemode_active");
            notify.CreateActionNotification(string.Format("ha creado una solicitud de vijae"), string.Format("({0}, {1})", req.PaisDes, req.Destino), "LibRequest", "Travel", 3045, int.Parse(Session["IdUser"].ToString()), "airplanemode_active");
            notify.CreateActionNotification(string.Format("ha creado una solicitud de vijae"), string.Format("({0}, {1})", req.PaisDes, req.Destino), "LibRequest", "Travel", 14, int.Parse(Session["IdUser"].ToString()), "airplanemode_active");
            notify.CreateActionNotification(string.Format("ha creado una solicitud de vijae"), string.Format("({0}, {1})", req.PaisDes, req.Destino), "LibRequest", "Travel", 3066, int.Parse(Session["IdUser"].ToString()), "airplanemode_active");

            return Redirect(Url.Action("LibRequest","Travel"));
        }

        public ActionResult AddConcepto(TrvRepConceptos concepto)
        {
            concepto.Creadopor = int.Parse(Session["IdUser"].ToString());
            concepto.FAlta = DateTime.Now;
            concepto.Activo = true;
            concepto.IdTrvRepConceptos = 0;
            travelHelper.InsertConcepto(concepto);
            return Redirect(Url.Action("TravelDetail", "Travel", new { reqID = concepto.IdTrvReq }));
        }

        public ActionResult DeleteConcepto(int id = 0)
        {
            TrvRepConceptos c = new TrvRepConceptos();
            c = travelHelper.GetConcepto(id);
            travelHelper.DeleteConcepto(c);
            return Redirect(Url.Action("TravelDetail", "Travel", new { reqID = c.IdTrvReq }));
        }

        public ActionResult TravelDetail(int reqID, int notificationID = 0, int newNotificationStatus = 0)
        {
            ViewBag.Request = travelHelper.GetRequest(reqID);
            ViewBag.Moneda = travelHelper.GetTipoMoneda();
            ViewBag.Conceptos = travelHelper.GetListConceptos(reqID);
            ViewBag.ConceptosList = travelHelper.ListaConceptos();

            if (notificationID != 0 && newNotificationStatus != 0)
            {
                switch (newNotificationStatus)
                {
                    case 1:
                        notify.ChangeStatus(notificationID, newNotificationStatus);
                        break;
                }
            }

            return View(travelHelper.GetConceptos(reqID));
        }

        public ActionResult AlterStatus(int id, int status)
        {
            int error; //If 0 then error

            TrvReq info = travelHelper.GetRawRequest(id);

            info.IdEstatus = status;

            if (status == 3)
            {
                info.Aprobado = true;
                notify.CreateNotification(string.Format("ha aprobado tu solicitud de vijae"), string.Format("({0}, {1})", info.PaisDes, info.Destino), Url.Action("TravelDetail", "Travel", new { reqID = info.IdTrvReq }), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "check_circle", true);
            }

            if (status == 2)
            {
                info.Aprobado = false;
                notify.CreateNotification(string.Format("ha rechazado tu solicitud de vijae"), string.Format("({0}, {1})", info.PaisDes, info.Destino), Url.Action("TravelDetail", "Travel", new { reqID = info.IdTrvReq }), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "cancel", true);
            }

            error = travelHelper.ChangeStatus(info); //Cambiamos el estado del ticket

            return Json(new
            {
                msg = "Successfully added "
            });
        }

        public ActionResult Calendar()
        {
            ViewBag.ListCalendar =JsonConvert.SerializeObject(travelHelper.GetUserRequest2(int.Parse(Session["IdUser"].ToString())), Newtonsoft.Json.Formatting.None);
            return View(travelHelper.GetUserRequest(int.Parse(Session["IdUser"].ToString())));
        }

    }
}