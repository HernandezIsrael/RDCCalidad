using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GrupoMenuHelper
    {
        public List<Grupos_Menu> ListaGrupoMenu()
        {
            var List = new List<Grupos_Menu>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    List = context.Grupos_Menu.Where(x => x.Icon != null).OrderBy(x => x.Grupo).ToList();
                }

            }
            catch (Exception ex) { }
            return List;
        }

        public Grupos_Menu ObtenerGrupoMenu(int id)
        {            
            Grupos_Menu ObtenGrupo = new Grupos_Menu();
            try
            {
                if (id == 0) return ObtenGrupo;
                using(ClusmextContext context=new ClusmextContext())
                {
                    ObtenGrupo = context.Grupos_Menu.Where(x => x.Id_Menu_Grupo == id).SingleOrDefault();
                }
            }
            catch (Exception ex){ }
            return ObtenGrupo;
        }

        public int Guardar(Grupos_Menu items)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (items.Id_Menu_Grupo > 0)
                    {
                        context.Entry(items).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(items).State = System.Data.Entity.EntityState.Added;
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
