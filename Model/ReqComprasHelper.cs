using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Model
{
   public class ReqComprasHelper
    {
        public List<SpSelReqCompra_Result> ListReqCompra(int id) {
            List<SpSelReqCompra_Result> list = new List<SpSelReqCompra_Result>();
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.SpSelReqCompra(id).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
    }
}
