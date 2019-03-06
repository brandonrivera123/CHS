using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHS_Auction_Site.Models
{
    public class Tickets
    {
        public int GuestId { get; set; }
        public int EventId { get; set; }
        public int TicketQuantity { get; set; }
        public int TicketPrice { get; set; }
        public int TicketTotalPrice { get; set; }
        public int TransactionId { get; set; }

        public Guests Guest { get; set; }
        public Events Event { get; set; }
        public Transactions Transaction { get; set; }
    }
}
