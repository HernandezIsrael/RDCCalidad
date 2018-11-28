using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
namespace Model
{
   public class NURCCPHelper
    {
        public List<spSelPagos_Programados_Result> LisPagos() {
            List<spSelPagos_Programados_Result> list = new List<spSelPagos_Programados_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSelPagos_Programados().OrderByDescending(x=> x.Id_Pago).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public Pagos ObetnerNurc(int id) {
            Pagos item = new Pagos();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.Pagos.Where(x=> x.Id_Pago==id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }
        public int Cancelar(Pagos item) {
            int val = 0;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    context.spPupAutorizaciones_Pago(item.Id_Pago, 4, item.Comentarios, item.Creado_por, false, VV, VM);
                    if (VV.Value.ToString() == "0")
                        val = 1;
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        public int spInsDocumento_Pago(string FileName,int IdUser,int IdPago,int IdTipoDocto,out string NombreV) {
            int val = 0;
            NombreV = string.Empty;
            ObjectParameter NV = new ObjectParameter("Nombre_Virtual", typeof(String));
            ObjectParameter IDD = new ObjectParameter("Id_Documento", typeof(Int32));
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                context.spInsDocumento_Pago(FileName, 1, IdUser, IdPago, IdTipoDocto, NV, IDD, VV, VM);
                    if (VV.Value.ToString() == "0")
                    {
                        NombreV = NV.Value.ToString();
                        val = 1;
                    }
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        public int spPupEstatusPagoCambio(Pagos item) {
            int val = 0;
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    context.spPupEstatusPagoCambio(item.Id_Pago, item.F_Pago, item.N_Transferencia, item.Creado_por, item.Cambio, VV, VM);
                    if (VV.Value.ToString() == "0")
                        val = 1;
                }
            }
            catch (Exception ex) {
            }
            return val;
        }

    }
   
}
