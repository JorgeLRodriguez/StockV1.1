using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class IdentityBase
    {
        [Key, Required, Display(Name ="ID")]
        public Guid ID { get; set; }
        [DataType(DataType.DateTime), Display(Name ="FechaCreacion")]
        public DateTime? CreatedOn { get; set; }
        [StringLength(20), Display(Name ="CreadoPor")]
        public string CreatedBy { get; set; }
        [DataType(DataType.DateTime), Display(Name ="FechaActualizacion")]
        public DateTime? ChangedOn { get; set; }
        [StringLength(20), Display(Name ="ActualizadoPor")]
        public string ChangedBy { get; set; }
    }
}
