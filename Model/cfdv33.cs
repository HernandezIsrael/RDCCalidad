﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// Este código fuente fue generado automáticamente por xsd, Versión=4.6.1055.0.
// 


/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.sat.gob.mx/cfd/3", IsNullable=false)]
public partial class Comprobante {
    
    private ComprobanteCfdiRelacionados cfdiRelacionadosField;
    
    private ComprobanteEmisor emisorField;
    
    private ComprobanteReceptor receptorField;
    
    private ComprobanteConcepto[] conceptosField;
    
    private ComprobanteImpuestos impuestosField;
    
    private ComprobanteComplemento[] complementoField;
    
    private ComprobanteAddenda addendaField;
    
    private string versionField;
    
    private string serieField;
    
    private string folioField;
    
    private System.DateTime fechaField;
    
    private string selloField;
    
    private c_FormaPago formaPagoField;
    
    private bool formaPagoFieldSpecified;
    
    private string noCertificadoField;
    
    private string certificadoField;
    
    private string condicionesDePagoField;
    
    private decimal subTotalField;
    
    private decimal descuentoField;
    
    private bool descuentoFieldSpecified;
    
    private c_Moneda monedaField;
    
    private decimal tipoCambioField;
    
    private bool tipoCambioFieldSpecified;
    
    private decimal totalField;
    
    private c_TipoDeComprobante tipoDeComprobanteField;
    
    private c_MetodoPago metodoPagoField;
    
    private bool metodoPagoFieldSpecified;
    
   // private c_CodigoPostal lugarExpedicionField;
    
    private string confirmacionField;
    
    public Comprobante() {
        this.versionField = "3.3";
    }
    
    /// <comentarios/>
    public ComprobanteCfdiRelacionados CfdiRelacionados {
        get {
            return this.cfdiRelacionadosField;
        }
        set {
            this.cfdiRelacionadosField = value;
        }
    }
    
    /// <comentarios/>
    public ComprobanteEmisor Emisor {
        get {
            return this.emisorField;
        }
        set {
            this.emisorField = value;
        }
    }
    
