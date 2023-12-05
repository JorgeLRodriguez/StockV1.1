using Domain.Integrity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Deposit : IdentityBase, IHorizontalCheckDigit
    {
        public Guid Client_ID { get; set; }
        [ForeignKey("Client_ID"), Required, Display(Name = "Cliente")]
        public virtual Client Client { get; set; }
        [Required, SensitiveData, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string DepositName { get; set; }
        [Required, SensitiveData, StringLength(100, MinimumLength = 3)]
        [Display(Name = "Domicilio")]
        public string Address { get; set; }
        public byte[] DVH { get; set; }
        public virtual ICollection<Pallet> Pallet { get; set; }
    }
}