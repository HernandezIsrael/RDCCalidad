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
    
    public partial class TaksTipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaksTipo()
        {
            this.TaksAdmon = new HashSet<TaksAdmon>();
        }
    
        public int IdTaksTipo { get; set; }
        public string TaksTipo1 { get; set; }
        public Nullable<int> Creadopor { get; set; }
        public Nullable<System.DateTime> FAlta { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaksAdmon> TaksAdmon { get; set; }
    }
}
