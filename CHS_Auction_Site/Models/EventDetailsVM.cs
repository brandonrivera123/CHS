using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHS_Auction_Site.Models
{
    public class EventDetailsVM
    {
        public Events Events { get; set; }
        public Packages GetPackageLocations { get; set; }
        public IEnumerable<Packages> Packages { get; set; }

        public int PackageId { get; set; }
        public string PackageDescription { get; set; }
        public int PackageStartBid { get; set; }
        public int PackageBidIncrement { get; set; }
        public int? PackageFinalPrice { get; set; }
        public int EventId { get; set; }
        public int? TransactionId { get; set; }
    }
}
