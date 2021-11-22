using Domain.Integrity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Pallet
    {
        [Required, SensitiveData, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        [Display(Name = "Deposito")]
        public int Deposit_ID { get; set; }
        [ForeignKey("Deposito_ID")]
        public virtual Deposit Deposito { get; set; }
        [Required, SensitiveData, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        [Display(Name = "Pasillo")]
        public int Aisle_ID { get; set; }
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
        public virtual ICollection<VoucherDetail> ComprobanteDetalle { get; set; }
        public byte[] DVH { get; set; }
    }
}
