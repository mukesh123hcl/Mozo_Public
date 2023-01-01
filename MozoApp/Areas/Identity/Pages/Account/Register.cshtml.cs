using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MozoUtilty.Utility;
using MozoApp.Data;
using System.IO;
using Microsoft.AspNetCore.Http;

using MozoModels.Models;

namespace MozoApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MozoAppContext _db;
        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            //IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            MozoAppContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            //_emailSender = emailSender;
            _db = db;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Name")]
            [StringLength(100, ErrorMessage = "Invalid input. Maximum is 100 characters.")]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Required")]
            [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
            [Display(Name ="Mobile Number")]
            
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]

            
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string OTP { get; set; }
           
        }

        public async Task OnGetAsync( string provider, string returnUrl )
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            HttpContext.Session.SetString("Provider", provider);
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                string otp = Generate_OTP.GenerateRandomOTP(6, saAllowedCharacters);
                
                var user = new ApplicationUser
                {
                    

                    Name = Input.Name,
                    PhoneNumber = Input.PhoneNumber,
                    UserName = Input.Email,
                    Email = Input.Email,
                    AddedDate = System.DateTime.Now,
                    IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                 
                    
                    ModifiedDate =System.DateTime.Now
                    
                    
                //PostalCode = Input.PostalCode
            };
                bool IsPhoneAlreadyRegistered = _userManager.Users.Any(item => item.PhoneNumber == Input.PhoneNumber);
                if (IsPhoneAlreadyRegistered == true)
                {
                    ModelState.AddModelError(string.Empty, "Mobile number "+Input.PhoneNumber+ " already taken");
                }
                else
                {
                    
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {
                        string Provider= HttpContext.Session.GetString("Provider");
                        _logger.LogInformation("User created a new account with password.");
                        if (Provider== "Custmer")
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.CustomerEndUser));
                            
                            await _userManager.AddToRoleAsync(user, SD.CustomerEndUser);
                        }
                        if (Provider == "ServiceProvider")
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.ServiceProviderUser));

                            await _userManager.AddToRoleAsync(user, SD.ServiceProviderUser);
                        }
                        HttpContext.Session.Remove("Provider");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        

                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                        FileStream fileStream = new FileStream("Utility/AccountConfirmation.html", FileMode.Open);
                        string body = string.Empty;
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            body = reader.ReadToEnd();
                        }
                        body = body.Replace("{ConfirmationLink}", callbackUrl);
                        body = body.Replace("{UserName}", Input.Name);
                        bool IsSendEmail = SendEmail.EmailSend(Input.Email, "Confirm your account", body, true);
                        if (IsSendEmail == true)
                        {
                            HttpContext.Session.SetString("OTP", otp.ToString());
                            Send_Sms.SMS_send(Input.PhoneNumber, otp, Input.Name);
                            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, userid=user.Id,  returnUrl = returnUrl });
                        }

                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, userid = user.Id,  returnUrl = returnUrl });
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
