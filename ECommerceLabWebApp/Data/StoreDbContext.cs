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
            modelBuilder.Entity<Product>().ToTable("Products");

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    ID = 1,
                    SKU = "12345",
                    Name = "Widget",
                    Description = "Description of Widget",
                    Price = 30,
                    ImageUrl = ""
                },

                new Product
                {
                    ID = 2,
                    SKU = "23456",
                    Name = "Sprocket",
                    Description = "Description of Sprocket",
                    Price = 40,
                    ImageUrl = ""
                },

                new Product
                {
                    ID = 3,
                    SKU = "34567",
                    Name = "Thingamabob",
                    Description = "Description of Thingamabob",
                    Price = 15,
                    ImageUrl = ""
                },

                new Product
                {
                    ID = 4,
                    SKU = "45678",
                    Name = "Gizmo",
                    Description = "Description of Gizmo",
                    Price = 200,
                    ImageUrl = ""
                },

                new Product
                {
                    ID = 5,
                    SKU = "56789",
                    Name = "Gadget",
                    Description = "Description of Gadget",
                    Price = 70,
                    ImageUrl = ""
                },

                new Product
                {
                    ID = 6,
                    SKU = "67890",
                    Name = "Device",
                    Description = "Description of Device",
                    Price = 90,
                    ImageUrl = ""
                },

                new Product
                {
                    ID = 7,
                    SKU = "78901",
                    Name = "Doohickey",
                    Description = "Description of Doohickey",
                    Price = 5,
                    ImageUrl = ""
                },

                new Product
                {
                    ID = 8,
                    SKU = "89012",
                    Name = "Rube Goldberg Machine",
                    Description = "Description of Rube Goldberg Machine",
                    Price = 42,
                    ImageUrl = ""
                },

                new Product
                {
                    ID = 9,
                    SKU = "90123",
                    Name = "Contraption",
                    Description = "Description of Contraption",
                    Price = 100,
                    ImageUrl = ""
                },

                new Product
                {
                    ID = 10,
                    SKU = "01234",
                    Name = "Whatchamacallit",
                    Description = "Description of Whatchamacallit",
                    Price = 0,
                    ImageUrl = ""
                }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}
