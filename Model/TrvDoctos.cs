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
    
    public partial class TrvDoctos
    {
        public int IdTrvDoctos { get; set; }
        public int IdTrvReq { get; set; }
        public string Nombre { get; set; }
        public string NombreVirtual { get; set; }
        public int Id_ftp { get; set; }
        public System.DateTime FAlta { get; set; }
        public int Creadopor { get; set; }
        public bool Activo { get; set; }
    }
}