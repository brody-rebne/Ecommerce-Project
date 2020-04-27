using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceLabWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceLabWebApp.Pages
{
    public class ProductsModel : PageModel
    {
        //dependency injection

        private IInventory _inventory;

        public ProductsModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        /// <summary>
        /// The list of products to be rendered to the page
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// On page load, gets a list of all products from database and adds it to the page model
        /// </summary>
        /// <returns>void</returns>
        public async Task OnGet()
        {
            Products = await _inventory.GetAllProductsAsync();
        }
    }
}
