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
    
    public partial class Co_Entrada_Salidas
    {
        public int Id_Entrada_Salidas { get; set; }
        public Nullable<int> Id_Tipo_Movimiento { get; set; }
        public Nullable<int> Id_Contrato { get; set; }
        public string Entregado_A { get; set; }
        public Nullable<int> Id_Medio { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Referencia { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}