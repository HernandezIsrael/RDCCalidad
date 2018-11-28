using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class TipoRRHHHelper
    {
        public List<CaTipoRRHHD> ListarTiposRRHHH() {
            List<CaTipoRRHHD> list = new List<CaTipoRRHHD>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.CaTipoRRHHD.OrderBy(x => x.TipoRRHHD).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public CaTipoRRHHD ObtenerTipo(int id) {
            CaTipoRRHHD item = new CaTipoRRHHD();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.CaTipoRRHHD.Where(x => x.IdTipoRRHHD == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public int Guardar(CaTipoRRHHD item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.IdTipoRRHHD > 0)
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
