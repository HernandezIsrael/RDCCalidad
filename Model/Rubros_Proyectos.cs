//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rubros_Proyectos
    {
        public int Id_Rubros_Proyectos { get; set; }
        public int Id_Proyecto { get; set; }
        public int Id_Empresa { get; set; }
        public Nullable<int> Id_Rubro { get; set; }
        public Nullable<decimal> Presupuesto_Interno { get; set; }
        public Nullable<decimal> Presupuesto_Externo { get; set; }
        public Nullable<int> Id_Moneda { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual Ca_Moneda Ca_Moneda { get; set; }
        public virtual Ca_Rubros Ca_Rubros { get; set; }
        public virtual Empresas Empresas { get; set; }
        public virtual Proyectos Proyectos { get; set; }
    }
}
