using Domain.Integrity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Aisle : IdentityBase, IHorizontalCheckDigit
    {
        [Required, SensitiveData, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        public byte[] DVH { get; set; }
        public virtual ICollection<Pallet> Pallet { get; set; }
    }
}