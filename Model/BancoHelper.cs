using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class BancoHelper
    {
        public List<Ca_Bancos> ListBancos()
        {
            List<Ca_Bancos> list = new List<Ca_Bancos>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Bancos.OrderBy(x => x.Banco).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public Ca_Bancos ObtenerBanco(int id)
        {
            Ca_Bancos cabanco = new Ca_Bancos();
            try
            {
                if (id == 0) return cabanco;
                using (ClusmextContext context = new ClusmextContext())
                {
                    cabanco = context.Ca_Bancos.Where(x => x.Id_Banco == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return cabanco;
        }
        public int Guardar(Ca_Bancos item)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {

                    if (item.Id_Banco > 0)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                    else
                    {
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
