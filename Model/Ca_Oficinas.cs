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
    
    public partial class Ca_Oficinas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ca_Oficinas()
        {
            this.Activo_Fijo = new HashSet<Activo_Fijo>();
        }
    
        public int Id_Oficina { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public Nullable<int> Id_Tipo_Oficina { get; set; }
        public Nullable<int> Id_Estatus_Oficina { get; set; }
        public string Contacto { get; set; }
        public string Correo { get; set; }
        public string Tel { get; set; }
        public Nullable<bool> Conacyt { get; set; }
        public string CP { get; set; }
        public string Calle { get; set; }
        public string Municipio { get; set; }
        public string NoInterior { get; set; }
        public string NoExterior { get; set; }
        public string Colonia { get; set; }
        public Nullable<int> Id_Estado { get; set; }
        public Nullable<int> Id_Pais { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activo_Fijo> Activo_Fijo { get; set; }
    }
}
