using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Model
{
   public class MedioEntregaHelper
    {
        public List<Ca_Medio_Entrega> ListarMedios() {
            List<Ca_Medio_Entrega> list = new List<Ca_Medio_Entrega>();
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    list = context.Ca_Medio_Entrega.OrderBy(x => x.Medio).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Ca_Medio_Entrega ObtrenerMedio(int id)
        {
            Ca_Medio_Entrega list = new Ca_Medio_Entrega();
            try
            {
                if (id == 0) return list;
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Medio_Entrega.Where(x => x.Id_Medio == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public int Guardar(Ca_Medio_Entrega entrega)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (entrega.Id_Medio > 0)
                    {
                        context.Entry(entrega).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(entrega).State = EntityState.Added;
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
