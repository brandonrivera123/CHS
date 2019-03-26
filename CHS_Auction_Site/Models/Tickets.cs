using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CHS_Auction_Site.Models
{
    public class Tickets
    {
        public int TicketId { get; set; }
        public int GuestId { get; set; }
        public int EventId { get; set; }
        public int TicketQuantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int TicketPrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int TicketTotalPrice { get; set; }
        public int TransactionId { get; set; }

        public Guests Guest { get; set; }
        public Events Event { get; set; }
        public Transactions Transaction { get; set; }
    }
}
