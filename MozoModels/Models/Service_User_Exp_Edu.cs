using System;
namespace MozoModels.Models
{
    public class Service_User_Exp_Edu : BaseEntity_Service
    {
        public string user_id { get; set; }
        public string experience { get; set; }
        public bool certified { get; set; }
        public string cerified_institute { get; set; }
        public string certificate_no { get; set; }
        public string certified_year { get; set; }
        public string edu_qalif { get; set; }


    
    }
}
