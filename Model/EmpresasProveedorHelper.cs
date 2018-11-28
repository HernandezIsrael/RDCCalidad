using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class EmpresasProveedorHelper
    {
        public List<AliasEmpresas> DataSourceEmpresas() {
            List<AliasEmpresas> list = new List<AliasEmpresas>();
            AliasEmpresas item;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.Empresas.OrderBy(x => x.Razon_Social)
                          .Select(x => new AliasEmpresas { Id = x.Id_Empresa, NombreCompleto = x.Razon_Social }).ToList();
                    item = new AliasEmpresas();
                    item.Id = -1;
                    item.NombreCompleto = "Seleccionar...";
                    list.Add(item);
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public List<AliasEmpresas> DataSourceEmpresasGrupo()
        {
            List<AliasEmpresas> list = new List<AliasEmpresas>();
            AliasEmpresas item;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Empresas.Where(x=> x.Id_Tipo_Empresa==1)
                          .Select(x => new AliasEmpresas { Id = x.Id_Empresa, NombreCompleto = x.Razon_Social }).ToList();
                    item = new AliasEmpresas();
                    item.Id = -1;
                    item.NombreCompleto = "Seleccionar...";
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list.OrderBy(x => x.NombreCompleto).ToList();
        }
        public List<Re_Proveedores_Empresa> DataSourceInProveedorxEmpresa(int id)
        {
            List<Re_Proveedores_Empresa> list = new List<Re_Proveedores_Empresa>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Re_Proveedores_Empresa.Include("Empresas1").Where(x => x.Id_Empresa == id).OrderBy(x => x.Empresas1.Razon_Social).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public List<AliasEmpresas> DataSourceNotInProveedores(int id) {
            List<Empresas> Items = new List<Empresas>();
            List<AliasEmpresas> list = new List<AliasEmpresas>();
            List<Re_Proveedores_Empresa> Params = DataSourceInProveedorxEmpresa(id);
            AliasEmpresas es;
            Empresas item;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    Items = context.Empresas.OrderBy(x => x.Razon_Social).ToList();
                    foreach (Re_Proveedores_Empresa param in Params) {
                        item = context.Empresas.Where(x => x.Id_Empresa == param.Id_Proveedor).OrderBy(x => x.Razon_Social).SingleOrDefault();
                        Items.Remove(item);
                    }
                    foreach (Empresas i in Items) {
                        es = new AliasEmpresas();
                        es.Id = i.Id_Empresa;
                        es.NombreCompleto = i.Razon_Social;
                        list.Add(es);
                    }
                    es = new AliasEmpresas();
                    es.Id = -1;
                    es.NombreCompleto = "Selccionar...";
                    list.Add(es);
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public int Guardar(Re_Proveedores_Empresa Item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (Item.Id_Proveedores_Empresa > 0)
                    {
                        context.Entry(Item).State = EntityState.Deleted;
                    }
                    else {
                        context.Entry(Item).State = EntityState.Added;
                    }
                    Val = context.SaveChanges();
                }
            }
            catch (Exception ex) {
            }
            return Val;
        }
        public int Eliminar(int id)
        {
            int Val = 0;
            Re_Proveedores_Empresa param;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    param = context.Re_Proveedores_Empresa.Where(x => x.Id_Proveedores_Empresa == id).SingleOrDefault();
                    context.Entry(param).State = EntityState.Deleted;
                    Val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return Val;
        }
    }

    public class AliasEmpresas
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
