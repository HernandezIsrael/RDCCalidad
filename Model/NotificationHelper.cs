using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NotificationHelper
    {

        public int InsertNotification(Notifications notification)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (notification.IdNotification > 0)
                    {
                        context.Entry(notification).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(notification).State = EntityState.Added;
                    }

                    val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public int InsertAndGetNotification(Notifications notification, out int newID)
        {
            int val = 0;
            newID = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (notification.IdNotification > 0)
                    {
                        context.Entry(notification).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(notification).State = EntityState.Added;
                    }

                    val = context.SaveChanges();
                    if (val != 0)
                        newID = notification.IdNotification;
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }

        public List<Notifications> GetNotifications(int userID)
        {
            var list = new List<Notifications>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.Notifications.Include("Usuarios").Include("Usuarios1").Where(x => x.EnviadoA == userID && x.Activo).OrderByDescending(x => x.IdNotification).Take(10).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public Notifications GetNotification(int id)
        {
            Notifications n = new Notifications();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    n = context.Notifications.Where(x => x.IdNotification == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return n;
        }

        public int ClearNotification(Notifications n)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (n.IdNotification > 0)
                    {
                        context.Entry(n).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(n).State = EntityState.Added;
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