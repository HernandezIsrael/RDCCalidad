using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using System.Data;

namespace Model
{
    public class VPagosHelper
    {
        public IPagedList<V_Pagos> ListaNurcs(int PageNumber, int PageSize,string search,string CurrentFilter)
        {
            if (search != null)
            {
                PageNumber = 1;
            }
            else
            {
                search = CurrentFilter;
            }
            List<V_Pagos> list = new List<V_Pagos>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                        list = context.V_Pagos.Where(x => x.Id_Estatus_Pago > 1 ).OrderByDescending(x => x.Id_Pago).ToList();
                    if (!String.IsNullOrEmpty(search))
                    {
                        list = list.Where(x => 
                                x.Id_Pago.ToString().Contains(search)
                              || x.Estatus_Pago.Contains(search)
                              || (x.F_Pago.HasValue?x.F_Pago.Value.ToShortDateString():"-1" ).Contains(search)
                              || (x.Folio_Fiscal!=null?x.Folio_Fiscal:"").Contains(search)
                              || (x.N_Transferencia!=null?x.N_Transferencia:"").Contains(search)
                              || (x.N_Cotizacion!=null?x.N_Cotizacion:"").Contains(search)
                              || (x.Clasificacion!=null?x.Clasificacion:"").Contains(search)
                              || (x.Tipo_Pago!=null?x.Tipo_Pago:"").Contains(search)
                              || (x.Factura!=null?x.Factura:"NO").Contains(search)
                              || (x.XML_Factura!=null?x.XML_Factura:"NO").Contains(search)
                              || (x.Comprobante_Pago!=null?x.Comprobante_Pago:"NO").Contains(search)
                              || (x.Val_Sat!=null?x.Val_Sat:"NO").Contains(search)
                              || (x.Codigo_Contrato!=null?x.Codigo_Contrato:"").Contains(search)
                              || x.Razon_Social.Contains(search)
                              || (x.RFC!=null?x.RFC:"").Contains(search)
                              || (x.Banco_Empresa!=null?x.Banco_Empresa:"").Contains(search)
                              || (x.Cuenta_empresa!=null?x.Cuenta_empresa:"").Contains(search)
                              || (x.Proveedor!=null?x.Proveedor:"").Contains(search)
                              || (x.RFC_Proveedor!=null?x.RFC_Proveedor:"").Contains(search)
                              || (x.Banco!=null?x.Banco:"").Contains(search)
                              || (x.N_Cuenta!=null?x.N_Cuenta:"").Contains(search)
                              || (x.Nombre_Proyecto!=null?x.Nombre_Proyecto:"").Contains(search)
                              || (x.Institucion!=null?x.Institucion:"").Contains(search)
                              || (x.Codigo!=null?x.Codigo:"").Contains(search)
                              || (x.Concepto!=null?x.Concepto:"").Contains(search)
                              || (x.Importe_Total!=null?x.Importe_Total:0).ToString().Contains(search)
                              || x.Calculo_IVA.ToString().Contains(search)
                              || x.Retenciones.ToString().Contains(search)
                              || x.Otros.ToString().Contains(search)
                              || x.ISR.ToString().Contains(search)
                              || x.Total.ToString().Contains(search)
                              || (x.Moneda!=null?x.Moneda:"").Contains(search)
                              || x.Tipo_Cambio.ToString().Contains(search)
                              || x.Total_Conversion.ToString().Contains(search)
                              || (x.Moneda_Conversion!=null?x.Moneda_Conversion:"").Contains(search)
                              || x.CS1.ToString().Contains(search)
                              || x.CS2.ToString().Contains(search)
                              || (x.Anticipo?"SI":"NO").Contains(search)
                              ).ToList();
                              
                             
             
                    }
                   
                }
            }
            catch (Exception ex) {

            }
          
