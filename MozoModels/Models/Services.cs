using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MozoModels.Models
{
	public class Services:BaseEntity_Service
	{

        [Display(Name = "Service Name")]
        [Required]
        public string Service_Name { get; set; }

        // Foreign key 
        [Display(Name = "Service_Type")]
        public Int64 Service_Type_Id { get; set; }

    

        
    }
}
