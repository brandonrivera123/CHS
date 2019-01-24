using System;
using System.Collections.Generic;

namespace CHS_Auction_Site.Models
{
    public partial class Organizations
    {
        public Organizations()
        {
            Guests = new HashSet<Guests>();
        }

        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }

        public ICollection<Guests> Guests { get; set; }
    }
}
