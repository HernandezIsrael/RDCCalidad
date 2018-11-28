using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AutoIngresosHelper
    {
        public List<spSelPagosAutoTesoreria_Result> ListPagos(int id) {
            List<spSelPagosAutoTesoreria_Result> list = new List<spSelPagosAutoTesoreria_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSelPagosAutoTesoreria(id).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Pagos ObtenerPagos(int id) {
            Pagos item = new Pagos();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.Pagos.Where(x=> x.Id_Pago==id).SingleOrDefault();
                } 
            }
            catch (Exception ex) {
            }
            return item;
        }
        public int Guardar(Pagos item) {
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    val = context.spPupAutorizacionesPago2(item.Id_Pago, 10, string.Empty, item.Creado_por, true, VV, VM);
                    if (VV.Value.ToString() == "0")
                        val = 1;
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        public int Cancelar(Pagos item)
        {
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            int val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    val = context.spPupAutorizaciones_Pago(item.Id_Pago, 4, item.Comentarios, item.Creado_por, false, VV, VM);
                    if (VV.Value.ToString() == "0")
                        val = 1;
                }
            }
            catch (Exception ex)
            {
            }
            return val;
        }
    }
}
