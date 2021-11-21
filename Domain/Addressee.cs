using System.Collections.Generic;

namespace Domain
{
    public class Addressee : IdentityBase
    {
        public string LastName { get; set; }
        public int DocumentType { get; set; }
        public int DocumentNumber { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string observations { get; set; }
        public string Mail { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
