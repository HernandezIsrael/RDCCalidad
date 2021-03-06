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
    
    public partial class Ca_N_Cuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ca_N_Cuenta()
        {
            this.Proyectos1 = new HashSet<Proyectos>();
            this.MovimientosBancosCsv = new HashSet<MovimientosBancosCsv>();
            this.Pagos = new HashSet<Pagos>();
            this.Pagos1 = new HashSet<Pagos>();
        }
    
        public int Id_N_Cuenta { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public Nullable<int> Id_Banco { get; set; }
        public string N_Cuenta { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public bool Activo { get; set; }
        public Nullable<int> Id_Moneda { get; set; }
        public Nullable<int> Id_Proyecto { get; set; }
    
        public virtual Ca_Bancos Ca_Bancos { get; set; }
        public virtual Ca_Moneda Ca_Moneda { get; set; }
        public virtual Empresas Empresas { get; set; }
        public virtual Proyectos Proyectos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyectos> Proyectos1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovimientosBancosCsv> MovimientosBancosCsv { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pagos> Pagos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pagos> Pagos1 { get; set; }
    }
}
