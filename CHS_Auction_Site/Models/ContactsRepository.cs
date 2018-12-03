using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CHS_Auction_Site.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContactsRepository : IContactRepo
    {

        public IQueryable<Contacts> Contacts => new List<Contacts> {
            new Contacts { contactID = 10, contactType = "Hello" }
            }.AsQueryable<Contacts>();
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FakeTestRepositoryExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContactsRepository>();
        }
    }
}
