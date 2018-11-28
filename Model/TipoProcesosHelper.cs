using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class TipoProcesosHelper
    {
        public List<CaTipoRProcesos> ListarProcesos() {
            List<CaTipoRProcesos> list = new List<CaTipoRProcesos>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.CaTipoRProcesos.OrderBy(x=> x.TipoRProcesos).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public CaTipoRProcesos ObtenerProceso(int id) {
            CaTipoRProcesos item = new CaTipoRProcesos();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.CaTipoRProcesos.Where(x => x.IdTipoRProcesos == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public int Guardar(CaTipoRProcesos item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.IdTipoRProcesos > 0)
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
    }
}
