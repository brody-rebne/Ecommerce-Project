using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using ECommerceLabWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerceLabWebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        //dependency injection

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public LoginInput LoginData { get; set; }

        public LoginModel(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signIn)
        {
            _userManager = usermanager;
            _signInManager = signIn;
        }

        /// <summary>
        /// Action on page load
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Performs user login via GET request.
        /// </summary>
        /// <param name="returnUrl">URL path to redirect to on successful login. If no value is given will redirect to homepage.</param>
        /// <returns>Redirect to given url if login succeeds, redirect to lockout page if user is locked out, refresh of page if login or form data is invalid</returns>
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

        /// <summary>
        /// Login input class for use in hashed identity database
        /// </summary>
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