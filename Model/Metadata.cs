using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class CA_AreasMetadata
    {
        [Required(ErrorMessage = "El campo area es obligatorio")]
        public string Nombre_Area { get; set; }
    }
    public class Ca_CategoriaMetadata {
        [Required(ErrorMessage ="El campo categoria es obligatorio")]
        public string Categoria { get; set; }
    }
    public class Ca_CondicionMetadata
    {
        [Required(ErrorMessage ="El campo codición es obligatorio")]
        public string Condicion { get; set; }
    }
    public class Ca_CSMetadata {
        [Required(ErrorMessage = "El campo codición es obligatorio")]
        public int CS { get; set; }
        [Required(ErrorMessage = "El campo socio es obligatorio")]
        public Nullable<int> Id_Usuario { get; set; }
    }

    public class Ca_PaisMetadata {
        [Required(ErrorMessage ="El campo pais es obligatorio")]
        public string Pais { get; set; }

    }
    public class Ca_EstadoMetadata
    {
        [Required(ErrorMessage = "El campo estado es obligatorio")]
        public string Estado { get; set; }

    }
    public class Ca_InstitucionesMetadata
    {
        [Required(ErrorMessage = "El campo Institución es obligatorio")]
        public string Institucion { get; set; }

    }
    public class Ca_MarcaMetadata {
        [Required(ErrorMessage = "El campo marca es obligatorio")]
        public string Marca { get; set; }
    }
    public class Ca_Medio_EntregaMetadata {
        [Required(ErrorMessage = "El campo medio es obligatorio")]
        public string Medio { get; set; }
    }
    public class Ca_MonedaMetadata {
        [Required(ErrorMessage ="El campo moneda es obligatorio")]
        public string Moneda { get; set; }
    }

    public class Ca_BancosMetadata
    {
        [Required(ErrorMessage = "El campo Banco es obligatorio")]
        public string Banco { get; set; }
    }
    public class Ca_RubrosMetadata
    {
        [Required(ErrorMessage = "El campo codigo es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo rubro es obligatorio")]
        public string Rubro { get; set; }
    }
    

    public class Ca_Solicitado_porMetadata {
        [Required(ErrorMessage = "El campo solicitado es obligatorio")]
        public string Solicitado_por { get; set; }
        [Required(ErrorMessage = "El campo solicitado es obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El correo no es valido")]
        [EmailAddress]
        public string Email { get; set; }
    }
    public class Ca_Tipo_CodoleMetadata
    {
        [Required(ErrorMessage = "El campo tipo es obligatorio")]
        public string Tipo_Codole { get; set; }
    }
    public class Ca_Tipo_ContratoMetadata {
        [Required(ErrorMessage = "El campo tipo es obligatorio")]
        public string Tipo_Contrato { get; set; }
    }
    public class Ca_Tipo_PagoMetadata {
        [Required(ErrorMessage = "El campo tipo de pago es obligatorio")]
        public string Tipo_Pago { get; set; }
    }
    public class Ca_Tipo_ServicioMetadata {
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo Tipo de servicio es obligatorio")]
        public string Tipo_Servicio { get; set; }
        [Required(ErrorMessage = "El campo Código es obligatorio")]
        public string CodigoServicio { get; set; }
    }

    public class CaTipoRContaMetadata {
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public string TipoRConta { get; set; }
    }
    public class CaTipoREjecucionMetadata {
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public string TipoREjecucion { get; set; }
    }
    public class CaTipoRPlancioMetadata {
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public string TipoRPlancio { get; set; }
    }
    public class CaTipoRProcesosMetadata {
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public string TipoRProcesos { get; set; }
    }
    public class CaTipoRRHHDMetadata {
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public string TipoRRHHD { get; set; } 
    }
    public class CaTipoRVinculacionesMetadata {
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public string TipoRVinculaciones { get; set; }
    }
    public class CaTipoTesoreriaMetadata {
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public string TipoTesoreria { get; set; }

    }
    public class EmpresasMetadata {

        [Required(ErrorMessage = "El campo Razón Social es obligatorio")]
        public string Razon_Social { get; set; }
        [Required(ErrorMessage = "El campo R.F.C es obligatorio")]
        [RegularExpression("[A-Z]{3,4}\\d{6}(\\w|\\d){3}", ErrorMessage ="El formato del R.F.C es invalido")]
        public string RFC { get; set; }



        [Required(ErrorMessage = "El campo C.P es obligatorio")]
        public string CP { get; set; }
        [Required(ErrorMessage = "El campo Calle es obligatorio")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "El campo Municipio es obligatorio")]
        public string Municipio { get; set; }
        [Required(ErrorMessage = "El campo No Exterior es obligatorio")]
        public string NoExterior { get; set; }
        [Required(ErrorMessage = "El campo Colonia es obligatorio")]
        public string Colonia { get; set; }
        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public Nullable<int> Id_Estado { get; set; }
        [Required(ErrorMessage = "El campo País es obligatorio")]
        public Nullable<int> Id_Pais { get; set; }
        
    }

    public class TaksAdmonMetadata
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Asunto { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Id_Empresa { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string IdTaksTipo { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string IdEstatusTaks { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Descripcion { get; set; }
    }

    public class Ca_N_CuentaMetadata {
        [Required(ErrorMessage = "El campo Banco es obligatorio")]
        public Nullable<int> Id_Banco { get; set; }
      
        [Required(ErrorMessage = "El campo No Cuenta es obligatorio")]
        public string N_Cuenta { get; set; }
        [Required(ErrorMessage = "El campo Moneda es obligatorio")]
        public Nullable<int> Id_Moneda { get; set; }
        
    }

    public class Ca_ClabeMetadata
    {
        [Required(ErrorMessage = "El campo Banco es obligatorio")]
        public Nullable<int> Id_Banco { get; set; }
        [Required(ErrorMessage = "El campo No Cuenta es obligatorio")]
        public string N_Clabe { get; set; }
        [Required(ErrorMessage = "El campo Moneda es obligatorio")]
        public Nullable<int> Id_Moneda { get; set; }

    }
    public class ProyectosMetadata {
        [Required(ErrorMessage = "El campo Empresa es obligatorio")]
        public Nullable<int> Id_Empresa { get; set; }
        [Required(ErrorMessage = "El campo Proyecto es obligatorio")]
        public string Proyecto { get; set; }
        [Required(ErrorMessage = "El campo Codigo es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo Programa es obligatorio")]
        public Nullable<int> Id_Institucion { get; set; }
        [Required(ErrorMessage = "El campo Fecha de inicio es obligatorio")]
        public Nullable<System.DateTime> Fecha_Inicio { get; set; }
        [Required(ErrorMessage = "El campo Fecha fin es obligatorio")]
        public Nullable<System.DateTime> Fecha_Fin { get; set; }
        [Required(ErrorMessage = "El campo Financiamiento es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = true)]

        public Nullable<decimal> Financiamiento { get; set; }
        [Required(ErrorMessage = "El campo Moneda es obligatorio")]
        public Nullable<int> Id_Moneda { get; set; }
        [Required(ErrorMessage = "El campo Banco es obligatorio")]
        public Nullable<int> Id_Banco { get; set; }
        [Required(ErrorMessage = "El campo No Cuenta es obligatorio")]
        public Nullable<int> Id_N_Cuenta { get; set; }
        
        
      
     
       
       
      

    
    }

    public class ServiciosMetadata {
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string NReferencia { get; set; }
    }
}
