using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CSV: IdentityBase
    {
		[Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:yyyy/MM/dd}")]
		public DateTime InvoiceDate { get; set; }
		[Required, StringLength(11, MinimumLength = 11)]
		public string Cuit { get; set; }
		[Required, StringLength(3, MinimumLength = 1)]
		public string Letter { get; set; }
		[Required, StringLength(4, MinimumLength = 1)]
		public string Branch { get; set; }
		[Required, StringLength(8, MinimumLength = 1), RegularExpression("^[0-9]*$")]
		public string InvoiceNumber { get; set; }
		[Required, RegularExpression("^[0-9]*$"), Range(1, 6)]
		public int DocType { get; set; }
		[Required, RegularExpression("^[0-9]*$"), Range(1, 999999999)]
		public int DocNumber { get; set; }
		[Required, StringLength(50, MinimumLength = 1)]
		public string AddresseeName { get; set; }
		[Required, StringLength(50, MinimumLength = 1)]
		public string AddresseeLastName { get; set; }
		[Required, StringLength(100, MinimumLength = 1)]
		public string AddresseeAddress { get; set; }
		[Required, RegularExpression("^[0-9]*$")]
		public string AddresseeZipCode { get; set; }
		[Required, RegularExpression("^[0-9]*$"), StringLength(10, MinimumLength = 1)]
		public string AddresseePhoneNumber { get; set; }
		[Required, RegularExpression("^[0-9]*$"), StringLength(10, MinimumLength = 1)]
		public string AddresseeCellPhoneNumber { get; set; }
		[Required, EmailAddress, DataType(DataType.EmailAddress)]
		public string AddresseeMail { get; set; }
		[Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:yyyy/MM/dd}")]
		public DateTime DeliveryDate { get; set; }
		[Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:yyyy/MM/dd}")]
		public DateTime RetirementDate { get; set; }
		public string DeliveryTimeSlot { get; set; }
		[Required, StringLength(100, MinimumLength = 1)]
		public string ClientAddresse { get; set; }
		[Required, RegularExpression("^[0-9]*$")]
		public string ClientZipCode { get; set; }
		[Required, RegularExpression("^[0-9]*$")]
		public int Packages { get; set; }
		[Required]
		public string FsCode { get; set; }
		[RegularExpression("^[0-9]*$")]
		public int Weight { get; set; }
		[RegularExpression("^[0-9]*$")]
		public int Width { get; set; }
		[RegularExpression("^[0-9]*$")]
		public int Long { get; set; }
		[RegularExpression("^[0-9]*$")]
		public int High { get; set; }
		public string FileName { get; set; }
	}
}
