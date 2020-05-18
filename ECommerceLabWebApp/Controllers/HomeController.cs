using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerceLabWebApp.Models.Interfaces;

namespace ECommerceLabWebApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Return index view on GET request
        /// </summary>
        /// <returns>Index.html found in Views folder</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}