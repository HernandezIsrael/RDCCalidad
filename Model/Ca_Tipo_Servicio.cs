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
    
    public partial class Ca_Tipo_Servicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ca_Tipo_Servicio()
        {
            this.Capacidades_Servicios = new HashSet<Capacidades_Servicios>();
            this.SEDirecciones = new HashSet<SEDirecciones>();
            this.Servicios = new HashSet<Servicios>();
        }
    
        public int Id_tipo_servicio { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime F_Alta { get; set; }
        public int Creado_por { get; set; }
        public bool Activo { get; set; }
        public string Tipo_Servicio { get; set; }
        public string CodigoServicio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Capacidades_Servicios> Capacidades_Servicios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEDirecciones> SEDirecciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servicios> Servicios { get; set; }
    }
}
