using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CodoleHelper
    {
        public List<spSel_Codole_Result> ListCodole() {
            List<spSel_Codole_Result> item = new List<spSel_Codole_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.spSel_Codole().OrderBy(x => x.Dias_Vigencia).ToList();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public CODOLE ObetnerCodole(int id) {
            CODOLE item = new CODOLE();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.CODOLE.Where(x => x.Id_Codole == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public IEnumerable<CodoleTipos> DatatSourceTipoCodole() {
            List<CodoleTipos> items = new List<CodoleTipos>();
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    items = context.Ca_Tipo_Codole.Where(x => x.Activo == true)
                        .Select(x => new CodoleTipos { Id = x.Id_Tipo_Codole, NombreCompleto = x.Tipo_Codole }).OrderBy(x=> x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex) {
            }
            return items;
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
        public IEnumerable<TSolicitado> DataSourceUsuariosLegal() {
            List<TSolicitado> items = new List<TSolicitado>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    items = context.spSelV_Usuarios_Legal().Where(x => x.Activo == true)
                        .Select(x => new TSolicitado { Id = x.Id_Usuario, NombreCompleto = x.Nombre }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex) {
            }
            return items;
        }
        public List<spSel_Documentos_Codole_Result> ListDocumentos(int id) {
            List<spSel_Documentos_Codole_Result> items = new List<spSel_Documentos_Codole_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    items = context.spSel_Documentos_Codole(id).ToList();
                }
            }
            catch (Exception ex) {
            }
            return items;
        }
        public int Guardar(CODOLE item) {
            int val = 0;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter id = new ObjectParameter("Id_Codole", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                if (item.Id_Proyecto >0)
                    item.Proyecto = true;
                else
                    item.Proyecto = false;
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.Id_Codole == 0) { 
                    context.spIns_Codole(
                        item.Id_Tipo_Codole,
                        item.F_Init,
                        item.F_Fin,
                        item.F_Firma,
                        item.Creado_por,
                        item.Encargado_Firmas,
                        item.Codigo_Codole,
                        item.Id_Empresa,
                        item.Id_Proveedor,
                        item.Proyecto,
                        item.Id_Proyecto,
                        item.Id_Solicitado_por,
                        item.Id_Valido_por,
                        item.Id_Generado_por,
                        item.Indefinido,
                        id,
                        VM,
                        VV);
                        if (VV.Value.ToString() == "0")
                            item.Id_Codole = int.Parse(id.Value.ToString());
                    }
                    else {
                        context.spPup_Codole(
                            item.Id_Codole,
                            item.Id_Tipo_Codole,
                            item.F_Init,
                            item.F_Fin,
                            item.F_Firma.Value,
                            item.Creado_por,
                            item.Encargado_Firmas,
                            item.Codigo_Codole,
                            item.Id_Empresa,
                            item.Id_Proveedor,
                            item.Proyecto,
                            item.Id_Proyecto,
                            item.Id_Solicitado_por,
                            item.Id_Valido_por,
                            item.Id_Generado_por,
                            item.Indefinido,
                            true,
                            VV,
                            VM);
                    }
                    if (VV.Value.ToString() == "0")
                        val = 1;
                }
            }
            catch (Exception ex) {
            }
            return val;
        }

    }
    public class CodoleTipos {
        private int id;
        public int Id {
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
}
