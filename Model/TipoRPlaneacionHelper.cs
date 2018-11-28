using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class TipoRPlaneacionHelper
    {
        public List<CaTipoRPlancio> ListarTiposPlancio() {
            List<CaTipoRPlancio> list = new List<CaTipoRPlancio>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.CaTipoRPlancio.OrderBy(x => x.TipoRPlancio).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public CaTipoRPlancio ObtenerTipo(int id)
        {
            CaTipoRPlancio item = new CaTipoRPlancio();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext())
                {
                    item = context.CaTipoRPlancio.Where(x => x.IdTipoRPlancio == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return item;
        }
        public int Guardar(CaTipoRPlancio item)
        {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (item.IdTipoRPlancio > 0)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(item).State = EntityState.Added;
                    }
                    Val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return Val;
        }
    }
}
