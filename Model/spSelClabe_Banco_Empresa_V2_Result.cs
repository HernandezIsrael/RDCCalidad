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
    
    public partial class spSelClabe_Banco_Empresa_V2_Result
    {
        public int Id_Clabe { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public string Razon_Social { get; set; }
        public string RFC { get; set; }
        public Nullable<int> Id_Banco { get; set; }
        public string Banco { get; set; }
        public string N_Cuenta { get; set; }
        public string N_Clabe { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public bool Activo { get; set; }
    }
}