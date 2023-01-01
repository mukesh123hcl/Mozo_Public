using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class Booking:BaseEntity_Service
	{
		[Display(Name = "City")]
		public Int64 City_Id { get; set; }

	

		


		[Display(Name = "Service_Type")]
		public Int64 Service_Type_Id { get; set; }



		
		[Display(Name = "Service")]
		public Int64 Services { get; set; }

		[Display (Name ="Area")]

		public string Area { get; set; }

		[Display(Name = "House Type")]
		public Int64 House_Type_Id { get; set; }

		[Display(Name ="Requested Date Time")]
		public DateTime Requested_Date_time { get; set; }

		public string User_Id { get; set; }
		public string Coupen_Code { get; set; }

	}
}
