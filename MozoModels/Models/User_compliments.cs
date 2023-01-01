using System;
namespace MozoModels.Models
{
    public class User_compliments:BaseEntity_Service
    {
        public string user_id { get; set; }
        public string compliment { get; set; }
    }
}
