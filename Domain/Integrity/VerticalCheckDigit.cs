using System.ComponentModel.DataAnnotations;

namespace Domain.Integrity
{
    public class VerticalCheckDigit
    {
        [Key, Required]
        public string Entity { get; set; }
        public byte[] Checksum { get; set; }
    }
}