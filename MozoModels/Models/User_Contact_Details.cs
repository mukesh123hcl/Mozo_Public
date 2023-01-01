using System;
namespace MozoModels.Models
{
    public class User_Contact_Details:BaseEntity_Service
    {
        public string user_id { get; set; }
        public long address_id { get; set; }
        public string contry_code { get; set; }
        public string primery_contact_number { get; set; }
        public string secondry_contact_number { get; set; }
    }
}
