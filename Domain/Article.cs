using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Article : IdentityBase
    {
        public Guid Client_ID { get; set; }
        [ForeignKey("Client_ID"), Required]
        public virtual Client Client { get; set; }
        public string FsCode { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public bool OwnBarcode { get; set; }
        [NotMapped]
        public string BarcodeDescription
        {
            get { return "(" + Barcode + ") " + Description; }
        }
        public virtual ICollection<VoucherDetail> VoucherDetails { get; set; }
        public virtual ICollection<Label> Labels { get; set; }
    }
}
