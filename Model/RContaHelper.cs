using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Model
{
   public class RContaHelper
    {
        public List<spSelRConta_Result> ListConta() {
            List<spSelRConta_Result> list = new List<spSelRConta_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSelRConta().ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public RConta ObtenerRconta(int id) {
            RConta item = new RConta();
            try {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.RConta.Where(x => x.IdRConta == id).SingleOrDefault();
                }
            } catch (Exception ex) {
            }
            return item;
        }
        public IEnumerable<TiposConta> DatatSourceTipoConta()
        {
            List<TiposConta> items = new List<TiposConta>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.CaTipoRConta.Where(x=> x.Activo==true)
                        .Select(x => new TiposConta { Id = x.IdTipoRConta, NombreCompleto = x.TipoRConta }).OrderBy(x => x.NombreCompleto).ToList();
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
                    items = context.Empresas.Where(x=> x.Activo==true)
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
        public IEnumerable<TSolicitado> DatatSourceUsConta()
        {
            List<TSolicitado> items = new List<TSolicitado>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.spSelUsuariosConta()
                        .Select(x => new TSolicitado { Id = x.Id_Usuario, NombreCompleto = x.Nombre }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public List<spSelDocumentosConta_Result> ListDocumentos(int id) {
            List<spSelDocumentosConta_Result> list = new List<spSelDocumentosConta_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSelDocumentosConta(id).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public int Guardar(RConta item) {
            int Val = 0;
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.IdRConta > 0)
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
        public bool spInsDocumentosRConta(int id,string Nombre,int IdUser,int IdTipo,out string NVV) {
            bool Val = false;
            NVV = string.Empty;
            ObjectParameter NV = new ObjectParameter("Nombre_Virtual", typeof(String));
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter IDD = new ObjectParameter("IdDocumentoRConta", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try  {
                using (ClusmextContext context = new ClusmextContext()) {
                    context.spInsDocumentosRConta(Nombre, 1, IdUser, id, IdTipo, NV, IDD, VV, VM);
                    if (VV.Value.ToString() == "0")
                    {
                        NVV = NV.Value.ToString();
                        Val = true;
                    }
                }
            }
            catch (Exception ex) {
            }
            return Val;
        }


    }
}
public class TiposConta
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
public class EmpConta
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
