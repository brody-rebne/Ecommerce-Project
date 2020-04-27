using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Models
{
    /// <summary>
    /// Inventory management service containing CRUD functionality for products
    /// </summary>
    public interface IInventory
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
