using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ECommerceLabWebApp.Data;

namespace ECommerceLabWebApp.Models
{
    public class Roles
    {
        /// <summary>
        /// Creating our list of roles
        /// </summary>
        private static readonly List<IdentityRole> roleList = new List<IdentityRole>()
        {
            //admin role
            new IdentityRole
            {
                Name = ApplicationRoles.Admin,
                NormalizedName = ApplicationRoles.Admin.ToUpper(),
                //guid = Global Unique Identifier
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },

            //member role
            new IdentityRole
            {
                Name = ApplicationRoles.Member,
                NormalizedName = ApplicationRoles.Member.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        };

        /// <summary>
        /// Seeds the created roles in our db
        /// </summary>
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
            }
        }

        public static void AddRoles(ApplicationDbContext context)
        {
            if (context.Roles.Any())
                return;

            foreach(var role in roleList)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }
    }
}
