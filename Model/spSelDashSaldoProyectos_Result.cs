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
    
    public partial class spSelDashSaldoProyectos_Result
    {
        public int Id_Proyecto { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public string Razon_Social { get; set; }
        public string Proyecto { get; set; }
        public Nullable<int> Id_Institucion { get; set; }
        public string Institucion { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public string Nombre_Completo { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public bool Activo { get; set; }
        public Nullable<decimal> Financiamiento { get; set; }
        public Nullable<System.DateTime> Fecha_Inicio { get; set; }
        public Nullable<System.DateTime> Fecha_Fin { get; set; }
        public Nullable<int> Id_Moneda { get; set; }
        public string Moneda { get; set; }
        public string Codigo { get; set; }
        public Nullable<int> Id_Banco { get; set; }
        public string Banco { get; set; }
        public Nullable<int> Id_N_Cuenta { get; set; }
        public string N_Cuenta { get; set; }
        public Nullable<decimal> gasto { get; set; }
        public Nullable<decimal> Dif { get; set; }
        public Nullable<decimal> saldo { get; set; }
    }
}
