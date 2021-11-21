using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Label : IdentityBase
    {
        //[Display(Name = ConstantesTexto.Comprobante)]
        public int Voucher_ID { get; set; }
        [ForeignKey("Comprobante_ID"), Required]
        public virtual Voucher Voucher { get; set; }
        [Required]
        //[Display(Name = ConstantesTexto.Articulo)]
        public int Article_ID { get; set; }

        [ForeignKey("Article_ID")]
        public virtual Article Article { get; set; }
        public int LabelNumber { get; set; }
        public int TotalLabels { get; set; }
    }
}
