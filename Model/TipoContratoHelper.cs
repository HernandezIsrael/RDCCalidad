using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class TipoContratoHelper
    {

        public List<Ca_Tipo_Contrato> ListarTipoContrato() {
            List<Ca_Tipo_Contrato> Items = new List<Ca_Tipo_Contrato>();
            try {
                using (ClusmextContext context= new ClusmextContext()) {
                    Items = context.Ca_Tipo_Contrato.OrderBy(x => x.Tipo_Contrato).ToList();
                }
            }
            catch (Exception ex) {
            }
            return Items;
        }
        public Ca_Tipo_Contrato ObtenerTipoContrato(int id) {
            Ca_Tipo_Contrato item = new Ca_Tipo_Contrato();
            try {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.Ca_Tipo_Contrato.Where(x => x.Id_Tipo_Contrato == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public int Guardar(Ca_Tipo_Contrato item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (item.Id_Tipo_Contrato > 0)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                    else {
                        context.Entry(item).State = EntityState.Added;
                    }
                    Val = context.SaveChanges();
                }
            }
            catch (Exception ex) {
            }
            return Val;
        }


    }
}
