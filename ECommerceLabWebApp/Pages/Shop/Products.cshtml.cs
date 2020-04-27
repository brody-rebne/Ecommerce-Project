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
        private IInventory _inventory;


        public ProductsModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        public IEnumerable<Product> Products { get; set; }

        public async Task OnGet()
        {
            Products = await _inventory.GetAllProductsAsync();
        }
    }
}
