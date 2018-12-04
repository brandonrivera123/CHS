using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CHS_Auction_Site.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuctionItem
    {
        public int auctionItemID { get; set; }
        public string item { get; set; }
        public string imageID { get; set; }
        public int salePrice { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public string category { get; set; }

        private readonly RequestDelegate _next;

        public AuctionItem(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuctionItemExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuctionItem>();
        }
    }
}
