using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLabWebApp.Models.Interfaces
{
    public interface IEmail
    {
        Task SendEmailAsync(string email, string subject, string html);
    }
}
