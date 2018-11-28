using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCGEA.Controllers
{
    public class StockController : Controller
    {

        StockHelper stock = new StockHelper();
        FTPHelper ftp = new FTPHelper();
        RRRHHHelper rrhh = new RRRHHHelper();

        public ActionResult LibReqsPapeleria()
        {
            int area = stock.GetUserData(int.Parse(Session["IdUser"].ToString())).Id_Area.Value;

            ViewBag.Permission = false;

            if (area == 1 || area == 1007)
            {
                ViewBag.Permission = true;
            }

            ViewBag.User = stock.GetUserData(int.Parse(Session["IdUser"].ToString()));
            ViewBag.Listas = stock.GetUserListas(int.Parse(Session["IdUser"].ToString())); //ListaPedidos
            return View(stock.GetSolicitudes(int.Parse(Session["IdUser"].ToString()))); //InvSolicitud
        }

        public ActionResult RequestDetails(int id = 0 /*id de la lista de pedidos*/, int error = 0)
        {
            int area = stock.GetUserData(int.Parse(Session["IdUser"].ToString())).Id_Area.Value;

            ViewBag.ID = id; //Id de la lista
            ViewBag.Papeleria = stock.GetPapeleria();
            ViewBag.Lista = stock.GetListaPedidos(id); //InvSolicitud
            ViewBag.Error = 0;
            ViewBag.ErrorMsg = string.Empty;
            ViewBag.ListInfo = stock.GetListaPedido(id);

            ViewBag.Permission = false;

            if (area == 1 || area == 1007)
            {
                ViewBag.Permission = true;
            }

            switch (error)
            {
                case 1:
                    ViewBag.Error = 1;
                    ViewBag.ErrorMsg = "Verifica que no haya campos obligatorios incompletos o incorrectos";
                    break;

            }

            return View(stock.GetRawPedido(/*id*/));
        }

        public ActionResult EditReqInfo(InvSolicitud s, int idLista = 0 /*Id de la lista*/) //Para crear o editar las listas de solicitudes
        {

            InvListaPedidos list = new InvListaPedidos();
            List<InvSolicitud> pedidos = new List<InvSolicitud>();

            if (idLista == 0)
            {
                //Creamos la lista antes de agregar los items a la misma
                list.Activo = true;
                list.CreadoPor = int.Parse(Session["IdUser"].ToString());
                list.Descripcion = String.Format("Solicitud creada por: {0}", int.Parse(Session["IdUser"].ToString()));
                list.FAlta = DateTime.Now;
                stock.CreateEditList(list, out idLista);
            }

            InvInventario item = new InvInventario();
            item = stock.GetItem(s.IdInventario);
            s.Descripcion = string.Format("{0}, {1}", item.Item, item.Descripcion);
            s.Devuelto = false;
            s.Entregado = false;
            s.Estatus = 1;
            s.FechaSolicitud = DateTime.Now;            
            s.IdListaPedidos = idLista;
            s.IdUsuarioExpediente = int.Parse(Session["IdUser"].ToString());
            s.NoDisponible = false;

            stock.InsertPedido(s);

            return Redirect(Url.Action("RequestDetails", "Stock", new { id = idLista }));

        }

        public ActionResult Stock()
        {
            return View(stock.GetStock());
        }

        public ActionResult ItemDetail(int id = 0, int error = 0)
        {
            ViewBag.InvTipos = stock.GetInvTipo();
            ViewBag.InvSubtipos = stock.GetInvSubtipos();
            ViewBag.InvUMedida = stock.GetInvUMedida();
            ViewBag.ImageError = string.Empty;
            ViewBag.Error = 0;

            if (error != 0)
            {
                switch (error)
                {
                    case 1:
                        ViewBag.Error = 1;
                        ViewBag.ImageError = "La imagen seleccionada no cumple con el formato requerido. Por favor selecciona archivos cuyo formato sea JPG o PNG";
                        break;
                    case 2:
                        ViewBag.Error = 1;
                        ViewBag.ImageError = "No has seleccionado ninguna imagen";
                        break;
                    case 3:
                        ViewBag.Error = 1;
                        ViewBag.ImageError = "Verifica que no haya campos obligatorios incompletos";
                        break;
                }
            }

            return View(stock.GetRawItem(id));
        }

        public ActionResult EdittItemInfo(InvInventario i)
        {

            int newID = 0;            

            i.Activo = true;
            i.CreadoPor = int.Parse(Session["IdUser"].ToString());
            i.FAlta = DateTime.Now;
            i.EnExistencia = i.Dispobibles;

            if (i.InvMin < 0)
            {
                i.InvMin = 0;
            }

            if (i.IdInventario > 0)
            {
                i.Imagen = stock.GetRawItem(i.IdInventario).Imagen;
            }

            if (i.IdTipo == -1 || i.IdSubTipo == -1 || i.IdUnidadMedida == -1 )
            {
                if (i.IdInventario > 0)
                {
                    return Redirect(Url.Action("ItemDetail", "Stock", new { id = i.IdInventario, error = 3 }));
                }
                else
                {
                    return Redirect(Url.Action("ItemDetail", "Stock", new { error = 3 }));
                }
            }

            stock.InsertItem(i, out newID);

            return Redirect(Url.Action("ItemDetail","Stock", new { id = newID }));
        }

        public ActionResult RemoveFromList(int reqID, int itemID)
        {
            stock.RemoveFromList(stock.GetItemFromList(itemID));
            return Redirect(Url.Action("RequestDetails", "Stock", new { id = reqID }));
        }

        public ActionResult MarkAs(int itemID, bool entregado, int listID = 0)
        {
            InvSolicitud s = new InvSolicitud();
            InvListaPedidos list = new InvListaPedidos();
            List<InvSolicitud> listItemns = new List<InvSolicitud>();
            int outVal = 0;
            bool delivered = false;

            s = stock.GetRawPedido(itemID);
            s.Entregado = entregado;
            stock.InsertPedido(s);

            list = stock.GetListaPedido(s.IdListaPedidos.Value); //Gets the list 

            listItemns = stock.GetListaPedidos(list.IdListaPedido); //Gets the items of the list

            foreach(InvSolicitud i in listItemns) //Ask for the items in the list if one of those ware delivered
            {
                if (i.Entregado.Value)
                {
                    delivered = true;   //If at least one element of the list was delivered this is true
                }
            }

            list.Atendido = delivered;

            stock.CreateEditList(list, out outVal); //Save the list

            if (listID == 0)
                return Redirect(Url.Action("LibReqsPapeleria"));
            else
                return Redirect(Url.Action("RequestDetails", new { id = listID }));
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, int InvId = 0)
        {

            try
            {
                InvInventario i = stock.GetRawItem(InvId);

                int newID = 0;
                string archivo = string.Empty;
                string extension = Path.GetExtension(file.FileName).ToLower();

                if (extension != ".png")
                {
                    if (extension != ".jpg")
                    {
                        if (extension != ".jpeg")
                        {
                            return Redirect(Url.Action("ItemDetail", "Stock", new { id = InvId, error = 1 }));
                        }
                    }
                }

                if (file == null)
                {
                    return Redirect(Url.Action("ItemDetail", "Stock", new { id = InvId, error = 2 }));
                }

                archivo = (InvId.ToString() + Path.GetExtension(file.FileName)).ToLower();
                //archivo = "/signalr/Stock/" + archivo;
                archivo = "/Image/Stock/" + archivo;

                i.Imagen = archivo;

                stock.InsertItem(i, out newID);
                file.SaveAs(Server.MapPath(archivo));


                return Redirect(Url.Action("ItemDetail", "Stock", new { id = InvId }));
            }
            catch(Exception ex)
            {
                return Redirect(Url.Action("ErrorPage", "Error", new { msg = ex.Message }));
            }

        }

    }
}