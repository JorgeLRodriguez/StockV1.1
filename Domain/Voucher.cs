using Domain.Integrity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Voucher : IdentityBase, IHorizontalCheckDigit
    {
        [Required, SensitiveData]
        [Display(Name = "Cliente")]
        public Guid Client_ID { get; set; }
        [ForeignKey("Client_ID")]
        public virtual Client Client { get; set; }
        [Required, SensitiveData]
        [Display(Name = "Tipo")]
        public VoucherType VoucherType { get; set; }
        [Required, SensitiveData, StringLength(3, MinimumLength = 1)]
        [Display(Name = "Letra")]
        public string Letter { get; set; }
        [Required, SensitiveData, Range(1, 1)]
        [Display(Name = "Sucursal")]
        public int Branch { get; set; }
        [Required, SensitiveData, Range(1, int.MaxValue)]
        [Display(Name = "NumeroComprobante")]
        public int Number { get; set; }
        [SensitiveData, StringLength(10, MinimumLength = 1), RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        [Display(Name = "Remito")]
        public string InvoiceClientNumber { get; set; }
        [SensitiveData, Required]
        [Display(Name = "Fecha")]
        public DateTime? VoucherDate { get; set; }
        [SensitiveData]
        [Display(Name = "Cierre")]
        public string Closure { get; set; }
        [RegularExpression("^[0-9]*$"), Range(0, int.MaxValue)]
        [Display(Name = "Destinatario")]
        public Guid? Addressee_ID { get; set; }
        [ForeignKey("Addressee_ID")]
        public virtual Addressee Addressee { get; set; }
        [Display(Name = "Observacion")]
        public string Observations { get; set; }
        public byte[] DVH { get; set; }
        [NotMapped]
        public string Description
        {
            get
            {
                return VoucherType.ToString() + " - " + Branch + " - " + Letter + " - " + ("0000000" + Number).Substring(("0000000" + Number).Length - 7);
            }
        }
        public virtual ICollection<VoucherDetail> VoucherDetails { get; set; }
        public virtual ICollection<Label> Labels { get; set; }
    }
}