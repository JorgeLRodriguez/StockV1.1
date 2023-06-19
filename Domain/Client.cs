using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Client : IdentityBase
    {
        [Required, Display(Name = "CUIT")]
        public string Cuit { get; set; }
        [Required, Display(Name = "Descripcion")]
        public string Description { get; set; }
        [Required, Display(Name = "Activo")]
        public bool Enabled { get; set; }
        [Display(Name = "Articulos")]
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
