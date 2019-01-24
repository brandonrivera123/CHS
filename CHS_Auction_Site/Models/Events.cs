using System;
using System.Collections.Generic;

namespace CHS_Auction_Site.Models
{
    public partial class Events
    {
        public Events()
        {
            Packages = new HashSet<Packages>();
        }

        public int EventId { get; set; }
        public string EventLocation { get; set; }
        public int EventTicketNum { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }

        public ICollection<Packages> Packages { get; set; }
    }
}
