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
    
    public partial class LogEventosSh
    {
        public int IdError { get; set; }
        public string Estatus { get; set; }
        public string CodigoError { get; set; }
        public string Mensaje { get; set; }
        public string Modulo { get; set; }
        public string URL { get; set; }
        public Nullable<int> IdDocumento { get; set; }
        public string Documento { get; set; }
        public int Id_Usuario { get; set; }
        public int Creadopor { get; set; }
        public Nullable<System.DateTime> FAlta { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}
