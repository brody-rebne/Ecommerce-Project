using ECommerceLabWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    ID = 1,
                    Name = "Widget",
                    Description = "Description of Widget",
                    Price = 30
                },

                new Product
                {
                    ID = 2,
                    Name = "Sprocket",
                    Description = "Description of Sprocket",
                    Price = 40
                }
                );
        }

        public DbSet<Product> Products { get; set; }
    }
}
