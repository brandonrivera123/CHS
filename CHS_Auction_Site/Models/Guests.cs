using System;
using System.Collections.Generic;

namespace CHS_Auction_Site.Models
{
    public partial class Guests
    {
        public Guests()
        {
            CheckIns = new HashSet<CheckIns>();
            Items = new HashSet<Items>();
            Tickets = new HashSet<Tickets>();
            Transactions = new HashSet<Transactions>();
        }

        public int GuestId { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public string GuestEmail { get; set; }
        public string GuestPhone { get; set; }
        public int? OrganizationId { get; set; }
        public string GuestAddress { get; set; }
        public string GuestCity { get; set; }
        public string GuestState { get; set; }
        public int GuestZip { get; set; }

        public Organizations Organization { get; set; }
        public ICollection<Items> Items { get; set; }
        public ICollection<Transactions> Transactions { get; set; }
        public ICollection<CheckIns> CheckIns { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }
}
