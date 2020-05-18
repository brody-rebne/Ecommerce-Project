using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceLabWebApp.Models;
using ECommerceLabWebApp.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceLabWebApp.Pages.Account
{
    //route will be /account/register
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ICart _cart;

        [BindProperty]
        public RegisterInput RegisterData { get; set; }

        public RegisterModel(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signIn, ICart cart)
        {
            _userManager = usermanager;
            _signInManager = signIn;
            _cart = cart;
        }

        /// <summary>
        /// Action on page load
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Creates new user identity from form data
        /// </summary>
        /// <returns>Redirect to home page if successful, refresh if form data is invalid</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = RegisterData.Email,
                    Email = RegisterData.Email,
                    FirstName = RegisterData.FirstName,
                    LastName = RegisterData.LastName,
                    Birthdate = RegisterData.Birthday
                };

                // Create the account using Identity

                var result = await _userManager.CreateAsync(user, RegisterData.Password);

                if (result.Succeeded)
                {
                    //create custom claims for the user
                    Claim name = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    //reconstructing the date from otherwise perfectly fine user input 🙄
                    Claim birthday = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthdate.Year, user.Birthdate.Month, user.Birthdate.Day).ToString("u"), ClaimValueTypes.DateTime);

                    //just regular, well-behaved email
                    Claim email = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    //list of all claims, to add them all at once
                    List<Claim> claims = new List<Claim>()
                    {
                        name, birthday, email
                    };

                    //add all claims at once to the user
                    await _userManager.AddClaimsAsync(user, claims);

                    //creating a cart for the user, keyed off of their username
                    Cart userCart = new Cart()
                    {
                        Owner = user.UserName
                    };

                    await _cart.CreateCart(userCart);

                    //sign the user in.
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    //load up all the errors and send them to the view page
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            //return if form data is invalid
            return Page();
        }

        public class RegisterInput
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime Birthday { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at leat {2} and at max {1} characters long", MinimumLength = 8)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage ="The passwords do not match")]
            public string ConfirmPassword { get; set; }
        }

    }
}