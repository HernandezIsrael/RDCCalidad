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
    
    public partial class TaksPertenencia
    {
        public int IdTaksPertenencia { get; set; }
        public int IdTaks { get; set; }
        public int Id_Usuario { get; set; }
        public Nullable<int> Creadopor { get; set; }
        public Nullable<System.DateTime> FAlta { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<bool> Autorizar { get; set; }
    
        public virtual TaksAdmon TaksAdmon { get; set; }
    }
}
