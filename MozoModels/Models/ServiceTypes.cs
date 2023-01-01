using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class ServiceTypes:BaseEntity_Service
	{

      
        public long Service_Type_Id { get; set; }
        [Display(Name = "Service Type")]
        [Required]
        public string Service_Type_Name { get; set; }
        
    }
}
