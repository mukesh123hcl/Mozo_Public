using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MozoModels.Models;


namespace MozoApp.Areas.Admin.Models
{
	public class GST_View:BaseEntity_Service
	{
		[Display(Name = "Service Type")]

		public string Sevice_type { get; set; }
		

		[Required]
		[RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Use number with decimal of two places")]
		[Display(Name = "SGST")]
	
		public string S_GST { get; set; }

		[Display(Name = "CGST")]
		[Required]
		[RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Use number with decimal of two places")]
		public string C_GST { get; set; }

		public List<SelectListItem> Service_Types
		{
			get;
			set;
		} = new List<SelectListItem>();

		public long Service_Type_Id
		{
			get;
			set;
		}
	}
}
