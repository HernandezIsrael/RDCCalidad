using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class TipoCodoleHelper
    {
        public List<Ca_Tipo_Codole> ListarTipos()
        {
            List<Ca_Tipo_Codole> list = new List<Ca_Tipo_Codole>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Tipo_Codole.OrderBy(x => x.Tipo_Codole).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public Ca_Tipo_Codole ObtenerTipo(int id)
        {
            Ca_Tipo_Codole list = new Ca_Tipo_Codole();
            try
            {
                if (id == 0) return list;
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Tipo_Codole.Where(x => x.Id_Tipo_Codole == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public int Guardar(Ca_Tipo_Codole item)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (item.Id_Tipo_Codole > 0)
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
