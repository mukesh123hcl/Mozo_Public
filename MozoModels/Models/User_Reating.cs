using System;
namespace MozoModels.Models
{
    public class User_Reating:BaseEntity_Service
    {
        public string user_id { get; set; }
        public long booking_id { get; set; }
        public int rating { get; set; }
    }
}
