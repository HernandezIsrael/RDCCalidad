using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class TipoVinculacionesHelper
    {
        public List<CaTipoRVinculaciones> ListarTipoVinculaciones() {
            List<CaTipoRVinculaciones> list = new List<CaTipoRVinculaciones>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.CaTipoRVinculaciones.OrderBy(x => x.TipoRVinculaciones).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public CaTipoRVinculaciones ObtenerTipo(int id) {
            CaTipoRVinculaciones item = new CaTipoRVinculaciones();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.CaTipoRVinculaciones.Where(x => x.IdTipoRVinculaciones == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public int Guardar(CaTipoRVinculaciones item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.IdTipoRVinculaciones>0) {
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
