using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MozoModels.Models;

namespace MozoApp.Areas.Admin.Models
{
	public class Services_View:BaseEntity_Service
	{
		[Display(Name = "Service Type")]

		public string Sevice_type { get; set; }
		[Display(Name = "Service")]
		[Required]
		[RegularExpression(@"^\b(?!.*?\s{2})[A-Za-z ]{1,50}\b$", ErrorMessage = "Use letters only please")]
		public string Service { get; set; }

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
