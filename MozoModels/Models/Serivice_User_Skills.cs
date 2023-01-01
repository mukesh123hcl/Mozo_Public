using System;
namespace MozoModels.Models
{
    public class Serivice_User_Skills:BaseEntity_Service
    {
        public string user_id { get; set; }
        public Int64 service_type_id { get; set; }
        public Int64 service_id { get; set; }
    }
}
