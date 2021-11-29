using Domain.Integrity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Pallet : IdentityBase, IHorizontalCheckDigit
    {
        [Required, SensitiveData]
        [Display(Name = "Deposito")]
        public Guid Deposit_ID { get; set; }
        [ForeignKey("Deposit_ID")]
        public virtual Deposit Deposit { get; set; }
        [Required, SensitiveData]
        [Display(Name = "Pasillo")]
        public Guid Aisle_ID { get; set; }
        [ForeignKey("Aisle_ID")]
        public virtual Aisle Aisle { get; set; }
        [Required, SensitiveData, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        [Display(Name = "Columna")]
        public int Col { get; set; }
        [Required, SensitiveData, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        [Display(Name = "Fila")]
        public int Row { get; set; }
        [Required, SensitiveData, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        public virtual ICollection<VoucherDetail> VoucherDetails { get; set; }
        public byte[] DVH { get; set; }
    }
}
