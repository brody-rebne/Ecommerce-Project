using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerceLabWebApp.Data;
using ECommerceLabWebApp.Models.Services;
using ECommerceLabWebApp.Models.Interfaces;
using ECommerceLabWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerceLabWebApp.Components
{
    [ViewComponent]
    public class Cart : ViewComponent
    {
        private IInventory _inventory;
        private ICartItems _cartItems;
        private ICart _cart;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public Cart(StoreDbContext context, IInventory inventory, ICartItems cartItems, ICart cart, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _inventory = inventory;
            _cartItems = cartItems;
            _cart = cart;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await _cart.GetCartByOwner(User.Identity.Name);
            var cartItems = await _cartItems.GetCartItemsByOwnerAsync(cart.Owner);

            string username = User.Identity.Name;

            // _cart.GetCartItemsByIdAsync(cartId)
            foreach(var item in cartItems)
            {
                item.Product = await _inventory.GetProductByIdAsync(item.ProductID);
            }

            return View(cartItems);
        }
    }
}
