using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHS_Auction_Site.Models
{
    public class EditGuestVM
    {
        public IEnumerable<Guests> Guests { get; set; }

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
    }
}
