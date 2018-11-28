using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HomeHelper
    {
        public Usuarios GetUserInfo(int id)
        {
            Usuarios u = new Usuarios();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    u = context.Usuarios.Where(x => x.Id_Usuario == id).SingleOrDefault();
                }
            }
            catch(Exception ex)
            {

            }
            return u;
        }

        public List<NewsFeed> GetNews()
        {
            List<NewsFeed> nf = new List<NewsFeed>();

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    nf = context.NewsFeed.ToList();
                }
            }
            catch(Exception ex)
            {

            }

            return nf;
        }

        public int UpdateNewsFeed(NewsFeed i)
        {
            int val = 0;
            int newID = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (i.IdItem > 0)
                    {
                        context.Entry(i).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(i).State = EntityState.Added;
                    }

                    val = context.SaveChanges();
                    newID = i.IdItem;
                }
            }
            catch (Exception ex)
            {

            }

            return newID;
        }

        public NewsFeed GetNewById(int id = 0)
        {
            NewsFeed s = new NewsFeed();

            if (id == 0)
            {
                s.IdItem = -1;
                //s.Descripcion = "Empty";
                return s;
            }

            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    s = context.NewsFeed.Where(x => x.IdItem == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return s;
        }
    }
}
