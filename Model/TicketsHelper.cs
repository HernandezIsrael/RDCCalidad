using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TicketsHelper
    {

        public List<TaksAdmon> ShowTickets(int userID)
        {
            List<TaksAdmon> list = new List<TaksAdmon>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (userID == 3045 || userID == 3030 || userID == 1)
                    {
                        list = context.TaksAdmon.Include("Empresas").Include("Usuarios").Include("CA_Areas").Include("TaksEstatus").Include("TaksTipo").Include("TaksPertenencia").OrderByDescending(x => x.IdTaks).ToList();
                    }
                    else
                    {
                        list = context.TaksAdmon.Include("Empresas").Include("Usuarios").Include("Usuarios1").Include("CA_Areas").Include("TaksEstatus").Include("TaksTipo").Include("TaksPertenencia").Where(x => x.Creadopor == userID).OrderByDescending(x => x.IdTaks).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public TaksAdmon GetDetails(int id)
        {
            TaksAdmon list = new TaksAdmon();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.TaksAdmon.Include("Empresas").Include("Usuarios").Include("CA_Areas").Include("TaksEstatus").Include("TaksTipo").Include("TaksPertenencia").Include("TaksComentarios").Where(x => x.IdTaks == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public TaksAdmon GetRawTicket(int id)
        {
            TaksAdmon ticket = new TaksAdmon();
            try
            {
                if (id == 0)
                {
                    ticket.Id_Empresa = -1;
                    ticket.IdTaksTipo = -1;
                    ticket.Id_CA_Area = -1;
                    return ticket;
                }
                using (ClusmextContext context = new ClusmextContext())
                {
                    ticket = context.TaksAdmon.Where(x => x.IdTaks == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return ticket;
        }

        public int InsertTicket(TaksAdmon ticket, out int newID)
        {
            int val = 0;
            newID = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (ticket.IdTaks > 0)
                    {
                        context.Entry(ticket).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(ticket).State = EntityState.Added;
                    }

                    val = context.SaveChanges();
                    if (val != 0)
                        newID = ticket.IdTaks;
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public TaksComentarios ObtenerComentario(int IdTask)
        {
            TaksComentarios item = new TaksComentarios();
            item.IdTaksComentario = 0;
            item.IdTaks = IdTask;
            return item;
        }

        public int ChangeStatus(TaksAdmon ticket)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.Entry(ticket).State = EntityState.Modified;
                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public TaksComentarios GetComment(int id)
        {
            TaksComentarios c = new TaksComentarios();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    c = context.TaksComentarios.Include("TaksAdmon").Where(x => x.IdTaksComentario == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return c;
        }

        public List<TaksComentarios> GetComentarios(int id)
        {
            List<TaksComentarios> list = new List<TaksComentarios>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.TaksComentarios.Include("Usuarios").Where(x => x.IdTaks == id).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public int InsertComment(TaksComentarios comment)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (comment.IdTaksComentario > 0)
                    {
                        context.Entry(comment).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(comment).State = EntityState.Added;
                    }

                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public IEnumerable<Empresas> DataSourceEmpresas() //Usamos IENumerable para usar los combo box
        {
            List<Empresas> list = new List<Empresas>();
            Empresas item = new Empresas();
            item.Id_Empresa = -1;
            item.Razon_Social = "* Empresa que solicita";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Empresas.Where(x => x.Id_Empresa != -1 && x.Id_Tipo_Empresa == 1).OrderBy(x => x.Razon_Social).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<CA_Areas> ListAreas()
        {
            List<CA_Areas> list = new List<CA_Areas>();
            CA_Areas item = new CA_Areas();
            item.Id_CA_Area = -1;
            item.Nombre_Area = "* Área a la que se dirige el ticket";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.CA_Areas.OrderBy(x => x.Nombre_Area).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<TaksTipo> ListTaskTipo()
        {
            List<TaksTipo> list = new List<TaksTipo>();
            TaksTipo item = new TaksTipo();
            item.IdTaksTipo = -1;
            item.TaksTipo1 = "* Tipo de solicitud";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.TaksTipo.OrderBy(x => x.TaksTipo1).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public int InsertFile(TaksDocumentos doc)
        {
            //Usamos el stored procedure
            int val = 0;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            ObjectParameter nombreVirtual = new ObjectParameter("Nombre_Virtual", typeof(String));
            ObjectParameter idDocumento = new ObjectParameter("Id_Documento", typeof(Int32));
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spInsDoctosTask(doc.Nombre, doc.Id_Ftp, doc.Creadopor, doc.IdTaks, doc.IdTaksDocumento, nombreVirtual, idDocumento, VV, VM);
                    if (VV.Value.ToString() == "0")
                        val = 1;
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public List<Usuarios> GetUsuariosArea(int idArea = 0)
        {

            List<Usuarios> list = new List<Usuarios>();

            if (idArea == 0)
            {
                return null;
            }

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Usuarios.Where(x => x.Id_Area == idArea).ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return list;
        }

        public List<Usuarios> GetUsuariosAreaByUser(int idUsuario = 0)
        {

            List<Usuarios> list = new List<Usuarios>();
            Usuarios u = new Usuarios();
            int idArea = 0;

            if (idUsuario == 0)
            {
                return null;
            }

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    u = context.Usuarios.Where(x => x.Id_Usuario == idUsuario).SingleOrDefault();
                    idArea = u.Id_Area.Value;
                    list = context.Usuarios.Where(x => x.Id_Area == idArea).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

    }
}
