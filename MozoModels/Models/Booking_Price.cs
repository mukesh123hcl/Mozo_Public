using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class Booking_Price:BaseEntity_Service
	{
		public Int64 Booking_Id { get; set; }
		public Int64 TotalTime_Required { get; set; }
		public Int64 TotalTime_Taken { get; set; }
		public float Sourge { get; set; }
		public float ToalGST { get; set; }
		public float C_GST { get; set; }
		public float S_GST { get; set; }
		public float Initial_Price { get; set; }
		public float Total_Revenue { get; set; }
		public float Gross_Margin { get; set; }
		public float Total_COGS { get; set; }
	}
}
