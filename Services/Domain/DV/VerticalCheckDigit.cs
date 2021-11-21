using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.DV
{
    class VerticalCheckDigit
    {
        [Key, Required]
        public string Entity { get; set; }
        public byte[] Checksum { get; set; }
    }
}
