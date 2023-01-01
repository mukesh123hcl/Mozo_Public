using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class Discount_Coupen:BaseEntity_Service
	{
		[Display(Name = "Coupen Code")]
		[Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string Coupen_Code { get; set; }

		[Display(Name = "Coupen Type")]
		[Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string Coupen_Type { get; set; }

		[Required]
		public Int64 Discount { get; set; }
		[Required]
		public Int64 Duration { get; set; }
	}
}
