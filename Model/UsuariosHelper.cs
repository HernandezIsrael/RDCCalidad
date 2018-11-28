using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class UsuariosHelper
    {
        public List<Usuarios> ListarUsuarios()
        {
            var List = new List<Usuarios>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                    List = context.Usuarios.Where(x => x.Activo == true).ToList();
            }
            catch(Exception ex)
            {

            }
            return List;
        }

        public int Guardar(Usuarios items)
        {
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (items.Id_Usuario > 0)
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

        public Usuarios ObtenerUsuario (int id)
        {
            Usuarios users = new Usuarios();
            try
            {
                if (id == 0) return users;
                using (ClusmextContext context = new ClusmextContext())
                {
                    users = context.Usuarios.Where(x => x.Id_Usuario == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return users;

        }
    }
}
