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
    
    public partial class Ca_Contratos
    {
        public int Id_Contrato { get; set; }
        public string Codigo_contrato { get; set; }
        public string Contrato { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public Nullable<int> Id_Proveedor { get; set; }
        public Nullable<int> Id_Proyecto { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}