                return list.ToPagedList(PageNumber, PageSize);

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
        public List<ExcelNurc> Excel()
        {
            List<ExcelNurc> list = new List<ExcelNurc>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.V_Pagos.Where(x => x.Id_Estatus_Pago > 1)
                        .Select(x => new ExcelNurc {
                            NURC = x.Id_Pago
                            ,Estatus = x.Estatus_Pago
                            ,FechaPago = x.F_Pago
                           , Autorizaciones = x.Autorizaciones
                           , Folio_Fiscal = x.Folio_Fiscal
                           , NoTransferencia = x.N_Transferencia
                           , NoCatización = x.N_Cotizacion
                           , Clasificación = x.Clasificacion
                           , TipodePago = x.Tipo_Pago
                           , Factura = x.Factura
                           , XML = x.XML_Factura
                           , Comprobante_Pago = x.Comprobante_Pago
                           , SAT = x.Val_Sat
                           , Contrato = x.Contrato
                           , Empresa = x.Razon_Social
                           , RFC = x.RFC
                           , Banco = x.Banco_Empresa
                           , NoCuenta = x.Cuenta_empresa
                           , Proveedor = x.Proveedor
                           , RFC_Proveedor = x.RFC_Proveedor
                           , Banco_Proveedor = x.Banco
                           , NoCuentaProveedor = x.N_Cuenta
                           , Proyecto = x.Nombre_Proyecto
                           , Programa = x.Institucion
                           , Rubro = x.Codigo
                           , Concepto = x.Concepto
                           , Acticipo = x.Anticipo
                           , Importe = x.Importe_Total
                           , IVA = x.Calculo_IVA
                           ,Rent_IVA=x.Retenciones
                           ,Rent_Otros=x.Otros
                           ,Rent_ISR=x.ISR
                           ,Total=x.Total
                           ,Moneda=x.Moneda
                           ,Cambio=x.Tipo_Cambio
                           ,Total_Conversión=x.Total_Conversion
                           ,Moneda_Conversión=x.Moneda_Conversion
                           ,CS1=x.CS1
                           ,CS2=x.CS2

                        }).OrderByDescending(x => x.NURC).ToList();
                        
                        
                        //.OrderByDescending(x => x.Id_Pago).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
    }
    public class ExcelNurc {
        private int nurc;
        public int NURC
        {
            get { return nurc; }
            set { nurc = value; }
        }
        private string estatus;
        public string Estatus {
            get { return estatus; }
            set { estatus = value; }
        }
        private DateTime? fechapago;
        public DateTime? FechaPago {
            get { return fechapago; }
            set { fechapago = value; }
        }
        private int? autorizaciones;
        public int? Autorizaciones {
            get { return autorizaciones; }
            set { autorizaciones = value; }
        }
        private string foliofiscal;
        public string Folio_Fiscal {
            get { return foliofiscal; }
            set { foliofiscal = value; }
        }
        private string notransferencuia;
        public string NoTransferencia
        {
            get { return notransferencuia; }
            set { notransferencuia = value; }
        }
        private string nocotizacion;
        public string NoCatización {
            get { return nocotizacion; }
            set { nocotizacion = value; }
        }
        private string clasificacion;
        public string Clasificación {
            get { return clasificacion; }
            set { clasificacion = value; }
        }
        private string tipodepago;
        public string TipodePago {
            get { return tipodepago; }
            set { tipodepago = value; }
        }
        private string factura;
        public string Factura {
            get { return factura; }
            set { factura = value; }
        }
        private string xml;
        public string XML {
            get { return xml; }
            set { xml = value; }
        }
        private string comprobantepago;
        public string Comprobante_Pago {
            get { return comprobantepago; }
            set { comprobantepago = value; }
        }
        private string sat;
        public string SAT {
            get { return sat; }
            set { sat = value; }
        }
        private bool contrato;
        public bool Contrato {
            get { return contrato; }
            set { contrato = value; }
        }
        private string empresa;
        public string Empresa {
            get { return empresa; }
            set { empresa = value; }
        }
        private string rfc;
        public string RFC {
            get { return rfc; }
            set { rfc = value; }
        }
        private string banco;
        public string Banco {
            get { return banco; }
            set { banco = value; }
        }
        private string ncuenta;
        public string NoCuenta {
            get { return ncuenta; }
            set { ncuenta = value; }
        }
        private string proveedor;
        public string Proveedor {
            get { return proveedor; }
            set { proveedor = value; }
        }
        private string rfcproveedor;
        public string RFC_Proveedor {
            get { return rfcproveedor; }
            set { rfcproveedor = value; }
        }
        private string bancoproveedor;
        public string Banco_Proveedor {
            get { return bancoproveedor; }
            set { bancoproveedor = value; }
        }
        private string ncuentaproveedor;
        public string NoCuentaProveedor {
            get { return ncuentaproveedor; }
            set { ncuentaproveedor = value; }
        }
        private string proyecto;
        public string Proyecto {
            get { return proyecto; }
            set { proyecto = value; }
        }
        private string programa;
        public string Programa {
            get { return programa; }
            set { programa = value; }
        }
        private string rubro;
        public string Rubro
        {
            get { return rubro; }
            set { rubro = value; }
        }
        private string concepto;
        public string Concepto {
            get { return concepto; }
            set { concepto = value; }
        }
        private bool? anticipo;
        public bool? Acticipo {
            get { return anticipo; }
            set { anticipo = value; }
        }
        private decimal? importe;
        public decimal? Importe {
            get { return importe; }
            set { importe = value; }
        }
        private decimal? iva;
        public decimal? IVA {
            get { return iva; }
            set { iva = value; }
        }
        private decimal? rentiva;
        public decimal? Rent_IVA {
            get { return rentiva; }
            set { rentiva = value; }
        }
        private decimal? rentotros;
        public decimal? Rent_Otros {
            get { return rentotros; }
            set { rentotros = value; }
        }
        private decimal? rentrisr;
        public decimal? Rent_ISR {
            get { return rentrisr; }
            set { rentrisr = value; }
        }
        private decimal? total;
        public decimal? Total {
             get { return total; }
            set { total = value; }
        }
        private string moneda;
        public string Moneda {
            get { return moneda; }
            set { moneda = value; }
        }
        private decimal? cambio;
        public decimal? Cambio {
            get { return cambio; }
            set { cambio = value; }
        }
        private decimal? totalconversion;
        public decimal? Total_Conversión {
            get { return totalconversion; ; }
            set { totalconversion = value; }
        }
        private string monedaconversion;
        public string Moneda_Conversión {
            get { return monedaconversion; }
            set { monedaconversion = value; }
        }
        private int? cs1;
        public int? CS1 {
            get { return cs1; }
            set { cs1 = value; }
        }
        private int? cs2;
        public int? CS2 {
            get { return cs2; }
            set { cs2 = value; }
        }
    }
   
}
