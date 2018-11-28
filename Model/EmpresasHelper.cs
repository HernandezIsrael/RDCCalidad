using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class EmpresasHelper
    {
        public List<Empresas> ListarEmpresas() {
            List<Empresas> list = new List<Empresas>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.Empresas.Where(x=> x.Id_Tipo_Empresa==1).OrderBy(x => x.Razon_Social).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public List<Empresas> ListarProveedores()
        {
            List<Empresas> list = new List<Empresas>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Empresas.Where(x => x.Id_Tipo_Empresa == 2).OrderBy(x => x.Razon_Social).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public IEnumerable<Ca_Pais> DataSourcePais()
        {
            List<Ca_Pais> list = new List<Ca_Pais>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Pais.Where(x=> x.Activo==true).OrderBy(x=> x.Pais).ToList();
                }
            }
            catch (Exception ex)
            {
            }

            return list.OrderBy(x=> x.Pais);
        }
        public IEnumerable<Ca_Estado> DataSourceEstados(int id)
        {
            List<Ca_Estado> list = new List<Ca_Estado>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Estado.Where(x => x.Id_Pais==id && x.Activo == true).OrderBy(x => x.Estado).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public IEnumerable<Proyectos> DataSourceProyectos(int id) {
            List<Proyectos> list = new List<Proyectos>();
            Proyectos item = new Proyectos();
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.Proyectos.Where(x => x.Id_Empresa == id).OrderBy(x => x.Proyecto).ToList();
                    item.Id_Proyecto = -1;
                    item.Proyecto = "Sin Asignar";
                    list.Add(item);
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public IEnumerable<Ca_Bancos> DataSourceBancos()
        {
            List<Ca_Bancos> list = new List<Ca_Bancos>();
            Ca_Bancos item = new Ca_Bancos();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Bancos.OrderBy(x => x.Banco).ToList();
                    item.Banco = "Seleccionar...";
                    list.Add(item);
                    
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<Ca_Moneda> DataSourceMoendas()
        {
            List<Ca_Moneda> list = new List<Ca_Moneda>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Moneda.OrderBy(x => x.Moneda).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }


        public Empresas ObtenerEmpresa(int id) {
            Empresas item = new Empresas();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.Empresas.Where(x => x.Id_Empresa == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }


        public List<Ca_N_Cuenta> ListarCuentasEmpresa(int id) {
            List<Ca_N_Cuenta> list = new List<Ca_N_Cuenta>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.Ca_N_Cuenta.Include("Ca_Moneda").Include("Proyectos").Include("Ca_Bancos").Where(x =>  x.Id_Empresa == id).OrderBy(x => x.Ca_Bancos.Banco).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Ca_N_Cuenta ObtenerCuenta(int id,int IdEmpresa) {
            Ca_N_Cuenta item = new Ca_N_Cuenta();
            try
            {
                if (id == 0) {
                    item.Id_Empresa = IdEmpresa;
                    return item;
                }
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.Ca_N_Cuenta.Where(x => x.Id_N_Cuenta == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public Ca_Clabe ObtenerClabe(int id, int IdEmpresa)
        {
            Ca_Clabe item = new Ca_Clabe();
            try
            {
                if (id == 0)
                {
                    item.Id_Empresa = IdEmpresa;
                    return item;
                }
                using (ClusmextContext context = new ClusmextContext())
                {
                    item = context.Ca_Clabe.Where(x => x.Id_Clabe == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return item;
        }
        public List<Ca_Clabe> ListClabesEmpresa(int id)
        {
            List<Ca_Clabe> list = new List<Ca_Clabe>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Clabe.Include("Ca_Moneda").Include("Proyectos").Include("Ca_Bancos").Where(x => x.Id_Empresa == id ).OrderBy(x => x.Ca_Bancos.Banco).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public int GuardarCuenta(Ca_N_Cuenta item)
        {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (item.Id_N_Cuenta > 0)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(item).State = EntityState.Added;
                    }
                    Val = context.SaveChanges();
                    if (Val == 1)
                    {
                        Re_Bancos_Empresa re = new Re_Bancos_Empresa();
                        re.Id_Empresa = item.Id_Empresa;
                        re.Id_Banco = item.Id_Banco;
                        re.F_Alta = DateTime.Now;
                        re.Creado_por = item.Creado_por;
                        re.Activo = true;
                        Val = GuardarRelacion(re);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Val;
        }
        public int Guardarclabe(Ca_Clabe item)
        {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (item.Id_Clabe > 0)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(item).State = EntityState.Added;
                    }
                    Val = context.SaveChanges();
                    if (Val==1) {
                        Re_Bancos_Empresa re = new Re_Bancos_Empresa();
                        re.Id_Empresa = item.Id_Empresa;
                        re.Id_Banco = item.Id_Banco;
                        re.F_Alta = DateTime.Now;
                        re.Creado_por = item.Creado_por;
                        re.Activo = true;
                       Val= GuardarRelacion(re);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Val;
        }
        public int Guardar(Empresas item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.Id_Empresa > 0)
                    {
                        context.Entry(item).State = EntityState.Modified;
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
        public int GuardarRelacion(Re_Bancos_Empresa items) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                   context.Entry(items).State = EntityState.Added;
                    Val = context.SaveChanges();
                }
            }
            catch (Exception ex) {
            }
            return Val;
        }
    }
}
