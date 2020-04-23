using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Models
{
    interface IInventory
    {
        //Create
        Task<Product> CreateProductAsync(Product product);

        //Read
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetAllProductsAsync();

        //Update
        Task UpdateProductAsync(Product product);

        //Delete
        Task RemoveProductAsync(int id);
    }
}
