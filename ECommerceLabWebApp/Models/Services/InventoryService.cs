using ECommerceLabWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Models.Services
{
    public class InventoryService : IInventory
    {
        private StoreDbContext _context;

        public InventoryService(StoreDbContext context)
        {
            _context = context;
        }


        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }


        public async Task<List<Product>> GetAllProductsAsync() => await _context.Products.ToListAsync();


        public async Task<Product> GetProductByIdAsync(int id) => await _context.Products.FindAsync(id);


        public async Task RemoveProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
