using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class PaisHelper
    {

        public List<Ca_Pais> ListarPaises() {
            List<Ca_Pais> list = new List<Ca_Pais>();
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.Ca_Pais.Include("Ca_Estado").OrderBy(x => x.Pais).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Ca_Pais ObtenerPais(int id) {
            Ca_Pais pais = new Ca_Pais();
            try {
                if (id == 0) return pais;
                using (ClusmextContext context = new ClusmextContext()) {
                    pais = context.Ca_Pais.Where(x => x.Id_Pais == id).SingleOrDefault();

                }

            } catch (Exception ex) {
            }
            return pais;
        }
        public Ca_Estado ObtenerEstado(int id,int idpais) {
            Ca_Estado edo = new Ca_Estado();
            try{
                if (id == 0) {
                    edo.Id_Pais = idpais;
                    return edo; }
                using (ClusmextContext context= new ClusmextContext()) {
                    edo = context.Ca_Estado.Where(x => x.Id_Estado == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return edo;
        }
        public List<Ca_Estado> Listarestados(int id) {
            List<Ca_Estado> list = new List<Ca_Estado>();
            try {
                using (ClusmextContext context= new ClusmextContext()) {
                    list = context.Ca_Estado.Where(x => x.Id_Pais == id).OrderBy(x=> x.Estado).ToList();
                }
            } catch (Exception ex) {
            }
            return list;

        }
        public int Guardar(Ca_Pais pais) {
            int val = 0;
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (pais.Id_Pais>0) {
                        context.Entry(pais).State = EntityState.Modified;
                    } else {
                        context.Entry(pais).State = EntityState.Added;
                    }
                    val = context.SaveChanges();
                }
            } catch (Exception ex) {
            }
            return val;
        }
        public int GuardarEstado(Ca_Estado edo)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (edo.Id_Estado > 0)
                    {
                        context.Entry(edo).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(edo).State = EntityState.Added;
                    }
                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return val;
        }
    }
}
