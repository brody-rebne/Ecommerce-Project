using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Models.Interfaces
{
    public interface ICart
    {
        //create
        Task<Cart> CreateCart(Cart cart);

        //read
        Task<Cart> GetCartById(string id);
        Task<Cart> GetCartByOwner(string username);
        Task<int> GetCartIdByOwner(string username);

        //delete
        Task RemoveCart(string id);
    }
}
