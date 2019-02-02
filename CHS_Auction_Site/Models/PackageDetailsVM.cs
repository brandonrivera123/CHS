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
    }
}
