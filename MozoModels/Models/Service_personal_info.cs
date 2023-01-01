using System;
namespace MozoModels.Models
{
    public class Service_personal_info:BaseEntity_Service
    {
        public string user_id { get; set; }
        public string user_title { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string religion { get; set; }
        public DateTime dob { get; set; }
        public string age { get; set; }
        public string maritial_status { get; set; }
        public DateTime marriage_date { get; set; }
        public string profile_photo { get; set; }
        public string about { get; set; }

        

        
    }
}
