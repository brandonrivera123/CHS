using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHS_Auction_Site.Models
{
    public class EditTicketVM
    {
        public IEnumerable<Tickets> Tickets { get; set; }

        public int TicketId { get; set; }
        public int GuestId { get; set; }
        public int EventId { get; set; }
        public int TicketQuantity { get; set; }
        public int TicketPrice { get; set; }
        public int TicketTotalPrice { get; set; }
        public int TransactionId { get; set; }
    }
}
