using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Label
    {
        [Key, Required]
        public Guid ID { get; set; }
        [Display(Name = "Comprobante")]
        public Guid Voucher_ID { get; set; }
        [ForeignKey("Voucher_ID"), Required]
        public virtual Voucher Voucher { get; set; }
        [Required]
        [Display(Name = "Articulo")]
        public Guid Article_ID { get; set; }

        [ForeignKey("Article_ID")]
        public virtual Article Article { get; set; }
        public int LabelNumber { get; set; }
        public int TotalLabels { get; set; }
    }
}
