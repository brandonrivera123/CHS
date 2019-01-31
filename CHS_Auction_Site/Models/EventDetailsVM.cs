using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHS_Auction_Site.Models
{
    public class EventDetailsVM
    {
        public Events Events { get; set; }
        public IEnumerable<Packages> Packages { get; set; }
    }
}
