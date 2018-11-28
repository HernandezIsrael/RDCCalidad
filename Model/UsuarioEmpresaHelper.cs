using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class UsuarioEmpresaHelper
    {
        public IEnumerable<Empleados> ListarUsuarios() {
            List<Empleados> list =new  List<Empleados>();
            Empleados item = new Empleados();
            item.Id = -1;
            item.NombreCompleto = "Seleccionar..";
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                     list = context.Usuarios.Where(x => x.Activo == true).OrderBy(x => x.Nombre).
                            Select(x => new Empleados { Id=x.Id_Usuario, NombreCompleto=x.Nombre+" "+x.Apellidos }).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public List<Re_Usuario_Empresa> ListarempresasxUsuario(int id) {
            List<Re_Usuario_Empresa> list = new List<Re_Usuario_Empresa>();
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.Re_Usuario_Empresa.Include("Empresas").Where(x => x.Id_Usuario == id).OrderBy(x=>x.Empresas.Razon_Social).ToList();
                }
            }catch(Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<EmpresasSocias> DataSourceempresasxUsuario(int id)
        {
            List<EmpresasSocias> list = new List<EmpresasSocias>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Re_Usuario_Empresa.Include("Empresas").Where(x => x.Id_Usuario == id).OrderBy(x => x.Empresas.Razon_Social).
                        Select(x => new EmpresasSocias { Id = x.Id_Re_Usuario_Empresas, NombreCompleto = x.Empresas.Razon_Social }).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public List<EmpresasSocias> DataSourceEmpresasNotIn(int id)
        {
            List<Empresas> list = new List<Empresas>();
            List<Re_Usuario_Empresa> Params = ListarempresasxUsuario(id);
            List<EmpresasSocias> Items = new List<EmpresasSocias>();
            EmpresasSocias es;
            Empresas item;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Empresas.OrderBy(x => x.Razon_Social).ToList();
                    foreach (Re_Usuario_Empresa param in Params)
                    {
                        item = context.Empresas.Where(x => x.Id_Empresa == param.Id_Empresa).SingleOrDefault();
                        list.Remove(item);
                    }
                    foreach (Empresas i in list) {
                        es = new EmpresasSocias();
                        es.Id = i.Id_Empresa;
                        es.NombreCompleto = i.Razon_Social;
                        Items.Add(es);
                    }
                    es = new EmpresasSocias();
                    es.Id = -1;
                    es.NombreCompleto = "Selccionar...";
                    Items.Add(es);

                }
            }
            catch (Exception ex)
            {
            }
            return Items;
        }
        public List<Empresas> ListarEmpresasNotIn(int id)
        {
            List<Empresas> list = new List<Empresas>();
            List<Re_Usuario_Empresa> Params = ListarempresasxUsuario(id);
            Empresas item;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Empresas.OrderBy(x => x.Razon_Social).ToList();
                    foreach (Re_Usuario_Empresa param in Params) {
                      item= context.Empresas.Where(x => x.Id_Empresa == param.Id_Empresa).SingleOrDefault();     
                      list.Remove(item);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public int Guardar(Re_Usuario_Empresa item) {
            int Val = 0;
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.Id_Re_Usuario_Empresas > 0)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }
                    else {
                        context.Entry(item).State = EntityState.Added;
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
            Re_Usuario_Empresa param;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    param = context.Re_Usuario_Empresa.Where(x => x.Id_Re_Usuario_Empresas == id).SingleOrDefault();
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
    public class Empleados {
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
    public class EmpresasSocias
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
