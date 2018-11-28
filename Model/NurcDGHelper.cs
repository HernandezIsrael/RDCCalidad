using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Model
{
   public class NurcDGHelper
    {
        public List<spSelPagos_Autorizacion_DG_Result> ListPagosEgresos(int id) {
            List<spSelPagos_Autorizacion_DG_Result> Items = new List<spSelPagos_Autorizacion_DG_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    Items = context.spSelPagos_Autorizacion_DG(id).OrderByDescending(x=> x.Id_Pago).ToList();
                }
            }
            catch (Exception ex) {
            }
            return Items;
        }
        public Pagos ObtenerNurc(int id) {
            Pagos item = new Pagos();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.Pagos.Where(x=> x.Id_Pago==id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }

        public List<BBanco> ListBancos(int id,int idmoneda) {
            List<BBanco> item = new List<BBanco>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.spSelBancos_Empresa_V2(id, idmoneda)
                        .Select(x => new BBanco { Id = x.Id_Banco.Value, Banco = x.Banco }).ToList();  
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public List<BCuenta> ListCuenta(int id, int idbanco, int idmoneda)
        {
            List<BCuenta> item = new List<BCuenta>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    item = context.spSelNCuenta_Banco_Empresa_V2( idbanco, id, idmoneda)
                        .Select(x => new BCuenta { Id = x.Id_N_Cuenta, NC = x.N_Cuenta }).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return item;
        }
        public List<BClabe> ListClabe(int id,int idbanco, int idmoneda)
        {
            List<BClabe> item = new List<BClabe>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    item = context.spSelClabe_Banco_Empresa_V2(idbanco, id, idmoneda)
                        .Select(x => new BClabe { Id = x.Id_Clabe, CB = x.N_Clabe }).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return item;
        }

        public List<Socio> ListCS() {
            List<Socio> list = new List<Socio>();
            Socio item = new Socio();
            item.Id =- 1;
            item.CS = "Selccionar..";
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.Ca_CS.Where(x => x.Activo == true).OrderBy(x => x.CS)
                        .Select(x => new Socio { Id = x.Id_CS, CS = x.CS.ToString() }).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex) {
            } 
            return list;
        }
        public int GuardarCS(int IdPago,int IdCS1,int IdCS2) {
            int val = 0;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    context.spPupNurcCs(IdPago, IdCS1, IdCS2, 0, 0, 0, VV, VM);
                    if (VV.Value.ToString() == "0")
                        val = 1;
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        public int GuardarCompleto(Pagos Item) {
            int val = 0;
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    context.Entry(Item).State = EntityState.Modified;
                    val = context.SaveChanges();
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        public int Guardar(int IdPago, int IdUser)
        {
            int val = 0;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spPupAutoDGeneral(IdPago,IdUser,VV,VM);
                    if (VV.Value.ToString() == "0")
                        val = 1;
                }
            }
            catch (Exception ex)
            {
            }
            return val;
        }
        public int Cancelar(int IdPago,int IdUser,string Comentario ) {
            int val = 0;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    context.spPupAutorizaciones_Pago(IdPago, 4, Comentario, IdUser, false, VV, VM);
                    if (VV.Value.ToString() == "0")
                        val = 1;
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
    }
    public class Socio {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string cs;
        public string CS
        {
            get { return cs; }
            set { cs = value; }
        }
    }
    public class BCuenta
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nc;
        public string NC
        {
            get { return nc; }
            set { nc = value; }
        }
    }
    public class BClabe
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string cb;
        public string CB
        {
            get { return cb; }
            set { cb = value; }
        }
    }
    public class BBanco
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string banco;
        public string Banco
        {
            get { return banco; }
            set { banco = value; }
        }
    }
}
