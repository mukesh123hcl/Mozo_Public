using Microsoft.AspNetCore.Mvc.Rendering;
using MozoModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MozoApp.Areas.Bookings.Models
{
    public class BookingConfirmation_View:BaseEntity_Service
    {
        public string AddLine1 { get; set; }

        public string AddLine2 { get; set; }

        public string AddLine3 { get; set; }

        public string Pincode { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string Service_Type_Name { get; set; }

        public string Service_Name { get; set; }

        public string House_Type_Name { get; set; }

        public float Price { get; set;}

        public long Address_id { get; set; }
        public string AddressType { get; set; }

        public string Total_Price { get; set; }
    }
}
