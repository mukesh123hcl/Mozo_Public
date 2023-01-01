using System;
namespace MozoModels.Models
{
    public class Booking_Addresss:BaseEntity_Service
    {
        public string User_Id { get; set; }

        public string AddLine1 { get; set; }

        public string AddLine2 { get; set; }

        public string AddLine3 { get; set; }

        public string Pincode { get; set; }

        public string Area { get; set; }

        public Int64 City_id { get; set; }

        public string AddressType { get; set;}


    }
}
