using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CapacidadesHelper
    {
        public List<Servicios> GetServicios()
        {
            List<Servicios> s = new List<Servicios>();

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    s = context.Servicios.Include("Ca_Tipo_Servicio").Include("Empresas").Include("Empresas1").Include("Ca_Moneda").Include("SEEstatusServicios").Include("SEDirecciones").ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return s;
        }

        public Servicios GetServicio(int id)
        {
            Servicios s = new Servicios();
            if (id == 0)
            {
                s.Id_Empresa = -1;
                s.Id_Proveedor = -1;
                s.Id_tipo_servicio = -1;
                s.IdEstatusServicio = -1;
                s.Id_Moneda = -1;
                s.IdDireccion = -1;
                return s;
            }
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    s = context.Servicios.Include("Ca_Tipo_Servicio").Include("Empresas").Include("Ca_Moneda").Include("SEEstatusServicios").Include("SEDirecciones").Where(x => x.IdServicios == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }

            return s;
        }

        public Servicios GetRawServicio(int id)
        {
            Servicios s = new Servicios();
            if (id == 0)
            {
                s.Id_Empresa = -1;
                s.Id_Proveedor = -1;
                s.Id_tipo_servicio = -1;
                s.IdEstatusServicio = -1;
                s.Id_Moneda = -1;
                s.Id_Lapso = -1;
                return s;
            }
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    s = context.Servicios.Where(x => x.IdServicios == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }

            return s;
        }

        public int InsertServicio(Servicios s)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (s.IdServicios > 0)
                    {
                        context.Entry(s).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(s).State = EntityState.Added;
                    }

                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public int InsertFile(SEDocumentosServicios doc, out string NV)
        {
            //Usamos el stored procedure "spInsDocumentoServiciosInit"
            int val = 0;
            NV = string.Empty;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            ObjectParameter nombreVirtual = new ObjectParameter("Nombre_Virtual", typeof(String));
            ObjectParameter idDocumento = new ObjectParameter("Id_Documento", typeof(Int32));
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spInsDocumentoServiciosInit(doc.Nombre, doc.Id_FTP, doc.CreadoPor, 0, doc.IdServicio, doc.IdTipoDocumentoServicio, nombreVirtual, idDocumento, VV, VM);
                    if (VV.Value.ToString() == "0")
                    {
                        val = 1;
                        NV = nombreVirtual.Value.ToString();
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public IEnumerable<Empresas> GetEmpresas()
        {
            List<Empresas> list = new List<Empresas>();
            Empresas item = new Empresas();
            item.Id_Empresa = -1;
            item.Razon_Social = "* Seleccionar empresa";

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

        public IEnumerable<Empresas> GetProveedores()
        {
            List<Empresas> list = new List<Empresas>();
            Empresas item = new Empresas();
            item.Id_Empresa = -1;
            item.Razon_Social = "* Seleccionar proveedor";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Empresas.Where(x => x.Id_Empresa != -1 && x.Id_Tipo_Empresa == 2).OrderBy(x => x.Razon_Social).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<Ca_Tipo_Servicio> GetTipoServicios()
        {
            List<Ca_Tipo_Servicio> list = new List<Ca_Tipo_Servicio>();
            Ca_Tipo_Servicio item = new Ca_Tipo_Servicio();
            item.Id_tipo_servicio = -1;
            item.Tipo_Servicio = "* Seleccionar servicio";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Tipo_Servicio.Where(x => x.Id_tipo_servicio != 1008).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<SEDirecciones> GetDirecciones()
        {
            List<SEDirecciones> list = new List<SEDirecciones>();
            SEDirecciones item = new SEDirecciones();
            item.IdDireccion = -1;
            item.Direccion = "* Seleccionar una dirección";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.SEDirecciones.ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<SEEstatusServicios> GetStatus()
        {
            List<SEEstatusServicios> list = new List<SEEstatusServicios>();
            SEEstatusServicios item = new SEEstatusServicios();
            item.IdEstatusServicio = -1;
            item.EstatusServicio = "* Selecciona un status";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.SEEstatusServicios.ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<Ca_Moneda> GetDivisas()
        {
            List<Ca_Moneda> list = new List<Ca_Moneda>();
            Ca_Moneda item = new Ca_Moneda();
            item.Id_Moneda = -1;
            item.Moneda = "* Selecciona tipo de divisa";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Moneda.ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<Ca_Lapso> GetLapsos()
        {
            List<Ca_Lapso> list = new List<Ca_Lapso>();
            Ca_Lapso item = new Ca_Lapso();
            item.Id_Lapso = -1;
            item.Lapso = "* Lapso";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Lapso.ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<SEDocumentosServicios> GetDocs(int id)
        {
            List<SEDocumentosServicios> list = new List<SEDocumentosServicios>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.SEDocumentosServicios.Where(x => x.IdServicio == id).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<SEDocumentosServicios> GetAllDocs()
        {
            List<SEDocumentosServicios> list = new List<SEDocumentosServicios>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.SEDocumentosServicios.ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public Empresas GetEmpresa(int id)
        {
            Empresas empresa = new Empresas();

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    empresa = context.Empresas.Where(x => x.Id_Empresa == id).SingleOrDefault();
                }
            }
            catch(Exception ex)
            {

            }

            return empresa;
        }

        public List<spSelReporteServicios_Result> GetReporteServicios(int idEmpresa)
        {
            List<spSelReporteServicios_Result> list = new List<spSelReporteServicios_Result>();

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelReporteServicios(idEmpresa).ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        /******************************************* ACTIVO FIJO **********************************************/

        public List<Activo_Fijo> GetActivoFijo()
        {
            List<Activo_Fijo> list = new List<Activo_Fijo>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Activo_Fijo.Include("Empresas").Include("Ca_Condicion").Include("Ca_Marca").Include("Ca_Moneda").ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public Activo_Fijo GetAFDetail(int id = 0)
        {
            Activo_Fijo item = new Activo_Fijo();

            if (id == 0)
            {
                item.Id_Empresa = -1;
                item.Id_Proveedor = -1;
                item.Id_Categoria = -1;
                item.Id_Condicion = -1;
                item.Id_Moneda = -1;
                item.Id_Marca = -1;
                return item;
            }

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    item = context.Activo_Fijo.Where(x => x.Id_Activo == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return item;
        }

        public IEnumerable<Ca_Categoria> GetCategorias()
        {
            Ca_Categoria def = new Ca_Categoria();
            List<Ca_Categoria> list = new List<Ca_Categoria>();
            def.Id_Categoria = -1;
            def.Categoria = "* Seleccionar categoría";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Categoria.ToList();
                    list.Add(def);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<Ca_Marca> GetMarcas()
        {
            List<Ca_Marca> list = new List<Ca_Marca>();
            Ca_Marca item = new Ca_Marca();
            item.Id_Marca = -1;
            item.Marca = "* Seleccionar marca del producto";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Marca.ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<Ca_Condicion> GetCondiciones()
        {
            List<Ca_Condicion> list = new List<Ca_Condicion>();
            Ca_Condicion item = new Ca_Condicion();
            item.Id_Condicion = -1;
            item.Condicion = "* Seleccionar condición actual del prodcuto";
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Condicion.ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public int InsertAF(Activo_Fijo af)
        {
            int newID = 0;
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (af.Id_Activo > 0)
                    {
                        context.Entry(af).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(af).State = EntityState.Added;
                    }

                    val = context.SaveChanges();
                    newID = af.Id_Activo;
                }
            }
            catch (Exception ex)
            {

            }
            return newID;
        }

    }
}
