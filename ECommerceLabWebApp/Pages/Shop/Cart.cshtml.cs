using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ECommerceLabWebApp.Models;
using ECommerceLabWebApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerceLabWebApp.Pages.Shop
{
    public class CartModel : PageModel
    {
        //dependency injection
        private ICartItems _cartItems;

        public CartModel(ICartItems cartItems)
        {
            _cartItems = cartItems;
        }
        //

        //cart items for model
        public List<CartItems> Items { get; set; }
        //

        //bind properties from form inputs
        [BindProperty]
        public UpdateDataInput UpdateData { get; set; }
        [BindProperty]
        public RemoveDataInput RemoveData { get; set; }
        //

        public async Task OnGet()
        {
            Items = await _cartItems.GetCartItemsByOwnerAsync(User.Identity.Name);
        }

        public async Task OnPut()
        {
            if (ModelState.IsValid)
            {
                foreach(var item in Items)
                {
                    if(item.ProductID == Convert.ToInt32(UpdateData.ProductID))
                    {
                        item.Qty = Convert.ToInt32(UpdateData.Qty);
                        await _cartItems.UpdateCartItemsAsync(item);
                    }
                }
            }
        }

        public async Task OnDelete()
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByNameAsync(username);
                _cartItems.RemoveCartItemsAsync()
            }
        }

        //models for form input
        public class UpdateDataInput
        {
            [Required]
            public string Qty { get; set; }
            [Required]
            public string ProductID { get; set; }
        }

        public class RemoveDataInput
        {
            [Required]
            public string ProductID { get; set; }
        }
        //
    }
}
