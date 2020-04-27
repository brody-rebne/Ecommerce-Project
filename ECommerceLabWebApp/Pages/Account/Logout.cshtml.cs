using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceLabWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceLabWebApp.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Action on page load
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Performs user logout via GET request
        /// </summary>
        /// <returns>Redirect to homepage</returns>
        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
