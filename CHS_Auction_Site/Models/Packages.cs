using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CHS_Auction_Site.Models
{
    public partial class Packages
    {
        public Packages()
        {
            Items = new HashSet<Items>();
        }

        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int PackageStartBid { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int PackageBidIncrement { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int? PackageFinalPrice { get; set; }
        public int EventId { get; set; }
        public int? TransactionId { get; set; }

        public Events Event { get; set; }
        public Transactions Transaction { get; set; }
        public ICollection<Items> Items { get; set; }
    }
}
