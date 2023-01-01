using Microsoft.AspNetCore.Mvc.Rendering;
using MozoModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoApp.Areas.Admin.Models
{
	public class Price_View:BaseEntity_Service
	{
		[Display(Name = "City")]

		public string City_Name { get; set; }

		public List<SelectListItem> City
		{
			get;
			set;
		} = new List<SelectListItem>();
		[Required(ErrorMessage = "{0} is required.")]
		public long City_Id
		{
			get;
			set;
		}

		[Display(Name = "Geo Category")]

		public string Geo_Category_Name { get; set; }

		public List<SelectListItem> Geo_category
		{
			get;
			set;
		} = new List<SelectListItem>();
		[Required(ErrorMessage = "{0} is required.")]
		public long Geo_category_Id
		{
			get;
			set;
		}

		[Display(Name = "Service Type")]

		public string Service_Type_Name { get; set; }

		public List<SelectListItem> Serive_Type
		{
			get;
			set;
		} = new List<SelectListItem>();
		[Required(ErrorMessage = "{0} is required.")]
		public long Service_Type_Id
		{
			get;
			set;
		}

		[Display(Name = "Service")]

		public string Service_Name { get; set; }

		public List<SelectListItem> Services
		{
			get;
			set;
		} = new List<SelectListItem>();
		[Required(ErrorMessage = "{0} is required.")]
		public long Service_Id
		{
			get;
			set;
		}
		[Display(Name = "House Type")]

		public string House_Type_Name { get; set; }

		public List<SelectListItem> House_Type
		{
			get;
			set;
		} = new List<SelectListItem>();
		[Required(ErrorMessage = "{0} is required.")]
		public long House_Type_Id
		{
			get;
			set;
		}

		[Display(Name = "Avarge Per Month Price")]
		[Required]
		public float Avg_Per_Month_Price { get; set; }
		[Display(Name = "Average Time")]
		[Required]
		[RegularExpression(@"^[0][1-9]\d{1}$|^[1-9]\d{1}$", ErrorMessage = "Two digit number is only allowed")]
		public Int64 Avg_Time { get; set; }

		[Display(Name = "Gross Margin")]
		[Required]
		
		public float Gross_Margin { get; set; }
	}
}
