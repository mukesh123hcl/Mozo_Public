using System;
using System.ComponentModel.DataAnnotations;

namespace MozoModels.Models
{
    public class Area : BaseEntity_Service
    {
       

            public string Area_Name { get; set; }
            [Display(Name = "City")]
            public Int64 City_Id { get; set; }

            public Int64 GeoCategory_Id { get; set; }
        

        
    }

            
}


