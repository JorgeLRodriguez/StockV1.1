using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Voucher
    {
        //[Required, DatoSensible, RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        //[Display(Name = ConstantesTexto.Cliente)]
        public int Client_ID { get; set; }
        [ForeignKey("Client_ID")]
        public virtual Client Client { get; set; }
        //[Required, DatoSensible, StringLength(3, MinimumLength = 3)]
        //[Display(Name = ConstantesTexto.Tipo)]
        public string VoucherType { get; set; }
        //[Required, DatoSensible, StringLength(3, MinimumLength = 1)]
        //[Display(Name = ConstantesTexto.Letra)]
        public string Letter { get; set; }
        //[Required, DatoSensible, Range(1, 1)]
        //[Display(Name = ConstantesTexto.Sucursal)]
        public int Branch { get; set; }
        //[Required, DatoSensible, Range(1, int.MaxValue)]
        //[Display(Name = ConstantesTexto.NumeroComprobante)]
        public int Number { get; set; }
        //[DatoSensible, StringLength(10, MinimumLength = 1), RegularExpression("^[0-9]*$"), Range(1, int.MaxValue)]
        //[Display(Name = ConstantesTexto.Remito)]
        public string InvoiceClientNumber { get; set; }
        //[DatoSensible, Required]
        //[Display(Name = ConstantesTexto.Fecha)]
        public DateTime? VoucherDate { get; set; }
        //[DatoSensible]
        //[Display(Name = ConstantesTexto.Cierre)]
        public string Closure { get; set; }
        [ RegularExpression("^[0-9]*$"), Range(0, int.MaxValue)]
        //[Display(Name = ConstantesTexto.Destinatario)]
        public int? Addressee_ID { get; set; }
        [ForeignKey("Destinatario_ID")]
        public virtual Addressee Addressee { get; set; }
        //[Display(Name = ConstantesTexto.Observacion)]
        public string Observations { get; set; }
        public byte[] DVH { get; set; }
        [NotMapped]
        public string Description
        {
            get
            {
                return VoucherType + " - " + Branch + " - " + Letter + " - " + ("0000000" + Number).Substring(("0000000" + Number).Length - 7);
            }
        }
        public virtual ICollection<VoucherDetail> VoucherDetails { get; set; }
        public virtual ICollection<Label> Labels { get; set; }
    }
}