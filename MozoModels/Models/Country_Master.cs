using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class Country_Master:BaseEntity_Service
	{
		[Display(Name = "Country")]
		[Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string Country_Name { get; set; }



	}
}
