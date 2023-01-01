using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public abstract class BaseEntity_Service
	{
		[Key]
		public Int64 Id
		{
			get;
			set;
		}
		public DateTime AddDateTime { get; set; }
		public DateTime ModifiedDatime { get; set; }
		public string AddedBy { get; set; }
		public string ModifiedBy { get; set; }
		public bool Status { get; set; }
	}
}
