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
    
    public partial class CA_Areas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CA_Areas()
        {
            this.TaksAdmon = new HashSet<TaksAdmon>();
            this.Manuales = new HashSet<Manuales>();
        }
    
        public int Id_CA_Area { get; set; }
        public string Nombre_Area { get; set; }
        public Nullable<System.DateTime> Fecha_Creado { get; set; }
        public bool Activo { get; set; }
        public Nullable<int> Creado_Por { get; set; }
        public Nullable<int> Id_Tipo_Usuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaksAdmon> TaksAdmon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manuales> Manuales { get; set; }
    }
}
