using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Model
{
    public class IngresosHelper
    {
        public List<spSelPagos_Procesados_UsuarioI_Result> ListIngresos(int id)
        {
            List<spSelPagos_Procesados_UsuarioI_Result> list = new List<spSelPagos_Procesados_UsuarioI_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelPagos_Procesados_UsuarioI(id).OrderByDescending(x => x.Id_Pago).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public List<spSelPagos_Captura_UsuarioI_Result> ListIngresosC(int id)
        {
            List<spSelPagos_Captura_UsuarioI_Result> list = new List<spSelPagos_Captura_UsuarioI_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelPagos_Captura_UsuarioI(id).OrderByDescending(x => x.Id_Pago).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public Pagos ObtenerNurc(int id,int IdUser) {
            Pagos item = new Pagos();
            ObjectParameter IdPago = new ObjectParameter("Id_Pago", typeof(Int32));
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                if (id == 0)
                {
                    using (ClusmextContext context = new ClusmextContext())
                    {
                        context.spInsPagoIngresos(IdUser, IdPago, VV, VM);
                        if (VV.Value.ToString() == "0")
                        {
                            id = int.Parse(IdPago.Value.ToString());
                            item = context.Pagos.Where(x => x.Id_Pago == id).SingleOrDefault();
                        }
                    }
                }
                else {
                    using (ClusmextContext context = new ClusmextContext())
                    {
                        item = context.Pagos.Where(x => x.Id_Pago == id).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public V_Pagos ObtenerVPago(int id) {
            V_Pagos item = new V_Pagos();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.V_Pagos.Where(x => x.Id_Pago == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public List<spSel_Conceptos_Pago_Result> DataSourceConceptos(int id)
        {
            List<spSel_Conceptos_Pago_Result> list = new List<spSel_Conceptos_Pago_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSel_Conceptos_Pago(id).OrderBy(x => x.Conceptos).ToList();
                }
            }
            catch (Exception ex)
            {
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
        public IEnumerable<Datos> DataSourceEmpresasUsuario(int id)
        {
            List<Datos> list = new List<Datos>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelEmpresas_Usuario(id)
                        .Select(x => new Datos { Id = x.Id_Empresa.Value, Texto = x.Razon_Social })
                        .OrderBy(x => x.Texto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceProyectos(int id)
        {
            List<Datos> list = new List<Datos>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelProyectos_Empresas(id)
                        .Select(x => new Datos { Id = x.Id_Proyecto, Texto = x.Proyecto })
                        .OrderBy(x => x.Texto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceRubros(int id)
        {
            List<Datos> list = new List<Datos>();
            Datos item = new Datos();
            item.Id = -1;
            item.Texto = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelRubros_Proyecto(id)
                        .Select(x => new Datos { Id = x.Id_Rubro, Texto = x.Codigo + " " + x.Rubro })
                        .OrderBy(x => x.Texto).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceSolicitantes()
        {
            List<Datos> list = new List<Datos>();
            Datos item = new Datos();
            item.Id = -1;
            item.Texto = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSel_Solicitado_por()
                        .Select(x => new Datos { Id = x.Id_Solicitado_por, Texto = x.Solicitado_por })
                        .OrderBy(x => x.Texto).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceProveedores(int id)
        {
            List<Datos> list = new List<Datos>();
            Datos item = new Datos();
            item.Id = -1;
            item.Texto = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelProveedores_Empresa(id)
                        .Select(x => new Datos { Id = x.Id_Proveedor, Texto = x.Proveedor })
                        .OrderBy(x => x.Texto).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceTipoPago()
        {
            List<Datos> list = new List<Datos>();
            Datos item = new Datos();
            item.Id = -1;
            item.Texto = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelTipo_Pago_Activo()
                        .Select(x => new Datos { Id = x.Id_Tipo_Pago, Texto = x.Tipo_Pago })
                        .OrderBy(x => x.Texto).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceMoneda()
        {
            List<Datos> list = new List<Datos>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelMonedas()
                        .Select(x => new Datos { Id = x.Id_Moneda, Texto = x.Moneda })
                        .OrderBy(x => x.Texto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceBancosProveedor(int id, int idmoneda)
        {
            List<Datos> list = new List<Datos>();
            Datos item = new Datos();
            item.Id = -1;
            item.Texto = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelBancos_Empresa_V2(id, idmoneda)
                        .Select(x => new Datos { Id = x.Id_Banco.Value, Texto = x.Banco })
                        .OrderBy(x => x.Texto).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceClabeProveedor(int idbanco, int idproveedor, int idmoneda)
        {
            List<Datos> list = new List<Datos>();
            Datos item = new Datos();
            item.Id = -1;
            item.Texto = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelClabe_Banco_Empresa_V2(idbanco, idproveedor, idmoneda)
                        .Select(x => new Datos { Id = x.Id_Clabe, Texto = x.N_Clabe })
                        .OrderBy(x => x.Texto).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceCuentaProveedor(int idbanco, int idproveedor, int idmoneda)
        {
            List<Datos> list = new List<Datos>();
            Datos item = new Datos();
            item.Id = -1;
            item.Texto = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelNCuenta_Banco_Empresa_V2(idbanco, idproveedor, idmoneda)
                        .Select(x => new Datos { Id = x.Id_N_Cuenta, Texto = x.N_Cuenta })
                        .OrderBy(x => x.Texto).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceContrato(int idempresa, int idproveedor)
        {
            List<Datos> list = new List<Datos>();
            Datos item = new Datos();
            item.Id = -1;
            item.Texto = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelContratos(idempresa, idproveedor)
                        .Select(x => new Datos { Id = x.Id_Contrato, Texto = x.Codigo_contrato + " " + x.Contrato })
                        .OrderBy(x => x.Texto).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Datos> DataSourceTipoDocumento()
        {
            List<Datos> list = new List<Datos>();
            Datos item = new Datos();
            item.Id = -1;
            item.Texto = "Seleccionar ...";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelTipo_Documento()
                        .Select(x => new Datos { Id = x.Id_Tipo_Documento, Texto = x.Tipo_Documento })
                        .OrderBy(x => x.Texto).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public bool GuardarDocumento(int IdPago, string Nombre, int IdTipoDocto, int Creado)
        {
            bool val = false;
            ObjectParameter NV = new ObjectParameter("Nombre_Virtual", typeof(String));
            ObjectParameter IdDcoto = new ObjectParameter("Id_Documento", typeof(Int32));
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));

            try
            {

                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spInsDocumento_Pago(Nombre, 1, Creado, IdPago, IdTipoDocto, NV, IdDcoto, VV, VM);
                    val = bool.Parse(VV.Value.ToString());
                }
            }
            catch (Exception ex)
            {
            }
            return val;
        }
        public bool BorrarDocumento(int id, int Creado)
        {
            bool val = false;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spPupDesHabilitar_Documentos(id, Creado, VV, VM);
                    val = bool.Parse(VV.Value.ToString());
                }
            }
            catch (Exception ex)
            {
            }
            return val;
        }
        public int BorrarConceptos(int id)
        {
            int val = 0;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spDelConceptos_Pago(id, VV, VM);
                    if (VV.Value.ToString() == "0")
                    {
                        val = 1;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return val;
        }
        public int GuardarConcepto(Conceptos item)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (item.Id_Conceptos > 0)
                    {
                        item = context.Conceptos.Where(x => x.Id_Conceptos == item.Id_Conceptos).SingleOrDefault();
                        context.Entry(item).State = EntityState.Deleted;
                    }
                    else
                    {
                        context.Entry(item).State = EntityState.Added;
                    }
                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return val;
        }
        public int Guardar(Pagos item, out List<Msj> msj)
        {
            int val = 1;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            msj = new List<Msj>();
            Msj param;

            if (item.Id_Empresa == -1 || item.Id_Empresa == null)
            {

                param = new Msj();
                param.Mnj = "El campo empresa es obligatorio";
                msj.Add(param);
                item.Id_Empresa = -1;

            }
            if (item.Id_Proveedor == -1 || item.Id_Proveedor == null)
            {
                param = new Msj();
                param.Mnj = "El campo proveedor es obligatorio";
                msj.Add(param);
                item.Id_Proveedor = -1;
            }
            if (item.Id_Banco == -1 || item.Id_Banco == null)
            {
                param = new Msj();
                param.Mnj = "El campo Banco es obligatorio";
                msj.Add(param);
                item.Id_Banco = -1;


            }
            if (item.Id_Clabe == -1 || item.Id_Clabe == null)
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
            if (item.Id_Proyecto == -1 || item.Proyecto == null)
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
            if (item.Id_Contrato == -1 || item.Id_Contrato == null)
                item.Contrato = false;
            else
                item.Contrato = true;

            item.Anticipo.ToString();
            if (item.Id_Moneda == -1 || item.Id_Moneda == null)
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

            if (item.Id_Tipo_Pago == -1 || item.Id_Tipo_Pago == null)
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
            if (item.Id_Banco_Empresa == -1 || item.Id_Banco_Empresa == null)
            {
                param = new Msj();
                param.Mnj = "El campo Banco es obligatorio";
                msj.Add(param);
                item.Id_Banco_Empresa = -1;


            }
            if (item.Id_Clabe_Empresa == -1 || item.Id_Clabe_Empresa == null)
            {
                param = new Msj();
                param.Mnj = "El campo Clabe es obligatorio";
                msj.Add(param);
                item.Id_Clabe_Empresa = -1;

            }
            if (item.Id_N_Cuenta_Empresa == -1)
            {
                param = new Msj();
                param.Mnj = "El campo Cuenta es obligatorio";
                msj.Add(param);
                item.Id_N_Cuenta_Empresa = -1;
            }

            if (msj.Count == 0)
                val = 0;
            else
                return val;

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spPupPagosIN(item.Id_Pago
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
                        ,item.Id_Banco_Empresa
                        ,item.Id_Clabe_Empresa
                        ,item.Id_N_Cuenta_Empresa
                        , VV
                        , VM);
                    if (VV.Value.ToString() == "0")
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return val;
        }
    }
    public class Datos {
        private int id;
        public int Id {
            get { return id; }
            set { id = value; }
        }
        private string texto;
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
    }
}
