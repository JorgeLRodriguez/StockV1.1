using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Locality : IdentityBase
    {
        [Display(Name = "CodigoPostal"), Required]
        public string ZipCode { get; set; }

        [Display(Name = "Localidad"), Required]
        public string LocalityName { get; set; }
        //[Display(Name = "Comprobante")]
        public Guid Province_ID { get; set; }

        [ForeignKey("Province_ID"), Required, Display(Name = "Provincia")]
        public virtual Province Province { get; set; }
    }
}