    /// <comentarios/>
    public ComprobanteReceptor Receptor {
        get {
            return this.receptorField;
        }
        set {
            this.receptorField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Concepto", IsNullable=false)]
    public ComprobanteConcepto[] Conceptos {
        get {
            return this.conceptosField;
        }
        set {
            this.conceptosField = value;
        }
    }
    
    /// <comentarios/>
    public ComprobanteImpuestos Impuestos {
        get {
            return this.impuestosField;
        }
        set {
            this.impuestosField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Complemento")]
    public ComprobanteComplemento[] Complemento {
        get {
            return this.complementoField;
        }
        set {
            this.complementoField = value;
        }
    }
    
    /// <comentarios/>
    public ComprobanteAddenda Addenda {
        get {
            return this.addendaField;
        }
        set {
            this.addendaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Version {
        get {
            return this.versionField;
        }
        set {
            this.versionField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Serie {
        get {
            return this.serieField;
        }
        set {
            this.serieField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Folio {
        get {
            return this.folioField;
        }
        set {
            this.folioField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime Fecha {
        get {
            return this.fechaField;
        }
        set {
            this.fechaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Sello {
        get {
            return this.selloField;
        }
        set {
            this.selloField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_FormaPago FormaPago {
        get {
            return this.formaPagoField;
        }
        set {
            this.formaPagoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool FormaPagoSpecified {
        get {
            return this.formaPagoFieldSpecified;
        }
        set {
            this.formaPagoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NoCertificado {
        get {
            return this.noCertificadoField;
        }
        set {
            this.noCertificadoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Certificado {
        get {
            return this.certificadoField;
        }
        set {
            this.certificadoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CondicionesDePago {
        get {
            return this.condicionesDePagoField;
        }
        set {
            this.condicionesDePagoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal SubTotal {
        get {
            return this.subTotalField;
        }
        set {
            this.subTotalField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Descuento {
        get {
            return this.descuentoField;
        }
        set {
            this.descuentoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DescuentoSpecified {
        get {
            return this.descuentoFieldSpecified;
        }
        set {
            this.descuentoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_Moneda Moneda {
        get {
            return this.monedaField;
        }
        set {
            this.monedaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TipoCambio {
        get {
            return this.tipoCambioField;
        }
        set {
            this.tipoCambioField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TipoCambioSpecified {
        get {
            return this.tipoCambioFieldSpecified;
        }
        set {
            this.tipoCambioFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Total {
        get {
            return this.totalField;
        }
        set {
            this.totalField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_TipoDeComprobante TipoDeComprobante {
        get {
            return this.tipoDeComprobanteField;
        }
        set {
            this.tipoDeComprobanteField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_MetodoPago MetodoPago {
        get {
            return this.metodoPagoField;
        }
        set {
            this.metodoPagoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool MetodoPagoSpecified {
        get {
            return this.metodoPagoFieldSpecified;
        }
        set {
            this.metodoPagoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    //[System.Xml.Serialization.XmlAttributeAttribute()]
    //public c_CodigoPostal LugarExpedicion {
    //    get {
    //        return this.lugarExpedicionField;
    //    }
    //    set {
    //        this.lugarExpedicionField = value;
    //    }
    //}
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Confirmacion {
        get {
            return this.confirmacionField;
        }
        set {
            this.confirmacionField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteCfdiRelacionados {
    
    private ComprobanteCfdiRelacionadosCfdiRelacionado[] cfdiRelacionadoField;
    
    private c_TipoRelacion tipoRelacionField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("CfdiRelacionado")]
    public ComprobanteCfdiRelacionadosCfdiRelacionado[] CfdiRelacionado {
        get {
            return this.cfdiRelacionadoField;
        }
        set {
            this.cfdiRelacionadoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_TipoRelacion TipoRelacion {
        get {
            return this.tipoRelacionField;
        }
        set {
            this.tipoRelacionField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteCfdiRelacionadosCfdiRelacionado {
    
    private string uUIDField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UUID {
        get {
            return this.uUIDField;
        }
        set {
            this.uUIDField = value;
        }
    }
}



/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteEmisor {
    
    private string rfcField;
    
    private string nombreField;
    
    private c_RegimenFiscal regimenFiscalField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Rfc {
        get {
            return this.rfcField;
        }
        set {
            this.rfcField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Nombre {
        get {
            return this.nombreField;
        }
        set {
            this.nombreField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_RegimenFiscal RegimenFiscal {
        get {
            return this.regimenFiscalField;
        }
        set {
            this.regimenFiscalField = value;
        }
    }
}


/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteReceptor {
    
    private string rfcField;
    
    private string nombreField;
    
    private c_Pais residenciaFiscalField;
    
    private bool residenciaFiscalFieldSpecified;
    
    private string numRegIdTribField;
    
    private c_UsoCFDI usoCFDIField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Rfc {
        get {
            return this.rfcField;
        }
        set {
            this.rfcField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Nombre {
        get {
            return this.nombreField;
        }
        set {
            this.nombreField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_Pais ResidenciaFiscal {
        get {
            return this.residenciaFiscalField;
        }
        set {
            this.residenciaFiscalField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ResidenciaFiscalSpecified {
        get {
            return this.residenciaFiscalFieldSpecified;
        }
        set {
            this.residenciaFiscalFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NumRegIdTrib {
        get {
            return this.numRegIdTribField;
        }
        set {
            this.numRegIdTribField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_UsoCFDI UsoCFDI {
        get {
            return this.usoCFDIField;
        }
        set {
            this.usoCFDIField = value;
        }
    }
}
/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConcepto {
    
    private ComprobanteConceptoImpuestos impuestosField;
    
    private ComprobanteConceptoInformacionAduanera[] informacionAduaneraField;
    
    private ComprobanteConceptoCuentaPredial cuentaPredialField;
    
    private ComprobanteConceptoComplementoConcepto complementoConceptoField;
    
    private ComprobanteConceptoParte[] parteField;
    
   // private c_ClaveProdServ claveProdServField;
    
    private string noIdentificacionField;
    
    private decimal cantidadField;
    
    private c_ClaveUnidad claveUnidadField;
    
    private string unidadField;
    
    private string descripcionField;
    
    private decimal valorUnitarioField;
    
    private decimal importeField;
    
    private decimal descuentoField;
    
    private bool descuentoFieldSpecified;
    
    /// <comentarios/>
    public ComprobanteConceptoImpuestos Impuestos {
        get {
            return this.impuestosField;
        }
        set {
            this.impuestosField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("InformacionAduanera")]
    public ComprobanteConceptoInformacionAduanera[] InformacionAduanera {
        get {
            return this.informacionAduaneraField;
        }
        set {
            this.informacionAduaneraField = value;
        }
    }
    
    /// <comentarios/>
    public ComprobanteConceptoCuentaPredial CuentaPredial {
        get {
            return this.cuentaPredialField;
        }
        set {
            this.cuentaPredialField = value;
        }
    }
    
    /// <comentarios/>
    public ComprobanteConceptoComplementoConcepto ComplementoConcepto {
        get {
            return this.complementoConceptoField;
        }
        set {
            this.complementoConceptoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Parte")]
    public ComprobanteConceptoParte[] Parte {
        get {
            return this.parteField;
        }
        set {
            this.parteField = value;
        }
    }
    
    /// <comentarios/>
    //[System.Xml.Serialization.XmlAttributeAttribute()]
    //public c_ClaveProdServ ClaveProdServ {
    //    get {
    //        return this.claveProdServField;
    //    }
    //    set {
    //        this.claveProdServField = value;
    //    }
    //}
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NoIdentificacion {
        get {
            return this.noIdentificacionField;
        }
        set {
            this.noIdentificacionField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Cantidad {
        get {
            return this.cantidadField;
        }
        set {
            this.cantidadField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_ClaveUnidad ClaveUnidad {
        get {
            return this.claveUnidadField;
        }
        set {
            this.claveUnidadField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Unidad {
        get {
            return this.unidadField;
        }
        set {
            this.unidadField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Descripcion {
        get {
            return this.descripcionField;
        }
        set {
            this.descripcionField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal ValorUnitario {
        get {
            return this.valorUnitarioField;
        }
        set {
            this.valorUnitarioField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe {
        get {
            return this.importeField;
        }
        set {
            this.importeField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Descuento {
        get {
            return this.descuentoField;
        }
        set {
            this.descuentoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DescuentoSpecified {
        get {
            return this.descuentoFieldSpecified;
        }
        set {
            this.descuentoFieldSpecified = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoImpuestos {
    
    private ComprobanteConceptoImpuestosTraslado[] trasladosField;
    
    private ComprobanteConceptoImpuestosRetencion[] retencionesField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable=false)]
    public ComprobanteConceptoImpuestosTraslado[] Traslados {
        get {
            return this.trasladosField;
        }
        set {
            this.trasladosField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable=false)]
    public ComprobanteConceptoImpuestosRetencion[] Retenciones {
        get {
            return this.retencionesField;
        }
        set {
            this.retencionesField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoImpuestosTraslado {
    
    private decimal baseField;
    
    private c_Impuesto impuestoField;
    
    private c_TipoFactor tipoFactorField;
    
    private decimal tasaOCuotaField;
    
    private bool tasaOCuotaFieldSpecified;
    
    private decimal importeField;
    
    private bool importeFieldSpecified;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Base {
        get {
            return this.baseField;
        }
        set {
            this.baseField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_Impuesto Impuesto {
        get {
            return this.impuestoField;
        }
        set {
            this.impuestoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_TipoFactor TipoFactor {
        get {
            return this.tipoFactorField;
        }
        set {
            this.tipoFactorField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TasaOCuota {
        get {
            return this.tasaOCuotaField;
        }
        set {
            this.tasaOCuotaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TasaOCuotaSpecified {
        get {
            return this.tasaOCuotaFieldSpecified;
        }
        set {
            this.tasaOCuotaFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe {
        get {
            return this.importeField;
        }
        set {
            this.importeField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ImporteSpecified {
        get {
            return this.importeFieldSpecified;
        }
        set {
            this.importeFieldSpecified = value;
        }
    }
}




/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoImpuestosRetencion {
    
    private decimal baseField;
    
    private c_Impuesto impuestoField;
    
    private c_TipoFactor tipoFactorField;
    
    private decimal tasaOCuotaField;
    
    private decimal importeField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Base {
        get {
            return this.baseField;
        }
        set {
            this.baseField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_Impuesto Impuesto {
        get {
            return this.impuestoField;
        }
        set {
            this.impuestoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_TipoFactor TipoFactor {
        get {
            return this.tipoFactorField;
        }
        set {
            this.tipoFactorField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TasaOCuota {
        get {
            return this.tasaOCuotaField;
        }
        set {
            this.tasaOCuotaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe {
        get {
            return this.importeField;
        }
        set {
            this.importeField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoInformacionAduanera {
    
    private string numeroPedimentoField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NumeroPedimento {
        get {
            return this.numeroPedimentoField;
        }
        set {
            this.numeroPedimentoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoCuentaPredial {
    
    private string numeroField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Numero {
        get {
            return this.numeroField;
        }
        set {
            this.numeroField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoComplementoConcepto {
    
    private System.Xml.XmlElement[] anyField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any {
        get {
            return this.anyField;
        }
        set {
            this.anyField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoParte {
    
    private ComprobanteConceptoParteInformacionAduanera[] informacionAduaneraField;
    
  //  private c_ClaveProdServ claveProdServField;
    
    private string noIdentificacionField;
    
    private decimal cantidadField;
    
    private string unidadField;
    
    private string descripcionField;
    
    private decimal valorUnitarioField;
    
    private bool valorUnitarioFieldSpecified;
    
    private decimal importeField;
    
    private bool importeFieldSpecified;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("InformacionAduanera")]
    public ComprobanteConceptoParteInformacionAduanera[] InformacionAduanera {
        get {
            return this.informacionAduaneraField;
        }
        set {
            this.informacionAduaneraField = value;
        }
    }
    
    /// <comentarios/>
    //[System.Xml.Serialization.XmlAttributeAttribute()]
    //public c_ClaveProdServ ClaveProdServ {
    //    get {
    //        return this.claveProdServField;
    //    }
    //    set {
    //        this.claveProdServField = value;
    //    }
    //}
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NoIdentificacion {
        get {
            return this.noIdentificacionField;
        }
        set {
            this.noIdentificacionField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Cantidad {
        get {
            return this.cantidadField;
        }
        set {
            this.cantidadField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Unidad {
        get {
            return this.unidadField;
        }
        set {
            this.unidadField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Descripcion {
        get {
            return this.descripcionField;
        }
        set {
            this.descripcionField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal ValorUnitario {
        get {
            return this.valorUnitarioField;
        }
        set {
            this.valorUnitarioField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ValorUnitarioSpecified {
        get {
            return this.valorUnitarioFieldSpecified;
        }
        set {
            this.valorUnitarioFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe {
        get {
            return this.importeField;
        }
        set {
            this.importeField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ImporteSpecified {
        get {
            return this.importeFieldSpecified;
        }
        set {
            this.importeFieldSpecified = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteConceptoParteInformacionAduanera {
    
    private string numeroPedimentoField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NumeroPedimento {
        get {
            return this.numeroPedimentoField;
        }
        set {
            this.numeroPedimentoField = value;
        }
    }
}




/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteImpuestos {
    
    private ComprobanteImpuestosRetencion[] retencionesField;
    
    private ComprobanteImpuestosTraslado[] trasladosField;
    
    private decimal totalImpuestosRetenidosField;
    
    private bool totalImpuestosRetenidosFieldSpecified;
    
    private decimal totalImpuestosTrasladadosField;
    
    private bool totalImpuestosTrasladadosFieldSpecified;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable=false)]
    public ComprobanteImpuestosRetencion[] Retenciones {
        get {
            return this.retencionesField;
        }
        set {
            this.retencionesField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable=false)]
    public ComprobanteImpuestosTraslado[] Traslados {
        get {
            return this.trasladosField;
        }
        set {
            this.trasladosField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TotalImpuestosRetenidos {
        get {
            return this.totalImpuestosRetenidosField;
        }
        set {
            this.totalImpuestosRetenidosField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TotalImpuestosRetenidosSpecified {
        get {
            return this.totalImpuestosRetenidosFieldSpecified;
        }
        set {
            this.totalImpuestosRetenidosFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TotalImpuestosTrasladados {
        get {
            return this.totalImpuestosTrasladadosField;
        }
        set {
            this.totalImpuestosTrasladadosField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TotalImpuestosTrasladadosSpecified {
        get {
            return this.totalImpuestosTrasladadosFieldSpecified;
        }
        set {
            this.totalImpuestosTrasladadosFieldSpecified = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteImpuestosRetencion {
    
    private c_Impuesto impuestoField;
    
    private decimal importeField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_Impuesto Impuesto {
        get {
            return this.impuestoField;
        }
        set {
            this.impuestoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe {
        get {
            return this.importeField;
        }
        set {
            this.importeField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteImpuestosTraslado {
    
    private c_Impuesto impuestoField;
    
    private c_TipoFactor tipoFactorField;
    
    private decimal tasaOCuotaField;
    
    private decimal importeField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_Impuesto Impuesto {
        get {
            return this.impuestoField;
        }
        set {
            this.impuestoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public c_TipoFactor TipoFactor {
        get {
            return this.tipoFactorField;
        }
        set {
            this.tipoFactorField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TasaOCuota {
        get {
            return this.tasaOCuotaField;
        }
        set {
            this.tasaOCuotaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe {
        get {
            return this.importeField;
        }
        set {
            this.importeField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteComplemento {
    
    private System.Xml.XmlElement[] anyField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any {
        get {
            return this.anyField;
        }
        set {
            this.anyField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteAddenda {
    
    private System.Xml.XmlElement[] anyField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any {
        get {
            return this.anyField;
        }
        set {
            this.anyField = value;
        }
    }
}