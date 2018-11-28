using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
  public  class TipoTesoreriaHelper
    {
        public List<CaTipoTesoreria> ListarTiposTesoreria() {
            List<CaTipoTesoreria> list = new List<CaTipoTesoreria>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.CaTipoTesoreria.OrderBy(x => x.TipoTesoreria).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public CaTipoTesoreria ObtenerTipoTesoreria(int id) {
            CaTipoTesoreria item = new CaTipoTesoreria();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.CaTipoTesoreria.Where(x => x.IdTipoTesoreria == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public int Guardar(CaTipoTesoreria item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.IdTipoTesoreria > 0)
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
