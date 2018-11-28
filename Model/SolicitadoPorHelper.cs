using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class SolicitadoPorHelper
    {
        public List<Ca_Solicitado_por> ListarSolicitados() {
            List<Ca_Solicitado_por> list = new List<Ca_Solicitado_por>();
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    list=context.Ca_Solicitado_por.OrderBy(x => x.Solicitado_por).ToList();
                }
            }
            catch (Exception ex) {

            }
            return list;
        }
        public Ca_Solicitado_por ObtenerSolicitados(int id)
        {
            Ca_Solicitado_por list = new Ca_Solicitado_por();
            try
            {
                if (id == 0) return list;
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Solicitado_por.Where(x => x.Id_Solicitado_por == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { 
            }
            return list;
        }
        public int Guardar(Ca_Solicitado_por item)
        {
            int val = 0;
            
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (item.Id_Solicitado_por > 0)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                    else {
                        context.Entry(item).State = EntityState.Added;
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
