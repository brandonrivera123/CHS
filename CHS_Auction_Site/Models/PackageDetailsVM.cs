using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHS_Auction_Site.Models
{
    public class PackageDetailsVM
    {
        public Packages Packages { get; set; }
        public IEnumerable<Items> Items { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCategory { get; set; }
        public string ItemImage { get; set; }
        public int ItemValue { get; set; }
        public int? PackageId { get; set; }
        public int GuestId { get; set; }
    }
}
