using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class CondicionHelper
    {
        public List<Ca_Condicion> ListarCondiciones() {
            List<Ca_Condicion> list = new List<Ca_Condicion>();
            try{
                using (ClusmextContext context= new ClusmextContext()) {
                    list = context.Ca_Condicion.OrderBy(x => x.Condicion).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Ca_Condicion ObtenerCondicion(int id) {
            Ca_Condicion condicion = new Ca_Condicion();
            try {
                using (ClusmextContext context= new ClusmextContext()) {
                    condicion = context.Ca_Condicion.Where(x => x.Id_Condicion == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return condicion;
        }
        public int Guardar(Ca_Condicion condicion) {
            int val = 0;
            try {
                using (ClusmextContext context= new ClusmextContext()) {
                    if (condicion.Id_Condicion>0) {
                        context.Entry(condicion).State = EntityState.Modified;
                    }
                    else {
                        context.Entry(condicion).State = EntityState.Added;
                    }
                    val=context.SaveChanges();
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
    }
}
