using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Client : IdentityBase
    {
        [Required]
        public string Cuit { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Enabled { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
