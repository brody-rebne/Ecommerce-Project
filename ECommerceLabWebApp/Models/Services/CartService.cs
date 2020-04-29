using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceLabWebApp.Data;
using ECommerceLabWebApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ECommerceLabWebApp.Models.Services
{
    public class CartService : ICart
    {
        //dependency injection
        private StoreDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public CartService(StoreDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Adding a new cart to database
        /// </summary>
        /// <param name="cart">The cart object to be added</param>
        /// <returns>The cart object passed in (NOT the new object from database</returns>
        public async Task<Cart> CreateCart(Cart cart)
        {
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return cart;
        }

        /// <summary>
        /// Gets a single cart by a given ID
        /// </summary>
        /// <param name="id">The ID of the cart</param>
        /// <returns>The cart object</returns>
        public async Task<Cart> GetCartById(string id) => await _context.Cart.FindAsync(id);


        /// <summary>
        /// Gets a cart by the corresponding user id
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>The cart</returns>
        //public async Task<Cart> GetCartByOwner(string userId) => await _context.Cart.Where(x => x.UserID == userId).FirstAsync();
        public async Task<Cart> GetCartByOwner(string username)
        {
            var currentUser = await _userManager.FindByNameAsync(username);
            return await _context.Cart.FirstOrDefaultAsync(x => x.Owner == currentUser.Id);
        }

        /// <summary>
        /// Gets a cart's id by the corresponding user id
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>The cart id</returns>
        //public async Task<Cart> GetCartByOwner(string userId) => await _context.Cart.Where(x => x.UserID == userId).FirstAsync();
        public async Task<int> GetCartIdByOwner(string username)
        {
            var currentUser = await _userManager.FindByNameAsync(username);
            var cart = await _context.Cart.FirstOrDefaultAsync(x => x.Owner == currentUser.Id);

            return cart.ID;
        }

        /// <summary>
        /// Removes the cart with a given ID from database
        /// </summary>
        /// <param name="id">The ID of the cart to be removed</param>
        /// <returns>void</returns>
        public async Task RemoveCart(string id)
        {
            var cart = await GetCartById(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
        }
    }
}
