using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Model
{
   public class PlancioHelper
    {
        public List<spSelRPlancio_Result> ListPlancio() {
            List<spSelRPlancio_Result> list = new List<spSelRPlancio_Result>();
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    list = context.spSelRPlancio().ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public RPlancio ObtenerPlancio(int id) {
            RPlancio item = new RPlancio();
            try{
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.RPlancio.Where(x => x.IdRPlancio == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }


        public IEnumerable<TiposPlan> DatatSourceTipoPlan()
        {
            List<TiposPlan> items = new List<TiposPlan>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.CaTipoRPlancio.Where(x => x.Activo == true)
                        .Select(x => new TiposPlan { Id = x.IdTipoRPlancio, NombreCompleto = x.TipoRPlancio }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public IEnumerable<EmpConta> DatatSourceEmpresas()
        {
            List<EmpConta> items = new List<EmpConta>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.Empresas.Where(x => x.Activo == true)
                        .Select(x => new EmpConta { Id = x.Id_Empresa, NombreCompleto = x.Razon_Social }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public IEnumerable<TProyectos> DatatSourceProyectos(int id)
        {
            List<TProyectos> items = new List<TProyectos>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.spSelProyectos_Empresas(id).Where(x => x.Activo == true)
                        .Select(x => new TProyectos { Id = x.Id_Proyecto, NombreCompleto = x.Proyecto }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public IEnumerable<TSolicitado> DatatSourceSolicitado()
        {
            List<TSolicitado> items = new List<TSolicitado>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.Ca_Solicitado_por.Where(x => x.Activo == true)
                        .Select(x => new TSolicitado { Id = x.Id_Solicitado_por, NombreCompleto = x.Solicitado_por }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public IEnumerable<TSolicitado> DatatSourceUsPlan()
        {
            List<TSolicitado> items = new List<TSolicitado>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.spSelVUsuariosPlaneacion()
                        .Select(x => new TSolicitado { Id = x.Id_Usuario, NombreCompleto = x.Nombre }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public List<spSelDocumentosRPlancio_Result> ListDocumentos(int id)
        {
            List<spSelDocumentosRPlancio_Result> list = new List<spSelDocumentosRPlancio_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelDocumentosRPlancio(id).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public int Guardar(RPlancio item)
        {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (item.IdRPlancio > 0)
                        context.Entry(item).State = EntityState.Modified;
                    else
                        context.Entry(item).State = EntityState.Added;
                    Val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return Val;
        }
        public bool spInsDocumentosPlan(int id, string Nombre, int IdUser, int IdTipo, out string NVV)
        {
            bool Val = false;
            NVV = string.Empty;
            ObjectParameter NV = new ObjectParameter("Nombre_Virtual", typeof(String));
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter IDD = new ObjectParameter("Id_Documento", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spInsDocumentoRPlancio(Nombre, 1, IdUser, id, IdTipo, NV, IDD, VV, VM);
                    if (VV.Value.ToString() == "0")
                    {
                        NVV = NV.Value.ToString();
                        Val = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Val;
        }
    }
}
public class TiposPlan
{
    private int id;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    private string nombrecompleto;
    public string NombreCompleto
    {
        get { return nombrecompleto; }
        set { nombrecompleto = value; }
    }
}