using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MozoModels.Models;

namespace MozoApp.Areas.User_Profile.Models
{
    public class Profile_View:BaseEntity_Service
    {
        public string user_id { get; set; }
        
        public List<SelectListItem> title_list
        {
            get;
            set;
        } = new List<SelectListItem>();

        public List<SelectListItem> gender_list
        {
            get;
            set;
        } = new List<SelectListItem>();
        public string user_title { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string religion { get; set; }

        
        public List<SelectListItem> religion_list
        {
            get;
            set;
        } = new List<SelectListItem>();
        public DateTime dob { get; set; }
        public string age { get; set; }
        
        public List<SelectListItem> maritial_status_list
        {
            get;
            set;
        } = new List<SelectListItem>();
        public string maritial_status { get; set; }
        public DateTime marriage_date { get; set; }
        public string profile_photo { get; set; }

        public IFormFile ProfileImage { get; set; }

        public string about { get; set; }

        public string experience { get; set; }
        public bool certified { get; set; }
        public string cerified_institute { get; set; }
        public string certificate_no { get; set; }
        public string certified_year { get; set; }
        public string edu_qalif { get; set; }

        public string add_doc_type { get; set; }
        public string add_doc_no { get; set; }
        public string add_doc { get; set; }
        public IFormFile add_doc_file { get; set; }
        public string id_doc_type { get; set; }
        public string id_doc_no { get; set; }
        public string id_doc { get; set; }
        public IFormFile id_doc_file { get; set; }
        public string pan_card_no { get; set; }
        public string pan_card { get; set; }
        public IFormFile pan_card_file { get; set; }
        public string dl_no { get; set; }
        public string dl { get; set; }
        public IFormFile dl_file { get; set; }
        public long address_id { get; set; }
        public string contry_code { get; set; }
        public string primery_contact_number { get; set; }
        public string secondry_contact_number { get; set; }

        public string AddressType { get; set; }
        public string AddLine1 { get; set; }

        public string AddLine2 { get; set; }

        public string AddLine3 { get; set; }

        public string Pincode { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string bank_name { get; set; }
        public string ifsc_code { get; set; }
        public string account_name { get; set; }
        public long account_number { get; set; }
        public string upi_id { get; set; }

        [Display(Name = "Service Type")]

        public string Service_Type_Name { get; set; }
        
        public List<SelectListItem> Serive_Type
        {
            get;
            set;
        } = new List<SelectListItem>();
        [Required(ErrorMessage = "{0} is required.")]
        public long Service_Type_Id
        {
            get;
            set;
        }

        [Display(Name = "Service")]

        public string Service_Name { get; set; }

        public List<SelectListItem> Services
        {
            get;
            set;
        } = new List<SelectListItem>();
        [Required(ErrorMessage = "{0} is required.")]
        public long Service_Id
        {
            get;
            set;
        }

        public string duty { get; set; }
        public bool duty_status { get; set; }
        public List<Booking_Addresss> userAddress;

    }
}
