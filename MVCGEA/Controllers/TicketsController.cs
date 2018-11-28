using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class TicketsController : Controller
    {
        TicketsHelper tickets = new TicketsHelper();
        NotificationsController notify = new NotificationsController();

        // GET: Tickets
        public ActionResult LibTickets()
        {
            return View(tickets.ShowTickets(int.Parse(Session["IdUser"].ToString())));
        }

        public ActionResult TicketDetail(int ticketID = 0, int status = 0, int notificationID = 0, int newNotificationStatus = 0)
        {
            ViewBag.TicketID = ticketID;
            ViewBag.comentarios = tickets.GetComentarios(ticketID);
            if (status == 2 && (int.Parse(Session["IdUser"].ToString()) == 3045 || int.Parse(Session["IdUser"].ToString()) == 3030 || int.Parse(Session["IdUser"].ToString()) == 1))
            {
                AlterStatus(ticketID, 5);
            }
            if (status == 1)
            {
                AlterStatus(ticketID, 2);
            }

            if (notificationID != 0)
            {
                notify.ChangeStatus(notificationID, 1);
            }

            if (newNotificationStatus != 0)
            {
                notify.ChangeStatus(notificationID, 1);
            }

            return View(tickets.GetDetails(ticketID));
        }

        public ActionResult CreateNew(int id = 0)
        {
            ViewBag.Empresas = tickets.DataSourceEmpresas();
            ViewBag.Areas = tickets.ListAreas();
            ViewBag.TaskTipos = tickets.ListTaskTipo();
            return View(tickets.GetRawTicket(id));
        }

        public ActionResult AlterStatus(int id, int status)
        {
            int error; //If 0 then error
            TaksAdmon info = tickets.GetRawTicket(id);

            if (info.IdEstatusTaks != 3 && info.IdEstatusTaks != 4) //Cuando el ticket no se ha cerrado aún
            {
                switch (status)
                {
                    case 2:
                        info.IdEstatusTaks = status;
                        break;
                    case 3:
                        info.IdEstatusTaks = status;
                        info.FCierre = DateTime.Now;
                        //notify.CreateNotification(string.Format("ha marcado tu ticket ({0}) como", info.Asunto), "Aprobado", info.IdTaks.ToString(), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "check_circle");
                        notify.CreateNotification(string.Format("ha marcado tu ticket ({0}) como", info.Asunto), "Completado", Url.Action("TicketDetail", "Tickets", new { ticketID = info.IdTaks }), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "check_circle", true);
                        break;
                    case 4:
                        info.IdEstatusTaks = status;
                        info.FCierre = DateTime.Now;
                        //notify.CreateNotification(string.Format("ha marcado tu ticket ({0}) como", info.Asunto), "Rechazado", info.IdTaks.ToString(), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "check_circle");
                        notify.CreateNotification(string.Format("ha marcado tu ticket ({0}) como", info.Asunto), "Cancelado", Url.Action("TicketDetail", "Tickets", new { ticketID = info.IdTaks }), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "check_circle", true);
                        break;
                    case 5:
                        if (info.IdEstatusTaks != 5)
                        {
                            info.IdEstatusTaks = status;
                            //notify.CreateNotification("ha revisado tu ticket ", string.Format("({0})", info.Asunto), info.IdTaks.ToString(), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "cancel");
                            notify.CreateNotification("ha revisado tu ticket ", string.Format("({0})", info.Asunto), Url.Action("TicketDetail", "Tickets", new { ticketID = info.IdTaks }), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "cancel", true);
                        }
                        break;
                }
            }
            else if (status == 3 || status == 4) //Cuando se ha cerrado el ticket, actualizar
            {
                info.IdEstatusTaks = status;
                switch (status)
                {
                    case 3:
                        //notify.CreateNotification(string.Format("ha marcado tu ticket ({0}) como", info.Asunto), "Aprobado", info.IdTaks.ToString(), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "check_circle");
                        notify.CreateNotification(string.Format("ha marcado tu ticket ({0}) como", info.Asunto), "Completado", Url.Action("TicketDetail", "Tickets", new { ticketID = info.IdTaks }), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "check_circle", true);
                        break;
                    case 4:
                        //notify.CreateNotification(string.Format("ha marcado tu ticket ({0}) como", info.Asunto), "Rechazado", info.IdTaks.ToString(), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "cancel");
                        notify.CreateNotification(string.Format("ha marcado tu ticket ({0}) como", info.Asunto), "Cancelado", Url.Action("TicketDetail", "Tickets", new { ticketID = info.IdTaks }), info.Creadopor, int.Parse(Session["IdUser"].ToString()), "cancel", true);
                        break;
                }

                info.FCierre = DateTime.Now;
                info.IdAtencion = int.Parse(Session["IdUser"].ToString());
            }

            error = tickets.ChangeStatus(info); //Cambiamos el estado del ticket

            return Json(new
            {
                msg = "Successfully added "
            });
        }

        public ActionResult EditComentario(int idtask = 0)
        {
            ViewBag.idReceptor = tickets.GetRawTicket(idtask).Id_CA_Area;
            return PartialView(tickets.ObtenerComentario(idtask));
        }

        public ActionResult EditTicket(int id = 0)
        {
            return PartialView(tickets.GetRawTicket(id));
        }

        public ActionResult AddTicket(TaksAdmon ticket)
        {
            int error = 0;
            int newID = 0;
            if (ticket.IdTaksTipo == -1 || ticket.Id_CA_Area == -1 || ticket.IdTaksTipo == -1)
            {
                ViewBag.Empresas = tickets.DataSourceEmpresas();
                ViewBag.Areas = tickets.ListAreas();
                ViewBag.TaskTipos = tickets.ListTaskTipo();
                return View("~/Views/Tickets/CreateNew.cshtml", ticket);
            }

            ticket.IdEstatusTaks = 2;
            ticket.Creadopor = int.Parse(Session["IdUser"].ToString());
            ticket.FAlta = DateTime.Now;
            ticket.Activo = true;
            error = tickets.InsertTicket(ticket, out newID);
            foreach (Usuarios u in tickets.GetUsuariosArea(ticket.Id_CA_Area.Value))
            {
                notify.CreateNotification("ha creado un nuevo ticket: ", ticket.Asunto, Url.Action("TicketDetail", "Tickets", new { ticketID = newID }), u.Id_Usuario, ticket.Creadopor, "receipt", true);
            }
            //notify.CreateNotification("ha creado un nuevo ticket: ", ticket.Asunto, Url.Action("TicketDetail", "Tickets", new { ticketID = newID }), 3045, ticket.Creadopor, "receipt");
            //notify.CreateNotification("ha creado un nuevo ticket: ", ticket.Asunto, Url.Action("TicketDetail", "Tickets", new { ticketID = newID }), 1, ticket.Creadopor, "receipt");
            //notify.CreateNotification("ha creado un nuevo ticket: ", ticket.Asunto, Url.Action("TicketDetail", "Tickets", new { ticketID = newID }), 3030, ticket.Creadopor, "receipt");
            return Redirect(string.Format("TicketDetail?ticketID={0}&status={1}", newID, 1));
        }

        public ActionResult AddComment(TaksComentarios comment, int idE = 0, int idR = 0)
        {
            // idE = idEmisor
            // idR = idReceptor
            int error = 0;
            TaksComentarios c;

            comment.Creadopor = int.Parse(Session["IdUser"].ToString());
            comment.Id_Usuario = int.Parse(Session["IdUser"].ToString());
            comment.FAlta = DateTime.Now;
            comment.Activo = true;
            error = tickets.InsertComment(comment);

            c = tickets.GetComment(comment.IdTaksComentario);

            /*
            //if (comment.Creadopor == 3045 || comment.Creadopor == 3030 || comment.Creadopor == 1)
            //{
            //---notify.CreateNotification(string.Format("ha comentado en el ticket ({0})", c.TaksAdmon.Asunto), string.Format("\"{0}\"", c.Comentario), c.IdTaks.ToString(), c.TaksAdmon.Creadopor, int.Parse(Session["IdUser"].ToString()), "question_answer");
            //notify.CreateNotification(string.Format("ha comentado en el ticket ({0})", c.TaksAdmon.Asunto), string.Format("\"{0}\"", c.Comentario), Url.Action("TicketDetail", "Tickets", new { ticketID = c.IdTaks }), c.TaksAdmon.Creadopor, int.Parse(Session["IdUser"].ToString()), "question_answer", true);
            //}
            //else
            //{
            //---notify.CreateNotification(string.Format("ha comentado en el ticket ({0})", c.TaksAdmon.Asunto), string.Format("\"{0}\"", c.Comentario), c.IdTaks.ToString(), 3045, int.Parse(Session["IdUser"].ToString()), "question_answer");
            //---notify.CreateNotification(string.Format("ha comentado en el ticket ({0})", c.TaksAdmon.Asunto), string.Format("\"{0}\"", c.Comentario), c.IdTaks.ToString(), 3030, int.Parse(Session["IdUser"].ToString()), "question_answer");
            //---notify.CreateNotification(string.Format("ha comentado en el ticket ({0})", c.TaksAdmon.Asunto), string.Format("\"{0}\"", c.Comentario), c.IdTaks.ToString(), 1, int.Parse(Session["IdUser"].ToString()), "question_answer");
            //notify.CreateNotification(string.Format("ha comentado en el ticket ({0})", c.TaksAdmon.Asunto), string.Format("\"{0}\"", c.Comentario), Url.Action("TicketDetail", "Tickets", new { ticketID = c.IdTaks }), 3045, int.Parse(Session["IdUser"].ToString()), "question_answer", true);
            //notify.CreateNotification(string.Format("ha comentado en el ticket ({0})", c.TaksAdmon.Asunto), string.Format("\"{0}\"", c.Comentario), Url.Action("TicketDetail", "Tickets", new { ticketID = c.IdTaks }), 3030, int.Parse(Session["IdUser"].ToString()), "question_answer", true);
            //notify.CreateNotification(string.Format("ha comentado en el ticket ({0})", c.TaksAdmon.Asunto), string.Format("\"{0}\"", c.Comentario), Url.Action("TicketDetail", "Tickets", new { ticketID = c.IdTaks }), 1, int.Parse(Session["IdUser"].ToString()), "question_answer", true);
            //}
            */

            if (c.Usuarios1.Id_Area == c.TaksAdmon.Usuarios.Id_Area) //Si quien comenta es de la misma área que creó el ticket >>> enviar noitificaciones al área que atiende
            {
                foreach (Usuarios u in tickets.GetUsuariosArea(c.TaksAdmon.Id_CA_Area.Value))
                {
                    notify.CreateNotification(string.Format("ha comentado en el ticket ({0})", c.TaksAdmon.Asunto), string.Format("\"{0}\"", c.Comentario), Url.Action("TicketDetail", "Tickets", new { ticketID = c.IdTaks }), u.Id_Usuario, int.Parse(Session["IdUser"].ToString()), "question_answer", true);
                }
            }
            else //si quien comenta es el área que atiende >>> enviar notificaciones al área que solicita ayuda
            {
                foreach (Usuarios u in tickets.GetUsuariosAreaByUser(c.TaksAdmon.Creadopor))
                {
                    notify.CreateNotification(string.Format("ha comentado en el ticket ({0})", c.TaksAdmon.Asunto), string.Format("\"{0}\"", c.Comentario), Url.Action("TicketDetail", "Tickets", new { ticketID = c.IdTaks }), u.Id_Usuario, int.Parse(Session["IdUser"].ToString()), "question_answer", true);
                }
            }
            
            return JavaScript("ShowConfirmation()");

        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, TaksComentarios c, int ticketID = 0)
        {
            TaksDocumentos doc = new TaksDocumentos();
            //c.Comentario = message;
            //TaksAdmon t = tickets.GetRawTicket(ticketID);

            if (ticketID == 0)
            {
                return Redirect(Url.Action("TicketDetail", "Tickets", new { id = ticketID }));
            }

            file.SaveAs(Server.MapPath("~/signalr/Tickets/" + file.FileName));

            doc.IdTaks = ticketID;
            doc.IdTaksTipoDocumento = 1;
            doc.Nombre = file.FileName;
            doc.NombreVirtual = file.FileName;
            doc.Id_Ftp = 1;
            doc.FAlta = DateTime.Now;
            doc.Creadopor = int.Parse(Session["IdUser"].ToString());
            doc.Activo = true;

            tickets.InsertFile(doc);
            //tickets.InsertServicio(t);
            //return Redirect(Url.Action("TicketDetail", "Tickets", new { id = ticketID }));
            return AddComment(c);
        }

    }
}