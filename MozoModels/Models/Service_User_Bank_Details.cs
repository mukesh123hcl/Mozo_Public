using System;
namespace MozoModels.Models
{
    public class Service_User_Bank_Details:BaseEntity_Service
    {
        public string user_id { get; set; }
        public string bank_name { get; set; }
        public string ifsc_code { get; set; }
        public string account_name { get; set; }
        public long account_number { get; set; }
        public string upi_id { get; set; }
    }
}
