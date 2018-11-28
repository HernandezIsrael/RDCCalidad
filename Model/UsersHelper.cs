using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Model
{
   public class UsersHelper
    {



        public Usuarios Login(string User, string Pass)
        {
            Usuarios Exist = new Usuarios();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    Exist = context.Usuarios.Where(x => x.Usuario == User && x.Pass == Pass).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return Exist;
        }
         public Usuarios ObtenerUsuario(int id)
        {
            Usuarios Exist = new Usuarios();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    Exist = context.Usuarios.Where(x => x.Id_Usuario==id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return Exist;
        }
        public static int Photo()
        {
            Random rd = new Random();
            int photo = rd.Next(14, 25);
            return photo;
        }

    }
}
