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
    
    public partial class DocumentosRPlancio
    {
        public int IdDocumentoRPlancio { get; set; }
        public int IdRPlancio { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Virtual { get; set; }
        public Nullable<int> IdTipoRPlancio { get; set; }
        public Nullable<int> Id_Ftp { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<bool> Sharepoint { get; set; }
        public Nullable<System.DateTime> ShFalta { get; set; }
        public Nullable<int> ShIdUsuario { get; set; }
        public Nullable<int> IdSistemasSh { get; set; }
    }
}