using Domain.Integrity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class VoucherDetail : IHorizontalCheckDigit
    {
        [Key, Required]
        public Guid ID { get; set; }
        [Display(Name = "Comprobante")]
        public Guid Voucher_ID { get; set; }
        [ForeignKey("Voucher_ID")]
        public virtual Voucher Voucher { get; set; }
        [Required, SensitiveData, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        [Display(Name = "Linea")]
        public int Line { get; set; }
        [SensitiveData, Required]
        [Display(Name = "Articulo")]
        public Guid Article_ID { get; set; }
        [ForeignKey("Article_ID")]
        public virtual Article Article { get; set; }
        [SensitiveData, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        [Display(Name = "Motivo")]
        public int? RejectionType_ID { get; set; }
        [NotMapped]
        public RejectionType RejectionType { get; set; }
        [RegularExpression("^[0-9]*$")]
        [Display(Name = "Pallet")]
        public Guid? Pallet_ID { get; set; }
        [ForeignKey("Pallet_ID")]
        public virtual Pallet Pallet { get; set; }
        public byte[] DVH { get; set; }
    }
}
