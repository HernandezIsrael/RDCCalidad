using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public  class MarcaHelper
    {

        public List<Ca_Marca> ListarMarcas() {
            List<Ca_Marca> list = new List<Ca_Marca>();
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    list = context.Ca_Marca.OrderBy(x => x.Marca).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Ca_Marca ObtenerMarca(int id)
        {
            Ca_Marca list = new Ca_Marca();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (id == 0) return list;
                    list = context.Ca_Marca.Where(x=> x.Id_Marca==id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public int Guardar(Ca_Marca item)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (item.Id_Marca > 0)
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
