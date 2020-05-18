using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using ECommerceLabWebApp.Models.Interfaces;

namespace ECommerceLabWebApp.Models.Services
{
    public class EmailService : IEmail
    {
        //dependency injection
        private IConfiguration _config;

        public EmailService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string html)
        {
            //establish client and message content
            SendGridClient client = new SendGridClient(_config["SendGridKey"]);
            SendGridMessage msg = new SendGridMessage();

            //
            //need to figure out what our mail acct is
            //
            msg.SetFrom("dontknow@notsure.com", "NAME GOES HERE");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, html);

            await client.SendEmailAsync(msg);
        }
    }
}
