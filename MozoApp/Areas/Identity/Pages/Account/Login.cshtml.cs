using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MozoModels.Models;
using MozoUtilty.Utility;
using NuGet.Common;
using MozoDataAccess.Repository;

namespace MozoApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IServiceRepository<User_Location> _repouserlocation; 

        public LoginModel(SignInManager<ApplicationUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<ApplicationUser> userManager,
            IServiceRepository<User_Location> repouserlocation)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this._repouserlocation = repouserlocation;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public bool IsPhoneVerified { get; set; } = true;

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "OTP")]
            public string OTP { get; set; }
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }

            public double lat { get; set; }
            public double log { get; set; }
            public string address { get; set; }
            public string city { get; set; }
          
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result= await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false); 
                if(DigitOnly.IsDigitsOnly(Input.Email)==true)
				{

                    var user = _userManager.Users.FirstOrDefault(item => item.PhoneNumber == Input.Email);
                    if (user != null)
                    {
                        result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                    }
                    else
					{
                        ModelState.AddModelError(string.Empty, "User or password incorrect");
                    }

                }
                else
				{

				
                result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                }
                if (result.Succeeded)
                {
                    

                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                   
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public void Save_Location(string userid, double lat,double lng,string map_add,string city)
        {
            User_Location user_Location = new User_Location
            {
                user_id = userid,
                latitude = lat,
                longitude = lng,
                map_address = map_add,
                city = city,
                AddedBy = userid,
                AddDateTime = DateTime.Now
            };
        }
    }
}
