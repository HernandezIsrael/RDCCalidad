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
    
    public partial class spSelVUsuariosPlaneacion_Result
    {
        public int Id_Usuario { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Id_Tipo_Usuario { get; set; }
        public string Tipo_Usuario { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public bool Activo { get; set; }
        public string Email { get; set; }
    }
}
