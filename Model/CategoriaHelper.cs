using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class CategoriaHelper
    {

        public List<Ca_Categoria> ListarCategorias() {

            List<Ca_Categoria> list = new List<Ca_Categoria>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.Ca_Categoria.OrderBy(x => x.Categoria).ToList();
                }
            }
            catch (Exception ex) {

            }
            return list;
        }
        public Ca_Categoria ObtenerCategoria(int id) {
            Ca_Categoria categoria = new Ca_Categoria();
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    categoria = context.Ca_Categoria.Where(x => x.Id_Categoria == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return categoria;
        }
        public int Guardar(Ca_Categoria categoria) {
            int val = 0;
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    if (categoria.Id_Categoria>0) {
                        context.Entry(categoria).State = EntityState.Modified;
                    }
                    else {
                        context.Entry(categoria).State = EntityState.Added;
                    }
                    val = context.SaveChanges();
                }
            }
            catch (Exception ex) {

            }
            return val;
        }
    }
}
