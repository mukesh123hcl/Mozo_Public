using System;
namespace MozoModels.Models
{
    public class User_Location:BaseEntity_Service
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string user_id { get; set; }
        public string map_address { get; set; }
        public string city { get; set; }
    }
}
