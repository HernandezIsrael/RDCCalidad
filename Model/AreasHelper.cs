using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class AreasHelper
    {
        public List<CA_Areas> ListAreas()
        {
            List<CA_Areas> List = new List<CA_Areas>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    List = context.CA_Areas.OrderBy(x => x.Nombre_Area).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return List;
        }
        public CA_Areas ObtenerArea(int id)
        {
            CA_Areas area = new CA_Areas();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    area = context.CA_Areas.Where(x => x.Id_CA_Area == id).SingleOrDefault();
                   
                }
            }
            catch (Exception)
            {

            }
            return area;
        }
        public int Guardar(CA_Areas areas)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    
                    if (areas.Id_CA_Area > 0)
                    {
                        context.Entry(areas).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(areas).State = EntityState.Added;
                    }
                   
                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }
        public bool Exist(CA_Areas areas) {
            bool val = false;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                  val=  context.CA_Areas.Any(x => x.Nombre_Area.Equals(areas.Nombre_Area));
                }
            }
            catch (Exception ex) { 
            }
            return val;
        }
    }
    
}
