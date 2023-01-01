using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class Price:BaseEntity_Service
	{


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

		[Display(Name = "No of Person")]
		[Required]
		public Int64 No_Of_Person { get; set; }
		[Display(Name ="Avarge Per Month Price")]
		[Required]
		public float Avg_Per_Month_Price { get; set; }

		[Required]
		public float Avg_Per_Day_Price { get; set; }

		[Display(Name ="Average Time")]
		[Required]
		public Int64 Avg_Time { get; set; }

		[Required]
		public float Avg_Per_Minute_Price { get; set; }

		[Required]
		public float Avg_Per_Month_Cost { get; set; }

		[Required]
		public float Avg_Per_Day_Cost { get; set; }

		[Required]
		public float Avg_Per_Minute_Cost { get; set; }

		public float Sourge { get; set; }
		public float ToalGST { get; set; }
		public float C_GST { get; set; }
		public float S_GST { get; set; }
		public float Total_Revenue { get; set; }
		public float Gross_Margin { get; set; }
		public float Total_COGS { get; set; }






	}
}
