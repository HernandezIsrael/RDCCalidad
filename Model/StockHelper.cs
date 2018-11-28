using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StockHelper
    {
        public List<InvInventario> GetStock()
        {
            List<InvInventario> list = new List<InvInventario>();

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.InvInventario.Include("InvTipo").Include("InvSubTipo").Include("InvUMedida").ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return list;
        }
        public string Renombre() {
            string NV = string.Empty;
            ObjectParameter NVV = new ObjectParameter("Nombre_Virtual", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    context.spSelRenombre_Documento(NVV);
                    if (!string.IsNullOrWhiteSpace(NVV.Value.ToString()))
                        NV = NVV.Value.ToString();
                }
            }
            catch (Exception ex) {
            }
            return NV;
        }
        public IEnumerable<InvInventario> GetPapeleria()
        {
            List<InvInventario> list = new List<InvInventario>();
            InvInventario item = new InvInventario();
            item.IdInventario = -1;
            item.Item = "* Selecciona el item que deseas solicitar";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.InvInventario.Where(x => x.IdTipo == 2).OrderBy(x => x.Item).ToList();
                    list.Add(item);
                }
            }
            catch(Exception ex)
            {

            }

            return list;
        }

        public InvSolicitud GetRawPedido(int id = 0)
        {
            InvSolicitud s = new InvSolicitud();

            if (id == 0)
            {
                s.IdInventario = -1;
                s.Descripcion = "Empty";
                return s;
            }

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    s = context.InvSolicitud.Where(x => x.IdSolicitud == id).SingleOrDefault();
                }
            }
            catch(Exception ex)
            {

            }
            return s;
        }

        public InvInventario GetRawItem(int id = 0)
        {
            InvInventario i = new InvInventario();

            if (id == 0)
            {
                i.IdInventario = -1;
                i.IdTipo = -1;
                i.IdSubTipo = -1;
                i.IdUnidadMedida = -1;
                return i;
            }
            else
            {
                try
                {
                    using (ClusmextContext context = new ClusmextContext())
                    {
                        i = context.InvInventario.Where(x => x.IdInventario == id).SingleOrDefault();
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return i;

        }

        public InvInventario GetItem(int id)
        {
            InvInventario i = new InvInventario();

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    i = context.InvInventario.Include("InvTipo").Include("InvSubtipo").Include("InvUMedida").Where(x => x.IdInventario == id).SingleOrDefault();
                }
            }catch(Exception ex)
            {

            }
            return i;
        }

        public int InsertItem(InvInventario i, out int newID)
        {
            int val = 0;
            newID = -1;

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (i.IdInventario > 0)
                    {
                        context.Entry(i).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(i).State = EntityState.Added;
                    }

                    val = context.SaveChanges();

                    newID = i.IdInventario;
                }
            }
            catch(Exception ex)
            {

            }

            return val;

        }

        public IEnumerable<InvTipo> GetInvTipo()
        {
            List<InvTipo> list = new List<InvTipo>();
            InvTipo item = new InvTipo();

            item.IdTipo = -1;
            item.Descripcion = "* Seleccionar categoría de producto";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.InvTipo.ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public IEnumerable<InvSubTipo> GetInvSubtipos()
        {
            List<InvSubTipo> list = new List<InvSubTipo>();
            InvSubTipo item = new InvSubTipo();

            item.IdSubTipo = -1;
            item.Descripcion = "* Seleccionar subcategoría de producto";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.InvSubTipo.ToList();
                    list.Add(item);
                }
            }
            catch(Exception ex)
            {

            }

            return list;

        }

        public IEnumerable<InvUMedida> GetInvUMedida()
        {
            List<InvUMedida> list = new List<InvUMedida>();
            InvUMedida item = new InvUMedida();

            item.IdUnidadMedida = -1;
            item.UnidadMedida = "* Seleccionar unidad de medida de producto";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.InvUMedida.ToList();
                    list.Add(item);
                }
            }
            catch
            {

            }
            return list;
        }

        public IEnumerable<InvInventario> GetOfficeStock()
        {
            List<InvInventario> list = new List<InvInventario>();
            InvInventario item = new InvInventario();
            item.IdInventario = -1;
            item.Item = "* Selecciona el producto que deseas solicitar";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.InvInventario.Include("InvTipo").Include("InvSubTipo").ToList();
                    list.Add(item);
                }
            }
            catch
            {

            }

            return list;
        }

        public List<InvSolicitud> GetSolicitudes(int user = 0)
        {

            List<InvSolicitud> list = new List<InvSolicitud>();
            Usuarios u = new Usuarios();

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (user != 0)
                    {
                        u = GetUserData(user);
                        if (u.Id_Area == 1 || u.Id_Area == 1007)
                        {
                            list = context.InvSolicitud.Include("InvInventario").Include("Usuarios").ToList();
                        }
                        else
                        {
                            list = context.InvSolicitud.Include("InvInventario").Include("Usuarios").Where(x => x.IdUsuarioExpediente == user).ToList();
                        }
                    }
                    else
                    {
                        list = context.InvSolicitud.Include("InvInventario").Include("Usuarios").ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return list;

        }

        public List<InvSolicitud> GetListaPedidos(int id = 0) //Returns a list with the items from a list (id)
        {
            List<InvSolicitud> list = new List<InvSolicitud>();
            InvListaPedidos pedido = new InvListaPedidos();
            InvSolicitud item = new InvSolicitud();
            int j = 0;
            
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.InvSolicitud.Include("InvInventario").Include("InvListaPedidos").Where(x => x.IdListaPedidos == id).ToList();

                    foreach (InvSolicitud i in list)
                    {
                        if (i.Entregado.Value)
                        {
                            pedido = GetListaPedido(id);
                            pedido.Atendido = true;
                            CreateEditList(pedido, out j);
                            return list;
                        }
                    }
                    pedido = GetListaPedido(id);
                    pedido.Atendido = false;
                    CreateEditList(pedido, out j);
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public List<InvListaPedidos> GetUserListas(int user = 0)
        {
            List<InvListaPedidos> list = new List<InvListaPedidos>();
            List<InvSolicitud> solicitudes = new List<InvSolicitud>();
            Usuarios u = new Usuarios();
            int j = 0;
            bool skip = false;

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (user != 0)
                    {
                        u = GetUserData(user);
                        if (u.Id_Area == 1 || u.Id_Area == 1007)
                        {
                            list = context.InvListaPedidos.Include("Usuarios").Include("InvSolicitud").ToList();
                        }
                        else
                        {
                            list = context.InvListaPedidos.Include("Usuarios").Include("InvSolicitud").Where(x => x.CreadoPor == user).ToList();
                        }
                    }
                    else
                    {
                        list = context.InvListaPedidos.Include("Usuarios").Include("InvSolicitud").ToList();
                    }

                    //    //preguntar por los elementos de la lista. y si alguno está entregado, entonces marcar la lista como atendida (hacerlo desde la entrega de un producto)

                    //foreach (InvListaPedidos ilp in list)
                    //{

                    //    solicitudes = GetListaPedidos(ilp.IdListaPedido);

                    //    foreach (InvSolicitud sol in solicitudes)
                    //    {
                    //        if (sol.Entregado.Value)
                    //        {
                    //            ilp.Atendido = true;
                    //            CreateEditList(ilp, out j);
                    //            skip = true;
                    //            break;
                    //        }
                    //    }
                    //    if (!skip)
                    //    {
                    //        ilp.Atendido = false;
                    //        CreateEditList(ilp, out j);
                    //    }

                    //}
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public InvListaPedidos GetListaPedido(int id)
        {
            InvListaPedidos i = new InvListaPedidos();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    i = context.InvListaPedidos.Where(x => x.IdListaPedido == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return i;
        }

        public int CreateEditList(InvListaPedidos list, out int newID)
        {
            int count = 0;

            newID = 0;

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (list.IdListaPedido > 0)
                    {
                        context.Entry(list).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(list).State = EntityState.Added;
                    }

                    count = context.SaveChanges();
                    newID = list.IdListaPedido;
                }
            }
            catch (Exception ex)
            {

            }

            return count;
        }

        public int InsertPedido(InvSolicitud s)
        {
            int count = 0;
            int itemID = 0;
            InvInventario item = new InvInventario();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (s.IdSolicitud > 0)
                    {
                        context.Entry(s).State = EntityState.Modified;
                        //Si algún pedido se entregó, modificamos la cantidad en inventario
                        if (s.Entregado.Value)
                        {
                            item = GetItem(s.IdInventario);
                            item.EnExistencia -= s.Cantidad;
                            item.Dispobibles = item.EnExistencia;
                            InsertItem(item, out itemID);
                        }
                        else
                        {
                            item = GetItem(s.IdInventario);
                            item.EnExistencia += s.Cantidad;
                            item.Dispobibles = item.EnExistencia;
                            InsertItem(item, out itemID);
                        }
                    }
                    else
                    {
                        context.Entry(s).State = EntityState.Added;
                    }

                    count = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

            return count;
        }

        public InvSolicitud GetItemFromList(int id)
        {
            InvSolicitud i = new InvSolicitud();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    i = context.InvSolicitud.Where(x => x.IdSolicitud == id).SingleOrDefault();
                }
            }
            catch(Exception ex)
            {

            }
            return i;
        }

        public int RemoveFromList(InvSolicitud item)
        {
            int count = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.Entry(item).State = EntityState.Deleted;
                    count = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return count;
        }

        public Usuarios GetUserData(int id)
        {
            Usuarios u = new Usuarios();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    u = context.Usuarios.Where(x => x.Id_Usuario == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return u;
        }

        //public bool UserBelongsToArea(int idUser, int idArea, out int belongsToArea)
        //{
        //    bool belongs = false;
        //    belongsToArea = -1;

        //    Usuarios u = new Usuarios();

        //    try
        //    {
        //        using (ClusmextContext context = new ClusmextContext())
        //        {
        //            u = context.Usuarios.Where(x => x.Id_Usuario == idUser).SingleOrDefault();
        //            belongsToArea = u.Id_Area.Value;
        //            if (u.Id_Area == idArea)
        //            {
        //                belongs = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return belongs;
        //}
    }
}
