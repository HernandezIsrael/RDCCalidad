using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class CuccHelper
    {
        public List<spSelV_Contratos_Result> ListCucc() {
            List<spSelV_Contratos_Result> list = new List<spSelV_Contratos_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSelV_Contratos().ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Contratos ObtenerContrato(int id) {
            Contratos item = new Contratos();
            try
            {
                if (id <= 0)
                    return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.Contratos.Where(x => x.Id_Contrato == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public int Guardar(Contratos item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.Id_Contrato > 0)
                        context.Entry(item).State = EntityState.Modified;
                    else
                        context.Entry(item).State = EntityState.Added;
                    Val = context.SaveChanges();
                }
            }
            catch (Exception ex) {

            }
            return Val;
        }
        public IEnumerable<TContratos> DataSourceTipoContratos() {
            List<TContratos> Params = new List<TContratos>();
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    Params = context.Ca_Tipo_Contrato.OrderBy(x => x.Tipo_Contrato)
                        .Select(x => new TContratos { Id = x.Id_Tipo_Contrato, NombreCompleto = x.Tipo_Contrato }).ToList();
                }
            }
            catch (Exception ex) {
            }
            return Params;
        }
        public IEnumerable<TEmpresas> DatatSourceEmpresas()
        {
            List<TEmpresas> items = new List<TEmpresas>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.Empresas.Where(x => x.Activo == true)
                        .Select(x => new TEmpresas { Id = x.Id_Empresa, NombreCompleto = x.Razon_Social }).OrderBy(x => x.NombreCompleto).ToList();
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
        public IEnumerable<TSolicitado> DataSourceUsuariosLegal()
        {
            List<TSolicitado> items = new List<TSolicitado>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.spSelV_Usuarios_Legal().Where(x => x.Activo == true)
                        .Select(x => new TSolicitado { Id = x.Id_Usuario, NombreCompleto = x.Nombre }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public List<spSel_V_Re_Documento_Contrato_Id_Result> ListContratos(int id) {
            List<spSel_V_Re_Documento_Contrato_Id_Result> list = new List<spSel_V_Re_Documento_Contrato_Id_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSel_V_Re_Documento_Contrato_Id(id).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
    }
}
public class TContratos
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
public class TEmpresas
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
public class TProyectos
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
public class TSolicitado
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