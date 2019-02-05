using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CHS_Auction_Site.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ItemPackagesVM
    {
        public IEnumerable<Items> items { get; set; }
        public IEnumerable<Packages> packages { get; set; }
    }

}
