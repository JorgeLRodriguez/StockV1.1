using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class VoucherDetail
    {
		[Key, Required]
		public int ID { get; set; }
		[RegularExpression("^[0-9]*$")]
		//[Display(Name = ConstantesTexto.Comprobante)]
		public int Voucher_ID { get; set; }
		[ForeignKey("Voucher_ID")]
		public virtual Voucher Voucher { get; set; }
		//[Required, DatoSensible, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
		//[Display(Name = ConstantesTexto.Linea)]
		public int Line { get; set; }
		//[DatoSensible, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue), Required]
		//[Display(Name = ConstantesTexto.Articulo)]
		public int Article_ID { get; set; }
		[ForeignKey("Article_ID")]
		public virtual Article Article { get; set; }
		//[DatoSensible, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
		//[Display(Name = ConstantesTexto.Cantidad)]
		public int quantity { get; set; }
		[RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
		//[Display(Name = ConstantesTexto.Motivo)]
		public int? RejectionType_ID { get; set; }
		[NotMapped]
		public RejectionType RejectionType { get; set; }
		[RegularExpression("^[0-9]*$")]
		//[Display(Name = "Pallet")]
		//public int? Pallet_ID { get; set; }
		//[ForeignKey("Pallet_ID")]
		//public virtual Pallet Pallet { get; set; }
		public byte[] DVH { get; set; }
	}
}
