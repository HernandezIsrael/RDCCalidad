﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Model
{
    public class CalidadHelper
    {
        public List<spSelRProcesos_Result> ListProcesos() {
            List<spSelRProcesos_Result> list = new List<spSelRProcesos_Result>();
            try {
                using (ClusmextContext context = new ClusmextContext()) {
                    list = context.spSelRProcesos().ToList();
                }
            }
            catch (Exception ex) {
            }
            return list;
        }
        public RProcesos ObtenerProc(int id) {
            RProcesos item = new RProcesos();
            try
            {
                if (id == 0) return item;
                using (ClusmextContext context = new ClusmextContext()) {
                    item = context.RProcesos.Where(x => x.IdRProcesos == id).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return item;
        }

        public IEnumerable<TiposCal> DatatSourceTipoCal()
        {
            List<TiposCal> items = new List<TiposCal>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.CaTipoRProcesos.Where(x => x.Activo == true)
                        .Select(x => new TiposCal { Id = x.IdTipoRProcesos, NombreCompleto = x.TipoRProcesos }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public IEnumerable<EmpConta> DatatSourceEmpresas()
        {
            List<EmpConta> items = new List<EmpConta>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.Empresas.Where(x => x.Activo == true)
                        .Select(x => new EmpConta { Id = x.Id_Empresa, NombreCompleto = x.Razon_Social }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public IEnumerable<TProyectos> DatatSourceProyectos(int id)
        {
            List<TProyectos> items = new List<TProyectos>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.spSelProyectos_Empresas(id).Where(x => x.Activo == true)
                        .Select(x => new TProyectos { Id = x.Id_Proyecto, NombreCompleto = x.Proyecto }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public IEnumerable<TSolicitado> DatatSourceSolicitado()
        {
            List<TSolicitado> items = new List<TSolicitado>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.Ca_Solicitado_por.Where(x => x.Activo == true)
                        .Select(x => new TSolicitado { Id = x.Id_Solicitado_por, NombreCompleto = x.Solicitado_por }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public IEnumerable<TSolicitado> DatatSourceUsCal()
        {
            List<TSolicitado> items = new List<TSolicitado>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    items = context.spSelUsuariosProc()
                        .Select(x => new TSolicitado { Id = x.Id_Usuario, NombreCompleto = x.Nombre }).OrderBy(x => x.NombreCompleto).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
        public List<spSelDocumentosProcs_Result> ListDocumentos(int id)
        {
            List<spSelDocumentosProcs_Result> list = new List<spSelDocumentosProcs_Result>();
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    list = context.spSelDocumentosProcs(id).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public int Guardar(RProcesos item)
        {
            int Val = 0;
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    if (item.IdRProcesos > 0)
                        context.Entry(item).State = EntityState.Modified;
                    else
                        context.Entry(item).State = EntityState.Added;
                    Val = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return Val;
        }
        public bool spInsDocumentosRProcesos(int id, string Nombre, int IdUser, int IdTipo, out string NVV)
        {
            bool Val = false;
            NVV = string.Empty;
            ObjectParameter NV = new ObjectParameter("Nombre_Virtual", typeof(String));
            ObjectParameter VV = new ObjectParameter("VValor_Mensaje", typeof(Int32));
            ObjectParameter IDD = new ObjectParameter("IdDocumentosRProcesos", typeof(Int32));
            ObjectParameter VM = new ObjectParameter("VMensaje", typeof(String));
            try
            {
                using (ClusmextContext context = new ClusmextContext())
                {
                    context.spInsDocumentosRProcesos(Nombre, 1, IdUser, id, IdTipo, NV, IDD, VV, VM);
                    if (VV.Value.ToString() == "0")
                    {
                        NVV = NV.Value.ToString();
                        Val = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Val;
        }


    }
}
public class TiposCal
{
    private int id;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    private string nombrecompleto;
    public string NombreCompleto
    {
        get { return nombrecompleto; }
        set { nombrecompleto = value; }
    }
}

