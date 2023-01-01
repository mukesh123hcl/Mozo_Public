using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class Packages:BaseEntity_Service
	{

        [Display(Name = "Package Name")]
        [Required]
        public string Package_Name { get; set; }

		[Display(Name = "City")]
		public Int64 City_Id { get; set; }



		[Display(Name = "Geo Category")]
		public Int64 Geo_Category_Id { get; set; }

		[Display(Name = "Service_Type")]
		public Int64 Service_Type_Id { get; set; }



		[Display(Name = "Service")]
		public Int64 Service_Id { get; set; }



		[Display(Name = "House Type")]
		public Int64 House_Type_Id { get; set; }



		[Required]
		public float Price { get; set; }

		[Required]
		public float Cost { get; set; }

		public float Sourge { get; set; }

		public float Total_Price { get; set; }

		public float Total_Cost { get; set; }
	}
}
