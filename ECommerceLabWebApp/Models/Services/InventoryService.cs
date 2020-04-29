using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ECommerceLabWebApp.Data;
using ECommerceLabWebApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceLabWebApp.Models.Services
{
    public class InventoryService : IInventory
    {
        //dependency injection for database context
        private StoreDbContext _context;

        public InventoryService(StoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adding a new product to database
        /// </summary>
        /// <param name="product">The product object to be added</param>
        /// <returns>The product object passed in (NOT the new object from database)</returns>
        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        /// <summary>
        /// Gets a list of all products in database
        /// </summary>
        /// <returns>A list of all products</returns>
        public async Task<List<Product>> GetAllProductsAsync() => await _context.Products.ToListAsync();

        /// <summary>
        /// Gets a single product by a given ID
        /// </summary>
        /// <param name="id">The ID of the product</param>
        /// <returns>The product object</returns>
        public async Task<Product> GetProductByIdAsync(int id) => await _context.Products.FindAsync(id);

        /// <summary>
        /// Removes the product with the given ID from database
        /// </summary>
        /// <param name="id">The ID of the product</param>
        /// <returns>void</returns>
        public async Task RemoveProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a product in database. No ID is needed as the ID value in the product passed in is used.
        /// </summary>
        /// <param name="product">The updated form of the product</param>
        /// <returns>void</returns>
        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
