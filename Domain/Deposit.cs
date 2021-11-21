using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Deposit : IdentityBase
    {
    //    [DatoSensible, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
    //    [Display(Name = ConstantesTexto.Cliente)]
        public int Client_ID { get; set; }
        //[ForeignKey("Cliente_ID")]
        public virtual Client Client { get; set; }
        //[Required, DatoSensible, StringLength(50, MinimumLength = 3)]
        //[Display(Name = ConstantesTexto.Descripcion)]
        public string DepositName { get; set; }
        //[Required, DatoSensible, StringLength(100, MinimumLength = 3)]
        //[Display(Name = ConstantesTexto.Domicilio)]
        public string Address { get; set; }
        public byte[] DVH { get; set; }
        //public virtual ICollection<Pallet> Pallet { get; set; }
    }
}