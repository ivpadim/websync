using System;
using System. Collections.Generic ;

namespace websync
{
	public partial class Operacion
	{
		public string IdPortafolio { get; set ; }
		public int IdOperacion { get; set ; }
		public DateTime FechaOperacion { get; set; }
		public DateTime FechaValor { get; set; }
		public string TipoOperacion { get; set ; }
		public string IdDivisaBase { get; set ; }
		public string IdDivisaOperada { get; set ; }
		public string EstatusDivisaBase { get; set ; }
		public string EstatusDivisaOperada { get; set ; }
		public double MontoDivisa { get; set ; }
		public double MontoDivisaOperada { get; set ; }
		public double TipoCambio { get; set ; }
		public string IdProductoBase { get; set ; }
		public string IdProductoOperado { get; set ; }
		public int IdCliente { get; set ; }
		public int IdUnidadNegocio { get; set ; }
		public string IdClienteOpera { get; set ; }
		public string Promotor { get; set ; }
		public bool MesaCambios { get; set ; }
		public bool AdministracionRiesgos { get; set ; }
		public bool Contraloria { get; set ; }
		public bool Cumplimiento { get; set ; }
		public bool AreaComercial { get; set ; }
		public bool FacturaGenerada {get;set;}
		public bool FacturaPorLiquidacion {get;set;}
		public string Notas {get;set;}
		public DateTime FechaCreacion { get; set; }
		public DateTime? FechaActualizacion { get; set ; }
		public virtual ICollection< OperacionDetalle> Liquidaciones { get ; set; }
	}
	
	public partial class OperacionDetalle
	{
		public string IdPortafolio { get; set ; }
		public int IdOperacion { get; set ; }
		public string IdDivisa { get; set ; }
		public int IdLiquidacion { get; set ; }
		public DateTime? FechaLiquidacion { get; set ; }
		public int IdFormaLiquidacion { get; set ; }
		public string FormaLiquidacion { get; set ; }
		public double Monto { get; set ; }
		public string Destinatario { get; set ; }
		public string Banco { get; set ; }
		public string Plaza { get; set ; }
		public string Cuenta { get; set ; }
		public string Aba { get; set ; }
		public string Ordenante { get; set ; }
		public string RfcCurp { get; set ; }
		public string IntermediarioCuenta { get; set ; }
		public string IntermediarioBanco { get; set ; }
		public string IntermediarioPlaza { get; set ; }
		public string Status { get; set ; }
		public string RecibeEntrega { get; set ; }
		public bool Conciliado { get; set ; }
		public DateTime FechaCreacion { get; set; }
		public DateTime? FechaActualizacion { get; set ; }
		public virtual Operacion Operacion { get ; set; }
	}
}

