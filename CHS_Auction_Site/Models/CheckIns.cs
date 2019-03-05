using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHS_Auction_Site.Models
{
    public class CheckIns
    {

        public int CheckInId { get; set; }
        public int CheckInBidderNumber { get; set; }
        public int GuestId { get; set; }
        public int EventId { get; set; }

        public Guests Guest { get; set; }
        public Events Event { get; set; }
    }
}
