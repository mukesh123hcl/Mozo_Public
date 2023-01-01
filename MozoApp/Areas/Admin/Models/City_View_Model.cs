using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MozoModels.Models;

namespace MozoApp.Areas.Admin.Models
{
	public class City_View_Model:BaseEntity_Service
	{
		[Display(Name = "Country")]
		
		public string Country_Name { get; set; }
		[Display(Name = "City")]
		[Required]
		[RegularExpression(@"^\b(?!.*?\s{2})[A-Za-z ]{1,50}\b$", ErrorMessage = "Use letters only please")]
		public string City_Name { get; set; }

		public List<SelectListItem> Country
		{
			get;
			set;
		} = new List<SelectListItem>();
		[Display(Name = "Contry")]
		[Required(ErrorMessage = "{0} is required.")]
		public long CountryId
		{
			get;
			set;
		}



	}
}
