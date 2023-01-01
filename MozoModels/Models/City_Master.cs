using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class City_Master:BaseEntity_Service
	{
		[Display(Name = "City")]
		[Required]
		public string City_Name { get; set; }

		
		public Int64 Country_Id { get; set; }




		
	}
}
