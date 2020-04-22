  using System;
using Xunit;
using ECommerceLabWebApp;
using ECommerceLabWebApp.Models;
using Microsoft.EntityFrameworkCore;
using ECommerceLabWebApp.Data;
using ECommerceLabWebApp.Models.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ECommerceLabWebAppTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateProduct()
        {
            Product testProd = new Product();

            Assert.IsType<Product>(testProd);
        }

        [Fact]
        public void CanPopulateProductData()
        {
            Product testP = new Product
            { 
                ID = 10,
                SKU = "testSKU",
                Name = "testName",
                Description = "testDescription",
                Price = 100,
                ImageUrl = "testUrl"
            };

            Assert.Equal(10, testP.ID);
            Assert.Equal("testSKU", testP.SKU);
            Assert.Equal("testName", testP.Name);
            Assert.Equal("testDescription", testP.Description);
            Assert.Equal(100, testP.Price);
            Assert.Equal("testUrl", testP.ImageUrl);
        }

        [Fact]
        public async Task CanAddProductToDb()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanAddProductToDb")
                .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryService ps = new InventoryService(context);

                Product testP = new Product
                {
                    ID = 10,
                    SKU = "testSKU",
                    Name = "testName",
                    Description = "testDescription",
                    Price = 100,
                    ImageUrl = "testUrl"
                };

                var result = await ps.CreateProductAsync(testP);

                var data = context.Products.Find(testP.ID);

                Assert.Equal(result, data);
            }
        }
    }
}
