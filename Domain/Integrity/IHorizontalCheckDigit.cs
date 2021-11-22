using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Integrity
{
    public interface IHorizontalCheckDigit
    {
        byte[] DVH { get; set; }
    }
}
