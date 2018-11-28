using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class TipoPagoHelper
    {

        public List<Ca_Tipo_Pago> ListarTipoPagos() {
            List<Ca_Tipo_Pago> list = new List<Ca_Tipo_Pago>();
            try
            {
                using (ClusmextContext context= new ClusmextContext()) {
                    list = context.Ca_Tipo_Pago.OrderBy(x => x.Tipo_Pago).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Ca_Tipo_Pago ObtenerTipoPago(int id) {
            Ca_Tipo_Pago item = new Ca_Tipo_Pago();
            try {
                if (id == 0) return item;
                using (ClusmextContext context= new ClusmextContext()) {
                    item = context.Ca_Tipo_Pago.Where(x => x.Id_Tipo_Pago == id).SingleOrDefault();
                }
            }catch(Exception ex)
            {

            }
            return item;
        }
        public int Guardar(Ca_Tipo_Pago Item) {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    if (Item.Id_Tipo_Pago > 0)
                    {
                        context.Entry(Item).State = EntityState.Modified;
                    }
                    else {
                        context.Entry(Item).State = EntityState.Added;
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
