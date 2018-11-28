using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class MonedaHelper
    {

        public List<Ca_Moneda> ListarMonedas() {
            List<Ca_Moneda> list = new List<Ca_Moneda>();
            try {
                using (ClusmextContext context= new ClusmextContext()) {
                    list = context.Ca_Moneda.OrderBy(x => x.Moneda).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Ca_Moneda ObtenerMoneda(int id)
        {
            Ca_Moneda pesito = new Ca_Moneda();
            try
            {
                if (id == 0) return pesito;
                using (ClusmextContext context = new ClusmextContext())
                {
                    pesito = context.Ca_Moneda.Where(x => x.Id_Moneda == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return pesito;
        }
        public int Guardar(Ca_Moneda pesito)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (pesito.Id_Moneda > 0)
                    {
                        context.Entry(pesito).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(pesito).State = EntityState.Added;
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
