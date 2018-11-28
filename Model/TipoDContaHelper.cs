using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class TipoDContaHelper
    {
        public List<CaTipoRConta> ListarTipoConta() {
            List<CaTipoRConta> list = new List<CaTipoRConta>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.CaTipoRConta.OrderBy(x => x.TipoRConta).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public CaTipoRConta ObtenerTipoConta(int id) {
            CaTipoRConta item = new CaTipoRConta();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.CaTipoRConta.Where(x => x.IdTipoRConta == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public int Guardar(CaTipoRConta item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.IdTipoRConta > 0)
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
