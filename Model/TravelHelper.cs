using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TravelHelper
    {
        public int InsertRequest(TrvReq req)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (req.IdTrvReq > 0)
                    {
                        context.Entry(req).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(req).State = EntityState.Added;
                    }

                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public List<TrvReq> GetUserRequest(int userID)
        {
            List<TrvReq> list = new List<TrvReq>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (userID == 3045 || userID == 3030 || userID == 1 || userID == 14 || userID == 3066)
                    {
                        list = context.TrvReq.Include("Empresas").Include("Usuarios").Include("TrvTransporte").Include("TrvTurno").Include("TrvEstatus").OrderByDescending(x => x.IdTrvReq).ToList();
                    }
                    else
                    {
                        list = context.TrvReq.Include("Empresas").Include("Usuarios").Include("TrvTransporte").Include("TrvTurno").Include("TrvEstatus").Where(x => x.Creadopor == userID).OrderByDescending(x => x.IdTrvReq).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public List<Calendarioj> GetUserRequest2(int userID)
        {
            List<Calendarioj> list = new List<Calendarioj>();
            string[] colors = new string[] { "event-azure", "event-rose", "event-orange", "event-green" };
            string color = colors[new Random().Next(0, colors.Length)];
            int i = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (userID == 3045 || userID == 3030 || userID == 1 || userID == 14 || userID == 3066)
                    {
                        list = context.TrvReq.Include("Empresas").Include("Usuarios").Include("TrvTransporte").Include("TrvTurno").Include("TrvEstatus").OrderByDescending(x => x.IdTrvReq)
                            .Select(x => new Calendarioj { title = x.Usuarios.Nombre + x.Usuarios.Apellidos + x.PaisDes + x.Destino, start = x.FPartida, end = x.FRetorno, className = "" }).ToList();
                    }
                    else
                    {
                        list = context.TrvReq.Include("Empresas").Include("Usuarios").Include("TrvTransporte").Include("TrvTurno").Include("TrvEstatus").Where(x => x.Creadopor == userID).OrderByDescending(x => x.IdTrvReq)
                           .Select(x => new Calendarioj { title = x.Usuarios.Nombre + x.Usuarios.Apellidos + x.PaisDes + x.Destino, start = x.FPartida, end = x.FRetorno, className = "" }).ToList();
                    }
                    foreach (Calendarioj item in list) {
                        color = string.Empty;
                        color = colors[i];
                        item.className = color;
                        i++;
                        if (i == 4)
                            i = 0;
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public TrvReq GetRequest(int id = 0)
        {
            TrvReq req = new TrvReq();
            try
            {
                if (id == 0)
                {                    
                    req.IdTrvReq = 0;
                    req.Id_Empresa = -1;
                    req.IdTransporte = -1;
                    req.IdTrvTurno = -1;
                    return req;
                }
                else
                {
                    using (ClusmextContext context = new ClusmextContext())
                    {
                        req = context.TrvReq.Include("TrvTransporte").Include("TrvTurno").Include("Empresas").Where(x => x.IdTrvReq == id).SingleOrDefault();
                        req.FPartida = req.FPartida.Date;
                        req.FRetorno = req.FRetorno.Date;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return req;
        }

        public TrvReq GetRawRequest(int id)
        {
            TrvReq req = new TrvReq();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    req = context.TrvReq.Where(x => x.IdTrvReq == id).SingleOrDefault();
                    req.FPartida = req.FPartida.Date;
                    req.FRetorno = req.FRetorno.Date;
                }
            }
            catch (Exception ex)
            {

            }
            return req;
        }

        public IEnumerable<Empresas> GetEmpresas() //Usamos IENumerable para usar los combo box
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

        public IEnumerable<TrvTransporte> GetTransporte()
        {
            List<TrvTransporte> list = new List<TrvTransporte>();
            TrvTransporte item = new TrvTransporte();
            item.IdTransporte = -1;
            item.Transporte = "* Principal medio de transporte";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.TrvTransporte.Where(x => x.IdTransporte != -1).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<TrvTurno> GetTurnos()
        {
            List<TrvTurno> list = new List<TrvTurno>();
            TrvTurno item = new TrvTurno();
            item.IdTrvTurno = -1;
            item.Turno = "* Turno de preferencia";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.TrvTurno.Where(x => x.IdTrvTurno != -1).ToList();
                    list.Add(item);
                }
            }
            catch(Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<Ca_Moneda> GetTipoMoneda()
        {
            List<Ca_Moneda> list = new List<Ca_Moneda>();
            Ca_Moneda item = new Ca_Moneda();
            item.Id_Moneda = -1;
            item.Moneda = "* Selecciona una divisa";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Moneda.Where(x => x.Id_Moneda != -1).ToList();
                    list.Add(item);
                }
            }
            catch(Exception ex)
            {

            }
            return list;
        }

        public TrvRepConceptos GetConceptos(int travelId = 0)
        {
            TrvRepConceptos c = new TrvRepConceptos();
            try
            {
                if (travelId == 0)
                {
                    c.Id_Moneda = 1;
                    c.IdTrvReq = -1;
                    return c;
                }
                else
                {
                    using (ClusmextContext context = new ClusmextContext())
                    {
                        c = context.TrvRepConceptos.Where(x => x.IdTrvReq == travelId).SingleOrDefault();
                        if (c == null)
                        {
                            c = new TrvRepConceptos();
                            c.IdTrvConceptos = -1;
                            c.Monto = 0;
                            c.Creadopor = -1;
                            c.Id_Moneda = 1;
                            c.IdTrvReq = -1;
                            return c;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return c;
        }

        public IEnumerable<TrvConceptos> ListaConceptos()
        {
            List<TrvConceptos> c = new List<TrvConceptos>();
            TrvConceptos item = new TrvConceptos();
            item.IdTrvConceptos = -1;
            item.Conceptos = "* Seleccionar concepto";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    c = context.TrvConceptos.Take(7).ToList();
                    c.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return c;
        }

        public List<TrvRepConceptos> GetListConceptos(int travelId = 0)
        {
            List<TrvRepConceptos> c = new List<TrvRepConceptos>();
            //TrvRepConceptos item = new TrvRepConceptos();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    c = context.TrvRepConceptos.Include("Ca_Moneda").Where(x => x.IdTrvReq == travelId).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return c;
        }

        public int InsertConcepto(TrvRepConceptos concepto)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (concepto.IdTrvRepConceptos > 0)
                    {
                        context.Entry(concepto).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(concepto).State = EntityState.Added;
                    }

                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public TrvRepConceptos GetConcepto(int ID)
        {
            TrvRepConceptos c = new TrvRepConceptos();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    c = context.TrvRepConceptos.Include("Ca_Moneda").Where(x => x.IdTrvRepConceptos == ID).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return c;
        }

        public int DeleteConcepto(TrvRepConceptos concepto)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.Entry(concepto).State = EntityState.Deleted;
                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public int ChangeStatus(TrvReq ticket)
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

        public List<TrvReq> GetListTrvReq()
        {
            List<TrvReq> list = new List<TrvReq>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.TrvReq.OrderByDescending(x => x.IdTrvReq).ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return list;
        }

    }
    public class Calendarioj {
        private string Title;
        public string title {
            get { return Title; }
            set { Title = value; }
        }
        private DateTime Start;
        public DateTime start {
            get { return Start; }
            set { Start = value; }
        }
        private DateTime End;
        public DateTime end {
            get { return End; }
            set { End = value; }
        }
        private string ClassName;
        public string className {
            get { return ClassName; }
            set { ClassName = value; }
        }
    }
}
