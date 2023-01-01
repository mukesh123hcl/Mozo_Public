using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class HouseType:BaseEntity_Service
	{

		[Display(Name = "House Type")]
		[Required]

		public string HouseType_Name { get; set; }

	}
}
