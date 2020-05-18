using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ECommerceLabWebApp.Models;
using ECommerceLabWebApp.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceLabWebApp.Pages.Shop
{
    public class ProductDetailsModel : PageModel
    {
        //dependency injection
        private IInventory _inventory;
        private ICartItems _cartItems;
        private ICart _cart;
        private UserManager<ApplicationUser> _userManager;

        public ProductDetailsModel(IInventory inventory, ICartItems cartItems, UserManager<ApplicationUser> userManager, ICart cart)
        {
            _inventory = inventory;
            _cartItems = cartItems;
            _userManager = userManager;
            _cart = cart;
        }

        /// <summary>
        /// The product whose details are to be rendered on the page
        /// </summary>
        public Product product { get; set; }


        [BindProperty]
        public AddDataInput AddData { get; set; }

        /// <summary>
        /// On page load, gets product by given ID to added to the page's model
        /// </summary>
        /// <param name="id">The ID of the product</param>
        /// <returns>void</returns>
        public async Task OnGetAsync(int id)
        {
            product = await _inventory.GetProductByIdAsync(id);
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            //not sure this is needed anymore
            returnUrl = returnUrl ?? Url.Content("~/");

            //Cart cart = await _cart.GetCartByOwner(User.Identity.Name);

            if (ModelState.IsValid)
            {
                CartItems cartItems = new CartItems()
                {
                    CartID = User.Identity.Name,
                    ProductID = Convert.ToInt32(AddData.ProductID),
                    Qty = Convert.ToInt32(AddData.Qty),
                    
                    Product = product,

                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    ProductImageUrl = product.ImageUrl
                };

                var result = await _cartItems.CreateCartItemsAsync(cartItems);

            }

            return RedirectToPage("Products");
        }

        public class AddDataInput
        {
            [Required]
            [Display(Name = "Quantity")]
            public string Qty { get; set; }

            [Required]
            public string ProductID { get; set; }
        }
    }
}