using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLabWebApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Return index view on GET request
        /// </summary>
        /// <returns>Index.html found in Views folder</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}