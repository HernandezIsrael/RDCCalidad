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
    
    public partial class TrvRepConceptos
    {
        public int IdTrvRepConceptos { get; set; }
        public int IdTrvReq { get; set; }
        public int IdTrvConceptos { get; set; }
        public decimal Monto { get; set; }
        public Nullable<int> Id_Moneda { get; set; }
        public Nullable<int> Creadopor { get; set; }
        public Nullable<System.DateTime> FAlta { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual Ca_Moneda Ca_Moneda { get; set; }
        public virtual TrvConceptos TrvConceptos { get; set; }
        public virtual TrvReq TrvReq { get; set; }
    }
}
