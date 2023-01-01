using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MozoModels.Models;


namespace MozoApp.Areas.Admin.Models
{
	public class Geo_Category_View:BaseEntity_Service
	{
		[Display(Name = "Country")]

		public string Country_Name { get; set; }
		
		[Display(Name ="City")]
		public string City_Name { get; set; }

		public List<SelectListItem> Country
		{
			get;
			set;
		} = new List<SelectListItem>();
		public List<SelectListItem> City
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
		[Display(Name = "City")]
		[Required(ErrorMessage = "{0} is required.")]
		public long CityId
		{
			get;
			set;
		}
		[Display(Name = "Geo Category")]
		[Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string Geo_Cateogry { get; set; }

		
	}
}
