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
        private IInventory _inventory;
        public ProductDetailsModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        public Product product { get; set; }

        public async Task OnGetAsync(int id)
        {
            product = await _inventory.GetProductByIdAsync(id);
        }
    }
}