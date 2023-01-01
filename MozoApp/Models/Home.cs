using System;
using MozoModels.Models;
namespace MozoApp.Models
{
    public class Home:BaseEntity_Service
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string user_id { get; set; }
    }
}
