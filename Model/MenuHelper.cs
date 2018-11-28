using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class MenuHelper
    {
        
        public List<Menu> _Menu(int IdUserRol)
        {
            var List = new List<Menu>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    List = context.Menu.Include("Grupos_Menu").Where(x => x.Id_Tipo_Usuario == IdUserRol && x.Activo == true && x.Controlador!=null).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return List;
        }


        public List<Menu> ListarMenuUsuario(int id, int TipoUsuario)
        {
            var List = new List<Menu>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    List = context.Menu.Include("Usuarios").Include("Grupos_Menu").Where(x => x.Id_Tipo_Usuario==TipoUsuario && x.Activo==true && x.Controlador!=null).OrderBy(x =>x.Grupos_Menu.Grupo).ToList();
                }
            }
            catch(Exception ex) { }
            return List;
        }
        public List<Menu> ListarMenu()
        {
            var List = new List<Menu>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    List = context.Menu.Include("Usuarios").Include("Grupos_Menu").ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return List;
        }

        public Menu ObtenerMenu (int id,int idusuario, int idTipoUsuario)
        {        
            Menu ObtenMenu= new Menu ();
            try
            {
                if (id == 0) {
                    ObtenMenu.Id_Usuario = idusuario;
                    ObtenMenu.Id_Tipo_Usuario = idTipoUsuario;
                    return ObtenMenu;
                }
                using (ClusmextContext context = new ClusmextContext())
                {
                    ObtenMenu = context.Menu.Where(x => x.Id_Menu == id).SingleOrDefault();
                    ObtenMenu.Id_Usuario = idusuario;              
                }
            }
            catch (Exception ex)
            {
            }
            return ObtenMenu;        
        }


        public IEnumerable<Grupos_Menu> CmbCS()
        {
            List<Grupos_Menu> list = new List<Grupos_Menu>();
            Grupos_Menu item = new Grupos_Menu();
            item.Id_Menu_Grupo = -1;
            item.Grupo = "Seleccionar...";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {                   
                    list = context.Grupos_Menu.ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
            }

            return list;
        }

        public Menu ObtenGrupoMenu(int id,int idGrupo)
        {
            Menu ObtenMenu = new Menu();
            try
            {
                if (id == 0)
                    ObtenMenu.Id_Menu_Grupo = idGrupo;
                return ObtenMenu;
                using (ClusmextContext context = new ClusmextContext())
                {
                    ObtenMenu = context.Menu.Where(x => x.Id_Menu == id && x.Id_Menu_Grupo==idGrupo).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return ObtenMenu;
        }

        public int Guardar(Menu items)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (items.Id_Menu > 0)
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
            catch(Exception ex)
            {

            }
            return val;
        }        
    }
}
