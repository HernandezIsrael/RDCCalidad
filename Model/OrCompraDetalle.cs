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
    
    public partial class OrCompraDetalle
    {
        public int IdOCompraDetalle { get; set; }
        public Nullable<int> IdOCompra { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Precio_Unitario { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> CreadoPor { get; set; }
        public Nullable<System.DateTime> FAlta { get; set; }
        public Nullable<int> IdMoneda { get; set; }
        public Nullable<int> IdUnidadMedida { get; set; }
    }
}
