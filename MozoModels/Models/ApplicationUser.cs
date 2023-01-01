using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
		public string Zip { get; set; }
		public string UserImage { get; set; }
		public DateTime AddedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string IPAddress { get; set; }
		public string OTP { get; set; }
		
	}
}
