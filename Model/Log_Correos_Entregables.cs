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
    
    public partial class Log_Correos_Entregables
    {
        public int Id_Log_Correos_Entregables { get; set; }
        public Nullable<System.DateTime> F_Envio { get; set; }
        public Nullable<int> Id_Reporte_Factura { get; set; }
        public Nullable<int> Id_Solicitado_por { get; set; }
        public string Archivo { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}
