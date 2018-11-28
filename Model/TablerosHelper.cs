using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
   public class TablerosHelper
    {
        public List<spSelVUltimosSaldos2_Result> ListarUltimosSaldos(int id) {
            List<spSelVUltimosSaldos2_Result> Items = new List<spSelVUltimosSaldos2_Result>();
            try
            {
                if (id == 0) return Items;
                using (ClusmextContext context= new ClusmextContext()) {
                    Items = context.spSelVUltimosSaldos2(id).ToList();
                }
            }
            catch (Exception ex) {

            }
            return Items;
        }
        public List<spSelMovimientos_Result> ListMovimientos(int id) {
            List<spSelMovimientos_Result> items = new List<spSelMovimientos_Result>();
            try{
                using (ClusmextContext context = new ClusmextContext()) {
                    items = context.spSelMovimientos(id).ToList();
                }
            }
            catch (Exception ex) {
            }
            return items;
        }
        public List<spSelMovimientos2_Result> ListMovimientos2(int id)
        {
            List<spSelMovimientos2_Result> items = new List<spSelMovimientos2_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.spSelMovimientos2(id).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public List<spSelPromedioSaldos_Result> ListPromedioSaldo(int id) {
            List<spSelPromedioSaldos_Result> items = new List<spSelPromedioSaldos_Result>();
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    items = context.spSelPromedioSaldos(id).ToList();
                }
            }
            catch (Exception ex) {
            }
            return items;
        }
        public List<V_Proyectos> ListProyectos() {
            List<V_Proyectos> list = new List<V_Proyectos>();
            try{
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.V_Proyectos.Where(x => x.Fecha_Fin.Value.Year == DateTime.Now.Year).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public List<V_Rubros_Proyecto> ListRubros(int id)
        {
            List<V_Rubros_Proyecto> list = new List<V_Rubros_Proyecto>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.V_Rubros_Proyecto.Where(x => x.Id_Proyecto == id).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public List<spSelHistoricoPagos_Result> ListHistorico(DateTime fini,DateTime ffin) {
            List<spSelHistoricoPagos_Result> list = new List<spSelHistoricoPagos_Result>();
            try{
                using (ClusmextContext context= new ClusmextContext()) {
                    list = context.spSelHistoricoPagos(fini, ffin).ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public List<string> Colores() {
            List<string> items = new List<string>();
            items.Add("#00a8b5");
            items.Add("#774898");
            items.Add("#e62a76");
            items.Add("#fbb901");
            items.Add("#f30e5c");
            items.Add("#f6f3a7");
            items.Add("#f6c523");
            items.Add("#228c7b");
            items.Add("#2b4353");
            items.Add("#e8630a");
            items.Add("#9cd3d3");
            items.Add("#57a99a");
            items.Add("#555151");
            items.Add("#76dbd1");
            items.Add("#4f323b");
            items.Add("#6e5773");
            items.Add("#ea9085");
            items.Add("#ff5959");
            items.Add("#ffad5a");
            items.Add("#4f9da6");
            items.Add("#1a0841");
            items.Add("#7b3c3c");
            items.Add("#db5f29");
            items.Add("#182952");
            items.Add("#2b3595");
            items.Add("#7045af");
            items.Add("#e14594");
            items.Add("#ffd96a");
            items.Add("#f34949");
            items.Add("#ff9090");
            items.Add("#ffb6b9");
            items.Add("#ff9900");
            items.Add("#ca431d");
            items.Add("#8b104e");
            items.Add("#520556");
            items.Add("#232931");
            items.Add("#f73859");
            items.Add("#e9290f");
            items.Add("#c40018");
            items.Add("#e1eb71");
            return items;
        }


    }
}
