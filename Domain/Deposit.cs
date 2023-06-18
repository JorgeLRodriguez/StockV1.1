using Domain.Integrity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Deposit : IdentityBase, IHorizontalCheckDigit
    {
        [SensitiveData, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        [Display(Name = "Cliente")]
        public Guid Client_ID { get; set; }
        //[ForeignKey("Client_ID")]
        public virtual Client Client { get; set; }
        [Required, SensitiveData, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Descripcion")]
        public string DepositName { get; set; }
        [Required, SensitiveData, StringLength(100, MinimumLength = 3)]
        [Display(Name = "Domicilio")]
        public string Address { get; set; }
        public byte[] DVH { get; set; }
        public virtual ICollection<Pallet> Pallet { get; set; }
    }
}