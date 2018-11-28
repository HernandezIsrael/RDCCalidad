using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
namespace Model
{
   public class RVinculacionesHelper
    {
        public List<spSelRVinculaciones_Result> ListVinculaciones() {
            List<spSelRVinculaciones_Result> list = new List<spSelRVinculaciones_Result>();
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSelRVinculaciones().ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public RVinculaciones ObtenerVinculacion(int id) {
            RVinculaciones item = new RVinculaciones();
            try {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.RVinculaciones.Where(x => x.IdRVinculaciones == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }


        public IEnumerable<TiposVin> DatatSourceTipoVin()
        {
            List<TiposVin> items = new List<TiposVin>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.CaTipoRVinculaciones.Where(x => x.Activo == true)
                        .Select(x => new TiposVin { Id = x.IdTipoRVinculaciones, NombreCompleto = x.TipoRVinculaciones }).OrderBy(x => x.NombreCompleto).ToList();
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
        public IEnumerable<TSolicitado> DatatSourceUsVin()
        {
            List<TSolicitado> items = new List<TSolicitado>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.spSelUsuariosVinculaciones()
                        .Select(x => new TSolicitado { Id = x.Id_Usuario, NombreCompleto = x.Nombre }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public List<spSelDocumentosVinculaciones_Result> ListDocumentos(int id)
        {
            List<spSelDocumentosVinculaciones_Result> list = new List<spSelDocumentosVinculaciones_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelDocumentosVinculaciones(id).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public int Guardar(RVinculaciones item)
        {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (item.IdRVinculaciones > 0)
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
        public bool spInsDocumentosRVincu(int id, string Nombre, int IdUser, int IdTipo, out string NVV)
        {
            bool Val = false;
            NVV = string.Empty;
            ObjectParameter NV = new ObjectParameter("Nombre_Virtual", typeof(String));
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter IDD = new ObjectParameter("IdDocumentoRVinculaciones", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spInsDocumentosRVincu(Nombre, 1, IdUser, id, IdTipo, NV, IDD, VV, VM);
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
public class TiposVin
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
