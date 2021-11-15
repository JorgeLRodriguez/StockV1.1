using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class IdentityBase
    {
        [Key, Required]
        public int ID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        [StringLength(20)]
        public string CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ChangedOn { get; set; }
        [StringLength(20)]
        public string ChangedBy { get; set; }
    }
}
