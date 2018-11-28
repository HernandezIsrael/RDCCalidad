using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class FinanciamientosHerlper
    {

        public List<Ca_Instituciones> ListarInstituciones() {
            List<Ca_Instituciones> list = new List<Ca_Instituciones>();
            try {
                using (ClusmextContext context= new ClusmextContext()) {
                    list = context.Ca_Instituciones.OrderBy(x => x.Institucion).ToList();
                }
            } catch (Exception ex) {
            }
            return list;
        }
        public Ca_Instituciones ObtenerInstitucion(int id)
        {
            Ca_Instituciones list = new Ca_Instituciones();
            try
            {
                if ( id == 0) return list;
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Instituciones.Where(x=>x.Id_Institucion==id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public int Guardar(Ca_Instituciones institucion)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (institucion.Id_Institucion > 0)
                    {
                        context.Entry(institucion).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(institucion).State = EntityState.Added;
                    }
                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return val;
        }
        public List<Ca_Rubros> ListarRubros(int id)
        {
            List<Ca_Rubros> list = new List<Ca_Rubros>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Rubros.Where(x => x.Id_Institucion==id).OrderBy(x=>x.Codigo).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public Ca_Rubros ObtenerRubro(int id,int idInst)
        {
            Ca_Rubros list = new Ca_Rubros();
            try
            {
                if (id == 0) {
                    list.Id_Institucion = idInst;
                    return list;
                }
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Ca_Rubros.Where(x => x.Id_Rubro == id).SingleOrDefault();
                    list.Id_Institucion = idInst;
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public int GuardarRubro(Ca_Rubros rb)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (rb.Id_Rubro > 0)
                    {
                        context.Entry(rb).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(rb).State = EntityState.Added;
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
