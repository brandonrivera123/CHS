using System;
using System.Collections.Generic;

namespace CHS_Auction_Site.Models
{
    public partial class Packages
    {
        public Packages()
        {
            Items = new HashSet<Items>();
        }

        public int PackageId { get; set; }
        public string PackageDescription { get; set; }
        public int PackageStartBid { get; set; }
        public int PackageBidIncrement { get; set; }
        public int? PackageFinalPrice { get; set; }
        public int EventId { get; set; }
        public int? TransactionId { get; set; }

        public Events Event { get; set; }
        public Transactions Transaction { get; set; }
        public ICollection<Items> Items { get; set; }
    }
}
