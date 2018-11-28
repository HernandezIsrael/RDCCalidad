using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ManualesHelper
    {
        public List<Manuales> ListManuales()
        {
            List<Manuales> list = new List<Manuales>();

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Manuales.Include("Usuarios").Include("Menu").Include("CA_Areas").Include("ManualesTipoUsuarios").ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public Manuales GetInfoManual(int id)
        {
            Manuales m = new Manuales();

            if (id == 0)
            {
                m.IdManual = -1;
                m.IdArea = -1;
                m.IdMenu = -1;
                m.IdTipoUsuario = -1;
                return m;
            }

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    m = context.Manuales.Where(x => x.IdManual == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return m;
        }

        public int InsertManual(Manuales m, out int newID)
        {
            int val = 0;
            newID = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (m.IdManual > 0)
                    {
                        context.Entry(m).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(m).State = EntityState.Added;
                    }

                    val = context.SaveChanges();
                    if (val != 0)
                    {
                        newID = m.IdManual;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }



        public IEnumerable<CA_Areas> GetListAreas()
        {
            List<CA_Areas> list = new List<CA_Areas>();
            CA_Areas item = new CA_Areas();
            item.Id_CA_Area = -1;
            item.Nombre_Area = "* Selecciona el área a la que está destinado el manual";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.CA_Areas.OrderBy(x => x.Nombre_Area).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public IEnumerable<Menu> GetListMenu()
        {
            List<Menu> list = new List<Menu>();
            Menu item = new Menu();
            item.Id_Menu = -1;
            item.Menu1 = "* Selecciona el sistema para el que está destinado el manual";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Menu.Where(x => x.Activo == true).OrderBy(x => x.Menu1).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public IEnumerable<ManualesTipoUsuarios> GetManualesTipoUsuarios()
        {
            List<ManualesTipoUsuarios> list = new List<ManualesTipoUsuarios>();
            ManualesTipoUsuarios item = new ManualesTipoUsuarios();
            item.IdManualesTipoUsuario = -1;
            item.TipoUsuario = "* Selecciona el tipo de usuario para el que está pensado el manual";

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.ManualesTipoUsuarios.OrderBy(x => x.TipoUsuario).ToList();
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }
    }
}
