using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class CSHelper
    {
        public List<Ca_CS> ListarCS() {
            List<Ca_CS> list = new List<Ca_CS>();
            try{
                using (ClusmextContext context= new ClusmextContext()) {
                    list = context.Ca_CS.Include("Usuarios").OrderBy(x => x.CS).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Ca_CS ObtenerCS(int id) {
            Ca_CS cs = new Ca_CS();
            try {
                using (ClusmextContext context= new ClusmextContext()) {
                    cs = context.Ca_CS.Where(x => x.Id_CS == id).SingleOrDefault();
                    if (id == 0) {
                        cs.Id_Usuario = -1;
                    }
                }
            }
            catch (Exception ex) {
            }
            return cs;
        }
        public IEnumerable<Usuarios> CmbCS()
        {
            List<Usuarios> list = new List<Usuarios>();
            Usuarios item = new Usuarios();
            item.Id_Usuario = -1;
            item.Nombre = "Seleccionar...";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Usuarios.ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }

            return list;
        }
        public int Guardar(Ca_CS cs) {
            int val = 0;
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (cs.Id_CS > 0)  {
                        context.Entry(cs).State = EntityState.Modified;
                    }
                    else {
                        context.Entry(cs).State = EntityState.Added;
                    }
                    val = context.SaveChanges();
                }
            }
            catch (Exception ex) {

            }
            return val;
        }
        public List<Usuarios> ListarSocios() {
            List<Usuarios> list = new List<Usuarios>();
            Usuarios a = new Usuarios();
            try
            {
                a.Id_Usuario = -1;
                a.Nombre = "Seleccionar...";
                using (ClusmextContext context=new ClusmextContext()) {
                    list = context.Usuarios.OrderBy(x => x.Nombre).ToList();
                    list.Add(a);
                }
            }
            catch (Exception ex) {
            }
            return list;
        }

    }
}
