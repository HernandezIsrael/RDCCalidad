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
    
    public partial class Log_CODOLE
    {
        public int Id_Log_Codole { get; set; }
        public Nullable<int> Id_Estatus_Log { get; set; }
        public Nullable<int> Id_Codole { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Id_Tipo_Codole { get; set; }
        public Nullable<System.DateTime> F_Init { get; set; }
        public Nullable<System.DateTime> F_Fin { get; set; }
        public Nullable<System.DateTime> F_Firma { get; set; }
        public Nullable<int> Creado_por { get; set; }
        public Nullable<System.DateTime> F_Alta { get; set; }
        public Nullable<bool> Activo { get; set; }
        public string Observaciones { get; set; }
        public string Encargado_Firmas { get; set; }
        public string Codigo_Codole { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public Nullable<int> Id_Proveedor { get; set; }
        public Nullable<bool> Proyecto { get; set; }
        public Nullable<int> Id_Proyecto { get; set; }
        public Nullable<int> Id_Notaria { get; set; }
        public Nullable<int> Id_Notario { get; set; }
        public string Entregado_A { get; set; }
        public Nullable<int> Id_Medio { get; set; }
        public Nullable<System.DateTime> Fecha_Entrega { get; set; }
        public string Referencia_Entrega { get; set; }
        public Nullable<int> Id_Solicitado_por { get; set; }
        public Nullable<int> Id_Valido_por { get; set; }
        public Nullable<int> Id_Generado_por { get; set; }
        public Nullable<int> Id_Notaria_Interna { get; set; }
        public Nullable<int> Id_Notario_Interno { get; set; }
        public Nullable<bool> Indefinido { get; set; }
    }
}
