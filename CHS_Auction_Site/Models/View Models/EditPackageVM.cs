using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CHS_Auction_Site.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class EditPackageVM
    {
        public IEnumerable <Packages> Packages { get; set; }

        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public int PackageStartBid { get; set; }
        public int PackageBidIncrement { get; set; }
        public int? PackageFinalPrice { get; set; }
        public int EventId { get; set; }
        public int? TransactionId { get; set; }
    }

}
