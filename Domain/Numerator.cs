namespace Domain
{
    public class Numerator : IdentityBase
    {
        public VoucherType VoucherType { get; set; }
        public string Letter { get; set; }
        public int Branch { get; set; }
        public int Number { get; set; }
    }
}
