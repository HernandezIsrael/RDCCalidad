using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using System.Data.Entity.Core.Objects;

namespace Model
{
  public class NurcEgresosHelper
    {
        public spSelPagos_Id_Result ViewPago(int id) {
            spSelPagos_Id_Result item = new spSelPagos_Id_Result();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.spSelPagos_Id(id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public IPagedList<spSelPagos_Procesados_Usuario_Result> ProcesadosUsuario(int id, int PageNumber, int PageSize, string search, string CurrentFilter) {
            List<spSelPagos_Procesados_Usuario_Result> list = new List<spSelPagos_Procesados_Usuario_Result>();
            if (search != null)
            {
                PageNumber = 1;
            }
            else
            {
                search = CurrentFilter;
            }
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelPagos_Procesados_Usuario(id).ToList();
                    if (!String.IsNullOrEmpty(search))
                    {
                        list = list.Where(x =>
                            x.Id_Pago.ToString().Contains(search)
                            || x.Solicitado_por.Contains(search)
                            || x.Estatus_Pago.Contains(search)
                            || (x.F_Pago.HasValue ? x.F_Pago.Value.ToShortDateString() : "-1").Contains(search)
                            || (x.Folio_Fiscal != null ? x.Folio_Fiscal : "").Contains(search)
                            || x.Razon_Social.Contains(search)
                            || (x.Proveedor != null ? x.Proveedor : "").Contains(search)
                            || (x.Nombre_Proyecto != null ? x.Nombre_Proyecto : "").Contains(search)
                            || (x.Codigo != null ? x.Codigo : "").Contains(search)
                            || (x.Anticipo.HasValue ? "SI" : "NO").Contains(search)
                            || (x.Importe_Total != null ? x.Importe_Total : 0).ToString().Contains(search)
                            || x.Calculo_IVA.ToString().Contains(search)
                            || x.Retenciones.ToString().Contains(search)
                            || x.Otros.ToString().Contains(search)
                            || x.ISR.ToString().Contains(search)
                            || x.Total.ToString().Contains(search)
                            || (x.Moneda != null ? x.Moneda : "").Contains(search)
                            || (x.F_Alta.HasValue ? x.F_Alta.Value.ToShortDateString() : "-1").Contains(search)
                            || x.Usuario.Contains(search)
                            ).ToList();
                    }
                }
            }
            catch (Exception ex) {
            }
            return list.ToPagedList(PageNumber, PageSize); ;
        }
        public IPagedList<spSelPagos_Captura_Usuario_Result> CapturaUsuario(int id, int PageNumber, int PageSize, string search, string CurrentFilter)
        {
            List<spSelPagos_Captura_Usuario_Result> list = new List<spSelPagos_Captura_Usuario_Result>();
            if (search != null)
            {
                PageNumber = 1;
            }
            else
            {
                search = CurrentFilter;
            }
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelPagos_Captura_Usuario(id).ToList();
                    if (!String.IsNullOrEmpty(search))
                    {
                        list = list.Where(x =>
                            x.Id_Pago.ToString().Contains(search)
                            || x.Solicitado_por.Contains(search)
                            || x.Estatus_Pago.Contains(search)
                            || (x.F_Pago.HasValue ? x.F_Pago.Value.ToShortDateString() : "-1").Contains(search)
                            || (x.Folio_Fiscal != null ? x.Folio_Fiscal : "").Contains(search)
                            || x.Razon_Social.Contains(search)
                            || (x.Proveedor != null ? x.Proveedor : "").Contains(search)
                            || (x.Nombre_Proyecto != null ? x.Nombre_Proyecto : "").Contains(search)
                            || (x.Codigo != null ? x.Codigo : "").Contains(search)
                            || (x.Anticipo.HasValue ? "SI" : "NO").Contains(search)
                            || (x.Importe_Total != null ? x.Importe_Total : 0).ToString().Contains(search)
                            || x.Calculo_IVA.ToString().Contains(search)
                            || x.Retenciones.ToString().Contains(search)
                            || x.Otros.ToString().Contains(search)
                            || x.ISR.ToString().Contains(search)
                            || x.Total.ToString().Contains(search)
                            || (x.Moneda != null ? x.Moneda : "").Contains(search)
                            || (x.F_Alta.HasValue ? x.F_Alta.Value.ToShortDateString() : "-1").Contains(search)
                            || x.Usuario.Contains(search)
                            ).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return list.ToPagedList(PageNumber, PageSize); 
        }
        public IEnumerable<EmpresasGrupo> DataSourceEmpresasUsuario(int id) {
            List<EmpresasGrupo> list = new List<EmpresasGrupo>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSelEmpresas_Usuario(id)
                        .Select(x => new EmpresasGrupo {Id= x.Id_Empresa, NombreCompleto=x.Razon_Social})
                        .OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public IEnumerable<ProyectosxEmpresa> DataSourceProyectos(int id)
        {
            List<ProyectosxEmpresa> list = new List<ProyectosxEmpresa>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelProyectos_Empresas(id)
                        .Select(x => new ProyectosxEmpresa { Id = x.Id_Proyecto,Proyecto= x.Proyecto })
                        .OrderBy(x => x.Proyecto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Rubros> DataSourceRubros(int id)
        {
            List<Rubros> list = new List<Rubros>();
            Rubros item = new Rubros();
            item.Id = -1;
            item.Rubro = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelRubros_Proyecto(id)
                        .Select(x => new Rubros { Id = x.Id_Rubro, Rubro = x.Codigo+" "+ x.Rubro })
                        .OrderBy(x => x.Rubro).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Solicitantes> DataSourceSolicitantes()
        {
            List<Solicitantes> list = new List<Solicitantes>();
            Solicitantes item = new Solicitantes();
            item.Id = -1;
            item.Solicitante = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSel_Solicitado_por()
                        .Select(x => new Solicitantes { Id = x.Id_Solicitado_por, Solicitante = x.Solicitado_por })
                        .OrderBy(x => x.Solicitante).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<ProveedoresxEmpresa> DataSourceProveedores(int id)
        {
            List<ProveedoresxEmpresa> list = new List<ProveedoresxEmpresa>();
            ProveedoresxEmpresa item = new ProveedoresxEmpresa();
            item.Id = -1;
            item.Proveedores = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelProveedores_Empresa(id)
                        .Select(x => new ProveedoresxEmpresa { Id = x.Id_Proveedor, Proveedores = x.Proveedor })
                        .OrderBy(x => x.Proveedores).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<TipoPago> DataSourceTipoPago()
        {
            List<TipoPago> list = new List<TipoPago>();
            TipoPago item = new TipoPago();
            item.Id = -1;
            item.Tipo = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelTipo_Pago_Activo()
                        .Select(x => new TipoPago { Id = x.Id_Tipo_Pago, Tipo = x.Tipo_Pago })
                        .OrderBy(x => x.Tipo).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<LMoney> DataSourceMoneda()
        {
            List<LMoney> list = new List<LMoney>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelMonedas()
                        .Select(x => new LMoney { Id = x.Id_Moneda, Money = x.Moneda })
                        .OrderBy(x => x.Money).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Bancos> DataSourceBancosProveedor(int id,int idmoneda)
        {
            List<Bancos> list = new List<Bancos>();
            Bancos item = new Bancos();
            item.Id = -1;
            item.Banco = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelBancos_Empresa_V2(id,idmoneda)
                        .Select(x => new Bancos { Id = x.Id_Banco, Banco = x.Banco })
                        .OrderBy(x => x.Banco).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<LClabe> DataSourceClabeProveedor(int idbanco,int idproveedor, int idmoneda)
        {
            List<LClabe> list = new List<LClabe>();
            LClabe item = new LClabe();
            item.Id = -1;
            item.Clabe = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelClabe_Banco_Empresa_V2(idbanco,idproveedor,idmoneda)
                        .Select(x => new LClabe { Id = x.Id_Clabe, Clabe = x.N_Clabe })
                        .OrderBy(x => x.Clabe).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<NCuenta> DataSourceCuentaProveedor(int idbanco, int idproveedor, int idmoneda)
        {
            List<NCuenta> list = new List<NCuenta>();
            NCuenta item = new NCuenta();
            item.Id = -1;
            item.Cuenta = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelNCuenta_Banco_Empresa_V2(idbanco, idproveedor, idmoneda)
                        .Select(x => new NCuenta { Id = x.Id_N_Cuenta, Cuenta = x.N_Cuenta })
                        .OrderBy(x => x.Cuenta).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<LContrato> DataSourceContrato(int idempresa, int idproveedor)
        {
            List<LContrato> list = new List<LContrato>();
            LContrato item = new LContrato();
            item.Id = -1;
            item.Contrato = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelContratos(idempresa, idproveedor)
                        .Select(x => new LContrato { Id = x.Id_Contrato, Contrato = x.Codigo_contrato+" "+x.Contrato })
                        .OrderBy(x => x.Contrato).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<TipoDocumento> DataSourceTipoDocumento() {
            List<TipoDocumento> list = new List<TipoDocumento>();
            TipoDocumento item = new TipoDocumento();
            item.Id = -1;
            item.Tipo = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSelTipo_Documento()
                        .Select(x => new TipoDocumento { Id = x.Id_Tipo_Documento, Tipo = x.Tipo_Documento })
                        .OrderBy(x => x.Tipo).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public List<spSelDocumentos_Pago_Id_Result> DataSourceDocumentos(int id)
        {
            List<spSelDocumentos_Pago_Id_Result> list = new List<spSelDocumentos_Pago_Id_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelDocumentos_Pago_Id(id).OrderByDescending(x => x.Nombre).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public bool GuardarDocumento(int IdPago,string Nombre,int IdTipoDocto,int Creado) {
            bool val = false;
            ObjectParameter NV = new ObjectParameter("Nombre_Virtual", typeof(String));
            ObjectParameter IdDcoto = new ObjectParameter("Id_Documento", typeof(Int32));
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
          
            try
            {
                
                using (ClusmextContext context = new ClusmextContext()) {
                   context.spInsDocumento_Pago(Nombre, 1, Creado, IdPago, IdTipoDocto, NV, IdDcoto, VV, VM);
                    val = bool.Parse(VV.Value.ToString());
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        public bool BorrarDocumento(int id,int Creado) {
            bool val = false;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    context.spPupDesHabilitar_Documentos(id, Creado, VV, VM);
                    val = bool.Parse(VV.Value.ToString());
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        public List<spSel_Conceptos_Pago_Result> DataSourceConceptos(int id) {
            List<spSel_Conceptos_Pago_Result> list = new List<spSel_Conceptos_Pago_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSel_Conceptos_Pago(id).OrderBy(x => x.Conceptos).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public int GuardarConcepto(Conceptos item) {
            int val = 0;
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.Id_Conceptos > 0) {
                        item = context.Conceptos.Where(x => x.Id_Conceptos == item.Id_Conceptos).SingleOrDefault();
                        context.Entry(item).State = EntityState.Deleted;
                    }
                    else{
                        context.Entry(item).State = EntityState.Added;
                    }
                    val = context.SaveChanges();
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        public Pagos CrearNurc(int creado) {
            Pagos nurc = new Pagos();
            ObjectParameter IdPago = new ObjectParameter("Id_Pago", typeof(Int32));
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    context.spInsPago(creado, IdPago, VV, VM);
                    if (VV.Value.ToString() == "0") {
                        int id = int.Parse(IdPago.Value.ToString());
                        nurc = context.Pagos.Where(x => x.Id_Pago ==id ).SingleOrDefault();
                    }
                    else {
                    }
                }
            }
            catch (Exception ex) {
            }
            return nurc;
        }
        public Pagos SelectNurc(int id)
        {
            Pagos nurc = new Pagos();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    nurc = context.Pagos.Where(x => x.Id_Pago == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return nurc;
        }
        public int SelectEmpesa(string rfc) {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    val = context.Empresas.Where(x => x.RFC.ToUpper().Trim() == rfc.ToUpper().Trim()).SingleOrDefault().Id_Empresa;
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        public int BorrarConceptos(int id) {
            int val = 0;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    context.spDelConceptos_Pago(id, VV, VM);
                    if (VV.Value.ToString() == "0") {
                        val = 1;
                    }
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        public int Guardar(Pagos item,out List<Msj> msj) {
            int val = 1;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            msj = new List<Msj>();
            Msj param;

            if (item.Id_Empresa == -1 || item.Id_Empresa ==null)
            {

                param = new Msj();
                param.Mnj = "El campo empresa es obligatorio";
                msj.Add(param);
                item.Id_Empresa = -1;
              
            }
            if (item.Id_Proveedor == -1 || item.Id_Proveedor==null)
            {
                param = new Msj();
                param.Mnj = "El campo proveedor es obligatorio";
                msj.Add(param);
                item.Id_Proveedor = -1;
            }
            if (item.Id_Banco == -1 || item.Id_Banco==null)
            {
                param = new Msj();
                param.Mnj = "El campo Banco es obligatorio";
                msj.Add(param);
                item.Id_Banco = -1;
               
               
            }
            if (item.Id_Clabe == -1 || item.Id_Clabe==null)
            {
                param = new Msj();
                param.Mnj = "El campo Clabe es obligatorio";
                msj.Add(param);
                item.Id_Clabe = -1;
 
            }
            if (item.Importe_Total <= 0)
            {
                param = new Msj();
                param.Mnj = "El importe debe de ser mayor a 0";
                msj.Add(param);
            }

            if (!item.F_Compromiso_Pago.HasValue)
            {
                param = new Msj();
                param.Mnj = "Indicar la fecha compromiso de pago";
                msj.Add(param);
            }
            if (item.Id_Proyecto == -1 || item.Proyecto==null)
            {
                item.Proyecto = false;
                item.Id_Proyecto = -1;
            }
            else
            {
                item.Proyecto = true;
                if (item.Id_Rubro == -1)
                {
                    param = new Msj();
                    param.Mnj = "El rubro es obligatorio";
                    msj.Add(param);
                    item.Id_Rubro = -1;
                }
            }
            if (item.Id_Contrato == -1 || item.Id_Contrato==null)
                item.Contrato = false;
            else
                item.Contrato = true;
           
            item.Anticipo.ToString();
            if (item.Id_Moneda == -1 || item.Id_Moneda==null)
            {
                param = new Msj();
                param.Mnj = "El campo moneda es obligatorio";
                msj.Add(param);
                item.Id_Moneda = -1;
            }


            if (string.IsNullOrWhiteSpace(item.Folio_Fiscal))
            {
                param = new Msj();
                param.Mnj = "Folio Fiscal es obligatorio";
                msj.Add(param);
            }
            if (item.Id_N_Cuenta == -1)
            {
                param = new Msj();
                param.Mnj = "El campo Cuenta es obligatorio";
                msj.Add(param);
                item.Id_N_Cuenta = -1;
            }
            item.Fecha_Anticipo_Factura.ToString();

            if (!item.F_Emision_Factura.HasValue)
            {
                param = new Msj();
                param.Mnj = "Indicar fecha de emisión de la factura";
                msj.Add(param);
            }

            if (item.Id_Tipo_Pago == -1 || item.Id_Tipo_Pago==null)
            {
                param = new Msj();
                param.Mnj = "El tipo de pago es obligatorio";
                msj.Add(param);
                item.Id_Tipo_Pago = -1;

            }


            if (item.Id_Solicitado_por == -1 || item.Id_Solicitado_por == null)
            {
                param = new Msj();
                param.Mnj = "El Campo solicitado por es obligatorio";
                msj.Add(param);
                item.Id_Solicitado_por = -1;
            }

            if (msj.Count == 0)
                val = 0;
            else
                return val;

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spPupPagos(item.Id_Pago
                        , item.Id_Estatus_Pago
                        , item.Id_Empresa
                        , item.Id_Proveedor
                        , item.Id_Banco
                        , item.Id_Clabe
                        , item.Importe_Total
                        , item.F_Compromiso_Pago
                        , item.Proyecto
                        , item.Id_Proyecto
                        , item.Contrato
                        , item.Id_Contrato
                        , item.Anticipo
                        , item.Id_Moneda
                        , item.Id_Rubro
                        , -1
                        , item.Retenciones
                        , item.ISR
                        , item.Folio_Fiscal
                        , item.Id_N_Cuenta
                        , item.Fecha_Anticipo_Factura
                        , item.Otros
                        , item.F_Emision_Factura
                        , item.Creado_por
                        , item.Comentarios
                        , item.Id_Tipo_Pago
                        , item.N_Cotizacion
                        , item.Solicitado_por
                        , item.Id_Clasificacion
                        , item.IVA
                        , item.Id_Solicitado_por
                        , VV
                        , VM);
                    if (VV.Value.ToString() == "0")
                    {
                    }
                }
            }
            catch (Exception ex) {
            }

            return val;
        }
    }
    public class Msj {
        private string mnj;
        public string Mnj
        {
            get { return mnj; }
            set { mnj = value; }
        }
    }
    public class EmpresasGrupo
    {
        private int? id;
        public int? Id
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
    public class ProyectosxEmpresa
    {
        private int? id;
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }
        private string proyecto;
        public string Proyecto
        {
            get { return proyecto; }
            set { proyecto = value; }
        }
    }
    public class Rubros
    {
        
        private int? id;
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }
        private string rubro;
        public string Rubro
        {
            get { return rubro; }
            set { rubro = value; }
        }
    }
    public class Solicitantes
    {

        private int? id;
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }
        private string solicitante;
        public string Solicitante
        {
            get { return solicitante; }
            set { solicitante = value; }
        }
    }
    public class ProveedoresxEmpresa
    {

        private int? id;
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }
        private string proveedores;
        public string Proveedores
        {
            get { return proveedores; }
            set { proveedores = value; }
        }
    }
    public class TipoPago
    {

        private int? id;
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }
        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
    public class LMoney
    {

        private int? id;
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }
        private string money;
        public string Money
        {
            get { return money; }
            set { money = value; }
        }
    }
    public class Bancos
    {

        private int? id;
        public int? Id
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
    public class LClabe
    {

        private int? id;
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }
        private string clabe;
        public string Clabe
        {
            get { return clabe; }
            set { clabe = value; }
        }
    }
    public class NCuenta
    {

        private int? id;
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }
        private string cuenta;
        public string Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }
    }
    public class LContrato
    {

        private int? id;
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }
        private string contrato;
        public string Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }
    }
    public class TipoDocumento
    {

        private int? id;
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }
        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
