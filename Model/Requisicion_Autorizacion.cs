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
    
    public partial class Requisicion_Autorizacion
    {
        public int Id_Requisicion_Autorizacion { get; set; }
        public Nullable<int> Creado_Por { get; set; }
        public Nullable<int> Usuario_Autorizado { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> Id_Requisicion_Compra { get; set; }
        public Nullable<int> Id_Area { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public Nullable<bool> Autorizado { get; set; }
    
        public virtual Requisicion_Compra Requisicion_Compra { get; set; }
    }
}
