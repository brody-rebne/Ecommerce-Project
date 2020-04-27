using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceLabWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceLabWebApp.Pages.Shop
{
    public class ProductDetailsModel : PageModel
    {
        //dependency injection
        private IInventory _inventory;
        public ProductDetailsModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        /// <summary>
        /// The product whose details are to be rendered on the page
        /// </summary>
        public Product product { get; set; }

        /// <summary>
        /// On page load, gets product by given ID to added to the page's model
        /// </summary>
        /// <param name="id">The ID of the product</param>
        /// <returns>void</returns>
        public async Task OnGetAsync(int id)
        {
            product = await _inventory.GetProductByIdAsync(id);
        }
    }
}