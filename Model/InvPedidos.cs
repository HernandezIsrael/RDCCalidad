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
    
    public partial class InvPedidos
    {
        public int IdPedido { get; set; }
        public string Item { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Tipo { get; set; }
        public Nullable<int> SubTipo { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<bool> Adquirido { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<System.DateTime> FAlta { get; set; }
        public Nullable<int> CreadoPor { get; set; }
        public Nullable<bool> Solicitado { get; set; }
        public Nullable<bool> WishList { get; set; }
        public Nullable<bool> Pedido { get; set; }
        public Nullable<int> Unidad { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> IdDocumento { get; set; }
        public Nullable<double> PrecioTotal { get; set; }
    }
}