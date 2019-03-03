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

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int CategoryId { get; set; }
        public string ItemImage { get; set; }
        public int ItemValue { get; set; }
        public int? PackageId { get; set; }
        public int GuestId { get; set; }
    }

}
