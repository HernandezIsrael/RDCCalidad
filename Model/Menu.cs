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
    
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            this.Manuales = new HashSet<Manuales>();
        }
    
        public int Id_Menu { get; set; }
        public Nullable<int> Id_Menu_Grupo { get; set; }
        public Nullable<int> Id_Usuario { get; set; }
        public string Menu1 { get; set; }
        public string URL { get; set; }
        public Nullable<int> Orden { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public bool Activo { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Id_Tipo_Usuario { get; set; }
        public string Controlador { get; set; }
    
        public virtual Grupos_Menu Grupos_Menu { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manuales> Manuales { get; set; }
    }
}
