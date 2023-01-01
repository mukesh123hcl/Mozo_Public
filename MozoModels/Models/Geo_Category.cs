using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class Geo_Category:BaseEntity_Service
	{
		[Display(Name = "Geo Category")]
		[Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string Geo_Category_Name { get; set; }

		public Int64 City_Id { get; set; }

	}
}
