using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Models.Interfaces
{
    public interface ICartItems
    {
        //Create
        Task<CartItems> CreateCartItemsAsync(CartItems cartItems);

        //Read
        Task<CartItems> GetCartItemsByIdAsync(int id);
        Task<List<CartItems>> GetCartItemsByOwnerAsync(string owner);

        //Update
        Task UpdateCartItemsAsync(CartItems cartItems);

        //Delete
        Task RemoveCartItemsAsync(int id);
    }
}
