using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceLabWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerceLabWebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public LoginInput LoginData { get; set; }

        public LoginModel(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signIn)
        {
            _userManager = usermanager;
            _signInManager = signIn;
        }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            //sets a url to return to on success
            returnUrl = returnUrl ?? Url.Content("~/");

            //if the form data is valid, proceed to login attempt
            if (ModelState.IsValid)
            {
                //login attempt. carries a success/failure prop
                var result = await _signInManager.PasswordSignInAsync(LoginData.Email, LoginData.Password, true, false);

                //action if login succeeded
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }

                //action if user is locked out of account
                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }

                //action if login failed
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login");
                    return Page();
                }
            }
            //action if form data is invalid
            return Page();
        }

        public class LoginInput
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}