using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLabWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

/*        [HttpGet]
        [Route("/Account/Register")]
        public IActionResult Register()
        {
            return RedirectToPage("Register");
        }

        [HttpGet]
        [Route("/Account/Login")]
        public IActionResult Login()
        {
            return RedirectToPage("Login");
        }*/
    }
}