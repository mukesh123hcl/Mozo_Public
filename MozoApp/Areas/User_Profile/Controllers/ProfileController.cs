using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MozoApp.Areas.User_Profile.Models;
using MozoDataAccess.Data;
using MozoDataAccess.Repository;
using MozoModels.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MozoApp.Areas.User_Profile.Controllers
{
    [Area("User_Profile")]
    public class ProfileController : Controller
    {

        private Mozo_Data_Context context;
        private UserManager<ApplicationUser> _userManager;

        private IServiceRepository<Service_personal_info> _repopersonalinfo;

        private IServiceRepository<Service_User_Exp_Edu> _repoeduinfo;

        private IServiceRepository<Serivice_User_Skills> _reposkills;

        private IServiceRepository<User_Contact_Details> _repocontactdetails;

        private IServiceRepository<User_Identification> _repouseridentification;

        private IServiceRepository<Service_User_Bank_Details> _reposerviceuserbank;

        private IServiceRepository<ServiceTypes> _reposervicetypes;

        private IServiceRepository<Booking_Addresss> _repobookingaddress;

        //private IServiceRepository<City_Master> _repocity;
        private IServiceRepository<City_Master> _repocitymaster;
        private readonly ILogger<ProfileController> _logger;

        private readonly IWebHostEnvironment webHostEnvironment;

        private IServiceRepository<Duty_Status> _repodutystatus;

        public ProfileController(UserManager<ApplicationUser> usermanager,
            IServiceRepository<Serivice_User_Skills> reposkills,
            IServiceRepository<Service_User_Exp_Edu> repoeduinfo,
            IServiceRepository<User_Contact_Details> repocontactdetails,
            IServiceRepository<User_Identification> repouseridentification,
            IServiceRepository<Service_User_Bank_Details> reposerviceuserbank,
            IServiceRepository<Service_personal_info> repopersonalinfo,
            IServiceRepository<ServiceTypes> reposervicetypes,
            IServiceRepository<Booking_Addresss> repobookingaddress,
            IServiceRepository<City_Master> repocitymaster,
            IServiceRepository<Duty_Status> repodutystatus,
            IWebHostEnvironment hostEnvironment,
            ILogger<ProfileController> logger, Mozo_Data_Context context)
        {
            this._repopersonalinfo = repopersonalinfo;
            this._reposkills = reposkills;
            this._repoeduinfo = repoeduinfo;
            this._repocontactdetails = repocontactdetails;
            this._repouseridentification = repouseridentification;
            this._reposerviceuserbank = reposerviceuserbank;
            this._reposervicetypes = reposervicetypes;
            this._userManager = usermanager;
            this._repocitymaster = repocitymaster;
            webHostEnvironment = hostEnvironment;
            this._repobookingaddress = repobookingaddress;
            _logger = logger;
            this.context = context;
            this._repodutystatus = repodutystatus;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Profile()
        {
             Profile_View model = new Profile_View();
            var user = await _userManager.GetUserAsync(User);
            HttpContext.Session.SetString("User_Id", user.Id);
            Service_personal_info personal_Info = context.Set<Service_personal_info>().SingleOrDefault(c => (c.user_id == user.Id));
            Service_User_Exp_Edu service_User_Exp_Edu = context.Set<Service_User_Exp_Edu>().SingleOrDefault(c => (c.user_id == user.Id));
            User_Identification user_Identification = context.Set<User_Identification>().SingleOrDefault(c => (c.user_id == user.Id));
            User_Contact_Details user_Contact_Details= context.Set<User_Contact_Details>().SingleOrDefault(c => (c.user_id == user.Id));
            Service_User_Bank_Details bank_Details = context.Set<Service_User_Bank_Details>().SingleOrDefault(c => (c.user_id == user.Id));
            Duty_Status duty_Status = context.Set<Duty_Status>().SingleOrDefault(c => c.user_id == user.Id);
            model.Serive_Type = _reposervicetypes.GetAll().Select(a => new SelectListItem
            {
                Text = a.Service_Type_Name,
                Value = a.Id.ToString()
            }).ToList();

           
            var Address = _repobookingaddress.GetAll().ToList();
            HttpContext.Session.SetString("User_Id", user.Id);

            Address.Where(s => s.User_Id == user.Id).ToList().ForEach(b =>
            {
                Profile_View BCView = new Profile_View
                {
                    AddressType = b.AddressType,
                    Area = b.Area,
                    AddLine1 = b.AddLine1,
                    AddLine2 = b.AddLine2,
                    AddLine3 = b.AddLine3,
                    address_id = b.Id
                };
                //City_Master city = _repocitymaster.Get(b.City_id);
                //BCView.City = city.City_Name;
                model.AddressType = BCView.AddressType;
                model.Area = BCView.Area;
                model.AddLine1 = BCView.AddLine1;
                model.AddLine2 = BCView.AddLine2;
                model.AddLine3 = BCView.AddLine3;
                model.address_id = BCView.address_id;
                //model.City = BCView.City;

            });

            if (personal_Info!=null)
            {
                model.user_title = personal_Info.user_title;
                model.first_name = personal_Info.first_name;
                model.middle_name = personal_Info.middle_name;
                model.last_name = personal_Info.last_name;
                model.gender = personal_Info.gender;
                model.religion = personal_Info.religion;
                model.dob = Convert.ToDateTime(personal_Info.dob);
                model.maritial_status = personal_Info.maritial_status;
                model.marriage_date = personal_Info.marriage_date;
                model.profile_photo = personal_Info.profile_photo;
                model.about = personal_Info.about;
            }
            if (service_User_Exp_Edu!=null)
            {
                model.edu_qalif = service_User_Exp_Edu.edu_qalif;
                model.experience = service_User_Exp_Edu.experience;
                model.certified = service_User_Exp_Edu.certified;
                model.cerified_institute = service_User_Exp_Edu.cerified_institute;
                model.certified_year = service_User_Exp_Edu.certified_year;
                model.certificate_no = service_User_Exp_Edu.certificate_no;
            }
            if(user_Identification!=null)
            {
                HttpContext.Session.SetString("User_Id_Identitiy", user_Identification.Id.ToString());
                model.add_doc = user_Identification.add_doc;
                model.add_doc_no = user_Identification.add_doc_no;
                model.add_doc_type = user_Identification.add_doc_type;
                model.id_doc = user_Identification.id_doc;
                model.id_doc_no = user_Identification.id_doc_no;
                model.id_doc_type = user_Identification.id_doc_type;
                model.pan_card = user_Identification.pan_card;
                model.pan_card_no = user_Identification.pan_card_no;
                model.dl = user_Identification.dl;
                model.dl_no = user_Identification.dl_no;
            }
            if(user_Contact_Details!=null)
            {
                HttpContext.Session.SetString("User_Id_Contact", user_Contact_Details.Id.ToString());
                model.primery_contact_number = user_Contact_Details.primery_contact_number;
                model.secondry_contact_number = user_Contact_Details.secondry_contact_number;
            }
            if(bank_Details!=null)
            {
                HttpContext.Session.SetString("Bank_Detail_Id", bank_Details.Id.ToString());
                model.bank_name = bank_Details.bank_name;
                model.account_name = bank_Details.account_name;
                model.ifsc_code = bank_Details.ifsc_code;
                model.account_number = bank_Details.account_number;
                model.upi_id = bank_Details.upi_id;
            }
            if(duty_Status==null)
            {
                Duty_Status duty = new Duty_Status
                {
                    user_id=user.Id,
                    Status=false,
                    AddDateTime=DateTime.Now,
                    AddedBy=user.Id
                };
                model.duty = "Duty On";
                _repodutystatus.Insert(duty);
            }
            if(duty_Status!=null)
            {
                if(duty_Status.Status==true)
                {
                    model.duty = "Duty Off";

                }
                else
                {
                    model.duty = "Duty On";
                }
            }

           

            return View("Profile",model);
        }

       [HttpPost]
        public IActionResult Personal(Profile_View model)
        {
            //var user = await _userManager.GetUserAsync(User);
            var today = DateTime.Today;
            var dateofb = Convert.ToDateTime(model.dob);
            string uniqueFileName = UploadedFile(model, "ProfilePhoto","Profile");
            Service_personal_info personal_Info = context.Set<Service_personal_info>().SingleOrDefault(c => (c.user_id == HttpContext.Session.GetString("User_Id")));
            if(personal_Info==null)
            {
                Service_personal_info serp = new Service_personal_info
                {
                    user_id = HttpContext.Session.GetString("User_Id"),
                    user_title=model.user_title,
                    first_name = model.first_name,
                    middle_name = model.middle_name,
                    last_name = model.last_name,
                    gender = model.gender,
                    religion = model.religion,
                    dob = Convert.ToDateTime(model.dob),
                    age = Convert.ToString(today.Year-dateofb.Year),
                    maritial_status=model.maritial_status,
                    marriage_date=Convert.ToDateTime(model.marriage_date),
                    profile_photo=uniqueFileName,
                    about=model.about,
                    AddedBy= HttpContext.Session.GetString("User_Id"),
                    AddDateTime=DateTime.Now,
                    Status=true


                };
                _repopersonalinfo.Insert(serp);
            }
            else
            {
                Service_personal_info SerInfoU = _repopersonalinfo.Get(personal_Info.Id);
                SerInfoU.first_name = model.first_name;
                SerInfoU.user_title = model.user_title;
                SerInfoU.middle_name = model.middle_name;
                SerInfoU.gender = model.gender;
                SerInfoU.religion = model.religion;
                SerInfoU.dob = Convert.ToDateTime(model.dob);
                SerInfoU.age = Convert.ToString(today.Year - dateofb.Year);
                SerInfoU.maritial_status = model.maritial_status;
                SerInfoU.marriage_date = Convert.ToDateTime(model.marriage_date);
                if (model.ProfileImage == null)
                {
                    SerInfoU.profile_photo = model.profile_photo;
                }
             
                else
                {
                    SerInfoU.profile_photo = UploadedFile(model, "ProfilePhoto", "Profile");
                }
                SerInfoU.about = model.about;
                SerInfoU.ModifiedBy = personal_Info.user_id;
                SerInfoU.ModifiedDatime = DateTime.Now;

                _repopersonalinfo.Update(SerInfoU);

            }
            return View("Profile", model);
        }

        [HttpPost]
        public IActionResult Iddetails(Profile_View model)
        {
            //User_Identification user_Identification = context.Set<User_Identification>().SingleOrDefault(c => (c.user_id == HttpContext.Session.GetString("User_Id")));
            if (HttpContext.Session.GetString("User_Id_Identitiy") == null)
            {
                User_Identification user_Identification = new User_Identification
                {
                    user_id = HttpContext.Session.GetString("User_Id"),
                    add_doc_type = model.add_doc_type,
                    add_doc = UploadedFile(model, "Id_Doc","Add_Proff"),
                    add_doc_no = model.add_doc_no,
                    id_doc_type = model.id_doc_type,
                    id_doc_no = model.id_doc_no,
                    id_doc = UploadedFile(model, "Id_Doc","ID_Proff"),
                    pan_card = UploadedFile(model, "Id_Doc","PAN"),
                    pan_card_no = model.pan_card_no,
                    dl = UploadedFile(model, "Id_Doc","DL"),
                    dl_no = model.dl_no,
                    AddedBy = HttpContext.Session.GetString("User_Id"),
                    AddDateTime = DateTime.Now,
                    Status=true


                };
                _repouseridentification.Insert(user_Identification);
            }
            else
            {
                User_Identification user_Identification = _repouseridentification.Get(Convert.ToInt64(HttpContext.Session.GetString("User_Id_Identitiy")));
                user_Identification.add_doc_type = model.add_doc_type;
                user_Identification.add_doc_no = model.add_doc_no;
                if(model.add_doc==null)
                {
                    user_Identification.add_doc = UploadedFile(model, "Id_Doc", "Add_Proff");
                }
                else
                {
                    user_Identification.add_doc = model.add_doc;
                }
                user_Identification.id_doc_type = model.id_doc_type;
                user_Identification.id_doc_no = model.id_doc_no;
                if(model.id_doc!=null)
                {
                    user_Identification.id_doc= UploadedFile(model, "Id_Doc", "ID_Proff");
                }
                else
                {
                    user_Identification.id_doc = model.id_doc;
                }
                user_Identification.pan_card_no = model.pan_card_no;
                if(model.pan_card != null)
                {
                    user_Identification.pan_card = UploadedFile(model, "Id_Doc","PAN");
                }
                else
                {
                    user_Identification.pan_card = model.pan_card;
                }
                user_Identification.dl_no = model.dl_no;
                if (model.dl != null)
                {
                    user_Identification.dl = UploadedFile(model, "Id_Doc","DL");
                }
                else
                {
                    user_Identification.dl = model.dl;
                }
                _repouseridentification.Update(user_Identification);
            }
            return View("Profile", model);
        }

        public IActionResult Bank_Details(Profile_View model)
        {
            if (HttpContext.Session.GetString("Bank_Detail_Id") == null)
            {
                Service_User_Bank_Details service_User_Bank_Details = new Service_User_Bank_Details
                {
                    user_id = HttpContext.Session.GetString("User_Id"),
                    bank_name = model.bank_name,
                    ifsc_code= model.ifsc_code,
                    account_name=model.account_name,
                    account_number=model.account_number,
                    upi_id=model.upi_id,
                    AddedBy= HttpContext.Session.GetString("User_Id"),
                    AddDateTime=DateTime.Now,
                    Status=true
                };
                _reposerviceuserbank.Insert(service_User_Bank_Details);
            }
            else
            {
                Service_User_Bank_Details service_User_Bank_Details = _reposerviceuserbank.Get(Convert.ToInt64(HttpContext.Session.GetString("Bank_Detail_Id")));
                service_User_Bank_Details.bank_name = model.bank_name;
                service_User_Bank_Details.account_name = model.account_name;
                service_User_Bank_Details.ifsc_code = model.ifsc_code;
                service_User_Bank_Details.account_number = model.account_number;
                service_User_Bank_Details.upi_id = model.upi_id;
                service_User_Bank_Details.ModifiedBy = HttpContext.Session.GetString("User_Id");
                service_User_Bank_Details.ModifiedDatime = DateTime.Now;
                _reposerviceuserbank.Update(service_User_Bank_Details);

            }
            return View("Profile", model);
        }
        [HttpPost]
        public IActionResult Contact_detail(Profile_View model)
        {
            if (HttpContext.Session.GetString("User_Id_Contact") == null)
            {
                User_Contact_Details user_Contact_Details = new User_Contact_Details
                {
                    user_id = HttpContext.Session.GetString("User_Id"),
                    primery_contact_number = model.primery_contact_number,
                    secondry_contact_number = model.secondry_contact_number,
                    Status = true,
                    AddedBy = HttpContext.Session.GetString("User_Id"),
                    AddDateTime = DateTime.Now
                };
                _repocontactdetails.Insert(user_Contact_Details);
            }
            else
            {
                User_Contact_Details user_Contact_Details  = _repocontactdetails.Get(Convert.ToInt64(HttpContext.Session.GetString("User_Id_Contact")));
                user_Contact_Details.primery_contact_number = model.primery_contact_number;
                user_Contact_Details.secondry_contact_number = model.secondry_contact_number;
                _repocontactdetails.Update(user_Contact_Details);

            }
            
                return View("Profile", model);
        }

        [HttpPost]
        public IActionResult Experiance(Profile_View model)
        {
            //var user = await _userManager.GetUserAsync(User);
            var today = DateTime.Today;
            var dateofb = Convert.ToDateTime(model.dob);
            
            Service_User_Exp_Edu Exp_Info = context.Set<Service_User_Exp_Edu>().SingleOrDefault(c => (c.user_id == HttpContext.Session.GetString("User_Id")));
            if (Exp_Info == null)
            {
                Service_User_Exp_Edu serp = new Service_User_Exp_Edu
                {
                    user_id = HttpContext.Session.GetString("User_Id"),
                    edu_qalif=model.edu_qalif,
                    experience=model.experience,
                    certified=model.certified,
                    certified_year=model.certified_year,
                    certificate_no=model.certificate_no,
                    cerified_institute=model.cerified_institute,
                    AddedBy= HttpContext.Session.GetString("User_Id"),
                    AddDateTime=DateTime.Now,
                    Status=true



                };
                _repoeduinfo.Insert(serp);
            }
            else
            {
                Service_User_Exp_Edu SerInfoU = _repoeduinfo.Get(Exp_Info.Id);
                SerInfoU.edu_qalif = model.edu_qalif;
                SerInfoU.experience = model.experience;
                SerInfoU.certified =  model.certified;
                SerInfoU.certified_year = model.certified_year;
                SerInfoU.edu_qalif = model.edu_qalif;
                SerInfoU.certificate_no = model.certificate_no;
                SerInfoU.cerified_institute = model.cerified_institute;
                SerInfoU.ModifiedBy = Exp_Info.user_id;
                SerInfoU.ModifiedDatime = DateTime.Now;
                _repoeduinfo.Update(SerInfoU);

            }
            return View("Profile", model);
        }

        [HttpPost]
        public IActionResult Skills_Details(Profile_View model)
        {
            
            Serivice_User_Skills serivice_User_Skills = new Serivice_User_Skills
            {
                user_id = HttpContext.Session.GetString("User_Id"),
                service_type_id =model.Service_Type_Id,
                service_id=model.Service_Id,
                AddedBy = HttpContext.Session.GetString("User_Id"),
                AddDateTime=DateTime.Now,
                Status=true
            };
            _reposkills.Insert(serivice_User_Skills);
            return View("Profile", model);
        }
        
        [HttpPost]
        public IActionResult Duty_Status(Profile_View model, string Duty_button)
        {
            Duty_Status duty_status = context.Set<Duty_Status>().SingleOrDefault(c => (c.user_id == HttpContext.Session.GetString("User_Id")));
            
            if(Duty_button=="Duty On")
            {
                duty_status.Status = true;
                model.duty = "Duty Off";
            }
            else
            {
                duty_status.Status = false;
                model.duty = "Duty On";
            }
            duty_status.ModifiedBy = duty_status.user_id;
            duty_status.ModifiedDatime = DateTime.Now;
            _repodutystatus.Update(duty_status);
            return View("Profile", model);
        }

        private string UploadedFile(Profile_View model,string Foldername,string name)
        {
            string uniqueFileName = null;

            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, Foldername);
            if (name == "Profile")
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
                
            }
            else if(name=="Add_Proff")
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.add_doc_file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.add_doc_file.CopyTo(fileStream);
                }

            }
            else if(name=="ID_Proff")
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.id_doc_file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.id_doc_file.CopyTo(fileStream);
                }
            }
            else if(name=="PAN")
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.pan_card_file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.pan_card_file.CopyTo(fileStream);
                }
            }
            else if(name=="DL")
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.dl_file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.dl_file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


    }
}
