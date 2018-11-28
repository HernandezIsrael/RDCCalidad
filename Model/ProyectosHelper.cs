using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class ProyectosHelper
    {
        public List<Proyectos> ListarProyectos(int id) {
            List<Proyectos> list = new List<Proyectos>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.Proyectos.Include("Ca_Instituciones").Include("Ca_N_Cuenta1").Include("Ca_Moneda").Include("Ca_Bancos").Where(x=> x.Id_Empresa==id).OrderBy(x => x.Proyecto).ToList();
                    
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Proyectos ObtenerProyecto(int id) {
            Proyectos item = new Proyectos();
            try
            {
                if (id == 0) {
                    item.Id_Moneda = 1;
                    return item;
                } 
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.Proyectos.Where(x => x.Id_Proyecto == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public IEnumerable<AliasBancos> DataSourceBancos(int id,int idmon)
        {
            List<AliasBancos> list = new List<AliasBancos>();
            AliasBancos item;    
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_N_Cuenta.Include("Ca_Bancos").Where(x => x.Activo == true && x.Id_Moneda == idmon && x.Id_Empresa == id)
                        .GroupBy(x => new { x.Ca_Bancos.Id_Banco, x.Ca_Bancos.Banco })
                        .Select(x => new AliasBancos { Id = x.Key.Id_Banco, Banco = x.Key.Banco }).ToList();
                      
                    item = new AliasBancos();
                    item.Id = -1;
                    item.Banco = "Selccionar...";
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list.OrderBy(x=> x.Banco);
        }
        public IEnumerable<AliasCuentas> DataSourceCuenta(int idempresa,int idbanco,int idmoneda)
        {
            List<AliasCuentas> list = new List<AliasCuentas>();
            AliasCuentas item;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_N_Cuenta.Where(x => x.Id_Empresa == idempresa && x.Id_Banco == idbanco && x.Id_Moneda== idmoneda && x.Activo==true)
                        .Select(x => new AliasCuentas { Id = x.Id_N_Cuenta, Cuenta = x.N_Cuenta }).ToList();
                    item = new AliasCuentas();
                    item.Id = -1;
                    item.Cuenta = "Seleccionar...";
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            return list.OrderBy(x=> x.Cuenta);
        }
        public IEnumerable<TypeMoney> DataSourceMonedas()
        {
            List<TypeMoney> list = new List<TypeMoney>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Moneda.Where(x=> x.Activo==true)
                        .Select(x=> new TypeMoney { Id= x.Id_Moneda, Money= x.Moneda }).OrderBy(x=> x.Money).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public IEnumerable<ItemsProgramas> DataSourceProgramas()
        {
            List<ItemsProgramas> list = new List<ItemsProgramas>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Instituciones.Where(x => x.Activo == true)
                        .Select(x => new ItemsProgramas { Id = x.Id_Institucion, Programa = x.Institucion }).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public int Guardar(Proyectos Item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (Item.Id_Proyecto > 0)
                    {
                        context.Entry(Item).State = EntityState.Modified;
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
    }
    public class AliasCuentas
    {
        private int id;
        public int Id
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
    public class ItemsProgramas {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string programa;
        public string Programa
        {
            get { return programa; }
            set { programa = value; }
        }
    }
    public class TypeMoney
    {
        private int id;
        public int Id
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
    public class AliasBancos {
        private int id;
        public int Id
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
}
