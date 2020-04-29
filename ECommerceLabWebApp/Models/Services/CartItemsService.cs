using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ECommerceLabWebApp.Data;
using ECommerceLabWebApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceLabWebApp.Models.Services
{
    public class CartItemsService : ICartItems
    {
        //dependency injection for database context
        private StoreDbContext _context;
        private ICart _cart;

        public CartItemsService(StoreDbContext context, ICart cart)
        {
            _context = context;
            _cart = cart;
        }

        /// <summary>
        /// Adding a new cartItems to database
        /// </summary>
        /// <param name="cartItems">The cartItems object to be added</param>
        /// <returns>The cartItems object passed in (NOT the new object from database)</returns>
        public async Task<CartItems> CreateCartItemsAsync(CartItems cartItems)
        {
            _context.CartItems.Add(cartItems);
            await _context.SaveChangesAsync();

            return cartItems;
        }

        /// <summary>
        /// Gets a single cartItems by a given ID
        /// </summary>
        /// <param name="id">The ID of the cartItems</param>
        /// <returns>The cartItems object</returns>
        public async Task<CartItems> GetCartItemsByIdAsync(int id) => await _context.CartItems.FindAsync(id);


        /// <summary>
        /// Gets a list of all cartItems in a given cart from database
        /// </summary>
        /// <returns>A list of all cartItems in the given cart</returns>
        public async Task<List<CartItems>> GetCartItemsByOwnerAsync(string owner)
        {
            int cartId = await _cart.GetCartIdByOwner(owner);
            return await _context.CartItems.Where(x => x.CartID == cartId).ToListAsync();
        }

        /// <summary>
        /// Removes the cartItems with the given ID from database
        /// </summary>
        /// <param name="id">The ID of the cartItems</param>
        /// <returns>void</returns>
        public async Task RemoveCartItemsAsync(int id)
        {
            var cartItems = await GetCartItemsByIdAsync(id);
            _context.CartItems.Remove(cartItems);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a cartItems in database. No ID is needed as the ID value in the cartItems passed in is used.
        /// </summary>
        /// <param name="cartItems">The updated form of the cartItems</param>
        /// <returns>void</returns>
        public async Task UpdateCartItemsAsync(CartItems cartItems)
        {
            _context.CartItems.Update(cartItems);
            await _context.SaveChangesAsync();
        }
    }
}
