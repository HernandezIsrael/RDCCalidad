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
    
    public partial class RDC
    {
        public int Id_RDC { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Virtual { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> Creado_Por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public Nullable<int> Id_Area { get; set; }
        public string Version { get; set; }
    }
}