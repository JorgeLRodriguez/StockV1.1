using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Numerator : IdentityBase
    {
        public string VoucherType { get; set; }
        public string Letter { get; set; }
        public int Branch { get; set; }
        public int Number { get; set; }
    }
}
