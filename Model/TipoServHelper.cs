using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class TipoServHelper
    {


        public List<Ca_Tipo_Servicio> ListarTipoServicios()
        {
            List<Ca_Tipo_Servicio> list = new List<Ca_Tipo_Servicio>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Tipo_Servicio.OrderBy(x => x.Tipo_Servicio).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public Ca_Tipo_Servicio ObtenerServicio(int id)
        {
            Ca_Tipo_Servicio serv = new Ca_Tipo_Servicio();
            try
            {
                if (id == 0) return serv;
                using (ClusmextContext context = new ClusmextContext())
                {
                    serv = context.Ca_Tipo_Servicio.Where(x => x.Id_tipo_servicio == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return serv;
        }
        public int Guardar(Ca_Tipo_Servicio serv)
        {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (serv.Id_tipo_servicio > 0)
                    {
                        context.Entry(serv).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(serv).State = EntityState.Added;
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
