using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Article : IdentityBase
    {

        public Guid Client_ID { get; set; }
        [ForeignKey("Client_ID"), Required, Display(Name = "Cliente")]
        public virtual Client Client { get; set; }
        [Display(Name = "CodigoFS")]
        public string FsCode { get; set; }
        [Display(Name ="Descripcion")]
        public string Description { get; set; }
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }
        [Display(Name = "CodigoPropio")]
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
