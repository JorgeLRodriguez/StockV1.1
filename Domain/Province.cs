using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Province : IdentityBase
    {
        [Display(Name = "Provincia"), Required]
        public string ProvinceName { get; set; }
        [Display (Name = "Localidades")]
        public virtual ICollection<Locality> Localities { get; set; }
    }
}
