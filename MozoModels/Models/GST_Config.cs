using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class GST_Config:BaseEntity_Service
	{

		[Display(Name = "SGST")]
		[Required]
		public string S_GST { get; set; }

		[Display(Name = "CGST")]
		[Required]
		public string C_GST { get; set; }
		// Foreign key 
		[Display(Name = "Service_Type")]
		public Int64 Service_Type_Id { get; set; }

	}
}
