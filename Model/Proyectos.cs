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
    
    public partial class Proyectos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proyectos()
        {
            this.Ca_N_Cuenta = new HashSet<Ca_N_Cuenta>();
            this.Ca_Clabe = new HashSet<Ca_Clabe>();
            this.CODOLE = new HashSet<CODOLE>();
            this.Contratos = new HashSet<Contratos>();
            this.Responsable_Proyecto = new HashSet<Responsable_Proyecto>();
            this.Rubros_Proyectos = new HashSet<Rubros_Proyectos>();
        }
    
        public int Id_Proyecto { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public string Proyecto { get; set; }
        public Nullable<int> Id_Institucion { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public bool Activo { get; set; }
        public Nullable<decimal> Financiamiento { get; set; }
        public Nullable<System.DateTime> Fecha_Inicio { get; set; }
        public Nullable<System.DateTime> Fecha_Fin { get; set; }
        public Nullable<int> Id_Moneda { get; set; }
        public Nullable<decimal> Financiamiento_Ext { get; set; }
        public string Codigo { get; set; }
        public Nullable<int> Id_Banco { get; set; }
        public Nullable<int> Id_N_Cuenta { get; set; }
    
        public virtual Ca_Bancos Ca_Bancos { get; set; }
        public virtual Ca_Instituciones Ca_Instituciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ca_N_Cuenta> Ca_N_Cuenta { get; set; }
        public virtual Empresas Empresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ca_Clabe> Ca_Clabe { get; set; }
        public virtual Ca_N_Cuenta Ca_N_Cuenta1 { get; set; }
        public virtual Ca_Moneda Ca_Moneda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CODOLE> CODOLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contratos> Contratos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Responsable_Proyecto> Responsable_Proyecto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rubros_Proyectos> Rubros_Proyectos { get; set; }
    }
}
