using System;
using System.Collections.Generic;

namespace CHS_Auction_Site.Models
{
    public partial class Transactions
    {
        public Transactions()
        {
            Packages = new HashSet<Packages>();
            Tickets = new HashSet<Tickets>();
        }

        public int TransactionId { get; set; }
        public int TransactionTotalPrice { get; set; }
        public int GuestId { get; set; }

        public Guests Guest { get; set; }
        public ICollection<Packages> Packages { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }
}
