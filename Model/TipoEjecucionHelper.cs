using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class TipoEjecucionHelper
    {
        public List<CaTipoREjecucion> ListarTiposDocumentos() {
            List<CaTipoREjecucion> list = new List<CaTipoREjecucion>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.CaTipoREjecucion.OrderBy(x => x.TipoREjecucion).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public CaTipoREjecucion ObetenerTipoEjecucion(int id) {
            CaTipoREjecucion item = new CaTipoREjecucion();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context= new ClusmextContext()) {
                    item = context.CaTipoREjecucion.Where(x => x.IdTipoREjecucion == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public int Guardar(CaTipoREjecucion item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    if (item.IdTipoREjecucion > 0)
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
