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
    
    public partial class CaSistemasSh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaSistemasSh()
        {
            this.CaUrlSharepoint = new HashSet<CaUrlSharepoint>();
            this.LogSyncSharepoint = new HashSet<LogSyncSharepoint>();
        }
    
        public int IdSistemasSh { get; set; }
        public string Sistema { get; set; }
        public int Creado_por { get; set; }
        public System.DateTime F_Alta { get; set; }
        public bool Activo { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CaUrlSharepoint> CaUrlSharepoint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogSyncSharepoint> LogSyncSharepoint { get; set; }
    }
}
