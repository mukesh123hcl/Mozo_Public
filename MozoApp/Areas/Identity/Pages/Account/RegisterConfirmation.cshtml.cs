using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using MozoModels.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Twilio.Types;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Diagnostics.Eventing.Reader;
using System;
using Microsoft.AspNetCore.Http;

namespace MozoApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IEmailSender _sender;

        public RegisterConfirmationModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            //_sender = sender;
        }
        public string ReturnUrl { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public string Email { get; set; }
        
        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public object Message { get; }



        public class InputModel
		{
            

            
            [RegularExpression(@"^(\d{6})$", ErrorMessage = "Wrong Code")]
            [Display(Name = "One Time Code")]

            public string OTP { get; set; }
            public string Err_msg { get; set; }
            public bool Phone_Confirmation { get; set; } = true;
            public bool Email_Confirmation { get; set; } = true;
        }

        public async Task<IActionResult> OnGetAsync(string email,  string userid,  string returnUrl = null)
        {
            //TempData["Userid"] = userid.ToString();
            if (email == null)
            {
                return RedirectToPage("/Index");
            }
           
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;
            //user_Id = userid;
            HttpContext.Session.SetString("userid", userid.ToString());
            // Once you add a real email sender, you should remove this code that lets you confirm the account
            DisplayConfirmAccountLink = true;
            if (DisplayConfirmAccountLink)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                
                //Input.PhoneNumber = mobile;
                EmailConfirmationUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    protocol: Request.Scheme);
                 
            }
            
            return Page();
        }

        [TempData]
        public string StatusMessage { get; set; }
        [ViewData]
        public string Msg { get; } = "";
        
        public async Task<IActionResult> OnPostAsync(string returnUrl =null)
        {
            if (ModelState.IsValid)
            {

                string userid = HttpContext.Session.GetString("userid"); 
                if (userid == null)
                {
                    return RedirectToPage("/Index");
                }

                var user = await _userManager.FindByIdAsync(userid);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Unable to find user");
                }

                string otp = HttpContext.Session.GetString("OTP");
                if (otp == Input.OTP)
                {
                    DateTime OTP_Generated_Time = user.ModifiedDate;
                    TimeSpan TS = DateTime.Now - OTP_Generated_Time;
                    if (TS.TotalMinutes <= 10)
                    {
                        user.EmailConfirmed = true;
                        user.PhoneNumberConfirmed = true;
                        user.ModifiedDate = DateTime.Now;
                        user.OTP = null;
                        await _userManager.UpdateAsync(user);
                        HttpContext.Session.Remove("userid");
                        HttpContext.Session.Remove("OTP");
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        user.OTP = null;
                        ModelState.AddModelError(string.Empty, "OTP is Expired");
                        HttpContext.Session.Remove("userid");
                        HttpContext.Session.Remove("OTP");
                        return Page();
                    }
                }
                else
                {
                    ModelState.Clear();
                    HttpContext.Session.Remove("userid");
                    HttpContext.Session.Remove("OTP");
                    ModelState.AddModelError(string.Empty, "Incoreect OTP");
                    return this.Page();
                }
                           }
            HttpContext.Session.Remove("userid");
            HttpContext.Session.Remove("OTP");
            return Page();



        }
    }
}
