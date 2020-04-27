using ECommerceLabWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Data
{
    /// <summary>
    /// Database context for database of products and other store data
    /// </summary>
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Actions performed upon database model creation
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding our data
            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    ID = 1,
                    SKU = "12345",
                    Name = "Pigs Feet",
                    Description = "Spicy Pickled Pigs Feet",
                    Price = 2,
                    ImageUrl = "wwwroot/img/PigFeet.jpg"
                },

                new Product
                {
                    ID = 2,
                    SKU = "23456",
                    Name = "Cheese",
                    Description = "One package of delicous cheese",
                    Price = 1,
                    ImageUrl = "wwwroot/img/cheese.jpg"
                },

                new Product
                {
                    ID = 3,
                    SKU = "34567",
                    Name = "Eggs",
                    Description = "Four raw eggs",
                    Price = 5,
                    ImageUrl = "wwwroot/img/cheese.jpg"
                },

                new Product
                {
                    ID = 4,
                    SKU = "45678",
                    Name = "Chips",
                    Description = "Small bag of Chicken and Waffles chips",
                    Price = 3,
                    ImageUrl = "wwwroot/img/Chips.jpg"
                },

                new Product
                {
                    ID = 5,
                    SKU = "56789",
                    Name = "Jerky",
                    Description = "One medium sized bag of jerky",
                    Price = 7,
                    ImageUrl = "wwwroot/img/Jerky.jpg"
                },

                new Product
                {
                    ID = 6,
                    SKU = "67890",
                    Name = "Lutefisk",
                    Description = "One can of delicous Lutefisk",
                    Price = 8,
                    ImageUrl = "wwwroot/img/Lutefisk.jpg"
                },

                new Product
                {
                    ID = 7,
                    SKU = "78901",
                    Name = "Catepillars",
                    Description = "High in protein",
                    Price = 5,
                    ImageUrl = "wwwroot/img/Caterpillar.jpg"
                },

                new Product
                {
                    ID = 8,
                    SKU = "89012",
                    Name = "Pork Rinds",
                    Description = "One bag of microwavable Pork Rinds",
                    Price = 3,
                    ImageUrl = "wwwroot/img/PorkRindsjpg"
                },

                new Product
                {
                    ID = 9,
                    SKU = "90123",
                    Name = "Vienna Sausage",
                    Description = "America's Favorite!",
                    Price = 1,
                    ImageUrl = "wwwroot/img/ViennaSausage.jpg"
                },

                new Product
                {
                    ID = 10,
                    SKU = "01234",
                    Name = "Beans",
                    Description = "One can of beans",
                    Price = 1,
                    ImageUrl = "wwwroot/img/beans.jpg"
                }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}
