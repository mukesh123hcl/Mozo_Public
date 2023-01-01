using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class Sourge_Config:BaseEntity_Service
	{
		[Display(Name = "Surge Type")]
		[Required]
		public string Surge_type { get; set; }

		[Display(Name = "Surge Price")]
		[Required]
		public string Surge_Price { get; set; }
	}
}
