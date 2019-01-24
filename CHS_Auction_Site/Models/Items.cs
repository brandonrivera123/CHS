using System;
using System.Collections.Generic;

namespace CHS_Auction_Site.Models
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCategory { get; set; }
        public string ItemImage { get; set; }
        public int ItemValue { get; set; }
        public int? PackageId { get; set; }
        public int GuestId { get; set; }

        public Guests Guest { get; set; }
        public Packages Package { get; set; }
    }
}
