using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CHS_Auction_Site.Models
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int? CategoryId { get; set; }
        public string ItemImage { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int ItemValue { get; set; }
        public int? PackageId { get; set; }
        public int GuestId { get; set; }

        public Guests Guest { get; set; }
        public Packages Package { get; set; }
        public Categories Category { get; set; }
    }
}
